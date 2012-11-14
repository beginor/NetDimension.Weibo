using Newtonsoft.Json;

namespace NetDimension.Weibo.Entities.status {
	public class Count : EntityBase {
		[JsonProperty("id")]
		public string ID { get; internal set; }

		[JsonProperty("comments")]
		public string Comments { get; internal set; }

		[JsonProperty("reposts")]
		public string Reposts { get; internal set; }
	}
}
