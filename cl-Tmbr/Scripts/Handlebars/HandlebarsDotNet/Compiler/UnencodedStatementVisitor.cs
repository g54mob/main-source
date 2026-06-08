using System.Linq.Expressions;
using Expressions.Shortcuts;

namespace HandlebarsDotNet.Compiler
{
	internal class UnencodedStatementVisitor : HandlebarsExpressionVisitor
	{
		private CompilationContext CompilationContext { get; }

		public UnencodedStatementVisitor(CompilationContext compilationContext)
		{
			CompilationContext = compilationContext;
		}

		protected override Expression VisitStatementExpression(StatementExpression sex)
		{
			if (!sex.IsEscaped)
			{
				ExpressionContainer<bool> expressionContainer = CompilationContext.Args.EncodedWriter.Property((EncodedTextWriter o) => o.SuppressEncoding);
				ExpressionContainer<bool> parameter;
				return ExpressionShortcuts.Block().Parameter(out parameter).Line(parameter.Assign(expressionContainer))
					.Line(expressionContainer.Assign(value: true))
					.Line(sex)
					.Line(expressionContainer.Assign(parameter));
			}
			return sex;
		}
	}
}
