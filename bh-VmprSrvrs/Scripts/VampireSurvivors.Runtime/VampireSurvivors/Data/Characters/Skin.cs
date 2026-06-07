using System;
using System.Collections.Generic;
using Poncle.Schema.Attributes.Attributes;
using UnityEngine;
using UnityEngine.Serialization;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Data.Characters
{
	[Serializable]
	public class Skin
	{
		[FormerlySerializedAs("id")]
		[Title("Skin Type")]
		public SkinType skinType;

		[Required]
		[Title("Name")]
		public string name { get; set; }

		[Title("Prefix")]
		public string prefix { get; set; }

		[Title("Suffix")]
		public string suffix { get; set; }

		[Title("Description")]
		public string description { get; set; }

		[Title("Texture Name")]
		[Required]
		public string textureName { get; set; }

		[Title("Sprite Name")]
		[Required]
		public string spriteName { get; set; }

		[Title("Char Sel Texture")]
		public string charSelTexture { get; set; }

		[Title("Char Sel Frame")]
		public string charSelFrame { get; set; }

		[Title("Walking Frames")]
		[Required]
		public int walkingFrames { get; set; }

		[Title("Walk Frame Rate")]
		public int? walkFrameRate { get; set; }

		[Title("Unlocked")]
		public bool unlocked { get; set; }

		[Title("Hidden")]
		public bool hidden { get; set; }

		[Title("Always Hidden")]
		public bool alwaysHidden { get; set; }

		[Title("Secret")]
		public bool secret { get; set; }

		[Title("Head Offsets")]
		public List<Vector2> headOffsets { get; set; }

		[Title("Starting Weapon")]
		public WeaponType? startingWeapon { get; set; }

		[Title("Sprite Anims")]
		public SpriteAnims spriteAnims { get; set; }

		public Vector2? bodyOffset { get; set; }

		[Title("Price")]
		public float price { get; set; }

		[Title("Cooldown")]
		public float cooldown { get; set; }

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

		[Title("Ex Weapons")]
		public List<string> exWeapons { get; set; }

		[Title("Ex Accessories")]
		public List<string> exAccessories { get; set; }

		[Title("Hidden Weapons")]
		public List<string> hiddenWeapons { get; set; }

		public ModifierStats onEveryLevelUp { get; set; }
	}
}
