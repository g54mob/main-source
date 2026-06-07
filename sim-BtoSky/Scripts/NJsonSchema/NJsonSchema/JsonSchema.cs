using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NJsonSchema.Collections;
using NJsonSchema.Generation;
using NJsonSchema.Infrastructure;
using NJsonSchema.References;
using NJsonSchema.Validation;
using Namotion.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NJsonSchema
{
	[JsonConverter(typeof(ExtensionDataDeserializationConverter))]
	public class JsonSchema : JsonReferenceBase<JsonSchema>, IDocumentPathProvider, IJsonReference, IJsonReferenceBase, IJsonExtensionObject
	{
		internal static readonly HashSet<string> JsonSchemaPropertiesCache = new HashSet<string>((from p in typeof(JsonSchema).GetContextualProperties()
			select p.Name).ToArray());

		private const SchemaType SerializationSchemaType = SchemaType.JsonSchema;

		private static readonly Lazy<PropertyRenameAndIgnoreSerializerContractResolver> ContractResolver = new Lazy<PropertyRenameAndIgnoreSerializerContractResolver>(() => CreateJsonSerializerContractResolver(SchemaType.JsonSchema));

		private ObservableDictionary<string, JsonSchemaProperty> _properties;

		private ObservableDictionary<string, JsonSchemaProperty> _patternProperties;

		private ObservableDictionary<string, JsonSchema> _definitions;

		internal ObservableCollection<JsonSchema> _allOf;

		internal ObservableCollection<JsonSchema> _anyOf;

		internal ObservableCollection<JsonSchema> _oneOf;

		private JsonSchema _not;

		private JsonSchema _dictionaryKey;

		private JsonObjectType _type;

		private JsonSchema _item;

		internal ObservableCollection<JsonSchema> _items;

		private bool _allowAdditionalItems = true;

		private JsonSchema _additionalItemsSchema;

		private bool _allowAdditionalProperties = true;

		private JsonSchema _additionalPropertiesSchema;

		private static readonly string version = typeof(JsonSchema).GetTypeInfo().Assembly.GetName().Version?.ToString() + " (Newtonsoft.Json v" + typeof(JToken).GetTypeInfo().Assembly.GetName().Version?.ToString() + ")";

		[JsonIgnore]
		private JsonXmlObject _xmlObject;

		private static readonly JsonObjectType[] _jsonObjectTypeValues = (from v in Enum.GetValues(typeof(JsonObjectType)).OfType<JsonObjectType>()
			where v != JsonObjectType.None
			select v).ToArray();

		private readonly NotifyCollectionChangedEventHandler _initializeSchemaCollectionEventHandler;

		private Lazy<object> _typeRaw;

		public static string ToolchainVersion => version;

		[JsonIgnore]
		public bool IsBinary
		{
			get
			{
				if (!Type.IsFile())
				{
					if (Type.IsString())
					{
						return Format == "binary";
					}
					return false;
				}
				return true;
			}
		}

		[JsonIgnore]
		public JsonSchema InheritedSchema
		{
			get
			{
				if (_allOf == null || _allOf.Count == 0 || HasReference)
				{
					return null;
				}
				if (_allOf.Count == 1)
				{
					return _allOf[0].ActualSchema;
				}
				JsonSchema jsonSchema = _allOf.FirstOrDefault((JsonSchema s) => s.HasReference);
				if (jsonSchema != null)
				{
					return jsonSchema.ActualSchema;
				}
				JsonSchema jsonSchema2 = _allOf.FirstOrDefault((JsonSchema s) => s.Type.IsObject());
				if (jsonSchema2 != null)
				{
					return jsonSchema2.ActualSchema;
				}
				return _allOf.FirstOrDefault()?.ActualSchema;
			}
		}

		[JsonIgnore]
		public JsonSchema InheritedTypeSchema
		{
			get
			{
				if (ActualTypeSchema.IsDictionary || ActualTypeSchema.IsArray || ActualTypeSchema.IsTuple)
				{
					return ActualTypeSchema;
				}
				return InheritedSchema;
			}
		}

		[JsonIgnore]
		public IReadOnlyCollection<JsonSchema> AllInheritedSchemas
		{
			get
			{
				List<JsonSchema> list = ((InheritedSchema != null) ? new List<JsonSchema> { InheritedSchema } : new List<JsonSchema>());
				return list.Concat(list.SelectMany((JsonSchema s) => s.AllInheritedSchemas)).ToList();
			}
		}

		[JsonIgnore]
		public OpenApiDiscriminator ResponsibleDiscriminatorObject
		{
			get
			{
				OpenApiDiscriminator openApiDiscriminator = ActualDiscriminatorObject;
				if (openApiDiscriminator == null)
				{
					JsonSchema inheritedSchema = InheritedSchema;
					if (inheritedSchema == null)
					{
						return null;
					}
					openApiDiscriminator = inheritedSchema.ActualSchema.ResponsibleDiscriminatorObject;
				}
				return openApiDiscriminator;
			}
		}

		[JsonIgnore]
		public bool HasActualProperties
		{
			get
			{
				if (_properties.Count > 0)
				{
					return true;
				}
				for (int i = 0; i < _allOf.Count; i++)
				{
					JsonSchema jsonSchema = _allOf[i];
					if (jsonSchema.ActualSchema != InheritedSchema && jsonSchema.ActualSchema.HasActualProperties)
					{
						return true;
					}
				}
				return false;
			}
		}

		[JsonIgnore]
		public IReadOnlyDictionary<string, JsonSchemaProperty> ActualProperties
		{
			get
			{
				if (_allOf.Count == 0)
				{
					return new Dictionary<string, JsonSchemaProperty>(_properties);
				}
				IEnumerable<KeyValuePair<string, JsonSchemaProperty>> source = _properties.Union(_allOf.Where((JsonSchema s) => s.ActualSchema != InheritedSchema).SelectMany((JsonSchema s) => s.ActualSchema.ActualProperties));
				try
				{
					return source.ToDictionary((KeyValuePair<string, JsonSchemaProperty> p) => p.Key, (KeyValuePair<string, JsonSchemaProperty> p) => p.Value);
				}
				catch (ArgumentException)
				{
					IEnumerable<IGrouping<string, KeyValuePair<string, JsonSchemaProperty>>> source2 = from p in source
						group p by p.Key into g
						where g.Count() > 1
						select g;
					throw new InvalidOperationException("The properties " + string.Join(", ", source2.Select((IGrouping<string, KeyValuePair<string, JsonSchemaProperty>> g) => "'" + g.Key + "'")) + " are defined multiple times.");
				}
			}
		}

		[JsonProperty("$schema", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, Order = -99)]
		public string SchemaVersion { get; set; }

		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, Order = -98)]
		public string Id { get; set; }

		[JsonProperty("title", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, Order = -97)]
		public string Title { get; set; }

		[JsonIgnore]
		public bool HasTypeNameTitle
		{
			get
			{
				if (!string.IsNullOrEmpty(Title))
				{
					return Regex.IsMatch(Title, "^[a-zA-Z0-9_]*$");
				}
				return false;
			}
		}

		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public virtual string Description { get; set; }

		[JsonIgnore]
		public JsonObjectType Type
		{
			get
			{
				return _type;
			}
			set
			{
				_type = value;
				ResetTypeRaw();
			}
		}

		[JsonIgnore]
		public JsonSchema ParentSchema => Parent as JsonSchema;

		[JsonIgnore]
		public virtual object Parent { get; set; }

		[JsonProperty("format", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public string Format { get; set; }

		[JsonProperty("default", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public object Default { get; set; }

		[JsonProperty("multipleOf", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public decimal? MultipleOf { get; set; }

		[JsonProperty("maximum", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public decimal? Maximum { get; set; }

		[JsonIgnore]
		public decimal? ExclusiveMaximum { get; set; }

		[JsonIgnore]
		public bool IsExclusiveMaximum { get; set; }

		[JsonProperty("minimum", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public decimal? Minimum { get; set; }

		[JsonIgnore]
		public decimal? ExclusiveMinimum { get; set; }

		[JsonIgnore]
		public bool IsExclusiveMinimum { get; set; }

		[JsonProperty("maxLength", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public int? MaxLength { get; set; }

		[JsonProperty("minLength", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public int? MinLength { get; set; }

		[JsonProperty("pattern", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public string Pattern { get; set; }

		[JsonProperty("maxItems", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public int MaxItems { get; set; }

		[JsonProperty("minItems", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public int MinItems { get; set; }

		[JsonProperty("uniqueItems", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public bool UniqueItems { get; set; }

		[JsonProperty("maxProperties", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public int MaxProperties { get; set; }

		[JsonProperty("minProperties", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public int MinProperties { get; set; }

		[JsonProperty("x-deprecated", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsDeprecated { get; set; }

		[JsonProperty("x-deprecatedMessage", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string DeprecatedMessage { get; set; }

		[JsonProperty("x-abstract", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public bool IsAbstract { get; set; }

		[JsonProperty("x-nullable", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public bool? IsNullableRaw { get; set; }

		[JsonProperty("x-example", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public object Example { get; set; }

		[JsonProperty("x-enumFlags", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public bool IsFlagEnumerable { get; set; }

		[JsonIgnore]
		public ICollection<object> Enumeration { get; internal set; }

		[JsonIgnore]
		public bool IsEnumeration => Enumeration.Count > 0;

		[JsonIgnore]
		public ICollection<string> RequiredProperties { get; internal set; }

		[JsonProperty("x-dictionaryKey", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public JsonSchema DictionaryKey
		{
			get
			{
				return _dictionaryKey;
			}
			set
			{
				_dictionaryKey = value;
				if (_dictionaryKey != null)
				{
					_dictionaryKey.Parent = this;
				}
			}
		}

		[JsonIgnore]
		public IDictionary<string, JsonSchemaProperty> Properties
		{
			get
			{
				return _properties;
			}
			internal set
			{
				if (_properties != value)
				{
					ObservableDictionary<string, JsonSchemaProperty> observableDictionary = ToObservableDictionary(value);
					RegisterProperties(_properties, observableDictionary);
					_properties = observableDictionary;
				}
			}
		}

		[JsonProperty("xml", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public JsonXmlObject Xml
		{
			get
			{
				return _xmlObject;
			}
			set
			{
				_xmlObject = value;
				if (_xmlObject != null)
				{
					_xmlObject.ParentSchema = this;
				}
			}
		}

		[JsonIgnore]
		public IDictionary<string, JsonSchemaProperty> PatternProperties
		{
			get
			{
				return _patternProperties;
			}
			internal set
			{
				if (_patternProperties != value)
				{
					ObservableDictionary<string, JsonSchemaProperty> observableDictionary = ToObservableDictionary(value);
					RegisterSchemaDictionary(_patternProperties, observableDictionary);
					_patternProperties = observableDictionary;
				}
			}
		}

		[JsonIgnore]
		public JsonSchema Item
		{
			get
			{
				return _item;
			}
			set
			{
				if (_item != value)
				{
					_item = value;
					if (_item != null)
					{
						_item.Parent = this;
						Items.Clear();
					}
				}
			}
		}

		[JsonIgnore]
		public ICollection<JsonSchema> Items
		{
			get
			{
				return _items;
			}
			internal set
			{
				if (_items != value)
				{
					ObservableCollection<JsonSchema> observableCollection = ToObservableCollection(value);
					RegisterSchemaCollection(_items, observableCollection);
					_items = observableCollection;
					if (_items != null)
					{
						Item = null;
					}
				}
			}
		}

		[JsonProperty("not", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public JsonSchema Not
		{
			get
			{
				return _not;
			}
			set
			{
				_not = value;
				if (_not != null)
				{
					_not.Parent = this;
				}
			}
		}

		[JsonIgnore]
		public IDictionary<string, JsonSchema> Definitions
		{
			get
			{
				return _definitions;
			}
			internal set
			{
				if (_definitions != value)
				{
					ObservableDictionary<string, JsonSchema> observableDictionary = ToObservableDictionary(value);
					RegisterSchemaDictionary(_definitions, observableDictionary);
					_definitions = observableDictionary;
				}
			}
		}

		[JsonIgnore]
		public ICollection<JsonSchema> AllOf
		{
			get
			{
				return _allOf;
			}
			internal set
			{
				if (_allOf != value)
				{
					ObservableCollection<JsonSchema> observableCollection = ToObservableCollection(value);
					RegisterSchemaCollection(_allOf, observableCollection);
					_allOf = observableCollection;
				}
			}
		}

		[JsonIgnore]
		public ICollection<JsonSchema> AnyOf
		{
			get
			{
				return _anyOf;
			}
			internal set
			{
				if (_anyOf != value)
				{
					ObservableCollection<JsonSchema> observableCollection = ToObservableCollection(value);
					RegisterSchemaCollection(_anyOf, observableCollection);
					_anyOf = observableCollection;
				}
			}
		}

		[JsonIgnore]
		public ICollection<JsonSchema> OneOf
		{
			get
			{
				return _oneOf;
			}
			internal set
			{
				if (_oneOf != value)
				{
					ObservableCollection<JsonSchema> observableCollection = ToObservableCollection(value);
					RegisterSchemaCollection(_oneOf, observableCollection);
					_oneOf = observableCollection;
				}
			}
		}

		[JsonIgnore]
		public bool AllowAdditionalItems
		{
			get
			{
				return _allowAdditionalItems;
			}
			set
			{
				if (_allowAdditionalItems != value)
				{
					_allowAdditionalItems = value;
					if (!_allowAdditionalItems)
					{
						AdditionalItemsSchema = null;
					}
				}
			}
		}

		[JsonIgnore]
		public JsonSchema AdditionalItemsSchema
		{
			get
			{
				return _additionalItemsSchema;
			}
			set
			{
				if (_additionalItemsSchema != value)
				{
					_additionalItemsSchema = value;
					if (_additionalItemsSchema != null)
					{
						AllowAdditionalItems = true;
					}
				}
			}
		}

		[JsonIgnore]
		public bool AllowAdditionalProperties
		{
			get
			{
				return _allowAdditionalProperties;
			}
			set
			{
				if (_allowAdditionalProperties != value)
				{
					_allowAdditionalProperties = value;
					if (!_allowAdditionalProperties)
					{
						AdditionalPropertiesSchema = null;
					}
				}
			}
		}

		[JsonIgnore]
		public JsonSchema AdditionalPropertiesSchema
		{
			get
			{
				return _additionalPropertiesSchema;
			}
			set
			{
				if (_additionalPropertiesSchema != value)
				{
					_additionalPropertiesSchema = value;
					if (_additionalPropertiesSchema != null)
					{
						AllowAdditionalProperties = true;
					}
				}
			}
		}

		[JsonIgnore]
		public bool IsObject => Type.IsObject();

		[JsonIgnore]
		public bool IsArray
		{
			get
			{
				if (Type.IsArray())
				{
					if (Items != null)
					{
						return Items.Count == 0;
					}
					return true;
				}
				return false;
			}
		}

		[JsonIgnore]
		public bool IsTuple
		{
			get
			{
				if (Type.IsArray())
				{
					return Items?.Any() ?? false;
				}
				return false;
			}
		}

		[JsonIgnore]
		public bool IsDictionary
		{
			get
			{
				if (Type.IsObject() && !HasActualProperties)
				{
					if (AdditionalPropertiesSchema == null)
					{
						return PatternProperties.Any();
					}
					return true;
				}
				return false;
			}
		}

		[JsonIgnore]
		public bool IsAnyType
		{
			get
			{
				if ((Type.IsObject() || Type == JsonObjectType.None) && Reference == null && _allOf.Count == 0 && _anyOf.Count == 0 && _oneOf.Count == 0 && !HasActualProperties && _patternProperties.Count == 0 && AdditionalPropertiesSchema == null && !MultipleOf.HasValue)
				{
					return !IsEnumeration;
				}
				return false;
			}
		}

		[JsonIgnore]
		public virtual JsonSchema ActualSchema => GetActualSchema(null);

		[JsonIgnore]
		public virtual JsonSchema ActualTypeSchema
		{
			get
			{
				JsonSchema jsonSchema = ((Reference != null) ? Reference : this);
				if (jsonSchema._allOf.Count <= 1 || jsonSchema._allOf.Count((JsonSchema s) => !s.HasReference && !s.IsDictionary) != 1)
				{
					return jsonSchema._oneOf.FirstOrDefault((JsonSchema o) => !o.IsNullable(SchemaType.JsonSchema))?.ActualSchema ?? ActualSchema;
				}
				return jsonSchema._allOf.First((JsonSchema s) => !s.HasReference && !s.IsDictionary).ActualSchema;
			}
		}

		[JsonIgnore]
		public bool HasReference
		{
			get
			{
				if (Reference == null && !HasAllOfSchemaReference && !HasOneOfSchemaReference)
				{
					return HasAnyOfSchemaReference;
				}
				return true;
			}
		}

		[JsonIgnore]
		public bool HasAllOfSchemaReference
		{
			get
			{
				if (Type == JsonObjectType.None && _anyOf.Count == 0 && _oneOf.Count == 0 && _properties.Count == 0 && _patternProperties.Count == 0 && AdditionalPropertiesSchema == null && !MultipleOf.HasValue && !IsEnumeration && _allOf.Count == 1)
				{
					return _allOf.Any((JsonSchema s) => s.HasReference);
				}
				return false;
			}
		}

		[JsonIgnore]
		public bool HasOneOfSchemaReference
		{
			get
			{
				if (Type == JsonObjectType.None && _anyOf.Count == 0 && _allOf.Count == 0 && _properties.Count == 0 && _patternProperties.Count == 0 && AdditionalPropertiesSchema == null && !MultipleOf.HasValue && !IsEnumeration && _oneOf.Count == 1)
				{
					return _oneOf.Any((JsonSchema s) => s.HasReference);
				}
				return false;
			}
		}

		[JsonIgnore]
		public bool HasAnyOfSchemaReference
		{
			get
			{
				if (Type == JsonObjectType.None && _allOf.Count == 0 && _oneOf.Count == 0 && _properties.Count == 0 && _patternProperties.Count == 0 && AdditionalPropertiesSchema == null && !MultipleOf.HasValue && !IsEnumeration && _anyOf.Count == 1)
				{
					return _anyOf.Any((JsonSchema s) => s.HasReference);
				}
				return false;
			}
		}

		[JsonIgnore]
		IJsonReference IJsonReference.ActualObject => ActualSchema;

		[JsonIgnore]
		object IJsonReference.PossibleRoot => Parent;

		[JsonIgnore]
		public override JsonSchema Reference
		{
			get
			{
				return base.Reference;
			}
			set
			{
				base.Reference = value;
				if (value != null)
				{
					Type = JsonObjectType.None;
				}
			}
		}

		[JsonExtensionData]
		public IDictionary<string, object> ExtensionData { get; set; }

		[JsonIgnore]
		public string ActualDiscriminator => ActualTypeSchema.Discriminator;

		[JsonIgnore]
		public string Discriminator
		{
			get
			{
				return DiscriminatorObject?.PropertyName;
			}
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					DiscriminatorObject = new OpenApiDiscriminator
					{
						PropertyName = value
					};
				}
				else
				{
					DiscriminatorObject = null;
				}
			}
		}

		[JsonIgnore]
		public OpenApiDiscriminator ActualDiscriminatorObject => DiscriminatorObject ?? ActualTypeSchema.DiscriminatorObject;

		[JsonIgnore]
		public OpenApiDiscriminator DiscriminatorObject { get; set; }

		[JsonProperty("discriminator", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, Order = -95)]
		internal object DiscriminatorRaw
		{
			get
			{
				if (JsonSchemaSerialization.CurrentSchemaType != SchemaType.Swagger2)
				{
					return DiscriminatorObject;
				}
				return Discriminator;
			}
			set
			{
				if (value is string)
				{
					Discriminator = (string)value;
				}
				else if (value != null)
				{
					DiscriminatorObject = ((JObject)value).ToObject<OpenApiDiscriminator>();
				}
			}
		}

		[JsonIgnore]
		public Collection<string> EnumerationNames { get; set; }

		[JsonProperty("exclusiveMaximum", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		internal object ExclusiveMaximumRaw
		{
			get
			{
				decimal? exclusiveMaximum = ExclusiveMaximum;
				if (!exclusiveMaximum.HasValue)
				{
					if (!IsExclusiveMaximum)
					{
						return null;
					}
					return true;
				}
				return exclusiveMaximum.GetValueOrDefault();
			}
			set
			{
				if (value is bool)
				{
					IsExclusiveMaximum = (bool)value;
				}
				else if (value != null && (value.Equals("true") || value.Equals("false")))
				{
					IsExclusiveMaximum = value.Equals("true");
				}
				else if (value != null)
				{
					ExclusiveMaximum = Convert.ToDecimal(value);
				}
			}
		}

		[JsonProperty("exclusiveMinimum", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		internal object ExclusiveMinimumRaw
		{
			get
			{
				decimal? exclusiveMinimum = ExclusiveMinimum;
				if (!exclusiveMinimum.HasValue)
				{
					if (!IsExclusiveMinimum)
					{
						return null;
					}
					return true;
				}
				return exclusiveMinimum.GetValueOrDefault();
			}
			set
			{
				if (value is bool)
				{
					IsExclusiveMinimum = (bool)value;
				}
				else if (value != null && (value.Equals("true") || value.Equals("false")))
				{
					IsExclusiveMinimum = value.Equals("true");
				}
				else if (value != null)
				{
					ExclusiveMinimum = Convert.ToDecimal(value);
				}
			}
		}

		[JsonProperty("additionalItems", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		internal object AdditionalItemsRaw
		{
			get
			{
				if (AdditionalItemsSchema != null)
				{
					return AdditionalItemsSchema;
				}
				if (!AllowAdditionalItems)
				{
					return false;
				}
				return null;
			}
			set
			{
				if (value is bool)
				{
					AllowAdditionalItems = (bool)value;
				}
				else if (value != null && (value.Equals("true") || value.Equals("false")))
				{
					AllowAdditionalItems = value.Equals("true");
				}
				else if (value != null)
				{
					AdditionalItemsSchema = FromJsonWithCurrentSettings(value);
				}
			}
		}

		[JsonProperty("additionalProperties", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		internal object AdditionalPropertiesRaw
		{
			get
			{
				if (AdditionalPropertiesSchema != null)
				{
					return AdditionalPropertiesSchema;
				}
				if (JsonSchemaSerialization.CurrentSchemaType == SchemaType.Swagger2)
				{
					if (AllowAdditionalProperties && (Type.IsObject() || Type == JsonObjectType.None) && !HasReference && !_allOf.Any() && !GetType().IsAssignableToTypeName("OpenApiParameter", TypeNameStyle.Name))
					{
						return new JObject();
					}
					return null;
				}
				if (!AllowAdditionalProperties)
				{
					return false;
				}
				return null;
			}
			set
			{
				if (value is bool)
				{
					AllowAdditionalProperties = (bool)value;
				}
				else if (value != null && (value.Equals("true") || value.Equals("false")))
				{
					AllowAdditionalProperties = value.Equals("true");
				}
				else if (value != null)
				{
					AdditionalPropertiesSchema = FromJsonWithCurrentSettings(value);
				}
			}
		}

		[JsonProperty("items", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		internal object ItemsRaw
		{
			get
			{
				if (Item != null)
				{
					return Item;
				}
				if (Items.Count > 0)
				{
					return Items;
				}
				return null;
			}
			set
			{
				if (value is JArray)
				{
					Items = new ObservableCollection<JsonSchema>(((JArray)value).Select((JToken t) => FromJsonWithCurrentSettings(t)));
				}
				else if (value != null)
				{
					Item = FromJsonWithCurrentSettings(value);
				}
			}
		}

		[JsonProperty("type", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, Order = -97)]
		internal object TypeRaw
		{
			get
			{
				if (_typeRaw == null)
				{
					ResetTypeRaw();
				}
				return _typeRaw.Value;
			}
			set
			{
				if (value is JArray)
				{
					Type = ((JArray)value).Aggregate(JsonObjectType.None, (JsonObjectType type, JToken token) => type | ConvertStringToJsonObjectType(token.ToString()));
				}
				else
				{
					Type = ConvertStringToJsonObjectType(value as string);
				}
				ResetTypeRaw();
			}
		}

		[JsonProperty("required", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		internal ICollection<string> RequiredPropertiesRaw
		{
			get
			{
				if (RequiredProperties == null || RequiredProperties.Count <= 0)
				{
					return null;
				}
				return RequiredProperties;
			}
			set
			{
				RequiredProperties = value;
			}
		}

		[JsonProperty("properties", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		internal IDictionary<string, JsonSchemaProperty> PropertiesRaw
		{
			get
			{
				if (_properties == null || _properties.Count <= 0)
				{
					return null;
				}
				return Properties;
			}
			set
			{
				Properties = ((value != null) ? new ObservableDictionary<string, JsonSchemaProperty>(value) : new ObservableDictionary<string, JsonSchemaProperty>());
			}
		}

		[JsonProperty("patternProperties", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		internal IDictionary<string, JsonSchemaProperty> PatternPropertiesRaw
		{
			get
			{
				if (_patternProperties == null || _patternProperties.Count <= 0)
				{
					return null;
				}
				return PatternProperties.ToDictionary((KeyValuePair<string, JsonSchemaProperty> p) => p.Key, (KeyValuePair<string, JsonSchemaProperty> p) => p.Value);
			}
			set
			{
				PatternProperties = ((value != null) ? new ObservableDictionary<string, JsonSchemaProperty>(value) : new ObservableDictionary<string, JsonSchemaProperty>());
			}
		}

		[JsonProperty("definitions", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		internal IDictionary<string, JsonSchema> DefinitionsRaw
		{
			get
			{
				if (Definitions == null || Definitions.Count <= 0)
				{
					return null;
				}
				return Definitions;
			}
			set
			{
				Definitions = ((value != null) ? new ObservableDictionary<string, JsonSchema>(value) : new ObservableDictionary<string, JsonSchema>());
			}
		}

		[JsonProperty("x-enumNames", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		internal Collection<string> EnumerationNamesRaw
		{
			get
			{
				if (EnumerationNames == null || EnumerationNames.Count <= 0)
				{
					return null;
				}
				return EnumerationNames;
			}
			set
			{
				EnumerationNames = ((value != null) ? new ObservableCollection<string>(value) : new ObservableCollection<string>());
			}
		}

		[JsonProperty("enum", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		internal ICollection<object> EnumerationRaw
		{
			get
			{
				if (Enumeration == null || Enumeration.Count <= 0)
				{
					return null;
				}
				return Enumeration;
			}
			set
			{
				Enumeration = ((value != null) ? new ObservableCollection<object>(value) : new ObservableCollection<object>());
			}
		}

		[JsonProperty("allOf", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		internal ICollection<JsonSchema> AllOfRaw
		{
			get
			{
				if (_allOf == null || _allOf.Count <= 0)
				{
					return null;
				}
				return AllOf;
			}
			set
			{
				AllOf = ((value != null) ? new ObservableCollection<JsonSchema>(value) : new ObservableCollection<JsonSchema>());
			}
		}

		[JsonProperty("anyOf", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		internal ICollection<JsonSchema> AnyOfRaw
		{
			get
			{
				if (_anyOf == null || _anyOf.Count <= 0)
				{
					return null;
				}
				return AnyOf;
			}
			set
			{
				AnyOf = ((value != null) ? new ObservableCollection<JsonSchema>(value) : new ObservableCollection<JsonSchema>());
			}
		}

		[JsonProperty("oneOf", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		internal ICollection<JsonSchema> OneOfRaw
		{
			get
			{
				if (_oneOf == null || _oneOf.Count <= 0)
				{
					return null;
				}
				return OneOf;
			}
			set
			{
				OneOf = ((value != null) ? new ObservableCollection<JsonSchema>(value) : new ObservableCollection<JsonSchema>());
			}
		}

		public JsonSchema()
		{
			_initializeSchemaCollectionEventHandler = InitializeSchemaCollection;
			Initialize();
			if (JsonSchemaSerialization.CurrentSchemaType == SchemaType.Swagger2)
			{
				_allowAdditionalProperties = false;
			}
		}

		public static JsonSchema CreateAnySchema()
		{
			return new JsonSchema();
		}

		public static TSchemaType CreateAnySchema<TSchemaType>() where TSchemaType : JsonSchema, new()
		{
			return new TSchemaType();
		}

		public static JsonSchema FromType<TType>()
		{
			return FromType<TType>(new JsonSchemaGeneratorSettings());
		}

		public static JsonSchema FromType(Type type)
		{
			return FromType(type, new JsonSchemaGeneratorSettings());
		}

		public static JsonSchema FromType<TType>(JsonSchemaGeneratorSettings settings)
		{
			JsonSchemaGenerator jsonSchemaGenerator = new JsonSchemaGenerator(settings);
			return jsonSchemaGenerator.Generate(typeof(TType));
		}

		public static JsonSchema FromType(Type type, JsonSchemaGeneratorSettings settings)
		{
			JsonSchemaGenerator jsonSchemaGenerator = new JsonSchemaGenerator(settings);
			return jsonSchemaGenerator.Generate(type);
		}

		public static JsonSchema FromSampleJson(string data)
		{
			SampleJsonSchemaGenerator sampleJsonSchemaGenerator = new SampleJsonSchemaGenerator();
			return sampleJsonSchemaGenerator.Generate(data);
		}

		public static JsonSchema FromSampleJson(Stream stream)
		{
			SampleJsonSchemaGenerator sampleJsonSchemaGenerator = new SampleJsonSchemaGenerator();
			return sampleJsonSchemaGenerator.Generate(stream);
		}

		public static Task<JsonSchema> FromFileAsync(string filePath, CancellationToken cancellationToken = default(CancellationToken))
		{
			Func<JsonSchema, JsonReferenceResolver> referenceResolverFactory = JsonReferenceResolver.CreateJsonReferenceResolverFactory(new DefaultTypeNameGenerator());
			return FromFileAsync(filePath, referenceResolverFactory, cancellationToken);
		}

		public static Task<JsonSchema> FromFileAsync(string filePath, Func<JsonSchema, JsonReferenceResolver> referenceResolverFactory, CancellationToken cancellationToken = default(CancellationToken))
		{
			using FileStream stream = File.OpenRead(filePath);
			return FromJsonAsync(stream, filePath, referenceResolverFactory, cancellationToken);
		}

		public static Task<JsonSchema> FromUrlAsync(string url, CancellationToken cancellationToken = default(CancellationToken))
		{
			Func<JsonSchema, JsonReferenceResolver> referenceResolverFactory = JsonReferenceResolver.CreateJsonReferenceResolverFactory(new DefaultTypeNameGenerator());
			return FromUrlAsync(url, referenceResolverFactory, cancellationToken);
		}

		public static async Task<JsonSchema> FromUrlAsync(string url, Func<JsonSchema, JsonReferenceResolver> referenceResolverFactory, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await FromJsonAsync(await DynamicApis.HttpGetAsync(url, cancellationToken).ConfigureAwait(continueOnCapturedContext: false), url, referenceResolverFactory, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public static Task<JsonSchema> FromJsonAsync(string data, CancellationToken cancellationToken = default(CancellationToken))
		{
			return FromJsonAsync(data, null, cancellationToken);
		}

		public static Task<JsonSchema> FromJsonAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
		{
			Func<JsonSchema, JsonReferenceResolver> referenceResolverFactory = JsonReferenceResolver.CreateJsonReferenceResolverFactory(new DefaultTypeNameGenerator());
			return FromJsonAsync(stream, null, referenceResolverFactory, cancellationToken);
		}

		public static Task<JsonSchema> FromJsonAsync(string data, string documentPath, CancellationToken cancellationToken = default(CancellationToken))
		{
			Func<JsonSchema, JsonReferenceResolver> referenceResolverFactory = JsonReferenceResolver.CreateJsonReferenceResolverFactory(new DefaultTypeNameGenerator());
			return FromJsonAsync(data, documentPath, referenceResolverFactory, cancellationToken);
		}

		public static Task<JsonSchema> FromJsonAsync(string data, string documentPath, Func<JsonSchema, JsonReferenceResolver> referenceResolverFactory, CancellationToken cancellationToken = default(CancellationToken))
		{
			return JsonSchemaSerialization.FromJsonAsync(data, SchemaType.JsonSchema, documentPath, referenceResolverFactory, ContractResolver.Value, cancellationToken);
		}

		public static Task<JsonSchema> FromJsonAsync(Stream stream, string documentPath, Func<JsonSchema, JsonReferenceResolver> referenceResolverFactory, CancellationToken cancellationToken = default(CancellationToken))
		{
			return JsonSchemaSerialization.FromJsonAsync(stream, SchemaType.JsonSchema, documentPath, referenceResolverFactory, ContractResolver.Value, cancellationToken);
		}

		internal static JsonSchema FromJsonWithCurrentSettings(object obj)
		{
			string value = JsonConvert.SerializeObject(obj, JsonSchemaSerialization.CurrentSerializerSettings);
			return JsonConvert.DeserializeObject<JsonSchema>(value, JsonSchemaSerialization.CurrentSerializerSettings);
		}

		public bool Inherits(JsonSchema schema)
		{
			schema = schema.ActualSchema;
			if (InheritedSchema?.ActualSchema != schema)
			{
				return InheritedSchema?.Inherits(schema) ?? false;
			}
			return true;
		}

		public virtual bool IsNullable(SchemaType schemaType)
		{
			if (IsNullableRaw == true)
			{
				return true;
			}
			if (IsEnumeration && Enumeration.Contains(null))
			{
				return true;
			}
			if (Type.IsNull())
			{
				return true;
			}
			if ((Type == JsonObjectType.None || Type.IsNull()) && _oneOf.Any((JsonSchema o) => o.IsNullable(schemaType)))
			{
				return true;
			}
			JsonSchema actualSchema = ActualSchema;
			if (actualSchema != this && actualSchema.IsNullable(schemaType))
			{
				return true;
			}
			JsonSchema actualTypeSchema = ActualTypeSchema;
			if (actualTypeSchema != this && actualTypeSchema.IsNullable(schemaType))
			{
				return true;
			}
			return false;
		}

		public string ToJson()
		{
			return ToJson(Formatting.Indented);
		}

		public string ToJson(Formatting formatting)
		{
			string schemaVersion = SchemaVersion;
			SchemaVersion = "http://json-schema.org/draft-04/schema#";
			string result = JsonSchemaSerialization.ToJson(this, SchemaType.JsonSchema, ContractResolver.Value, formatting);
			SchemaVersion = schemaVersion;
			return result;
		}

		public JToken ToSampleJson()
		{
			SampleJsonDataGenerator sampleJsonDataGenerator = new SampleJsonDataGenerator();
			return sampleJsonDataGenerator.Generate(this);
		}

		public bool InheritsSchema(JsonSchema parentSchema)
		{
			if (parentSchema != null)
			{
				return ActualSchema.AllInheritedSchemas.Concat(new List<JsonSchema> { this }).Any((JsonSchema s) => s.ActualSchema == parentSchema.ActualSchema);
			}
			return false;
		}

		public ICollection<ValidationError> Validate(string jsonData, JsonSchemaValidatorSettings settings = null)
		{
			JsonSchemaValidator jsonSchemaValidator = new JsonSchemaValidator(settings);
			return jsonSchemaValidator.Validate(jsonData, ActualSchema);
		}

		public ICollection<ValidationError> Validate(JToken token, JsonSchemaValidatorSettings settings = null)
		{
			JsonSchemaValidator jsonSchemaValidator = new JsonSchemaValidator(settings);
			return jsonSchemaValidator.Validate(token, ActualSchema);
		}

		public ICollection<ValidationError> Validate(string jsonData, SchemaType schemaType, JsonSchemaValidatorSettings settings = null)
		{
			JsonSchemaValidator jsonSchemaValidator = new JsonSchemaValidator(settings);
			return jsonSchemaValidator.Validate(jsonData, ActualSchema, schemaType);
		}

		public ICollection<ValidationError> Validate(JToken token, SchemaType schemaType, JsonSchemaValidatorSettings settings = null)
		{
			JsonSchemaValidator jsonSchemaValidator = new JsonSchemaValidator(settings);
			return jsonSchemaValidator.Validate(token, ActualSchema, schemaType);
		}

		private static JsonObjectType ConvertStringToJsonObjectType(string value)
		{
			return value switch
			{
				"array" => JsonObjectType.Array, 
				"boolean" => JsonObjectType.Boolean, 
				"integer" => JsonObjectType.Integer, 
				"number" => JsonObjectType.Number, 
				"null" => JsonObjectType.Null, 
				"object" => JsonObjectType.Object, 
				"string" => JsonObjectType.String, 
				"file" => JsonObjectType.File, 
				_ => JsonObjectType.None, 
			};
		}

		private void Initialize()
		{
			if (Items == null)
			{
				Items = new ObservableCollection<JsonSchema>();
			}
			if (Properties == null)
			{
				Properties = new ObservableDictionary<string, JsonSchemaProperty>();
			}
			if (PatternProperties == null)
			{
				PatternProperties = new ObservableDictionary<string, JsonSchemaProperty>();
			}
			if (Definitions == null)
			{
				Definitions = new ObservableDictionary<string, JsonSchema>();
			}
			if (RequiredProperties == null)
			{
				RequiredProperties = new ObservableCollection<string>();
			}
			if (AllOf == null)
			{
				AllOf = new ObservableCollection<JsonSchema>();
			}
			if (AnyOf == null)
			{
				AnyOf = new ObservableCollection<JsonSchema>();
			}
			if (OneOf == null)
			{
				OneOf = new ObservableCollection<JsonSchema>();
			}
			if (Enumeration == null)
			{
				Enumeration = new Collection<object>();
			}
			if (EnumerationNames == null)
			{
				EnumerationNames = new Collection<string>();
			}
		}

		private static ObservableCollection<T> ToObservableCollection<T>(ICollection<T> value)
		{
			if (value == null)
			{
				return null;
			}
			return (value as ObservableCollection<T>) ?? new ObservableCollection<T>(value);
		}

		private static ObservableDictionary<string, T> ToObservableDictionary<T>(IDictionary<string, T> value)
		{
			if (value == null)
			{
				return null;
			}
			return (value as ObservableDictionary<string, T>) ?? new ObservableDictionary<string, T>(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JsonSchema GetActualSchema(List<JsonSchema> checkedSchemas)
		{
			if (checkedSchemas != null && checkedSchemas.Contains(this))
			{
				ThrowInvalidOperationException("Cyclic references detected.");
			}
			if (Reference == null && ((IJsonReferenceBase)this).ReferencePath != null)
			{
				ThrowInvalidOperationException("The schema reference path '" + ((IJsonReferenceBase)this).ReferencePath + "' has not been resolved.");
			}
			if (HasReference)
			{
				return GetActualSchemaReferences(checkedSchemas);
			}
			return this;
			static void ThrowInvalidOperationException(string message)
			{
				throw new InvalidOperationException(message);
			}
		}

		private JsonSchema GetActualSchemaReferences(List<JsonSchema> checkedSchemas)
		{
			if (checkedSchemas == null)
			{
				checkedSchemas = new List<JsonSchema>();
			}
			checkedSchemas.Add(this);
			if (HasAllOfSchemaReference)
			{
				return _allOf[0].GetActualSchema(checkedSchemas);
			}
			if (HasOneOfSchemaReference)
			{
				return _oneOf[0].GetActualSchema(checkedSchemas);
			}
			if (HasAnyOfSchemaReference)
			{
				return _anyOf[0].GetActualSchema(checkedSchemas);
			}
			return Reference.GetActualSchema(checkedSchemas);
		}

		public static PropertyRenameAndIgnoreSerializerContractResolver CreateJsonSerializerContractResolver(SchemaType schemaType)
		{
			IgnoreEmptyCollectionsContractResolver ignoreEmptyCollectionsContractResolver = new IgnoreEmptyCollectionsContractResolver();
			switch (schemaType)
			{
			case SchemaType.OpenApi3:
				ignoreEmptyCollectionsContractResolver.RenameProperty(typeof(JsonSchemaProperty), "x-readOnly", "readOnly");
				ignoreEmptyCollectionsContractResolver.RenameProperty(typeof(JsonSchemaProperty), "x-writeOnly", "writeOnly");
				ignoreEmptyCollectionsContractResolver.RenameProperty(typeof(JsonSchema), "x-nullable", "nullable");
				ignoreEmptyCollectionsContractResolver.RenameProperty(typeof(JsonSchema), "x-example", "example");
				ignoreEmptyCollectionsContractResolver.RenameProperty(typeof(JsonSchema), "x-deprecated", "deprecated");
				break;
			case SchemaType.Swagger2:
				ignoreEmptyCollectionsContractResolver.RenameProperty(typeof(JsonSchemaProperty), "x-readOnly", "readOnly");
				ignoreEmptyCollectionsContractResolver.RenameProperty(typeof(JsonSchema), "x-example", "example");
				break;
			default:
				ignoreEmptyCollectionsContractResolver.RenameProperty(typeof(JsonSchemaProperty), "x-readOnly", "readonly");
				break;
			}
			return ignoreEmptyCollectionsContractResolver;
		}

		[OnDeserialized]
		internal void OnDeserialized(StreamingContext ctx)
		{
			Initialize();
		}

		private void ResetTypeRaw()
		{
			_typeRaw = new Lazy<object>(delegate
			{
				JsonObjectType[] array = _jsonObjectTypeValues.Where((JsonObjectType v) => Type.HasFlag(v)).ToArray();
				if (array.Length > 1)
				{
					return new JArray(array.Select((JsonObjectType f) => new JValue(f.ToString().ToLowerInvariant())));
				}
				return (array.Length == 1) ? new JValue(array[0].ToString().ToLowerInvariant()) : null;
			});
		}

		private void RegisterProperties(ObservableDictionary<string, JsonSchemaProperty> oldCollection, ObservableDictionary<string, JsonSchemaProperty> newCollection)
		{
			if (oldCollection != null)
			{
				oldCollection.CollectionChanged -= _initializeSchemaCollectionEventHandler;
			}
			if (newCollection != null)
			{
				newCollection.CollectionChanged += _initializeSchemaCollectionEventHandler;
				InitializeSchemaCollection(newCollection, null);
			}
		}

		private void RegisterSchemaDictionary<T>(ObservableDictionary<string, T> oldCollection, ObservableDictionary<string, T> newCollection) where T : JsonSchema
		{
			if (oldCollection != null)
			{
				oldCollection.CollectionChanged -= _initializeSchemaCollectionEventHandler;
			}
			if (newCollection != null)
			{
				newCollection.CollectionChanged += _initializeSchemaCollectionEventHandler;
				InitializeSchemaCollection(newCollection, null);
			}
		}

		private void RegisterSchemaCollection(ObservableCollection<JsonSchema> oldCollection, ObservableCollection<JsonSchema> newCollection)
		{
			if (oldCollection != null)
			{
				oldCollection.CollectionChanged -= _initializeSchemaCollectionEventHandler;
			}
			if (newCollection != null)
			{
				newCollection.CollectionChanged += _initializeSchemaCollectionEventHandler;
				InitializeSchemaCollection(newCollection, null);
			}
		}

		private void InitializeSchemaCollection(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (sender is ObservableDictionary<string, JsonSchemaProperty> observableDictionary)
			{
				{
					foreach (KeyValuePair<string, JsonSchemaProperty> item in observableDictionary)
					{
						item.Value.Name = item.Key;
						item.Value.Parent = this;
					}
					return;
				}
			}
			if (sender is ObservableCollection<JsonSchema> observableCollection)
			{
				{
					foreach (JsonSchema item2 in observableCollection)
					{
						item2.Parent = this;
					}
					return;
				}
			}
			if (!(sender is ObservableDictionary<string, JsonSchema> observableDictionary2))
			{
				return;
			}
			KeyValuePair<string, JsonSchema>[] array = observableDictionary2.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				KeyValuePair<string, JsonSchema> keyValuePair = array[i];
				if (keyValuePair.Value == null)
				{
					observableDictionary2.Remove(keyValuePair.Key);
				}
				else
				{
					keyValuePair.Value.Parent = this;
				}
			}
		}
	}
}
