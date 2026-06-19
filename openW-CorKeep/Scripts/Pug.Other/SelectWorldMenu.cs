using System.Collections.Generic;
using PugMod;
using UnityEngine;

public class SelectWorldMenu : RadicalMenu, IScrollable
{
	public GameObject worldSlotPrefab;

	public Transform saveSlotsContainer;

	public int selectedOptionIndex;

	public bool isDeleteMenu;

	public UIScrollWindow scrollWindow;

	protected float windowHeight;

	private List<WorldSlot> worldSlots = new List<WorldSlot>();

	protected virtual int numberOfSaveSlotsToInitializeInAwake => 30;

	protected override void Awake()
	{
		AsyncInstantiateOperation<GameObject> asyncInstantiateOperation = Object.InstantiateAsync(worldSlotPrefab, numberOfSaveSlotsToInitializeInAwake, saveSlotsContainer);
		asyncInstantiateOperation.WaitForCompletion();
		for (int i = 0; i < asyncInstantiateOperation.Result.Length; i++)
		{
			InitializeSlot(asyncInstantiateOperation.Result[i], i);
		}
		base.Awake();
	}

	protected virtual void InitializeSlot(GameObject instantiatedSlot, int index)
	{
		WorldSlot component = instantiatedSlot.GetComponent<WorldSlot>();
		component.transform.localPosition = new Vector3(0f, 0f, 0f);
		component.playOption.selectWorldMenu = this;
		component.moreOption.selectWorldMenu = this;
		component.deleteOption.selectWorldMenu = this;
		component.newWorldOption.selectWorldMenu = this;
		component.newWorldFromModOption.selectWorldMenu = this;
		component.playOption.SetParentMenu(this);
		component.moreOption.SetParentMenu(this);
		component.deleteOption.SetParentMenu(this);
		component.newWorldOption.SetParentMenu(this);
		component.newWorldFromModOption.SetParentMenu(this);
		component.newWorldOption.SetAsInactive();
		component.newWorldFromModOption.SetAsInactive();
		worldSlots.Add(component);
		if (index != 0)
		{
			WorldSlotPlayOption playOption = worldSlots[index - 1].playOption;
			_ = worldSlots[index - 1].moreOption;
			WorldSlotDeleteOption deleteOption = worldSlots[index - 1].deleteOption;
			WorldSlotNewWorldOption newWorldOption = worldSlots[index - 1].newWorldOption;
			WorldSlotNewWorldOption newWorldFromModOption = worldSlots[index - 1].newWorldFromModOption;
			playOption.bottomUIElements = new List<UIelement> { component.playOption };
			deleteOption.bottomUIElements = new List<UIelement> { component.moreOption, component.playOption };
			newWorldOption.bottomUIElements = new List<UIelement> { component.newWorldOption, component.playOption };
			newWorldFromModOption.bottomUIElements = new List<UIelement> { component.newWorldFromModOption, component.playOption };
			component.playOption.topUIElements = new List<UIelement> { playOption };
			component.moreOption.topUIElements = new List<UIelement> { deleteOption, playOption };
			component.newWorldOption.topUIElements = new List<UIelement> { newWorldOption, playOption };
			component.newWorldFromModOption.topUIElements = new List<UIelement> { newWorldFromModOption, playOption };
		}
	}

	public override void Activate()
	{
		base.gameObject.SetActive(value: true);
		SetupSaveSlots();
		scrollWindow.ResetScroll();
		base.Activate();
	}

	public override void UpdatePosition()
	{
		float num = menuEntryStartPositionY;
		windowHeight = 0f;
		foreach (WorldSlot worldSlot in worldSlots)
		{
			Vector3 localPosition = worldSlot.transform.localPosition;
			Vector3 localPosition2 = new Vector3(localPosition.x, num, localPosition.z);
			worldSlot.transform.localPosition = localPosition2;
			num -= menuEntryVirtualHeight;
			windowHeight += menuEntryVirtualHeight;
		}
	}

	public void UpdateSlots()
	{
		SetupSaveSlots();
		UpdatePosition();
	}

	protected virtual void SetupSaveSlots()
	{
		menuOptions.Clear();
		for (int i = 0; i < 30; i++)
		{
			WorldSlot worldSlot = worldSlots[i];
			int num = i;
			bool flag = !Manager.saves.WorldExists(num);
			if (flag && Loader.Instance.HasSavesMod)
			{
				worldSlot.newWorldOption.gameObject.SetActive(value: true);
				worldSlot.newWorldFromModOption.gameObject.SetActive(value: true);
				menuOptions.Add(worldSlot.newWorldOption);
				menuOptions.Add(worldSlot.newWorldFromModOption);
				worldSlot.playOption.gameObject.SetActive(value: false);
				worldSlot.moreOption.gameObject.SetActive(value: false);
				worldSlot.deleteOption.gameObject.SetActive(value: false);
				worldSlot.newWorldOption.Init(num);
				worldSlot.newWorldFromModOption.Init(num);
			}
			else
			{
				worldSlot.playOption.gameObject.SetActive(value: true);
				worldSlot.moreOption.gameObject.SetActive(value: true);
				worldSlot.deleteOption.gameObject.SetActive(value: true);
				menuOptions.Add(worldSlot.playOption);
				menuOptions.Add(worldSlot.moreOption);
				menuOptions.Add(worldSlot.deleteOption);
				worldSlot.newWorldOption.gameObject.SetActive(value: false);
				worldSlot.newWorldFromModOption.gameObject.SetActive(value: false);
				worldSlot.playOption.Init(this, num, flag);
				worldSlot.playOption.SetAsInactive();
				worldSlot.playOption.UpdateSlot();
				worldSlot.playOption.ResetSelectedOption();
				worldSlot.moreOption.Init(this, num);
				worldSlot.deleteOption.Init(this);
				WorldInfo worldInfo = Manager.saves.GetWorldInfo(num);
				bool flag2 = !flag && worldInfo.worldGenerationType == WorldGenerationType.FullRelease && !worldInfo.HasViewedAllContentBundles();
				worldSlot.moreOption.SetNotification(flag2);
				worldSlot.moreOption.SetTooltip(flag2 ? "Menu/NewContentAvailableTooltip" : null);
			}
			worldSlot.number.Render((num + 1).ToString());
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
