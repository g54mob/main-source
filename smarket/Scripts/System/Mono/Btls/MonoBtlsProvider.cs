using System;
using System.IO;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32.SafeHandles;
using Mono.Net.Security;
using Mono.Security.Interface;

namespace Mono.Btls
{
	internal class MonoBtlsProvider : MobileTlsProvider
	{
		public override Guid ID => default(Guid);

		public override string Name => null;

		public override bool SupportsSslStream => false;

		public override bool SupportsMonoExtensions => false;

		public override bool SupportsConnectionInfo => false;

		internal override bool SupportsCleanShutdown => false;

		public override SslProtocols SupportedProtocols => default(SslProtocols);

		internal MonoBtlsProvider()
		{
		}

		internal override MobileAuthenticatedStream CreateSslStream(SslStream sslStream, Stream innerStream, bool leaveInnerStreamOpen, MonoTlsSettings settings)
		{
			return null;
		}

		internal X509Certificate2Impl GetNativeCertificate(byte[] data, string password, X509KeyStorageFlags flags)
		{
			return null;
		}

		internal X509Certificate2Impl GetNativeCertificate(X509Certificate certificate)
		{
			return null;
		}

		internal X509Certificate2Impl GetNativeCertificate(byte[] data, SafePasswordHandle password, X509KeyStorageFlags flags)
		{
			return null;
		}

		internal static MonoBtlsX509VerifyParam GetVerifyParam(MonoTlsSettings settings, string targetHost, bool serverMode)
		{
			return null;
		}

		internal override bool ValidateCertificate(ChainValidationHelper validator, string targetHost, bool serverMode, X509CertificateCollection certificates, bool wantsChain, ref X509Chain chain, ref SslPolicyErrors errors, ref int status11)
		{
			return false;
		}

		internal static bool ValidateCertificate(MonoBtlsX509Chain chain, MonoBtlsX509VerifyParam param)
		{
			return false;
		}

		private void CheckValidationResult(ChainValidationHelper validator, string targetHost, bool serverMode, X509CertificateCollection certificates, bool wantsChain, X509Chain chain, MonoBtlsX509StoreCtx storeCtx, bool success, ref SslPolicyErrors errors, ref int status11)
		{
		}

		internal static X509ChainStatusFlags MapVerifyErrorToChainStatus(MonoBtlsX509Error code)
		{
			return default(X509ChainStatusFlags);
		}

		internal static void SetupCertificateStore(MonoBtlsX509Store store, MonoTlsSettings settings, bool server)
		{
		}

		private static void SetupDefaultCertificateStore(MonoBtlsX509Store store)
		{
		}

		private static void AddUserStore(MonoBtlsX509Store store)
		{
		}

		private static void AddMachineStore(MonoBtlsX509Store store)
		{
		}

		private static void AddTrustedRoots(MonoBtlsX509Store store, MonoTlsSettings settings, bool server)
		{
		}

		public static X509Certificate2 CreateCertificate(MonoBtlsX509 x509)
		{
			return null;
		}

		public static X509Chain GetManagedChain(MonoBtlsX509Chain chain)
		{
			return null;
		}

		public static MonoBtlsX509 GetBtlsCertificate(X509Certificate certificate)
		{
			return null;
		}

		public static MonoBtlsX509Chain GetNativeChain(X509CertificateCollection certificates)
		{
			return null;
		}
	}
}
