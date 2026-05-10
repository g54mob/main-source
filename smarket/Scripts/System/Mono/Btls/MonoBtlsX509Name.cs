using System;
using System.Runtime.InteropServices;

namespace Mono.Btls
{
	internal class MonoBtlsX509Name : MonoBtlsObject
	{
		internal class BoringX509NameHandle : MonoBtlsHandle
		{
			private bool dontFree;

			internal BoringX509NameHandle(IntPtr handle, bool ownsHandle)
				: base((IntPtr)0, ownsHandle: false)
			{
			}

			protected override bool ReleaseHandle()
			{
				return false;
			}
		}

		internal new BoringX509NameHandle Handle => null;

		[PreserveSig]
		private static extern long mono_btls_x509_name_hash(IntPtr handle);

		[PreserveSig]
		private static extern int mono_btls_x509_name_get_entry_count(IntPtr handle);

		[PreserveSig]
		private static extern MonoBtlsX509NameEntryType mono_btls_x509_name_get_entry_type(IntPtr name, int index);

		[PreserveSig]
		private static extern int mono_btls_x509_name_get_entry_oid(IntPtr name, int index, IntPtr buffer, int size);

		[PreserveSig]
		private static extern int mono_btls_x509_name_get_entry_oid_data(IntPtr name, int index, out IntPtr data);

		[PreserveSig]
		private static extern int mono_btls_x509_name_get_entry_value(IntPtr name, int index, out int tag, out IntPtr str);

		[PreserveSig]
		private unsafe static extern IntPtr mono_btls_x509_name_from_data(void* data, int len, int use_canon_enc);

		[PreserveSig]
		private static extern void mono_btls_x509_name_free(IntPtr handle);

		internal MonoBtlsX509Name(BoringX509NameHandle handle)
			: base(null)
		{
		}

		public long GetHash()
		{
			return 0L;
		}

		public int GetEntryCount()
		{
			return 0;
		}

		public MonoBtlsX509NameEntryType GetEntryType(int index)
		{
			return default(MonoBtlsX509NameEntryType);
		}

		public string GetEntryOid(int index)
		{
			return null;
		}

		public byte[] GetEntryOidData(int index)
		{
			return null;
		}

		public string GetEntryValue(int index, out int tag)
		{
			tag = default(int);
			return null;
		}

		public static MonoBtlsX509Name CreateFromData(byte[] data, bool use_canon_enc)
		{
			return null;
		}
	}
}
