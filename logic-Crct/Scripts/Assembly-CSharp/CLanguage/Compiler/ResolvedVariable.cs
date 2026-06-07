using CLanguage.Interpreter;
using CLanguage.Types;

namespace CLanguage.Compiler
{
	public class ResolvedVariable
	{
		public VariableScope Scope { get; }

		public int Address { get; }

		public CType VariableType { get; }

		public BaseFunction? Function { get; }

		public Value Constant { get; }

		public ResolvedVariable(VariableScope scope, int address, CType variableType)
		{
		}

		public ResolvedVariable(BaseFunction function, int address)
		{
		}

		public ResolvedVariable(Value constantValue, CType variableType)
		{
		}

		public void Emit(EmitContext ec)
		{
		}

		public void EmitPointer(EmitContext ec)
		{
		}
	}
}
