using System.Collections.Generic;
using CLanguage.Compiler;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public class MultiDeclaratorStatement : Statement
	{
		public DeclarationSpecifiers Specifiers;

		public List<InitDeclarator>? InitDeclarators;

		public override bool AlwaysReturns => false;

		public MultiDeclaratorStatement(DeclarationSpecifiers specifiers, List<InitDeclarator>? initDeclarators)
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

		private static ExpressionStatement GetCtorInitializerStatement(string name, CStructType ctorDeclType, FunctionDeclarator ctorDecl)
		{
			return null;
		}

		private static Expression GetInitializerExpression(Initializer init)
		{
			return null;
		}

		private static bool HasStronglyBoundPointer(Declarator? d)
		{
			return false;
		}
	}
}
