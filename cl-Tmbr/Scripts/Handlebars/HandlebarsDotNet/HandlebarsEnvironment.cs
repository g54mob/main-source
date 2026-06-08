using System;
using System.Collections.Generic;
using System.IO;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.Decorators;
using HandlebarsDotNet.Features;
using HandlebarsDotNet.Helpers;
using HandlebarsDotNet.IO;
using HandlebarsDotNet.ObjectDescriptors;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet
{
	internal class HandlebarsEnvironment : IHandlebars, IHelpersRegistry, ICompiledHandlebars
	{
		private static readonly ViewReaderFactory ViewReaderFactory = (ICompiledHandlebarsConfiguration configuration, string path) => new StringReader((configuration.FileSystem ?? throw new InvalidOperationException("Cannot compile view when configuration.FileSystem is not set")).GetFileContent(path) ?? throw new InvalidOperationException("Cannot find template at '" + path + "'"));

		private readonly AmbientContext _ambientContext = AmbientContext.Create();

		public bool IsSharedEnvironment { get; }

		public HandlebarsConfiguration Configuration { get; }

		internal ICompiledHandlebarsConfiguration CompiledConfiguration { get; }

		ICompiledHandlebarsConfiguration ICompiledHandlebars.CompiledConfiguration => CompiledConfiguration;

		public HandlebarsEnvironment(HandlebarsConfiguration configuration)
		{
			Configuration = configuration ?? throw new ArgumentNullException("configuration");
		}

		internal HandlebarsEnvironment(ICompiledHandlebarsConfiguration configuration)
		{
			CompiledConfiguration = configuration ?? throw new ArgumentNullException("configuration");
			Configuration = CompiledConfiguration.UnderlingConfiguration;
			IsSharedEnvironment = true;
		}

		public HandlebarsTemplate<TextWriter, object, object> CompileView(string templatePath, ViewReaderFactory readerFactoryFactory)
		{
			if (readerFactoryFactory == null)
			{
				readerFactoryFactory = ViewReaderFactory;
			}
			return CompileViewInternal(templatePath, readerFactoryFactory);
		}

		public HandlebarsTemplate<object, object> CompileView(string templatePath)
		{
			HandlebarsTemplate<TextWriter, object, object> view = CompileViewInternal(templatePath, ViewReaderFactory);
			return delegate(object vm, object data)
			{
				using ReusableStringWriter reusableStringWriter = ReusableStringWriter.Get(Configuration?.FormatProvider ?? CompiledConfiguration.FormatProvider);
				view(reusableStringWriter, vm, data);
				return reusableStringWriter.ToString();
			};
		}

		private HandlebarsTemplate<TextWriter, object, object> CompileViewInternal(string templatePath, ViewReaderFactory readerFactoryFactory)
		{
			using (AmbientContext.Use(_ambientContext))
			{
				ICompiledHandlebarsConfiguration configuration = CompiledConfiguration ?? new HandlebarsConfigurationAdapter(Configuration);
				FormatterProvider formatterProvider = new FormatterProvider(configuration.FormatterProviders);
				ObjectDescriptorFactory descriptorFactory = new ObjectDescriptorFactory(configuration.ObjectDescriptorProviders);
				AmbientContext localContext = AmbientContext.Create(_ambientContext, null, null, null, formatterProvider, descriptorFactory);
				using (AmbientContext.Use(localContext))
				{
					IReadOnlyList<IFeature> features = configuration.Features;
					for (int i = 0; i < features.Count; i++)
					{
						features[i].OnCompiling(configuration);
					}
					CompilationContext compilationContext = new CompilationContext(configuration);
					TemplateDelegate compiledView = HandlebarsCompiler.CompileView(readerFactoryFactory, templatePath, compilationContext);
					for (int j = 0; j < features.Count; j++)
					{
						features[j].CompilationCompleted();
					}
					return delegate(TextWriter writer, object context, object data)
					{
						using (AmbientContext.Use(localContext))
						{
							if (context is BindingContext bindingContext)
							{
								bindingContext.Extensions["templatePath"] = templatePath;
								ICompiledHandlebarsConfiguration configuration2 = bindingContext.Configuration;
								using EncodedTextWriter writer2 = new EncodedTextWriter(writer, configuration2.TextEncoder, formatterProvider, configuration2.NoEscape);
								compiledView(in writer2, bindingContext);
								return;
							}
							using BindingContext bindingContext2 = BindingContext.Create(configuration, context);
							bindingContext2.Extensions["templatePath"] = templatePath;
							bindingContext2.SetDataObject(data);
							using EncodedTextWriter writer3 = new EncodedTextWriter(writer, configuration.TextEncoder, formatterProvider, configuration.NoEscape);
							compiledView(in writer3, bindingContext2);
						}
					};
				}
			}
		}

		public IHandlebars CreateSharedEnvironment()
		{
			return new HandlebarsEnvironment(CompiledConfiguration ?? new HandlebarsConfigurationAdapter(Configuration));
		}

		public HandlebarsTemplate<TextWriter, object, object> Compile(TextReader template)
		{
			using (AmbientContext.Use(_ambientContext))
			{
				ICompiledHandlebarsConfiguration configuration = CompiledConfiguration ?? new HandlebarsConfigurationAdapter(Configuration);
				FormatterProvider formatterProvider = new FormatterProvider(configuration.FormatterProviders);
				ObjectDescriptorFactory descriptorFactory = new ObjectDescriptorFactory(configuration.ObjectDescriptorProviders);
				AmbientContext localContext = AmbientContext.Create(_ambientContext, null, null, null, formatterProvider, descriptorFactory);
				using (AmbientContext.Use(localContext))
				{
					CompilationContext compilationContext = new CompilationContext(configuration);
					using ExtendedStringReader source = new ExtendedStringReader(template);
					TemplateDelegate compiledTemplate = HandlebarsCompiler.Compile(source, compilationContext);
					return delegate(TextWriter writer, object context, object data)
					{
						using (AmbientContext.Use(localContext))
						{
							if (writer is EncodedTextWriterWrapper { UnderlyingWriter: var writer2 })
							{
								if (context is BindingContext context2)
								{
									compiledTemplate(in writer2, context2);
									return;
								}
								using BindingContext bindingContext = BindingContext.Create(configuration, context);
								bindingContext.SetDataObject(data);
								compiledTemplate(in writer2, bindingContext);
								return;
							}
							if (context is BindingContext { Configuration: var configuration2 } bindingContext2)
							{
								using EncodedTextWriter writer3 = new EncodedTextWriter(writer, configuration2.TextEncoder, formatterProvider, configuration2.NoEscape);
								compiledTemplate(in writer3, bindingContext2);
								return;
							}
							using BindingContext bindingContext3 = BindingContext.Create(configuration, context);
							bindingContext3.SetDataObject(data);
							using EncodedTextWriter writer4 = new EncodedTextWriter(writer, configuration.TextEncoder, formatterProvider, configuration.NoEscape);
							compiledTemplate(in writer4, bindingContext3);
						}
					};
				}
			}
		}

		public HandlebarsTemplate<object, object> Compile(string template)
		{
			using StringReader template2 = new StringReader(template);
			HandlebarsTemplate<TextWriter, object, object> compiledTemplate = Compile(template2);
			return delegate(object context, object data)
			{
				using ReusableStringWriter reusableStringWriter = ReusableStringWriter.Get(Configuration?.FormatProvider ?? CompiledConfiguration?.FormatProvider);
				compiledTemplate(reusableStringWriter, context, data);
				return reusableStringWriter.ToString();
			};
		}

		public void RegisterTemplate(string templateName, HandlebarsTemplate<TextWriter, object, object> template)
		{
			IHandlebarsTemplateRegistrations configuration = Configuration;
			(configuration ?? CompiledConfiguration).RegisteredTemplates[in templateName] = template;
		}

		public void RegisterTemplate(string templateName, string template)
		{
			using StringReader template2 = new StringReader(template);
			RegisterTemplate(templateName, Compile(template2));
		}

		public void RegisterDecorator(string helperName, HandlebarsBlockDecorator helperFunction)
		{
			Configuration.BlockDecorators["*" + helperName] = new DelegateBlockDecoratorDescriptor(helperName, helperFunction);
		}

		public void RegisterDecorator(string helperName, HandlebarsDecorator helperFunction)
		{
			Configuration.Decorators["*" + helperName] = new DelegateDecoratorDescriptor(helperName, helperFunction);
		}

		public void RegisterDecorator(string helperName, HandlebarsBlockDecoratorVoid helperFunction)
		{
			Configuration.BlockDecorators["*" + helperName] = new DelegateBlockDecoratorVoidDescriptor(helperName, helperFunction);
		}

		public void RegisterDecorator(string helperName, HandlebarsDecoratorVoid helperFunction)
		{
			Configuration.Decorators["*" + helperName] = new DelegateDecoratorVoidDescriptor(helperName, helperFunction);
		}

		public DisposableContainer Configure()
		{
			return AmbientContext.Use(_ambientContext);
		}

		public IIndexed<string, IHelperDescriptor<HelperOptions>> GetHelpers()
		{
			return Configuration.Helpers;
		}

		public IIndexed<string, IHelperDescriptor<BlockHelperOptions>> GetBlockHelpers()
		{
			return Configuration.BlockHelpers;
		}
	}
}
