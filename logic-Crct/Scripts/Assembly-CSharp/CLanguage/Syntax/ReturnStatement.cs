using CLanguage.Compiler;

namespace CLanguage.Syntax
{
	public class ReturnStatement : Statement
	{
		public Expression? ReturnExpression { get; set; }

		public override bool AlwaysReturns => false;

		public ReturnStatement(Expression returnExpression)
		{
		}

		public ReturnStatement()
		{
		}

		protected override void DoEmit(EmitContext ec)
		{
		}

		public override void AddDeclarationToBlock(BlockContext context)
		{
		}
	}
}
