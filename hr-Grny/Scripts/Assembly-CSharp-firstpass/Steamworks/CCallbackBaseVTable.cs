using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0)]
	internal class CCallbackBaseVTable
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void RunCBDel(IntPtr thisptr, IntPtr pvParam);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void RunCRDel(IntPtr thisptr, IntPtr pvParam, bool bIOFailure, ulong hSteamAPICall);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int GetCallbackSizeBytesDel(IntPtr thisptr);

		private const CallingConvention cc = CallingConvention.Cdecl;

		[NonSerialized]
		public RunCRDel m_RunCallResult;

		[NonSerialized]
		public RunCBDel m_RunCallback;

		[NonSerialized]
		public GetCallbackSizeBytesDel m_GetCallbackSizeBytes;
	}
}
