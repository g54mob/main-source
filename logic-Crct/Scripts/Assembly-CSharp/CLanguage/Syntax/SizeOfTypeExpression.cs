using CLanguage.Compiler;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public class SizeOfTypeExpression : Expression
	{
		public TypeName TypeName { get; }

		public SizeOfTypeExpression(TypeName typeName)
		{
		}

		public override CType GetEvaluatedCType(EmitContext ec)
		{
			return null;
		}

		protected override void DoEmit(EmitContext ec)
		{
		}
	}
}
