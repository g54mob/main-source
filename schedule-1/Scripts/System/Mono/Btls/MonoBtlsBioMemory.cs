using System;
using System.Runtime.InteropServices;

namespace Mono.Btls
{
	internal class MonoBtlsBioMemory : MonoBtlsBio
	{
		[PreserveSig]
		private static extern IntPtr mono_btls_bio_mem_new();

		[PreserveSig]
		private static extern int mono_btls_bio_mem_get_data(IntPtr handle, out IntPtr data);

		public MonoBtlsBioMemory()
			: base(null)
		{
		}

		public byte[] GetData()
		{
			return null;
		}
	}
}
