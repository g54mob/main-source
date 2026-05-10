using System;
using System.Runtime.InteropServices;
using Mono.Util;

namespace Mono.Btls
{
	internal abstract class MonoBtlsX509LookupMono : MonoBtlsObject
	{
		internal class BoringX509LookupMonoHandle : MonoBtlsHandle
		{
			public BoringX509LookupMonoHandle(IntPtr handle)
				: base((IntPtr)0, ownsHandle: false)
			{
			}

			protected override bool ReleaseHandle()
			{
				return false;
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int BySubjectFunc(IntPtr instance, IntPtr name, out IntPtr x509_ptr);

		private GCHandle gch;

		private IntPtr instance;

		private BySubjectFunc bySubjectFunc;

		private IntPtr bySubjectFuncPtr;

		private MonoBtlsX509Lookup lookup;

		internal new BoringX509LookupMonoHandle Handle => null;

		[PreserveSig]
		private static extern IntPtr mono_btls_x509_lookup_mono_new();

		[PreserveSig]
		private static extern void mono_btls_x509_lookup_mono_init(IntPtr handle, IntPtr instance, IntPtr by_subject_func);

		[PreserveSig]
		private static extern int mono_btls_x509_lookup_mono_free(IntPtr handle);

		internal MonoBtlsX509LookupMono()
			: base(null)
		{
		}

		internal void Install(MonoBtlsX509Lookup lookup)
		{
		}

		protected void AddCertificate(MonoBtlsX509 certificate)
		{
		}

		protected abstract MonoBtlsX509 OnGetBySubject(MonoBtlsX509Name name);

		[MonoPInvokeCallback(typeof(BySubjectFunc))]
		private static int OnGetBySubject(IntPtr instance, IntPtr name_ptr, out IntPtr x509_ptr)
		{
			x509_ptr = default(IntPtr);
			return 0;
		}

		protected override void Close()
		{
		}
	}
}
