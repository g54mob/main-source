using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using ProtoBuf.Compiler;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	internal sealed class RepeatedSerializerStub
	{
		internal static readonly RepeatedSerializerStub Empty = new RepeatedSerializerStub(null, null);

		private object _serializer;

		public MemberInfo Provider { get; }

		public bool IsMap { get; }

		public bool IsEmpty => (object)Provider == null;

		public object Serializer => _serializer ?? CreateSerializer();

		public Type ForType { get; }

		public Type ItemType { get; }

		internal bool IsValidProtobufMap(RuntimeTypeModel model, CompatibilityLevel compatibilityLevel, DataFormat dataFormat)
		{
			if (!IsMap)
			{
				return false;
			}
			ResolveMapTypes(out var keyType, out var valueType);
			if (!IsValidKey(keyType, compatibilityLevel, dataFormat))
			{
				return false;
			}
			RepeatedSerializerStub repeatedSerializerStub = ((model == null) ? RepeatedSerializers.TryGetRepeatedProvider(valueType) : model.TryGetRepeatedProvider(valueType));
			if (repeatedSerializerStub != null)
			{
				return false;
			}
			return true;
			static bool IsValidKey(Type type, CompatibilityLevel compatibilityLevel2, DataFormat dataFormat2)
			{
				if ((object)type == null)
				{
					return false;
				}
				if (type.IsEnum)
				{
					return true;
				}
				if (type == typeof(string))
				{
					return true;
				}
				if (!type.IsValueType)
				{
					return false;
				}
				if ((object)Nullable.GetUnderlyingType(type) != null)
				{
					return false;
				}
				TypeCode typeCode = Type.GetTypeCode(type);
				if ((uint)(typeCode - 5) <= 7u)
				{
					return true;
				}
				if (compatibilityLevel2 >= CompatibilityLevel.Level300 && type == typeof(Guid) && dataFormat2 != DataFormat.FixedSize)
				{
					return true;
				}
				return false;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private object CreateSerializer()
		{
			try
			{
				MemberInfo underlyingProvider = RuntimeTypeModel.GetUnderlyingProvider(Provider, ForType);
				object serializer;
				if (!(underlyingProvider is FieldInfo fieldInfo))
				{
					if (!(underlyingProvider is MethodInfo methodInfo) || !methodInfo.IsStatic)
					{
						goto IL_004d;
					}
					serializer = methodInfo.Invoke(null, null);
				}
				else
				{
					if (!fieldInfo.IsStatic)
					{
						goto IL_004d;
					}
					serializer = fieldInfo.GetValue(null);
				}
				goto IL_004f;
				IL_004d:
				serializer = null;
				goto IL_004f;
				IL_004f:
				_serializer = serializer;
				return _serializer;
			}
			catch (TargetInvocationException ex) when (ex.InnerException != null)
			{
				throw ex.InnerException;
			}
		}

		internal void EmitProvider(CompilerContext ctx)
		{
			EmitProvider(ctx.IL);
		}

		private void EmitProvider(ILGenerator il)
		{
			MemberInfo underlyingProvider = RuntimeTypeModel.GetUnderlyingProvider(Provider, ForType);
			RuntimeTypeModel.EmitProvider(underlyingProvider, il);
		}

		public static RepeatedSerializerStub Create(Type forType, MemberInfo provider)
		{
			if ((object)provider != null)
			{
				return new RepeatedSerializerStub(forType, provider);
			}
			return Empty;
		}

		private RepeatedSerializerStub(Type forType, MemberInfo provider)
		{
			ForType = forType;
			Provider = provider;
			IsMap = CheckIsMap(provider, out var itemType);
			ItemType = itemType;
		}

		private static bool CheckIsMap(MemberInfo provider, out Type itemType)
		{
			Type type = ((provider is MethodInfo methodInfo) ? methodInfo.ReturnType : ((provider is FieldInfo fieldInfo) ? fieldInfo.FieldType : ((provider is PropertyInfo propertyInfo) ? propertyInfo.PropertyType : ((!(provider is Type type2)) ? null : type2))));
			Type type3 = type;
			while ((object)type3 != null && type3 != typeof(object))
			{
				if (type3.IsGenericType)
				{
					Type genericTypeDefinition = type3.GetGenericTypeDefinition();
					if (genericTypeDefinition == typeof(MapSerializer<, , >))
					{
						Type[] genericArguments = type3.GetGenericArguments();
						itemType = typeof(KeyValuePair<, >).MakeGenericType(genericArguments[1], genericArguments[2]);
						return true;
					}
					if (genericTypeDefinition == typeof(RepeatedSerializer<, >))
					{
						Type[] genericArguments2 = type3.GetGenericArguments();
						itemType = genericArguments2[1];
						return false;
					}
				}
				type3 = type3.BaseType;
			}
			itemType = null;
			return false;
		}

		internal void ResolveMapTypes(out Type keyType, out Type valueType)
		{
			keyType = (valueType = null);
			if (IsMap)
			{
				Type[] genericArguments = ItemType.GetGenericArguments();
				keyType = genericArguments[0];
				valueType = genericArguments[1];
			}
		}
	}
}
