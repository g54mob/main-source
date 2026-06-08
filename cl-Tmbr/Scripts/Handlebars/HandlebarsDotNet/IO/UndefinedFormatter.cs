using System;

namespace HandlebarsDotNet.IO
{
	public sealed class UndefinedFormatter : IFormatter, IFormatterProvider
	{
		public string FormatString { get; set; }

		public UndefinedFormatter(string formatString = null)
		{
			FormatString = formatString;
		}

		public bool TryCreateFormatter(Type type, out IFormatter formatter)
		{
			if (type != typeof(UndefinedBindingResult))
			{
				formatter = null;
				return false;
			}
			formatter = this;
			return true;
		}

		public void Format<T>(T value, in EncodedTextWriter writer)
		{
			if (!string.IsNullOrEmpty(FormatString))
			{
				writer.Write(FormatString, (value as UndefinedBindingResult).Value);
			}
		}

		void IFormatter.Format<T>(T value, in EncodedTextWriter writer)
		{
			Format(value, in writer);
		}
	}
}
