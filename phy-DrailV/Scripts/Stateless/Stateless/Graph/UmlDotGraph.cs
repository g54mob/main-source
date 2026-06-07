using Stateless.Reflection;

namespace Stateless.Graph
{
	public static class UmlDotGraph
	{
		public static string Format(StateMachineInfo machineInfo)
		{
			return new StateGraph(machineInfo).ToGraph(new UmlDotGraphStyle());
		}
	}
}
