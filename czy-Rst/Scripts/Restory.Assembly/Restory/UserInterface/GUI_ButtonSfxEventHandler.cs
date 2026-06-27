using Restory.UserInterface.CommonElements;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UserInterface
{
	public class GUI_ButtonSfxEventHandler : GUI_SfxEventHandler
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private GUI_Button guiButton;

		protected override bool IsCorrect()
		{
			if (base.IsCorrect())
			{
				if (!(button != null) || !button.isActiveAndEnabled || !button.IsInteractable())
				{
					if (guiButton != null && guiButton.isActiveAndEnabled)
					{
						return guiButton.Interactable;
					}
					return false;
				}
				return true;
			}
			return false;
		}
	}
}
