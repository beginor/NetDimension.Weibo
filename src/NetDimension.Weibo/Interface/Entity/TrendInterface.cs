using System;
using System.Collections.Generic;
using NetDimension.Weibo.Entities.trend;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetDimension.Weibo.Interface.Entity {
	/// <summary>
	/// Trend接口
	/// </summary>
	public class TrendInterface : WeiboInterface {
		private readonly TrendAPI api;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="client">操作类</param>
		public TrendInterface(Client client)
			: base(client) {
			this.api = new TrendAPI(client);
		}

		/// <summary>
		/// 获取某人话题 
		/// </summary>
		/// <param name="uid"></param>
		/// <param name="count"></param>
		/// <param name="page"></param>
		/// <returns></returns>
		public IEnumerable<Trend> Trends(string uid, int count = 10, int page = 1) {
			return JsonConvert.DeserializeObject<IEnumerable<Trend>>(this.api.Trends(uid, count, page));
		}

		/// <summary>
		/// 是否关注某话题 
		/// </summary>
		/// <param name="trendName"></param>
		/// <returns></returns>
		public IsFollow IsFollow(string trendName) {
			return JsonConvert.DeserializeObject<IsFollow>(this.api.IsFollow(trendName));
		}

		/// <summary>
		/// 返回最近一小时内的热门话题。 
		/// </summary>
		/// <param name="baseApp">是否基于当前应用来获取数据。true表示基于当前应用来获取数据。 </param>
		/// <returns></returns>
		public HotTrends Hourly(bool baseApp = false) {
			JObject json = JObject.Parse(this.api.Hourly(baseApp));

			var result = new HotTrends();

			result.AsOf = json["as_of"].ToString();
			result.Trends = new Dictionary<string, List<Keyword>>();
			foreach (JProperty x in json["trends"]) {
				string name = x.Name;
				List<Keyword> list = null;
				if (result.Trends.ContainsKey(name)) {
					list = result.Trends[name];
				}
				else {
					list = result.Trends[name] = new List<Keyword>();
				}

				foreach (JObject item in x.Value) {
					list.Add(new Keyword {Name = string.Format("{0}", item["name"]), Query = string.Format("{0}", item["query"]), Amount = string.Format("{0}", item["amount"]), Delta = string.Format("{0}", item["delta"])});
				}
			}

			return result;
		}

		/// <summary>
		/// 返回最近一天内的热门话题。 
		/// </summary>
		/// <param name="baseApp">是否基于当前应用来获取数据。true表示基于当前应用来获取数据。 </param>
		/// <returns></returns>
		public HotTrends Daily(bool baseApp = false) {
			JObject json = JObject.Parse(this.api.Daily(baseApp));

			var result = new HotTrends();

			result.AsOf = json["as_of"].ToString();
			result.Trends = new Dictionary<string, List<Keyword>>();
			foreach (JProperty x in json["trends"]) {
				string name = x.Name;
				List<Keyword> list = null;
				if (result.Trends.ContainsKey(name)) {
					list = result.Trends[name];
				}
				else {
					list = result.Trends[name] = new List<Keyword>();
				}

				foreach (JObject item in x.Value) {
					list.Add(new Keyword {Name = string.Format("{0}", item["name"]), Query = string.Format("{0}", item["query"]), Amount = string.Format("{0}", item["amount"]), Delta = string.Format("{0}", item["delta"])});
				}
			}

			return result;
		}

		/// <summary>
		/// 返回最近一周内的热门话题。 
		/// </summary>
		/// <param name="baseApp">是否基于当前应用来获取数据。true表示基于当前应用来获取数据。 </param>
		/// <returns></returns>
		public HotTrends Weekly(bool baseApp = false) {
			JObject json = JObject.Parse(this.api.Weekly(baseApp));

			var result = new HotTrends();

			result.AsOf = json["as_of"].ToString();
			result.Trends = new Dictionary<string, List<Keyword>>();
			foreach (JProperty x in json["trends"]) {
				string name = x.Name;
				List<Keyword> list = null;
				if (result.Trends.ContainsKey(name)) {
					list = result.Trends[name];
				}
				else {
					list = result.Trends[name] = new List<Keyword>();
				}

				foreach (JObject item in x.Value) {
					list.Add(new Keyword {Name = string.Format("{0}", item["name"]), Query = string.Format("{0}", item["query"]), Amount = string.Format("{0}", item["amount"]), Delta = string.Format("{0}", item["delta"])});
				}
			}

			return result;
		}

		/// <summary>
		/// 关注某话题 
		/// </summary>
		/// <param name="trendName"></param>
		/// <returns></returns>
		public string Follow(string trendName) {
			return JObject.Parse(this.api.Follow(trendName))["topicid"].ToString();
		}

		/// <summary>
		/// 取消关注的某一个话题 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool Destroy(string id) {
			return Convert.ToBoolean(JObject.Parse(this.api.Destroy(id))["result"].ToString());
		}
	}
}
