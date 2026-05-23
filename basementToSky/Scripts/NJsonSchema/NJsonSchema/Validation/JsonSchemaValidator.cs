using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using NJsonSchema.Validation.FormatValidators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NJsonSchema.Validation
{
	public class JsonSchemaValidator
	{
		private readonly IDictionary<string, IFormatValidator[]> _formatValidatorsMap;

		private readonly JsonSchemaValidatorSettings _settings;

		private static readonly IEnumerable<JsonObjectType> JsonObjectTypes = (from JsonObjectType t in Enum.GetValues(typeof(JsonObjectType))
			where t != JsonObjectType.None
			select t).ToList();

		public JsonSchemaValidator(params IFormatValidator[] customValidators)
			: this(new JsonSchemaValidatorSettings
			{
				FormatValidators = customValidators
			})
		{
		}

		public JsonSchemaValidator(JsonSchemaValidatorSettings settings)
		{
			_settings = settings ?? new JsonSchemaValidatorSettings();
			_formatValidatorsMap = (from x in _settings.FormatValidators
				group x by x.Format).ToDictionary((IGrouping<string, IFormatValidator> v) => v.Key, (IGrouping<string, IFormatValidator> v) => v.ToArray());
		}

		public ICollection<ValidationError> Validate(string jsonData, JsonSchema schema, SchemaType schemaType = SchemaType.JsonSchema)
		{
			using StringReader reader = new StringReader(jsonData);
			using JsonTextReader reader2 = new JsonTextReader(reader)
			{
				DateParseHandling = DateParseHandling.None
			};
			JToken token = JToken.ReadFrom(reader2);
			return Validate(token, schema, schemaType);
		}

		public ICollection<ValidationError> Validate(JToken token, JsonSchema schema, SchemaType schemaType = SchemaType.JsonSchema)
		{
			return Validate(token, schema.ActualSchema, schemaType, null, token.Path);
		}

		protected virtual ICollection<ValidationError> Validate(JToken token, JsonSchema schema, SchemaType schemaType, string propertyName, string propertyPath)
		{
			List<ValidationError> list = new List<ValidationError>();
			ValidateAnyOf(token, schema, propertyName, propertyPath, list);
			ValidateAllOf(token, schema, propertyName, propertyPath, list);
			ValidateOneOf(token, schema, propertyName, propertyPath, list);
			ValidateNot(token, schema, propertyName, propertyPath, list);
			ValidateType(token, schema, schemaType, propertyName, propertyPath, list);
			ValidateEnum(token, schema, schemaType, propertyName, propertyPath, list);
			ValidateProperties(token, schema, schemaType, propertyName, propertyPath, list);
			return list;
		}

		private void ValidateType(JToken token, JsonSchema schema, SchemaType schemaType, string propertyName, string propertyPath, List<ValidationError> errors)
		{
			if (token.Type == JTokenType.Null && schema.IsNullable(schemaType))
			{
				return;
			}
			Dictionary<JsonObjectType, ICollection<ValidationError>> dictionary = GetTypes(schema).ToDictionary((Func<JsonObjectType, JsonObjectType>)((JsonObjectType t) => t), (Func<JsonObjectType, ICollection<ValidationError>>)((JsonObjectType t) => new List<ValidationError>()));
			if (dictionary.Count > 1)
			{
				foreach (KeyValuePair<JsonObjectType, ICollection<ValidationError>> item in dictionary)
				{
					ValidateArray(token, schema, schemaType, item.Key, propertyName, propertyPath, (List<ValidationError>)item.Value);
					ValidateString(token, schema, item.Key, propertyName, propertyPath, (List<ValidationError>)item.Value);
					ValidateNumber(token, schema, item.Key, propertyName, propertyPath, (List<ValidationError>)item.Value);
					ValidateInteger(token, schema, item.Key, propertyName, propertyPath, (List<ValidationError>)item.Value);
					ValidateBoolean(token, schema, item.Key, propertyName, propertyPath, (List<ValidationError>)item.Value);
					ValidateNull(token, schema, item.Key, propertyName, propertyPath, (List<ValidationError>)item.Value);
					ValidateObject(token, schema, item.Key, propertyName, propertyPath, (List<ValidationError>)item.Value);
				}
				if (dictionary.All((KeyValuePair<JsonObjectType, ICollection<ValidationError>> t) => t.Value.Count > 0))
				{
					errors.Add(new MultiTypeValidationError(ValidationErrorKind.NoTypeValidates, propertyName, propertyPath, dictionary, token, schema));
				}
			}
			else
			{
				ValidateArray(token, schema, schemaType, schema.Type, propertyName, propertyPath, errors);
				ValidateString(token, schema, schema.Type, propertyName, propertyPath, errors);
				ValidateNumber(token, schema, schema.Type, propertyName, propertyPath, errors);
				ValidateInteger(token, schema, schema.Type, propertyName, propertyPath, errors);
				ValidateBoolean(token, schema, schema.Type, propertyName, propertyPath, errors);
				ValidateNull(token, schema, schema.Type, propertyName, propertyPath, errors);
				ValidateObject(token, schema, schema.Type, propertyName, propertyPath, errors);
			}
		}

		private IEnumerable<JsonObjectType> GetTypes(JsonSchema schema)
		{
			return JsonObjectTypes.Where((JsonObjectType t) => schema.Type.HasFlag(t));
		}

		private void ValidateAnyOf(JToken token, JsonSchema schema, string propertyName, string propertyPath, List<ValidationError> errors)
		{
			if (schema._anyOf.Count > 0)
			{
				Dictionary<JsonSchema, ICollection<ValidationError>> dictionary = schema._anyOf.ToDictionary((JsonSchema s) => s, (JsonSchema s) => Validate(token, s));
				if (dictionary.All((KeyValuePair<JsonSchema, ICollection<ValidationError>> s) => s.Value.Count != 0))
				{
					errors.Add(new ChildSchemaValidationError(ValidationErrorKind.NotAnyOf, propertyName, propertyPath, dictionary, token, schema));
				}
			}
		}

		private void ValidateAllOf(JToken token, JsonSchema schema, string propertyName, string propertyPath, List<ValidationError> errors)
		{
			if (schema._allOf.Count > 0)
			{
				Dictionary<JsonSchema, ICollection<ValidationError>> dictionary = schema._allOf.ToDictionary((JsonSchema s) => s, (JsonSchema s) => Validate(token, s));
				if (dictionary.Any((KeyValuePair<JsonSchema, ICollection<ValidationError>> s) => s.Value.Count != 0))
				{
					errors.Add(new ChildSchemaValidationError(ValidationErrorKind.NotAllOf, propertyName, propertyPath, dictionary, token, schema));
				}
			}
		}

		private void ValidateOneOf(JToken token, JsonSchema schema, string propertyName, string propertyPath, List<ValidationError> errors)
		{
			if (schema._oneOf.Count > 0)
			{
				Dictionary<JsonSchema, ICollection<ValidationError>> dictionary = schema._oneOf.ToDictionary((JsonSchema s) => s, (JsonSchema s) => Validate(token, s));
				if (dictionary.Count((KeyValuePair<JsonSchema, ICollection<ValidationError>> s) => s.Value.Count == 0) != 1)
				{
					errors.Add(new ChildSchemaValidationError(ValidationErrorKind.NotOneOf, propertyName, propertyPath, dictionary, token, schema));
				}
			}
		}

		private void ValidateNot(JToken token, JsonSchema schema, string propertyName, string propertyPath, List<ValidationError> errors)
		{
			if (schema.Not != null && Validate(token, schema.Not).Count == 0)
			{
				errors.Add(new ValidationError(ValidationErrorKind.ExcludedSchemaValidates, propertyName, propertyPath, token, schema));
			}
		}

		private void ValidateNull(JToken token, JsonSchema schema, JsonObjectType type, string propertyName, string propertyPath, List<ValidationError> errors)
		{
			if (type.IsNull() && token != null && token.Type != JTokenType.Null)
			{
				errors.Add(new ValidationError(ValidationErrorKind.NullExpected, propertyName, propertyPath, token, schema));
			}
		}

		private void ValidateEnum(JToken token, JsonSchema schema, SchemaType schemaType, string propertyName, string propertyPath, List<ValidationError> errors)
		{
			if (schema.IsNullable(schemaType))
			{
				JToken jToken = token;
				if (jToken != null && jToken.Type == JTokenType.Null)
				{
					return;
				}
			}
			if (schema.Enumeration.Count > 0 && schema.Enumeration.All((object v) => v?.ToString() != token?.ToString()))
			{
				errors.Add(new ValidationError(ValidationErrorKind.NotInEnumeration, propertyName, propertyPath, token, schema));
			}
		}

		private void ValidateString(JToken token, JsonSchema schema, JsonObjectType type, string propertyName, string propertyPath, List<ValidationError> errors)
		{
			if (token.Type == JTokenType.String || token.Type == JTokenType.Date || token.Type == JTokenType.Guid || token.Type == JTokenType.TimeSpan || token.Type == JTokenType.Uri)
			{
				string value = ((token.Type == JTokenType.Date) ? (token as JValue).ToString("yyyy-MM-ddTHH:mm:ssK") : token.Value<string>());
				if (value == null)
				{
					return;
				}
				if (!string.IsNullOrEmpty(schema.Pattern) && !Regex.IsMatch(value, schema.Pattern))
				{
					errors.Add(new ValidationError(ValidationErrorKind.PatternMismatch, propertyName, propertyPath, token, schema));
				}
				if (schema.MinLength.HasValue && value.Length < schema.MinLength)
				{
					errors.Add(new ValidationError(ValidationErrorKind.StringTooShort, propertyName, propertyPath, token, schema));
				}
				if (schema.MaxLength.HasValue && value.Length > schema.MaxLength)
				{
					errors.Add(new ValidationError(ValidationErrorKind.StringTooLong, propertyName, propertyPath, token, schema));
				}
				if (!string.IsNullOrEmpty(schema.Format) && _formatValidatorsMap.TryGetValue(schema.Format, out var value2) && !value2.Any((IFormatValidator x) => x.IsValid(value, token.Type)))
				{
					errors.AddRange(from validationErrorKind in value2.Select((IFormatValidator x) => x.ValidationErrorKind).Distinct()
						select new ValidationError(validationErrorKind, propertyName, propertyPath, token, schema));
				}
			}
			else if (type.IsString())
			{
				errors.Add(new ValidationError(ValidationErrorKind.StringExpected, propertyName, propertyPath, token, schema));
			}
		}

		private void ValidateNumber(JToken token, JsonSchema schema, JsonObjectType type, string propertyName, string propertyPath, List<ValidationError> errors)
		{
			if (type.IsNumber() && token.Type != JTokenType.Float && token.Type != JTokenType.Integer)
			{
				errors.Add(new ValidationError(ValidationErrorKind.NumberExpected, propertyName, propertyPath, token, schema));
			}
			if (token.Type != JTokenType.Float && token.Type != JTokenType.Integer)
			{
				return;
			}
			try
			{
				decimal num = token.Value<decimal>();
				if (schema.Minimum.HasValue)
				{
					bool num2;
					if (!schema.IsExclusiveMinimum)
					{
						decimal? minimum = schema.Minimum;
						num2 = (num < minimum.GetValueOrDefault()) & minimum.HasValue;
					}
					else
					{
						decimal? minimum = schema.Minimum;
						num2 = (num <= minimum.GetValueOrDefault()) & minimum.HasValue;
					}
					if (num2)
					{
						errors.Add(new ValidationError(ValidationErrorKind.NumberTooSmall, propertyName, propertyPath, token, schema));
					}
				}
				if (schema.Maximum.HasValue)
				{
					bool num3;
					if (!schema.IsExclusiveMaximum)
					{
						decimal? minimum = schema.Maximum;
						num3 = (num > minimum.GetValueOrDefault()) & minimum.HasValue;
					}
					else
					{
						decimal? minimum = schema.Maximum;
						num3 = (num >= minimum.GetValueOrDefault()) & minimum.HasValue;
					}
					if (num3)
					{
						errors.Add(new ValidationError(ValidationErrorKind.NumberTooBig, propertyName, propertyPath, token, schema));
					}
				}
				if (schema.ExclusiveMinimum.HasValue)
				{
					decimal? minimum = schema.ExclusiveMinimum;
					if ((num <= minimum.GetValueOrDefault()) & minimum.HasValue)
					{
						errors.Add(new ValidationError(ValidationErrorKind.NumberTooSmall, propertyName, propertyPath, token, schema));
					}
				}
				if (schema.ExclusiveMaximum.HasValue)
				{
					decimal? minimum = schema.ExclusiveMaximum;
					if ((num >= minimum.GetValueOrDefault()) & minimum.HasValue)
					{
						errors.Add(new ValidationError(ValidationErrorKind.NumberTooBig, propertyName, propertyPath, token, schema));
					}
				}
				if (schema.MultipleOf.HasValue)
				{
					decimal value = num;
					decimal? multipleOf = schema.MultipleOf;
					decimal? minimum = (decimal?)value % multipleOf;
					if (!((minimum.GetValueOrDefault() == default(decimal)) & minimum.HasValue))
					{
						errors.Add(new ValidationError(ValidationErrorKind.NumberNotMultipleOf, propertyName, propertyPath, token, schema));
					}
				}
			}
			catch (OverflowException)
			{
				double num4 = token.Value<double>();
				if (schema.Minimum.HasValue && (schema.IsExclusiveMinimum ? (num4 <= (double)schema.Minimum.Value) : (num4 < (double)schema.Minimum.Value)))
				{
					errors.Add(new ValidationError(ValidationErrorKind.NumberTooSmall, propertyName, propertyPath, token, schema));
				}
				if (schema.Maximum.HasValue && (schema.IsExclusiveMaximum ? (num4 >= (double)schema.Maximum.Value) : (num4 > (double)schema.Maximum.Value)))
				{
					errors.Add(new ValidationError(ValidationErrorKind.NumberTooBig, propertyName, propertyPath, token, schema));
				}
				if (schema.ExclusiveMinimum.HasValue && num4 <= (double)schema.ExclusiveMinimum.Value)
				{
					errors.Add(new ValidationError(ValidationErrorKind.NumberTooSmall, propertyName, propertyPath, token, schema));
				}
				if (schema.ExclusiveMaximum.HasValue && num4 >= (double)schema.ExclusiveMaximum.Value)
				{
					errors.Add(new ValidationError(ValidationErrorKind.NumberTooBig, propertyName, propertyPath, token, schema));
				}
				if (schema.MultipleOf.HasValue && num4 % (double)schema.MultipleOf.Value != 0.0)
				{
					errors.Add(new ValidationError(ValidationErrorKind.NumberNotMultipleOf, propertyName, propertyPath, token, schema));
				}
			}
		}

		private void ValidateInteger(JToken token, JsonSchema schema, JsonObjectType type, string propertyName, string propertyPath, List<ValidationError> errors)
		{
			if (type.IsInteger() && token.Type != JTokenType.Integer)
			{
				errors.Add(new ValidationError(ValidationErrorKind.IntegerExpected, propertyName, propertyPath, token, schema));
			}
		}

		private void ValidateBoolean(JToken token, JsonSchema schema, JsonObjectType type, string propertyName, string propertyPath, List<ValidationError> errors)
		{
			if (type.IsBoolean() && token.Type != JTokenType.Boolean)
			{
				errors.Add(new ValidationError(ValidationErrorKind.BooleanExpected, propertyName, propertyPath, token, schema));
			}
		}

		private void ValidateObject(JToken token, JsonSchema schema, JsonObjectType type, string propertyName, string propertyPath, List<ValidationError> errors)
		{
			if (type.IsObject() && !(token is JObject))
			{
				errors.Add(new ValidationError(ValidationErrorKind.ObjectExpected, propertyName, propertyPath, token, schema));
			}
		}

		private void ValidateProperties(JToken token, JsonSchema schema, SchemaType schemaType, string propertyName, string propertyPath, List<ValidationError> errors)
		{
			JObject jObject = token as JObject;
			if (jObject == null && schema.Type.IsNull())
			{
				return;
			}
			StringComparer propertyStringComparer = _settings.PropertyStringComparer;
			HashSet<string> schemaPropertyKeys = new HashSet<string>(schema.Properties.Keys, propertyStringComparer);
			foreach (KeyValuePair<string, JsonSchemaProperty> property in schema.Properties)
			{
				string propertyPath2 = GetPropertyPath(propertyPath, property.Key);
				if (jObject != null && TryGetPropertyWithStringComparer(jObject, property.Key, propertyStringComparer, out var value))
				{
					if (value.Type != JTokenType.Null || !property.Value.IsNullable(schemaType))
					{
						ICollection<ValidationError> collection = Validate(value, property.Value.ActualSchema, schemaType, property.Key, propertyPath2);
						errors.AddRange(collection);
					}
				}
				else if (property.Value.IsRequired)
				{
					errors.Add(new ValidationError(ValidationErrorKind.PropertyRequired, property.Key, propertyPath2, token, schema));
				}
			}
			foreach (string requiredProperty in schema.RequiredProperties)
			{
				if (!schemaPropertyKeys.Contains(requiredProperty) && (jObject == null || !TryGetPropertyWithStringComparer(jObject, requiredProperty, propertyStringComparer, out var _)))
				{
					string propertyPath3 = GetPropertyPath(propertyPath, requiredProperty);
					errors.Add(new ValidationError(ValidationErrorKind.PropertyRequired, requiredProperty, propertyPath3, token, schema));
				}
			}
			if (jObject != null)
			{
				List<JProperty> list = jObject.Properties().ToList();
				ValidateMaxProperties(token, list, schema, propertyName, propertyPath, errors);
				ValidateMinProperties(token, list, schema, propertyName, propertyPath, errors);
				List<JProperty> additionalProperties = list.Where((JProperty p) => !schemaPropertyKeys.Contains(p.Name)).ToList();
				ValidatePatternProperties(additionalProperties, schema, schemaType, errors);
				ValidateAdditionalProperties(token, additionalProperties, schema, schemaType, propertyName, propertyPath, errors);
			}
		}

		private string GetPropertyPath(string propertyPath, string propertyName)
		{
			if (string.IsNullOrEmpty(propertyPath))
			{
				return propertyName;
			}
			return propertyPath + "." + propertyName;
		}

		private void ValidateMaxProperties(JToken token, IList<JProperty> properties, JsonSchema schema, string propertyName, string propertyPath, List<ValidationError> errors)
		{
			if (schema.MaxProperties > 0 && properties.Count() > schema.MaxProperties)
			{
				errors.Add(new ValidationError(ValidationErrorKind.TooManyProperties, propertyName, propertyPath, token, schema));
			}
		}

		private void ValidateMinProperties(JToken token, IList<JProperty> properties, JsonSchema schema, string propertyName, string propertyPath, List<ValidationError> errors)
		{
			if (schema.MinProperties > 0 && properties.Count() < schema.MinProperties)
			{
				errors.Add(new ValidationError(ValidationErrorKind.TooFewProperties, propertyName, propertyPath, token, schema));
			}
		}

		private void ValidatePatternProperties(List<JProperty> additionalProperties, JsonSchema schema, SchemaType schemaType, List<ValidationError> errors)
		{
			JProperty[] array = additionalProperties.ToArray();
			foreach (JProperty property in array)
			{
				KeyValuePair<string, JsonSchemaProperty> keyValuePair = schema.PatternProperties.FirstOrDefault((KeyValuePair<string, JsonSchemaProperty> p) => Regex.IsMatch(property.Name, p.Key));
				if (keyValuePair.Value != null)
				{
					ChildSchemaValidationError childSchemaValidationError = TryCreateChildSchemaError(property.Value, keyValuePair.Value, schemaType, ValidationErrorKind.AdditionalPropertiesNotValid, property.Name, property.Path);
					if (childSchemaValidationError != null)
					{
						errors.Add(childSchemaValidationError);
					}
					additionalProperties.Remove(property);
				}
			}
		}

		private void ValidateAdditionalProperties(JToken token, List<JProperty> additionalProperties, JsonSchema schema, SchemaType schemaType, string propertyName, string propertyPath, List<ValidationError> errors)
		{
			if (schema.AdditionalPropertiesSchema != null)
			{
				foreach (JProperty additionalProperty in additionalProperties)
				{
					ChildSchemaValidationError childSchemaValidationError = TryCreateChildSchemaError(additionalProperty.Value, schema.AdditionalPropertiesSchema, schemaType, ValidationErrorKind.AdditionalPropertiesNotValid, additionalProperty.Name, additionalProperty.Path);
					if (childSchemaValidationError != null)
					{
						errors.Add(childSchemaValidationError);
					}
				}
				return;
			}
			if (schema.AllowAdditionalProperties || !additionalProperties.Any())
			{
				return;
			}
			foreach (JProperty additionalProperty2 in additionalProperties)
			{
				string propertyPath2 = ((!string.IsNullOrEmpty(propertyPath)) ? (propertyPath + "." + additionalProperty2.Name) : additionalProperty2.Name);
				errors.Add(new ValidationError(ValidationErrorKind.NoAdditionalPropertiesAllowed, additionalProperty2.Name, propertyPath2, additionalProperty2, schema));
			}
		}

		private void ValidateArray(JToken token, JsonSchema schema, SchemaType schemaType, JsonObjectType type, string propertyName, string propertyPath, List<ValidationError> errors)
		{
			if (token is JArray jArray)
			{
				if (schema.MinItems > 0 && jArray.Count < schema.MinItems)
				{
					errors.Add(new ValidationError(ValidationErrorKind.TooFewItems, propertyName, propertyPath, token, schema));
				}
				if (schema.MaxItems > 0 && jArray.Count > schema.MaxItems)
				{
					errors.Add(new ValidationError(ValidationErrorKind.TooManyItems, propertyName, propertyPath, token, schema));
				}
				if (schema.UniqueItems && jArray.Count != jArray.Select((JToken a) => a.ToString()).Distinct().Count())
				{
					errors.Add(new ValidationError(ValidationErrorKind.ItemsNotUnique, propertyName, propertyPath, token, schema));
				}
				for (int num = 0; num < jArray.Count; num++)
				{
					JToken jToken = jArray[num];
					string text = $"[{num}]";
					string path = ((!string.IsNullOrEmpty(propertyPath)) ? (propertyPath + text) : text);
					if (schema.Item != null)
					{
						ChildSchemaValidationError childSchemaValidationError = TryCreateChildSchemaError(jToken, schema.Item, schemaType, ValidationErrorKind.ArrayItemNotValid, text, path);
						if (childSchemaValidationError != null)
						{
							errors.Add(childSchemaValidationError);
						}
					}
					ValidateAdditionalItems(jToken, schema, schemaType, num, propertyPath, errors);
				}
			}
			else if (type.IsArray())
			{
				errors.Add(new ValidationError(ValidationErrorKind.ArrayExpected, propertyName, propertyPath, token, schema));
			}
		}

		private void ValidateAdditionalItems(JToken item, JsonSchema schema, SchemaType schemaType, int index, string propertyPath, List<ValidationError> errors)
		{
			if (schema.Items.Count <= 0)
			{
				return;
			}
			string text = $"[{index}]";
			if (schema.Items.Count > index)
			{
				ChildSchemaValidationError childSchemaValidationError = TryCreateChildSchemaError(item, schema.Items.ElementAt(index), schemaType, ValidationErrorKind.ArrayItemNotValid, text, propertyPath + text);
				if (childSchemaValidationError != null)
				{
					errors.Add(childSchemaValidationError);
				}
			}
			else if (schema.AdditionalItemsSchema != null)
			{
				ChildSchemaValidationError childSchemaValidationError2 = TryCreateChildSchemaError(item, schema.AdditionalItemsSchema, schemaType, ValidationErrorKind.AdditionalItemNotValid, text, propertyPath + text);
				if (childSchemaValidationError2 != null)
				{
					errors.Add(childSchemaValidationError2);
				}
			}
			else if (!schema.AllowAdditionalItems)
			{
				errors.Add(new ValidationError(ValidationErrorKind.TooManyItemsInTuple, text, propertyPath + text, item, schema));
			}
		}

		private ChildSchemaValidationError TryCreateChildSchemaError(JToken token, JsonSchema schema, SchemaType schemaType, ValidationErrorKind errorKind, string property, string path)
		{
			ICollection<ValidationError> collection = Validate(token, schema.ActualSchema, schemaType, null, path);
			if (collection.Count == 0)
			{
				return null;
			}
			Dictionary<JsonSchema, ICollection<ValidationError>> dictionary = new Dictionary<JsonSchema, ICollection<ValidationError>>();
			dictionary.Add(schema, collection);
			return new ChildSchemaValidationError(errorKind, property, path, dictionary, token, schema);
		}

		private bool TryGetPropertyWithStringComparer(JObject obj, string propertyName, StringComparer comparer, out JToken value)
		{
			if (obj.TryGetValue(propertyName, out value))
			{
				return true;
			}
			foreach (JProperty item in obj.Properties())
			{
				if (comparer.Equals(propertyName, item.Name))
				{
					value = item.Value;
					return true;
				}
			}
			return false;
		}
	}
}
