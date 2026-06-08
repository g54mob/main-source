using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik
{
	public class NavigationBar : MonoBehaviour
	{
		[SerializeField]
		private List<Selectable> navigationBarRightEdgeObjects;

		private MainMenuUi mainMenuUi;

		private void Start()
		{
			mainMenuUi = Singleton<MainMenuUi>.Instance;
			mainMenuUi.OnSwitchActiveScreen += SwitchScreen;
		}

		private void SwitchScreen(MainMenuScreen activeScreen)
		{
			foreach (Selectable navigationBarRightEdgeObject in navigationBarRightEdgeObjects)
			{
				bool flag = activeScreen == null || activeScreen.screenType == MainMenuScreenType.NavigationBar;
				Navigation navigation = navigationBarRightEdgeObject.navigation;
				navigation.selectOnRight = (flag ? null : activeScreen.defaultSelectable);
				navigationBarRightEdgeObject.navigation = navigation;
			}
		}

		private void OnDestroy()
		{
			mainMenuUi.OnSwitchActiveScreen -= SwitchScreen;
		}
	}
}
