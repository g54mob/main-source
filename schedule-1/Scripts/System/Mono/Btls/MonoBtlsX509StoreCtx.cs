using System;
using System.Runtime.InteropServices;

namespace Mono.Btls
{
	internal class MonoBtlsX509StoreCtx : MonoBtlsObject
	{
		internal class BoringX509StoreCtxHandle : MonoBtlsHandle
		{
			private bool dontFree;

			internal BoringX509StoreCtxHandle(IntPtr handle, bool ownsHandle = true)
				: base((IntPtr)0, ownsHandle: false)
			{
			}

			protected override bool ReleaseHandle()
			{
				return false;
			}
		}

		private int? verifyResult;

		internal new BoringX509StoreCtxHandle Handle => null;

		public int VerifyResult => 0;

		[PreserveSig]
		private static extern IntPtr mono_btls_x509_store_ctx_new();

		[PreserveSig]
		private static extern IntPtr mono_btls_x509_store_ctx_from_ptr(IntPtr ctx);

		[PreserveSig]
		private static extern MonoBtlsX509Error mono_btls_x509_store_ctx_get_error(IntPtr handle, out IntPtr error_string);

		[PreserveSig]
		private static extern IntPtr mono_btls_x509_store_ctx_get_chain(IntPtr handle);

		[PreserveSig]
		private static extern int mono_btls_x509_store_ctx_init(IntPtr handle, IntPtr store, IntPtr chain);

		[PreserveSig]
		private static extern int mono_btls_x509_store_ctx_set_param(IntPtr handle, IntPtr param);

		[PreserveSig]
		private static extern int mono_btls_x509_store_ctx_verify_cert(IntPtr handle);

		[PreserveSig]
		private static extern IntPtr mono_btls_x509_store_ctx_get_untrusted(IntPtr handle);

		[PreserveSig]
		private static extern IntPtr mono_btls_x509_store_ctx_up_ref(IntPtr handle);

		[PreserveSig]
		private static extern void mono_btls_x509_store_ctx_free(IntPtr handle);

		internal MonoBtlsX509StoreCtx()
			: base(null)
		{
		}

		private static BoringX509StoreCtxHandle Create_internal(IntPtr store_ctx)
		{
			return null;
		}

		internal MonoBtlsX509StoreCtx(int preverify_ok, IntPtr store_ctx)
			: base(null)
		{
		}

		internal MonoBtlsX509StoreCtx(BoringX509StoreCtxHandle ptr, int? verifyResult)
			: base(null)
		{
		}

		public MonoBtlsX509Error GetError()
		{
			return default(MonoBtlsX509Error);
		}

		public MonoBtlsX509Chain GetChain()
		{
			return null;
		}

		public MonoBtlsX509Chain GetUntrusted()
		{
			return null;
		}

		public void Initialize(MonoBtlsX509Store store, MonoBtlsX509Chain chain)
		{
		}

		public void SetVerifyParam(MonoBtlsX509VerifyParam param)
		{
		}

		public int Verify()
		{
			return 0;
		}

		public MonoBtlsX509StoreCtx Copy()
		{
			return null;
		}
	}
}
