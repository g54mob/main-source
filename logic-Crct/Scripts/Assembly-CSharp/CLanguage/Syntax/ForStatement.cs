using CLanguage.Compiler;

namespace CLanguage.Syntax
{
	public class ForStatement : Statement
	{
		public Block InitBlock { get; private set; }

		public Expression ContinueExpression { get; private set; }

		public Expression? NextExpression { get; private set; }

		public Block LoopBody { get; private set; }

		public override bool AlwaysReturns => false;

		public ForStatement(Statement initStatement, Expression continueExpr, Block body)
		{
		}

		public ForStatement(Statement initStatement, Expression continueExpr, Expression nextExpr, Block body)
		{
		}

		public override string ToString()
		{
			return null;
		}

		protected override void DoEmit(EmitContext initialContext)
		{
		}

		public override void AddDeclarationToBlock(BlockContext context)
		{
		}
	}
}
