using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Mono.Util;

namespace Mono.Btls
{
	internal class MonoBtlsSsl : MonoBtlsObject
	{
		internal class BoringSslHandle : MonoBtlsHandle
		{
			public BoringSslHandle(IntPtr handle)
				: base((IntPtr)0, ownsHandle: false)
			{
			}

			protected override bool ReleaseHandle()
			{
				return false;
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int PrintErrorsCallbackFunc(IntPtr str, IntPtr len, IntPtr ctx);

		private MonoBtlsBio bio;

		private PrintErrorsCallbackFunc printErrorsFunc;

		private IntPtr printErrorsFuncPtr;

		internal new BoringSslHandle Handle => null;

		[PreserveSig]
		private static extern void mono_btls_ssl_destroy(IntPtr handle);

		[PreserveSig]
		private static extern IntPtr mono_btls_ssl_new(IntPtr handle);

		[PreserveSig]
		private static extern int mono_btls_ssl_use_certificate(IntPtr handle, IntPtr x509);

		[PreserveSig]
		private static extern int mono_btls_ssl_use_private_key(IntPtr handle, IntPtr key);

		[PreserveSig]
		private static extern int mono_btls_ssl_add_chain_certificate(IntPtr handle, IntPtr x509);

		[PreserveSig]
		private static extern int mono_btls_ssl_accept(IntPtr handle);

		[PreserveSig]
		private static extern int mono_btls_ssl_connect(IntPtr handle);

		[PreserveSig]
		private static extern int mono_btls_ssl_handshake(IntPtr handle);

		[PreserveSig]
		private static extern void mono_btls_ssl_close(IntPtr handle);

		[PreserveSig]
		private static extern int mono_btls_ssl_shutdown(IntPtr handle);

		[PreserveSig]
		private static extern void mono_btls_ssl_set_quiet_shutdown(IntPtr handle, int mode);

		[PreserveSig]
		private static extern void mono_btls_ssl_set_bio(IntPtr handle, IntPtr bio);

		[PreserveSig]
		private static extern int mono_btls_ssl_read(IntPtr handle, IntPtr data, int len);

		[PreserveSig]
		private static extern int mono_btls_ssl_write(IntPtr handle, IntPtr data, int len);

		[PreserveSig]
		private static extern int mono_btls_ssl_get_error(IntPtr handle, int ret_code);

		[PreserveSig]
		private static extern int mono_btls_ssl_get_version(IntPtr handle);

		[PreserveSig]
		private static extern int mono_btls_ssl_get_cipher(IntPtr handle);

		[PreserveSig]
		private static extern IntPtr mono_btls_ssl_get_peer_certificate(IntPtr handle);

		[PreserveSig]
		private static extern void mono_btls_ssl_print_errors_cb(IntPtr func, IntPtr ctx);

		[PreserveSig]
		private static extern int mono_btls_ssl_set_server_name(IntPtr handle, IntPtr name);

		[PreserveSig]
		private static extern IntPtr mono_btls_ssl_get_server_name(IntPtr handle);

		[PreserveSig]
		private static extern void mono_btls_ssl_set_renegotiate_mode(IntPtr handle, int mode);

		[PreserveSig]
		private static extern int mono_btls_ssl_renegotiate_pending(IntPtr handle);

		private static BoringSslHandle Create_internal(MonoBtlsSslCtx ctx)
		{
			return null;
		}

		public MonoBtlsSsl(MonoBtlsSslCtx ctx)
			: base(null)
		{
		}

		public void SetBio(MonoBtlsBio bio)
		{
		}

		private Exception ThrowError([CallerMemberName] string callerName = null)
		{
			return null;
		}

		private MonoBtlsSslError GetError(int ret_code)
		{
			return default(MonoBtlsSslError);
		}

		public void SetCertificate(MonoBtlsX509 x509)
		{
		}

		public void SetPrivateKey(MonoBtlsKey key)
		{
		}

		public void AddIntermediateCertificate(MonoBtlsX509 x509)
		{
		}

		public MonoBtlsSslError Accept()
		{
			return default(MonoBtlsSslError);
		}

		public MonoBtlsSslError Connect()
		{
			return default(MonoBtlsSslError);
		}

		public MonoBtlsSslError Handshake()
		{
			return default(MonoBtlsSslError);
		}

		[MonoPInvokeCallback(typeof(PrintErrorsCallbackFunc))]
		private static int PrintErrorsCallback(IntPtr str, IntPtr len, IntPtr ctx)
		{
			return 0;
		}

		public string GetErrors()
		{
			return null;
		}

		public void PrintErrors()
		{
		}

		public MonoBtlsSslError Read(IntPtr data, ref int dataSize)
		{
			return default(MonoBtlsSslError);
		}

		public MonoBtlsSslError Write(IntPtr data, ref int dataSize)
		{
			return default(MonoBtlsSslError);
		}

		public int GetVersion()
		{
			return 0;
		}

		public int GetCipher()
		{
			return 0;
		}

		public MonoBtlsX509 GetPeerCertificate()
		{
			return null;
		}

		public void SetServerName(string name)
		{
		}

		public string GetServerName()
		{
			return null;
		}

		public void Shutdown()
		{
		}

		public void SetQuietShutdown()
		{
		}

		protected override void Close()
		{
		}

		public void SetRenegotiateMode(MonoBtlsSslRenegotiateMode mode)
		{
		}

		public bool RenegotiatePending()
		{
			return false;
		}
	}
}
