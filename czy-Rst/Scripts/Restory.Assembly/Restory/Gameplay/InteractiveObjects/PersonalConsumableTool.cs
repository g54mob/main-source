using UnityEngine;

namespace Restory.Gameplay.InteractiveObjects
{
	public class PersonalConsumableTool : PersonalTool
	{
		public int Amount { get; private set; } = 1;

		public void SpecifyAmount(int amount)
		{
			if (amount <= 0)
			{
				Debug.LogError("Amount of consumable tools must be greater than 0");
			}
			else
			{
				Amount = amount;
			}
		}
	}
}
