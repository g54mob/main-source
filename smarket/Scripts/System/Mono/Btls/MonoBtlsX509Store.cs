using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Mono.Btls
{
	internal class MonoBtlsX509Store : MonoBtlsObject
	{
		internal class BoringX509StoreHandle : MonoBtlsHandle
		{
			public BoringX509StoreHandle(IntPtr handle)
				: base((IntPtr)0, ownsHandle: false)
			{
			}

			protected override bool ReleaseHandle()
			{
				return false;
			}
		}

		private Dictionary<IntPtr, MonoBtlsX509Lookup> lookupHash;

		internal new BoringX509StoreHandle Handle => null;

		[PreserveSig]
		private static extern IntPtr mono_btls_x509_store_new();

		[PreserveSig]
		private static extern IntPtr mono_btls_x509_store_from_ssl_ctx(IntPtr handle);

		[PreserveSig]
		private static extern int mono_btls_x509_store_add_cert(IntPtr handle, IntPtr x509);

		[PreserveSig]
		private static extern void mono_btls_x509_store_free(IntPtr handle);

		private static BoringX509StoreHandle Create_internal()
		{
			return null;
		}

		private static BoringX509StoreHandle Create_internal(MonoBtlsSslCtx.BoringSslCtxHandle ctx)
		{
			return null;
		}

		internal MonoBtlsX509Store()
			: base(null)
		{
		}

		internal MonoBtlsX509Store(MonoBtlsSslCtx.BoringSslCtxHandle ctx)
			: base(null)
		{
		}

		public void AddCertificate(MonoBtlsX509 x509)
		{
		}

		public MonoBtlsX509Lookup AddLookup(MonoBtlsX509LookupType type)
		{
			return null;
		}

		public void AddDirectoryLookup(string dir, MonoBtlsX509FileType type)
		{
		}

		public void AddCollection(X509CertificateCollection collection, MonoBtlsX509TrustKind trust)
		{
		}

		protected override void Close()
		{
		}
	}
}
