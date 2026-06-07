using System;
using System.ComponentModel;
using System.Globalization;

namespace Noesis
{
	public class KeyConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return false;
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			return null;
		}
	}
}
