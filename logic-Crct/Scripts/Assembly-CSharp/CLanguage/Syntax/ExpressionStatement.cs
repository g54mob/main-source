using CLanguage.Compiler;

namespace CLanguage.Syntax
{
	public class ExpressionStatement : Statement
	{
		public Expression Expression { get; set; }

		public override bool AlwaysReturns => false;

		public ExpressionStatement(Expression expr)
		{
		}

		protected override void DoEmit(EmitContext ec)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override void AddDeclarationToBlock(BlockContext context)
		{
		}
	}
}
