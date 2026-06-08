using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using Expressions.Shortcuts;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Polyfills;

namespace HandlebarsDotNet.Compiler
{
	internal class PartialBinder : HandlebarsExpressionVisitor
	{
		private static string SpecialPartialBlockName = "@partial-block";

		private CompilationContext CompilationContext { get; }

		public PartialBinder(CompilationContext compilationContext)
		{
			CompilationContext = compilationContext;
		}

		protected override Expression VisitBlockHelperExpression(BlockHelperExpression bhex)
		{
			return bhex;
		}

		protected override Expression VisitStatementExpression(StatementExpression sex)
		{
			if (!(sex.Body is PartialExpression))
			{
				return sex;
			}
			return Visit(sex.Body);
		}

		protected unsafe override Expression VisitPartialExpression(PartialExpression pex)
		{
			IReadOnlyList<DecoratorDefinition> decorators = ArrayEx.Empty<DecoratorDefinition>();
			TemplateDelegate templateDelegate = ((pex.Fallback != null) ? FunctionBuilder.Compile(new Expression[1] { pex.Fallback }, CompilationContext, out decorators) : null);
			IReadOnlyList<DecoratorDefinition> decorators2;
			if (decorators.Count > 0)
			{
				ExpressionContainer<BindingContext> bindingContext = CompilationContext.Args.BindingContext;
				ExpressionContainer<EncodedTextWriter> writer = CompilationContext.Args.EncodedWriter;
				ExpressionContainer<BindingContext> parentContext = bindingContext;
				if (pex.Argument != null || templateDelegate != null)
				{
					ExpressionContainer<object> value = ((pex.Argument != null) ? ExpressionShortcuts.Arg<object>(FunctionBuilder.Reduce(pex.Argument, CompilationContext, out decorators2)) : bindingContext.Property((BindingContext o) => o.Value));
					ExpressionContainer<TemplateDelegate> partialTemplate = ExpressionShortcuts.Arg(templateDelegate);
					bindingContext = bindingContext.Call((BindingContext o) => o.CreateChildContext(value, (TemplateDelegate)partialTemplate));
				}
				ExpressionContainer<string> partialName = ExpressionShortcuts.Cast<string>(pex.PartialName);
				ExpressionContainer<ICompiledHandlebarsConfiguration> configuration = ExpressionShortcuts.Arg(CompilationContext.Configuration);
				TemplateDelegate templateDelegate2 = FunctionBuilder.Compile(new Expression[1] { ExpressionShortcuts.Call(() => InvokePartialWithFallback((string)partialName, (BindingContext)bindingContext, (EncodedTextWriter)writer, (ICompiledHandlebarsConfiguration)configuration)).Expression }, CompilationContext, out decorators2);
				DecoratorDelegate decorator = decorators.Compile(CompilationContext);
				return ExpressionShortcuts.Call(() => decorator(in *(EncodedTextWriter*)(EncodedTextWriter)writer, (BindingContext)parentContext, templateDelegate2)).Call((TemplateDelegate f) => f(in *(EncodedTextWriter*)(EncodedTextWriter)writer, (BindingContext)parentContext));
			}
			ExpressionContainer<BindingContext> bindingContext2 = CompilationContext.Args.BindingContext;
			ExpressionContainer<EncodedTextWriter> writer2 = CompilationContext.Args.EncodedWriter;
			if (pex.Argument != null || templateDelegate != null)
			{
				ExpressionContainer<object> value2 = ((pex.Argument != null) ? ExpressionShortcuts.Arg<object>(FunctionBuilder.Reduce(pex.Argument, CompilationContext, out decorators2)) : bindingContext2.Property((BindingContext o) => o.Value));
				ExpressionContainer<TemplateDelegate> partialTemplate2 = ExpressionShortcuts.Arg(templateDelegate);
				bindingContext2 = bindingContext2.Call((BindingContext o) => o.CreateChildContext(value2, (TemplateDelegate)partialTemplate2));
			}
			ExpressionContainer<string> partialName2 = ExpressionShortcuts.Cast<string>(pex.PartialName);
			ExpressionContainer<ICompiledHandlebarsConfiguration> configuration2 = ExpressionShortcuts.Arg(CompilationContext.Configuration);
			return ExpressionShortcuts.Call(() => InvokePartialWithFallback((string)partialName2, (BindingContext)bindingContext2, (EncodedTextWriter)writer2, (ICompiledHandlebarsConfiguration)configuration2));
		}

		private static void InvokePartialWithFallback(string partialName, BindingContext context, EncodedTextWriter writer, ICompiledHandlebarsConfiguration configuration)
		{
			partialName = ((partialName != null) ? ChainSegment.Create(partialName).TrimmedValue : null);
			if (InvokePartial(partialName, context, writer, configuration))
			{
				return;
			}
			if (context.PartialBlockTemplate == null)
			{
				if (configuration.MissingPartialTemplateHandler == null)
				{
					throw new HandlebarsRuntimeException("Referenced partial name " + partialName + " could not be resolved");
				}
				configuration.MissingPartialTemplateHandler.Handle(configuration, partialName, in writer);
			}
			else
			{
				context.PartialBlockTemplate(in writer, context);
			}
		}

		private static bool InvokePartial(string partialName, BindingContext context, EncodedTextWriter writer, ICompiledHandlebarsConfiguration configuration)
		{
			if (partialName.Equals(SpecialPartialBlockName))
			{
				if (context.PartialBlockTemplate == null)
				{
					return false;
				}
				TemplateDelegate partialBlockTemplate = context.PartialBlockTemplate;
				try
				{
					context.PartialBlockTemplate = context.ParentContext.PartialBlockTemplate;
					partialBlockTemplate(in writer, context);
				}
				finally
				{
					context.PartialBlockTemplate = partialBlockTemplate;
				}
				return true;
			}
			if (context.InlinePartialTemplates.TryGetValue(in partialName, out var value))
			{
				IncreaseDepth();
				try
				{
					value(writer, context);
				}
				finally
				{
					context.PartialDepth--;
				}
				return true;
			}
			if (!configuration.RegisteredTemplates.ContainsKey(in partialName))
			{
				IHandlebars env = Handlebars.Create(configuration);
				if (configuration.PartialTemplateResolver == null || !configuration.PartialTemplateResolver.TryRegisterPartial(env, partialName, (string)context.Extensions.Optional("templatePath")))
				{
					return false;
				}
			}
			IncreaseDepth();
			try
			{
				using TextWriter writer2 = writer.CreateWrapper();
				configuration.RegisteredTemplates[in partialName](writer2, context);
				return true;
			}
			catch (Exception innerException)
			{
				throw new HandlebarsRuntimeException("Runtime error while rendering partial '" + partialName + "', see inner exception for more information", innerException);
			}
			finally
			{
				context.PartialDepth--;
			}
			void IncreaseDepth()
			{
				if (++context.PartialDepth > configuration.PartialRecursionDepthLimit)
				{
					throw new HandlebarsRuntimeException($"Runtime error while rendering partial '{partialName}', exceeded recursion depth limit of {configuration.PartialRecursionDepthLimit}");
				}
			}
		}
	}
}
