using System;
using System.Runtime.InteropServices;

namespace Mono.Btls
{
	internal class MonoBtlsX509 : MonoBtlsObject
	{
		internal class BoringX509Handle : MonoBtlsHandle
		{
			public BoringX509Handle(IntPtr handle)
				: base((IntPtr)0, ownsHandle: false)
			{
			}

			protected override bool ReleaseHandle()
			{
				return false;
			}

			public IntPtr StealHandle()
			{
				return (IntPtr)0;
			}
		}

		internal new BoringX509Handle Handle => null;

		internal MonoBtlsX509(BoringX509Handle handle)
			: base(null)
		{
		}

		[PreserveSig]
		private static extern IntPtr mono_btls_x509_up_ref(IntPtr handle);

		[PreserveSig]
		private static extern IntPtr mono_btls_x509_from_data(IntPtr data, int len, MonoBtlsX509Format format);

		[PreserveSig]
		private static extern IntPtr mono_btls_x509_get_subject_name(IntPtr handle);

		[PreserveSig]
		private static extern int mono_btls_x509_get_raw_data(IntPtr handle, IntPtr bio, MonoBtlsX509Format format);

		[PreserveSig]
		private static extern int mono_btls_x509_cmp(IntPtr a, IntPtr b);

		[PreserveSig]
		private static extern void mono_btls_x509_free(IntPtr handle);

		[PreserveSig]
		private static extern int mono_btls_x509_add_explicit_trust(IntPtr handle, MonoBtlsX509TrustKind kind);

		internal MonoBtlsX509 Copy()
		{
			return null;
		}

		public static MonoBtlsX509 LoadFromData(byte[] buffer, MonoBtlsX509Format format)
		{
			return null;
		}

		public MonoBtlsX509Name GetSubjectName()
		{
			return null;
		}

		public long GetSubjectNameHash()
		{
			return 0L;
		}

		public byte[] GetRawData(MonoBtlsX509Format format)
		{
			return null;
		}

		public static int Compare(MonoBtlsX509 a, MonoBtlsX509 b)
		{
			return 0;
		}

		public void AddExplicitTrust(MonoBtlsX509TrustKind kind)
		{
		}
	}
}
