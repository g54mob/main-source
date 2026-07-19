using System;
using System.Runtime.InteropServices;

namespace UniGLTF
{
	public static class ArrayExtensions
	{
		public static int MarshalCopyTo<T>(this ArraySegment<byte> src, T[] dst) where T : struct
		{
			int num = dst.Length * Marshal.SizeOf(typeof(T));
			using Pin<T> pin = Pin.Create(dst);
			Marshal.Copy(src.Array, src.Offset, pin.Ptr, num);
			return num;
		}

		public static byte[] ToArray(this ArraySegment<byte> src)
		{
			byte[] array = new byte[src.Count];
			Array.Copy(src.Array, src.Offset, array, 0, src.Count);
			return array;
		}

		public static T[] SelectInplace<T>(this T[] src, Func<T, T> pred)
		{
			for (int i = 0; i < src.Length; i++)
			{
				src[i] = pred(src[i]);
			}
			return src;
		}

		public static void Copy<TFrom, TTo>(ArraySegment<TFrom> src, ArraySegment<TTo> dst) where TFrom : struct where TTo : struct
		{
			byte[] array = new byte[src.Count * Marshal.SizeOf(typeof(TFrom))];
			using (Pin<TFrom> pin = Pin.Create(src))
			{
				Marshal.Copy(pin.Ptr, array, 0, array.Length);
			}
			using Pin<TTo> pin2 = Pin.Create(dst);
			Marshal.Copy(array, 0, pin2.Ptr, array.Length);
		}
	}
}
