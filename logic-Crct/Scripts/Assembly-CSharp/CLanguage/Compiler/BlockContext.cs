using CLanguage.Interpreter;
using CLanguage.Syntax;
using CLanguage.Types;

namespace CLanguage.Compiler
{
	public class BlockContext : EmitContext
	{
		public Block Block { get; }

		public BlockContext(Block block, EmitContext parentContext)
			: base(null)
		{
		}

		public BlockContext(Block block, MachineInfo machineInfo, Report report, CompiledFunction fdecl, EmitContext parentContext)
			: base(null)
		{
		}

		public override ResolvedVariable TryResolveVariable(string name, CType[]? argTypes)
		{
			return null;
		}
	}
}
