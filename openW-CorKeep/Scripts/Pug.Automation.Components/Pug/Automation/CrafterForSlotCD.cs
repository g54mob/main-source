using Unity.Entities;

namespace Pug.Automation
{
	public struct CrafterForSlotCD : IComponentData, IQueryTypeParameter
	{
		public int slotIndex;
	}
}
