using Unity.Entities;

namespace Pug.Automation
{
	public struct BigEntityCraftingDataChangedTriggerCD : IComponentData, IQueryTypeParameter
	{
		public byte triggerValue;
	}
}
