using System;
using System.IO;

namespace HandlebarsDotNet
{
	internal sealed class ExtendedStringReader : TextReader
	{
		private class ReaderContext : IReaderContext
		{
			public int LineNumber { get; set; }

			public int CharNumber { get; set; }
		}

		private int _linePos;

		private int _charPos;

		private int _matched;

		private readonly TextReader _inner;

		public ExtendedStringReader(TextReader reader)
		{
			_inner = reader;
		}

		public override int Peek()
		{
			return _inner.Peek();
		}

		public override int Read()
		{
			int num = _inner.Read();
			if (num >= 0)
			{
				AdvancePosition((char)num);
			}
			return num;
		}

		private void AdvancePosition(char c)
		{
			if (Environment.NewLine[_matched] == c)
			{
				_matched++;
				if (_matched == Environment.NewLine.Length)
				{
					_linePos++;
					_charPos = 0;
					_matched = 0;
				}
			}
			else
			{
				_matched = 0;
				_charPos++;
			}
		}

		public IReaderContext GetContext()
		{
			return new ReaderContext
			{
				LineNumber = _linePos,
				CharNumber = _charPos
			};
		}
	}
}
