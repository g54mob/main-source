using System;
using System.Collections.Generic;
using I2.Loc;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class WorldSlotPlayOption : RadicalMainMenuOption
{
	[Serializable]
	public class CrystalSprite
	{
		public ObjectID crystalId;

		public SpriteRenderer sr;
	}

	public WorldSlot worldSlot;

	public WorldInfoTable worldInfoTable;

	public SpriteRenderer selectMarker;

	public SpriteRenderer icon;

	public PugText text;

	public PugText number;

	public Color selectedColor;

	public Color deleteColor;

	public Color deleteColorNumber;

	public PugText creationDate;

	private Transform parentTransform;

	public GameObject container;

	public Animator animator;

	private bool isEmptySlot;

	private bool isConnecting;

	public int saveFileId;

	[FormerlySerializedAs("selectWorldRadicalMenu")]
	public SelectWorldMenu selectWorldMenu;

	public PugText worldName;

	public PugText worldMode;

	public GameObject crystalsContainer;

	[ArrayElementTitle("crystalId")]
	public List<CrystalSprite> crystals;

	public bool isStarting;

	private bool _pushMenuOnNextUpdate;

	private RadicalMenu.MenuType _menuToPush;

	private const string classicWorldBlocked = "classicWorldBlocked";

	private const string WORLD_SLOT = "Menu/WorldSlot";

	private const string mode = "Mode";

	public override bool CanBeActivated()
	{
		return true;
	}

	protected override void Awake()
	{
		parentTransform = base.transform.parent.transform;
		worldSlot.moreOption.SetEnabled(_enabled: false);
		worldSlot.deleteOption.SetEnabled(_enabled: false);
		animator.updateMode = AnimatorUpdateMode.UnscaledTime;
		base.Awake();
	}

	public void Init(SelectWorldMenu _selectWorldMenu, int _saveFileId, bool _isEmptySlot)
	{
		selectWorldMenu = _selectWorldMenu;
		isEmptySlot = _isEmptySlot;
		saveFileId = _saveFileId;
	}

	protected override void InitClickCollider()
	{
	}

	protected override void UpdateClickCollider()
	{
	}

	public void ResetSelectedOption()
	{
		selectWorldMenu.selectedOptionIndex = 0;
		SetAsInactive();
	}

	public override void OnActivated()
	{
		base.OnActivated();
		if (Manager.filesystemManager.BackingStorageIsFull())
		{
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Error/BackingStorageFull", null, menuInputCooldown: true, 0f, 5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, null, new List<string>(), 10f, 0f, 0, 20f);
			return;
		}
		ActivateSlot();
		isStarting = false;
	}

	public void DeleteSaveSlot()
	{
		AudioManager.SfxUI(SfxID.wall, 1f, reuse: false);
		Manager.saves.RemoveWorld(saveFileId);
		selectWorldMenu.DeselectAnyCurrentOption();
		selectWorldMenu.SelectOptionIndex(selectWorldMenu.GetIndexForOption(this));
		selectWorldMenu.UpdateSlots();
	}

	public void ActivateSlot()
	{
		Manager.saves.SetWorldId(saveFileId);
		if (isEmptySlot)
		{
			Manager.menu.PushMenu(RadicalMenu.MenuType.CREATE_WORLD);
			return;
		}
		if (Manager.platform.platformImpl is SteamPlatform steamPlatform && steamPlatform.IsSubscribedFromFreeWeekend())
		{
			Manager.menu.centerPopUpText.StartNewDisplaySequence("classicWorldBlocked", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate
			{
			}, new List<string> { "ok" }, 10f, 0.8f, 0, 20f);
			return;
		}
		RadicalMenu.MenuType chooseCharacterMenu = (Manager.saves.IsWorldModeEnabled(WorldMode.Creative) ? RadicalMenu.MenuType.CREATIVE_CHARACTER_CHOOSER : RadicalMenu.MenuType.CHARACTER_CHOOSER);
		if (Manager.saves.GetWorldGenerationType() == WorldGenerationType.FullRelease && !Manager.saves.GetWorldInfo().HasViewedAllContentBundles())
		{
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Menu/ConfirmStartWithoutNewContent", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate(PopupResponse response)
			{
				Manager.saves.GetWorldInfo().MarkAllContentBundlesAsViewed();
				if (response.IsConfirm)
				{
					_pushMenuOnNextUpdate = true;
					_menuToPush = chooseCharacterMenu;
				}
			}, new List<string> { "cancelDialogue", "Menu/ContinueAnyway" }, 10f, 0.8f, 0, 16f, secondOptionPopsAllMenus: false, pauseGame: true, holdToConfirm: false, localizePlaceholders: true, 0f);
		}
		else
		{
			Manager.menu.PushMenu(chooseCharacterMenu);
		}
	}

	public void UpdateSlot()
	{
		container.SetActive(!isEmptySlot);
		if (isEmptySlot)
		{
			worldSlot.moreOption.SetEnabled(_enabled: false);
			worldSlot.deleteOption.SetEnabled(_enabled: false);
			text.localize = true;
			text.Render("Menu/WorldSlot");
			crystalsContainer.gameObject.SetActive(value: false);
			return;
		}
		worldSlot.moreOption.SetEnabled(_enabled: true);
		worldSlot.deleteOption.SetEnabled(_enabled: true);
		text.localize = false;
		text.Render(" ");
		worldName.localize = false;
		WorldInfo worldInfo = Manager.saves.GetWorldInfo(saveFileId);
		worldName.Render(worldInfo.name);
		if (worldInfo.worldGenerationType == WorldGenerationType.Classic)
		{
			worldMode.formatFields = new string[1] { worldInfo.mode.ToString() + "Mode" };
			worldMode.Render("Menu/ClassicWorldFormat", rewindEffectAnims: true);
		}
		else
		{
			worldMode.Render(worldInfo.mode.ToString() + "Mode", rewindEffectAnims: true);
		}
		worldMode.SetTempColor(Manager.text.GetModeColor(Mathf.Max(0, (int)worldInfo.mode)));
		icon.sprite = worldInfoTable.worldIcons[math.clamp(worldInfo.iconIndex, 0, worldInfoTable.worldIcons.Count - 1)];
		string[] array = LocalizationManager.GetTranslation("months").Split(' ');
		CreationDate worldCreationDate = Manager.saves.GetWorldCreationDate(saveFileId);
		if (worldCreationDate == null || worldCreationDate.year == 0)
		{
			Manager.saves.SetWorldCreationDate(DateTime.Now, saveFileId);
			Manager.saves.WriteWorldInfo(saveFileId);
			worldCreationDate = Manager.saves.GetWorldCreationDate(saveFileId);
		}
		creationDate.formatFields = new string[3]
		{
			worldCreationDate.year.ToString(),
			worldCreationDate.day.ToString(),
			array[Mathf.Clamp(worldCreationDate.month, 0, 11)]
		};
		creationDate.Render("dateFormat");
		crystalsContainer.gameObject.SetActive(value: true);
		for (int i = 0; i < crystals.Count; i++)
		{
			crystals[i].sr.gameObject.SetActive(Manager.saves.HasActivatedCrystal(crystals[i].crystalId, saveFileId));
		}
	}

	public override void OnParentMenuActivation()
	{
		isConnecting = false;
		base.OnParentMenuActivation();
	}

	public override bool OnSkimLeft()
	{
		return false;
	}

	public override bool OnSkimRight()
	{
		return false;
	}

	public override void OnSelected()
	{
		if (isEmptySlot)
		{
			selectWorldMenu.selectedOptionIndex = 0;
		}
		animator.SetTrigger(1260321794);
		DelayedSetColor();
		Invoke("DelayedSetColor", 0.001f);
		selectMarker.gameObject.SetActive(value: true);
		selectWorldMenu.GetScrollWindow().MoveScrollToIncludePosition(parentTransform.localPosition.y, 1f);
		base.OnSelected();
	}

	private void DelayedSetColor()
	{
		if (selectWorldMenu.isDeleteMenu)
		{
			number.color = deleteColorNumber;
			selectMarker.color = deleteColor;
		}
		else
		{
			number.color = selectedColor;
			selectMarker.color = selectedColor;
		}
	}

	public override void OnDeselected(bool playEffect = true)
	{
		animator.SetTrigger(-1949102368);
		number.color = Color.white;
		SetAsInactive();
		base.OnDeselected(playEffect);
	}

	public void SetAsInactive()
	{
		selectMarker.gameObject.SetActive(value: false);
	}

	protected override void Update()
	{
		if (_pushMenuOnNextUpdate)
		{
			Manager.menu.PushMenu(_menuToPush);
			_pushMenuOnNextUpdate = false;
		}
		if (isEmptySlot && !worldSlot.moreOption.enabled && !worldSlot.deleteOption.enabled && worldSlot.moreOption.IsSelected() && !IsSelected())
		{
			Select();
		}
		base.Update();
	}
}
