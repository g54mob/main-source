using Data.FactoryFloor.FactoryObjectBehaviours;
using UnityEngine;

namespace Data.FactoryFloor.Freighter.Actions
{
	[CreateAssetMenu(fileName = "FreighterSlotUnloadAction", menuName = "Factory/FactoryBehaviour/Freighter/SlotAction/Unload")]
	public class FreighterSlotActionUnload : FreighterSlotAction
	{
		public override void Apply(FreightHubBehaviour freightHub, int slotIndex, ref FreightHubBehaviour.FreightHubSlot freighterSlot)
		{
			if (!freighterSlot.HasResource)
			{
				return;
			}
			FreightHubBehaviour.FreightHubSlot outSlot = freightHub.GetOutSlot(slotIndex);
			if (!outSlot.HasResource)
			{
				freightHub.SetOutSlot(slotIndex, freighterSlot);
				freighterSlot = default(FreightHubBehaviour.FreightHubSlot);
				freightHub.UnloadCrateFromFreighter(slotIndex, outSlot, hasLeftOvers: false);
			}
			else if (freightHub.IsSameResourceAsOutSlot(freighterSlot.Resource, slotIndex))
			{
				outSlot.Amount += freighterSlot.Amount;
				bool flag = outSlot.Amount > freightHub.MaxInStorage;
				if (flag)
				{
					freighterSlot.Amount = outSlot.Amount - freightHub.MaxInStorage;
				}
				else
				{
					freighterSlot = default(FreightHubBehaviour.FreightHubSlot);
				}
				freightHub.SetOutSlot(slotIndex, outSlot);
				freightHub.UnloadCrateFromFreighter(slotIndex, freighterSlot, flag);
			}
		}
	}
}
