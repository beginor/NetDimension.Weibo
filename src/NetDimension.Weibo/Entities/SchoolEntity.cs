using Newtonsoft.Json;

namespace NetDimension.Weibo.Entities {
	public class SchoolEntity : EntityBase {
		[JsonProperty("id")]
		public string ID { get; internal set; }

		[JsonProperty("name")]
		public string Name { get; internal set; }
	}
}
