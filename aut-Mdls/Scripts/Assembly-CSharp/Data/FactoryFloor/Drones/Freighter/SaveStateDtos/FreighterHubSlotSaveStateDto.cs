using System;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Resources;

namespace Data.FactoryFloor.Drones.Freighter.SaveStateDtos
{
	[Serializable]
	public class FreighterHubSlotSaveStateDto
	{
		public ResourceDto ResourceDto;

		public int Amount;

		public static FreighterHubSlotSaveStateDto FromFreighterHubSlot(FreightHubBehaviour.FreightHubSlot freightHubSlot)
		{
			return new FreighterHubSlotSaveStateDto
			{
				ResourceDto = new ResourceDto(freightHubSlot.Resource),
				Amount = freightHubSlot.Amount
			};
		}

		public static FreighterHubSlotSaveStateDto[] FromFreighterHubSlots(FreightHubBehaviour.FreightHubSlot[] freightHubSlots)
		{
			FreighterHubSlotSaveStateDto[] array = new FreighterHubSlotSaveStateDto[freightHubSlots.Length];
			for (int i = 0; i < freightHubSlots.Length; i++)
			{
				array[i] = FromFreighterHubSlot(freightHubSlots[i]);
			}
			return array;
		}
	}
}
