using Unity.Entities;

namespace Pug.Automation
{
	public struct LogicCircuitCD : IComponentData, IQueryTypeParameter
	{
		public bool lastShouldSwitch;
	}
}
