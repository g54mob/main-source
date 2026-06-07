using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.Variables;
using UnityEngine;

namespace Data.FactoryFloor.Freighter.Actions
{
	[CreateAssetMenu(fileName = "FreighterSlotLoadAction", menuName = "Factory/FactoryBehaviour/Freighter/SlotAction/Load")]
	public class FreighterSlotActionLoad : FreighterSlotAction
	{
		[SerializeField]
		private IntVariableSO _maxFreighterSlotAmount;

		public override void Apply(FreightHubBehaviour freightHub, int slotIndex, ref FreightHubBehaviour.FreightHubSlot freighterSlot)
		{
			if (freightHub.GetInSlot(slotIndex).HasResource && (!freighterSlot.HasResource || freightHub.IsSameResourceAsInSlot(freighterSlot.Resource, slotIndex)))
			{
				bool hasResource = freighterSlot.HasResource;
				FreightHubBehaviour.FreightHubSlot inSlot = freightHub.GetInSlot(slotIndex);
				int num = inSlot.Amount + freighterSlot.Amount;
				int amount = ((num >= _maxFreighterSlotAmount.Value) ? (num - _maxFreighterSlotAmount.Value) : 0);
				num = ((num < _maxFreighterSlotAmount.Value) ? num : _maxFreighterSlotAmount.Value);
				if (num > 0 && (freighterSlot.Amount != num || freighterSlot.Resource != inSlot.Resource))
				{
					freighterSlot.Amount = num;
					freighterSlot.Resource = inSlot.Resource;
					inSlot.Amount = amount;
					freightHub.SetInSlot(slotIndex, inSlot);
					freightHub.LoadCrateIntoFreighter(slotIndex, freighterSlot, hasResource);
				}
			}
		}
	}
}
