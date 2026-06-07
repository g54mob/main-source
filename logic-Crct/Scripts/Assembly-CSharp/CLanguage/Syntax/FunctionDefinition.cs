using System.Collections.Generic;
using CLanguage.Compiler;

namespace CLanguage.Syntax
{
	public class FunctionDefinition : Statement
	{
		public DeclarationSpecifiers Specifiers { get; set; }

		public Declarator Declarator { get; set; }

		public List<Declaration>? ParameterDeclarations { get; set; }

		public Block Body { get; set; }

		public override bool AlwaysReturns => false;

		public FunctionDefinition(DeclarationSpecifiers specifiers, Declarator declarator, List<Declaration>? parameterDeclarations, Block body)
		{
		}

		public override void AddDeclarationToBlock(BlockContext context)
		{
		}

		protected override void DoEmit(EmitContext ec)
		{
		}
	}
}
