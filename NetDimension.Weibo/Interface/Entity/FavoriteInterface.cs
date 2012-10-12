using System;
using System.Collections.Generic;
using NetDimension.Weibo.Entities.favorite;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetDimension.Weibo.Interface.Entity {
	/// <summary>
	/// Favorite接口
	/// </summary>
	public class FavoriteInterface : WeiboInterface {
		private readonly FavoriteAPI api;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="client">操作类</param>
		public FavoriteInterface(Client client)
			: base(client) {
			this.api = new FavoriteAPI(client);
		}

		/// <summary>
		/// 获取当前登录用户的收藏列表
		/// </summary>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <returns></returns>
		public Collection Favorites(int count = 50, int page = 1) {
			return JsonConvert.DeserializeObject<Collection>(this.api.Favorites(count, page));
		}

		/// <summary>
		/// 获取当前用户的收藏列表的ID
		/// </summary>
		/// <param name="count">单页返回的记录条数，默认为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <returns></returns>
		public IDCollection FavoriteIDs(int count = 50, int page = 1) {
			return JsonConvert.DeserializeObject<IDCollection>(this.api.FavoriteIDs(count, page));
		}

		/// <summary>
		/// 根据收藏ID获取指定的收藏信息 
		/// </summary>
		/// <param name="id">需要查询的收藏ID。 </param>
		/// <returns></returns>
		public Entities.favorite.Entity Show(string id) {
			return JsonConvert.DeserializeObject<Entities.favorite.Entity>(this.api.Show(id));
		}

		/// <summary>
		/// 根据标签获取当前登录用户该标签下的收藏列表  
		/// </summary>
		/// <param name="tid">需要查询的标签ID。</param>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <returns></returns>
		public Collection ByTags(string tid, int count = 50, int page = 1) {
			return JsonConvert.DeserializeObject<Collection>(this.api.ByTags(tid, count, page));
		}

		/// <summary>
		/// 获取当前登录用户的收藏标签列表 
		/// </summary>
		/// <param name="count">单页返回的记录条数，默认为10。</param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <returns></returns>
		public IEnumerable<TagEntity> Tags(int count = 10, int page = 1) {
			JObject result = JObject.Parse(this.api.Tags(count, page));

			return JsonConvert.DeserializeObject<IEnumerable<TagEntity>>(result["tags"].ToString());
		}

		/// <summary>
		/// 获取当前用户某个标签下的收藏列表的ID 
		/// </summary>
		/// <param name="tid">需要查询的标签ID。</param>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <returns></returns>
		public IEnumerable<IDEntity> ByTagIDs(string tid, int count = 50, int page = 1) {
			JObject result = JObject.Parse(this.api.ByTagIDs(tid, count, page));
			return JsonConvert.DeserializeObject<IEnumerable<IDEntity>>(result["favorites"].ToString());
		}

		/// <summary>
		/// 添加一条微博到收藏里 
		/// </summary>
		/// <param name="id">要收藏的微博ID。</param>
		/// <returns></returns>
		public Entities.favorite.Entity Create(string id) {
			return JsonConvert.DeserializeObject<Entities.favorite.Entity>(this.api.Create(id));
		}

		/// <summary>
		/// 取消收藏一条微博
		/// </summary>
		/// <param name="id">要取消收藏的微博ID。</param>
		/// <returns></returns>
		public Entities.favorite.Entity Destroy(string id) {
			return JsonConvert.DeserializeObject<Entities.favorite.Entity>(this.api.Destroy(id));
		}

		/// <summary>
		/// 根据收藏ID批量取消收藏 
		/// </summary>
		/// <param name="ids">要取消收藏的收藏ID最多不超过10个。 </param>
		/// <returns></returns>
		public bool DestroyBatch(params string[] ids) {
			return Convert.ToBoolean(JObject.Parse(this.api.DestroyBatch(ids))["result"]);
		}

		/// <summary>
		/// 更新一条收藏的收藏标签
		/// </summary>
		/// <param name="id">需要更新的收藏ID。</param>
		/// <param name="tags">需要更新的标签内容，最多不超过2条。</param>
		/// <returns></returns>
		public Entities.favorite.Entity UpdateTags(string id, params string[] tags) {
			return JsonConvert.DeserializeObject<Entities.favorite.Entity>(this.api.UpdateTags(id, tags));
		}

		/// <summary>
		/// 更新当前登录用户所有收藏下的指定标签 
		/// </summary>
		/// <param name="tid">需要更新的标签ID</param>
		/// <param name="tag">需要更新的标签内容</param>
		/// <returns></returns>
		public TagEntity UpdateTagsBatch(string tid, string tag) {
			return JsonConvert.DeserializeObject<TagEntity>(this.api.UpdateTagsBatch(tid, tag));
		}

		/// <summary>
		/// 删除当前登录用户所有收藏下的指定标签 
		/// </summary>
		/// <param name="tid">需要删除的标签ID</param>
		/// <returns></returns>
		public bool DestroyTags(string[] tid) {
			return Convert.ToBoolean(JObject.Parse(this.api.DestroyTags(tid)));
		}
	}
}
