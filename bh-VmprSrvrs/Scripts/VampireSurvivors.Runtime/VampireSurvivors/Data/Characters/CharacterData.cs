using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Poncle.Schema.Attributes.Attributes;
using UnityEngine;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Data.Characters
{
	[Serializable]
	[Title("Character")]
	public class CharacterData
	{
		[ReadOnly(true)]
		public const string CharacterLangSheet = "characterLang/";

		[ReadOnly(true)]
		public const string SkinLangSheet = "skinLang/";

		public bool allowCoopOutline { get; set; }

		[Title("Hidden")]
		public bool hidden { get; set; }

		[Title("Always Hidden")]
		public bool alwaysHidden { get; set; }

		[Title("Secret")]
		public bool secret { get; set; }

		[Title("Hide Weapon Icon")]
		public bool hideWeaponIcon { get; set; }

		[Required]
		[Title("Level")]
		public int level { get; set; }

		[Title("Starting Weapon")]
		public WeaponType? startingWeapon { get; set; }

		[Title("Cooldown")]
		public float cooldown { get; set; }

		[Title("Prefix")]
		public string prefix { get; set; }

		[Title("Character Name")]
		public string charName { get; set; }

		[Title("Surname")]
		public string surname { get; set; }

		[Title("Texture Name")]
		public string textureName { get; set; }

		[Title("Sprite Name")]
		public string spriteName { get; set; }

		[Title("Char Sel Texture")]
		public string charSelTexture { get; set; }

		[Title("Char Sel Frame")]
		public string charSelFrame { get; set; }

		[Title("Portrait Name")]
		public string portraitName { get; set; }

		[Title("Walking Frames")]
		public int walkingFrames { get; set; }

		[Title("Head Offsets")]
		public List<Vector2> headOffsets { get; set; }

		[Title("Skins")]
		public List<Skin> skins { get; set; }

		[Title("Walk Frame Rate")]
		public int? walkFrameRate { get; set; }

		[Title("Description")]
		public string description { get; set; }

		[Title("Price")]
		public float price { get; set; }

		[Title("Max HP")]
		public float maxHp { get; set; }

		[Title("Armor")]
		public float armor { get; set; }

		[Title("Regen")]
		public float regen { get; set; }

		[Title("Move Speed")]
		public float moveSpeed { get; set; }

		[Title("Power")]
		public double power { get; set; }

		[Title("Area")]
		public float area { get; set; }

		[Title("Speed")]
		public float speed { get; set; }

		[Title("Duration")]
		public float duration { get; set; }

		[Title("Amount")]
		public float amount { get; set; }

		[Title("Luck")]
		public float luck { get; set; }

		[Title("Growth")]
		public float growth { get; set; }

		[Title("Greed")]
		public float greed { get; set; }

		[Title("Magnet")]
		public float magnet { get; set; }

		[Title("Revivals")]
		public float revivals { get; set; }

		[Title("Curse")]
		public float curse { get; set; }

		[Title("Shields")]
		public float shields { get; set; }

		[Title("Rerolls")]
		public float reRolls { get; set; }

		[Title("Skips")]
		public float skips { get; set; }

		[Title("Banish")]
		public float banish { get; set; }

		[Title("Showcase")]
		[CanBeNull]
		public List<WeaponType> showcase { get; set; }

		[Title("Level Up Presets")]
		[CanBeNull]
		public List<Loadout> levelUpPresets { get; set; }

		[Title("Debug Time")]
		public float debugTime { get; set; }

		[Title("Debug Enemies")]
		public float debugEnemies { get; set; }

		[Title("BGM")]
		public string bgm { get; set; }

		[Title("Start Frame Count")]
		public int? startFrameCount { get; set; }

		[Title("Zero Pad")]
		public int? zeroPad { get; set; }

		[Title("Suffix")]
		public string suffix { get; set; }

		[Title("Frame Rate")]
		public int? frameRate { get; set; }

		[Title("Sine Speed")]
		public SineBonusData sineSpeed { get; set; }

		[Title("Sine Cooldown")]
		public SineBonusData sineCooldown { get; set; }

		[Title("Sine Area")]
		public SineBonusData sineArea { get; set; }

		[Title("Sine Duration")]
		public SineBonusData sineDuration { get; set; }

		[Title("Sine Might")]
		public SineBonusData sineMight { get; set; }

		[Title("No Hurt")]
		public bool noHurt { get; set; }

		[Title("Ex Levels")]
		public int exLevels { get; set; }

		[Title("Ex Weapons")]
		public List<string> exWeapons { get; set; }

		[Title("Hidden Weapons")]
		public List<string> hiddenWeapons { get; set; }

		[Title("On Every Level Up")]
		public ModifierStats onEveryLevelUp { get; set; }

		[Title("Body Offset")]
		public Vector2? bodyOffset { get; set; }

		[Title("Name Index")]
		public int? nameIndex { get; set; }

		[Title("Current Skin")]
		public SkinType currentSkin { get; set; }

		[Title("Racing Offsets")]
		public List<RacingOffsetData> racingOffsets { get; set; }

		[Title("Requires Relic")]
		public ItemType? requiresRelic { get; set; }

		public string GetFirstNameLocKey(CharacterType t)
		{
			return null;
		}

		public string GetSkinPrefix()
		{
			return null;
		}

		public string GetSkinSuffix()
		{
			return null;
		}

		public string GetCharPrefix(CharacterType t)
		{
			return null;
		}

		public string GetCharFirstName(CharacterType t)
		{
			return null;
		}

		public string GetCharSurname(CharacterType t)
		{
			return null;
		}

		public string GetTextWithFallback<T>(T t, string sheet, string term, string fallback)
		{
			return null;
		}

		public string GetFirstNameWithPrefix(CharacterType t)
		{
			return null;
		}

		public string GetSurnameWithSuffix(CharacterType t)
		{
			return null;
		}

		public string GetFullName(CharacterType t, bool ignoreSkinPrefixSuffix = false, bool splitDualCharacterNames = true)
		{
			return null;
		}

		public string GetFullNameUntranslated()
		{
			return null;
		}

		public string GetSurNameLocKey(CharacterType t)
		{
			return null;
		}

		public string GetDescriptionLocKey(CharacterType t)
		{
			return null;
		}

		public string GetDescription(CharacterType t)
		{
			return null;
		}

		public RacingOffsetData GetRacingOffsetData(CharacterVehicleType characterVehicleType)
		{
			return null;
		}

		public Skin GetCurrentSkinData()
		{
			return null;
		}

		public Skin GetSkinData(SkinType skinType)
		{
			return null;
		}
	}
}
