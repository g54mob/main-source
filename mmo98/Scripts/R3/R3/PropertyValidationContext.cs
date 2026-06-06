using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace R3
{
	internal sealed class PropertyValidationContext
	{
		public int ValidatorCount => _003Cattributes_003EP.Length;

		public PropertyValidationContext(ValidationContext context, ValidationAttribute[] attributes)
		{
			_003Ccontext_003EP = context;
			_003Cattributes_003EP = attributes;
			base._002Ector();
		}

		public bool TryValidateValue(object? value, ICollection<ValidationResult> validationResults)
		{
			return Validator.TryValidateValue(value, _003Ccontext_003EP, validationResults, _003Cattributes_003EP);
		}
	}
}
