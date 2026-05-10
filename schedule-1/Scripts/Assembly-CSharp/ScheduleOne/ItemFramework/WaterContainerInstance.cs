using System;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Storage;

namespace ScheduleOne.ItemFramework
{
	[Serializable]
	public class WaterContainerInstance : StorableItemInstance
	{
		public float CurrentFillAmount { get; private set; }

		public float NormalizedFillAmount => 0f;

		public WaterContainerDefinition WaterContainerDefinition => null;

		public WaterContainerInstance()
		{
		}

		public WaterContainerInstance(ItemDefinition definition, int quantity, float fillAmount)
		{
		}

		public override ItemInstance GetCopy(int overrideQuantity = -1)
		{
			return null;
		}

		public void ChangeFillAmount(float change)
		{
		}

		public void ChangeFillAmountByPercentage(float percentage)
		{
		}

		public void SetFillAmount(float amount)
		{
		}

		public override ItemData GetItemData()
		{
			return null;
		}
	}
}
