using MoonSharp.Interpreter.Execution;

namespace MoonSharp.Interpreter.Tree
{
	internal abstract class Statement : NodeBase
	{
		public Statement(ScriptLoadingContext lcontext)
			: base(null)
		{
		}

		protected static Statement CreateStatement(ScriptLoadingContext lcontext, out bool forceLast)
		{
			forceLast = default(bool);
			return null;
		}

		private static Statement DispatchForLoopStatement(ScriptLoadingContext lcontext)
		{
			return null;
		}
	}
}
