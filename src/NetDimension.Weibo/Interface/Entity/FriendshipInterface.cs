using System.Collections.Generic;
using NetDimension.Weibo.Entities.friendship;
using NetDimension.Weibo.Entities.user;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetDimension.Weibo.Interface.Entity {
	/// <summary>
	/// Friendship接口
	/// </summary>
	public class FriendshipInterface : WeiboInterface {
		private readonly FriendshipAPI api;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="client">操作类</param>
		public FriendshipInterface(Client client)
			: base(client) {
			this.api = new FriendshipAPI(client);
		}

		/// <summary>
		/// 获取用户的关注列表 
		/// </summary>
		/// <param name="uid">需要查询的用户UID。 </param>
		/// <param name="screenName">需要查询的用户昵称。 </param>
		/// <param name="count">单页返回的记录条数，默认为50，最大不超过200。</param>
		/// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
		/// /// <param name="trimStatus">返回值中user字段中的status字段开关，0：返回完整status字段、1：status字段仅返回status_id，默认为1。 </param>
		/// <returns></returns>
		public Collection Friends(string uid = "", string screenName = "", int count = 50, int cursor = 0, bool trimStatus = true) {
			return JsonConvert.DeserializeObject<Collection>(this.api.Friends(uid, screenName, count, cursor, trimStatus));
		}

		/// <summary>
		/// 获取用户关注的用户UID列表
		/// </summary>
		/// <param name="uid">需要查询的用户UID。 </param>
		/// <param name="screenName">需要查询的用户昵称。 </param>
		/// <param name="count">单页返回的记录条数，默认为500，最大不超过5000。 </param>
		/// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
		/// <returns></returns>
		public IDCollection FriendIDs(string uid = "", string screenName = "", int count = 50, int cursor = 0) {
			return JsonConvert.DeserializeObject<IDCollection>(this.api.FriendIDs(uid, screenName, count, cursor));
		}

		/// <summary>
		/// 获取两个用户之间的共同关注人列表 
		/// </summary>
		/// <param name="uid">需要获取共同关注关系的用户UID。</param>
		/// <param name="suid">需要获取共同关注关系的用户UID，默认为当前登录用户。</param>
		/// <param name="count">单页返回的记录条数，默认为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <returns></returns>
		public IEnumerable<Entities.user.Entity> FriendsInCommon(string uid = "", string suid = "", int count = 50, int page = 1) {
			return JsonConvert.DeserializeObject<IEnumerable<Entities.user.Entity>>(JObject.Parse(this.api.FriendsInCommon(uid, suid, count, page))["users"].ToString());
		}

		/// <summary>
		/// 获取用户的双向关注列表，即互粉列表 
		/// </summary>
		/// <param name="uid">需要获取双向关注列表的用户UID。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="sort">排序类型，0：按关注时间最近排序，默认为0。</param>
		/// <returns></returns>
		public IEnumerable<Entities.user.Entity> FriendsOnBilateral(string uid, int count = 50, int page = 1, bool sort = false) {
			return JsonConvert.DeserializeObject<IEnumerable<Entities.user.Entity>>(JObject.Parse(this.api.FriendsOnBilateral(uid, count, page, sort))["users"].ToString());
		}

		/// <summary>
		/// 获取用户双向关注的用户ID列表，即互粉UID列表 
		/// </summary>
		/// <param name="uid">需要获取双向关注列表的用户UID。</param>
		/// <param name="count">单页返回的记录条数，默认为50，最大不超过2000。 </param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <param name="sort">排序类型，0：按关注时间最近排序，默认为0。 </param>
		/// <returns></returns>
		public IDCollection FriendsOnBilateralIDs(string uid, int count = 50, int page = 1, bool sort = false) {
			//return JsonConvert.DeserializeObject<NetDimension.Weibo.Entities.user.IDCollection>(JObject.Parse(api.FriendsOnBilateralIDs(uid, count, page, sort))["ids"].ToString());
			return JsonConvert.DeserializeObject<IDCollection>(this.api.FriendsOnBilateralIDs(uid, count, page, sort));
		}

		/// <summary>
		/// 获取用户的粉丝列表 
		/// </summary>
		/// <param name="uid">需要查询的用户UID。 </param>
		/// <param name="screenName">需要查询的用户昵称。 </param>
		/// <param name="count">单页返回的记录条数，默认为50，最大不超过200。</param>
		/// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
		/// <param name="trimStatus">返回值中user字段中的status字段开关，0：返回完整status字段、1：status字段仅返回status_id，默认为1。 </param>
		/// <returns></returns>
		public Collection Followers(string uid = "", string screenName = "", int count = 50, int cursor = 0, bool trimStatus = true) {
			return JsonConvert.DeserializeObject<Collection>(this.api.Followers(uid, screenName, count, cursor, trimStatus));
		}

		/// <summary>
		/// 获取用户粉丝的用户UID列表 
		/// </summary>
		/// <param name="uid">需要查询的用户UID。</param>
		/// <param name="screenName">需要查询的用户昵称。 </param>
		/// <param name="count">单页返回的记录条数，默认为500，最大不超过5000。</param>
		/// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。 </param>
		/// <returns></returns>
		public IDCollection FollowerIDs(string uid = "", string screenName = "", int count = 50, int cursor = 0) {
			return JsonConvert.DeserializeObject<IDCollection>(this.api.FollowerIDs(uid, screenName, count, cursor));
		}

		/// <summary>
		/// 获取用户的活跃粉丝列表
		/// </summary>
		/// <param name="uid">需要查询的用户UID。 </param>
		/// <param name="count">返回的记录条数，默认为20，最大不超过200。 </param>
		/// <returns></returns>
		public IEnumerable<Entities.user.Entity> FollowersInActive(string uid, int count = 20) {
			return JsonConvert.DeserializeObject<IEnumerable<Entities.user.Entity>>(JObject.Parse(this.api.FollowersInActive(uid, count))["users"].ToString());
		}

		/// <summary>
		/// 获取当前登录用户的关注人中又关注了指定用户的用户列表
		/// </summary>
		/// <param name="uid">指定的关注目标用户UID。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <returns></returns>
		public Collection FriendsChain(string uid, int count = 50, int page = 1) {
			return JsonConvert.DeserializeObject<Collection>(this.api.FriendsChain(uid, count, page));
		}

		/// <summary>
		/// 获取两个用户之间的详细关注关系情况
		/// </summary>
		/// <param name="sourceID">源用户的UID。</param>
		/// <param name="sourceScreenName">源用户的微博昵称。 </param>
		/// <param name="targetID">目标用户的UID。 </param>
		/// <param name="targetScreenName">目标用户的微博昵称。 </param>
		/// <returns></returns>
		public Result Show(string sourceID = "", string sourceScreenName = "", string targetID = "", string targetScreenName = "") {
			return JsonConvert.DeserializeObject<Result>(this.api.Show(sourceID, sourceScreenName, targetID, targetScreenName));
		}

		/// <summary>
		/// 关注一个用户 
		/// </summary>
		/// <param name="uid">需要关注的用户ID。</param>
		/// <param name="screenName">需要关注的用户昵称。 </param>
		/// <returns></returns>
		public Entities.user.Entity Create(string uid = "", string screenName = "") {
			return JsonConvert.DeserializeObject<Entities.user.Entity>(this.api.Create(uid, screenName));
		}

		/// <summary>
		/// 取消关注一个用户 
		/// </summary>
		/// <param name="uid">需要取消关注的用户ID。</param>
		/// <param name="screenName">需要取消关注的用户昵称。 </param>
		/// <returns></returns>
		public Entities.user.Entity Destroy(string uid = "", string screenName = "") {
			return JsonConvert.DeserializeObject<Entities.user.Entity>(this.api.Destroy(uid, screenName));
		}

		/// <summary>
		/// 更新当前登录用户所关注的某个好友的备注信息 
		/// </summary>
		/// <param name="uid">需要修改备注信息的用户UID。 </param>
		/// <param name="remark">备注信息</param>
		/// <returns></returns>
		public Entities.user.Entity UpdateRemark(string uid, string remark) {
			return JsonConvert.DeserializeObject<Entities.user.Entity>(this.api.UpdateRemark(uid, remark));
		}
	}
}
