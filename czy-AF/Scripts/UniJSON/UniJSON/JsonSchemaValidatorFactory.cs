using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;

namespace UniJSON
{
	public static class JsonSchemaValidatorFactory
	{
		private struct JsonSchemaItem
		{
			public string Key;

			public JsonSchema Schema;

			public bool Required;

			public string[] Dependencies;
		}

		private static Dictionary<Type, ValueNodeType> s_typeMap = new Dictionary<Type, ValueNodeType>
		{
			{
				typeof(byte),
				ValueNodeType.Integer
			},
			{
				typeof(short),
				ValueNodeType.Integer
			},
			{
				typeof(int),
				ValueNodeType.Integer
			},
			{
				typeof(long),
				ValueNodeType.Integer
			},
			{
				typeof(sbyte),
				ValueNodeType.Integer
			},
			{
				typeof(ushort),
				ValueNodeType.Integer
			},
			{
				typeof(uint),
				ValueNodeType.Integer
			},
			{
				typeof(ulong),
				ValueNodeType.Integer
			},
			{
				typeof(float),
				ValueNodeType.Number
			},
			{
				typeof(double),
				ValueNodeType.Number
			},
			{
				typeof(string),
				ValueNodeType.String
			},
			{
				typeof(bool),
				ValueNodeType.Boolean
			},
			{
				typeof(Vector3),
				ValueNodeType.Object
			}
		};

		private static IEnumerable<JsonSchemaItem> GetProperties(Type t, PropertyExportFlags exportFlags)
		{
			FieldInfo[] fields = t.GetFields();
			foreach (FieldInfo fieldInfo in fields)
			{
				JsonSchemaAttribute jsonSchemaAttribute = fieldInfo.GetCustomAttributes(typeof(JsonSchemaAttribute), inherit: true).FirstOrDefault() as JsonSchemaAttribute;
				if (jsonSchemaAttribute == null)
				{
					jsonSchemaAttribute = fieldInfo.FieldType.GetCustomAttributes(typeof(JsonSchemaAttribute), inherit: true).FirstOrDefault() as JsonSchemaAttribute;
					if (jsonSchemaAttribute == null && !fieldInfo.IsStatic && fieldInfo.IsPublic)
					{
						jsonSchemaAttribute = new JsonSchemaAttribute();
					}
				}
				ItemJsonSchemaAttribute ia = fieldInfo.GetCustomAttributes(typeof(ItemJsonSchemaAttribute), inherit: true).FirstOrDefault() as ItemJsonSchemaAttribute;
				if (jsonSchemaAttribute != null)
				{
					yield return new JsonSchemaItem
					{
						Key = fieldInfo.Name,
						Schema = JsonSchema.FromType(fieldInfo.FieldType, jsonSchemaAttribute, ia),
						Required = jsonSchemaAttribute.Required,
						Dependencies = jsonSchemaAttribute.Dependencies
					};
				}
			}
			PropertyInfo[] properties = t.GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				JsonSchemaAttribute jsonSchemaAttribute2 = propertyInfo.GetCustomAttributes(typeof(JsonSchemaAttribute), inherit: true).FirstOrDefault() as JsonSchemaAttribute;
				ItemJsonSchemaAttribute ia2 = propertyInfo.GetCustomAttributes(typeof(ItemJsonSchemaAttribute), inherit: true).FirstOrDefault() as ItemJsonSchemaAttribute;
				if (jsonSchemaAttribute2 != null)
				{
					yield return new JsonSchemaItem
					{
						Key = propertyInfo.Name,
						Schema = JsonSchema.FromType(propertyInfo.PropertyType, jsonSchemaAttribute2, ia2),
						Required = jsonSchemaAttribute2.Required,
						Dependencies = jsonSchemaAttribute2.Dependencies
					};
				}
			}
		}

		public static IJsonSchemaValidator Create(ValueNodeType valueType, Type t = null, BaseJsonSchemaAttribute a = null, ItemJsonSchemaAttribute ia = null)
		{
			switch (valueType)
			{
			case ValueNodeType.Integer:
			{
				JsonIntValidator jsonIntValidator = new JsonIntValidator();
				if (a != null)
				{
					if (!double.IsNaN(a.Minimum))
					{
						jsonIntValidator.Minimum = (int)a.Minimum;
					}
					if (a.ExclusiveMinimum)
					{
						jsonIntValidator.ExclusiveMinimum = a.ExclusiveMinimum;
					}
					if (!double.IsNaN(a.Maximum))
					{
						jsonIntValidator.Maximum = (int)a.Maximum;
					}
					if (a.ExclusiveMaximum)
					{
						jsonIntValidator.ExclusiveMaximum = a.ExclusiveMaximum;
					}
					if (a.MultipleOf != 0.0)
					{
						jsonIntValidator.MultipleOf = (int)a.MultipleOf;
					}
				}
				return jsonIntValidator;
			}
			case ValueNodeType.Number:
			{
				JsonNumberValidator jsonNumberValidator = new JsonNumberValidator();
				if (a != null)
				{
					if (!double.IsNaN(a.Minimum))
					{
						jsonNumberValidator.Minimum = (int)a.Minimum;
					}
					if (a.ExclusiveMinimum)
					{
						jsonNumberValidator.ExclusiveMinimum = a.ExclusiveMinimum;
					}
					if (!double.IsNaN(a.Maximum))
					{
						jsonNumberValidator.Maximum = (int)a.Maximum;
					}
					if (a.ExclusiveMaximum)
					{
						jsonNumberValidator.ExclusiveMaximum = a.ExclusiveMaximum;
					}
					if (a.MultipleOf != 0.0)
					{
						jsonNumberValidator.MultipleOf = (int)a.MultipleOf;
					}
				}
				return jsonNumberValidator;
			}
			case ValueNodeType.String:
			{
				JsonStringValidator jsonStringValidator = new JsonStringValidator();
				if (a != null && a.Pattern != null)
				{
					jsonStringValidator.Pattern = new Regex(a.Pattern);
				}
				return jsonStringValidator;
			}
			case ValueNodeType.Boolean:
				return new JsonBoolValidator();
			case ValueNodeType.Array:
			{
				JsonArrayValidator jsonArrayValidator = new JsonArrayValidator();
				if (a != null)
				{
					if (a.MinItems != 0)
					{
						jsonArrayValidator.MinItems = a.MinItems;
					}
					if (a.MaxItems != 0)
					{
						jsonArrayValidator.MaxItems = a.MaxItems;
					}
					if (t != null)
					{
						if (ia == null)
						{
							ia = new ItemJsonSchemaAttribute();
						}
						Type type = null;
						if (t.IsArray)
						{
							type = t.GetElementType();
						}
						else if (t.GetIsGenericList())
						{
							type = t.GetGenericArguments().First();
						}
						if (type != null)
						{
							JsonSchema items = JsonSchema.FromType(type, ia);
							jsonArrayValidator.Items = items;
						}
					}
				}
				return jsonArrayValidator;
			}
			case ValueNodeType.Object:
			{
				if (t.GetIsGenericDictionary())
				{
					return typeof(JsonDictionaryValidator).GetMethod("Create", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(t.GetGenericArguments()[1]).Invoke(null, null) as IJsonSchemaValidator;
				}
				JsonObjectValidator jsonObjectValidator = new JsonObjectValidator();
				if (a != null)
				{
					if (a.MinProperties > 0)
					{
						jsonObjectValidator.MinProperties = a.MinProperties;
					}
					foreach (JsonSchemaItem property in GetProperties(t, a.ExportFlags))
					{
						jsonObjectValidator.Properties.Add(property.Key, property.Schema);
						if (property.Required)
						{
							jsonObjectValidator.Required.Add(property.Key);
						}
						if (property.Dependencies != null)
						{
							jsonObjectValidator.Dependencies.Add(property.Key, property.Dependencies);
						}
					}
				}
				if (ia != null)
				{
					JsonSchema additionalProperties = new JsonSchema
					{
						SkipComparison = ia.SkipSchemaComparison,
						Validator = Create(typeof(object), ia, null)
					};
					jsonObjectValidator.AdditionalProperties = additionalProperties;
				}
				return jsonObjectValidator;
			}
			default:
				throw new NotImplementedException();
			}
		}

		public static IJsonSchemaValidator Create(string t)
		{
			return Create((ValueNodeType)Enum.Parse(typeof(ValueNodeType), t, ignoreCase: true));
		}

		private static ValueNodeType ToJsonType(Type t)
		{
			if (s_typeMap.TryGetValue(t, out var value))
			{
				return value;
			}
			if (t.IsArray)
			{
				return ValueNodeType.Array;
			}
			if (t.GetIsGenericList())
			{
				return ValueNodeType.Array;
			}
			return ValueNodeType.Object;
		}

		public static IJsonSchemaValidator Create(Type t, BaseJsonSchemaAttribute a, ItemJsonSchemaAttribute ia)
		{
			return Create(ToJsonType(t), t, a, ia);
		}
	}
}
