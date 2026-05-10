using System;
using System.Runtime.CompilerServices;

namespace Mono.Security.Interface
{
	public class MonoTlsConnectionInfo
	{
		[CompilerGenerated]
		private string _003CPeerDomainName_003Ek__BackingField;

		[CLSCompliant(false)]
		public CipherSuiteCode CipherSuiteCode { get; set; }

		public TlsProtocols ProtocolVersion { get; set; }

		public string PeerDomainName
		{
			[CompilerGenerated]
			set
			{
				_003CPeerDomainName_003Ek__BackingField = value;
			}
		}

		public override string ToString()
		{
			return null;
		}
	}
}
