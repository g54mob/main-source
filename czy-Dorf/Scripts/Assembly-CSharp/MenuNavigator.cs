using System.Collections.Generic;
using Dorfromantik.UI;
using Dorfromantik.UI.MainMenu;
using UnityEngine;

public class MenuNavigator : MonoBehaviour
{
	private Camera mainCamera;

	[SerializeField]
	private UiScreenType startupUiScreen;

	[SerializeField]
	private GameObject blockingImage;

	[SerializeField]
	private InputRouter inputRouter;

	private List<HideableUi> confirmationScreens;

	private Dictionary<UiScreenType, HideableUi> uiScreenByType;

	private Dictionary<UiScreenType, bool> uiScreenHidesOthers;

	private UiScreenType activeMenu;

	private void Awake()
	{
		mainCamera = Camera.main;
		uiScreenHidesOthers = new Dictionary<UiScreenType, bool> { 
		{
			UiScreenType.None,
			true
		} };
		uiScreenByType = new Dictionary<UiScreenType, HideableUi>();
		HideableUi[] componentsInChildren = GetComponentsInChildren<HideableUi>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			_ = componentsInChildren[i];
		}
		confirmationScreens = new List<HideableUi>();
		ConfirmationScreen[] componentsInChildren2 = GetComponentsInChildren<ConfirmationScreen>(includeInactive: true);
		foreach (ConfirmationScreen confirmationScreen in componentsInChildren2)
		{
			confirmationScreens.Add(confirmationScreen.GetComponent<HideableUi>());
		}
		inputRouter.OnToggleMenu += ToggleMenu;
	}

	private void Start()
	{
		ChangeMenuScreen(startupUiScreen);
	}

	public void ChangeMenuScreen(int targetScreen)
	{
		ChangeMenuScreen((UiScreenType)targetScreen);
	}

	public void ChangeMenuScreen(UiScreenType targetScreen)
	{
		if (uiScreenHidesOthers[targetScreen])
		{
			foreach (KeyValuePair<UiScreenType, HideableUi> item in uiScreenByType)
			{
				if (uiScreenHidesOthers[item.Key] && item.Key != targetScreen)
				{
					item.Value.Show(shouldShow: false);
				}
			}
			activeMenu = targetScreen;
			inputRouter.SetInputState((targetScreen != UiScreenType.None) ? GameState.Menu : GameState.Playing);
		}
		if (targetScreen != UiScreenType.None)
		{
			uiScreenByType[targetScreen].Show(shouldShow: true);
		}
	}

	public void ToggleMenu()
	{
		if (activeMenu == UiScreenType.None)
		{
			ChangeMenuScreen(UiScreenType.MainMenu);
		}
		else
		{
			ChangeMenuScreen(UiScreenType.None);
		}
	}

	private void OnDestroy()
	{
		inputRouter.OnToggleMenu -= ToggleMenu;
	}
}
