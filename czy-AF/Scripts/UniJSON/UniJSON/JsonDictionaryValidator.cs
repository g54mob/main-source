using System;
using System.Collections.Generic;
using System.Linq;

namespace UniJSON
{
	public class JsonDictionaryValidator<T> : IJsonSchemaValidator
	{
		private List<string> m_required = new List<string>();

		private Dictionary<string, string[]> m_dependencies;

		private Dictionary<string, object> m_validValueMap = new Dictionary<string, object>();

		public int MaxProperties { get; set; }

		public int MinProperties { get; set; }

		public List<string> Required => m_required;

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

		public JsonDictionaryValidator()
		{
			AdditionalProperties = JsonSchema.FromType<T>();
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
				foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item2 in value.ObjectItems())
				{
					Dependencies.Add(item2.Key.GetString(), (from x in item2.Value.ArrayItems()
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
		}

		public JsonSchemaValidationException Validate<S>(JsonSchemaValidationContext c, S o)
		{
			if (o == null)
			{
				return new JsonSchemaValidationException(c, "null");
			}
			if (!(o is IDictionary<string, T> dictionary))
			{
				return new JsonSchemaValidationException(c, "not dictionary");
			}
			if (Required != null)
			{
				foreach (string item in Required)
				{
					using (c.Push(item))
					{
					}
				}
			}
			if (AdditionalProperties != null)
			{
				foreach (KeyValuePair<string, T> item2 in dictionary)
				{
					using (c.Push(item2.Key))
					{
						JsonSchemaValidationException ex = AdditionalProperties.Validator.Validate(c, item2.Value);
						if (ex != null)
						{
							return ex;
						}
					}
				}
			}
			return null;
		}

		public void Serialize<S>(IFormatter f, JsonSchemaValidationContext c, S o)
		{
			m_validValueMap.Clear();
			Dictionary<string, T> dictionary = o as Dictionary<string, T>;
			f.BeginMap(dictionary.Count);
			foreach (KeyValuePair<string, T> item in dictionary)
			{
				f.Key(item.Key);
				AdditionalProperties.Validator.Serialize(f, c, item.Value);
			}
			f.EndMap();
		}

		public void Deserialize<U, V>(ListTreeNode<U> src, ref V dst) where U : IListTreeItem, IValue<U>
		{
			src.Deserialize(ref dst);
		}
	}
	public static class JsonDictionaryValidator
	{
		public static JsonDictionaryValidator<T> Create<T>()
		{
			return new JsonDictionaryValidator<T>();
		}

		public static JsonDictionaryValidator<float> CreateSingle()
		{
			return Create<float>();
		}

		public static JsonDictionaryValidator<int> CreateInt32()
		{
			return Create<int>();
		}

		public static JsonDictionaryValidator<bool> CreateBoolean()
		{
			return Create<bool>();
		}
	}
}
