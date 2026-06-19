using System;
using System.Runtime.InteropServices;
using System.Text;

namespace PlayFab.Multiplayer.InteropWrapper
{
	internal struct UTF8StringPtr
	{
		private IntPtr pointer;

		public unsafe sbyte* Pointer => (sbyte*)pointer.ToPointer();

		public UTF8StringPtr(string str, DisposableCollection disposableCollection)
		{
			if (str == null)
			{
				pointer = IntPtr.Zero;
				return;
			}
			byte[] array = StringToNullTerminatedUTF8ByteArray(str);
			DisposableBuffer disposableBuffer = new DisposableBuffer(array.Length);
			Marshal.Copy(array, 0, disposableBuffer.IntPtr, array.Length);
			disposableCollection.Add(disposableBuffer);
			pointer = disposableBuffer.IntPtr;
		}

		public string GetString()
		{
			if (pointer == IntPtr.Zero)
			{
				return null;
			}
			return Converters.PtrToStringUTF8(pointer);
		}

		internal static byte[] StringToNullTerminatedUTF8ByteArray(string str)
		{
			return StringToNullTerminatedUTF8ByteArrayInternal(str, -1);
		}

		private static byte[] StringToNullTerminatedUTF8ByteArrayInternal(string str, int requiredByteArrayLength)
		{
			if (str == null)
			{
				return null;
			}
			if (requiredByteArrayLength == -1)
			{
				return Encoding.UTF8.GetBytes(str + "\0");
			}
			byte[] array = new byte[requiredByteArrayLength];
			Encoding.UTF8.GetBytes(str + "\0", 0, str.Length + 1, array, 0);
			return array;
		}
	}
}
