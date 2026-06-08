using System.Linq.Expressions;
using Expressions.Shortcuts;

namespace HandlebarsDotNet.Compiler
{
	internal readonly struct DecoratorDefinition
	{
		public Expression Decorator { get; }

		public ExpressionContainer<TemplateDelegate> Function { get; }

		public DecoratorDefinition(Expression decorator, ExpressionContainer<TemplateDelegate> function)
		{
			Decorator = decorator;
			Function = function;
		}

		public DecoratorDelegate Compile(CompilationContext context)
		{
			if (Function == null || Decorator == null)
			{
				return delegate(in EncodedTextWriter writer, BindingContext bindingContext, TemplateDelegate function)
				{
					return function;
				};
			}
			Expression<DecoratorDelegate> expression = Expression.Lambda<DecoratorDelegate>(Decorator, new ParameterExpression[3]
			{
				context.EncodedWriter,
				context.BindingContext,
				Function.Expression as ParameterExpression
			});
			return context.Configuration.ExpressionCompiler.Compile(expression);
		}
	}
}
