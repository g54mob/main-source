using System.IO;
using HandlebarsDotNet.Collections;

namespace HandlebarsDotNet
{
	public interface IHandlebarsTemplateRegistrations
	{
		IIndexed<string, HandlebarsTemplate<TextWriter, object, object>> RegisteredTemplates { get; }

		ViewEngineFileSystem FileSystem { get; }
	}
}
