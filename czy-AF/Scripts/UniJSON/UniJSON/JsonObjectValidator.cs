using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UniJSON
{
	public class JsonObjectValidator : IJsonSchemaValidator
	{
		private static class GenericFieldView<T>
		{
			public static FieldInfo[] GetFields()
			{
				return typeof(T).GetFields(BindingFlags.Instance | BindingFlags.Public);
			}

			public static void CreateFieldProcessors<G, D>(Func<FieldInfo, D> creator, Dictionary<string, D> processors)
			{
				FieldInfo[] fields = GetFields();
				foreach (FieldInfo fieldInfo in fields)
				{
					processors.Add(fieldInfo.Name, creator(fieldInfo));
				}
			}
		}

		internal class ValidationResult
		{
			public bool IsIgnorable;

			public JsonSchemaValidationException Ex;
		}

		public static class GenericValidator<T>
		{
			private class ObjectValidator
			{
				private delegate JsonSchemaValidationException FieldValidator(JsonSchema s, JsonSchemaValidationContext c, T o, out bool isIgnorable);

				private Dictionary<string, FieldValidator> m_validators;

				private static FieldValidator CreateFieldValidator(FieldInfo fi)
				{
					return GenericInvokeCallFactory.StaticFunc<FieldInfo, FieldValidator>(typeof(ObjectValidator).GetMethod("_CreateFieldValidator", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(fi.FieldType))(fi);
				}

				private static FieldValidator _CreateFieldValidator<U>(FieldInfo fi)
				{
					Func<T, U> getter = (T t) => (U)fi.GetValue(t);
					return delegate(JsonSchema s, JsonSchemaValidationContext c, T o, out bool isIgnorable)
					{
						IJsonSchemaValidator validator = s.Validator;
						using (c.Push(fi.Name))
						{
							U val = getter(o);
							JsonSchemaValidationException ex = validator.Validate(c, val);
							isIgnorable = ex != null && s.IsExplicitlyIgnorableValue(val);
							return ex;
						}
					};
				}

				public ObjectValidator()
				{
					Dictionary<string, FieldValidator> dictionary = new Dictionary<string, FieldValidator>();
					GenericFieldView<T>.CreateFieldProcessors<ObjectValidator, FieldValidator>(CreateFieldValidator, dictionary);
					m_validators = dictionary;
				}

				public JsonSchemaValidationException ValidateProperty(HashSet<string> required, KeyValuePair<string, JsonSchema> property, JsonSchemaValidationContext c, T o, out bool isIgnorable)
				{
					string key = property.Key;
					JsonSchema value = property.Value;
					isIgnorable = false;
					if (m_validators.TryGetValue(key, out var value2))
					{
						bool flag = required?.Contains(key) ?? false;
						bool isIgnorable2;
						JsonSchemaValidationException ex = value2(value, c, o, out isIgnorable2);
						if (ex != null)
						{
							isIgnorable = !flag && isIgnorable2;
							if (flag || c.EnableDiagnosisForNotRequiredFields)
							{
								return ex;
							}
						}
					}
					return null;
				}

				public JsonSchemaValidationException Validate(HashSet<string> required, Dictionary<string, JsonSchema> properties, JsonSchemaValidationContext c, T o)
				{
					foreach (KeyValuePair<string, JsonSchema> property in properties)
					{
						bool isIgnorable;
						JsonSchemaValidationException ex = ValidateProperty(required, property, c, o, out isIgnorable);
						if (ex != null && !isIgnorable)
						{
							return ex;
						}
					}
					return null;
				}

				public void ValidationResults(HashSet<string> required, Dictionary<string, JsonSchema> properties, JsonSchemaValidationContext c, T o, Dictionary<string, ValidationResult> results)
				{
					foreach (KeyValuePair<string, JsonSchema> property in properties)
					{
						bool isIgnorable;
						JsonSchemaValidationException ex = ValidateProperty(required, property, c, o, out isIgnorable);
						results.Add(property.Key, new ValidationResult
						{
							IsIgnorable = isIgnorable,
							Ex = ex
						});
					}
				}
			}

			private static ObjectValidator s_validator;

			private static void prepareValidator()
			{
				if (s_validator == null)
				{
					s_validator = new ObjectValidator();
				}
			}

			public static JsonSchemaValidationException Validate(HashSet<string> required, Dictionary<string, JsonSchema> properties, JsonSchemaValidationContext c, T o)
			{
				prepareValidator();
				return s_validator.Validate(required, properties, c, o);
			}

			internal static void ValidationResults(HashSet<string> required, Dictionary<string, JsonSchema> properties, JsonSchemaValidationContext c, T o, Dictionary<string, ValidationResult> results)
			{
				prepareValidator();
				s_validator.ValidationResults(required, properties, c, o, results);
			}
		}

		private static class GenericSerializer<T>
		{
			private class Serializer
			{
				private delegate void FieldSerializer(JsonSchema s, JsonSchemaValidationContext c, IFormatter f, T o, Dictionary<string, ValidationResult> vRes, string[] deps);

				private Dictionary<string, FieldSerializer> m_serializers;

				private static FieldSerializer CreateFieldSerializer(FieldInfo fi)
				{
					return GenericInvokeCallFactory.StaticFunc<FieldInfo, FieldSerializer>(typeof(Serializer).GetMethod("_CreateFieldSerializer", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(fi.FieldType))(fi);
				}

				private static FieldSerializer _CreateFieldSerializer<U>(FieldInfo fi)
				{
					Func<T, U> getter = (T t) => (U)fi.GetValue(t);
					return delegate(JsonSchema s, JsonSchemaValidationContext c, IFormatter f, T o, Dictionary<string, ValidationResult> vRes, string[] deps)
					{
						IJsonSchemaValidator validator = s.Validator;
						U value = getter(o);
						if (vRes[fi.Name].Ex == null)
						{
							if (deps != null)
							{
								foreach (string key in deps)
								{
									if (vRes[key].Ex != null)
									{
										return;
									}
								}
							}
							f.Key(fi.Name);
							validator.Serialize(f, c, value);
						}
					};
				}

				public Serializer()
				{
					Dictionary<string, FieldSerializer> dictionary = new Dictionary<string, FieldSerializer>();
					GenericFieldView<T>.CreateFieldProcessors<Serializer, FieldSerializer>(CreateFieldSerializer, dictionary);
					m_serializers = dictionary;
				}

				public void Serialize(JsonObjectValidator objectValidator, IFormatter f, JsonSchemaValidationContext c, T o)
				{
					Dictionary<string, ValidationResult> dictionary = new Dictionary<string, ValidationResult>();
					GenericValidator<T>.ValidationResults(objectValidator.Required, objectValidator.Properties, c, o, dictionary);
					f.BeginMap(objectValidator.Properties.Count());
					foreach (KeyValuePair<string, JsonSchema> property in objectValidator.Properties)
					{
						string key = property.Key;
						JsonSchema value = property.Value;
						string[] value2 = null;
						objectValidator.Dependencies.TryGetValue(key, out value2);
						if (m_serializers.TryGetValue(key, out var value3))
						{
							value3(value, c, f, o, dictionary, value2);
						}
					}
					f.EndMap();
				}
			}

			private static FieldInfo[] s_fields;

			private static Serializer s_serializer;

			public static void Serialize(JsonObjectValidator objectValidator, IFormatter f, JsonSchemaValidationContext c, T value)
			{
				if (s_serializer == null)
				{
					s_serializer = new Serializer();
				}
				s_serializer.Serialize(objectValidator, f, c, value);
			}
		}

		public static class GenericDeserializer<S, T> where S : IListTreeItem, IValue<S>
		{
			private delegate T Deserializer(ListTreeNode<S> src);

			private delegate void FieldSetter(ListTreeNode<S> s, object o);

			private static Deserializer s_d;

			private static FieldSetter GetFieldDeserializer<U>(FieldInfo fi)
			{
				return delegate(ListTreeNode<S> s, object o)
				{
					U value = default(U);
					s.Deserialize(ref value);
					fi.SetValue(o, value);
				};
			}

			public static U DeserializeField<U>(JsonSchema prop, ListTreeNode<S> s)
			{
				U dst = default(U);
				prop.Validator.Deserialize(s, ref dst);
				return dst;
			}

			public static void Deserialize(ListTreeNode<S> src, ref T dst, Dictionary<string, JsonSchema> props)
			{
				if (s_d == null)
				{
					FieldInfo[] fields = typeof(T).GetFields(BindingFlags.Instance | BindingFlags.Public);
					Dictionary<Utf8String, FieldSetter> fieldDeserializers = fields.ToDictionary((FieldInfo x) => Utf8String.From(x.Name), delegate(FieldInfo x)
					{
						if (!props.TryGetValue(x.Name, out var prop))
						{
							return (FieldSetter)null;
						}
						MethodInfo method = typeof(GenericDeserializer<S, T>).GetMethod("DeserializeField", BindingFlags.Static | BindingFlags.Public);
						MethodInfo g = method.MakeGenericMethod(x.FieldType);
						return delegate(ListTreeNode<S> s, object o)
						{
							object value = g.Invoke(null, new object[2] { prop, s });
							x.SetValue(o, value);
						};
					});
					s_d = delegate(ListTreeNode<S> s)
					{
						if (!s.IsMap())
						{
							throw new ArgumentException(s.Value.ValueType.ToString());
						}
						object obj = Activator.CreateInstance<T>();
						foreach (KeyValuePair<ListTreeNode<S>, ListTreeNode<S>> item in s.ObjectItems())
						{
							if (fieldDeserializers.TryGetValue(item.Key.GetUtf8String(), out var value))
							{
								value?.Invoke(item.Value, obj);
							}
						}
						return (T)obj;
					};
				}
				dst = s_d(src);
			}
		}

		private HashSet<string> m_required = new HashSet<string>();

		private Dictionary<string, JsonSchema> m_props;

		private Dictionary<string, string[]> m_dependencies;

		public int MaxProperties { get; set; }

		public int MinProperties { get; set; }

		public HashSet<string> Required => m_required;

		public Dictionary<string, JsonSchema> Properties
		{
			get
			{
				if (m_props == null)
				{
					m_props = new Dictionary<string, JsonSchema>();
				}
				return m_props;
			}
		}

		public string PatternProperties { get; private set; }

		public JsonSchema AdditionalProperties { get; set; }

		public Dictionary<string, string[]> Dependencies
		{
			get
			{
				if (m_dependencies == null)
				{
					m_dependencies = new Dictionary<string, string[]>();
				}
				return m_dependencies;
			}
		}

		public void AddProperty(IFileSystemAccessor fs, string key, ListTreeNode<JsonValue> value)
		{
			JsonSchema jsonSchema = new JsonSchema();
			jsonSchema.Parse(fs, value, key);
			if (Properties.ContainsKey(key))
			{
				if (jsonSchema.Validator != null)
				{
					Properties[key].Validator.Merge(jsonSchema.Validator);
				}
			}
			else
			{
				Properties.Add(key, jsonSchema);
			}
		}

		public override int GetHashCode()
		{
			return 6;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is JsonObjectValidator jsonObjectValidator))
			{
				return false;
			}
			if (Properties.Count != jsonObjectValidator.Properties.Count)
			{
				return false;
			}
			foreach (KeyValuePair<string, JsonSchema> property in Properties)
			{
				if (jsonObjectValidator.Properties.TryGetValue(property.Key, out var value))
				{
					if (!value.Equals(property.Value))
					{
						Console.WriteLine($"{property.Key} is not equals");
						_ = property.Value.Validator;
						_ = value.Validator;
						return false;
					}
					continue;
				}
				return false;
			}
			if (Required.Count != jsonObjectValidator.Required.Count)
			{
				return false;
			}
			if (!Required.OrderBy((string x) => x).SequenceEqual(jsonObjectValidator.Required.OrderBy((string x) => x)))
			{
				return false;
			}
			if (Dependencies.Count != jsonObjectValidator.Dependencies.Count)
			{
				return false;
			}
			foreach (KeyValuePair<string, string[]> dependency in Dependencies)
			{
				if (!dependency.Value.OrderBy((string x) => x).SequenceEqual(jsonObjectValidator.Dependencies[dependency.Key].OrderBy((string x) => x)))
				{
					return false;
				}
			}
			if (!(AdditionalProperties == null) || !(jsonObjectValidator.AdditionalProperties == null))
			{
				if (AdditionalProperties == null)
				{
					return false;
				}
				if (jsonObjectValidator.AdditionalProperties == null)
				{
					return false;
				}
				if (!AdditionalProperties.Equals(jsonObjectValidator.AdditionalProperties))
				{
					return false;
				}
			}
			return true;
		}

		public void Merge(IJsonSchemaValidator obj)
		{
			if (!(obj is JsonObjectValidator jsonObjectValidator))
			{
				throw new ArgumentException();
			}
			foreach (KeyValuePair<string, JsonSchema> property in jsonObjectValidator.Properties)
			{
				if (Properties.ContainsKey(property.Key))
				{
					Properties[property.Key] = property.Value;
				}
				else
				{
					Properties.Add(property.Key, property.Value);
				}
			}
			foreach (string item in jsonObjectValidator.Required)
			{
				Required.Add(item);
			}
			if (jsonObjectValidator.AdditionalProperties != null)
			{
				if (AdditionalProperties != null)
				{
					throw new NotImplementedException();
				}
				AdditionalProperties = jsonObjectValidator.AdditionalProperties;
			}
		}

		public bool FromJsonSchema(IFileSystemAccessor fs, string key, ListTreeNode<JsonValue> value)
		{
			switch (key)
			{
			case "maxProperties":
				MaxProperties = value.GetInt32();
				return true;
			case "minProperties":
				MinProperties = value.GetInt32();
				return true;
			case "required":
				foreach (ListTreeNode<JsonValue> item in value.ArrayItems())
				{
					m_required.Add(item.GetString());
				}
				return true;
			case "properties":
				foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item2 in value.ObjectItems())
				{
					AddProperty(fs, item2.Key.GetString(), item2.Value);
				}
				return true;
			case "patternProperties":
				PatternProperties = value.GetString();
				return true;
			case "additionalProperties":
			{
				JsonSchema jsonSchema = new JsonSchema();
				jsonSchema.Parse(fs, value, "additionalProperties");
				AdditionalProperties = jsonSchema;
				return true;
			}
			case "dependencies":
				foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item3 in value.ObjectItems())
				{
					Dependencies.Add(item3.Key.GetString(), (from x in item3.Value.ArrayItems()
						select x.GetString()).ToArray());
				}
				return true;
			case "propertyNames":
				return true;
			default:
				return false;
			}
		}

		public void ToJsonSchema(IFormatter f)
		{
			f.Key("type");
			f.Value("object");
			if (Properties.Count <= 0)
			{
				return;
			}
			f.Key("properties");
			f.BeginMap(Properties.Count);
			foreach (KeyValuePair<string, JsonSchema> property in Properties)
			{
				f.Key(property.Key);
				property.Value.ToJson(f);
			}
			f.EndMap();
		}

		public JsonSchemaValidationException Validate<T>(JsonSchemaValidationContext c, T o)
		{
			if (o == null)
			{
				return new JsonSchemaValidationException(c, "null");
			}
			if (Properties.Count < MinProperties)
			{
				return new JsonSchemaValidationException(c, "no properties");
			}
			return GenericValidator<T>.Validate(Required, Properties, c, o);
		}

		public void Serialize<T>(IFormatter f, JsonSchemaValidationContext c, T value)
		{
			GenericSerializer<T>.Serialize(this, f, c, value);
		}

		public void Deserialize<T, U>(ListTreeNode<T> src, ref U dst) where T : IListTreeItem, IValue<T>
		{
			GenericDeserializer<T, U>.Deserialize(src, ref dst, Properties);
		}
	}
}
