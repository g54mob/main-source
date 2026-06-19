#define PUG_ACHIEVEMENTS
using System;
using Pug.UnityExtensions;
using UnityEngine;

public class CharacterCustomizationMenu : RadicalMenu
{
	public enum CustomizableBodyPartType
	{
		Body = 0,
		SkinColor = 1,
		Hair = 2,
		HairColor = 3,
		EyeColor = 4,
		ShirtColor = 5,
		PantsColor = 6
	}

	public CharacterCustomizationOption_NameInput nameInput;

	public PugText nameText;

	public PlayerController pc;

	public RadicalMenuOption_Done doneOption;

	public CharacterCustomizationOption_Rotate rotateLeftButton;

	public CharacterCustomizationOption_Rotate rotateRightButton;

	public CharacterCustomizationOption_Selection roleSelection;

	public DataBlockRef<PlayerCustomizationTableDataBlock> customizationTable;

	public DataBlockRef<PlayerKeyArtTable> playerKeyArt;

	private Direction characterFacingDirection;

	private bool hasRandomized;

	private int saveFileId;

	private int _bodyIndex;

	private int _skinColorIndex;

	private int _hairIndex;

	private int _hairColorIndex;

	private int _eyesColorIndex;

	private int _shirtColorIndex;

	private int _pantsColorIndex;

	protected override void Awake()
	{
		PlayerCustomizationTableDataBlock playerCustomizationTableDataBlock = customizationTable.Get();
		if (playerCustomizationTableDataBlock == null)
		{
			Debug.LogError("CharacterCustomizationMenu: PlayerCustomizationTableDataBlock is not assigned.");
			return;
		}
		int count = playerCustomizationTableDataBlock.bodySkinCollection.Get().Count;
		if (count != playerCustomizationTableDataBlock.eyeSkinCollection.Get().Count || count != playerCustomizationTableDataBlock.shirtSkinCollection.Get().Count || count != playerCustomizationTableDataBlock.pantsSkinCollection.Get().Count)
		{
			Debug.LogError("CharacterCustomizationMenu: Mismatched number of body, eye, shirt, or pants skins in PlayerCustomizationTableDataBlock.");
		}
		if (playerCustomizationTableDataBlock.skinReplacementColors.Get().Count != playerCustomizationTableDataBlock.hairShadeReplacementColors.Get().Count)
		{
			Debug.LogError("CharacterCustomizationMenu: Mismatched number of skin and hair shade colors in PlayerCustomizationTableDataBlock.");
		}
	}

	public override void Activate()
	{
		base.Activate();
		bool isInGame = Manager.sceneHandler.isInGame;
		characterFacingDirection = Direction.Id.back;
		UpdateFacingDirection();
		if (isInGame && Manager.main.player != null)
		{
			roleSelection.gameObject.SetActive(value: false);
			nameInput.SetInputText(Manager.main.player.activeCustomization.name.Value);
			pc.activeCustomization = Manager.main.player.activeCustomization;
			pc.activeCustomization.helm = new DataBlockAddress(Guid.Parse("38f67562-7735-1324-6ade-6f067e2d86b9"));
			pc.activeCustomization.breastArmor = new DataBlockAddress(Guid.Parse("79ab3677-3176-d464-783f-e43b94310196"));
			pc.activeCustomization.pantsArmor = new DataBlockAddress(Guid.Parse("66719df9-87d3-5fd4-6b9a-8b3bcd85ba6c"));
			pc.RefreshCustomization();
		}
		else
		{
			nameInput.SetInputText("");
			if (Manager.input.SystemPrefersKeyboardAndMouse())
			{
				nameInput.Select();
				nameInput.LeftClick(mod1: false, mod2: false, autoActivated: true);
			}
			roleSelection.gameObject.SetActive(value: true);
			roleSelection.ResetRole();
			if (!hasRandomized)
			{
				Randomize();
				hasRandomized = true;
			}
		}
		saveFileId = Manager.saves.GetCharacterId();
	}

	public void OnDone()
	{
		if (Manager.sceneHandler.isInGame)
		{
			StoreCharacterAndContinueGame();
		}
		else
		{
			hasRandomized = false;
			StoreCharacterAndStartGame();
		}
		if (IsWowCombination())
		{
			Manager.achievements.TriggerAchievement(AchievementID.KeyArtCharacter);
		}
	}

	private void Update()
	{
		doneOption.SetInteractable(nameText.displayedTextString.Trim() != "");
		if (Manager.input.IsMenuRightShoulderButtonDown())
		{
			RotateCharacterRightClick();
		}
		else if (Manager.input.IsMenuLeftShoulderButtonDown())
		{
			RotateCharacterLeftClick();
		}
	}

	public void StepCustomizationOption(CustomizableBodyPartType type, int step, bool refresh = true)
	{
		PlayerCustomizationTableDataBlock playerCustomizationTableDataBlock = customizationTable.Get();
		BodySkinCollectionDataBlock bodySkinCollectionDataBlock = playerCustomizationTableDataBlock.bodySkinCollection.Get();
		EyesSkinCollectionDataBlock eyesSkinCollectionDataBlock = playerCustomizationTableDataBlock.eyeSkinCollection.Get();
		ReplacementColorCollectionDataBlock replacementColorCollectionDataBlock = playerCustomizationTableDataBlock.eyeReplacementColors.Get();
		ShirtSkinCollectionDataBlock shirtSkinCollectionDataBlock = playerCustomizationTableDataBlock.shirtSkinCollection.Get();
		ReplacementColorCollectionDataBlock replacementColorCollectionDataBlock2 = shirtSkinCollectionDataBlock[_bodyIndex].replacementColorsCollectionRef.Get();
		PantsSkinCollectionDataBlock pantsSkinCollectionDataBlock = playerCustomizationTableDataBlock.pantsSkinCollection.Get();
		ReplacementColorCollectionDataBlock replacementColorCollectionDataBlock3 = pantsSkinCollectionDataBlock[_bodyIndex].replacementColorsCollectionRef.Get();
		HairSkinCollectionDataBlock hairSkinCollectionDataBlock = playerCustomizationTableDataBlock.hairSkinCollection.Get();
		ReplacementColorCollectionDataBlock replacementColorCollectionDataBlock4 = playerCustomizationTableDataBlock.hairReplacementColors.Get();
		ReplacementColorCollectionDataBlock replacementColorCollectionDataBlock5 = playerCustomizationTableDataBlock.hairShadeReplacementColors.Get();
		ReplacementColorCollectionDataBlock replacementColorCollectionDataBlock6 = playerCustomizationTableDataBlock.skinReplacementColors.Get();
		switch (type)
		{
		case CustomizableBodyPartType.Body:
			_bodyIndex = StepCircular(_bodyIndex, step, bodySkinCollectionDataBlock.Count);
			pc.activeCustomization.body = bodySkinCollectionDataBlock[_bodyIndex].address;
			pc.activeCustomization.eyes = eyesSkinCollectionDataBlock[_bodyIndex].address;
			pc.activeCustomization.shirtSkin = shirtSkinCollectionDataBlock[_bodyIndex].address;
			pc.activeCustomization.pantsSkin = pantsSkinCollectionDataBlock[_bodyIndex].address;
			_shirtColorIndex = Math.Min(_shirtColorIndex, replacementColorCollectionDataBlock2.Count - 1);
			pc.activeCustomization.shirtColor = replacementColorCollectionDataBlock2[_shirtColorIndex].address;
			_pantsColorIndex = Math.Min(_pantsColorIndex, replacementColorCollectionDataBlock3.Count - 1);
			pc.activeCustomization.pantsColor = replacementColorCollectionDataBlock3[_pantsColorIndex].address;
			break;
		case CustomizableBodyPartType.SkinColor:
			_skinColorIndex = StepCircular(_skinColorIndex, step, replacementColorCollectionDataBlock6.Count);
			pc.activeCustomization.skinColor = replacementColorCollectionDataBlock6[_skinColorIndex].address;
			pc.activeCustomization.hairShadeColor = replacementColorCollectionDataBlock5[_skinColorIndex].address;
			break;
		case CustomizableBodyPartType.Hair:
			_hairIndex = StepCircular(_hairIndex, step, hairSkinCollectionDataBlock.Count);
			pc.activeCustomization.hair = hairSkinCollectionDataBlock[_hairIndex].address;
			break;
		case CustomizableBodyPartType.HairColor:
			_hairColorIndex = StepCircular(_hairColorIndex, step, replacementColorCollectionDataBlock4.Count);
			pc.activeCustomization.hairColor = replacementColorCollectionDataBlock4[_hairColorIndex].address;
			break;
		case CustomizableBodyPartType.EyeColor:
			_eyesColorIndex = StepCircular(_eyesColorIndex, step, replacementColorCollectionDataBlock.Count);
			pc.activeCustomization.eyesColor = replacementColorCollectionDataBlock[_eyesColorIndex].address;
			break;
		case CustomizableBodyPartType.ShirtColor:
			_shirtColorIndex = StepCircular(_shirtColorIndex, step, replacementColorCollectionDataBlock2.Count);
			pc.activeCustomization.shirtColor = replacementColorCollectionDataBlock2[_shirtColorIndex].address;
			break;
		case CustomizableBodyPartType.PantsColor:
			_pantsColorIndex = StepCircular(_pantsColorIndex, step, replacementColorCollectionDataBlock3.Count);
			pc.activeCustomization.pantsColor = replacementColorCollectionDataBlock3[_pantsColorIndex].address;
			break;
		}
		if (refresh)
		{
			pc.RefreshCustomization();
		}
	}

	public void Randomize()
	{
		StepCustomizationOption(CustomizableBodyPartType.Body, UnityEngine.Random.Range(1, int.MaxValue), refresh: false);
		StepCustomizationOption(CustomizableBodyPartType.SkinColor, UnityEngine.Random.Range(1, int.MaxValue), refresh: false);
		StepCustomizationOption(CustomizableBodyPartType.Hair, UnityEngine.Random.Range(1, int.MaxValue), refresh: false);
		StepCustomizationOption(CustomizableBodyPartType.HairColor, UnityEngine.Random.Range(1, int.MaxValue), refresh: false);
		StepCustomizationOption(CustomizableBodyPartType.EyeColor, UnityEngine.Random.Range(1, int.MaxValue), refresh: false);
		StepCustomizationOption(CustomizableBodyPartType.ShirtColor, UnityEngine.Random.Range(1, int.MaxValue), refresh: false);
		StepCustomizationOption(CustomizableBodyPartType.PantsColor, UnityEngine.Random.Range(1, int.MaxValue), refresh: false);
		pc.RefreshCustomization();
	}

	private static int StepCircular(int value, int step, int maxValue)
	{
		return ((value + step) % maxValue + maxValue) % maxValue;
	}

	private void StoreCharacterAndStartGame()
	{
		pc.activeCustomization.name = nameText.displayedTextString.Trim();
		Manager.saves.SetCharacterCustomization(saveFileId, pc.activeCustomization);
		Manager.saves.WriteCharacter(saveFileId);
		Manager.saves.SetCharacterId(saveFileId);
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

	private void StoreCharacterAndContinueGame()
	{
		pc.activeCustomization.name = nameText.displayedTextString.Trim();
		PlayerCustomization activeCustomization = Manager.main.player.activeCustomization;
		pc.activeCustomization.helm = activeCustomization.helm;
		pc.activeCustomization.breastArmor = activeCustomization.breastArmor;
		pc.activeCustomization.pantsArmor = activeCustomization.pantsArmor;
		Manager.saves.SetCharacterCustomization(saveFileId, pc.activeCustomization);
		Manager.saves.WriteCharacter(saveFileId);
		Manager.main.player.UpdateAndSendNewCustomization();
		Manager.menu.PopAllMenus();
		if (IsWowCombination())
		{
			EntityUtility.PlayEffectEventClient(new EffectEventCD
			{
				effectID = EffectID.MagicMirrorEffectWow,
				position1 = Manager.main.player.transform.position
			});
		}
		else
		{
			EntityUtility.PlayEffectEventClient(new EffectEventCD
			{
				effectID = EffectID.MagicMirrorEffect,
				position1 = Manager.main.player.transform.position
			});
		}
	}

	public void RotateCharacterLeftClick()
	{
		rotateLeftButton.LeftClick();
	}

	public void RotateCharacterLeft()
	{
		characterFacingDirection = characterFacingDirection.nextClockwise;
		UpdateFacingDirection();
	}

	public void RotateCharacterRightClick()
	{
		rotateRightButton.LeftClick();
	}

	public void RotateCharacterRight()
	{
		characterFacingDirection = characterFacingDirection.nextCounterClockwise;
		UpdateFacingDirection();
	}

	private void UpdateFacingDirection()
	{
		pc.animator.SetFloat(898384463, characterFacingDirection.vec3.x);
		pc.animator.SetFloat(1116435161, characterFacingDirection.vec3.z);
	}

	private bool IsWowCombination()
	{
		PlayerKeyArtTable playerKeyArtTable = playerKeyArt.Get();
		if (playerKeyArtTable != null)
		{
			return playerKeyArtTable.IsKeyArt(pc.activeCustomization);
		}
		return false;
	}
}
