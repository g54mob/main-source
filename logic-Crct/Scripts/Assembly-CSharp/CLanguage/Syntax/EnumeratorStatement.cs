using CLanguage.Compiler;

namespace CLanguage.Syntax
{
	public class EnumeratorStatement : Statement
	{
		public string Name { get; }

		public Expression? LiteralValue { get; }

		public override bool AlwaysReturns => false;

		public EnumeratorStatement(string left, Expression? right = null)
		{
		}

		public override string ToString()
		{
			return null;
		}

		protected override void DoEmit(EmitContext ec)
		{
		}

		public override void AddDeclarationToBlock(BlockContext context)
		{
		}
	}
}
