using System.Text;

namespace Timberborn.Common
{
	public struct StringListBuilder
	{
		private readonly StringBuilder _stringBuilder;

		private readonly string _separator;

		private bool _subsequent;

		public StringListBuilder(StringBuilder stringBuilder, string separator)
		{
			_stringBuilder = stringBuilder;
			_separator = separator;
			_subsequent = false;
		}

		public void BeginItem()
		{
			if (_subsequent)
			{
				_stringBuilder.Append(_separator);
			}
			else
			{
				_subsequent = true;
			}
		}
	}
}
