using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32.SafeHandles;

namespace Mono.Btls
{
	internal class X509CertificateImplBtls : X509Certificate2ImplUnix
	{
		private MonoBtlsX509 x509;

		private MonoBtlsKey nativePrivateKey;

		private X509CertificateImplCollection intermediateCerts;

		public override bool IsValid => false;

		internal MonoBtlsX509 X509 => null;

		internal MonoBtlsKey NativePrivateKey => null;

		internal override X509CertificateImplCollection IntermediateCertificates => null;

		public override bool HasPrivateKey => false;

		public override AsymmetricAlgorithm PrivateKey
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal X509CertificateImplBtls(MonoBtlsX509 x509)
		{
		}

		private X509CertificateImplBtls(X509CertificateImplBtls other)
		{
		}

		internal X509CertificateImplBtls(byte[] data, MonoBtlsX509Format format)
		{
		}

		internal X509CertificateImplBtls(byte[] data, SafePasswordHandle password, X509KeyStorageFlags keyStorageFlags)
		{
		}

		public override X509CertificateImpl Clone()
		{
			return null;
		}

		protected override byte[] GetRawCertData()
		{
			return null;
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override RSA GetRSAPrivateKey()
		{
			return null;
		}

		public override DSA GetDSAPrivateKey()
		{
			return null;
		}

		private void Import(byte[] data)
		{
		}

		private void ImportPkcs12(byte[] data, SafePasswordHandle password)
		{
		}

		private void ImportAuthenticode(byte[] data)
		{
		}

		public override bool Verify(X509Certificate2 thisCertificate)
		{
			return false;
		}
	}
}
