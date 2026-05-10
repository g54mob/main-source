using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32.SafeHandles;

namespace Mono
{
	internal abstract class X509PalImpl
	{
		private static byte[] signedData;

		public bool SupportsLegacyBasicConstraintsExtension => false;

		public abstract X509CertificateImpl Import(byte[] data);

		public abstract X509Certificate2Impl Import(byte[] data, SafePasswordHandle password, X509KeyStorageFlags keyStorageFlags);

		public abstract X509Certificate2Impl Import(X509Certificate cert);

		private static byte[] PEM(string type, byte[] data)
		{
			return null;
		}

		protected static byte[] ConvertData(byte[] data)
		{
			return null;
		}

		internal X509Certificate2Impl ImportFallback(byte[] data)
		{
			return null;
		}

		internal X509Certificate2Impl ImportFallback(byte[] data, SafePasswordHandle password, X509KeyStorageFlags keyStorageFlags)
		{
			return null;
		}

		public X509ContentType GetCertContentType(byte[] rawData)
		{
			return default(X509ContentType);
		}
	}
}
