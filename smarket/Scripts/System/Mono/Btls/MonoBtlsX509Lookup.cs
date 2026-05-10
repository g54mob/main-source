using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Mono.Btls
{
	internal class MonoBtlsX509Lookup : MonoBtlsObject
	{
		internal class BoringX509LookupHandle : MonoBtlsHandle
		{
			public BoringX509LookupHandle(IntPtr handle)
				: base((IntPtr)0, ownsHandle: false)
			{
			}

			protected override bool ReleaseHandle()
			{
				return false;
			}
		}

		private MonoBtlsX509Store store;

		private MonoBtlsX509LookupType type;

		private List<MonoBtlsX509LookupMono> monoLookups;

		internal new BoringX509LookupHandle Handle => null;

		[PreserveSig]
		private static extern IntPtr mono_btls_x509_lookup_new(IntPtr store, MonoBtlsX509LookupType type);

		[PreserveSig]
		private static extern int mono_btls_x509_lookup_add_dir(IntPtr handle, IntPtr dir, MonoBtlsX509FileType type);

		[PreserveSig]
		private static extern int mono_btls_x509_lookup_add_mono(IntPtr handle, IntPtr monoLookup);

		[PreserveSig]
		private static extern void mono_btls_x509_lookup_free(IntPtr handle);

		[PreserveSig]
		private static extern IntPtr mono_btls_x509_lookup_peek_lookup(IntPtr handle);

		private static BoringX509LookupHandle Create_internal(MonoBtlsX509Store store, MonoBtlsX509LookupType type)
		{
			return null;
		}

		internal MonoBtlsX509Lookup(MonoBtlsX509Store store, MonoBtlsX509LookupType type)
			: base(null)
		{
		}

		internal IntPtr GetNativeLookup()
		{
			return (IntPtr)0;
		}

		public void AddDirectory(string dir, MonoBtlsX509FileType type)
		{
		}

		internal void AddMono(MonoBtlsX509LookupMono monoLookup)
		{
		}

		internal void AddCertificate(MonoBtlsX509 certificate)
		{
		}

		protected override void Close()
		{
		}
	}
}
