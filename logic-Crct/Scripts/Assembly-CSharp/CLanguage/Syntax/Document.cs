using System.Text;

namespace CLanguage.Syntax
{
	public class Document
	{
		public readonly string Path;

		public readonly string Content;

		public readonly Encoding Encoding;

		public bool IsCompilable => false;

		public Document(string path, string content, Encoding encoding)
		{
		}

		public Document(string path, string content)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
