using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using NJsonSchema.Annotations;
using Namotion.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace NJsonSchema.Generation
{
	public class DefaultReflectionService : IReflectionService
	{
		public JsonTypeDescription GetDescription(ContextualType contextualType, JsonSchemaGeneratorSettings settings)
		{
			return GetDescription(contextualType, settings.DefaultReferenceTypeNullHandling, settings);
		}

		public virtual JsonTypeDescription GetDescription(ContextualType contextualType, ReferenceTypeNullHandling defaultReferenceTypeNullHandling, JsonSchemaGeneratorSettings settings)
		{
			Type type = contextualType.OriginalType;
			bool isNullable = IsNullable(contextualType, defaultReferenceTypeNullHandling);
			JsonSchemaTypeAttribute attribute = contextualType.GetAttribute<JsonSchemaTypeAttribute>();
			if (attribute != null)
			{
				type = attribute.Type;
				contextualType = type.ToContextualType();
				if (attribute.IsNullableRaw.HasValue)
				{
					isNullable = attribute.IsNullableRaw.Value;
				}
			}
			JsonSchemaAttribute attribute2 = contextualType.GetAttribute<JsonSchemaAttribute>();
			if (attribute2 != null)
			{
				JsonObjectType jsonType = ((attribute2.Type != JsonObjectType.None) ? attribute2.Type : JsonObjectType.Object);
				string format = ((!string.IsNullOrEmpty(attribute2.Format)) ? attribute2.Format : null);
				return JsonTypeDescription.Create(contextualType, jsonType, isNullable, format);
			}
			if (type.GetTypeInfo().IsEnum)
			{
				bool flag = IsStringEnum(contextualType, settings.ActualSerializerSettings);
				return JsonTypeDescription.CreateForEnumeration(contextualType, flag ? JsonObjectType.String : JsonObjectType.Integer, isNullable: false);
			}
			if (type == typeof(short) || type == typeof(uint) || type == typeof(ushort))
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.Integer, isNullable: false, null);
			}
			if (type == typeof(int))
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.Integer, isNullable: false, "int32");
			}
			if (type == typeof(long) || type == typeof(ulong))
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.Integer, isNullable: false, "int64");
			}
			if (type == typeof(double))
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.Number, isNullable: false, "double");
			}
			if (type == typeof(float))
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.Number, isNullable: false, "float");
			}
			if (type == typeof(decimal))
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.Number, isNullable: false, "decimal");
			}
			if (type == typeof(bool))
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.Boolean, isNullable: false, null);
			}
			if (type == typeof(string) || type == typeof(Type))
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.String, isNullable, null);
			}
			if (type == typeof(char))
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.String, isNullable: false, null);
			}
			if (type == typeof(Guid))
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.String, isNullable: false, "guid");
			}
			if (type == typeof(DateTime) || type == typeof(DateTimeOffset) || type.FullName == "NodaTime.OffsetDateTime" || type.FullName == "NodaTime.LocalDateTime" || type.FullName == "NodaTime.ZonedDateTime" || type.FullName == "NodaTime.Instant")
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.String, isNullable: false, "date-time");
			}
			if (type == typeof(TimeSpan) || type.FullName == "NodaTime.Duration")
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.String, isNullable: false, "duration");
			}
			if (type.FullName == "NodaTime.LocalDate" || type.FullName == "System.DateOnly")
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.String, isNullable: false, "date");
			}
			if (type.FullName == "NodaTime.LocalTime" || type.FullName == "System.TimeOnly")
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.String, isNullable: false, "time");
			}
			if (type == typeof(Uri))
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.String, isNullable, "uri");
			}
			if (type == typeof(byte))
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.Integer, isNullable: false, "byte");
			}
			if (type == typeof(byte[]))
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.String, isNullable, "byte");
			}
			if (type.IsAssignableToTypeName("JArray", TypeNameStyle.Name))
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.Array, isNullable, null);
			}
			if (type.IsAssignableToTypeName("JToken", TypeNameStyle.Name) || type.FullName == "System.Dynamic.ExpandoObject" || type.FullName == "System.Text.Json.JsonElement" || type == typeof(object))
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.None, isNullable, null);
			}
			if (IsBinary(contextualType))
			{
				if (settings.SchemaType == SchemaType.Swagger2)
				{
					return JsonTypeDescription.Create(contextualType, JsonObjectType.File, isNullable, null);
				}
				return JsonTypeDescription.Create(contextualType, JsonObjectType.String, isNullable, "binary");
			}
			if (contextualType.IsNullableType)
			{
				JsonTypeDescription description = GetDescription(contextualType.OriginalGenericArguments[0], defaultReferenceTypeNullHandling, settings);
				description.IsNullable = true;
				return description;
			}
			JsonContract jsonContract = settings.ResolveContract(type);
			if (IsDictionaryType(contextualType) && jsonContract is JsonDictionaryContract)
			{
				return JsonTypeDescription.CreateForDictionary(contextualType, JsonObjectType.Object, isNullable);
			}
			if (IsIAsyncEnumerableType(contextualType) || (IsArrayType(contextualType) && jsonContract is JsonArrayContract))
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.Array, isNullable, null);
			}
			if (jsonContract is JsonStringContract)
			{
				return JsonTypeDescription.Create(contextualType, JsonObjectType.String, isNullable, null);
			}
			return JsonTypeDescription.Create(contextualType, JsonObjectType.Object, isNullable, null);
		}

		public virtual bool IsNullable(ContextualType contextualType, ReferenceTypeNullHandling defaultReferenceTypeNullHandling)
		{
			JsonPropertyAttribute contextAttribute = contextualType.GetContextAttribute<JsonPropertyAttribute>();
			if (contextAttribute != null && contextAttribute.Required == Required.DisallowNull)
			{
				return false;
			}
			if (contextualType.ContextAttributes.FirstAssignableToTypeNameOrDefault("NotNullAttribute", TypeNameStyle.Name) != null)
			{
				return false;
			}
			if (contextualType.ContextAttributes.FirstAssignableToTypeNameOrDefault("CanBeNullAttribute", TypeNameStyle.Name) != null)
			{
				return true;
			}
			if (contextualType.Nullability != Nullability.Unknown)
			{
				return contextualType.Nullability == Nullability.Nullable;
			}
			if (!(contextualType.Type != typeof(string)) || !contextualType.TypeInfo.IsValueType)
			{
				return defaultReferenceTypeNullHandling != ReferenceTypeNullHandling.NotNull;
			}
			return false;
		}

		public virtual bool IsStringEnum(ContextualType contextualType, JsonSerializerSettings serializerSettings)
		{
			if (!contextualType.TypeInfo.IsEnum)
			{
				return false;
			}
			if (!serializerSettings.Converters.OfType<StringEnumConverter>().Any())
			{
				return HasStringEnumConverter(contextualType);
			}
			return true;
		}

		protected virtual bool IsBinary(ContextualType contextualType)
		{
			string typeName = contextualType.TypeName;
			if (!(typeName == "IFormFile") && !contextualType.IsAssignableToTypeName("HttpPostedFile", TypeNameStyle.Name) && !contextualType.IsAssignableToTypeName("HttpPostedFileBase", TypeNameStyle.Name))
			{
				return contextualType.TypeInfo.ImplementedInterfaces.Any((Type i) => i.Name == "IFormFile");
			}
			return true;
		}

		private bool IsIAsyncEnumerableType(ContextualType contextualType)
		{
			return contextualType.TypeName == "IAsyncEnumerable`1";
		}

		protected virtual bool IsArrayType(ContextualType contextualType)
		{
			if (IsDictionaryType(contextualType))
			{
				return false;
			}
			if (contextualType.TypeName == "ObservableCollection`1")
			{
				return true;
			}
			if (!contextualType.Type.IsArray)
			{
				if (contextualType.TypeInfo.ImplementedInterfaces.Contains(typeof(IEnumerable)))
				{
					if (!(contextualType.TypeInfo.BaseType == null))
					{
						return !contextualType.TypeInfo.BaseType.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IEnumerable));
					}
					return true;
				}
				return false;
			}
			return true;
		}

		protected virtual bool IsDictionaryType(ContextualType contextualType)
		{
			if (contextualType.TypeName == "IDictionary`2" || contextualType.TypeName == "IReadOnlyDictionary`2")
			{
				return true;
			}
			if (contextualType.TypeInfo.ImplementedInterfaces.Contains(typeof(IDictionary)))
			{
				if (!(contextualType.TypeInfo.BaseType == null))
				{
					return !contextualType.TypeInfo.BaseType.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IDictionary));
				}
				return true;
			}
			return false;
		}

		private bool HasStringEnumConverter(ContextualType contextualType)
		{
			dynamic val = contextualType.Attributes?.FirstOrDefault((Attribute a) => a.GetType().Name == "JsonConverterAttribute");
			if (val != null && ObjectExtensions.HasProperty(val, "ConverterType"))
			{
				Type type = (Type)val.ConverterType;
				if (type != null)
				{
					if (!type.IsAssignableToTypeName("StringEnumConverter", TypeNameStyle.Name))
					{
						return type.IsAssignableToTypeName("System.Text.Json.Serialization.JsonStringEnumConverter", TypeNameStyle.FullName);
					}
					return true;
				}
			}
			return false;
		}
	}
}
