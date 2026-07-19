using System;

namespace UniJSON
{
	public class JsonNumberValidator : IJsonSchemaValidator
	{
		public double? MultipleOf { get; set; }

		public double? Maximum { get; set; }

		public bool ExclusiveMaximum { get; set; }

		public double? Minimum { get; set; }

		public bool ExclusiveMinimum { get; set; }

		public override int GetHashCode()
		{
			return 3;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is JsonNumberValidator jsonNumberValidator))
			{
				return false;
			}
			if (MultipleOf != jsonNumberValidator.MultipleOf)
			{
				return false;
			}
			if (Maximum != jsonNumberValidator.Maximum)
			{
				return false;
			}
			if (ExclusiveMaximum != jsonNumberValidator.ExclusiveMaximum)
			{
				return false;
			}
			if (Minimum != jsonNumberValidator.Minimum)
			{
				return false;
			}
			if (ExclusiveMinimum != jsonNumberValidator.ExclusiveMinimum)
			{
				return false;
			}
			return true;
		}

		public void Merge(IJsonSchemaValidator rhs)
		{
			throw new NotImplementedException();
		}

		public bool FromJsonSchema(IFileSystemAccessor fs, string key, ListTreeNode<JsonValue> value)
		{
			switch (key)
			{
			case "multipleOf":
				MultipleOf = value.GetDouble();
				return true;
			case "maximum":
				Maximum = value.GetDouble();
				return true;
			case "exclusiveMaximum":
				ExclusiveMaximum = value.GetBoolean();
				return true;
			case "minimum":
				Minimum = value.GetDouble();
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
			f.Value("number");
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

		public JsonSchemaValidationException Validate<T>(JsonSchemaValidationContext c, T o)
		{
			try
			{
				double num = Convert.ToDouble(o);
				if (Minimum.HasValue)
				{
					if (ExclusiveMinimum)
					{
						if (!(num > Minimum.Value))
						{
							return new JsonSchemaValidationException(c, $"minimum: ! {num}>{Minimum.Value}");
						}
					}
					else if (!(num >= Minimum.Value))
					{
						return new JsonSchemaValidationException(c, $"minimum: ! {num}>={Minimum.Value}");
					}
				}
				if (Maximum.HasValue)
				{
					if (ExclusiveMaximum)
					{
						if (!(num < Maximum.Value))
						{
							return new JsonSchemaValidationException(c, $"maximum: ! {num}<{Maximum.Value}");
						}
					}
					else if (!(num <= Maximum.Value))
					{
						return new JsonSchemaValidationException(c, $"maximum: ! {num}<={Maximum.Value}");
					}
				}
				if (MultipleOf.HasValue)
				{
					throw new NotImplementedException();
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
			f.Serialize(o);
		}

		public void Deserialize<T, U>(ListTreeNode<T> src, ref U dst) where T : IListTreeItem, IValue<T>
		{
			dst = GenericCast<double, U>.Cast(src.GetDouble());
		}
	}
}
