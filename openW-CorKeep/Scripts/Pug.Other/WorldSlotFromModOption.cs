using System;
using System.IO;
using Pug.Platform;
using Unity.Mathematics;
using UnityEngine;

public class WorldSlotFromModOption : RadicalMainMenuOption
{
	private const string CLASSIC_WORLD_FORMAT = "Menu/ClassicWorldFormat";

	private const string WORLD_SLOT = "Menu/WorldSlot";

	private const string MODE = "Mode";

	public WorldInfoTable worldInfoTable;

	public SpriteRenderer selectMarker;

	public SpriteRenderer icon;

	public PugText text;

	public Color selectedColor;

	public Animator animator;

	public PugText worldName;

	public PugText worldMode;

	public PugText modName;

	private int saveFileId;

	private SelectWorldFromModMenu selectWorldMenu;

	private SelectWorldFromModMenu.ModSave modSave;

	private WorldInfo worldInfo;

	protected override void Awake()
	{
		animator.updateMode = AnimatorUpdateMode.UnscaledTime;
		base.Awake();
	}

	public void Init(SelectWorldFromModMenu.ModSave modSave, SelectWorldFromModMenu _selectWorldMenu, int _listIndex, int _saveFileId)
	{
		this.modSave = modSave;
		selectWorldMenu = _selectWorldMenu;
		saveFileId = _saveFileId;
		try
		{
			worldInfo = SaveManager.GetWorldInfoFromSerialized(File.ReadAllBytes(modSave.WorldInfoPath));
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Error/FailedToLoad", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, null, null, 10f, 0.8f, 0, 0f, secondOptionPopsAllMenus: false, pauseGame: true, holdToConfirm: false, localizePlaceholders: true, 0f);
			Manager.menu.PopMenu();
		}
		text.localize = false;
		text.Render(" ");
		worldName.localize = false;
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
		modName.Render(modSave.ModName);
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
		try
		{
			modSave.WorldSave = new FilesystemManager.File(modSave.WorldSave.FileID, saveFileId);
			modSave.WorldInfo = new FilesystemManager.File(modSave.WorldInfo.FileID, saveFileId);
			modSave.WorldGenerationParameters = new FilesystemManager.File(modSave.WorldGenerationParameters.FileID, saveFileId);
			modSave.ServerMapParts = new FilesystemManager.File(modSave.ServerMapParts.FileID, saveFileId);
			Debug.Log($"write mod save {worldInfo.name} to slot {saveFileId}");
			modSave.WorldSave.Write(File.ReadAllBytes(modSave.WorldSavePath), addToPool: false, force: false, raw: true);
			modSave.WorldInfo.Write(File.ReadAllBytes(modSave.WorldInfoPath), addToPool: false, force: false, raw: true);
			Manager.saves.ReloadWorldInfo(saveFileId);
			if (modSave.WorldGenerationParametersPath != null)
			{
				modSave.WorldGenerationParameters.Write(File.ReadAllBytes(modSave.WorldGenerationParametersPath), addToPool: false, force: false, raw: true);
			}
			if (modSave.ServerMapPartsPath != null)
			{
				modSave.ServerMapParts.Write(File.ReadAllBytes(modSave.ServerMapPartsPath), addToPool: false, force: false, raw: true);
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Error/FailedToLoad", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, null, null, 10f, 0.8f, 0, 0f, secondOptionPopsAllMenus: false, pauseGame: true, holdToConfirm: false, localizePlaceholders: true, 0f);
			Manager.menu.PopMenu();
			return;
		}
		StartWorld();
	}

	public void StartWorld()
	{
		Manager.saves.SetWorldId(saveFileId);
		if (Manager.saves.IsWorldModeEnabled(WorldMode.Creative))
		{
			Manager.menu.PushMenu(RadicalMenu.MenuType.CREATIVE_CHARACTER_CHOOSER);
		}
		else
		{
			Manager.menu.PushMenu(RadicalMenu.MenuType.CHARACTER_CHOOSER);
		}
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
		animator.SetTrigger(1260321794);
		DelayedSetColor();
		Invoke("DelayedSetColor", 0.001f);
		selectMarker.gameObject.SetActive(value: true);
		selectWorldMenu.GetScrollWindow().MoveScrollToIncludePosition(base.transform.localPosition.y, 1f);
		base.OnSelected();
	}

	private void DelayedSetColor()
	{
		selectMarker.color = selectedColor;
	}

	public override void OnDeselected(bool playEffect = true)
	{
		animator.SetTrigger(-1949102368);
		SetAsInactive();
		base.OnDeselected(playEffect);
	}

	public void SetAsInactive()
	{
		selectMarker.gameObject.SetActive(value: false);
	}
}
