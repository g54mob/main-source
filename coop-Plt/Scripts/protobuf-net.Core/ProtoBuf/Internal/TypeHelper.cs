using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;

namespace ProtoBuf.Internal
{
	internal static class TypeHelper
	{
		internal static string NormalizeName(this Type type)
		{
			return type?.ToString();
		}

		internal static bool CanBePacked(Type type)
		{
			if (type.IsEnum)
			{
				return true;
			}
			TypeCode typeCode = Type.GetTypeCode(type);
			if ((uint)(typeCode - 3) <= 11u)
			{
				return true;
			}
			return false;
		}

		[Obsolete("Prefer list provider")]
		internal static bool ResolveUniqueEnumerableT(Type type, out Type t)
		{
			if ((object)type == null || type == typeof(string) || type == typeof(byte[]) || type == typeof(object))
			{
				t = null;
				return false;
			}
			if (type.IsArray)
			{
				t = type.GetElementType();
				return type == t.MakeArrayType();
			}
			bool flag = false;
			t = null;
			try
			{
				if (IsEnumerableT(type, out t))
				{
					return true;
				}
				Type[] interfaces = type.GetInterfaces();
				foreach (Type type2 in interfaces)
				{
					if (IsEnumerableT(type2, out var t2))
					{
						if (flag && t2 != t)
						{
							flag = false;
							break;
						}
						flag = true;
						t = t2;
					}
				}
			}
			catch
			{
			}
			if (flag)
			{
				return true;
			}
			t = null;
			return false;
			static bool IsEnumerableT(Type type3, out Type reference)
			{
				if (type3.IsInterface && type3.IsGenericType && type3.GetGenericTypeDefinition() == typeof(IEnumerable<>))
				{
					reference = type3.GetGenericArguments()[0];
					return true;
				}
				reference = null;
				return false;
			}
		}

		internal static object GetValueTypeChecker(Type type)
		{
			Type type2 = Nullable.GetUnderlyingType(type) ?? type;
			return typeof(StructValueChecker<>).MakeGenericType(type2).GetField("Instance").GetValue(null);
		}
	}
	internal static class TypeHelper<T>
	{
		public static readonly bool IsReferenceType = !typeof(T).IsValueType;

		public static readonly bool CanBeNull = default(T) == null;

		public static readonly IValueChecker<T> ValueChecker = (SerializerCache<PrimaryTypeProvider>.InstanceField as IValueChecker<T>) ?? (ReferenceValueChecker.Instance as IValueChecker<T>) ?? ((IValueChecker<T>)TypeHelper.GetValueTypeChecker(typeof(T)));

		public static readonly bool CanBePacked = !CanBeNull && TypeHelper.CanBePacked(typeof(T));

		public static readonly T Default = ((typeof(T) == typeof(string)) ? ((T)(object)"") : default(T));

		public static readonly Func<ISerializationContext, T> Factory = (ISerializationContext ctx) => TypeModel.CreateInstance<T>(ctx);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T FromObject(object value)
		{
			if (value != null)
			{
				return (T)value;
			}
			return default(T);
		}
	}
}
