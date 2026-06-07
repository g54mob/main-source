using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace Muna.Beta
{
	internal static class ValueUtils
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static object ToObject<T>(this Stream stream, int[] shape) where T : unmanaged
		{
			T[] array = stream.ToArray<T>();
			if (shape.Length == 0)
			{
				return array[0];
			}
			return new Tensor<T>(array, shape);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static object ToObject(this Enum value)
		{
			if (!(value.GetType().GetField(value.ToString())?.GetCustomAttributes(typeof(EnumMemberAttribute), inherit: false)?.FirstOrDefault() is EnumMemberAttribute { IsValueSetExplicitly: not false } enumMemberAttribute))
			{
				return Convert.ToInt32(value);
			}
			return enumMemberAttribute.Value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static Stream ToStream<T>(this T[] data) where T : unmanaged
		{
			if (data is byte[] buffer)
			{
				return new MemoryStream(buffer);
			}
			byte[] array = new byte[data.Length * sizeof(T)];
			fixed (T* ptr = data)
			{
				void* source = ptr;
				fixed (byte* ptr2 = array)
				{
					void* destination = ptr2;
					Buffer.MemoryCopy(source, destination, array.Length, array.Length);
				}
			}
			return new MemoryStream(array);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Stream ToStream(this string data)
		{
			return new MemoryStream(Encoding.UTF8.GetBytes(data));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static T[] ToArray<T>(this Stream stream) where T : unmanaged
		{
			T[] array = new T[stream.Length / sizeof(T)];
			fixed (T* pointer = array)
			{
				using UnmanagedMemoryStream destination = new UnmanagedMemoryStream((byte*)pointer, stream.Length, stream.Length, FileAccess.Write);
				stream.CopyTo(destination);
			}
			return array;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Stream Clone(this Stream stream)
		{
			MemoryStream memoryStream = new MemoryStream();
			stream.CopyTo(memoryStream);
			return memoryStream;
		}
	}
}
