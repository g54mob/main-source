using MoonSharp.Interpreter.Debugging;
using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;
using MoonSharp.Interpreter.Tree.Expressions;

namespace MoonSharp.Interpreter.Tree.Fast_Interface
{
	internal static class Loader_Fast
	{
		internal static DynamicExprExpression LoadDynamicExpr(Script script, SourceCode source)
		{
			return null;
		}

		private static ScriptLoadingContext CreateLoadingContext(Script script, SourceCode source)
		{
			return null;
		}

		internal static int LoadChunk(Script script, SourceCode source, ByteCode bytecode)
		{
			return 0;
		}

		internal static int LoadFunction(Script script, SourceCode source, ByteCode bytecode, bool usesGlobalEnv)
		{
			return 0;
		}
	}
}
