using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik
{
	[RequireComponent(typeof(Selectable))]
	public class DynamicUiNavigationSwitcher : MonoBehaviour
	{
		private sealed class _003C_003Ec__DisplayClass8_0
		{
			public MainMenuScreenType newActiveScreenType;

			public Func<DynamicUiNavigationTarget, bool> _003C_003E9__1;

			internal bool _003CActiveScreenSwitched_003Eb__0(DynamicUiNavigationTarget x)
			{
				return x.mainMenuScreenType == newActiveScreenType;
			}

			internal bool _003CActiveScreenSwitched_003Eb__1(DynamicUiNavigationTarget x)
			{
				return x.mainMenuScreenType == newActiveScreenType;
			}
		}

		[SerializeField]
		private UiDirection defaultSelectableDirection;

		[SerializeField]
		private int targetScreenMinLayer = 1;

		[SerializeField]
		private List<DynamicUiNavigationTarget> customNavigationTargets;

		[SerializeField]
		private List<RuntimePlatform> onlyExecuteOnPlatforms;

		private Selectable selectable;

		private bool listeningToMainMenuUi;

		private void OnEnable()
		{
			if (onlyExecuteOnPlatforms.Count <= 0 || onlyExecuteOnPlatforms.Contains(Application.platform))
			{
				if (!selectable)
				{
					selectable = GetComponent<Selectable>();
				}
				if ((bool)Singleton<MainMenuUi>.Instance && !listeningToMainMenuUi)
				{
					Singleton<MainMenuUi>.Instance.OnSwitchActiveScreen += ActiveScreenSwitched;
					listeningToMainMenuUi = true;
				}
			}
		}

		private void Start()
		{
			if ((onlyExecuteOnPlatforms.Count <= 0 || onlyExecuteOnPlatforms.Contains(Application.platform)) && !listeningToMainMenuUi)
			{
				Singleton<MainMenuUi>.Instance.OnSwitchActiveScreen += ActiveScreenSwitched;
				listeningToMainMenuUi = true;
			}
		}

		private void ActiveScreenSwitched(MainMenuScreen newActiveScreen)
		{
			_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass8_0();
			Navigation navigation = selectable.navigation;
			CS_0024_003C_003E8__locals3.newActiveScreenType = (newActiveScreen ? newActiveScreen.screenType : MainMenuScreenType.None);
			if (Enumerable.Count(customNavigationTargets, (DynamicUiNavigationTarget x) => x.mainMenuScreenType == CS_0024_003C_003E8__locals3.newActiveScreenType) > 0)
			{
				foreach (DynamicUiNavigationTarget item in Enumerable.Where(customNavigationTargets, (DynamicUiNavigationTarget x) => x.mainMenuScreenType == CS_0024_003C_003E8__locals3.newActiveScreenType))
				{
					navigation = SetSelectableNavigationTarget(navigation, item.direction, item.targetSelectable);
				}
			}
			if (defaultSelectableDirection != UiDirection.None && (bool)newActiveScreen && newActiveScreen.layer >= targetScreenMinLayer)
			{
				navigation = SetSelectableNavigationTarget(navigation, defaultSelectableDirection, newActiveScreen.defaultSelectable);
			}
			selectable.navigation = navigation;
		}

		private Navigation SetSelectableNavigationTarget(Navigation selectableNavigation, UiDirection direction, Selectable targetSelectable)
		{
			switch (direction)
			{
			case UiDirection.Left:
				selectableNavigation.selectOnLeft = targetSelectable;
				break;
			case UiDirection.Right:
				selectableNavigation.selectOnRight = targetSelectable;
				break;
			case UiDirection.Up:
				selectableNavigation.selectOnUp = targetSelectable;
				break;
			case UiDirection.Down:
				selectableNavigation.selectOnDown = targetSelectable;
				break;
			}
			return selectableNavigation;
		}

		private void OnDisable()
		{
			if (onlyExecuteOnPlatforms.Count <= 0 || onlyExecuteOnPlatforms.Contains(Application.platform))
			{
				Singleton<MainMenuUi>.Instance.OnSwitchActiveScreen -= ActiveScreenSwitched;
				listeningToMainMenuUi = false;
			}
		}
	}
}
