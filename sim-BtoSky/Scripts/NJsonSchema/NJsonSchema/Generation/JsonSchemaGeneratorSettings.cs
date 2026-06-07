using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using NJsonSchema.Generation.TypeMappers;
using Namotion.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace NJsonSchema.Generation
{
	public class JsonSchemaGeneratorSettings : IXmlDocsSettings
	{
		private EnumHandling _defaultEnumHandling;

		private PropertyNameHandling _defaultPropertyNameHandling;

		private IContractResolver _contractResolver;

		private JsonSerializerSettings _serializerSettings;

		private object _serializerOptions;

		public ReferenceTypeNullHandling DefaultReferenceTypeNullHandling { get; set; }

		public ReferenceTypeNullHandling DefaultDictionaryValueReferenceTypeNullHandling { get; set; }

		public bool GenerateAbstractProperties { get; set; }

		public bool FlattenInheritanceHierarchy { get; set; }

		public bool GenerateAbstractSchemas { get; set; }

		public bool GenerateKnownTypes { get; set; } = true;

		public bool GenerateXmlObjects { get; set; }

		public bool IgnoreObsoleteProperties { get; set; }

		public bool AllowReferencesWithProperties { get; set; }

		public bool GenerateEnumMappingDescription { get; set; }

		public bool AlwaysAllowAdditionalObjectProperties { get; set; }

		public bool GenerateExamples { get; set; }

		public SchemaType SchemaType { get; set; }

		[JsonIgnore]
		public JsonSerializerSettings SerializerSettings
		{
			get
			{
				return _serializerSettings;
			}
			set
			{
				_serializerSettings = value;
				UpdateActualContractResolverAndSerializerSettings();
			}
		}

		[JsonIgnore]
		public object SerializerOptions
		{
			get
			{
				return _serializerOptions;
			}
			set
			{
				_serializerOptions = value;
				UpdateActualContractResolverAndSerializerSettings();
			}
		}

		public string[] ExcludedTypeNames { get; set; }

		public bool UseXmlDocumentation { get; set; }

		public bool ResolveExternalXmlDocumentation { get; set; }

		public XmlDocsFormattingMode XmlDocumentationFormatting { get; set; }

		[JsonIgnore]
		public ITypeNameGenerator TypeNameGenerator { get; set; }

		[JsonIgnore]
		public ISchemaNameGenerator SchemaNameGenerator { get; set; }

		[JsonIgnore]
		public IReflectionService ReflectionService { get; set; }

		[JsonIgnore]
		public ICollection<ITypeMapper> TypeMappers { get; set; } = new Collection<ITypeMapper>();

		[JsonIgnore]
		public ICollection<ISchemaProcessor> SchemaProcessors { get; } = new Collection<ISchemaProcessor>();

		public bool GenerateCustomNullableProperties { get; set; }

		[JsonIgnore]
		[Obsolete("Use SerializerSettings directly instead. In NSwag.AspNetCore the property is set automatically.")]
		public IContractResolver ContractResolver
		{
			get
			{
				return _contractResolver;
			}
			set
			{
				_contractResolver = value;
				UpdateActualContractResolverAndSerializerSettings();
			}
		}

		[Obsolete("Use SerializerSettings directly instead. In NSwag.AspNetCore the property is set automatically.")]
		public PropertyNameHandling DefaultPropertyNameHandling
		{
			get
			{
				return _defaultPropertyNameHandling;
			}
			set
			{
				_defaultPropertyNameHandling = value;
				UpdateActualContractResolverAndSerializerSettings();
			}
		}

		[Obsolete("Use SerializerSettings directly instead. In NSwag.AspNetCore the property is set automatically.")]
		public EnumHandling DefaultEnumHandling
		{
			get
			{
				return _defaultEnumHandling;
			}
			set
			{
				_defaultEnumHandling = value;
				UpdateActualSerializerSettings();
			}
		}

		[JsonIgnore]
		public IContractResolver ActualContractResolver { get; internal set; }

		[JsonIgnore]
		public JsonSerializerSettings ActualSerializerSettings { get; internal set; }

		public JsonSchemaGeneratorSettings()
		{
			DefaultReferenceTypeNullHandling = ReferenceTypeNullHandling.Null;
			DefaultDictionaryValueReferenceTypeNullHandling = ReferenceTypeNullHandling.NotNull;
			SchemaType = SchemaType.JsonSchema;
			GenerateAbstractSchemas = true;
			GenerateExamples = true;
			DefaultEnumHandling = EnumHandling.Integer;
			DefaultPropertyNameHandling = PropertyNameHandling.Default;
			ContractResolver = null;
			TypeNameGenerator = new DefaultTypeNameGenerator();
			SchemaNameGenerator = new DefaultSchemaNameGenerator();
			ReflectionService = new DefaultReflectionService();
			ExcludedTypeNames = new string[0];
			UseXmlDocumentation = true;
			ResolveExternalXmlDocumentation = true;
			XmlDocumentationFormatting = XmlDocsFormattingMode.None;
		}

		public JsonContract ResolveContract(Type type)
		{
			string fullName = type.FullName;
			if (fullName == null)
			{
				return null;
			}
			return (!type.GetTypeInfo().IsGenericTypeDefinition) ? ActualContractResolver.ResolveContract(type) : null;
		}

		public bool GetActualGenerateAbstractSchema(Type type)
		{
			object obj = type.GetTypeInfo().GetCustomAttributes(inherit: false).FirstAssignableToTypeNameOrDefault("JsonSchemaAbstractAttribute", TypeNameStyle.Name);
			if (!GenerateAbstractSchemas || obj != null)
			{
				return obj?.TryGetPropertyValue("IsAbstract", defaultValue: true) ?? false;
			}
			return true;
		}

		public bool GetActualFlattenInheritanceHierarchy(Type type)
		{
			object obj = type.GetTypeInfo().GetCustomAttributes(inherit: false).FirstAssignableToTypeNameOrDefault("JsonSchemaFlattenAttribute", TypeNameStyle.Name);
			if (!FlattenInheritanceHierarchy || obj != null)
			{
				return obj?.TryGetPropertyValue("Flatten", defaultValue: true) ?? false;
			}
			return true;
		}

		private void UpdateActualContractResolverAndSerializerSettings()
		{
			if (SerializerOptions != null)
			{
				if (DefaultPropertyNameHandling != PropertyNameHandling.Default)
				{
					throw new InvalidOperationException("The setting DefaultPropertyNameHandling cannot be used when ContractResolver or SerializerOptions is set.");
				}
				if (ContractResolver != null)
				{
					throw new InvalidOperationException("The setting ContractResolver cannot be used when SerializerOptions is set.");
				}
				if (SerializerSettings != null)
				{
					throw new InvalidOperationException("The setting SerializerSettings cannot be used when SerializerOptions is set.");
				}
				ActualSerializerSettings = SystemTextJsonUtilities.ConvertJsonOptionsToNewtonsoftSettings(SerializerOptions);
				ActualContractResolver = ActualSerializerSettings.ContractResolver ?? new DefaultContractResolver();
				return;
			}
			if (SerializerSettings != null)
			{
				if (DefaultPropertyNameHandling != PropertyNameHandling.Default)
				{
					throw new InvalidOperationException("The setting DefaultPropertyNameHandling cannot be used when ContractResolver or SerializerSettings is set.");
				}
				if (ContractResolver != null)
				{
					throw new InvalidOperationException("The setting ContractResolver cannot be used when SerializerSettings is set.");
				}
				if (SerializerOptions != null)
				{
					throw new InvalidOperationException("The setting SerializerOptions cannot be used when SerializerSettings is set.");
				}
				ActualContractResolver = SerializerSettings.ContractResolver ?? new DefaultContractResolver();
			}
			else if (ContractResolver != null)
			{
				if (DefaultPropertyNameHandling != PropertyNameHandling.Default)
				{
					throw new InvalidOperationException("The setting DefaultPropertyNameHandling cannot be used when ContractResolver or SerializerSettings is set.");
				}
				ActualContractResolver = ContractResolver;
			}
			else if (DefaultPropertyNameHandling == PropertyNameHandling.CamelCase)
			{
				ActualContractResolver = new DefaultContractResolver
				{
					NamingStrategy = new CamelCaseNamingStrategy(processDictionaryKeys: false, overrideSpecifiedNames: true)
				};
			}
			else if (DefaultPropertyNameHandling == PropertyNameHandling.SnakeCase)
			{
				ActualContractResolver = new DefaultContractResolver
				{
					NamingStrategy = new SnakeCaseNamingStrategy(processDictionaryKeys: false, overrideSpecifiedNames: true)
				};
			}
			else
			{
				ActualContractResolver = new DefaultContractResolver();
			}
			UpdateActualSerializerSettings();
		}

		private void UpdateActualSerializerSettings()
		{
			if (SerializerSettings != null)
			{
				if (DefaultPropertyNameHandling != PropertyNameHandling.Default)
				{
					throw new InvalidOperationException("The setting DefaultPropertyNameHandling cannot be used when ContractResolver or SerializerSettings is set.");
				}
				if (ContractResolver != null)
				{
					throw new InvalidOperationException("The setting ContractResolver cannot be used when SerializerSettings is set.");
				}
				if (DefaultEnumHandling != EnumHandling.Integer)
				{
					throw new InvalidOperationException("The setting DefaultEnumHandling cannot be used when SerializerSettings is set.");
				}
				ActualSerializerSettings = SerializerSettings;
			}
			else
			{
				JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
				jsonSerializerSettings.ContractResolver = ActualContractResolver;
				if (DefaultEnumHandling == EnumHandling.String)
				{
					jsonSerializerSettings.Converters.Add(new StringEnumConverter());
				}
				else if (DefaultEnumHandling == EnumHandling.CamelCaseString)
				{
					jsonSerializerSettings.Converters.Add(new StringEnumConverter(camelCaseText: true));
				}
				ActualSerializerSettings = jsonSerializerSettings;
			}
		}
	}
}
