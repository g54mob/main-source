using System;
using System.IO;
using System.Reflection;
using ProtoBuf.Internal;

namespace ProtoBuf
{
	internal static class Helpers
	{
		internal static MethodInfo GetInstanceMethod(Type declaringType, string name)
		{
			return declaringType.GetMethod(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		}

		internal static MethodInfo GetStaticMethod(Type declaringType, string name)
		{
			return declaringType.GetMethod(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		internal static MethodInfo GetInstanceMethod(Type declaringType, string name, Type[] types)
		{
			if (types == null)
			{
				types = Type.EmptyTypes;
			}
			return declaringType.GetMethod(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, types, null);
		}

		internal static bool IsSubclassOf(Type type, Type baseClass)
		{
			return type.IsSubclassOf(baseClass);
		}

		public static ProtoTypeCode GetTypeCode(Type type)
		{
			TypeCode typeCode = Type.GetTypeCode(type);
			switch (typeCode)
			{
			case TypeCode.Empty:
			case TypeCode.Boolean:
			case TypeCode.Char:
			case TypeCode.SByte:
			case TypeCode.Byte:
			case TypeCode.Int16:
			case TypeCode.UInt16:
			case TypeCode.Int32:
			case TypeCode.UInt32:
			case TypeCode.Int64:
			case TypeCode.UInt64:
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Decimal:
			case TypeCode.DateTime:
			case TypeCode.String:
				return (ProtoTypeCode)typeCode;
			default:
				if (type == typeof(TimeSpan))
				{
					return ProtoTypeCode.TimeSpan;
				}
				if (type == typeof(Guid))
				{
					return ProtoTypeCode.Guid;
				}
				if (type == typeof(Uri))
				{
					return ProtoTypeCode.Uri;
				}
				if (type == typeof(byte[]))
				{
					return ProtoTypeCode.ByteArray;
				}
				if (type == typeof(ArraySegment<byte>))
				{
					return ProtoTypeCode.ByteArraySegment;
				}
				if (type == typeof(Memory<byte>))
				{
					return ProtoTypeCode.ByteMemory;
				}
				if (type == typeof(ReadOnlyMemory<byte>))
				{
					return ProtoTypeCode.ByteReadOnlyMemory;
				}
				if (type == typeof(Type))
				{
					return ProtoTypeCode.Type;
				}
				if (type == typeof(IntPtr))
				{
					return ProtoTypeCode.IntPtr;
				}
				if (type == typeof(UIntPtr))
				{
					return ProtoTypeCode.UIntPtr;
				}
				return ProtoTypeCode.Unknown;
			}
		}

		internal static MethodInfo GetGetMethod(PropertyInfo property, bool nonPublic, bool allowInternal)
		{
			if ((object)property == null)
			{
				return null;
			}
			MethodInfo methodInfo = property.GetGetMethod(nonPublic);
			if ((object)methodInfo == null && !nonPublic && allowInternal)
			{
				methodInfo = property.GetGetMethod(nonPublic: true);
				if ((object)methodInfo != null && !methodInfo.IsAssembly && !methodInfo.IsFamilyOrAssembly)
				{
					methodInfo = null;
				}
			}
			return methodInfo;
		}

		internal static MethodInfo GetSetMethod(PropertyInfo property, bool nonPublic, bool allowInternal)
		{
			if ((object)property == null)
			{
				return null;
			}
			MethodInfo methodInfo = property.GetSetMethod(nonPublic);
			if ((object)methodInfo == null && !nonPublic && allowInternal)
			{
				methodInfo = property.GetSetMethod(nonPublic: true);
				if ((object)methodInfo != null && !methodInfo.IsAssembly && !methodInfo.IsFamilyOrAssembly)
				{
					methodInfo = null;
				}
			}
			return methodInfo;
		}

		internal static ConstructorInfo GetConstructor(Type type, Type[] parameterTypes, bool nonPublic)
		{
			return type.GetConstructor(nonPublic ? (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) : (BindingFlags.Instance | BindingFlags.Public), null, parameterTypes, null);
		}

		internal static ConstructorInfo[] GetConstructors(Type type, bool nonPublic)
		{
			return type.GetConstructors(nonPublic ? (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) : (BindingFlags.Instance | BindingFlags.Public));
		}

		internal static void GetBuffer(MemoryStream stream, out ArraySegment<byte> segment)
		{
			if (stream == null || !stream.TryGetBuffer(out segment))
			{
				ThrowHelper.ThrowInvalidOperationException("Unable to obtain buffer from MemoryStream");
				segment = default(ArraySegment<byte>);
			}
		}

		internal static PropertyInfo GetProperty(Type type, string name, bool nonPublic)
		{
			return type.GetProperty(name, nonPublic ? (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) : (BindingFlags.Instance | BindingFlags.Public));
		}

		internal static MemberInfo[] GetInstanceFieldsAndProperties(Type type, bool publicOnly)
		{
			BindingFlags bindingAttr = (publicOnly ? (BindingFlags.Instance | BindingFlags.Public) : (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			PropertyInfo[] properties = type.GetProperties(bindingAttr);
			FieldInfo[] fields = type.GetFields(bindingAttr);
			MemberInfo[] array = new MemberInfo[fields.Length + properties.Length];
			properties.CopyTo(array, 0);
			fields.CopyTo(array, properties.Length);
			return array;
		}

		internal static Type GetMemberType(MemberInfo member)
		{
			return member.MemberType switch
			{
				MemberTypes.Field => ((FieldInfo)member).FieldType, 
				MemberTypes.Property => ((PropertyInfo)member).PropertyType, 
				_ => null, 
			};
		}
	}
}
