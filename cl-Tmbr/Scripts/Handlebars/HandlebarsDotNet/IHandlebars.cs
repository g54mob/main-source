using System.IO;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet
{
	public interface IHandlebars : IHelpersRegistry
	{
		bool IsSharedEnvironment { get; }

		HandlebarsConfiguration Configuration { get; }

		IHandlebars CreateSharedEnvironment();

		HandlebarsTemplate<TextWriter, object, object> Compile(TextReader template);

		HandlebarsTemplate<object, object> Compile(string template);

		HandlebarsTemplate<object, object> CompileView(string templatePath);

		HandlebarsTemplate<TextWriter, object, object> CompileView(string templatePath, ViewReaderFactory readerFactoryFactory);

		void RegisterTemplate(string templateName, HandlebarsTemplate<TextWriter, object, object> template);

		void RegisterTemplate(string templateName, string template);

		void RegisterDecorator(string helperName, HandlebarsBlockDecorator helperFunction);

		void RegisterDecorator(string helperName, HandlebarsDecorator helperFunction);

		void RegisterDecorator(string helperName, HandlebarsBlockDecoratorVoid helperFunction);

		void RegisterDecorator(string helperName, HandlebarsDecoratorVoid helperFunction);

		DisposableContainer Configure();
	}
}
