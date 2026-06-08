using System.Linq.Expressions;
using Expressions.Shortcuts;
using HandlebarsDotNet.Helpers;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.Compiler
{
	internal class PathBinder : HandlebarsExpressionVisitor
	{
		private CompilationContext CompilationContext { get; }

		public PathBinder(CompilationContext compilationContext)
		{
			CompilationContext = compilationContext;
		}

		protected override Expression VisitStatementExpression(StatementExpression sex)
		{
			if (!(sex.Body is PathExpression))
			{
				return Visit(sex.Body);
			}
			ExpressionContainer<EncodedTextWriter> encodedWriter = CompilationContext.Args.EncodedWriter;
			ExpressionContainer<object> value = ExpressionShortcuts.Arg<object>(Visit(sex.Body));
			return encodedWriter.Call((EncodedTextWriter o) => o.Write<object>((object)value));
		}

		protected unsafe override Expression VisitPathExpression(PathExpression pex)
		{
			ExpressionContainer<BindingContext> bindingContext = CompilationContext.Args.BindingContext;
			ICompiledHandlebarsConfiguration configuration = CompilationContext.Configuration;
			PathInfo pathInfo = PathInfoStore.Current.GetOrAdd(pex.Path);
			ExpressionContainer<object> expressionContainer = ExpressionShortcuts.Call(() => PathResolver.ResolvePath((BindingContext)bindingContext, pathInfo));
			if (pex.Context == PathExpression.ResolutionContext.Parameter)
			{
				return expressionContainer;
			}
			if (pathInfo.IsVariable || pathInfo.IsThis)
			{
				return expressionContainer;
			}
			if (!pathInfo.IsValidHelperLiteral && !configuration.Compatibility.RelaxedHelperNaming)
			{
				return expressionContainer;
			}
			PathInfoLight key = new PathInfoLight(pathInfo);
			if (!configuration.Helpers.TryGetValue(in key, out var helper))
			{
				LateBindHelperDescriptor value = new LateBindHelperDescriptor(pathInfo);
				helper = new Ref<IHelperDescriptor<HelperOptions>>(value);
				configuration.Helpers.AddOrReplace(in key, in helper);
			}
			else if (configuration.Compatibility.RelaxedHelperNaming)
			{
				key = key.TagComparer();
				if (!configuration.Helpers.ContainsKey(in key))
				{
					LateBindHelperDescriptor value2 = new LateBindHelperDescriptor(pathInfo);
					helper = new Ref<IHelperDescriptor<HelperOptions>>(value2);
					configuration.Helpers.AddOrReplace(in key, in helper);
				}
			}
			ExpressionContainer<HelperOptions> options = ExpressionShortcuts.New(() => new HelperOptions(pathInfo, (BindingContext)bindingContext));
			ExpressionContainer<Context> context = ExpressionShortcuts.New(() => new Context((BindingContext)bindingContext));
			ExpressionContainer<Arguments> argumentsArg = ExpressionShortcuts.New(() => new Arguments(0));
			return ExpressionShortcuts.Call(() => helper.Value.Invoke(in *(HelperOptions*)(HelperOptions)options, in *(Context*)(Context)context, in *(Arguments*)(Arguments)argumentsArg));
		}
	}
}
