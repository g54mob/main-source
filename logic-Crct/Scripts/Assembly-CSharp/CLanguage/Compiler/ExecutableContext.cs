using CLanguage.Interpreter;
using CLanguage.Types;

namespace CLanguage.Compiler
{
	public class ExecutableContext : EmitContext
	{
		public Executable Executable { get; }

		public ExecutableContext(Executable executable, Report report)
			: base(null)
		{
		}

		public override ResolvedVariable ResolveMethodFunction(CStructType structType, CStructMethod method)
		{
			return null;
		}

		private BaseFunction UnresolvedMethod(string typeName, string methodName)
		{
			return null;
		}

		public override ResolvedVariable TryResolveVariable(string name, CType[]? argTypes)
		{
			return null;
		}
	}
}
