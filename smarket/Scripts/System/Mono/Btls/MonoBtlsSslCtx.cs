using System;
using System.Runtime.InteropServices;
using Mono.Util;

namespace Mono.Btls
{
	internal class MonoBtlsSslCtx : MonoBtlsObject
	{
		internal class BoringSslCtxHandle : MonoBtlsHandle
		{
			public BoringSslCtxHandle(IntPtr handle)
				: base((IntPtr)0, ownsHandle: false)
			{
			}

			protected override bool ReleaseHandle()
			{
				return false;
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int NativeVerifyFunc(IntPtr instance, int preverify_ok, IntPtr ctx);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int NativeSelectFunc(IntPtr instance, int count, IntPtr sizes, IntPtr data);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int NativeServerNameFunc(IntPtr instance);

		private NativeVerifyFunc verifyFunc;

		private NativeSelectFunc selectFunc;

		private NativeServerNameFunc serverNameFunc;

		private IntPtr verifyFuncPtr;

		private IntPtr selectFuncPtr;

		private IntPtr serverNameFuncPtr;

		private MonoBtlsVerifyCallback verifyCallback;

		private MonoBtlsSelectCallback selectCallback;

		private MonoBtlsServerNameCallback serverNameCallback;

		private MonoBtlsX509Store store;

		private GCHandle instance;

		private IntPtr instancePtr;

		internal new BoringSslCtxHandle Handle => null;

		public MonoBtlsX509Store CertificateStore => null;

		[PreserveSig]
		private static extern IntPtr mono_btls_ssl_ctx_new();

		[PreserveSig]
		private static extern int mono_btls_ssl_ctx_free(IntPtr handle);

		[PreserveSig]
		private static extern void mono_btls_ssl_ctx_initialize(IntPtr handle, IntPtr instance);

		[PreserveSig]
		private static extern void mono_btls_ssl_ctx_set_cert_verify_callback(IntPtr handle, IntPtr func, int cert_required);

		[PreserveSig]
		private static extern void mono_btls_ssl_ctx_set_cert_select_callback(IntPtr handle, IntPtr func);

		[PreserveSig]
		private static extern void mono_btls_ssl_ctx_set_min_version(IntPtr handle, int version);

		[PreserveSig]
		private static extern void mono_btls_ssl_ctx_set_max_version(IntPtr handle, int version);

		[PreserveSig]
		private static extern int mono_btls_ssl_ctx_set_ciphers(IntPtr handle, int count, IntPtr data, int allow_unsupported);

		[PreserveSig]
		private static extern int mono_btls_ssl_ctx_set_verify_param(IntPtr handle, IntPtr param);

		[PreserveSig]
		private static extern int mono_btls_ssl_ctx_set_client_ca_list(IntPtr handle, int count, IntPtr sizes, IntPtr data);

		[PreserveSig]
		private static extern void mono_btls_ssl_ctx_set_server_name_callback(IntPtr handle, IntPtr func);

		public MonoBtlsSslCtx()
			: base(null)
		{
		}

		internal MonoBtlsSslCtx(BoringSslCtxHandle handle)
			: base(null)
		{
		}

		private int VerifyCallback(bool preverify_ok, MonoBtlsX509StoreCtx ctx)
		{
			return 0;
		}

		[MonoPInvokeCallback(typeof(NativeVerifyFunc))]
		private static int NativeVerifyCallback(IntPtr instance, int preverify_ok, IntPtr store_ctx)
		{
			return 0;
		}

		[MonoPInvokeCallback(typeof(NativeSelectFunc))]
		private static int NativeSelectCallback(IntPtr instance, int count, IntPtr sizes, IntPtr data)
		{
			return 0;
		}

		private static string[] CopyIssuers(int count, IntPtr sizesPtr, IntPtr dataPtr)
		{
			return null;
		}

		public void SetVerifyCallback(MonoBtlsVerifyCallback callback, bool client_cert_required)
		{
		}

		public void SetSelectCallback(MonoBtlsSelectCallback callback)
		{
		}

		public void SetMinVersion(int version)
		{
		}

		public void SetMaxVersion(int version)
		{
		}

		public void SetCiphers(short[] ciphers, bool allow_unsupported)
		{
		}

		public void SetVerifyParam(MonoBtlsX509VerifyParam param)
		{
		}

		public void SetClientCertificateIssuers(string[] acceptableIssuers)
		{
		}

		public void SetServerNameCallback(MonoBtlsServerNameCallback callback)
		{
		}

		[MonoPInvokeCallback(typeof(NativeServerNameFunc))]
		private static int NativeServerNameCallback(IntPtr instance)
		{
			return 0;
		}

		protected override void Close()
		{
		}
	}
}
