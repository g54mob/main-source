using System.Collections.Generic;
using UnityEngine;

namespace CreativeMode
{
	public class CreativeModePlantButtonsUI : MonoBehaviour
	{
		[SerializeField]
		private List<PlantCategoryItem> categoryButtons;

		public void HideAllButtons()
		{
			foreach (PlantCategoryItem categoryButton in categoryButtons)
			{
				categoryButton.HideButtons();
			}
		}
	}
}
