using System.Net;

namespace Amazon.RuntimeDependencies
{
	public class SecurityTokenServiceClientContext
	{
		public enum ActionContext
		{
			AssumeRoleAWSCredentials = 0,
			AssumeRoleWithWebIdentityCredentials = 1,
			FederatedAWSCredentials = 2
		}

		public ActionContext Action { get; set; }

		public RegionEndpoint Region { get; set; }

		public IWebProxy ProxySettings { get; set; }
	}
}
