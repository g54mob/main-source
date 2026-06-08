using System;
using System.IO;

namespace HandlebarsDotNet
{
	public class FileSystemPartialTemplateResolver : IPartialTemplateResolver
	{
		public bool TryRegisterPartial(IHandlebars env, string partialName, string templatePath)
		{
			if (env == null)
			{
				throw new ArgumentNullException("env");
			}
			IHandlebarsTemplateRegistrations configuration = env.Configuration;
			IHandlebarsTemplateRegistrations handlebarsTemplateRegistrations = configuration ?? env.As<ICompiledHandlebars>().CompiledConfiguration;
			if (handlebarsTemplateRegistrations?.FileSystem == null || templatePath == null || partialName == null)
			{
				return false;
			}
			string text = handlebarsTemplateRegistrations.FileSystem.Closest(templatePath, "partials/" + partialName + ".hbs");
			if (text != null)
			{
				HandlebarsTemplate<object, object> compiled = env.CompileView(text);
				handlebarsTemplateRegistrations.RegisteredTemplates.AddOrReplace(in partialName, (HandlebarsTemplate<TextWriter, object, object>)delegate(TextWriter writer, object o, object data)
				{
					((EncodedTextWriterWrapper)writer).Write(compiled(o, data), encode: false);
				});
				return true;
			}
			return false;
		}
	}
}
