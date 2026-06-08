using System;
using System.Net;

namespace Amazon.Runtime.Internal
{
	public class AmazonSecurityProtocolManager : IAmazonSecurityProtocolManager
	{
		private const SecurityProtocolType Tls11 = SecurityProtocolType.Tls11;

		private const SecurityProtocolType Tls12 = SecurityProtocolType.Tls12;

		private const SecurityProtocolType SupportedTls = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

		private const SecurityProtocolType SystemDefault = SecurityProtocolType.SystemDefault;

		public bool IsSecurityProtocolSystemDefault()
		{
			return ServicePointManager.SecurityProtocol == SecurityProtocolType.SystemDefault;
		}

		public void UpdateProtocolsToSupported()
		{
			SecurityProtocolType securityProtocol = ServicePointManager.SecurityProtocol;
			try
			{
				ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			}
			catch (NotSupportedException innerException)
			{
				ServicePointManager.SecurityProtocol = securityProtocol;
				throw new NotSupportedException("TLS version 1.1 or 1.2 are not supported on this system. Some AWS services will refuse traffic. Please consider updating to a system that supports newer security protocols.", innerException);
			}
		}
	}
}
