using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Mono.Security.Interface;

namespace Mono.Net.Security
{
	internal class ChainValidationHelper : ICertificateValidator
	{
		private readonly WeakReference<SslStream> owner;

		private readonly MonoTlsSettings settings;

		private readonly MobileTlsProvider provider;

		private readonly ServerCertValidationCallback certValidationCallback;

		private readonly LocalCertSelectionCallback certSelectionCallback;

		private readonly MonoTlsStream tlsStream;

		private readonly HttpWebRequest request;

		public MonoTlsSettings Settings => null;

		internal static ChainValidationHelper GetInternalValidator(SslStream owner, MobileTlsProvider provider, MonoTlsSettings settings)
		{
			return null;
		}

		internal static ChainValidationHelper Create(MobileTlsProvider provider, ref MonoTlsSettings settings, MonoTlsStream stream)
		{
			return null;
		}

		private ChainValidationHelper(SslStream owner, MobileTlsProvider provider, MonoTlsSettings settings, bool cloneSettings, MonoTlsStream stream)
		{
		}

		private static ServerCertValidationCallback GetValidationCallback(MonoTlsSettings settings)
		{
			return null;
		}

		private static X509Certificate DefaultSelectionCallback(string targetHost, X509CertificateCollection localCertificates, X509Certificate remoteCertificate, string[] acceptableIssuers)
		{
			return null;
		}

		public bool SelectClientCertificate(string targetHost, X509CertificateCollection localCertificates, X509Certificate remoteCertificate, string[] acceptableIssuers, out X509Certificate clientCertificate)
		{
			clientCertificate = null;
			return false;
		}

		public ValidationResult ValidateCertificate(string host, bool serverMode, X509Certificate leaf, X509Chain chain)
		{
			return null;
		}

		private ValidationResult ValidateChain(string host, bool server, X509Certificate leaf, X509Chain chain, X509CertificateCollection certs, SslPolicyErrors errors)
		{
			return null;
		}

		private ValidationResult ValidateChain(string host, bool server, X509Certificate leaf, ref X509Chain chain, X509CertificateCollection certs, SslPolicyErrors errors)
		{
			return null;
		}

		private bool InvokeCallback(X509Certificate leaf, X509Chain chain, SslPolicyErrors errors)
		{
			return false;
		}
	}
}
