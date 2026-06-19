using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;

namespace Pug.ECS.Serialization.DOTS100
{
	public class TypeHash
	{
		private const ulong kFNV1A64OffsetBasis = 14695981039346656037uL;

		private const ulong kFNV1A64Prime = 1099511628211uL;

		private static readonly Type[] WorkaroundTypes = new Type[1] { typeof(Guid) };

		public static ulong FNV1A64(string text)
		{
			ulong num = 14695981039346656037uL;
			foreach (char c in text)
			{
				num = 1099511628211L * (num ^ (byte)(c & 0xFF));
				num = 1099511628211L * (num ^ (byte)((int)c >> 8));
			}
			return num;
		}

		public static ulong FNV1A64<T>(T text) where T : unmanaged, INativeList<byte>, IUTF8Bytes
		{
			ulong num = 14695981039346656037uL;
			for (int i = 0; i < text.Length; i++)
			{
				byte b = text[i];
				num = 1099511628211L * (num ^ (byte)(b & 0xFF));
				num = 1099511628211L * (num ^ (byte)(b >> 8));
			}
			return num;
		}

		public static ulong FNV1A64(int val)
		{
			ulong num = 14695981039346656037uL;
			num = ((ulong)(val & 0xFF) ^ num) * 1099511628211L;
			num = (((ulong)(val & 0xFF00) >> 8) ^ num) * 1099511628211L;
			num = (((ulong)(val & 0xFF0000) >> 16) ^ num) * 1099511628211L;
			return (((ulong)(val & 0xFF000000u) >> 24) ^ num) * 1099511628211L;
		}

		public static ulong CombineFNV1A64(ulong hash, ulong value)
		{
			hash ^= value;
			hash *= 1099511628211L;
			return hash;
		}

		private static ulong HashType(Type type, Dictionary<Type, ulong> cache)
		{
			ulong num = HashTypeName(type);
			Type unityEngineObjectType = TypeManager.UnityEngineObjectType;
			if ((object)unityEngineObjectType != null && unityEngineObjectType.IsAssignableFrom(type))
			{
				return CombineFNV1A64(num, FNV1A64(type.Assembly.GetName().Name));
			}
			if (type.IsGenericParameter || type.IsArray || type.IsPointer || type.IsPrimitive || type.IsEnum || WorkaroundTypes.Contains(type))
			{
				return num;
			}
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (!fieldInfo.IsStatic)
				{
					Type fieldType = fieldInfo.FieldType;
					if (!cache.TryGetValue(fieldType, out var value))
					{
						cache.Add(fieldType, HashTypeName(fieldType));
						value = (cache[fieldType] = HashType(fieldType, cache));
					}
					IEnumerable<Attribute> customAttributes = fieldInfo.GetCustomAttributes(typeof(FieldOffsetAttribute));
					if (customAttributes.Any())
					{
						int value2 = ((FieldOffsetAttribute)customAttributes.First()).Value;
						num = CombineFNV1A64(num, (ulong)value2);
					}
					num = CombineFNV1A64(num, value);
				}
			}
			return num;
		}

		private static ulong HashVersionAttribute(Type type, IEnumerable<CustomAttributeData> customAttributes = null)
		{
			int val = 0;
			customAttributes = customAttributes ?? type.CustomAttributes;
			if (customAttributes.Any())
			{
				CustomAttributeData customAttributeData = customAttributes.FirstOrDefault((CustomAttributeData ca) => ca.Constructor.DeclaringType == typeof(TypeManager.TypeVersionAttribute));
				if (customAttributeData != null)
				{
					val = (int)customAttributeData.ConstructorArguments.First((CustomAttributeTypedArgument arg) => arg.ArgumentType.Name == "Int32").Value;
				}
			}
			return FNV1A64(val);
		}

		private static ulong HashNamespace(Type type)
		{
			ulong num = 14695981039346656037uL;
			if (type.IsNested)
			{
				num = CombineFNV1A64(num, HashNamespace(type.DeclaringType));
				num = CombineFNV1A64(num, FNV1A64(type.DeclaringType.Name));
			}
			else if (!string.IsNullOrEmpty(type.Namespace))
			{
				num = CombineFNV1A64(num, FNV1A64(type.Namespace));
			}
			return num;
		}

		private static ulong HashTypeName(Type type)
		{
			ulong hash = HashNamespace(type);
			hash = CombineFNV1A64(hash, FNV1A64(type.Name));
			Type[] genericTypeArguments = type.GenericTypeArguments;
			foreach (Type type2 in genericTypeArguments)
			{
				hash = CombineFNV1A64(hash, HashTypeName(type2));
			}
			return hash;
		}

		public static ulong CalculateStableTypeHash(Type type, IEnumerable<CustomAttributeData> customAttributes = null, Dictionary<Type, ulong> hashCache = null)
		{
			ulong hash = HashVersionAttribute(type, customAttributes);
			if (hashCache == null)
			{
				hashCache = new Dictionary<Type, ulong>();
			}
			ulong value = HashType(type, hashCache);
			return CombineFNV1A64(hash, value);
		}

		public static ulong CalculateMemoryOrdering(Type type, out bool hasCustomMemoryOrder, Dictionary<Type, ulong> hashCache = null)
		{
			hasCustomMemoryOrder = false;
			if (type == null || type.FullName == "Unity.Entities.Entity")
			{
				return 0uL;
			}
			IEnumerable<CustomAttributeData> customAttributes = type.CustomAttributes;
			if (customAttributes.Any())
			{
				CustomAttributeData customAttributeData = customAttributes.FirstOrDefault((CustomAttributeData ca) => ca.Constructor.DeclaringType == typeof(TypeManager.ForcedMemoryOrderingAttribute));
				if (customAttributeData != null)
				{
					hasCustomMemoryOrder = true;
					return (ulong)customAttributeData.ConstructorArguments.First((CustomAttributeTypedArgument arg) => arg.ArgumentType.Name == "UInt64" || arg.ArgumentType.Name == "ulong").Value;
				}
			}
			return CalculateStableTypeHash(type, customAttributes, hashCache);
		}
	}
}
