using System.Collections.Generic;
using CLanguage.Interpreter;
using CLanguage.Syntax;
using CLanguage.Types;

namespace CLanguage.Compiler
{
	internal class FunctionContext : BlockContext
	{
		private class BlockLocals
		{
			public int StartIndex;

			public int Length;
		}

		private Executable exe;

		private CompiledFunction fexe;

		private List<Block> blocks;

		private Dictionary<Block, BlockLocals> blockLocals;

		private List<CompiledVariable> allLocals;

		public IEnumerable<CompiledVariable> LocalVariables => null;

		public FunctionContext(Executable exe, CompiledFunction fexe, EmitContext parentContext)
			: base(null, null)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override CType ResolveTypeName(string typeName)
		{
			return null;
		}

		public override ResolvedVariable TryResolveVariable(string name, CType[]? argTypes)
		{
			return null;
		}

		public override void BeginBlock(Block b)
		{
		}

		public override void EndBlock()
		{
		}

		public override CLangLabel DefineLabel()
		{
			return null;
		}

		public override void EmitLabel(CLangLabel l)
		{
		}

		public override void Emit(Instruction instruction)
		{
		}

		public override Value GetConstantMemory(string stringConstant)
		{
			return default(Value);
		}
	}
}
