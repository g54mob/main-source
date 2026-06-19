using System;
using System.ComponentModel;
using System.Globalization;

namespace ModIO
{
	public class ModIdConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (!(sourceType == typeof(string)))
			{
				return base.CanConvertFrom(context, sourceType);
			}
			return true;
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (!(destinationType == typeof(ModId)))
			{
				return base.CanConvertTo(context, destinationType);
			}
			return true;
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				long.TryParse((string)value, out var result);
				return new ModId(result);
			}
			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (value is ModId { id: var id })
			{
				return id.ToString();
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
