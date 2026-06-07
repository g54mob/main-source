using CLanguage.Types;

namespace CLanguage.Interpreter
{
	public class CompiledVariable
	{
		public string Name { get; }

		public CType VariableType { get; }

		public int StackOffset { get; set; }

		public Value[]? InitialValue { get; set; }

		public CompiledVariable(string name, int offset, CType type)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
