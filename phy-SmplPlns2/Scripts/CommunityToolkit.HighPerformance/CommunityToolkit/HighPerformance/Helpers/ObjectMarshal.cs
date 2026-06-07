using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CommunityToolkit.HighPerformance.Helpers
{
	public static class ObjectMarshal
	{
		[StructLayout(LayoutKind.Explicit)]
		private sealed class RawObjectData
		{
			[FieldOffset(0)]
			public byte Data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IntPtr DangerousGetObjectDataByteOffset<T>(object obj, ref T data)
		{
			return Unsafe.ByteOffset(ref Unsafe.As<RawObjectData>(obj).Data, ref Unsafe.As<T, byte>(ref data));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T DangerousGetObjectDataReferenceAt<T>(object obj, IntPtr offset)
		{
			return ref Unsafe.As<byte, T>(ref Unsafe.AddByteOffset(ref Unsafe.As<RawObjectData>(obj).Data, offset));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryUnbox<T>(this object obj, out T value) where T : struct
		{
			if (obj.GetType() == typeof(T))
			{
				value = Unsafe.Unbox<T>(obj);
				return true;
			}
			value = default(T);
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T DangerousUnbox<T>(object obj) where T : struct
		{
			return ref Unsafe.Unbox<T>(obj);
		}
	}
}
