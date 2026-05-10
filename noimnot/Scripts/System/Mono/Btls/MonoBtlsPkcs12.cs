using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Mono.Btls
{
	internal class MonoBtlsPkcs12 : MonoBtlsObject
	{
		internal class BoringPkcs12Handle : MonoBtlsHandle
		{
			public BoringPkcs12Handle(IntPtr handle)
				: base((IntPtr)0, ownsHandle: false)
			{
			}

			protected override bool ReleaseHandle()
			{
				return false;
			}
		}

		private MonoBtlsKey privateKey;

		internal new BoringPkcs12Handle Handle => null;

		public int Count => 0;

		public bool HasPrivateKey => false;

		[PreserveSig]
		private static extern void mono_btls_pkcs12_free(IntPtr handle);

		[PreserveSig]
		private static extern IntPtr mono_btls_pkcs12_new();

		[PreserveSig]
		private static extern int mono_btls_pkcs12_get_count(IntPtr handle);

		[PreserveSig]
		private static extern IntPtr mono_btls_pkcs12_get_cert(IntPtr Handle, int index);

		[PreserveSig]
		private unsafe static extern int mono_btls_pkcs12_import(IntPtr chain, void* data, int len, SafePasswordHandle password);

		[PreserveSig]
		private static extern int mono_btls_pkcs12_has_private_key(IntPtr pkcs12);

		[PreserveSig]
		private static extern IntPtr mono_btls_pkcs12_get_private_key(IntPtr pkcs12);

		internal MonoBtlsPkcs12()
			: base(null)
		{
		}

		public MonoBtlsX509 GetCertificate(int index)
		{
			return null;
		}

		public void Import(byte[] buffer, SafePasswordHandle password)
		{
		}

		public MonoBtlsKey GetPrivateKey()
		{
			return null;
		}
	}
}
