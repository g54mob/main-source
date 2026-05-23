using System.Collections.Generic;
using System.Linq;
using NJsonSchema.Generation.TypeMappers;
using Namotion.Reflection;

namespace NJsonSchema.Generation
{
	public class JsonTypeDescription
	{
		public ContextualType ContextualType { get; }

		public JsonObjectType Type { get; private set; }

		public bool IsDictionary { get; private set; }

		public bool IsEnum { get; private set; }

		public string Format { get; private set; }

		public bool IsNullable { get; set; }

		public bool IsComplexType
		{
			get
			{
				if (!IsDictionary && !Type.IsObject())
				{
					return Type.IsArray();
				}
				return true;
			}
		}

		public bool IsAny => Type == JsonObjectType.None;

		private JsonTypeDescription(ContextualType type, JsonObjectType jsonType, bool isNullable)
		{
			ContextualType = type;
			Type = jsonType;
			IsNullable = isNullable;
		}

		public static JsonTypeDescription Create(ContextualType type, JsonObjectType jsonType, bool isNullable, string format)
		{
			return new JsonTypeDescription(type, jsonType, isNullable)
			{
				Format = format
			};
		}

		public static JsonTypeDescription CreateForDictionary(ContextualType type, JsonObjectType jsonType, bool isNullable)
		{
			return new JsonTypeDescription(type, jsonType, isNullable)
			{
				IsDictionary = true
			};
		}

		public static JsonTypeDescription CreateForEnumeration(ContextualType type, JsonObjectType jsonType, bool isNullable)
		{
			return new JsonTypeDescription(type, jsonType, isNullable)
			{
				IsEnum = true
			};
		}

		public bool RequiresSchemaReference(IEnumerable<ITypeMapper> typeMappers)
		{
			ITypeMapper typeMapper = typeMappers.FirstOrDefault((ITypeMapper m) => m.MappedType == ContextualType.OriginalType);
			if (typeMapper != null)
			{
				return typeMapper.UseReference;
			}
			if (!IsDictionary)
			{
				if (!Type.IsObject())
				{
					return IsEnum;
				}
				return true;
			}
			return false;
		}

		public void ApplyType(JsonSchema schema)
		{
			schema.Type = Type;
			schema.Format = Format;
		}
	}
}
