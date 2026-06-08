using System.Collections.Generic;
using System.Linq.Expressions;
using Expressions.Shortcuts;
using HandlebarsDotNet.Decorators;
using HandlebarsDotNet.Helpers;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.Compiler
{
	internal class HelperFunctionBinder : HandlebarsExpressionVisitor
	{
		private readonly List<DecoratorDefinition> _decorators;

		private CompilationContext CompilationContext { get; }

		public HelperFunctionBinder(CompilationContext compilationContext, List<DecoratorDefinition> decorators)
		{
			_decorators = decorators;
			CompilationContext = compilationContext;
		}

		protected override Expression VisitStatementExpression(StatementExpression sex)
		{
			if (!(sex.Body is HelperExpression))
			{
				return sex;
			}
			return Visit(sex.Body);
		}

		protected unsafe override Expression VisitHelperExpression(HelperExpression hex)
		{
			if (hex.HelperName.StartsWith("*"))
			{
				_decorators.Add(VisitDecoratorExpression(hex));
				return Expression.Empty();
			}
			PathInfo pathInfo = PathInfoStore.Current.GetOrAdd(hex.HelperName);
			if (!pathInfo.IsValidHelperLiteral && !CompilationContext.Configuration.Compatibility.RelaxedHelperNaming)
			{
				return Expression.Empty();
			}
			ExpressionContainer<BindingContext> bindingContext = CompilationContext.Args.BindingContext;
			ExpressionContainer<HelperOptions> options = ExpressionShortcuts.New(() => new HelperOptions(pathInfo, (BindingContext)bindingContext));
			ExpressionContainer<EncodedTextWriter> textWriter = CompilationContext.Args.EncodedWriter;
			ExpressionContainer<Context> contextValue = ExpressionShortcuts.New(() => new Context((BindingContext)bindingContext));
			ExpressionContainer<Arguments> args = FunctionBinderHelpers.CreateArguments(hex.Arguments, CompilationContext);
			ICompiledHandlebarsConfiguration configuration = CompilationContext.Configuration;
			if (configuration.Helpers.TryGetValue((PathInfoLight)pathInfo, out var helper))
			{
				return ExpressionShortcuts.Call(() => helper.Value.Invoke(in *(EncodedTextWriter*)(EncodedTextWriter)textWriter, in *(HelperOptions*)(HelperOptions)options, in *(Context*)(Context)contextValue, in *(Arguments*)(Arguments)args));
			}
			for (int num = 0; num < configuration.HelperResolvers.Count; num++)
			{
				if (configuration.HelperResolvers[num].TryResolveHelper(pathInfo, typeof(object), out var resolvedHelper))
				{
					helper = new Ref<IHelperDescriptor<HelperOptions>>(resolvedHelper);
					configuration.Helpers.AddOrReplace((PathInfoLight)pathInfo, in helper);
					return ExpressionShortcuts.Call(() => resolvedHelper.Invoke(in *(EncodedTextWriter*)(EncodedTextWriter)textWriter, in *(HelperOptions*)(HelperOptions)options, in *(Context*)(Context)contextValue, in *(Arguments*)(Arguments)args));
				}
			}
			Ref<IHelperDescriptor<HelperOptions>> lateBindDescriptor = new Ref<IHelperDescriptor<HelperOptions>>(new LateBindHelperDescriptor(pathInfo));
			configuration.Helpers.AddOrReplace((PathInfoLight)pathInfo, in lateBindDescriptor);
			return ExpressionShortcuts.Call(() => lateBindDescriptor.Value.Invoke(in *(EncodedTextWriter*)(EncodedTextWriter)textWriter, in *(HelperOptions*)(HelperOptions)options, in *(Context*)(Context)contextValue, in *(Arguments*)(Arguments)args));
		}

		private unsafe DecoratorDefinition VisitDecoratorExpression(HelperExpression hex)
		{
			PathInfo pathInfo = PathInfoStore.Current.GetOrAdd(hex.HelperName);
			if (!pathInfo.IsValidHelperLiteral && !CompilationContext.Configuration.Compatibility.RelaxedHelperNaming)
			{
				return default(DecoratorDefinition);
			}
			ExpressionContainer<BindingContext> bindingContext = CompilationContext.Args.BindingContext;
			ExpressionContainer<DecoratorOptions> options = ExpressionShortcuts.New(() => new DecoratorOptions(pathInfo, (BindingContext)bindingContext));
			ExpressionContainer<Context> contextValue = ExpressionShortcuts.New(() => new Context((BindingContext)bindingContext));
			ExpressionContainer<Arguments> args = FunctionBinderHelpers.CreateArguments(hex.Arguments, CompilationContext);
			ExpressionContainer<TemplateDelegate> parameter = ExpressionShortcuts.Parameter<TemplateDelegate>();
			ICompiledHandlebarsConfiguration configuration = CompilationContext.Configuration;
			if (configuration.Decorators.TryGetValue((PathInfoLight)pathInfo, out var helper))
			{
				return new DecoratorDefinition(ExpressionShortcuts.Call(() => helper.Value.Invoke(in *(TemplateDelegate*)(TemplateDelegate)parameter, in *(DecoratorOptions*)(DecoratorOptions)options, in *(Context*)(Context)contextValue, in *(Arguments*)(Arguments)args)), parameter);
			}
			Ref<IDecoratorDescriptor<DecoratorOptions>> emptyDecorator = new Ref<IDecoratorDescriptor<DecoratorOptions>>(new EmptyDecorator(pathInfo));
			configuration.Decorators.AddOrReplace((PathInfoLight)pathInfo, in emptyDecorator);
			return new DecoratorDefinition(ExpressionShortcuts.Call(() => emptyDecorator.Value.Invoke(in *(TemplateDelegate*)(TemplateDelegate)parameter, in *(DecoratorOptions*)(DecoratorOptions)options, in *(Context*)(Context)contextValue, in *(Arguments*)(Arguments)args)), parameter);
		}
	}
}
