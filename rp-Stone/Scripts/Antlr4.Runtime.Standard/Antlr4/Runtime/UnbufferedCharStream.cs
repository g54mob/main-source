using System;
using System.IO;
using System.Text;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime
{
	public class UnbufferedCharStream : ICharStream, IIntStream
	{
		protected internal int[] data;

		protected internal int n;

		protected internal int p;

		protected internal int numMarkers;

		protected internal int lastChar = -1;

		protected internal int lastCharBufferStart;

		protected internal int currentCharIndex;

		protected internal TextReader input;

		public string name;

		public virtual int Index => currentCharIndex;

		public virtual int Size
		{
			get
			{
				throw new NotSupportedException("Unbuffered stream cannot know its size");
			}
		}

		public virtual string SourceName
		{
			get
			{
				if (string.IsNullOrEmpty(name))
				{
					return "<unknown>";
				}
				return name;
			}
		}

		protected internal int BufferStartIndex => currentCharIndex - p;

		public UnbufferedCharStream()
			: this(256)
		{
		}

		public UnbufferedCharStream(int bufferSize)
		{
			n = 0;
			data = new int[bufferSize];
		}

		public UnbufferedCharStream(Stream input)
			: this(input, 256)
		{
		}

		public UnbufferedCharStream(TextReader input)
			: this(input, 256)
		{
		}

		public UnbufferedCharStream(Stream input, int bufferSize)
			: this(bufferSize)
		{
			this.input = new StreamReader(input);
			Fill(1);
		}

		public UnbufferedCharStream(TextReader input, int bufferSize)
			: this(bufferSize)
		{
			this.input = input;
			Fill(1);
		}

		public virtual void Consume()
		{
			if (LA(1) == -1)
			{
				throw new InvalidOperationException("cannot consume EOF");
			}
			lastChar = data[p];
			if (p == n - 1 && numMarkers == 0)
			{
				n = 0;
				p = -1;
				lastCharBufferStart = lastChar;
			}
			p++;
			currentCharIndex++;
			Sync(1);
		}

		protected internal virtual void Sync(int want)
		{
			int num = p + want - 1 - n + 1;
			if (num > 0)
			{
				Fill(num);
			}
		}

		protected internal virtual int Fill(int n)
		{
			for (int i = 0; i < n; i++)
			{
				if (this.n > 0 && data[this.n - 1] == -1)
				{
					return i;
				}
				int num = NextChar();
				if (num > 65535 || num == -1)
				{
					Add(num);
					continue;
				}
				char c = (char)num;
				if (char.IsLowSurrogate(c))
				{
					throw new ArgumentException("Invalid UTF-16 (low surrogate with no preceding high surrogate)");
				}
				if (char.IsHighSurrogate(c))
				{
					int num2 = NextChar();
					if (num2 > 65535)
					{
						throw new ArgumentException("Invalid UTF-16 (high surrogate followed by code point > U+FFFF");
					}
					if (num2 == -1)
					{
						throw new ArgumentException("Invalid UTF-16 (low surrogate with no preceding high surrogate)");
					}
					char c2 = (char)num2;
					if (!char.IsLowSurrogate(c2))
					{
						throw new ArgumentException("Invalid UTF-16 (low surrogate with no preceding high surrogate)");
					}
					Add(char.ConvertToUtf32(c, c2));
				}
				else
				{
					Add(num);
				}
			}
			return n;
		}

		protected internal virtual int NextChar()
		{
			return input.Read();
		}

		protected internal virtual void Add(int c)
		{
			if (n >= data.Length)
			{
				data = Arrays.CopyOf(data, data.Length * 2);
			}
			data[n++] = c;
		}

		public virtual int LA(int i)
		{
			if (i == -1)
			{
				return lastChar;
			}
			Sync(i);
			int num = p + i - 1;
			if (num < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (num >= n)
			{
				return -1;
			}
			return data[num];
		}

		public virtual int Mark()
		{
			if (numMarkers == 0)
			{
				lastCharBufferStart = lastChar;
			}
			int result = -numMarkers - 1;
			numMarkers++;
			return result;
		}

		public virtual void Release(int marker)
		{
			int num = -numMarkers;
			if (marker != num)
			{
				throw new InvalidOperationException("release() called with an invalid marker.");
			}
			numMarkers--;
			if (numMarkers == 0 && p > 0)
			{
				Array.Copy(data, p, data, 0, n - p);
				n -= p;
				p = 0;
				lastCharBufferStart = lastChar;
			}
		}

		public virtual void Seek(int index)
		{
			if (index != currentCharIndex)
			{
				if (index > currentCharIndex)
				{
					Sync(index - currentCharIndex);
					index = Math.Min(index, BufferStartIndex + n - 1);
				}
				int num = index - BufferStartIndex;
				if (num < 0)
				{
					throw new ArgumentException("cannot seek to negative index " + index);
				}
				if (num >= n)
				{
					throw new NotSupportedException("seek to index outside buffer: " + index + " not in " + BufferStartIndex + ".." + (BufferStartIndex + n));
				}
				p = num;
				currentCharIndex = index;
				if (p == 0)
				{
					lastChar = lastCharBufferStart;
				}
				else
				{
					lastChar = data[p - 1];
				}
			}
		}

		public virtual string GetText(Interval interval)
		{
			if (interval.a < 0 || interval.b < interval.a - 1)
			{
				throw new ArgumentException("invalid interval");
			}
			int bufferStartIndex = BufferStartIndex;
			if (n > 0 && data[n - 1] == -1 && interval.a + interval.Length > bufferStartIndex + n)
			{
				throw new ArgumentException("the interval extends past the end of the stream");
			}
			if (interval.a < bufferStartIndex || interval.b >= bufferStartIndex + n)
			{
				string[] obj = new string[6] { "interval ", null, null, null, null, null };
				Interval interval2 = interval;
				obj[1] = interval2.ToString();
				obj[2] = " outside buffer: ";
				obj[3] = bufferStartIndex.ToString();
				obj[4] = "..";
				obj[5] = (bufferStartIndex + n - 1).ToString();
				throw new NotSupportedException(string.Concat(obj));
			}
			int num = interval.a - bufferStartIndex;
			StringBuilder stringBuilder = new StringBuilder(interval.Length);
			for (int i = 0; i < interval.Length; i++)
			{
				stringBuilder.Append(char.ConvertFromUtf32(data[num + i]));
			}
			return stringBuilder.ToString();
		}
	}
}
