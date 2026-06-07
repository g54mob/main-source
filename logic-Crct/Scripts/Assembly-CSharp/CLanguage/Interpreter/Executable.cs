using System.Collections.Generic;
using CLanguage.Types;

namespace CLanguage.Interpreter
{
	public class Executable
	{
		private readonly List<CompiledVariable> globals;

		public MachineInfo MachineInfo { get; private set; }

		public List<BaseFunction> Functions { get; private set; }

		public IReadOnlyList<CompiledVariable> Globals => null;

		public Executable(MachineInfo machineInfo)
		{
		}

		public CompiledVariable AddGlobal(string name, CType type)
		{
			return null;
		}

		public Value GetConstantMemory(string stringConstant)
		{
			return default(Value);
		}
	}
}
