using System;

namespace Services.Save.Consumables
{
	[Serializable]
	public struct SpawnedConsumableData
	{
		public float CurrentProgress;

		public int CurrentQuantity;

		public string ConsumableType;
	}
}
