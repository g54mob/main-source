using System.Runtime.CompilerServices;

namespace NJsonSchema
{
	internal static class EnumExtensions
	{
		private const MethodImplOptions OptionAggressiveInlining = MethodImplOptions.AggressiveInlining;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsNull(this JsonObjectType type)
		{
			return (type & JsonObjectType.Null) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsNumber(this JsonObjectType type)
		{
			return (type & JsonObjectType.Number) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsObject(this JsonObjectType type)
		{
			return (type & JsonObjectType.Object) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsArray(this JsonObjectType type)
		{
			return (type & JsonObjectType.Array) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsInteger(this JsonObjectType type)
		{
			return (type & JsonObjectType.Integer) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsString(this JsonObjectType type)
		{
			return (type & JsonObjectType.String) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsBoolean(this JsonObjectType type)
		{
			return (type & JsonObjectType.Boolean) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsFile(this JsonObjectType type)
		{
			return (type & JsonObjectType.File) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsNone(this JsonObjectType type)
		{
			return type == JsonObjectType.None;
		}
	}
}
