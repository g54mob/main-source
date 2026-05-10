using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace Mono.Net.Security
{
	internal sealed class MonoSslClientAuthenticationOptions : MonoSslAuthenticationOptions
	{
		public SslClientAuthenticationOptions Options { get; }

		public override bool ServerMode => false;

		public override bool AllowRenegotiation => false;

		public override X509RevocationMode CertificateRevocationCheckMode
		{
			set
			{
			}
		}

		public override EncryptionPolicy EncryptionPolicy
		{
			set
			{
			}
		}

		public override SslProtocols EnabledSslProtocols
		{
			get
			{
				return default(SslProtocols);
			}
			set
			{
			}
		}

		public override string TargetHost
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override bool ClientCertificateRequired => false;

		public override X509CertificateCollection ClientCertificates
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override X509Certificate ServerCertificate => null;
	}
}
