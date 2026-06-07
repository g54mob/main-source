using System;
using System.Net.Security;
using System.Runtime.InteropServices;

internal static class Interop
{
	internal static class Crypt32
	{
		[PreserveSig]
		internal static extern bool CertFreeCertificateContext(IntPtr pCertContext);
	}

	internal enum SECURITY_STATUS
	{
		OK = 0,
		ContinueNeeded = 590610,
		CompleteNeeded = 590611,
		CompAndContinue = 590612,
		ContextExpired = 590615,
		CredentialsNeeded = 590624,
		Renegotiate = 590625,
		OutOfMemory = -2146893056,
		InvalidHandle = -2146893055,
		Unsupported = -2146893054,
		TargetUnknown = -2146893053,
		InternalError = -2146893052,
		PackageNotFound = -2146893051,
		NotOwner = -2146893050,
		CannotInstall = -2146893049,
		InvalidToken = -2146893048,
		CannotPack = -2146893047,
		QopNotSupported = -2146893046,
		NoImpersonation = -2146893045,
		LogonDenied = -2146893044,
		UnknownCredentials = -2146893043,
		NoCredentials = -2146893042,
		MessageAltered = -2146893041,
		OutOfSequence = -2146893040,
		NoAuthenticatingAuthority = -2146893039,
		IncompleteMessage = -2146893032,
		IncompleteCredentials = -2146893024,
		BufferNotEnough = -2146893023,
		WrongPrincipal = -2146893022,
		TimeSkew = -2146893020,
		UntrustedRoot = -2146893019,
		IllegalMessage = -2146893018,
		CertUnknown = -2146893017,
		CertExpired = -2146893016,
		AlgorithmMismatch = -2146893007,
		SecurityQosFailed = -2146893006,
		SmartcardLogonRequired = -2146892994,
		UnsupportedPreauth = -2146892989,
		BadBinding = -2146892986,
		DowngradeDetected = -2146892976,
		ApplicationProtocolMismatch = -2146892953
	}

	internal enum ApplicationProtocolNegotiationStatus
	{
		None = 0,
		Success = 1,
		SelectedClientOnly = 2
	}

	internal enum ApplicationProtocolNegotiationExt
	{
		None = 0,
		NPN = 1,
		ALPN = 2
	}

	[StructLayout((LayoutKind)0)]
	internal class SecPkgContext_ApplicationProtocol
	{
		public ApplicationProtocolNegotiationStatus ProtoNegoStatus;

		public ApplicationProtocolNegotiationExt ProtoNegoExt;

		public byte ProtocolIdSize;

		public byte[] ProtocolId;
	}

	internal class Kernel32
	{
		[PreserveSig]
		internal static extern bool CloseHandle(IntPtr handle);
	}

	internal static class SspiCli
	{
		[StructLayout((LayoutKind)0, Pack = 1, Size = 16)]
		internal struct CredHandle
		{
			private IntPtr dwLower;

			private IntPtr dwUpper;

			public bool IsZero => false;

			internal void SetToInvalid()
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		internal enum ContextAttribute
		{
			SECPKG_ATTR_SIZES = 0,
			SECPKG_ATTR_NAMES = 1,
			SECPKG_ATTR_LIFESPAN = 2,
			SECPKG_ATTR_DCE_INFO = 3,
			SECPKG_ATTR_STREAM_SIZES = 4,
			SECPKG_ATTR_AUTHORITY = 6,
			SECPKG_ATTR_PACKAGE_INFO = 10,
			SECPKG_ATTR_NEGOTIATION_INFO = 12,
			SECPKG_ATTR_UNIQUE_BINDINGS = 25,
			SECPKG_ATTR_ENDPOINT_BINDINGS = 26,
			SECPKG_ATTR_CLIENT_SPECIFIED_TARGET = 27,
			SECPKG_ATTR_APPLICATION_PROTOCOL = 35,
			SECPKG_ATTR_REMOTE_CERT_CONTEXT = 83,
			SECPKG_ATTR_LOCAL_CERT_CONTEXT = 84,
			SECPKG_ATTR_ROOT_STORE = 85,
			SECPKG_ATTR_ISSUER_LIST_EX = 89,
			SECPKG_ATTR_CONNECTION_INFO = 90,
			SECPKG_ATTR_UI_INFO = 104
		}

		[Flags]
		internal enum ContextFlags
		{
			Zero = 0,
			Delegate = 1,
			MutualAuth = 2,
			ReplayDetect = 4,
			SequenceDetect = 8,
			Confidentiality = 0x10,
			UseSessionKey = 0x20,
			AllocateMemory = 0x100,
			Connection = 0x800,
			InitExtendedError = 0x4000,
			AcceptExtendedError = 0x8000,
			InitStream = 0x8000,
			AcceptStream = 0x10000,
			InitIntegrity = 0x10000,
			AcceptIntegrity = 0x20000,
			InitManualCredValidation = 0x80000,
			InitUseSuppliedCreds = 0x80,
			InitIdentify = 0x20000,
			AcceptIdentify = 0x80000,
			ProxyBindings = 0x4000000,
			AllowMissingBindings = 0x10000000,
			UnverifiedTargetName = 0x20000000
		}

		internal enum Endianness
		{
			SECURITY_NETWORK_DREP = 0,
			SECURITY_NATIVE_DREP = 0x10
		}

		internal enum CredentialUse
		{
			SECPKG_CRED_INBOUND = 1,
			SECPKG_CRED_OUTBOUND = 2,
			SECPKG_CRED_BOTH = 3
		}

		internal struct SecPkgContext_IssuerListInfoEx
		{
			public SafeHandle aIssuers;

			public uint cIssuers;

			public SecPkgContext_IssuerListInfoEx(SafeHandle handle, byte[] nativeBuffer)
			{
				aIssuers = null;
				cIssuers = 0u;
			}
		}

		internal struct SCHANNEL_CRED
		{
			[Flags]
			public enum Flags
			{
				Zero = 0,
				SCH_CRED_NO_SYSTEM_MAPPER = 2,
				SCH_CRED_NO_SERVERNAME_CHECK = 4,
				SCH_CRED_MANUAL_CRED_VALIDATION = 8,
				SCH_CRED_NO_DEFAULT_CREDS = 0x10,
				SCH_CRED_AUTO_CRED_VALIDATION = 0x20,
				SCH_SEND_AUX_RECORD = 0x200000,
				SCH_USE_STRONG_CRYPTO = 0x400000
			}

			public int dwVersion;

			public int cCreds;

			public IntPtr paCred;

			public IntPtr hRootStore;

			public int cMappers;

			public IntPtr aphMappers;

			public int cSupportedAlgs;

			public IntPtr palgSupportedAlgs;

			public int grbitEnabledProtocols;

			public int dwMinimumCipherStrength;

			public int dwMaximumCipherStrength;

			public int dwSessionLifespan;

			public Flags dwFlags;

			public int reserved;
		}

		internal struct SecBuffer
		{
			public int cbBuffer;

			public SecurityBufferType BufferType;

			public IntPtr pvBuffer;

			public static readonly int Size;
		}

		internal struct SecBufferDesc
		{
			public readonly int ulVersion;

			public readonly int cBuffers;

			public unsafe void* pBuffers;

			public unsafe SecBufferDesc(int count)
			{
				ulVersion = 0;
				cBuffers = 0;
				pBuffers = null;
			}
		}

		[StructLayout((LayoutKind)0, CharSet = CharSet.Unicode)]
		internal struct SEC_WINNT_AUTH_IDENTITY_W
		{
			internal string User;

			internal int UserLength;

			internal string Domain;

			internal int DomainLength;

			internal string Password;

			internal int PasswordLength;

			internal int Flags;
		}

		[PreserveSig]
		internal static extern int EncryptMessage(ref CredHandle contextHandle, [In] uint qualityOfProtection, [In][Out] ref SecBufferDesc inputOutput, [In] uint sequenceNumber);

		[PreserveSig]
		internal unsafe static extern int DecryptMessage([In] ref CredHandle contextHandle, [In][Out] ref SecBufferDesc inputOutput, [In] uint sequenceNumber, uint* qualityOfProtection);

		[PreserveSig]
		internal static extern int QuerySecurityContextToken(ref CredHandle phContext, out SecurityContextTokenHandle handle);

		[PreserveSig]
		internal static extern int FreeContextBuffer([In] IntPtr contextBuffer);

		[PreserveSig]
		internal static extern int FreeCredentialsHandle(ref CredHandle handlePtr);

		[PreserveSig]
		internal static extern int DeleteSecurityContext(ref CredHandle handlePtr);

		[PreserveSig]
		internal unsafe static extern int AcceptSecurityContext(ref CredHandle credentialHandle, [In] void* inContextPtr, [In] SecBufferDesc* inputBuffer, [In] ContextFlags inFlags, [In] Endianness endianness, ref CredHandle outContextPtr, [In][Out] ref SecBufferDesc outputBuffer, [In][Out] ref ContextFlags attributes, out long timeStamp);

		[PreserveSig]
		internal unsafe static extern int QueryContextAttributesW(ref CredHandle contextHandle, [In] ContextAttribute attribute, [In] void* buffer);

		[PreserveSig]
		internal static extern int SetContextAttributesW(ref CredHandle contextHandle, [In] ContextAttribute attribute, [In] byte[] buffer, [In] int bufferSize);

		[PreserveSig]
		internal static extern int EnumerateSecurityPackagesW(out int pkgnum, out SafeFreeContextBuffer_SECURITY handle);

		[PreserveSig]
		internal unsafe static extern int AcquireCredentialsHandleW([In] string principal, [In] string moduleName, [In] int usage, [In] void* logonID, [In] ref SEC_WINNT_AUTH_IDENTITY_W authdata, [In] void* keyCallback, [In] void* keyArgument, ref CredHandle handlePtr, out long timeStamp);

		[PreserveSig]
		internal unsafe static extern int AcquireCredentialsHandleW([In] string principal, [In] string moduleName, [In] int usage, [In] void* logonID, [In] IntPtr zero, [In] void* keyCallback, [In] void* keyArgument, ref CredHandle handlePtr, out long timeStamp);

		[PreserveSig]
		internal unsafe static extern int AcquireCredentialsHandleW([In] string principal, [In] string moduleName, [In] int usage, [In] void* logonID, [In] SafeSspiAuthDataHandle authdata, [In] void* keyCallback, [In] void* keyArgument, ref CredHandle handlePtr, out long timeStamp);

		[PreserveSig]
		internal unsafe static extern int AcquireCredentialsHandleW([In] string principal, [In] string moduleName, [In] int usage, [In] void* logonID, [In] ref SCHANNEL_CRED authData, [In] void* keyCallback, [In] void* keyArgument, ref CredHandle handlePtr, out long timeStamp);

		[PreserveSig]
		internal unsafe static extern int InitializeSecurityContextW(ref CredHandle credentialHandle, [In] void* inContextPtr, [In] byte* targetName, [In] ContextFlags inFlags, [In] int reservedI, [In] Endianness endianness, [In] SecBufferDesc* inputBuffer, [In] int reservedII, ref CredHandle outContextPtr, [In][Out] ref SecBufferDesc outputBuffer, [In][Out] ref ContextFlags attributes, out long timeStamp);

		[PreserveSig]
		internal unsafe static extern int CompleteAuthToken([In] void* inContextPtr, [In][Out] ref SecBufferDesc inputBuffers);

		[PreserveSig]
		internal unsafe static extern int ApplyControlToken([In] void* inContextPtr, [In][Out] ref SecBufferDesc inputBuffers);

		[PreserveSig]
		internal static extern SECURITY_STATUS SspiFreeAuthIdentity([In] IntPtr authData);
	}
}
