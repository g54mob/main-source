using System;

namespace Services.Save.SceneItems
{
	[Serializable]
	public struct ConsumableData
	{
		public float CurrentProgress;

		public int CurrentQuantity;

		public string ConsumableType;
	}
}
