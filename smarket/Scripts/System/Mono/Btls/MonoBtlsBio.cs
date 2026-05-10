using System;
using System.Runtime.InteropServices;

namespace Mono.Btls
{
	internal class MonoBtlsBio : MonoBtlsObject
	{
		protected internal class BoringBioHandle : MonoBtlsHandle
		{
			public BoringBioHandle(IntPtr handle)
				: base((IntPtr)0, ownsHandle: false)
			{
			}

			protected override bool ReleaseHandle()
			{
				return false;
			}
		}

		protected internal new BoringBioHandle Handle => null;

		internal MonoBtlsBio(BoringBioHandle handle)
			: base(null)
		{
		}

		[PreserveSig]
		private static extern void mono_btls_bio_free(IntPtr handle);
	}
}
