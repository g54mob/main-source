using CLanguage.Compiler;

namespace CLanguage.Syntax
{
	public class IfStatement : Statement
	{
		public Expression Condition { get; private set; }

		public Statement TrueStatement { get; private set; }

		public Statement? FalseStatement { get; private set; }

		public override bool AlwaysReturns => false;

		public IfStatement(Expression condition, Statement trueStatement, Statement? falseStatement, Location loc)
		{
		}

		public IfStatement(Expression condition, Statement trueStatement, Location loc)
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
