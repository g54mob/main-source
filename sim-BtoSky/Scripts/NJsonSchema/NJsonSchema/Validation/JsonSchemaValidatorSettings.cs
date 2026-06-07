using System;
using System.Collections.Generic;
using System.Linq;
using NJsonSchema.Validation.FormatValidators;

namespace NJsonSchema.Validation
{
	public class JsonSchemaValidatorSettings
	{
		private StringComparer _propertyStringComparer;

		public StringComparer PropertyStringComparer
		{
			get
			{
				return _propertyStringComparer ?? StringComparer.Ordinal;
			}
			set
			{
				_propertyStringComparer = value;
			}
		}

		public IEnumerable<IFormatValidator> FormatValidators { get; set; } = new IFormatValidator[13]
		{
			new DateTimeFormatValidator(),
			new DateFormatValidator(),
			new EmailFormatValidator(),
			new GuidFormatValidator(),
			new HostnameFormatValidator(),
			new IpV4FormatValidator(),
			new IpV6FormatValidator(),
			new TimeFormatValidator(),
			new TimeSpanFormatValidator(),
			new UriFormatValidator(),
			new ByteFormatValidator(),
			new Base64FormatValidator(),
			new UuidFormatValidator()
		};

		public void AddCustomFormatValidator(IFormatValidator formatValidator)
		{
			FormatValidators = FormatValidators.Union(new IFormatValidator[1] { formatValidator }).ToArray();
		}
	}
}
