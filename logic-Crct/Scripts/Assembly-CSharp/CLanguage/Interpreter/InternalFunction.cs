using CLanguage.Types;

namespace CLanguage.Interpreter
{
	public class InternalFunction : BaseFunction
	{
		public InternalFunctionAction Action { get; set; }

		public InternalFunction(string name, string nameContext, CFunctionType functionType)
		{
		}

		public InternalFunction(MachineInfo machineInfo, string prototype, InternalFunctionAction? action = null)
		{
		}

		public override void Step(CInterpreter state, ExecutionFrame frame)
		{
		}
	}
}
