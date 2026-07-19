using System;

namespace UniJSON
{
	public class JsonIntValidator : IJsonSchemaValidator
	{
		public int? MultipleOf { get; set; }

		public int? Maximum { get; set; }

		public bool ExclusiveMaximum { get; set; }

		public int? Minimum { get; set; }

		public bool ExclusiveMinimum { get; set; }

		public override int GetHashCode()
		{
			return 2;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is JsonIntValidator jsonIntValidator))
			{
				return false;
			}
			if (MultipleOf != jsonIntValidator.MultipleOf)
			{
				Console.WriteLine("MultipleOf");
				return false;
			}
			if (Maximum != jsonIntValidator.Maximum)
			{
				Console.WriteLine("Maximum");
				return false;
			}
			if (ExclusiveMaximum != jsonIntValidator.ExclusiveMaximum)
			{
				Console.WriteLine("ExclusiveMaximum");
				return false;
			}
			if (Minimum != jsonIntValidator.Minimum)
			{
				Console.WriteLine("Minimum");
				return false;
			}
			if (ExclusiveMinimum != jsonIntValidator.ExclusiveMinimum)
			{
				Console.WriteLine("ExclusiveMinimum");
				return false;
			}
			return true;
		}

		public bool FromJsonSchema(IFileSystemAccessor fs, string key, ListTreeNode<JsonValue> value)
		{
			switch (key)
			{
			case "multipleOf":
				MultipleOf = value.GetInt32();
				return true;
			case "maximum":
				Maximum = value.GetInt32();
				return true;
			case "exclusiveMaximum":
				ExclusiveMaximum = value.GetBoolean();
				return true;
			case "minimum":
				Minimum = value.GetInt32();
				return true;
			case "exclusiveMinimum":
				ExclusiveMinimum = value.GetBoolean();
				return true;
			default:
				return false;
			}
		}

		public void ToJsonSchema(IFormatter f)
		{
			f.Key("type");
			f.Value("integer");
			if (Minimum.HasValue)
			{
				f.Key("minimum");
				f.Value(Minimum.Value);
			}
			if (Maximum.HasValue)
			{
				f.Key("maximum");
				f.Value(Maximum.Value);
			}
		}

		public void Merge(IJsonSchemaValidator obj)
		{
			if (!(obj is JsonIntValidator jsonIntValidator))
			{
				throw new ArgumentException();
			}
			MultipleOf = jsonIntValidator.MultipleOf;
			Maximum = jsonIntValidator.Maximum;
			ExclusiveMaximum = jsonIntValidator.ExclusiveMaximum;
			Minimum = jsonIntValidator.Minimum;
			ExclusiveMinimum = jsonIntValidator.ExclusiveMinimum;
		}

		public JsonSchemaValidationException Validate<T>(JsonSchemaValidationContext c, T o)
		{
			try
			{
				int num = GenericCast<T, int>.Cast(o);
				if (Minimum.HasValue)
				{
					if (ExclusiveMinimum)
					{
						if (num <= Minimum.Value)
						{
							return new JsonSchemaValidationException(c, $"minimum: ! {num}>{Minimum.Value}");
						}
					}
					else if (num < Minimum.Value)
					{
						return new JsonSchemaValidationException(c, $"minimum: ! {num}>={Minimum.Value}");
					}
				}
				if (Maximum.HasValue)
				{
					if (ExclusiveMaximum)
					{
						if (num >= Maximum.Value)
						{
							return new JsonSchemaValidationException(c, $"maximum: ! {num}<{Maximum.Value}");
						}
					}
					else if (num > Maximum.Value)
					{
						return new JsonSchemaValidationException(c, $"maximum: ! {num}<={Maximum.Value}");
					}
				}
				if (MultipleOf.HasValue && num % MultipleOf.Value != 0)
				{
					return new JsonSchemaValidationException(c, $"multipleOf: {num}%{MultipleOf.Value}");
				}
				return null;
			}
			catch (Exception ex)
			{
				return new JsonSchemaValidationException(c, ex);
			}
		}

		public void Serialize<T>(IFormatter f, JsonSchemaValidationContext c, T o)
		{
			f.Serialize(GenericCast<T, int>.Cast(o));
		}

		public void Deserialize<T, U>(ListTreeNode<T> src, ref U dst) where T : IListTreeItem, IValue<T>
		{
			dst = GenericCast<int, U>.Cast(src.GetInt32());
		}
	}
}
