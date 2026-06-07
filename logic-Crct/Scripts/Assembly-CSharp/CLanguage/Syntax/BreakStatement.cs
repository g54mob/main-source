using CLanguage.Compiler;

namespace CLanguage.Syntax
{
	public class BreakStatement : Statement
	{
		public override bool AlwaysReturns => false;

		public override void AddDeclarationToBlock(BlockContext context)
		{
		}

		protected override void DoEmit(EmitContext ec)
		{
		}
	}
}
