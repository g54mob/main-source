using System.Collections.Generic;
using CLanguage.Syntax;
using CLanguage.Types;

namespace CLanguage.Interpreter
{
	public class CompiledFunction : BaseFunction
	{
		public Block? Body { get; }

		public List<CompiledVariable> LocalVariables { get; }

		public List<Instruction> Instructions { get; }

		public string Assembler => null;

		public CompiledFunction(string name, string nameContext, CFunctionType functionType, Block? body)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override void Init(CInterpreter state)
		{
		}

		public override void Step(CInterpreter state, ExecutionFrame frame)
		{
		}

		private Value Convert(Value x, OpCode op)
		{
			return default(Value);
		}
	}
}
