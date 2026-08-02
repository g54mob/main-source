using MoonSharp.Interpreter.DataStructs;

namespace MoonSharp.Interpreter.Execution
{
	internal class LoopTracker
	{
		public FastStack<ILoop> Loops;
	}
}
