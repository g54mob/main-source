using System.Collections.Generic;

namespace Amazon.Runtime.Internal.Endpoints.StandardLibrary
{
	public class PartitionFunctionShape
	{
		public string version { get; set; }

		public List<PartitionShape> partitions { get; set; }
	}
}
