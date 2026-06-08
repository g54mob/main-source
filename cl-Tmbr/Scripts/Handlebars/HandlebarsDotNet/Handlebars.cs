using System;
using System.IO;
using HandlebarsDotNet.Helpers;

namespace HandlebarsDotNet
{
	public sealed class Handlebars
	{
		private static readonly Lazy<IHandlebars> Lazy = new Lazy<IHandlebars>(() => new HandlebarsEnvironment(new HandlebarsConfiguration()));

		private static IHandlebars Instance => Lazy.Value;

		public static HandlebarsConfiguration Configuration => Instance.Configuration;

		public static IHandlebars Create(HandlebarsConfiguration configuration = null)
		{
			configuration = configuration ?? new HandlebarsConfiguration();
			return new HandlebarsEnvironment(configuration);
		}

		public static IHandlebars CreateSharedEnvironment(HandlebarsConfiguration configuration = null)
		{
			if (configuration == null)
			{
				configuration = new HandlebarsConfiguration();
			}
			return new HandlebarsEnvironment(new HandlebarsConfigurationAdapter(configuration));
		}

		internal static IHandlebars Create(ICompiledHandlebarsConfiguration configuration)
		{
			if (configuration == null)
			{
				configuration = new HandlebarsConfigurationAdapter(new HandlebarsConfiguration());
			}
			return new HandlebarsEnvironment(configuration);
		}

		public static HandlebarsTemplate<TextWriter, object, object> Compile(TextReader template)
		{
			return Instance.Compile(template);
		}

		public static HandlebarsTemplate<object, object> Compile(string template)
		{
			return Instance.Compile(template);
		}

		public static HandlebarsTemplate<object, object> CompileView(string templatePath)
		{
			return Instance.CompileView(templatePath);
		}

		public static HandlebarsTemplate<TextWriter, object, object> CompileView(string templatePath, ViewReaderFactory readerFactoryFactory)
		{
			return Instance.CompileView(templatePath, readerFactoryFactory);
		}

		public static void RegisterTemplate(string templateName, HandlebarsTemplate<TextWriter, object, object> template)
		{
			Instance.RegisterTemplate(templateName, template);
		}

		public static void RegisterTemplate(string templateName, string template)
		{
			Instance.RegisterTemplate(templateName, template);
		}

		public static void RegisterHelper(string helperName, HandlebarsHelper helperFunction)
		{
			Instance.RegisterHelper(helperName, helperFunction);
		}

		public static void RegisterHelper(string helperName, HandlebarsHelperWithOptions helperFunction)
		{
			Instance.RegisterHelper(helperName, helperFunction);
		}

		public static void RegisterHelper(string helperName, HandlebarsReturnHelper helperFunction)
		{
			Instance.RegisterHelper(helperName, helperFunction);
		}

		public static void RegisterHelper(string helperName, HandlebarsReturnWithOptionsHelper helperFunction)
		{
			Instance.RegisterHelper(helperName, helperFunction);
		}

		public static void RegisterHelper(string helperName, HandlebarsBlockHelper helperFunction)
		{
			Instance.RegisterHelper(helperName, helperFunction);
		}

		public static void RegisterHelper(string helperName, HandlebarsReturnBlockHelper helperFunction)
		{
			Instance.RegisterHelper(helperName, helperFunction);
		}

		public static void RegisterHelper(IHelperDescriptor<HelperOptions> helperObject)
		{
			Instance.RegisterHelper(helperObject);
		}

		public static void RegisterHelper(IHelperDescriptor<BlockHelperOptions> helperObject)
		{
			Instance.RegisterHelper(helperObject);
		}

		public void RegisterDecorator(string helperName, HandlebarsBlockDecorator helperFunction)
		{
			Instance.RegisterDecorator(helperName, helperFunction);
		}

		public void RegisterDecorator(string helperName, HandlebarsDecorator helperFunction)
		{
			Instance.RegisterDecorator(helperName, helperFunction);
		}

		public void RegisterDecorator(string helperName, HandlebarsBlockDecoratorVoid helperFunction)
		{
			Instance.RegisterDecorator(helperName, helperFunction);
		}

		public void RegisterDecorator(string helperName, HandlebarsDecoratorVoid helperFunction)
		{
			Instance.RegisterDecorator(helperName, helperFunction);
		}
	}
}
