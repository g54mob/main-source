using System.IO;
using System.Text;

namespace Antlr4.Runtime
{
	public static class CharStreams
	{
		public static ICharStream fromPath(string path)
		{
			return fromPath(path, Encoding.UTF8);
		}

		public static ICharStream fromPath(string path, Encoding encoding)
		{
			return new CodePointCharStream(File.ReadAllText(path, encoding))
			{
				name = path
			};
		}

		public static ICharStream fromTextReader(TextReader textReader)
		{
			try
			{
				return new CodePointCharStream(textReader.ReadToEnd());
			}
			finally
			{
				textReader.Dispose();
			}
		}

		public static ICharStream fromStream(Stream stream)
		{
			return fromStream(stream, Encoding.UTF8);
		}

		public static ICharStream fromStream(Stream stream, Encoding encoding)
		{
			using StreamReader textReader = new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks: false);
			return fromTextReader(textReader);
		}

		public static ICharStream fromString(string s)
		{
			return new CodePointCharStream(s);
		}
	}
}
