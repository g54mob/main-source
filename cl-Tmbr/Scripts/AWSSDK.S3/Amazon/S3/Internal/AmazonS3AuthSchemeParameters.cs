using Amazon.Runtime.Internal.Auth;

namespace Amazon.S3.Internal
{
	public class AmazonS3AuthSchemeParameters : IAuthSchemeParameters
	{
		public string Operation { get; set; }

		public string Region { get; set; }
	}
}
