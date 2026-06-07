using CLanguage.Compiler;

namespace CLanguage.Syntax
{
	public class VisibilityStatement : Statement
	{
		public DeclarationsVisibility Visibility { get; }

		public override bool AlwaysReturns => false;

		public VisibilityStatement(DeclarationsVisibility visibility)
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
