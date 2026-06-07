using Data.FactoryFloor.FactoryObjectBehaviours;
using UnityEngine;

namespace Data.FactoryFloor.Freighter.Actions
{
	[CreateAssetMenu(fileName = "FreighterSlotUnload&LoadAction", menuName = "Factory/FactoryBehaviour/Freighter/SlotAction/Unload And Load")]
	public class FreighterSlotActionUnloadAndLoad : FreighterSlotAction
	{
		[SerializeField]
		private FreighterSlotActionUnload _freigherSlotUnloadAction;

		[SerializeField]
		private FreighterSlotActionLoad _freigherSlotLoadAction;

		public override void Apply(FreightHubBehaviour freightHub, int slotIndex, ref FreightHubBehaviour.FreightHubSlot freighterSlot)
		{
			_freigherSlotUnloadAction.Apply(freightHub, slotIndex, ref freighterSlot);
			_freigherSlotLoadAction.Apply(freightHub, slotIndex, ref freighterSlot);
		}
	}
}
