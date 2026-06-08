using System;

namespace HandlebarsDotNet.IO.Formatters.DefaultFormatters
{
	public class DefaultDoubleFormatter : IFormatter
	{
		public void Format<T>(T value, in EncodedTextWriter writer)
		{
			if (!(value is double value2))
			{
				throw new ArgumentException(" supposed to be double", "value");
			}
			writer.UnderlyingWriter.Write(value2);
		}

		void IFormatter.Format<T>(T value, in EncodedTextWriter writer)
		{
			Format(value, in writer);
		}
	}
}
