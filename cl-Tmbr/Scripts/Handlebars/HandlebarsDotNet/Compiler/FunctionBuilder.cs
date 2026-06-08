using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Expressions.Shortcuts;
using HandlebarsDotNet.Polyfills;

namespace HandlebarsDotNet.Compiler
{
	internal static class FunctionBuilder
	{
		private static readonly TemplateDelegate EmptyTemplateLambda = delegate
		{
		};

		public static Expression Reduce(Expression expression, CompilationContext context, out IReadOnlyList<DecoratorDefinition> decorators)
		{
			List<DecoratorDefinition> decorators2 = (List<DecoratorDefinition>)(decorators = new List<DecoratorDefinition>());
			expression = new CommentVisitor().Visit(expression);
			expression = new UnencodedStatementVisitor(context).Visit(expression);
			expression = new PartialBinder(context).Visit(expression);
			expression = new StaticReplacer(context).Visit(expression);
			expression = new IteratorBinder(context).Visit(expression);
			expression = new BlockHelperFunctionBinder(context, decorators2).Visit(expression);
			expression = new HelperFunctionBinder(context, decorators2).Visit(expression);
			expression = new BoolishConverter(context).Visit(expression);
			expression = new PathBinder(context).Visit(expression);
			expression = new SubExpressionVisitor(context).Visit(expression);
			expression = new HashParameterBinder().Visit(expression);
			return expression;
		}

		public static ExpressionContainer<TemplateDelegate> CreateExpression(IEnumerable<Expression> expressions, CompilationContext compilationContext, out IReadOnlyList<DecoratorDefinition> decorators)
		{
			try
			{
				decorators = ArrayEx.Empty<DecoratorDefinition>();
				Expression[] array = (expressions as Expression[]) ?? expressions.ToArray();
				if (!array.Any() || array.IsOneOf<Expression, DefaultExpression>())
				{
					return ExpressionShortcuts.Arg(EmptyTemplateLambda);
				}
				Expression expression = Expression.Block(array);
				expression = Reduce(expression, compilationContext, out decorators);
				return ExpressionShortcuts.Arg(ContextBinder.Bind(compilationContext, expression));
			}
			catch (Exception innerException)
			{
				throw new HandlebarsCompilerException("An unhandled exception occurred while trying to compile the template", innerException);
			}
		}

		public static TemplateDelegate Compile(IEnumerable<Expression> expressions, CompilationContext compilationContext, out IReadOnlyList<DecoratorDefinition> decorators)
		{
			try
			{
				ExpressionContainer<TemplateDelegate> expressionContainer = CreateExpression(expressions, compilationContext, out decorators);
				if (expressionContainer.Expression is ConstantExpression constantExpression)
				{
					return (TemplateDelegate)constantExpression.Value;
				}
				Expression<TemplateDelegate> expression = (Expression<TemplateDelegate>)expressionContainer.Expression;
				return compilationContext.Configuration.ExpressionCompiler.Compile(expression);
			}
			catch (Exception innerException)
			{
				throw new HandlebarsCompilerException("An unhandled exception occurred while trying to compile the template", innerException);
			}
		}
	}
}
