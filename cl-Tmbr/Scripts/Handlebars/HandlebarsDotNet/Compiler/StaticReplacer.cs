using System.Linq.Expressions;
using Expressions.Shortcuts;

namespace HandlebarsDotNet.Compiler
{
	internal class StaticReplacer : HandlebarsExpressionVisitor
	{
		private CompilationContext CompilationContext { get; }

		public StaticReplacer(CompilationContext compilationContext)
		{
			CompilationContext = compilationContext;
		}

		protected override Expression VisitStaticExpression(StaticExpression stex)
		{
			ExpressionContainer<EncodedTextWriter> encodedWriter = CompilationContext.Args.EncodedWriter;
			ExpressionContainer<string> value = ExpressionShortcuts.Arg(stex.Value);
			return encodedWriter.Call((EncodedTextWriter o) => o.Write((string)value, encode: false));
		}
	}
}
