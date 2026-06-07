using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MiscUtil.IO
{
	public sealed class LineReader : IEnumerable<string>, IEnumerable
	{
		private readonly Func<TextReader> dataSource;

		public LineReader(Func<Stream> streamSource)
			: this(streamSource, Encoding.UTF8)
		{
		}

		public LineReader(Func<Stream> streamSource, Encoding encoding)
			: this(() => new StreamReader(streamSource(), encoding))
		{
		}

		public LineReader(string filename)
			: this(filename, Encoding.UTF8)
		{
		}

		public LineReader(string filename, Encoding encoding)
			: this(() => new StreamReader(filename, encoding))
		{
		}

		public LineReader(Func<TextReader> dataSource)
		{
			this.dataSource = dataSource;
		}

		public IEnumerator<string> GetEnumerator()
		{
			using (TextReader reader = dataSource())
			{
				while (true)
				{
					string text;
					string line = (text = reader.ReadLine());
					if (text != null)
					{
						yield return line;
						continue;
					}
					break;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
