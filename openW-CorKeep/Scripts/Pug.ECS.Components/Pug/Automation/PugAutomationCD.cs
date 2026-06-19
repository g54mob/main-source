using Unity.Entities;

namespace Pug.Automation
{
	public struct PugAutomationCD : IComponentData, IQueryTypeParameter
	{
		public AutomationType type;

		public bool isActive;
	}
}
