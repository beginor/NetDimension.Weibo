using Newtonsoft.Json;

namespace NetDimension.Weibo.Entities.shortUrl {
	public class Location : EntityBase {
		[JsonProperty("clicks")]
		public string Clicks { get; internal set; }

		[JsonProperty("province")]
		public string Province { get; internal set; }

		[JsonProperty("location")]
		public string Name { get; internal set; }
	}
}
