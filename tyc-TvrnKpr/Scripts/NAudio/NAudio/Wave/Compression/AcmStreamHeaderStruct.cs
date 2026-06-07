using System;
using System.Runtime.InteropServices;

namespace NAudio.Wave.Compression
{
	[StructLayout((LayoutKind)0)]
	internal class AcmStreamHeaderStruct
	{
		public int cbStruct;

		public AcmStreamHeaderStatusFlags fdwStatus;

		public IntPtr userData;

		public IntPtr sourceBufferPointer;

		public int sourceBufferLength;

		public int sourceBufferLengthUsed;

		public IntPtr sourceUserData;

		public IntPtr destBufferPointer;

		public int destBufferLength;

		public int destBufferLengthUsed;

		public IntPtr destUserData;
	}
}
