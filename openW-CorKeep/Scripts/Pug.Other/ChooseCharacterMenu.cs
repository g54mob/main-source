using System;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacterMenu : RadicalMenu, IScrollable
{
	public SaveSlot saveSlotPrefab;

	public Transform saveSlotsContainer;

	public UIScrollWindow scrollWindow;

	[NonSerialized]
	public bool isCreativeMenu;

	private float windowHeight;

	private int VisibleSlots
	{
		get
		{
			if (!isCreativeMenu)
			{
				return 30;
			}
			return 30;
		}
	}

	public override void Activate()
	{
		base.gameObject.SetActive(value: true);
		SetupSaveSlots();
		scrollWindow.ResetScroll();
		base.Activate();
	}

	public override void Deactivate(bool pop)
	{
		bool isStartingGame = Manager.menu.isStartingGame;
		if (pop)
		{
			if (!Manager.networking.connectionFailed && (!isStartingGame || !Manager.networking.isConnected))
			{
				Manager.ecs.UnloadWorlds();
			}
			Manager.menu.isStartingGame = false;
		}
		base.Deactivate(pop);
	}

	public override void UpdatePosition()
	{
		float num = menuEntryStartPositionY;
		windowHeight = 0f;
		List<RadicalMenuOption> allCurrentlyActiveMenuOptions = GetAllCurrentlyActiveMenuOptions();
		for (int i = 0; i < allCurrentlyActiveMenuOptions.Count; i++)
		{
			Vector3 localPosition = allCurrentlyActiveMenuOptions[i].transform.localPosition;
			Vector3 localPosition2 = new Vector3(localPosition.x, num, localPosition.z);
			allCurrentlyActiveMenuOptions[i].transform.localPosition = localPosition2;
			if ((i + 1) % 2 == 0 && allCurrentlyActiveMenuOptions[i].gameObject.activeInHierarchy)
			{
				num -= menuEntryVirtualHeight;
				windowHeight += menuEntryVirtualHeight;
			}
		}
	}

	public void SetupSaveSlots()
	{
		SaveSlot[] componentsInChildren = saveSlotsContainer.GetComponentsInChildren<SaveSlot>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (i >= VisibleSlots)
			{
				componentsInChildren[i].gameObject.SetActive(value: false);
			}
		}
		UpdatePosition();
		List<SaveSlot> list = new List<SaveSlot>();
		for (int j = 0; j < VisibleSlots; j++)
		{
			SaveSlot saveSlot = null;
			int num = (isCreativeMenu ? (30 + j) : j);
			if (menuOptions.Count <= j)
			{
				saveSlot = UnityEngine.Object.Instantiate(saveSlotPrefab, saveSlotsContainer);
				saveSlot.transform.localPosition = new Vector3(0f, 0f, 0f);
				menuOptions.Add(saveSlot.saveSlotPlayOption);
				menuOptions.Add(saveSlot.saveSlotDeleteOption);
			}
			else
			{
				saveSlot = ((SaveSlotPlayOption)menuOptions[j * 2]).saveSlot;
			}
			list.Add(saveSlot);
			bool isEmptySlot = !Manager.saves.CharacterExists(num);
			if (j > 0)
			{
				RadicalMenuOption radicalMenuOption = menuOptions[(j - 1) * 2];
				RadicalMenuOption radicalMenuOption2 = menuOptions[(j - 1) * 2 + 1];
				radicalMenuOption.bottomUIElements = new List<UIelement> { saveSlot.saveSlotPlayOption };
				radicalMenuOption2.bottomUIElements = new List<UIelement> { saveSlot.saveSlotDeleteOption, saveSlot.saveSlotPlayOption };
				saveSlot.saveSlotPlayOption.topUIElements = new List<UIelement> { radicalMenuOption };
				saveSlot.saveSlotDeleteOption.topUIElements = new List<UIelement> { radicalMenuOption2, radicalMenuOption };
			}
			saveSlot.saveSlotPlayOption.Init(this, num, isEmptySlot);
			saveSlot.saveSlotPlayOption.SetParentMenu(this);
			saveSlot.saveSlotPlayOption.SetAsInactive();
			saveSlot.saveSlotPlayOption.UpdateSlot();
			saveSlot.saveSlotPlayOption.ResetSelectedOption();
			saveSlot.saveSlotDeleteOption.Init(this);
			saveSlot.saveSlotDeleteOption.SetParentMenu(this);
		}
		foreach (SaveSlot item in list)
		{
			item.saveSlotPlayOption.player.CompleteCustomizationAssetLoading();
		}
		GetSelectedMenuOption()?.OnSelected();
	}

	public void UpdateContainingElements(float scroll)
	{
	}

	public bool IsBottomElementSelected()
	{
		UIelement uIelement = null;
		foreach (RadicalMenuOption menuOption in menuOptions)
		{
			if (menuOption.gameObject.activeInHierarchy)
			{
				uIelement = menuOption;
			}
		}
		if (uIelement != null)
		{
			return uIelement == Manager.ui.currentSelectedUIElement;
		}
		return false;
	}

	public bool IsTopElementSelected()
	{
		foreach (RadicalMenuOption menuOption in menuOptions)
		{
			if (menuOption.gameObject.activeInHierarchy)
			{
				return menuOption == Manager.ui.currentSelectedUIElement;
			}
		}
		return false;
	}

	public float GetCurrentWindowHeight()
	{
		return windowHeight;
	}

	public UIScrollWindow GetScrollWindow()
	{
		return scrollWindow;
	}
}
