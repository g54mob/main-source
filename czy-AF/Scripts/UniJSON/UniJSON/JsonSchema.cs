using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UniJSON
{
	public class JsonSchema : IEquatable<JsonSchema>
	{
		public string Schema;

		private string m_title;

		private string m_desc;

		private Stack<string> m_context = new Stack<string>();

		private static Utf8String s_ref = Utf8String.From("$ref");

		public string Title
		{
			get
			{
				return m_title;
			}
			private set
			{
				if (value == null)
				{
					m_title = "";
				}
				else
				{
					m_title = value.Trim();
				}
			}
		}

		public string Description
		{
			get
			{
				return m_desc;
			}
			private set
			{
				if (value == null)
				{
					m_desc = "";
				}
				else
				{
					m_desc = value.Trim();
				}
			}
		}

		public object Default { get; private set; }

		public IJsonSchemaValidator Validator { get; set; }

		public bool SkipComparison { get; set; }

		public object ExplicitIgnorableValue { private get; set; }

		public int ExplicitIgnorableItemLength { private get; set; }

		public override string ToString()
		{
			return $"<{Title}>";
		}

		public override int GetHashCode()
		{
			return 1;
		}

		public override bool Equals(object obj)
		{
			JsonSchema jsonSchema = obj as JsonSchema;
			if (jsonSchema == null)
			{
				return false;
			}
			return Equals(jsonSchema);
		}

		public bool Equals(JsonSchema rhs)
		{
			if (SkipComparison)
			{
				return true;
			}
			if (rhs.SkipComparison)
			{
				return true;
			}
			return Validator.Equals(rhs.Validator);
		}

		public static bool operator ==(JsonSchema obj1, JsonSchema obj2)
		{
			if ((object)obj1 == obj2)
			{
				return true;
			}
			if ((object)obj1 == null)
			{
				return false;
			}
			if ((object)obj2 == null)
			{
				return false;
			}
			return obj1.Equals(obj2);
		}

		public static bool operator !=(JsonSchema obj1, JsonSchema obj2)
		{
			return !(obj1 == obj2);
		}

		public static JsonSchema FromType<T>()
		{
			return FromType(typeof(T));
		}

		public static JsonSchema FromType(Type t, BaseJsonSchemaAttribute a = null, ItemJsonSchemaAttribute ia = null)
		{
			JsonSchemaAttribute jsonSchemaAttribute = t.GetCustomAttributes(typeof(JsonSchemaAttribute), inherit: true).FirstOrDefault() as JsonSchemaAttribute;
			if (a == null)
			{
				a = ((jsonSchemaAttribute != null) ? jsonSchemaAttribute : new JsonSchemaAttribute());
			}
			else
			{
				a.Merge(jsonSchemaAttribute);
			}
			if (ia == null)
			{
				ia = t.GetCustomAttributes(typeof(ItemJsonSchemaAttribute), inherit: true).FirstOrDefault() as ItemJsonSchemaAttribute;
			}
			IJsonSchemaValidator jsonSchemaValidator = null;
			bool skipComparison = a.SkipSchemaComparison;
			if (t == typeof(object))
			{
				skipComparison = true;
			}
			if (a.EnumValues == null)
			{
				jsonSchemaValidator = ((!t.IsEnum) ? JsonSchemaValidatorFactory.Create(t, a, ia) : JsonEnumValidator.Create(t, a.EnumSerializationType, a.EnumExcludes));
			}
			else
			{
				try
				{
					jsonSchemaValidator = JsonEnumValidator.Create(a.EnumValues, a.EnumSerializationType);
				}
				catch (Exception)
				{
					throw new Exception(string.Join(", ", a.EnumValues.Select((object x) => x.ToString()).ToArray()));
				}
			}
			return new JsonSchema
			{
				Title = a.Title,
				Description = a.Description,
				Validator = jsonSchemaValidator,
				SkipComparison = skipComparison,
				ExplicitIgnorableValue = a.ExplicitIgnorableValue,
				ExplicitIgnorableItemLength = a.ExplicitIgnorableItemLength
			};
		}

		private static ValueNodeType ParseValueType(string type)
		{
			try
			{
				return (ValueNodeType)Enum.Parse(typeof(ValueNodeType), type, ignoreCase: true);
			}
			catch (ArgumentException)
			{
				throw new ArgumentException($"unknown type: {type}");
			}
		}

		public void Parse(IFileSystemAccessor fs, ListTreeNode<JsonValue> root, string Key)
		{
			m_context.Push(Key);
			CompositionType compositionType = CompositionType.Unknown;
			List<JsonSchema> list = new List<JsonSchema>();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item2 in root.ObjectItems())
			{
				switch (item2.Key.GetString())
				{
				case "$schema":
					Schema = item2.Value.GetString();
					break;
				case "$ref":
				{
					IFileSystemAccessor fileSystemAccessor = fs.Get(item2.Value.GetString());
					ListTreeNode<JsonValue> root2 = JsonParser.Parse(fileSystemAccessor.ReadAllText());
					Parse(fileSystemAccessor, root2, "$ref");
					break;
				}
				case "title":
					Title = item2.Value.GetString();
					break;
				case "description":
					Description = item2.Value.GetString();
					break;
				case "default":
					Default = item2.Value;
					break;
				case "type":
					if (Validator == null)
					{
						Validator = JsonSchemaValidatorFactory.Create(item2.Value.GetString());
					}
					break;
				case "enum":
					Validator = JsonEnumValidator.Create(item2.Value);
					break;
				case "anyOf":
				case "allOf":
					compositionType = (CompositionType)Enum.Parse(typeof(CompositionType), item2.Key.GetString(), ignoreCase: true);
					foreach (ListTreeNode<JsonValue> item3 in item2.Value.ArrayItems())
					{
						if (item3.ContainsKey(s_ref))
						{
							JsonSchema item = ParseFromPath(fs.Get(item3[s_ref].GetString()));
							list.Add(item);
						}
						else
						{
							JsonSchema jsonSchema = new JsonSchema();
							jsonSchema.Parse(fs, item3, compositionType.ToString());
							list.Add(jsonSchema);
						}
					}
					Composite(compositionType, list);
					break;
				default:
					if (Validator == null || !Validator.FromJsonSchema(fs, item2.Key.GetString(), item2.Value))
					{
						throw new NotImplementedException($"unknown key: {item2.Key}");
					}
					break;
				case "const":
				case "oneOf":
				case "not":
				case "format":
				case "gltf_detailedDescription":
				case "gltf_webgl":
				case "gltf_uriType":
					break;
				}
			}
			m_context.Pop();
			if (Validator == null)
			{
				SkipComparison = true;
			}
		}

		private void Composite(CompositionType compositionType, List<JsonSchema> composition)
		{
			switch (compositionType)
			{
			case CompositionType.AllOf:
				if (composition.Count == 1)
				{
					if (Validator == null)
					{
						Validator = composition[0].Validator;
					}
					else
					{
						Validator.Merge(composition[0].Validator);
					}
					break;
				}
				throw new NotImplementedException();
			case CompositionType.AnyOf:
				if (Validator == null)
				{
					if (composition.Count == 1)
					{
						throw new NotImplementedException();
					}
					Validator = JsonEnumValidator.Create(composition, EnumSerializationType.AsString);
				}
				break;
			default:
				throw new NotImplementedException();
			}
		}

		public static JsonSchema ParseFromPath(IFileSystemAccessor fs)
		{
			ListTreeNode<JsonValue> root = JsonParser.Parse(fs.ReadAllText());
			JsonSchema jsonSchema = new JsonSchema();
			jsonSchema.Parse(fs, root, "__ParseFromPath__" + fs.ToString());
			return jsonSchema;
		}

		public void Serialize<T>(IFormatter f, T o, JsonSchemaValidationContext c = null)
		{
			if (c == null)
			{
				c = new JsonSchemaValidationContext(o)
				{
					EnableDiagnosisForNotRequiredFields = true
				};
			}
			JsonSchemaValidationException ex = Validator.Validate(c, o);
			if (ex != null)
			{
				throw ex;
			}
			Validator.Serialize(f, c, o);
		}

		public void ToJson(IFormatter f)
		{
			f.BeginMap(2);
			if (!string.IsNullOrEmpty(Title))
			{
				f.Key("title");
				f.Value(Title);
			}
			if (!string.IsNullOrEmpty(Description))
			{
				f.Key("description");
				f.Value(Description);
			}
			Validator.ToJsonSchema(f);
			f.EndMap();
		}

		public bool IsExplicitlyIgnorableValue<T>(T obj)
		{
			if (obj == null)
			{
				return ExplicitIgnorableValue == null;
			}
			ICollection collection = obj as ICollection;
			if (ExplicitIgnorableItemLength != -1 && collection != null)
			{
				return collection.Count == ExplicitIgnorableItemLength;
			}
			return obj.Equals(ExplicitIgnorableValue);
		}
	}
}
