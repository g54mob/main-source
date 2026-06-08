using System;

namespace HandlebarsDotNet.IO.Formatters.DefaultFormatters
{
	public class DefaultUShortFormatter : IFormatter
	{
		public void Format<T>(T value, in EncodedTextWriter writer)
		{
			if (!(value is ushort value2))
			{
				throw new ArgumentException(" supposed to be ushort", "value");
			}
			writer.UnderlyingWriter.Write(value2);
		}

		void IFormatter.Format<T>(T value, in EncodedTextWriter writer)
		{
			Format(value, in writer);
		}
	}
}
