using System;
using System.Security.Cryptography.X509Certificates;

namespace Mono.Security.Interface
{
	public sealed class MonoTlsSettings
	{
		private bool cloned;

		private bool checkCertName;

		private bool checkCertRevocationStatus;

		private bool? useServicePointManagerCallback;

		private bool skipSystemValidators;

		private bool callbackNeedsChain;

		private ICertificateValidator certificateValidator;

		private static MonoTlsSettings defaultSettings;

		public MonoRemoteCertificateValidationCallback RemoteCertificateValidationCallback { get; set; }

		public MonoLocalCertificateSelectionCallback ClientCertificateSelectionCallback { get; set; }

		public bool? UseServicePointManagerCallback
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool CallbackNeedsCertificateChain => false;

		public DateTime? CertificateValidationTime { get; set; }

		public X509CertificateCollection TrustAnchors { get; set; }

		public object UserSettings { get; set; }

		internal string[] CertificateSearchPaths { get; set; }

		internal bool SendCloseNotify { get; set; }

		public string[] ClientCertificateIssuers { get; set; }

		public bool DisallowUnauthenticatedCertificateRequest { get; set; }

		public TlsProtocols? EnabledProtocols { get; set; }

		[CLSCompliant(false)]
		public CipherSuiteCode[] EnabledCiphers { get; set; }

		public static MonoTlsSettings DefaultSettings => null;

		[Obsolete("Do not use outside System.dll!")]
		public ICertificateValidator CertificateValidator => null;

		public MonoTlsSettings()
		{
		}

		public static MonoTlsSettings CopyDefaultSettings()
		{
			return null;
		}

		[Obsolete("Do not use outside System.dll!")]
		public MonoTlsSettings CloneWithValidator(ICertificateValidator validator)
		{
			return null;
		}

		public MonoTlsSettings Clone()
		{
			return null;
		}

		private MonoTlsSettings(MonoTlsSettings other)
		{
		}
	}
}
