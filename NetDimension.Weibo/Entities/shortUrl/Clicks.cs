using Newtonsoft.Json;

namespace NetDimension.Weibo.Entities.shortUrl {
	public class Clicks : EntityBase {
		[JsonProperty("url_short")]
		public string ShortUrl { get; internal set; }

		[JsonProperty("url_long")]
		public string LongUrl { get; internal set; }

		[JsonProperty("clicks")]
		public string ClickCounts { get; internal set; }
	}
}
