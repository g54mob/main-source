using System.Collections.Generic;

namespace Refic.Emberward.Minigame
{
	public abstract class ATowerOverchargeMinigame
	{
		protected eOverchargeType type;

		protected List<OverchargeItemData> list_Data;

		protected readonly int MAX_BUTTON_COUNT;

		public List<OverchargeItemData> Data => null;

		public void Initialize()
		{
		}

		public OverchargeItemData GetItemData(int index)
		{
			return null;
		}

		protected abstract void SetupMinigame();

		public abstract bool ValidateButtonPress(int index);

		public abstract bool IsCompleted();
	}
}
