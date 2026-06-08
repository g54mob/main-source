using System.Collections.Generic;
using Dorfromantik.UI.Components;
using UnityEngine;

namespace Dorfromantik
{
	public class IconButtonMenuScreenListener : MonoBehaviour
	{
		[SerializeField]
		private MainMenuUi mainMenuUi;

		[SerializeField]
		private List<MainMenuScreenType> screenTypes;

		private UiIconButton iconButton;

		private void Awake()
		{
			iconButton = GetComponent<UiIconButton>();
			mainMenuUi.OnSwitchActiveScreen += UpdateActiveState;
		}

		private void UpdateActiveState(MainMenuScreen newActiveScreen)
		{
			bool shouldSetActivated = (bool)newActiveScreen && screenTypes.Contains(newActiveScreen.screenType);
			iconButton.SetVisualStateActivated(shouldSetActivated);
		}

		private void OnDestroy()
		{
			if ((bool)mainMenuUi)
			{
				mainMenuUi.OnSwitchActiveScreen -= UpdateActiveState;
			}
		}
	}
}
