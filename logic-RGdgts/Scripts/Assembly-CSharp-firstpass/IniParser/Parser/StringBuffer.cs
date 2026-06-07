using System.Collections.Generic;
using System.IO;

namespace IniParser.Parser
{
	public sealed class StringBuffer
	{
		public struct Range
		{
			private int _start;

			private int _size;

			public int start
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public int size
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public int end => 0;

			public bool IsEmpty => false;

			public void Reset()
			{
			}

			public static Range FromIndexWithSize(int start, int size)
			{
				return default(Range);
			}

			public static Range WithIndexes(int start, int end)
			{
				return default(Range);
			}

			public override string ToString()
			{
				return null;
			}
		}

		private static readonly int DefaultCapacity;

		private TextReader _dataSource;

		private List<char> _buffer;

		private Range _bufferIndexes;

		public int Count => 0;

		public bool IsEmpty => false;

		public bool IsWhitespace => false;

		public char Item => '\0';

		public StringBuffer()
		{
		}

		public StringBuffer(int capacity)
		{
		}

		internal StringBuffer(List<char> buffer, Range bufferIndexes)
		{
		}

		public StringBuffer DiscardChanges()
		{
			return null;
		}

		public Range FindSubstring(string subString, int startingIndex = 0)
		{
			return default(Range);
		}

		public bool ReadLine()
		{
			return false;
		}

		public void Reset(TextReader dataSource)
		{
		}

		public void Resize(Range range)
		{
		}

		public void Resize(int newSize)
		{
		}

		public void Resize(int startIdx, int size)
		{
		}

		public void ResizeBetweenIndexes(int startIdx, int endIdx)
		{
		}

		public StringBuffer Substring(Range range)
		{
			return null;
		}

		public StringBuffer SwallowCopy()
		{
			return null;
		}

		public void TrimStart()
		{
		}

		public void TrimEnd()
		{
		}

		public void Trim()
		{
		}

		public bool StartsWith(string str)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public string ToString(Range range)
		{
			return null;
		}
	}
}
