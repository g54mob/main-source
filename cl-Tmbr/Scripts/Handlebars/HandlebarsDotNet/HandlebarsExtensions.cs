using System;

namespace HandlebarsDotNet
{
	public static class HandlebarsExtensions
	{
		public static void WriteSafeString(this in EncodedTextWriter writer, string value)
		{
			writer.Write(value, encode: false);
		}

		public static void WriteSafeString(this in EncodedTextWriter writer, object value)
		{
			if (value is string value2)
			{
				writer.WriteSafeString(value2);
				return;
			}
			bool suppressEncoding = writer.SuppressEncoding;
			try
			{
				writer.SuppressEncoding = true;
				writer.Write(value);
			}
			finally
			{
				writer.SuppressEncoding = suppressEncoding;
			}
		}

		public static HandlebarsConfiguration Configure(this HandlebarsConfiguration configuration, Action<HandlebarsConfiguration> config)
		{
			config(configuration);
			return configuration;
		}
	}
}
