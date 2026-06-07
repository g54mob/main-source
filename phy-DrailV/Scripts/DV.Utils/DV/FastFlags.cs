using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DV
{
	public static class FastFlags
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static bool HasByteFlag<T>(this T enumValue, T flag) where T : unmanaged, Enum
		{
			return (*(byte*)(&enumValue) & *(byte*)(&flag)) == *(byte*)(&flag);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static bool HasUShortFlag<T>(this T enumValue, T flag) where T : unmanaged, Enum
		{
			return (*(ushort*)(&enumValue) & *(ushort*)(&flag)) == *(ushort*)(&flag);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static bool HasIntFlag<T>(this T enumValue, T flag) where T : unmanaged, Enum
		{
			return (*(int*)(&enumValue) & *(int*)(&flag)) == *(int*)(&flag);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static bool HasUnknownFlag<T>(this T enumValue, T flag) where T : unmanaged, Enum
		{
			switch (sizeof(T))
			{
			case 1:
				return enumValue.HasByteFlag(flag);
			case 2:
				return enumValue.HasUShortFlag(flag);
			case 4:
				return enumValue.HasIntFlag(flag);
			default:
				throw new ArgumentException($"Unsupported underlying enum type size '{sizeof(T)}'", "enumValue");
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static bool HasAnyByteFlag<T>(this T enumValue, T flag) where T : unmanaged, Enum
		{
			return (*(byte*)(&enumValue) & *(byte*)(&flag)) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static bool HasAnyUShortFlag<T>(this T enumValue, T flag) where T : unmanaged, Enum
		{
			return (*(ushort*)(&enumValue) & *(ushort*)(&flag)) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static bool HasAnyIntFlag<T>(this T enumValue, T flag) where T : unmanaged, Enum
		{
			return (*(int*)(&enumValue) & *(int*)(&flag)) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static bool HasAnyFlag<T>(this T enumValue, T flag) where T : unmanaged, Enum
		{
			switch (sizeof(T))
			{
			case 1:
				return enumValue.HasAnyByteFlag(flag);
			case 2:
				return enumValue.HasAnyUShortFlag(flag);
			case 4:
				return enumValue.HasAnyIntFlag(flag);
			default:
				throw new ArgumentException($"Unsupported underlying enum type size '{sizeof(T)}'", "enumValue");
			}
		}

		public static string PrettyPrintFlags<T>(this T enumValue) where T : unmanaged, Enum
		{
			if (EqualityComparer<T>.Default.Equals(enumValue, default(T)))
			{
				return Enum.GetName(typeof(T), default(T)) ?? "None";
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (T value in Enum.GetValues(typeof(T)))
			{
				if (!EqualityComparer<T>.Default.Equals(value, default(T)) && enumValue.HasUnknownFlag(value))
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(", ");
					}
					stringBuilder.Append(Enum.GetName(typeof(T), value));
				}
			}
			return stringBuilder.ToString();
		}
	}
}
