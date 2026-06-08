using System;

namespace HandlebarsDotNet.IO.Formatters.DefaultFormatters
{
	public class DefaultULongFormatter : IFormatter
	{
		public void Format<T>(T value, in EncodedTextWriter writer)
		{
			if (!(value is ulong value2))
			{
				throw new ArgumentException(" supposed to be ulong", "value");
			}
			writer.UnderlyingWriter.Write(value2);
		}

		void IFormatter.Format<T>(T value, in EncodedTextWriter writer)
		{
			Format(value, in writer);
		}
	}
}
