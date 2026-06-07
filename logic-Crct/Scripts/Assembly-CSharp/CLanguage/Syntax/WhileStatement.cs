using CLanguage.Compiler;

namespace CLanguage.Syntax
{
	public class WhileStatement : Statement
	{
		public bool IsDo { get; private set; }

		public Expression Condition { get; private set; }

		public Block Loop { get; private set; }

		public override bool AlwaysReturns => false;

		public WhileStatement(bool isDo, Expression condition, Block loop)
		{
		}

		protected override void DoEmit(EmitContext parentContext)
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
