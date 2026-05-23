using System;
using System.Linq;
using NJsonSchema.Annotations;
using Namotion.Reflection;

namespace NJsonSchema.Generation
{
	public class DefaultSchemaNameGenerator : ISchemaNameGenerator
	{
		public virtual string Generate(Type type)
		{
			CachedType cachedType = type.ToCachedType();
			JsonSchemaAttribute inheritedAttribute = cachedType.GetInheritedAttribute<JsonSchemaAttribute>();
			if (!string.IsNullOrEmpty(inheritedAttribute?.Name))
			{
				return inheritedAttribute.Name;
			}
			CachedType cachedType2 = type.ToCachedType();
			if (cachedType2.Type.IsConstructedGenericType)
			{
				return GetName(cachedType2).Split(new char[1] { '`' }).First() + "Of" + string.Join("And", cachedType2.GenericArguments.Select((CachedType a) => Generate(a.OriginalType)));
			}
			return GetName(cachedType2);
		}

		private static string GetName(CachedType cType)
		{
			if (!(cType.TypeName == "Int16"))
			{
				if (!(cType.TypeName == "Int32"))
				{
					if (!(cType.TypeName == "Int64"))
					{
						return GetNullableDisplayName(cType, cType.TypeName);
					}
					return GetNullableDisplayName(cType, "Long");
				}
				return GetNullableDisplayName(cType, "Integer");
			}
			return GetNullableDisplayName(cType, "Short");
		}

		private static string GetNullableDisplayName(CachedType type, string actual)
		{
			return (type.IsNullableType ? "Nullable" : "") + actual;
		}
	}
}
