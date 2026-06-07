using System;
using System.Linq;
using Namotion.Reflection;

namespace NJsonSchema.Infrastructure
{
	public static class XmlObjectExtension
	{
		public static void GenerateXmlObjectForType(this JsonSchema schema, Type type)
		{
			Attribute[] inheritedAttributes = type.ToCachedType().InheritedAttributes;
			if (inheritedAttributes.Any())
			{
				dynamic val = inheritedAttributes.FirstAssignableToTypeNameOrDefault("System.Xml.Serialization.XmlTypeAttribute");
				if (val != null)
				{
					XmlObjectExtension.GenerateXmlObject(val.TypeName, val.Namespace, false, false, schema);
				}
			}
		}

		public static void GenerateXmlObjectForArrayType(this JsonSchema schema)
		{
			if (schema.IsArray && schema.ParentSchema == null)
			{
				GenerateXmlObject("ArrayOf" + schema.Item.Xml.Name, null, wrapped: true, isAttribute: false, schema);
			}
		}

		public static void GenerateXmlObjectForItemType(this JsonSchema schema, CachedType type)
		{
			Attribute[] inheritedAttributes = type.InheritedAttributes;
			dynamic val = inheritedAttributes.FirstAssignableToTypeNameOrDefault("System.Xml.Serialization.XmlTypeAttribute");
			string name = GetXmlItemName(type.OriginalType);
			if (val != null)
			{
				name = val.TypeName;
			}
			GenerateXmlObject(name, null, wrapped: false, isAttribute: false, schema);
		}

		public static void GenerateXmlObjectForProperty(this JsonSchemaProperty propertySchema, ContextualType type, string propertyName)
		{
			string text = null;
			string text2 = null;
			bool flag = false;
			if (propertySchema.IsArray)
			{
				dynamic val = type.Attributes.FirstAssignableToTypeNameOrDefault("System.Xml.Serialization.XmlArrayAttribute");
				if (val != null)
				{
					text = val.ElementName;
					text2 = val.Namespace;
				}
				dynamic val2 = type.Attributes.FirstAssignableToTypeNameOrDefault("System.Xml.Serialization.XmlArrayItemAttribute");
				if (val2 != null)
				{
					dynamic val3 = val2.ElementName;
					dynamic val4 = val2.Namespace;
					XmlObjectExtension.GenerateXmlObject(val3, val4, true, false, propertySchema.Item);
				}
				flag = true;
			}
			dynamic val5 = type.Attributes.FirstAssignableToTypeNameOrDefault("System.Xml.Serialization.XmlElementAttribute");
			if (val5 != null)
			{
				text = val5.ElementName;
				text2 = val5.Namespace;
			}
			dynamic val6 = type.Attributes.FirstAssignableToTypeNameOrDefault("System.Xml.Serialization.XmlAttributeAttribute");
			if (val6 != null)
			{
				if ((!string.IsNullOrEmpty(val6.AttributeName)))
				{
					text = val6.AttributeName;
				}
				if ((!string.IsNullOrEmpty(val6.Namespace)))
				{
					text2 = val6.Namespace;
				}
			}
			if (string.IsNullOrEmpty(text) && propertySchema.Type == JsonObjectType.None)
			{
				dynamic val7 = type.InheritedAttributes.FirstAssignableToTypeNameOrDefault("System.Xml.Serialization.XmlTypeAttribute");
				if (val7 != null)
				{
					text = propertyName;
				}
			}
			if (!string.IsNullOrEmpty(text) || flag)
			{
				GenerateXmlObject(text, text2, flag, (val6 != null) ? true : false, propertySchema);
			}
		}

		private static void GenerateXmlObject(string name, string @namespace, bool wrapped, bool isAttribute, JsonSchema schema)
		{
			schema.Xml = new JsonXmlObject
			{
				Name = name,
				Wrapped = wrapped,
				Namespace = @namespace,
				ParentSchema = schema,
				Attribute = isAttribute
			};
		}

		private static string GetXmlItemName(Type type)
		{
			if (type == typeof(int))
			{
				return "int";
			}
			if (type == typeof(string))
			{
				return "string";
			}
			if (type == typeof(double))
			{
				return "double";
			}
			if (type == typeof(decimal))
			{
				return "decimal";
			}
			return type.Name;
		}
	}
}
