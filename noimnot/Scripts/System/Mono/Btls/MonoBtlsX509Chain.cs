using System;
using System.Runtime.InteropServices;

namespace Mono.Btls
{
	internal class MonoBtlsX509Chain : MonoBtlsObject
	{
		internal class BoringX509ChainHandle : MonoBtlsHandle
		{
			public BoringX509ChainHandle(IntPtr handle)
				: base((IntPtr)0, ownsHandle: false)
			{
			}

			protected override bool ReleaseHandle()
			{
				return false;
			}
		}

		internal new BoringX509ChainHandle Handle => null;

		public int Count => 0;

		[PreserveSig]
		private static extern IntPtr mono_btls_x509_chain_new();

		[PreserveSig]
		private static extern int mono_btls_x509_chain_get_count(IntPtr handle);

		[PreserveSig]
		private static extern IntPtr mono_btls_x509_chain_get_cert(IntPtr Handle, int index);

		[PreserveSig]
		private static extern int mono_btls_x509_chain_add_cert(IntPtr chain, IntPtr x509);

		[PreserveSig]
		private static extern IntPtr mono_btls_x509_chain_up_ref(IntPtr handle);

		[PreserveSig]
		private static extern void mono_btls_x509_chain_free(IntPtr handle);

		public MonoBtlsX509Chain()
			: base(null)
		{
		}

		internal MonoBtlsX509Chain(BoringX509ChainHandle handle)
			: base(null)
		{
		}

		public MonoBtlsX509 GetCertificate(int index)
		{
			return null;
		}

		public void AddCertificate(MonoBtlsX509 x509)
		{
		}

		internal MonoBtlsX509Chain Copy()
		{
			return null;
		}
	}
}
