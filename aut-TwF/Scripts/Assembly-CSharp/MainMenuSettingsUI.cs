using UnityEngine;

public class MainMenuSettingsUI : HUDMenu
{
	private LTMainMenuHUD ltMainMenuHud;

	[Header("Common")]
	[SerializeField]
	private Transform settingsPanelContainer;

	[SerializeField]
	private GameObject defaultMenuObject;

	private GameObject currentMenuObject;

	protected override void Start()
	{
		base.Start();
		ltMainMenuHud = base.Hud as LTMainMenuHUD;
		foreach (Transform item in settingsPanelContainer)
		{
			item.gameObject.SetActive(value: false);
		}
		ChangeCurrentMenu(defaultMenuObject);
	}

	private void OnEnable()
	{
		base.Hud.BlurBackground(enable: true);
	}

	public override bool BackButtonPressed()
	{
		if (base.BackButtonPressed())
		{
			OnBackButtonPressed();
			return true;
		}
		return false;
	}

	private void ChangeCurrentMenu(GameObject newMenu)
	{
		if ((bool)currentMenuObject)
		{
			currentMenuObject.SetActive(value: false);
		}
		currentMenuObject = newMenu;
		currentMenuObject.SetActive(value: true);
		if (currentMenuObject.TryGetComponent<AutoTransformRebuild>(out var component))
		{
			component.RebuildTransform();
		}
	}

	public void OnChangeMenuPressed(GameObject menuObject)
	{
		ChangeCurrentMenu(menuObject);
	}

	public void OnBackButtonPressed()
	{
		ltMainMenuHud.ShowMainMenuUI();
	}
}
