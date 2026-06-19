using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace XGamingRuntime.Interop
{
	internal static class Converters
	{
		internal static IntPtr Offset(this IntPtr ptr, long that)
		{
			return new IntPtr(ptr.ToInt64() + that);
		}

		internal static DisposableBuffer StringArrayToUTF8StringArray(string[] strings)
		{
			if (strings == null)
			{
				return new DisposableBuffer();
			}
			List<byte[]> list = new List<byte[]>(strings.Length);
			int num = 0;
			for (int i = 0; i < strings.Length; i++)
			{
				byte[] array = StringToNullTerminatedUTF8ByteArray(strings[i]);
				list.Add(array);
				if (array != null)
				{
					num = checked(num + array.Length);
				}
			}
			int num2 = Marshal.SizeOf(typeof(IntPtr));
			checked
			{
				int num3 = num2 * strings.Length;
				num += num3;
				DisposableBuffer disposableBuffer = new DisposableBuffer(num);
				IntPtr ptr = disposableBuffer.IntPtr;
				IntPtr intPtr = ptr.Offset(num3);
				foreach (byte[] item in list)
				{
					if (item != null)
					{
						Marshal.WriteIntPtr(ptr, intPtr);
						Marshal.Copy(item, 0, intPtr, item.Length);
						intPtr = intPtr.Offset(item.Length);
					}
					else
					{
						Marshal.WriteIntPtr(ptr, IntPtr.Zero);
					}
					ptr = ptr.Offset(num2);
				}
				return disposableBuffer;
			}
		}

		internal static IntPtr StringArrayToUTF8StringArray(string[] strings, DisposableCollection disposableCollection, out SizeT count)
		{
			if (strings == null)
			{
				count = new SizeT(0);
				return IntPtr.Zero;
			}
			count = new SizeT(strings.Length);
			return disposableCollection.Add(StringArrayToUTF8StringArray(strings)).IntPtr;
		}

		internal static byte[] StringToNullTerminatedUTF8ByteArray(string str)
		{
			return StringToNullTerminatedUTF8ByteArrayInternal(str, -1);
		}

		internal static byte[] StringToNullTerminatedUTF8ByteArray(string str, int requiredByteArrayLength)
		{
			return StringToNullTerminatedUTF8ByteArrayInternal(str, requiredByteArrayLength);
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

		internal unsafe static void StringToNullTerminatedUTF8FixedPointer(string str, byte* bytePointer, int length)
		{
			Marshal.Copy(StringToNullTerminatedUTF8ByteArray(str, length), 0, (IntPtr)bytePointer, length);
		}

		internal unsafe static string BytePointerToString(byte* bytePointer, int length)
		{
			byte[] array = new byte[length];
			Marshal.Copy((IntPtr)bytePointer, array, 0, length);
			return ByteArrayToString(array);
		}

		internal static string ByteArrayToString(byte[] arr)
		{
			string text = Encoding.UTF8.GetString(arr);
			int num = text.IndexOf('\0');
			if (num < 0)
			{
				return text;
			}
			return text.Substring(0, num);
		}

		internal static string ByteArrayToString(byte[] arr, int index, int count)
		{
			return Encoding.UTF8.GetString(arr, index, count).TrimEnd(default(char));
		}

		internal static string PtrToStringUTF8(IntPtr rawPtr)
		{
			if (rawPtr == IntPtr.Zero)
			{
				return null;
			}
			List<byte> list = new List<byte>();
			while (true)
			{
				byte b = Marshal.ReadByte(rawPtr);
				if (b == 0)
				{
					break;
				}
				list.Add(b);
				rawPtr = rawPtr.Offset(1L);
			}
			return Encoding.UTF8.GetString(list.ToArray());
		}

		internal static ClassType PtrToClass<ClassType, InteropStructType>(IntPtr rawPtr, Func<InteropStructType, ClassType> ctor) where ClassType : class where InteropStructType : struct
		{
			if (rawPtr == IntPtr.Zero)
			{
				return null;
			}
			return ctor((InteropStructType)Marshal.PtrToStructure(rawPtr, typeof(InteropStructType)));
		}

		internal static ClassType[] PtrToClassArray<ClassType, InteropStructType>(IntPtr rawPtr, SizeT count, Func<InteropStructType, ClassType> ctor)
		{
			return PtrToClassArray(rawPtr, count.ToUInt32(), ctor);
		}

		internal static ClassType[] PtrToClassArray<ClassType, InteropStructType>(IntPtr rawPtr, uint count, Func<InteropStructType, ClassType> ctor)
		{
			ClassType[] array = new ClassType[count];
			if (IntPtr.Zero != rawPtr)
			{
				int num = Marshal.SizeOf(typeof(InteropStructType));
				for (int i = 0; i < count; i++)
				{
					InteropStructType arg = (InteropStructType)Marshal.PtrToStructure(rawPtr.Offset(i * num), typeof(InteropStructType));
					array[i] = ctor(arg);
				}
			}
			return array;
		}

		public static IntPtr ClassArrayToPtr<ClassType, InteropStructType>(ClassType[] inputTypes, Func<ClassType, DisposableCollection, InteropStructType> converter, DisposableCollection disposableCollection, out SizeT arrayCount)
		{
			if (inputTypes == null)
			{
				arrayCount = new SizeT(0);
				return IntPtr.Zero;
			}
			bool isEnum = typeof(InteropStructType).IsEnum;
			int num = Marshal.SizeOf(isEnum ? Enum.GetUnderlyingType(typeof(InteropStructType)) : typeof(InteropStructType));
			DisposableBuffer disposableBuffer = disposableCollection.Add(new DisposableBuffer(checked(num * inputTypes.Length)));
			IntPtr ptr = disposableBuffer.IntPtr;
			foreach (ClassType arg in inputTypes)
			{
				Marshal.StructureToPtr(isEnum ? Convert.ChangeType(converter(arg, disposableCollection), Enum.GetUnderlyingType(typeof(InteropStructType))) : ((object)converter(arg, disposableCollection)), ptr, fDeleteOld: false);
				ptr = ptr.Offset(num);
			}
			arrayCount = new SizeT(inputTypes.Length);
			return disposableBuffer.IntPtr;
		}

		public static InteropStructType[] ConvertArrayToFixedLength<ClassType, InteropStructType>(ClassType[] classes, int length, Func<ClassType, InteropStructType> ctor)
		{
			InteropStructType[] array = new InteropStructType[length];
			int num = Math.Min(length, classes.Length);
			for (int i = 0; i < num; i++)
			{
				array[i] = ctor(classes[i]);
			}
			return array;
		}
	}
}
