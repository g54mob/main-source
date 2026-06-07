using CLanguage.Interpreter;
using CLanguage.Types;

namespace CLanguage.Compiler
{
	public class LoopContext : EmitContext
	{
		public CLangLabel BreakLabel { get; }

		public CLangLabel ContinueLabel { get; }

		public override LoopContext? Loop => null;

		public LoopContext(CLangLabel breakLabel, CLangLabel continueLabel, EmitContext parentContext)
			: base(null)
		{
		}

		public override ResolvedVariable TryResolveVariable(string name, CType[]? argTypes)
		{
			return null;
		}
	}
}
