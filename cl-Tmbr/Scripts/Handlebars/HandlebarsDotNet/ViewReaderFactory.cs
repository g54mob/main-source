using System.IO;

namespace HandlebarsDotNet
{
	public delegate TextReader ViewReaderFactory(ICompiledHandlebarsConfiguration configuration, string templatePath);
}
