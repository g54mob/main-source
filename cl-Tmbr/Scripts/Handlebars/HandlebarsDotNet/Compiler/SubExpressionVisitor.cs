using System.Linq.Expressions;
using Expressions.Shortcuts;
using HandlebarsDotNet.Helpers;

namespace HandlebarsDotNet.Compiler
{
	internal class SubExpressionVisitor : HandlebarsExpressionVisitor
	{
		private CompilationContext CompilationContext { get; }

		public SubExpressionVisitor(CompilationContext compilationContext)
		{
			CompilationContext = compilationContext;
		}

		protected override Expression VisitSubExpression(SubExpressionExpression subex)
		{
			if (subex.Expression is MethodCallExpression helperCall)
			{
				return HandleMethodCallExpression(helperCall);
			}
			if (FunctionBuilder.Reduce(subex.Expression, CompilationContext, out var _) is MethodCallExpression helperCall2)
			{
				return HandleMethodCallExpression(helperCall2);
			}
			throw new HandlebarsCompilerException("Sub-expression does not contain a converted MethodCall expression");
		}

		private unsafe static Expression HandleMethodCallExpression(MethodCallExpression helperCall)
		{
			ExpressionContainer<HelperOptions> options = ExpressionShortcuts.Arg<HelperOptions>(helperCall.Arguments[1]);
			ExpressionContainer<Context> context = ExpressionShortcuts.Arg<Context>(helperCall.Arguments[2]);
			ExpressionContainer<Arguments> arguments = ExpressionShortcuts.Arg<Arguments>(helperCall.Arguments[3]);
			return ExpressionShortcuts.Arg<IHelperDescriptor<HelperOptions>>(helperCall.Object).Call((IHelperDescriptor<HelperOptions> o) => o.Invoke(in *(HelperOptions*)(HelperOptions)options, in *(Context*)(Context)context, in *(Arguments*)(Arguments)arguments));
		}
	}
}
