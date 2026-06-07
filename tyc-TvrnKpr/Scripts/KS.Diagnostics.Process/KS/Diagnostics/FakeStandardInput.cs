using System;
using System.Runtime.InteropServices;

namespace KS.Diagnostics
{
	public class FakeStandardInput
	{
		public class FakeBaseStream
		{
			private readonly IntPtr procPtr;

			public FakeBaseStream(IntPtr ptr)
			{
			}

			[PreserveSig]
			private static extern void StandardInput_BaseStream_Write(IntPtr ptr, IntPtr ptrArrBytes, int offset, int count);

			public void Write(byte[] arr, int offset, int count)
			{
			}

			public void Write(IntPtr arayrPointer, int offset, int count)
			{
			}

			[PreserveSig]
			private static extern void StandardInput_BaseStream_Flush(IntPtr ptr);

			public void Flush()
			{
			}

			[PreserveSig]
			private static extern void StandardInput_BaseStream_Close(IntPtr ptr);

			public void Close()
			{
			}
		}

		private IntPtr procPtr;

		public readonly FakeBaseStream BaseStream;

		[PreserveSig]
		private static extern void StandardInput_Close(IntPtr ptr);

		public void Close()
		{
		}

		public FakeStandardInput(IntPtr ptr)
		{
		}
	}
}
