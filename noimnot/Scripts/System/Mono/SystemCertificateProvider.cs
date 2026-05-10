using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32.SafeHandles;
using Mono.Security.Interface;

namespace Mono
{
	internal class SystemCertificateProvider : ISystemCertificateProvider
	{
		private static MonoTlsProvider provider;

		private static int initialized;

		private static X509PalImpl x509pal;

		private static object syncRoot;

		public X509PalImpl X509Pal => null;

		private static X509PalImpl GetX509Pal()
		{
			return null;
		}

		private static void EnsureInitialized()
		{
		}

		public X509CertificateImpl Import(byte[] data, CertificateImportFlags importFlags = CertificateImportFlags.None)
		{
			return null;
		}

		X509CertificateImpl ISystemCertificateProvider.Import(byte[] data, SafePasswordHandle password, X509KeyStorageFlags keyStorageFlags, CertificateImportFlags importFlags)
		{
			return null;
		}

		public X509Certificate2Impl Import(byte[] data, SafePasswordHandle password, X509KeyStorageFlags keyStorageFlags, CertificateImportFlags importFlags = CertificateImportFlags.None)
		{
			return null;
		}

		X509CertificateImpl ISystemCertificateProvider.Import(X509Certificate cert, CertificateImportFlags importFlags)
		{
			return null;
		}

		public X509Certificate2Impl Import(X509Certificate cert, CertificateImportFlags importFlags = CertificateImportFlags.None)
		{
			return null;
		}
	}
}
