using DG.Tweening;
using UnityEngine;

public class InGameSettingsUI : HUDMenu
{
	[Header("Common")]
	[SerializeField]
	private Transform settingsPanelContainer;

	[SerializeField]
	private GameObject defaultMenuObject;

	[Header("Selected button indicator")]
	[SerializeField]
	private GameObject selectedButtonIndicator;

	[SerializeField]
	private Transform[] selectedButtonIndicatorPositions;

	private GameObject currentMenuObject;

	protected override void Start()
	{
		base.Start();
		foreach (Transform item in settingsPanelContainer)
		{
			item.gameObject.SetActive(value: false);
		}
		ChangeCurrentMenu(defaultMenuObject);
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

	public void SetSelectedButtonIndicatorPosition(int positionIdx)
	{
		if (selectedButtonIndicatorPositions != null && positionIdx < selectedButtonIndicatorPositions.Length && positionIdx >= 0)
		{
			selectedButtonIndicator.transform.DOMoveX(selectedButtonIndicatorPositions[positionIdx].transform.position.x, 0.2f).SetEase(Ease.OutExpo).SetUpdate(isIndependentUpdate: true);
		}
	}

	public void OnChangeMenuPressed(GameObject menuObject)
	{
		ChangeCurrentMenu(menuObject);
	}

	public void OnBackButtonPressed()
	{
		(base.Hud as LTHUD).ShowPauseUI();
	}
}
