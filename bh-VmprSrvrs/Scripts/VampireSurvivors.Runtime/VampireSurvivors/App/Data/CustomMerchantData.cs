using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.App.Data
{
	[Serializable]
	public class CustomMerchantData
	{
		[JsonProperty("merchantCharacter")]
		public CharacterType MerchantCharacter { get; set; }

		[JsonProperty("portraitSprite")]
		public string PortraitSprite { get; set; }

		[JsonProperty("portraitSpriteTexture")]
		public string PortraitSpriteTexture { get; set; }

		[JsonProperty("staticSprite")]
		public string StaticSprite { get; set; }

		[JsonProperty("staticSpriteTexture")]
		public string StaticSpriteTexture { get; set; }

		[JsonProperty("DLC")]
		public List<DlcType> DLC { get; set; }

		[JsonProperty("isAnimated")]
		public bool IsAnimated { get; set; }

		[JsonProperty("hideBackgroundParticles")]
		public bool HideBackgroundParticles { get; set; }

		[JsonProperty("hideBackgroundWindows")]
		public bool HideBackgroundWindows { get; set; }

		[JsonProperty("hideBackgroundMask")]
		public bool HideBackgroundMask { get; set; }

		[JsonProperty("customCooldown")]
		public float? CustomCooldown { get; set; }

		[JsonProperty("textLocKey")]
		public string TextLocKey { get; set; }

		[JsonProperty("merchantXPos")]
		public float? MerchantXPos { get; set; }

		[JsonProperty("merchantYPos")]
		public float? MerchantYPos { get; set; }

		[JsonProperty("bodyOffset")]
		public Vector2? BodyOffset { get; set; }

		[JsonProperty("merchantInventory")]
		public List<WeaponType> MerchantInventory { get; set; }

		[JsonProperty("merchantInventoryItems")]
		public List<ItemType> MerchantInventoryItems { get; set; }
	}
}
