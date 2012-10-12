using System.Collections.Generic;
using Newtonsoft.Json;

namespace NetDimension.Weibo.Entities.favorite {
	public class Collection : EntityBase {
		[JsonProperty("favorites")]
		public IEnumerable<Entity> Favorites { get; internal set; }

		[JsonProperty("total_number")]
		public int TotalNumber { get; internal set; }
	}
}
