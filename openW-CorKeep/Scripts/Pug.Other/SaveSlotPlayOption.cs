using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class SaveSlotPlayOption : RadicalMainMenuOption
{
	[Serializable]
	public class SoulSprite
	{
		public SoulID soulId;

		public SpriteRenderer sr;
	}

	public SaveSlot saveSlot;

	public SaveSlotDeleteOption saveSlotDeleteOption;

	public SpriteRenderer selectMarker;

	public PugText text;

	public PugText number;

	public Color selectedColor;

	public Color deleteColor;

	public Color deleteColorNumber;

	public GameObject buttonsContainer;

	public Animator animator;

	private bool isEmptySlot;

	private bool isConnecting;

	public int saveFileId;

	public ChooseCharacterMenu chooseCharacterMenu;

	public PugText characterName;

	public PugText characterType;

	public Color hardcoreColor;

	public Color casualColor;

	public PlayerController player;

	public PlayerHealthBarUI healthBar;

	public GameObject soulsContainer;

	[ArrayElementTitle("soulId")]
	public List<SoulSprite> souls;

	private const string menuPrefix = "Menu/";

	private const string characterSlot = "Menu/CharacterSlot";

	public override bool CanBeActivated()
	{
		return true;
	}

	protected override void Awake()
	{
		saveSlotDeleteOption.SetEnabled(_enabled: false);
		animator.updateMode = AnimatorUpdateMode.UnscaledTime;
		base.Awake();
	}

	private void ConnectFailed()
	{
		Manager.ecs.UnloadWorlds();
		string connectionFailedReason = Manager.networking.connectionFailedReason;
		Manager.menu.centerPopUpText.StartNewDisplaySequence(string.IsNullOrEmpty(connectionFailedReason) ? "connectionFailed" : connectionFailedReason, null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, PopUpCallBack, new List<string> { "cancelDialogue" }, 10f);
		isConnecting = false;
	}

	private void PopUpCallBack(PopupResponse response)
	{
	}

	public void Init(ChooseCharacterMenu _radicalMenu, int _saveFileId, bool _isEmptySlot)
	{
		chooseCharacterMenu = _radicalMenu;
		isEmptySlot = _isEmptySlot;
		saveFileId = _saveFileId;
		int num = saveFileId + 1;
		if (num > 30)
		{
			num -= 30;
		}
		number.Render(num.ToString());
	}

	protected override void InitClickCollider()
	{
	}

	protected override void UpdateClickCollider()
	{
	}

	public void ResetSelectedOption()
	{
		SetAsInactive();
	}

	public override void OnActivated()
	{
		base.OnActivated();
		ActivateSlot();
	}

	public void DeleteSaveSlot()
	{
		AudioManager.SfxUI(SfxID.wall, 1f, reuse: false);
		Manager.saves.RemoveCharacter(saveFileId);
		isEmptySlot = true;
		chooseCharacterMenu.DeselectAnyCurrentOption();
		chooseCharacterMenu.SelectOptionIndex(chooseCharacterMenu.GetIndexForOption(this));
		UpdateSlot();
	}

	public void ActivateSlot()
	{
		if (isEmptySlot)
		{
			GoToCharacterTypeSelection();
		}
		else if (!Manager.saves.IsCompatibleWithCurrentGameVersion(saveFileId))
		{
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Error/CharacterVersionTooHigh", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate
			{
			}, new List<string> { "ok" }, 10f, 0f, 0, 25f);
		}
		else
		{
			StartGame(saveFileId);
		}
	}

	public static void StartGameFromActivity(int worldID, int characterID)
	{
		Manager.saves.SetWorldId(worldID);
		StartGame(characterID);
	}

	public static void StartGame(int characterID)
	{
		Manager.saves.SetCharacterId(characterID);
		Manager.menu.isStartingGame = true;
		if (Manager.saves.IsFirstTimePlayingOnAnyServer() && !Manager.saves.IsCreativeModeWorld())
		{
			Manager.load.LoadIntroScene();
		}
		else
		{
			Manager.load.LoadMainScene();
		}
	}

	private void GoToCharacterTypeSelection()
	{
		Manager.saves.SetCharacterId(saveFileId);
		Manager.menu.PushMenu(RadicalMenu.MenuType.CHARACTER_TYPE_SELECTION);
	}

	public void UpdateSlot()
	{
		buttonsContainer.SetActive(!isEmptySlot);
		if (isEmptySlot)
		{
			saveSlotDeleteOption.SetEnabled(_enabled: false);
			text.localize = true;
			text.Render("Menu/CharacterSlot");
			player.gameObject.SetActive(value: false);
			healthBar.gameObject.SetActive(value: false);
			soulsContainer.gameObject.SetActive(value: false);
			return;
		}
		saveSlotDeleteOption.SetEnabled(_enabled: true);
		text.localize = false;
		text.Render(" ");
		player.gameObject.SetActive(value: true);
		characterName.localize = false;
		PlayerCustomization characterCustomization = Manager.saves.GetCharacterCustomization(saveFileId);
		string value = characterCustomization.name.Value;
		characterName.Render(value);
		CharacterType characterType = Manager.saves.GetCharacterType(saveFileId);
		this.characterType.Render("Menu/" + characterType);
		switch (characterType)
		{
		case CharacterType.Hardcore:
			this.characterType.SetTempColor(hardcoreColor);
			break;
		case CharacterType.Casual:
			this.characterType.SetTempColor(casualColor);
			break;
		default:
			this.characterType.SetTempColor(Color.white);
			break;
		}
		player.facingDirection = Direction.Id.right;
		player.animator.SetFloat(898384463, player.facingDirection.vec3.x);
		player.animator.SetFloat(1116435161, player.facingDirection.vec3.z);
		player.activeCustomization = characterCustomization;
		player.RefreshCustomization();
		healthBar.gameObject.SetActive(value: true);
		int currentMaxHealth = Manager.saves.GetCurrentMaxHealth(saveFileId);
		healthBar.UpdateHealthBar(currentMaxHealth, currentMaxHealth, 0, 0, showText: true, onlyShowMaxHealth: true);
		soulsContainer.gameObject.SetActive(value: true);
		for (int i = 0; i < souls.Count; i++)
		{
			souls[i].sr.gameObject.SetActive(Manager.saves.HasCollectedSoul(souls[i].soulId, saveFileId));
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
		animator.SetTrigger("active");
		DelayedSetColor();
		Invoke("DelayedSetColor", 0.001f);
		selectMarker.gameObject.SetActive(value: true);
		chooseCharacterMenu.GetScrollWindow().MoveScrollToIncludePosition(base.transform.localPosition.y, 1f);
		Select();
		base.OnSelected();
	}

	private void DelayedSetColor()
	{
		try
		{
			number.color = selectedColor;
			selectMarker.color = selectedColor;
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
	}

	public override void OnDeselected(bool playEffect = true)
	{
		animator.SetTrigger("inactive");
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
		if (!saveSlot.saveSlotDeleteOption.enabled && saveSlot.saveSlotDeleteOption.IsSelected() && !IsSelected())
		{
			Select();
		}
		base.Update();
	}
}
