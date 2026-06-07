using System;
using System.Runtime.CompilerServices;

namespace CTS.Core.Utilities
{
	public static class EnumExtensions
	{
		private unsafe static int ToInt32<TEnum>(this TEnum testEnum) where TEnum : unmanaged, Enum
		{
			if (sizeof(TEnum) == 4)
			{
				return *(int*)(&testEnum);
			}
			return 0;
		}

		public static bool HasMoreThanOne<TEnum>(this TEnum testEnum) where TEnum : unmanaged, Enum
		{
			switch (Unsafe.SizeOf<TEnum>())
			{
			case 1:
			{
				byte b = Unsafe.As<TEnum, byte>(ref testEnum);
				return (b & (b - 1)) != 0;
			}
			case 2:
			{
				ushort num3 = Unsafe.As<TEnum, ushort>(ref testEnum);
				return (num3 & (num3 - 1)) != 0;
			}
			case 4:
			{
				uint num2 = Unsafe.As<TEnum, uint>(ref testEnum);
				return (num2 & (num2 - 1)) != 0;
			}
			case 8:
			{
				ulong num = Unsafe.As<TEnum, ulong>(ref testEnum);
				return (num & (num - 1)) != 0;
			}
			default:
				throw new Exception("Size does not match a known Enum backing type.");
			}
		}

		public static bool ExistsInMask<TEnum>(this int value, TEnum testEnum) where TEnum : unmanaged, Enum
		{
			return (testEnum.ToInt32() & value) == value;
		}

		public static bool ExistsInMask(this int value, int mask)
		{
			return (mask & value) == value;
		}

		public static bool HasFlagNonAlloc<TEnum>(this TEnum lhs, TEnum flags) where TEnum : unmanaged, Enum
		{
			return Unsafe.SizeOf<TEnum>() switch
			{
				1 => (Unsafe.As<TEnum, byte>(ref lhs) & Unsafe.As<TEnum, byte>(ref flags)) != 0, 
				2 => (Unsafe.As<TEnum, ushort>(ref lhs) & Unsafe.As<TEnum, ushort>(ref flags)) != 0, 
				4 => (Unsafe.As<TEnum, uint>(ref lhs) & Unsafe.As<TEnum, uint>(ref flags)) != 0, 
				8 => (Unsafe.As<TEnum, ulong>(ref lhs) & Unsafe.As<TEnum, ulong>(ref flags)) != 0, 
				_ => throw new Exception("Size does not match a known Enum backing type."), 
			};
		}
	}
}
