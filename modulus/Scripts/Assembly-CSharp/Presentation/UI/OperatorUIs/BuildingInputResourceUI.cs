using UnityEngine;

namespace Presentation.UI.OperatorUIs
{
	public class BuildingInputResourceUI : InputResourceUI
	{
		[SerializeField]
		private Transform _craneIconParent;

		public void SetAmount(int amount, int totalAmount, int smallestAmountOfResources, int smallestMultiplier)
		{
			int cranes = totalAmount * smallestMultiplier / smallestAmountOfResources;
			EnableCraneIcons(cranes);
			SetAmount(amount, $"/{totalAmount}");
		}

		private void EnableCraneIcons(int cranes)
		{
			for (int i = 0; i < _craneIconParent.childCount; i++)
			{
				_craneIconParent.GetChild(i).gameObject.SetActive(i < cranes);
			}
		}
	}
}
