using System;
using System.Reflection;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	internal static class EnumSerializers
	{
		internal static object GetSerializer(Type type)
		{
			MemberInfo underlyingProvider = RuntimeTypeModel.GetUnderlyingProvider(GetProvider(type), type);
			if (!(underlyingProvider is FieldInfo fieldInfo))
			{
				if (underlyingProvider is MethodInfo methodInfo)
				{
					return methodInfo.Invoke(null, null);
				}
				return null;
			}
			return fieldInfo.GetValue(null);
		}

		internal static MemberInfo GetProvider(Type type)
		{
			if ((object)type == null)
			{
				return null;
			}
			type = Nullable.GetUnderlyingType(type) ?? type;
			if (!type.IsEnum)
			{
				return null;
			}
			string text = Type.GetTypeCode(type) switch
			{
				TypeCode.SByte => "CreateSByte", 
				TypeCode.Int16 => "CreateInt16", 
				TypeCode.Int32 => "CreateInt32", 
				TypeCode.Int64 => "CreateInt64", 
				TypeCode.Byte => "CreateByte", 
				TypeCode.UInt16 => "CreateUInt16", 
				TypeCode.UInt32 => "CreateUInt32", 
				TypeCode.UInt64 => "CreateUInt64", 
				_ => null, 
			};
			if (text == null)
			{
				return null;
			}
			return typeof(EnumSerializer).GetMethod(text, BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(type);
		}
	}
}
