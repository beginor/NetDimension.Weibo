using Newtonsoft.Json;

namespace NetDimension.Weibo.Entities.search {
	public class App : EntityBase {
		[JsonProperty("apps_name")]
		public string Name { get; internal set; }

		[JsonProperty("members_count")]
		public int Count { get; internal set; }
	}
}
