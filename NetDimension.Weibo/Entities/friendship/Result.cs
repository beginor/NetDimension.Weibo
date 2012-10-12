using Newtonsoft.Json;

namespace NetDimension.Weibo.Entities.friendship {
	public class Result : EntityBase {
		[JsonProperty("target")]
		public Entity Target { get; internal set; }

		[JsonProperty("source")]
		public Entity Source { get; internal set; }
	}
}
