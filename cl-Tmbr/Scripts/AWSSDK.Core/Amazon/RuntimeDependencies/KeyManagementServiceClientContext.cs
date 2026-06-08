using Amazon.Runtime;

namespace Amazon.RuntimeDependencies
{
	public class KeyManagementServiceClientContext
	{
		public AmazonServiceClient ParentServiceClient { get; set; }
	}
}
