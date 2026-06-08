using System.Linq.Expressions;

namespace HandlebarsDotNet.Compiler
{
	internal static class ContextBinder
	{
		public static Expression<TemplateDelegate> Bind(CompilationContext context, Expression body)
		{
			return Expression.Lambda<TemplateDelegate>((BlockExpression)body, new ParameterExpression[2] { context.EncodedWriter, context.BindingContext });
		}
	}
}
