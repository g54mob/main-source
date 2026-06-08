using System;
using Antlr4.Runtime.Misc;

namespace Antlr4.Runtime
{
	public abstract class BaseInputCharStream : ICharStream, IIntStream
	{
		public const int ReadBufferSize = 1024;

		public const int InitialBufferSize = 1024;

		protected internal int n;

		protected internal int p;

		public string name;

		public virtual int Index => p;

		public virtual int Size => n;

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

		public virtual void Reset()
		{
			p = 0;
		}

		public virtual void Consume()
		{
			if (p >= n)
			{
				throw new InvalidOperationException("cannot consume EOF");
			}
			p++;
		}

		public virtual int LA(int i)
		{
			if (i == 0)
			{
				return 0;
			}
			if (i < 0)
			{
				i++;
				if (p + i - 1 < 0)
				{
					return -1;
				}
			}
			if (p + i - 1 >= n)
			{
				return -1;
			}
			return ValueAt(p + i - 1);
		}

		public virtual int Lt(int i)
		{
			return LA(i);
		}

		public virtual int Mark()
		{
			return -1;
		}

		public virtual void Release(int marker)
		{
		}

		public virtual void Seek(int index)
		{
			if (index <= p)
			{
				p = index;
				return;
			}
			index = Math.Min(index, n);
			while (p < index)
			{
				Consume();
			}
		}

		public virtual string GetText(Interval interval)
		{
			int a = interval.a;
			int num = interval.b;
			if (num >= n)
			{
				num = n - 1;
			}
			int count = num - a + 1;
			if (a >= n)
			{
				return string.Empty;
			}
			return ConvertDataToString(a, count);
		}

		protected abstract int ValueAt(int i);

		protected abstract string ConvertDataToString(int start, int count);

		public sealed override string ToString()
		{
			return ConvertDataToString(0, n);
		}
	}
}
