using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Mono.Btls
{
	internal class MonoBtlsKey : MonoBtlsObject
	{
		internal class BoringKeyHandle : MonoBtlsHandle
		{
			internal BoringKeyHandle(IntPtr handle)
				: base((IntPtr)0, ownsHandle: false)
			{
			}

			protected override bool ReleaseHandle()
			{
				return false;
			}
		}

		internal new BoringKeyHandle Handle => null;

		[PreserveSig]
		private static extern IntPtr mono_btls_key_new();

		[PreserveSig]
		private static extern void mono_btls_key_free(IntPtr handle);

		[PreserveSig]
		private static extern IntPtr mono_btls_key_up_ref(IntPtr handle);

		[PreserveSig]
		private static extern int mono_btls_key_get_bytes(IntPtr handle, out IntPtr data, out int size, int include_private_bits);

		[PreserveSig]
		private static extern int mono_btls_key_assign_rsa_private_key(IntPtr handle, byte[] der, int der_length);

		internal MonoBtlsKey(BoringKeyHandle handle)
			: base(null)
		{
		}

		public byte[] GetBytes(bool include_private_bits)
		{
			return null;
		}

		public MonoBtlsKey Copy()
		{
			return null;
		}

		public static MonoBtlsKey CreateFromRSAPrivateKey(RSA privateKey)
		{
			return null;
		}
	}
}
