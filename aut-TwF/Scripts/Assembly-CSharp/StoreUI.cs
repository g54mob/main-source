using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoreUI : HUDMenu
{
	[Header("Selected button indicator")]
	[SerializeField]
	private GameObject selectedButtonIndicator;

	[SerializeField]
	private Transform[] selectedButtonIndicatorPositions;

	[Space]
	[SerializeField]
	private UIList t1ElementListUI;

	[SerializeField]
	private UIList t2ElementListUI;

	[SerializeField]
	private StoreUIInfoPanel storeUIInfoPanel;

	[Space]
	[SerializeField]
	private GameObject pauseFrame;

	private int currentSection;

	private PlayerData.PlayerBuilding selectedElement;

	private LTHUD ltHud;

	public PlayerData.PlayerBuilding SelectedElement
	{
		get
		{
			return selectedElement;
		}
		set
		{
			selectedElement = value;
			if ((bool)selectedElement.BuildingData && selectedElement.IsUnlocked)
			{
				storeUIInfoPanel.LoadInfoPanel(selectedElement.BuildingData);
			}
			else
			{
				storeUIInfoPanel.LoadLockedInfoPanel();
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		LoadMarketElementList();
		ltHud = base.Hud as LTHUD;
	}

	protected override void Start()
	{
		base.Start();
		LTFunctionLibrary.GetTimeManager().onGameSpeedChanged += OnGameSpeedChanged;
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}

	private void OnEnable()
	{
		base.Hud.BlurBackground(enable: true);
		ltHud.LtPlayerController.IsHotbarLocked = true;
		ltHud.LtPlayerController.onHotbarInputButtonPressed += OnHotbarInputButtonPressed;
		OnGameSpeedChanged(LTFunctionLibrary.GetTimeManager().GetGameSpeed(), Time.timeScale);
	}

	private void OnDisable()
	{
		base.Hud.BlurBackground(enable: false);
		ltHud.LtPlayerController.IsHotbarLocked = false;
		ltHud.LtPlayerController.onHotbarInputButtonPressed -= OnHotbarInputButtonPressed;
	}

	public override bool BackButtonPressed()
	{
		if (base.BackButtonPressed())
		{
			switch (ltHud.LtPlayerController.CurrentInputMode.InputModeType)
			{
			case EInputMode.Standard:
				ltHud.ShowStandardModeUI();
				break;
			case EInputMode.EditMode:
				ltHud.ShowEditModeUI();
				break;
			case EInputMode.BuyMode:
				ltHud.ShowEditModeUI();
				break;
			}
			return true;
		}
		return false;
	}

	private void OnGameSpeedChanged(TimeManager.ETimeSpeed timeSpeed, float speed)
	{
		pauseFrame.SetActive(timeSpeed == TimeManager.ETimeSpeed.Pause);
	}

	public void LoadMarketElementList()
	{
		List<object> list = new List<object>();
		List<object> list2 = new List<object>();
		List<PlayerData.PlayerBuilding> list3 = new List<PlayerData.PlayerBuilding>();
		switch (currentSection)
		{
		case 0:
			list3.AddRange(LTFunctionLibrary.GetPlayerData().AvailableBuildings);
			break;
		case 1:
			list3.AddRange(LTFunctionLibrary.GetPlayerData().AvailableTowers);
			break;
		}
		foreach (PlayerData.PlayerBuilding item in list3)
		{
			if ((bool)item.BuildingData && !item.BuildingData.IsUpgrade() && (item.IsUnlocked || !item.HideIfLocked))
			{
				switch (item.Tier)
				{
				case 0:
					list.Add(item);
					break;
				case 1:
					list2.Add(item);
					break;
				}
			}
		}
		LoadUIList(t1ElementListUI, list);
		LoadUIList(t2ElementListUI, list2);
	}

	private void LoadUIList(UIList uiList, List<object> items)
	{
		items.Sort((object x, object y) => (x as PlayerData.PlayerBuilding).IsUnlocked.CompareTo((y as PlayerData.PlayerBuilding).IsUnlocked) * -1);
		uiList.LoadList(items);
		foreach (UIListElement element in uiList.Elements)
		{
			element.onPointerEnter = (Action<UIListElement>)Delegate.Combine(element.onPointerEnter, new Action<UIListElement>(OnElementPointerEnter));
		}
	}

	private void OnElementPointerEnter(UIListElement element)
	{
		SelectedElement = element.Data as PlayerData.PlayerBuilding;
	}

	public void OnChangeSectionButtonPressed(int section)
	{
		if (currentSection != section)
		{
			currentSection = section;
			SetSelectedButtonIndicatorPosition(section);
			LoadMarketElementList();
		}
	}

	private void SetSelectedButtonIndicatorPosition(int positionIdx)
	{
		if (selectedButtonIndicatorPositions != null && positionIdx < selectedButtonIndicatorPositions.Length && positionIdx >= 0)
		{
			selectedButtonIndicator.transform.DOMoveX(selectedButtonIndicatorPositions[positionIdx].transform.position.x, 0.1f).SetEase(Ease.OutExpo).SetUpdate(isIndependentUpdate: true);
		}
	}

	public void OnCloseButtonPressed()
	{
		switch (ltHud.LtPlayerController.CurrentInputMode.InputModeType)
		{
		case EInputMode.Standard:
			ltHud.ShowStandardModeUI();
			break;
		case EInputMode.EditMode:
			ltHud.ShowEditModeUI();
			break;
		case EInputMode.BuyMode:
			ltHud.ShowEditModeUI();
			break;
		}
	}

	private void OnHotbarInputButtonPressed(int hotbarActionIdx)
	{
		StoreElementUI storeElementUI = FunctionLibrary.TryToGetObjectUnderCursor<StoreElementUI>(EventSystem.current, GetComponent<GraphicRaycaster>());
		if (!storeElementUI)
		{
			return;
		}
		PlayerData.PlayerBuilding playerBuilding = storeElementUI.Data as PlayerData.PlayerBuilding;
		if (playerBuilding.IsUnlocked)
		{
			if ((ltHud.LtPlayerController.GetHotbarAction(hotbarActionIdx)?.Id ?? null) == playerBuilding.BuildingData.Id)
			{
				ltHud.LtPlayerController.RemoveHotbarAction(hotbarActionIdx);
			}
			else
			{
				ltHud.LtPlayerController.AddHotbarAction(playerBuilding.BuildingData, hotbarActionIdx);
			}
		}
	}
}
