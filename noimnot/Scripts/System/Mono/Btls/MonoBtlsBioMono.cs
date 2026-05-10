using System;
using System.Runtime.InteropServices;
using Mono.Util;

namespace Mono.Btls
{
	internal class MonoBtlsBioMono : MonoBtlsBio
	{
		private enum ControlCommand
		{
			Flush = 1
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int BioReadFunc(IntPtr bio, IntPtr data, int dataLength, out int wantMore);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int BioWriteFunc(IntPtr bio, IntPtr data, int dataLength);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate long BioControlFunc(IntPtr bio, ControlCommand command, long arg);

		private GCHandle handle;

		private IntPtr instance;

		private BioReadFunc readFunc;

		private BioWriteFunc writeFunc;

		private BioControlFunc controlFunc;

		private IntPtr readFuncPtr;

		private IntPtr writeFuncPtr;

		private IntPtr controlFuncPtr;

		private IMonoBtlsBioMono backend;

		public MonoBtlsBioMono(IMonoBtlsBioMono backend)
			: base(null)
		{
		}

		[PreserveSig]
		private static extern IntPtr mono_btls_bio_mono_new();

		[PreserveSig]
		private static extern void mono_btls_bio_mono_initialize(IntPtr handle, IntPtr instance, IntPtr readFunc, IntPtr writeFunc, IntPtr controlFunc);

		private long Control(ControlCommand command, long arg)
		{
			return 0L;
		}

		private int OnRead(IntPtr data, int dataLength, out int wantMore)
		{
			wantMore = default(int);
			return 0;
		}

		[MonoPInvokeCallback(typeof(BioReadFunc))]
		private static int OnRead(IntPtr instance, IntPtr data, int dataLength, out int wantMore)
		{
			wantMore = default(int);
			return 0;
		}

		private int OnWrite(IntPtr data, int dataLength)
		{
			return 0;
		}

		[MonoPInvokeCallback(typeof(BioWriteFunc))]
		private static int OnWrite(IntPtr instance, IntPtr data, int dataLength)
		{
			return 0;
		}

		[MonoPInvokeCallback(typeof(BioControlFunc))]
		private static long Control(IntPtr instance, ControlCommand command, long arg)
		{
			return 0L;
		}

		protected override void Close()
		{
		}
	}
}
