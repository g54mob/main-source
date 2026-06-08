using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using HandlebarsDotNet.Compiler.Lexer;
using HandlebarsDotNet.Features;
using HandlebarsDotNet.IO;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Compiler
{
	internal static class HandlebarsCompiler
	{
		public static TemplateDelegate Compile(ExtendedStringReader source, CompilationContext compilationContext)
		{
			ICompiledHandlebarsConfiguration configuration = compilationContext.Configuration;
			IReadOnlyList<IFeature> features = configuration.Features;
			for (int i = 0; i < features.Count; i++)
			{
				features[i].OnCompiling(configuration);
			}
			IReadOnlyList<DecoratorDefinition> decorators;
			TemplateDelegate templateDelegate = FunctionBuilder.Compile(ExpressionBuilder.ConvertTokensToExpressions(Tokenizer.Tokenize(source).ToArray(), configuration), compilationContext, out decorators);
			if (decorators.Count > 0)
			{
				TemplateDelegate a1 = templateDelegate;
				DecoratorDelegate decorator = decorators.Compile(compilationContext);
				templateDelegate = delegate(in EncodedTextWriter writer, BindingContext context)
				{
					decorator(in writer, context, a1)(in writer, context);
				};
			}
			for (int num = 0; num < features.Count; num++)
			{
				features[num].CompilationCompleted();
			}
			return templateDelegate;
		}

		internal static TemplateDelegate CompileView(ViewReaderFactory readerFactoryFactory, string templatePath, CompilationContext compilationContext)
		{
			ICompiledHandlebarsConfiguration configuration = compilationContext.Configuration;
			IEnumerable<object> enumerable;
			using (TextReader reader = readerFactoryFactory(configuration, templatePath))
			{
				using ExtendedStringReader source = new ExtendedStringReader(reader);
				enumerable = Tokenizer.Tokenize(source).ToArray();
			}
			LayoutToken layoutToken = enumerable.OfType<LayoutToken>().SingleOrDefault();
			IEnumerable<Expression> expressions = ExpressionBuilder.ConvertTokensToExpressions(enumerable, configuration);
			IReadOnlyList<DecoratorDefinition> decorators;
			TemplateDelegate compiledView = FunctionBuilder.Compile(expressions, compilationContext, out decorators);
			if (decorators.Count > 0)
			{
				TemplateDelegate a1 = compiledView;
				DecoratorDelegate decorator = decorators.Compile(compilationContext);
				compiledView = delegate(in EncodedTextWriter writer, BindingContext context)
				{
					decorator(in writer, context, a1)(in writer, context);
				};
			}
			if (layoutToken == null)
			{
				return compiledView;
			}
			string text = configuration.FileSystem.Closest(templatePath, layoutToken.Value + ".hbs");
			if (text == null)
			{
				throw new InvalidOperationException("Cannot find layout '" + layoutToken.Value + "' for template '" + templatePath + "'");
			}
			TemplateDelegate compiledLayout = CompileView(readerFactoryFactory, text, new CompilationContext(compilationContext));
			return delegate(in EncodedTextWriter writer, BindingContext context)
			{
				ICompiledHandlebarsConfiguration configuration2 = context.Configuration;
				using BindingContext bindingContext = BindingContext.Create(configuration2, null);
				foreach (KeyValuePair<ChainSegment, object> item in context.ContextDataObject)
				{
					WellKnownVariable wellKnownVariable = item.Key.WellKnownVariable;
					if ((uint)(wellKnownVariable - 5) > 1u)
					{
						bindingContext.ContextDataObject[item.Key] = item.Value;
					}
				}
				using ReusableStringWriter reusableStringWriter = ReusableStringWriter.Get(configuration2.FormatProvider);
				using EncodedTextWriter writer2 = new EncodedTextWriter(reusableStringWriter, configuration2.TextEncoder, FormatterProvider.Current, suppressEncoding: true);
				compiledView(in writer2, context);
				LayoutViewModel value = new LayoutViewModel(reusableStringWriter.ToString(), context.Value);
				bindingContext.Value = value;
				compiledLayout(in writer, bindingContext);
			};
		}
	}
}
