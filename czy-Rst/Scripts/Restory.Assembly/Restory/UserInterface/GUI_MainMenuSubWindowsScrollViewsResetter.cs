using System;
using Restory.UserInterface.CommonElements;
using Restory.Utils;
using UnityEngine;

namespace Restory.UserInterface
{
	public class GUI_MainMenuSubWindowsScrollViewsResetter : MonoBehaviour
	{
		[SerializeField]
		private GUI_MainMenu mainMenu;

		[SerializeField]
		private GUI_ScrollBarVisibilitySetter[] scrollBarVisibilitySetters = Array.Empty<GUI_ScrollBarVisibilitySetter>();

		private void OnEnable()
		{
			mainMenu.OnShown.AddListener(ResolveMainMenuWasShown);
		}

		private void OnDisable()
		{
			if (mainMenu.MonoShellExists())
			{
				mainMenu.OnShown.RemoveListener(ResolveMainMenuWasShown);
			}
		}

		private void ResolveMainMenuWasShown()
		{
			GUI_ScrollBarVisibilitySetter[] array = scrollBarVisibilitySetters;
			foreach (GUI_ScrollBarVisibilitySetter gUI_ScrollBarVisibilitySetter in array)
			{
				if ((bool)gUI_ScrollBarVisibilitySetter)
				{
					gUI_ScrollBarVisibilitySetter.ResetPosition();
				}
			}
		}
	}
}
