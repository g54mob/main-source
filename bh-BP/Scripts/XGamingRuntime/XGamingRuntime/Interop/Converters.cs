using System;

namespace XGamingRuntime.Interop
{
	public static class Converters
	{
		public static IntPtr Offset(this IntPtr ptr, long that)
		{
			return (IntPtr)0;
		}

		public static int GetSizeRequiredToEncodeStringToUTF8(string str)
		{
			return 0;
		}

		public static DisposableBuffer StringArrayToUTF8StringArray(string[] strings)
		{
			return null;
		}

		public static IntPtr StringArrayToUTF8StringArray(string[] strings, DisposableCollection disposableCollection, out SizeT count)
		{
			count = default(SizeT);
			return (IntPtr)0;
		}

		public static byte[] StringToNullTerminatedUTF8ByteArray(string str)
		{
			return null;
		}

		public static byte[] StringToNullTerminatedUTF8ByteArray(string str, int requiredByteArrayLength)
		{
			return null;
		}

		private static byte[] StringToNullTerminatedUTF8ByteArrayInternal(string str, int requiredByteArrayLength)
		{
			return null;
		}

		public unsafe static void StringToNullTerminatedUTF8FixedPointer(string str, byte* bytePointer, int length)
		{
		}

		public unsafe static string BytePointerToString(byte* bytePointer, int length)
		{
			return null;
		}

		public unsafe static string NullTerminatedBytePointerToString(byte* bytePointer)
		{
			return null;
		}

		public static string ByteArrayToString(byte[] arr)
		{
			return null;
		}

		public static string ByteArrayToString(byte[] arr, int index, int count)
		{
			return null;
		}

		public static string PtrToStringUTF8(IntPtr rawPtr)
		{
			return null;
		}

		public static ClassType PtrToClass<ClassType, InteropStructType>(IntPtr rawPtr, Func<InteropStructType, ClassType> ctor) where ClassType : class where InteropStructType : struct
		{
			return null;
		}

		public static ClassType[] PtrToClassArray<ClassType, InteropStructType>(IntPtr rawPtr, SizeT count, Func<InteropStructType, ClassType> ctor)
		{
			return null;
		}

		public static ClassType[] PtrToClassArray<ClassType, InteropStructType>(IntPtr rawPtr, uint count, Func<InteropStructType, ClassType> ctor)
		{
			return null;
		}

		public static IntPtr ClassArrayToPtr<ClassType, InteropStructType>(ClassType[] inputTypes, Func<ClassType, DisposableCollection, InteropStructType> converter, DisposableCollection disposableCollection, out uint arrayCount)
		{
			arrayCount = default(uint);
			return (IntPtr)0;
		}

		public static IntPtr ClassArrayToPtr<ClassType, InteropStructType>(ClassType[] inputTypes, Func<ClassType, DisposableCollection, InteropStructType> converter, DisposableCollection disposableCollection, out SizeT arrayCount)
		{
			arrayCount = default(SizeT);
			return (IntPtr)0;
		}

		public static InteropStructType[] ConvertArrayToFixedLength<ClassType, InteropStructType>(ClassType[] classes, int length, Func<ClassType, InteropStructType> ctor)
		{
			return null;
		}
	}
}
