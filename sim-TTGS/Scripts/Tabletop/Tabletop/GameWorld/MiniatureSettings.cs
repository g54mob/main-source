using Dhs5.Utility.Settings;
using I2.Loc;
using UnityEngine;

namespace Tabletop.GameWorld
{
	[Settings("Tabletop/Miniatures", Scope.Project)]
	public class MiniatureSettings : CustomSettings<MiniatureSettings>
	{
		[Header("Rarity")]
		[SerializeField]
		private int m_miniatureRarityTiers = 5;

		[SerializeField]
		[VectorRange(2f, 10f)]
		private Vector2Int m_uncommonRarityRange = new Vector2Int(2, 3);

		[Space(10f)]
		[SerializeField]
		private Sprite m_uncommonMarkerSprite;

		[SerializeField]
		private Sprite m_rareMarkerSprite;

		[Space(10f)]
		[SerializeField]
		private Sprite m_uncommonSquadMarkerSprite;

		[SerializeField]
		private Sprite m_rareSquadMarkerSprite;

		[Header("Unpacking")]
		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("Delay between unpacking animation end and unpacking popup")]
		private float m_unpackingDelay = 0.2f;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_superLegendaryProba = 0.02f;

		[SerializeField]
		private EnumValues<ELicense, MiniatureBoxProductData> m_superLegendaryBoxes;

		[Header("Licenses")]
		[SerializeField]
		private EnumValues<ELicense, Sprite> m_licenseSprites;

		[SerializeField]
		private EnumValues<ELicense, LocalizedString> m_licenseTerms;

		[Header("Armies")]
		[SerializeField]
		private EnumValues<EMiniatureArmy, Sprite> m_armySprites;

		[SerializeField]
		private EnumValues<EMiniatureArmy, LocalizedString> m_armyTerms;

		[SerializeField]
		private Material m_highlightMissingPieceMaterial;

		[Header("Scale")]
		[SerializeField]
		[Range(0.01f, 2f)]
		private float m_miniature3DSize;

		[Header("Setup")]
		[SerializeField]
		[Layer]
		private int m_preview3DLayer;

		public static int MiniatureRarityTiers => CustomSettings<MiniatureSettings>.I.m_miniatureRarityTiers;

		public static float UnpackingDelay => CustomSettings<MiniatureSettings>.I.m_unpackingDelay;

		public static float SuperLegendaryProba => CustomSettings<MiniatureSettings>.I.m_superLegendaryProba;

		public static Material HighlightMissingPieceMaterial => CustomSettings<MiniatureSettings>.I.m_highlightMissingPieceMaterial;

		public static float Miniature3DSize => CustomSettings<MiniatureSettings>.I.m_miniature3DSize;

		public static int Preview3DLayer => CustomSettings<MiniatureSettings>.I.m_preview3DLayer;

		public static EMiniatureType GetTypeFromRarity(int rarity)
		{
			if (rarity < CustomSettings<MiniatureSettings>.I.m_uncommonRarityRange.x)
			{
				return EMiniatureType.COMMON;
			}
			if (rarity <= CustomSettings<MiniatureSettings>.I.m_uncommonRarityRange.y)
			{
				return EMiniatureType.UNCOMMON;
			}
			return EMiniatureType.RARE;
		}

		public static Sprite GetCollectionSpriteFromRarity(EMiniatureType type)
		{
			return type switch
			{
				EMiniatureType.UNCOMMON => CustomSettings<MiniatureSettings>.I.m_uncommonMarkerSprite, 
				EMiniatureType.RARE => CustomSettings<MiniatureSettings>.I.m_rareMarkerSprite, 
				_ => null, 
			};
		}

		public static Sprite GetSquadSpriteFromRarity(EMiniatureType type)
		{
			return type switch
			{
				EMiniatureType.UNCOMMON => CustomSettings<MiniatureSettings>.I.m_uncommonSquadMarkerSprite, 
				EMiniatureType.RARE => CustomSettings<MiniatureSettings>.I.m_rareSquadMarkerSprite, 
				_ => null, 
			};
		}

		public static MiniatureBoxProductData GetSuperLegendaryBox(ELicense license)
		{
			return CustomSettings<MiniatureSettings>.I.m_superLegendaryBoxes[license];
		}

		public static Sprite GetLicenseSprite(ELicense license)
		{
			return CustomSettings<MiniatureSettings>.I.m_licenseSprites[license];
		}

		public static string GetLicenseTerm(ELicense license)
		{
			return CustomSettings<MiniatureSettings>.I.m_licenseTerms[license].mTerm;
		}

		public static Sprite GetArmySprite(EMiniatureArmy army)
		{
			return CustomSettings<MiniatureSettings>.I.m_armySprites[army];
		}

		public static string GetArmyTerm(EMiniatureArmy army)
		{
			return CustomSettings<MiniatureSettings>.I.m_armyTerms[army].mTerm;
		}
	}
}
