using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetDimension.Weibo {
	/// <summary>
	/// 授权认证返回类型
	/// </summary>
	public enum ResponseType {
		/// <summary>
		/// Code
		/// </summary>
		Code,

		/// <summary>
		/// Access Token
		/// </summary>
		Token
	}

	/// <summary>
	/// 回调返回类型
	/// </summary>
	public enum DisplayType {
		/// <summary>
		/// 默认
		/// </summary>
		Default,

		/// <summary>
		/// 移动界面
		/// </summary>
		Mobile,

		/// <summary>
		/// 弹出窗
		/// </summary>
		Popup,

		/// <summary>
		/// Wap12
		/// </summary>
		Wap12,

		/// <summary>
		/// Wap20
		/// </summary>
		Wap20,

		/// <summary>
		/// Javascript
		/// </summary>
		JS,

		/// <summary>
		/// 刷新框架
		/// </summary>
		ApponWeibo
	}

	internal enum GrantType {
		AuthorizationCode,
		Password,
		RefreshToken
	}

	internal enum RequestMethod {
		Get,
		Post
	}

	/// <summary>
	/// 重置微博技术类型
	/// </summary>
	public enum ResetCountType {
		/// <summary>
		/// 新微博数
		/// </summary>
		status,

		/// <summary>
		/// 新粉丝数
		/// </summary>
		follower,

		/// <summary>
		/// 新评论数
		/// </summary>
		cmt,

		/// <summary>
		/// 新私信数
		/// </summary>
		dm,

		/// <summary>
		/// 新提及我的微博数
		/// </summary>
		mention_status,

		/// <summary>
		/// 新提及我的评论数
		/// </summary>
		mention_cmt
	}

	/// <summary>
	/// 转发评论类型
	/// </summary>
	public enum RepostCommentType {
		/// <summary>
		/// 无评论
		/// </summary>
		NoComment,

		/// <summary>
		/// 当前
		/// </summary>
		Current,

		/// <summary>
		/// 原文转发
		/// </summary>
		Orign,

		/// <summary>
		/// 都有
		/// </summary>
		Both
	}

	/// <summary>
	/// 性别类型
	/// </summary>
	public enum GenderType {
		/// <summary>
		/// 男
		/// </summary>
		Male,

		/// <summary>
		/// 女
		/// </summary>
		Female,

		/// <summary>
		/// 不男不女
		/// </summary>
		Unknown
	}

	/// <summary>
	/// 热门微博类型
	/// </summary>
	public enum HotUserCatagory {
		/// <summary>
		/// 人气关注
		/// </summary>
		@default,

		/// <summary>
		/// 影视明星
		/// </summary>
		ent,

		/// <summary>
		/// 港台名人
		/// </summary>
		hk_famous,

		/// <summary>
		/// 模特
		/// </summary>
		model,

		/// <summary>
		/// 美食与健康
		/// </summary>
		cooking,

		/// <summary>
		/// 体育名人
		/// </summary>
		sport,

		/// <summary>
		/// 商界名人
		/// </summary>
		finance,

		/// <summary>
		/// IT互联网
		/// </summary>
		tech,

		/// <summary>
		/// 歌手
		/// </summary>
		singer,

		/// <summary>
		/// 作家
		/// </summary>
		writer,

		/// <summary>
		/// 主持人
		/// </summary>
		moderator,

		/// <summary>
		/// 媒体总编
		/// </summary>
		medium,

		/// <summary>
		/// 炒股高手
		/// </summary>
		stockplayer
	}

	/// <summary>
	/// 表情类型
	/// </summary>
	public enum EmotionType {
		/// <summary>
		/// 普通表情
		/// </summary>
		face,

		/// <summary>
		/// 魔法表情
		/// </summary>
		ani,

		/// <summary>
		/// 动漫表情
		/// </summary>
		cartoon
	}

	/// <summary>
	/// 语言类型
	/// </summary>
	public enum LanguageType {
		/// <summary>
		/// 简体
		/// </summary>
		cnname,

		/// <summary>
		/// 繁体
		/// </summary>
		twname
	}

	/// <summary>
	/// Token验证返回值
	/// </summary>
	public enum TokenResult {
		/// <summary>
		/// 正常
		/// </summary>
		Success,

		/// <summary>
		/// Token已过期
		/// </summary>
		TokenExpired,

		/// <summary>
		/// Token已被占用
		/// </summary>
		TokenUsed,

		/// <summary>
		/// Token已被回收
		/// </summary>
		TokenRevoked,

		/// <summary>
		/// Token被拒绝
		/// </summary>
		TokenRejected,

		/// <summary>
		/// 其他问题
		/// </summary>
		Other
	}

	/// <summary>
	/// 坐标
	/// </summary>
	public class Coordinate {
		public Coordinate(float lat, float log) {
			this.Latitude = lat;
			this.Longtitude = log;
		}

		/// <summary>
		/// 维度
		/// </summary>
		public float Latitude { get; set; }

		/// <summary>
		/// 经度
		/// </summary>
		public float Longtitude { get; set; }

		public override string ToString() {
			return string.Format("{0:#.####},{1:#.####}", this.Latitude, this.Longtitude);
		}
	}

	/// <summary>
	/// WeiboParameter实现的IComparer接口
	/// </summary>
	internal class WeiboParameterComparer : IComparer<WeiboParameter> {
		#region IComparer<WeiboParameter> Members
		public int Compare(WeiboParameter x, WeiboParameter y) {
			return StringComparer.CurrentCulture.Compare(x.Name, y.Name);
		}
		#endregion
	}

	/// <summary>
	/// 微博工具类
	/// </summary>
	public static class Utility {
		/// <summary>
		/// 将微博时间转换为DateTime
		/// </summary>
		/// <param name="dateString">微博时间字符串</param>
		/// <returns>DateTime</returns>
		public static DateTime ParseUTCDate(string dateString) {
			CultureInfo provider = CultureInfo.InvariantCulture;

			DateTime dt = DateTime.ParseExact(dateString, "ddd MMM dd HH:mm:ss zzz yyyy", provider);

			return dt;
		}

		internal static Dictionary<string, string> GetDictionaryFromJSON(string json) {
			var result = JsonConvert.DeserializeObject<IEnumerable<JObject>>(json);

			var dict = new Dictionary<string, string>();
			foreach (JObject loc in result) {
				foreach (JProperty x in loc.Properties()) {
					dict.Add(x.Name, x.Value.ToString());
				}
			}
			return dict;
		}

		internal static IEnumerable<string> GetStringListFromJSON(string json) {
			var result = JsonConvert.DeserializeObject<IEnumerable<JObject>>(json);
			var list = new List<string>();
			foreach (JObject loc in result) {
				foreach (JProperty x in loc.Properties()) {
					list.Add(x.Value.ToString());
				}
			}
			return list;
		}

		internal static string BuildQueryString(Dictionary<string, string> parameters) {
			var pairs = new List<string>();
			foreach (var item in parameters) {
				if (string.IsNullOrEmpty(item.Value)) {
					continue;
				}

				pairs.Add(string.Format("{0}={1}", Uri.EscapeDataString(item.Key), Uri.EscapeDataString(item.Value)));
			}

			return string.Join("&", pairs.ToArray());
		}

		internal static string BuildQueryString(params WeiboParameter[] parameters) {
			var pairs = new List<string>();
			foreach (WeiboParameter item in parameters) {
				if (item.IsBinaryData) {
					continue;
				}

				string value = string.Format("{0}", item.Value);
				if (!string.IsNullOrEmpty(value)) {
					pairs.Add(string.Format("{0}={1}", Uri.EscapeDataString(item.Name), Uri.EscapeDataString(value)));
				}
			}

			return string.Join("&", pairs.ToArray());
		}

		internal static string GetBoundary() {
			string pattern = "abcdefghijklmnopqrstuvwxyz0123456789";
			var boundaryBuilder = new StringBuilder();
			var rnd = new Random();
			for (int i = 0; i < 10; i++) {
				int index = rnd.Next(pattern.Length);
				boundaryBuilder.Append(pattern[index]);
			}
			return boundaryBuilder.ToString();
		}

		/// <summary>
		/// 创建Post Body
		/// </summary>
		/// <param name="boundary"></param>
		/// <param name="parameters">参数</param>
		/// <returns></returns>
		internal static byte[] BuildPostData(string boundary, params WeiboParameter[] parameters) {
			var pairs = new List<WeiboParameter>(parameters);
			pairs.Sort(new WeiboParameterComparer());
			var buff = new MemoryStream();

			byte[] headerBuff = Encoding.ASCII.GetBytes(string.Format("\r\n--{0}\r\n", boundary));
			byte[] footerBuff = Encoding.ASCII.GetBytes(string.Format("\r\n--{0}--", boundary));

			var contentBuilder = new StringBuilder();

			foreach (WeiboParameter p in pairs) {
				if (!p.IsBinaryData) {
					string value = string.Format("{0}", p.Value);
					if (string.IsNullOrEmpty(value)) {
						continue;
					}

					buff.Write(headerBuff, 0, headerBuff.Length);
					byte[] dispositonBuff = Encoding.UTF8.GetBytes(string.Format("content-disposition: form-data; name=\"{0}\"\r\n\r\n{1}", p.Name, p.Value));
					buff.Write(dispositonBuff, 0, dispositonBuff.Length);
				}
				else {
					buff.Write(headerBuff, 0, headerBuff.Length);
					string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: \"image/unknow\"\r\nContent-Transfer-Encoding: binary\r\n\r\n";
					byte[] fileBuff = Encoding.UTF8.GetBytes(string.Format(headerTemplate, p.Name, string.Format("upload{0}", BitConverter.ToInt64(Guid.NewGuid().ToByteArray(), 0))));
					buff.Write(fileBuff, 0, fileBuff.Length);
					var file = (byte[])p.Value;
					buff.Write(file, 0, file.Length);
				}
			}

			buff.Write(footerBuff, 0, footerBuff.Length);
			buff.Position = 0;

			var contentBuff = new byte[buff.Length];
			buff.Read(contentBuff, 0, contentBuff.Length);
			buff.Close();
			buff.Dispose();
			return contentBuff;
		}
	}
}
