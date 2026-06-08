namespace Amazon.Runtime.Internal.Endpoints.StandardLibrary
{
	public class PartitionAttributesShape
	{
		public string name { get; set; }

		public string dnsSuffix { get; set; }

		public string dualStackDnsSuffix { get; set; }

		public bool supportsFIPS { get; set; }

		public bool supportsDualStack { get; set; }

		public string implicitGlobalRegion { get; set; }
	}
}
