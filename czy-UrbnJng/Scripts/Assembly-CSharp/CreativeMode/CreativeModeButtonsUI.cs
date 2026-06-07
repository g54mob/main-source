using System.Collections.Generic;
using UnityEngine;

namespace CreativeMode
{
	public class CreativeModeButtonsUI : MonoBehaviour
	{
		[SerializeField]
		private List<ItemCategoryButtonUI> categoryButtons;

		public void HideAllButtons()
		{
			foreach (ItemCategoryButtonUI categoryButton in categoryButtons)
			{
				categoryButton.HideButtons();
			}
		}
	}
}
