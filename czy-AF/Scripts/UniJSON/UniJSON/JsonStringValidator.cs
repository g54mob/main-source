using System;
using System.Text.RegularExpressions;

namespace UniJSON
{
	public class JsonStringValidator : IJsonSchemaValidator
	{
		public int? MaxLength { get; set; }

		public int? MinLength { get; set; }

		public Regex Pattern { get; set; }

		public override int GetHashCode()
		{
			return 4;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is JsonStringValidator jsonStringValidator))
			{
				return false;
			}
			if (MaxLength != jsonStringValidator.MaxLength)
			{
				return false;
			}
			if (MinLength != jsonStringValidator.MinLength)
			{
				return false;
			}
			if (Pattern != null || jsonStringValidator.Pattern != null)
			{
				if (Pattern == null)
				{
					return false;
				}
				if (jsonStringValidator.Pattern == null)
				{
					return false;
				}
				if (Pattern.ToString() != jsonStringValidator.Pattern.ToString())
				{
					return false;
				}
			}
			return true;
		}

		public void Merge(IJsonSchemaValidator obj)
		{
			if (!(obj is JsonStringValidator jsonStringValidator))
			{
				throw new ArgumentException();
			}
			MaxLength = jsonStringValidator.MaxLength;
			MinLength = jsonStringValidator.MinLength;
			Pattern = jsonStringValidator.Pattern;
		}

		public bool FromJsonSchema(IFileSystemAccessor fs, string key, ListTreeNode<JsonValue> value)
		{
			switch (key)
			{
			case "maxLength":
				MaxLength = value.GetInt32();
				return true;
			case "minLength":
				MinLength = value.GetInt32();
				return true;
			case "pattern":
				Pattern = new Regex(value.GetString().Replace("\\\\", "\\"));
				return true;
			default:
				return false;
			}
		}

		public void ToJsonSchema(IFormatter f)
		{
			f.Key("type");
			f.Value("string");
		}

		public JsonSchemaValidationException Validate<T>(JsonSchemaValidationContext c, T o)
		{
			if (o == null)
			{
				return new JsonSchemaValidationException(c, "null");
			}
			string text = o as string;
			if (MinLength.HasValue && text.Length < MinLength)
			{
				return new JsonSchemaValidationException(c, $"minlength: {text.Length}<{MinLength.Value}");
			}
			if (MaxLength.HasValue && text.Length > MaxLength)
			{
				return new JsonSchemaValidationException(c, $"maxlength: {text.Length}>{MaxLength.Value}");
			}
			if (Pattern != null && !Pattern.IsMatch(text))
			{
				return new JsonSchemaValidationException(c, $"pattern: {Pattern} not match {text}");
			}
			return null;
		}

		public void Serialize<T>(IFormatter f, JsonSchemaValidationContext c, T o)
		{
			f.Value(GenericCast<T, string>.Cast(o));
		}

		public void Deserialize<T, U>(ListTreeNode<T> src, ref U dst) where T : IListTreeItem, IValue<T>
		{
			dst = GenericCast<string, U>.Cast(src.GetString());
		}
	}
}
