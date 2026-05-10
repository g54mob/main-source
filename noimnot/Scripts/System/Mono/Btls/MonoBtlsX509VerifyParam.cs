using System;
using System.Runtime.InteropServices;

namespace Mono.Btls
{
	internal class MonoBtlsX509VerifyParam : MonoBtlsObject
	{
		internal class BoringX509VerifyParamHandle : MonoBtlsHandle
		{
			public BoringX509VerifyParamHandle(IntPtr handle)
				: base((IntPtr)0, ownsHandle: false)
			{
			}

			protected override bool ReleaseHandle()
			{
				return false;
			}
		}

		internal new BoringX509VerifyParamHandle Handle => null;

		public bool CanModify => false;

		[PreserveSig]
		private static extern IntPtr mono_btls_x509_verify_param_copy(IntPtr handle);

		[PreserveSig]
		private static extern IntPtr mono_btls_x509_verify_param_lookup(IntPtr name);

		[PreserveSig]
		private static extern int mono_btls_x509_verify_param_can_modify(IntPtr param);

		[PreserveSig]
		private static extern int mono_btls_x509_verify_param_set_host(IntPtr handle, IntPtr name, int namelen);

		[PreserveSig]
		private static extern int mono_btls_x509_verify_param_set_time(IntPtr handle, long time);

		[PreserveSig]
		private static extern void mono_btls_x509_verify_param_free(IntPtr handle);

		internal MonoBtlsX509VerifyParam(BoringX509VerifyParamHandle handle)
			: base(null)
		{
		}

		public MonoBtlsX509VerifyParam Copy()
		{
			return null;
		}

		public static MonoBtlsX509VerifyParam GetSslClient()
		{
			return null;
		}

		public static MonoBtlsX509VerifyParam GetSslServer()
		{
			return null;
		}

		public static MonoBtlsX509VerifyParam Lookup(string name, bool fail = false)
		{
			return null;
		}

		private void WantToModify()
		{
		}

		public void SetHost(string name)
		{
		}

		public void SetTime(DateTime time)
		{
		}
	}
}
