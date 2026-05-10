using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32.SafeHandles;
using Mono.Security.Interface;

namespace Mono.Btls
{
	internal class X509PalImplBtls : X509PalImpl
	{
		private MonoBtlsProvider Provider { get; }

		public X509PalImplBtls(MonoTlsProvider provider)
		{
		}

		public override X509CertificateImpl Import(byte[] data)
		{
			return null;
		}

		public override X509Certificate2Impl Import(byte[] data, SafePasswordHandle password, X509KeyStorageFlags keyStorageFlags)
		{
			return null;
		}

		public override X509Certificate2Impl Import(X509Certificate cert)
		{
			return null;
		}
	}
}
