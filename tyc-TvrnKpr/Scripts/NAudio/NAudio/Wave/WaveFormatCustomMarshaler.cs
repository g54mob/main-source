using System;
using System.Runtime.InteropServices;

namespace NAudio.Wave
{
	public sealed class WaveFormatCustomMarshaler : ICustomMarshaler
	{
		private static WaveFormatCustomMarshaler marshaler;

		public static ICustomMarshaler GetInstance(string cookie)
		{
			return null;
		}

		public void CleanUpManagedData(object ManagedObj)
		{
		}

		public void CleanUpNativeData(IntPtr pNativeData)
		{
		}

		public int GetNativeDataSize()
		{
			return 0;
		}

		public IntPtr MarshalManagedToNative(object ManagedObj)
		{
			return (IntPtr)0;
		}

		public object MarshalNativeToManaged(IntPtr pNativeData)
		{
			return null;
		}
	}
}
