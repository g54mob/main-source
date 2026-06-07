using System;
using System.Collections.Generic;
using System.Text;

namespace Gh
{
	public static class StringBuilderPool
	{
		public class DisposableStringBuilder : IDisposable
		{
			private const int MAX_CACHED_CAPACITY = 2048;

			private readonly StringBuilder _builder;

			public char this[int index]
			{
				get
				{
					return '\0';
				}
				set
				{
				}
			}

			public int Length => 0;

			public override string ToString()
			{
				return null;
			}

			public string ToString(int startIndex, int length)
			{
				return null;
			}

			public void Dispose()
			{
			}

			public DisposableStringBuilder Append(char value)
			{
				return null;
			}

			public DisposableStringBuilder Append(string value)
			{
				return null;
			}

			public DisposableStringBuilder Append(StringBuilder value)
			{
				return null;
			}

			public DisposableStringBuilder Append(DisposableStringBuilder value)
			{
				return null;
			}

			public DisposableStringBuilder AppendLine()
			{
				return null;
			}

			public DisposableStringBuilder AppendLine(string value)
			{
				return null;
			}

			public DisposableStringBuilder AppendFormat(string formatString, params object[] args)
			{
				return null;
			}

			public DisposableStringBuilder Replace(string oldValue, string newValue)
			{
				return null;
			}

			public DisposableStringBuilder Replace(string oldValue, string newValue, int startIndex, int count)
			{
				return null;
			}

			public DisposableStringBuilder Remove(int startIndex, int length)
			{
				return null;
			}

			public bool Contains(string value)
			{
				return false;
			}

			public DisposableStringBuilder Insert(int index, string value)
			{
				return null;
			}

			public DisposableStringBuilder Insert(int index, string value, int count)
			{
				return null;
			}

			public static implicit operator StringBuilder(DisposableStringBuilder builder)
			{
				return null;
			}

			public void Clear()
			{
			}
		}

		[ThreadStatic]
		private static Stack<DisposableStringBuilder> _stack;

		public static DisposableStringBuilder GetPooledDisposableBuilder()
		{
			return null;
		}
	}
}
