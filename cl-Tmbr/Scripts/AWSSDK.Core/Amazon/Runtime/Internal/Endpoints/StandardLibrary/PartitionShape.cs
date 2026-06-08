using System.Collections.Generic;
using System.Text.Json;

namespace Amazon.Runtime.Internal.Endpoints.StandardLibrary
{
	public class PartitionShape
	{
		public string id { get; set; }

		public string regionRegex { get; set; }

		public Dictionary<string, JsonElement> regions { get; set; }

		public PartitionAttributesShape outputs { get; set; }
	}
}
