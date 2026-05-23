using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using NJsonSchema.Annotations;
using NJsonSchema.Converters;
using NJsonSchema.Generation.TypeMappers;
using NJsonSchema.Infrastructure;
using Namotion.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace NJsonSchema.Generation
{
	public class JsonSchemaGenerator
	{
		private static readonly Dictionary<string, string> DataTypeFormats = new Dictionary<string, string>
		{
			{ "DateTime", "date-time" },
			{ "Date", "date" },
			{ "Time", "time" },
			{ "EmailAddress", "email" },
			{ "PhoneNumber", "phone" },
			{ "Url", "uri" }
		};

		public JsonSchemaGeneratorSettings Settings { get; }

		public JsonSchemaGenerator(JsonSchemaGeneratorSettings settings)
		{
			Settings = settings;
		}

		public JsonSchema Generate(Type type)
		{
			JsonSchema jsonSchema = new JsonSchema();
			JsonSchemaResolver schemaResolver = new JsonSchemaResolver(jsonSchema, Settings);
			Generate(jsonSchema, type.ToContextualType(), schemaResolver);
			return jsonSchema;
		}

		public JsonSchema Generate(Type type, JsonSchemaResolver schemaResolver)
		{
			return Generate<JsonSchema>(type, schemaResolver);
		}

		public TSchemaType Generate<TSchemaType>(Type type, JsonSchemaResolver schemaResolver) where TSchemaType : JsonSchema, new()
		{
			return Generate<TSchemaType>(type.ToContextualType(), schemaResolver);
		}

		public JsonSchema Generate(ContextualType contextualType, JsonSchemaResolver schemaResolver)
		{
			return Generate<JsonSchema>(contextualType, schemaResolver);
		}

		public TSchemaType Generate<TSchemaType>(ContextualType contextualType, JsonSchemaResolver schemaResolver) where TSchemaType : JsonSchema, new()
		{
			TSchemaType val = new TSchemaType();
			Generate(val, contextualType, schemaResolver);
			return val;
		}

		public void Generate<TSchemaType>(TSchemaType schema, Type type, JsonSchemaResolver schemaResolver) where TSchemaType : JsonSchema, new()
		{
			Generate(schema, type.ToContextualType(), schemaResolver);
		}

		public virtual void Generate<TSchemaType>(TSchemaType schema, ContextualType contextualType, JsonSchemaResolver schemaResolver) where TSchemaType : JsonSchema, new()
		{
			JsonTypeDescription description = Settings.ReflectionService.GetDescription(contextualType, Settings);
			ApplyTypeExtensionDataAttributes(schema, contextualType);
			if (TryHandleSpecialTypes(schema, description.ContextualType, schemaResolver))
			{
				ApplySchemaProcessors(schema, description.ContextualType, schemaResolver);
				return;
			}
			if (schemaResolver.RootObject == schema)
			{
				schema.Title = Settings.SchemaNameGenerator.Generate(description.ContextualType.OriginalType);
			}
			if (description.Type.IsObject())
			{
				if (description.IsDictionary)
				{
					GenerateDictionary(schema, description, schemaResolver);
				}
				else if (schemaResolver.HasSchema(description.ContextualType.OriginalType, isIntegerEnumeration: false))
				{
					schema.Reference = schemaResolver.GetSchema(description.ContextualType.OriginalType, isIntegerEnumeration: false);
				}
				else if (schema.GetType() == typeof(JsonSchema))
				{
					GenerateObject(schema, description, schemaResolver);
				}
				else
				{
					schema.Reference = Generate(description.ContextualType, schemaResolver);
				}
			}
			else if (description.IsEnum)
			{
				GenerateEnum(schema, description, schemaResolver);
			}
			else if (description.Type.IsArray())
			{
				GenerateArray(schema, description, schemaResolver);
			}
			else
			{
				description.ApplyType(schema);
			}
			if (contextualType != description.ContextualType)
			{
				ApplySchemaProcessors(schema, description.ContextualType, schemaResolver);
			}
			ApplySchemaProcessors(schema, contextualType, schemaResolver);
		}

		public TSchemaType GenerateWithReference<TSchemaType>(ContextualType contextualType, JsonSchemaResolver schemaResolver, Action<TSchemaType, JsonSchema> transformation = null) where TSchemaType : JsonSchema, new()
		{
			return GenerateWithReferenceAndNullability(contextualType, isNullable: false, schemaResolver, transformation);
		}

		public TSchemaType GenerateWithReferenceAndNullability<TSchemaType>(ContextualType contextualType, JsonSchemaResolver schemaResolver, Action<TSchemaType, JsonSchema> transformation = null) where TSchemaType : JsonSchema, new()
		{
			JsonTypeDescription description = Settings.ReflectionService.GetDescription(contextualType, Settings);
			return GenerateWithReferenceAndNullability(contextualType, description.IsNullable, schemaResolver, transformation);
		}

		public virtual TSchemaType GenerateWithReferenceAndNullability<TSchemaType>(ContextualType contextualType, bool isNullable, JsonSchemaResolver schemaResolver, Action<TSchemaType, JsonSchema> transformation = null) where TSchemaType : JsonSchema, new()
		{
			JsonTypeDescription description = Settings.ReflectionService.GetDescription(contextualType, Settings);
			JsonSchema jsonSchema;
			if (!description.RequiresSchemaReference(Settings.TypeMappers))
			{
				TSchemaType val = Generate<TSchemaType>(description.ContextualType, schemaResolver);
				if (!val.HasReference)
				{
					transformation?.Invoke(val, val);
					if (isNullable)
					{
						if (Settings.SchemaType == SchemaType.JsonSchema)
						{
							if (val.Type == JsonObjectType.None)
							{
								val._oneOf.Add(new JsonSchema
								{
									Type = JsonObjectType.None
								});
								val._oneOf.Add(new JsonSchema
								{
									Type = JsonObjectType.Null
								});
							}
							else
							{
								val.Type |= JsonObjectType.Null;
							}
						}
						else if (Settings.SchemaType == SchemaType.OpenApi3 || Settings.GenerateCustomNullableProperties)
						{
							val.IsNullableRaw = isNullable;
						}
					}
					return val;
				}
				jsonSchema = val.ActualSchema;
			}
			else
			{
				jsonSchema = Generate<JsonSchema>(description.ContextualType, schemaResolver);
			}
			TSchemaType val2 = new TSchemaType();
			transformation?.Invoke(val2, jsonSchema);
			if (isNullable)
			{
				if (Settings.SchemaType == SchemaType.JsonSchema)
				{
					val2._oneOf.Add(new JsonSchema
					{
						Type = JsonObjectType.Null
					});
				}
				else if (Settings.SchemaType == SchemaType.OpenApi3 || Settings.GenerateCustomNullableProperties)
				{
					val2.IsNullableRaw = true;
				}
			}
			if ((Settings.AllowReferencesWithProperties || !JsonConvert.DeserializeObject<JObject>(JsonConvert.SerializeObject(val2)).Properties().Any()) && val2._oneOf.Count == 0)
			{
				val2.Reference = jsonSchema.ActualSchema;
			}
			else if (Settings.SchemaType != SchemaType.Swagger2)
			{
				val2._oneOf.Add(new JsonSchema
				{
					Reference = jsonSchema.ActualSchema
				});
			}
			else
			{
				val2._allOf.Add(new JsonSchema
				{
					Reference = jsonSchema.ActualSchema
				});
			}
			return val2;
		}

		public virtual string GetPropertyName(JsonProperty jsonProperty, ContextualAccessorInfo accessorInfo)
		{
			if (jsonProperty != null && jsonProperty.PropertyName != null)
			{
				return jsonProperty.PropertyName;
			}
			try
			{
				string name = accessorInfo.GetName();
				return (Settings.ActualContractResolver is DefaultContractResolver defaultContractResolver) ? defaultContractResolver.GetResolvedPropertyName(name) : name;
			}
			catch (Exception innerException)
			{
				throw new InvalidOperationException("Could not get JSON property name of property '" + ((accessorInfo != null) ? accessorInfo.Name : "n/a") + "' and type '" + ((accessorInfo?.MemberInfo?.DeclaringType != null) ? accessorInfo.MemberInfo.DeclaringType.FullName : "n/a") + "'.", innerException);
			}
		}

		public virtual void ApplyDataAnnotations(JsonSchema schema, JsonTypeDescription typeDescription)
		{
			ContextualType contextualType = typeDescription.ContextualType;
			dynamic val = contextualType.ContextAttributes.FirstAssignableToTypeNameOrDefault("System.ComponentModel.DataAnnotations.DisplayAttribute");
			if (val != null)
			{
				dynamic name = val.GetName();
				if (name != null)
				{
					schema.Title = name;
				}
			}
			dynamic val2 = contextualType.ContextAttributes.FirstAssignableToTypeNameOrDefault("System.ComponentModel.DefaultValueAttribute");
			if (val2 != null)
			{
				if (typeDescription.IsEnum && typeDescription.Type.IsString())
				{
					schema.Default = (object)val2.Value?.ToString();
				}
				else
				{
					schema.Default = (object)val2.Value;
				}
			}
			dynamic val3 = contextualType.ContextAttributes.FirstAssignableToTypeNameOrDefault("System.ComponentModel.DataAnnotations.RegularExpressionAttribute");
			if (val3 != null)
			{
				if (typeDescription.IsDictionary)
				{
					schema.AdditionalPropertiesSchema.Pattern = val3.Pattern;
				}
				else
				{
					schema.Pattern = val3.Pattern;
				}
			}
			if (typeDescription.Type == JsonObjectType.Number || typeDescription.Type == JsonObjectType.Integer)
			{
				ApplyRangeAttribute(schema, contextualType.ContextAttributes);
				MultipleOfAttribute multipleOfAttribute = contextualType.ContextAttributes.OfType<MultipleOfAttribute>().SingleOrDefault();
				if (multipleOfAttribute != null)
				{
					schema.MultipleOf = multipleOfAttribute.MultipleOf;
				}
			}
			dynamic val4 = contextualType.ContextAttributes.FirstAssignableToTypeNameOrDefault("System.ComponentModel.DataAnnotations.MinLengthAttribute");
			if (val4 != null && val4.Length != null)
			{
				if (typeDescription.Type == JsonObjectType.String)
				{
					schema.MinLength = val4.Length;
				}
				else if (typeDescription.Type == JsonObjectType.Array)
				{
					schema.MinItems = val4.Length;
				}
			}
			dynamic val5 = contextualType.ContextAttributes.FirstAssignableToTypeNameOrDefault("System.ComponentModel.DataAnnotations.MaxLengthAttribute");
			if (val5 != null && val5.Length != null)
			{
				if (typeDescription.Type == JsonObjectType.String)
				{
					schema.MaxLength = val5.Length;
				}
				else if (typeDescription.Type == JsonObjectType.Array)
				{
					schema.MaxItems = val5.Length;
				}
			}
			dynamic val6 = contextualType.ContextAttributes.FirstAssignableToTypeNameOrDefault("System.ComponentModel.DataAnnotations.StringLengthAttribute");
			if ((val6 != null) && typeDescription.Type == JsonObjectType.String)
			{
				schema.MinLength = val6.MinimumLength;
				schema.MaxLength = val6.MaximumLength;
			}
			dynamic val7 = contextualType.ContextAttributes.FirstAssignableToTypeNameOrDefault("System.ComponentModel.DataAnnotations.DataTypeAttribute");
			if (val7 != null)
			{
				dynamic val8 = val7.DataType.ToString();
				if (DataTypeFormats.ContainsKey(val8))
				{
					schema.Format = DataTypeFormats[val8];
				}
			}
		}

		public virtual object ConvertDefaultValue(ContextualType type, object defaultValue)
		{
			if (defaultValue != null && defaultValue.GetType().GetTypeInfo().IsEnum)
			{
				if (Settings.ReflectionService.IsStringEnum(type, Settings.ActualSerializerSettings))
				{
					return defaultValue.ToString();
				}
				return (int)defaultValue;
			}
			return defaultValue;
		}

		public virtual object GenerateExample(ContextualType type)
		{
			if (Settings.GenerateExamples && Settings.UseXmlDocumentation)
			{
				try
				{
					string xmlDocsTag = type.GetXmlDocsTag("example", Settings.GetXmlDocsOptions());
					return GenerateExample(xmlDocsTag);
				}
				catch
				{
					return null;
				}
			}
			return null;
		}

		public virtual object GenerateExample(ContextualAccessorInfo accessorInfo)
		{
			if (Settings.GenerateExamples && Settings.UseXmlDocumentation)
			{
				try
				{
					string xmlDocsTag = accessorInfo.GetXmlDocsTag("example", Settings.GetXmlDocsOptions());
					return GenerateExample(xmlDocsTag);
				}
				catch
				{
					return null;
				}
			}
			return null;
		}

		private object GenerateExample(string xmlDocs)
		{
			try
			{
				return (!string.IsNullOrEmpty(xmlDocs)) ? JsonConvert.DeserializeObject<JToken>(xmlDocs) : null;
			}
			catch
			{
				return xmlDocs;
			}
		}

		protected virtual void GenerateObject(JsonSchema schema, JsonTypeDescription typeDescription, JsonSchemaResolver schemaResolver)
		{
			Type type = typeDescription.ContextualType.Type;
			schemaResolver.AddSchema(type, isIntegerEnumeration: false, schema);
			JsonSchema schema2 = schema;
			JsonSchema jsonSchema = GenerateInheritance(typeDescription.ContextualType, schema, schemaResolver);
			if (jsonSchema != null)
			{
				schema = jsonSchema;
			}
			else
			{
				GenerateProperties(type, schema, schemaResolver);
				ApplyAdditionalProperties(schema, type, schemaResolver);
			}
			if (!schema.Type.IsArray())
			{
				typeDescription.ApplyType(schema);
			}
			schema.Description = type.ToCachedType().GetDescription(Settings);
			schema.Example = GenerateExample(type.ToContextualType());
			dynamic val = type.GetTypeInfo().GetCustomAttributes(inherit: false).FirstAssignableToTypeNameOrDefault("System.ObsoleteAttribute");
			if (val != null)
			{
				schema.IsDeprecated = true;
				schema.DeprecatedMessage = val.Message;
			}
			if (Settings.GetActualGenerateAbstractSchema(type))
			{
				schema.IsAbstract = type.GetTypeInfo().IsAbstract;
			}
			GenerateInheritanceDiscriminator(type, schema2, schema);
			GenerateKnownTypes(type, schemaResolver);
			if (Settings.GenerateXmlObjects)
			{
				schema.GenerateXmlObjectForType(type);
			}
		}

		protected virtual string[] GetTypeProperties(Type type)
		{
			if (type == typeof(Exception))
			{
				return new string[4] { "InnerException", "Message", "Source", "StackTrace" };
			}
			return null;
		}

		protected virtual void GenerateArray<TSchemaType>(TSchemaType schema, JsonTypeDescription typeDescription, JsonSchemaResolver schemaResolver) where TSchemaType : JsonSchema, new()
		{
			ContextualType contextualType = typeDescription.ContextualType;
			typeDescription.ApplyType(schema);
			ContextualType itemType = contextualType.GetInheritedAttribute<JsonSchemaAttribute>()?.ArrayItem.ToContextualType() ?? contextualType.EnumerableItemType ?? contextualType.GenericArguments.FirstOrDefault();
			if (itemType != null)
			{
				bool isNullable = contextualType.GetContextAttribute<ItemsCanBeNullAttribute>() != null || itemType.Nullability == Nullability.Nullable;
				schema.Item = GenerateWithReferenceAndNullability(itemType, isNullable, schemaResolver, delegate(JsonSchema itemSchema, JsonSchema typeSchema)
				{
					if (Settings.GenerateXmlObjects)
					{
						itemSchema.GenerateXmlObjectForItemType(itemType);
					}
				});
				if (Settings.GenerateXmlObjects)
				{
					schema.GenerateXmlObjectForArrayType();
				}
			}
			else
			{
				schema.Item = JsonSchema.CreateAnySchema();
			}
			dynamic val = contextualType.ContextAttributes.FirstAssignableToTypeNameOrDefault("MinLengthAttribute", TypeNameStyle.Name);
			if (val != null && ObjectExtensions.HasProperty(val, "Length"))
			{
				schema.MinItems = val.Length;
			}
			dynamic val2 = contextualType.ContextAttributes.FirstAssignableToTypeNameOrDefault("MaxLengthAttribute", TypeNameStyle.Name);
			if (val2 != null && ObjectExtensions.HasProperty(val2, "Length"))
			{
				schema.MaxItems = val2.Length;
			}
		}

		protected virtual void GenerateDictionary<TSchemaType>(TSchemaType schema, JsonTypeDescription typeDescription, JsonSchemaResolver schemaResolver) where TSchemaType : JsonSchema, new()
		{
			ContextualType contextualType = typeDescription.ContextualType;
			typeDescription.ApplyType(schema);
			ContextualType[] genericArguments = contextualType.GenericArguments;
			ContextualType contextualType2 = ((genericArguments.Length == 2) ? genericArguments[0] : typeof(string).ToContextualType());
			if (contextualType2.OriginalType.GetTypeInfo().IsEnum)
			{
				schema.DictionaryKey = GenerateWithReference<JsonSchema>(contextualType2, schemaResolver);
			}
			ContextualType contextualType3 = ((genericArguments.Length == 2) ? genericArguments[1] : typeof(object).ToContextualType());
			IEnumerable<JsonSchemaPatternPropertiesAttribute> enumerable = contextualType.ContextAttributes.OfType<JsonSchemaPatternPropertiesAttribute>();
			if (enumerable.Any())
			{
				schema.AllowAdditionalProperties = false;
				foreach (JsonSchemaPatternPropertiesAttribute item in enumerable)
				{
					JsonSchemaProperty value = GenerateDictionaryValueSchema<JsonSchemaProperty>(schemaResolver, item.Type?.ToContextualType() ?? contextualType3);
					schema.PatternProperties.Add(item.RegularExpression, value);
				}
			}
			else
			{
				schema.AdditionalPropertiesSchema = GenerateDictionaryValueSchema<JsonSchema>(schemaResolver, contextualType3);
				schema.AllowAdditionalProperties = true;
			}
			dynamic val = contextualType.ContextAttributes.FirstAssignableToTypeNameOrDefault("MinLengthAttribute", TypeNameStyle.Name);
			if (val != null && ObjectExtensions.HasProperty(val, "Length"))
			{
				schema.MinProperties = val.Length;
			}
			dynamic val2 = contextualType.ContextAttributes.FirstAssignableToTypeNameOrDefault("MaxLengthAttribute", TypeNameStyle.Name);
			if (val2 != null && ObjectExtensions.HasProperty(val2, "Length"))
			{
				schema.MaxProperties = val2.Length;
			}
		}

		protected virtual void GenerateEnum(JsonSchema schema, JsonTypeDescription typeDescription)
		{
			ContextualType contextualType = typeDescription.ContextualType;
			schema.Type = typeDescription.Type;
			schema.Enumeration.Clear();
			schema.EnumerationNames.Clear();
			schema.IsFlagEnumerable = contextualType.GetInheritedAttribute<FlagsAttribute>() != null;
			Type underlyingType = Enum.GetUnderlyingType(contextualType.Type);
			List<JsonConverter> list = Settings.ActualSerializerSettings.Converters.ToList();
			if (!list.OfType<StringEnumConverter>().Any())
			{
				list.Add(new StringEnumConverter());
			}
			string[] names = Enum.GetNames(contextualType.Type);
			foreach (string text in names)
			{
				if (typeDescription.Type == JsonObjectType.Integer)
				{
					object item = Convert.ChangeType(Enum.Parse(contextualType.Type, text), underlyingType);
					schema.Enumeration.Add(item);
				}
				else
				{
					IEnumerable<Attribute> customAttributes = contextualType.Type.GetRuntimeField(text).GetCustomAttributes();
					dynamic val = customAttributes.FirstAssignableToTypeNameOrDefault("System.Runtime.Serialization.EnumMemberAttribute");
					if (val != null && !string.IsNullOrEmpty(val.Value))
					{
						schema.Enumeration.Add((string)val.Value);
					}
					else
					{
						object value = Enum.Parse(contextualType.Type, text);
						string value2 = JsonConvert.SerializeObject(value, Formatting.None, list.ToArray());
						schema.Enumeration.Add(JsonConvert.DeserializeObject<string>(value2));
					}
				}
				schema.EnumerationNames.Add(text);
			}
			if (typeDescription.Type == JsonObjectType.Integer && Settings.GenerateEnumMappingDescription)
			{
				schema.Description = (schema.Description + "\n\n" + string.Join("\n", schema.Enumeration.Select((object e, int index) => e?.ToString() + " = " + schema.EnumerationNames[index]))).Trim();
			}
		}

		private TSchema GenerateDictionaryValueSchema<TSchema>(JsonSchemaResolver schemaResolver, ContextualType valueType) where TSchema : JsonSchema, new()
		{
			if (valueType.OriginalType == typeof(object))
			{
				TSchema val = new TSchema();
				if (Settings.SchemaType == SchemaType.Swagger2)
				{
					val.AllowAdditionalProperties = false;
				}
				return val;
			}
			JsonTypeDescription description = Settings.ReflectionService.GetDescription(valueType, Settings.DefaultDictionaryValueReferenceTypeNullHandling, Settings);
			bool isNullable = valueType.GetContextAttribute<ItemsCanBeNullAttribute>() != null || description.IsNullable;
			return GenerateWithReferenceAndNullability<TSchema>(valueType, isNullable, schemaResolver);
		}

		private void ApplyAdditionalProperties<TSchemaType>(TSchemaType schema, Type type, JsonSchemaResolver schemaResolver) where TSchemaType : JsonSchema, new()
		{
			ContextualPropertyInfo contextualPropertyInfo = type.GetContextualProperties().FirstOrDefault((ContextualPropertyInfo p) => p.ContextAttributes.Any((Attribute a) => a.GetType().IsAssignableToTypeName("JsonExtensionDataAttribute", TypeNameStyle.Name)));
			if (contextualPropertyInfo != null)
			{
				ContextualType[] genericArguments = contextualPropertyInfo.AccessorType.GenericArguments;
				ContextualType contextualType = ((genericArguments.Length == 2) ? genericArguments[1] : typeof(object).ToContextualType());
				schema.AdditionalPropertiesSchema = GenerateWithReferenceAndNullability<JsonSchema>(contextualType, schemaResolver);
			}
			else
			{
				schema.AllowAdditionalProperties = Settings.AlwaysAllowAdditionalObjectProperties;
			}
		}

		private void ApplySchemaProcessors(JsonSchema schema, ContextualType contextualType, JsonSchemaResolver schemaResolver)
		{
			SchemaProcessorContext schemaProcessorContext = new SchemaProcessorContext(contextualType, schema, schemaResolver, this, Settings);
			foreach (ISchemaProcessor schemaProcessor in Settings.SchemaProcessors)
			{
				schemaProcessor.Process(schemaProcessorContext);
			}
			IEnumerable<Attribute> assignableToTypeName = contextualType.InheritedAttributes.GetAssignableToTypeName("JsonSchemaProcessorAttribute", TypeNameStyle.Name);
			foreach (dynamic item in assignableToTypeName)
			{
				dynamic val = Activator.CreateInstance(item.Type, item.Parameters);
				val.Process(schemaProcessorContext);
			}
		}

		private bool TryHandleSpecialTypes<TSchemaType>(TSchemaType schema, ContextualType contextualType, JsonSchemaResolver schemaResolver) where TSchemaType : JsonSchema, new()
		{
			ITypeMapper typeMapper = Settings.TypeMappers.FirstOrDefault((ITypeMapper m) => m.MappedType == contextualType.OriginalType);
			if (typeMapper == null && contextualType.OriginalType.GetTypeInfo().IsGenericType)
			{
				Type genericType = contextualType.OriginalType.GetGenericTypeDefinition();
				typeMapper = Settings.TypeMappers.FirstOrDefault((ITypeMapper m) => m.MappedType == genericType);
			}
			if (typeMapper != null)
			{
				TypeMapperContext context = new TypeMapperContext(contextualType.OriginalType, this, schemaResolver, contextualType.ContextAttributes);
				typeMapper.GenerateSchema(schema, context);
				return true;
			}
			if (!contextualType.OriginalType.IsAssignableToTypeName("JArray", TypeNameStyle.Name) && (contextualType.OriginalType.IsAssignableToTypeName("JToken", TypeNameStyle.Name) || contextualType.OriginalType == typeof(object)))
			{
				if (Settings.SchemaType == SchemaType.Swagger2)
				{
					schema.AllowAdditionalProperties = false;
				}
				return true;
			}
			return false;
		}

		private void GenerateEnum<TSchemaType>(TSchemaType schema, JsonTypeDescription typeDescription, JsonSchemaResolver schemaResolver) where TSchemaType : JsonSchema, new()
		{
			Type type = typeDescription.ContextualType.Type;
			bool isIntegerEnumeration = typeDescription.Type == JsonObjectType.Integer;
			if (schemaResolver.HasSchema(type, isIntegerEnumeration))
			{
				schema.Reference = schemaResolver.GetSchema(type, isIntegerEnumeration);
			}
			else if (schema.GetType() == typeof(JsonSchema))
			{
				typeDescription.ApplyType(schema);
				if (Settings.UseXmlDocumentation)
				{
					schema.Description = type.GetXmlDocsSummary(Settings.GetXmlDocsOptions());
				}
				GenerateEnum(schema, typeDescription);
				schemaResolver.AddSchema(type, isIntegerEnumeration, schema);
			}
			else
			{
				schema.Reference = Generate(typeDescription.ContextualType, schemaResolver);
			}
		}

		private void GenerateProperties(Type type, JsonSchema schema, JsonSchemaResolver schemaResolver)
		{
			List<MemberInfo> source = type.GetTypeInfo().DeclaredFields.Where((FieldInfo f) => (!f.IsPrivate && !f.IsStatic) || f.IsDefined(typeof(DataMemberAttribute))).OfType<MemberInfo>().Concat(type.GetTypeInfo().DeclaredProperties.Where(delegate(PropertyInfo p)
			{
				MethodInfo getMethod = p.GetMethod;
				if ((object)getMethod == null || !getMethod.IsPrivate)
				{
					MethodInfo getMethod2 = p.GetMethod;
					if ((object)getMethod2 != null && !getMethod2.IsStatic)
					{
						goto IL_006d;
					}
				}
				MethodInfo setMethod = p.SetMethod;
				if ((object)setMethod == null || !setMethod.IsPrivate)
				{
					MethodInfo setMethod2 = p.SetMethod;
					if ((object)setMethod2 != null && !setMethod2.IsStatic)
					{
						goto IL_006d;
					}
				}
				return p.IsDefined(typeof(DataMemberAttribute));
				IL_006d:
				return true;
			}))
				.ToList();
			IEnumerable<ContextualAccessorInfo> source2 = source.Select((MemberInfo m) => m.ToContextualAccessor());
			JsonContract jsonContract = Settings.ResolveContract(type);
			string[] allowedProperties = GetTypeProperties(type);
			if (jsonContract is JsonObjectContract jsonObjectContract && allowedProperties == null)
			{
				foreach (JsonProperty jsonProperty in jsonObjectContract.Properties.Where((JsonProperty p) => p.DeclaringType == type))
				{
					bool flag;
					try
					{
						flag = jsonProperty.ShouldSerialize?.Invoke(null) ?? true;
					}
					catch
					{
						flag = true;
					}
					if (flag)
					{
						ContextualAccessorInfo contextualAccessorInfo = source2.FirstOrDefault((ContextualAccessorInfo p) => p.Name == jsonProperty.UnderlyingName);
						if (contextualAccessorInfo != null && (Settings.GenerateAbstractProperties || !IsAbstractProperty(contextualAccessorInfo)))
						{
							LoadPropertyOrField(jsonProperty, contextualAccessorInfo, type, schema, schemaResolver);
						}
					}
				}
				return;
			}
			foreach (ContextualAccessorInfo item in source2.Where((ContextualAccessorInfo m) => allowedProperties == null || allowedProperties.Contains<string>(m.Name)))
			{
				JsonPropertyAttribute contextAttribute = item.GetContextAttribute<JsonPropertyAttribute>();
				Type propertyType = (item as ContextualPropertyInfo)?.PropertyInfo.PropertyType ?? (item as ContextualFieldInfo)?.FieldInfo.FieldType;
				JsonProperty jsonProperty2 = new JsonProperty
				{
					AttributeProvider = new ReflectionAttributeProvider(item),
					PropertyType = propertyType,
					Ignored = IsPropertyIgnored(item, type)
				};
				if (contextAttribute != null)
				{
					jsonProperty2.PropertyName = contextAttribute.PropertyName ?? item.Name;
					jsonProperty2.Required = contextAttribute.Required;
					jsonProperty2.DefaultValueHandling = contextAttribute.DefaultValueHandling;
					jsonProperty2.TypeNameHandling = contextAttribute.TypeNameHandling;
					jsonProperty2.NullValueHandling = contextAttribute.NullValueHandling;
					jsonProperty2.TypeNameHandling = contextAttribute.TypeNameHandling;
				}
				else
				{
					jsonProperty2.PropertyName = item.Name;
				}
				LoadPropertyOrField(jsonProperty2, item, type, schema, schemaResolver);
			}
		}

		private bool IsAbstractProperty(ContextualMemberInfo memberInfo)
		{
			if (memberInfo is ContextualPropertyInfo contextualPropertyInfo && !contextualPropertyInfo.PropertyInfo.DeclaringType.GetTypeInfo().IsInterface)
			{
				MethodInfo getMethod = contextualPropertyInfo.PropertyInfo.GetMethod;
				if ((object)getMethod == null || !getMethod.IsAbstract)
				{
					return contextualPropertyInfo.PropertyInfo.SetMethod?.IsAbstract ?? false;
				}
				return true;
			}
			return false;
		}

		private void GenerateKnownTypes(Type type, JsonSchemaResolver schemaResolver)
		{
			object[] customAttributes = type.GetTypeInfo().GetCustomAttributes(Settings.GetActualFlattenInheritanceHierarchy(type));
			if (Settings.GenerateKnownTypes)
			{
				IEnumerable<Attribute> enumerable = customAttributes.GetAssignableToTypeName("KnownTypeAttribute", TypeNameStyle.Name).OfType<Attribute>();
				foreach (dynamic item in enumerable)
				{
					if (item.Type != null)
					{
						AddKnownType(item.Type, schemaResolver);
						continue;
					}
					if (item.MethodName != null)
					{
						MethodInfo runtimeMethod = type.GetRuntimeMethod((string)item.MethodName, new Type[0]);
						if (!(runtimeMethod != null) || !(runtimeMethod.Invoke(null, null) is IEnumerable<Type> enumerable2))
						{
							continue;
						}
						foreach (Type item2 in enumerable2)
						{
							AddKnownType(item2, schemaResolver);
						}
						continue;
					}
					throw new ArgumentException("A KnownType attribute on " + type.FullName + " does not specify a type or a method name.", "type");
				}
			}
			foreach (object item3 in customAttributes.GetAssignableToTypeName("JsonInheritanceAttribute", TypeNameStyle.Name))
			{
				Type type2 = item3.TryGetPropertyValue<Type>("Type");
				if (type2 != null)
				{
					AddKnownType(type2, schemaResolver);
				}
			}
		}

		private void AddKnownType(Type type, JsonSchemaResolver schemaResolver)
		{
			JsonTypeDescription description = Settings.ReflectionService.GetDescription(type.ToContextualType(), Settings);
			bool isIntegerEnumeration = description.Type == JsonObjectType.Integer;
			if (!schemaResolver.HasSchema(type, isIntegerEnumeration))
			{
				Generate(type, schemaResolver);
			}
		}

		private JsonSchema GenerateInheritance(ContextualType type, JsonSchema schema, JsonSchemaResolver schemaResolver)
		{
			ContextualType baseType = type.BaseType;
			if (baseType != null && baseType.Type != typeof(object) && baseType.Type != typeof(ValueType) && baseType.Attributes.FirstAssignableToTypeNameOrDefault("JsonSchemaIgnoreAttribute", TypeNameStyle.Name) == null && baseType.Attributes.FirstAssignableToTypeNameOrDefault("SwaggerIgnoreAttribute", TypeNameStyle.Name) == null)
			{
				string[] excludedTypeNames = Settings.ExcludedTypeNames;
				if (excludedTypeNames == null || !excludedTypeNames.Contains(baseType.Type.FullName))
				{
					if (!Settings.GetActualFlattenInheritanceHierarchy(type))
					{
						JsonSchema jsonSchema = new JsonSchema();
						GenerateProperties(type, jsonSchema, schemaResolver);
						ApplyAdditionalProperties(jsonSchema, type, schemaResolver);
						JsonTypeDescription description = Settings.ReflectionService.GetDescription(baseType, Settings);
						bool flag = description.RequiresSchemaReference(Settings.TypeMappers);
						if (jsonSchema.Properties.Any() || flag)
						{
							JsonSchema jsonSchema2 = Generate(baseType, schemaResolver);
							if (flag)
							{
								if (schemaResolver.RootObject != jsonSchema2.ActualSchema)
								{
									schemaResolver.AppendSchema(jsonSchema2.ActualSchema, Settings.SchemaNameGenerator.Generate(baseType));
								}
								schema._allOf.Add(new JsonSchema
								{
									Reference = jsonSchema2.ActualSchema
								});
							}
							else
							{
								schema._allOf.Add(jsonSchema2);
							}
							schema._allOf.Add(jsonSchema);
							return jsonSchema;
						}
						Generate(schema, baseType, schemaResolver);
						return schema;
					}
					JsonTypeDescription description2 = Settings.ReflectionService.GetDescription(baseType, Settings);
					if (!description2.IsDictionary && !type.Type.IsArray)
					{
						GenerateProperties(baseType, schema, schemaResolver);
						JsonSchema jsonSchema3 = GenerateInheritance(baseType, schema, schemaResolver);
						GenerateInheritanceDiscriminator(baseType, schema, jsonSchema3 ?? schema);
					}
				}
			}
			if (Settings.GetActualFlattenInheritanceHierarchy(type) && Settings.GenerateAbstractProperties)
			{
				foreach (Type implementedInterface in type.Type.GetTypeInfo().ImplementedInterfaces)
				{
					JsonTypeDescription description3 = Settings.ReflectionService.GetDescription(implementedInterface.ToContextualType(), Settings);
					if (!description3.IsDictionary && !type.Type.IsArray && !typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(implementedInterface.GetTypeInfo()))
					{
						GenerateProperties(implementedInterface, schema, schemaResolver);
						JsonSchema jsonSchema4 = GenerateInheritance(implementedInterface.ToContextualType(), schema, schemaResolver);
						GenerateInheritanceDiscriminator(implementedInterface, schema, jsonSchema4 ?? schema);
					}
				}
			}
			return null;
		}

		private void GenerateInheritanceDiscriminator(Type type, JsonSchema schema, JsonSchema typeSchema)
		{
			if (Settings.GetActualFlattenInheritanceHierarchy(type))
			{
				return;
			}
			object obj = TryGetInheritanceDiscriminatorConverter(type);
			if (obj != null)
			{
				string text = TryGetInheritanceDiscriminatorName(obj);
				if (typeSchema.Properties.TryGetValue(text, out var value))
				{
					if (!value.ActualTypeSchema.Type.IsInteger() && !value.ActualTypeSchema.Type.IsString())
					{
						throw new InvalidOperationException("The JSON discriminator property '" + text + "' must be a string|int property on type '" + type.FullName + "' (it is recommended to not implement the discriminator property at all).");
					}
					value.IsRequired = true;
				}
				OpenApiDiscriminator discriminatorObject = new OpenApiDiscriminator
				{
					JsonInheritanceConverter = obj,
					PropertyName = text
				};
				typeSchema.DiscriminatorObject = discriminatorObject;
				if (!typeSchema.Properties.ContainsKey(text))
				{
					typeSchema.Properties[text] = new JsonSchemaProperty
					{
						Type = JsonObjectType.String,
						IsRequired = true
					};
				}
			}
			else
			{
				(schema.ResponsibleDiscriminatorObject ?? schema.ActualTypeSchema.ResponsibleDiscriminatorObject)?.AddMapping(type, schema);
			}
		}

		private object TryGetInheritanceDiscriminatorConverter(Type type)
		{
			IEnumerable<Attribute> objects = type.GetTypeInfo().GetCustomAttributes(inherit: false).OfType<Attribute>();
			dynamic val = objects.FirstAssignableToTypeNameOrDefault("JsonConverterAttribute", TypeNameStyle.Name);
			if (val != null)
			{
				Type type2 = (Type)val.ConverterType;
				if (type2 != null && (type2.IsAssignableToTypeName("JsonInheritanceConverter", TypeNameStyle.Name) || type2.IsAssignableToTypeName("JsonInheritanceConverter`1", TypeNameStyle.Name)))
				{
					if (ObjectExtensions.HasProperty(val, "ConverterParameters") && val.ConverterParameters != null && val.ConverterParameters.Length > 0)
					{
						return Activator.CreateInstance(val.ConverterType, val.ConverterParameters);
					}
					return Activator.CreateInstance(val.ConverterType);
				}
			}
			return null;
		}

		private string TryGetInheritanceDiscriminatorName(object jsonInheritanceConverter)
		{
			return jsonInheritanceConverter.TryGetPropertyValue("DiscriminatorName", JsonInheritanceConverter.DefaultDiscriminatorName);
		}

		private void LoadPropertyOrField(JsonProperty jsonProperty, ContextualAccessorInfo accessorInfo, Type parentType, JsonSchema parentSchema, JsonSchemaResolver schemaResolver)
		{
			JsonTypeDescription propertyTypeDescription = Settings.ReflectionService.GetDescription(accessorInfo.AccessorType, Settings);
			if (jsonProperty.Ignored || IsPropertyIgnoredBySettings(accessorInfo))
			{
				return;
			}
			string propertyName = GetPropertyName(jsonProperty, accessorInfo);
			if (parentSchema.Properties.ContainsKey(propertyName))
			{
				if (!Settings.GetActualFlattenInheritanceHierarchy(parentType))
				{
					throw new InvalidOperationException("The JSON property '" + propertyName + "' is defined multiple times on type '" + parentType.FullName + "'.");
				}
				parentSchema.Properties.Remove(propertyName);
			}
			Attribute requiredAttribute = accessorInfo.ContextAttributes.FirstAssignableToTypeNameOrDefault("System.ComponentModel.DataAnnotations.RequiredAttribute");
			bool flag = jsonProperty.Required == Required.Always || jsonProperty.Required == Required.AllowNull;
			dynamic val = GetDataMemberAttribute(accessorInfo, parentType)?.IsRequired == true;
			bool hasRequiredAttribute = requiredAttribute != null;
			if ((hasRequiredAttribute ? ((object)hasRequiredAttribute) : (hasRequiredAttribute | val)) || flag)
			{
				parentSchema.RequiredProperties.Add(propertyName);
			}
			bool isNullable = propertyTypeDescription.IsNullable && !hasRequiredAttribute && (jsonProperty.Required == Required.Default || jsonProperty.Required == Required.AllowNull);
			Action<JsonSchemaProperty, JsonSchema> transformation = delegate(JsonSchemaProperty propertySchema, JsonSchema typeSchema)
			{
				if (Settings.GenerateXmlObjects)
				{
					propertySchema.GenerateXmlObjectForProperty(accessorInfo.AccessorType, propertyName);
				}
				if (hasRequiredAttribute && !propertyTypeDescription.IsEnum && propertyTypeDescription.Type == JsonObjectType.String && !requiredAttribute.TryGetPropertyValue("AllowEmptyStrings", defaultValue: false))
				{
					propertySchema.MinLength = 1;
				}
				if (!isNullable && Settings.SchemaType == SchemaType.Swagger2 && !parentSchema.RequiredProperties.Contains(propertyName))
				{
					parentSchema.RequiredProperties.Add(propertyName);
				}
				dynamic val2 = accessorInfo.ContextAttributes.FirstAssignableToTypeNameOrDefault("System.ComponentModel.ReadOnlyAttribute");
				if (val2 != null)
				{
					propertySchema.IsReadOnly = val2.IsReadOnly;
				}
				if (propertySchema.Description == null)
				{
					propertySchema.Description = accessorInfo.GetDescription(Settings);
				}
				if (propertySchema.Example == null)
				{
					propertySchema.Example = GenerateExample(accessorInfo);
				}
				dynamic val3 = accessorInfo.ContextAttributes.FirstAssignableToTypeNameOrDefault("System.ObsoleteAttribute");
				if (val3 != null)
				{
					propertySchema.IsDeprecated = true;
					propertySchema.DeprecatedMessage = val3.Message;
				}
				propertySchema.Default = ConvertDefaultValue(accessorInfo.AccessorType, jsonProperty.DefaultValue);
				ApplyDataAnnotations(propertySchema, propertyTypeDescription);
				ApplyPropertyExtensionDataAttributes(accessorInfo, propertySchema);
			};
			JsonSchemaProperty value = GenerateWithReferenceAndNullability(accessorInfo.AccessorType, isNullable, schemaResolver, transformation);
			parentSchema.Properties.Add(propertyName, value);
		}

		protected virtual bool IsPropertyIgnored(ContextualAccessorInfo accessorInfo, Type parentType)
		{
			if (accessorInfo.GetContextAttribute<JsonIgnoreAttribute>() != null)
			{
				return true;
			}
			if (accessorInfo.GetContextAttribute<JsonPropertyAttribute>() == null && HasDataContractAttribute(parentType) && GetDataMemberAttribute(accessorInfo, parentType) == null)
			{
				return true;
			}
			return IsPropertyIgnoredBySettings(accessorInfo);
		}

		private bool IsPropertyIgnoredBySettings(ContextualAccessorInfo accessorInfo)
		{
			if (Settings.IgnoreObsoleteProperties && accessorInfo.GetContextAttribute<ObsoleteAttribute>() != null)
			{
				return true;
			}
			if (accessorInfo.GetContextAttribute<JsonSchemaIgnoreAttribute>() != null)
			{
				return true;
			}
			return false;
		}

		private dynamic GetDataMemberAttribute(ContextualAccessorInfo accessorInfo, Type parentType)
		{
			if (!HasDataContractAttribute(parentType))
			{
				return null;
			}
			return accessorInfo.ContextAttributes.FirstAssignableToTypeNameOrDefault("DataMemberAttribute", TypeNameStyle.Name);
		}

		private bool HasDataContractAttribute(Type parentType)
		{
			return parentType.ToCachedType().InheritedAttributes.FirstAssignableToTypeNameOrDefault("DataContractAttribute", TypeNameStyle.Name) != null;
		}

		private void ApplyRangeAttribute(JsonSchema schema, IEnumerable<Attribute> parentAttributes)
		{
			dynamic val = parentAttributes.FirstAssignableToTypeNameOrDefault("System.ComponentModel.DataAnnotations.RangeAttribute");
			if (!((val != null) ? true : false))
			{
				return;
			}
			if (val.Minimum != null)
			{
				if (val.OperandType == typeof(double))
				{
					double num = (double)Convert.ChangeType(val.Minimum, typeof(double));
					if (num > double.MinValue)
					{
						schema.Minimum = (decimal)num;
					}
				}
				else
				{
					decimal num2 = (decimal)Convert.ChangeType(val.Minimum, typeof(decimal));
					if (num2 > decimal.MinValue)
					{
						schema.Minimum = num2;
					}
				}
			}
			if (!((val.Maximum != null) ? true : false))
			{
				return;
			}
			if (val.OperandType == typeof(double))
			{
				double num3 = (double)Convert.ChangeType(val.Maximum, typeof(double));
				if (num3 < double.MaxValue)
				{
					schema.Maximum = (decimal)num3;
				}
			}
			else
			{
				decimal num4 = (decimal)Convert.ChangeType(val.Maximum, typeof(decimal));
				if (num4 < decimal.MaxValue)
				{
					schema.Maximum = num4;
				}
			}
		}

		private void ApplyTypeExtensionDataAttributes<TSchemaType>(TSchemaType schema, ContextualType contextualType) where TSchemaType : JsonSchema, new()
		{
			Attribute[] array = (from attribute2 in contextualType.OriginalType.GetTypeInfo().GetCustomAttributes()
				where attribute2 is IJsonSchemaExtensionDataAttribute
				select attribute2).ToArray();
			if (array.Any())
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				Attribute[] array2 = array;
				foreach (Attribute attribute in array2)
				{
					IJsonSchemaExtensionDataAttribute jsonSchemaExtensionDataAttribute = (IJsonSchemaExtensionDataAttribute)attribute;
					dictionary.Add(jsonSchemaExtensionDataAttribute.Key, jsonSchemaExtensionDataAttribute.Value);
				}
				schema.ExtensionData = dictionary;
			}
		}

		private void ApplyPropertyExtensionDataAttributes(ContextualAccessorInfo accessorInfo, JsonSchemaProperty propertySchema)
		{
			IJsonSchemaExtensionDataAttribute[] source = accessorInfo.GetContextAttributes<IJsonSchemaExtensionDataAttribute>().ToArray();
			if (source.Any())
			{
				propertySchema.ExtensionData = source.ToDictionary((IJsonSchemaExtensionDataAttribute a) => a.Key, (IJsonSchemaExtensionDataAttribute a) => a.Value);
			}
		}
	}
}
