using FractureField.Rocks;
using FractureField.Shared.Enums;
using FractureField.UI.Components;
using UnityEngine;

namespace FractureField
{
	public class Colors : MonoBehaviour
	{
		public class General
		{
			public static Color RedCannotAfford;
		}

		public class Buttons
		{
			public static Color Disabled;

			public static Color Orange;

			public static Color Blue;

			public static Color Red;

			public static Color Green;

			public static Color Yellow;

			public static Color Ad;
		}

		public class Badges
		{
			public static Color Blue;

			public static Color Red;

			public static Color Green;

			public static Color Yellow;

			public static Color Orange;

			public static Color Get(BadgeColor badgeColor)
			{
				return default(Color);
			}
		}

		public class ProgressBar
		{
			public static Color Blue;

			public static Color Red;

			public static Color Green;

			public static Color Yellow;
		}

		public class Rarities
		{
			public static Color Common;

			public static Color Uncommon;

			public static Color Rare;

			public static Color Epic;

			public static Color Legendary;

			public static Color Mythic;

			public static Color Get(Rarity rarity)
			{
				return default(Color);
			}
		}

		public class Tabs
		{
			public static Color Active;

			public static Color Inactive;

			public static Color Get(bool isActive)
			{
				return default(Color);
			}
		}

		public class Currencies
		{
			public static Color Dust;

			public static Color DroneCores;

			public static Color StoneFragments;

			public static Color ClayTablets;

			public static Color SandstoneShards;

			public static Color QuartzCrystals;

			public static Color IronOre;

			public static Color SilverNuggets;

			public static Color GoldNuggets;

			public static Color DiamondCrystals;

			public static Color ObsidianSplinters;

			public static Color StardustMotes;

			public static Color VoidSlivers;

			public static Color ChroniteShards;

			public static Color Get(CurrencyType currencyType)
			{
				return default(Color);
			}
		}

		public class Rocks
		{
			public class Sparks
			{
				public static Color Stone;

				public static Color Clay;

				public static Color Sandstone;

				public static Color Quartz;

				public static Color Iron;

				public static Color Silver;

				public static Color Gold;

				public static Color Diamond;

				public static Color Obsidian;

				public static Color Starmetal;

				public static Color Voidstone;

				public static Color Chronite;

				public static Color Get(RockLayerType layerType)
				{
					return default(Color);
				}
			}

			public class HealthBars
			{
				public static Color Stone;

				public static Color Clay;

				public static Color Sandstone;

				public static Color Quartz;

				public static Color Iron;

				public static Color Silver;

				public static Color Gold;

				public static Color Diamond;

				public static Color Obsidian;

				public static Color Starmetal;

				public static Color Voidstone;

				public static Color Chronite;

				public static Color DefaultBackground;

				public static Color ContrastBackground;

				public static Color Get(RockLayerType layerType)
				{
					return default(Color);
				}

				public static Color GetBackground(RockLayerType layerType)
				{
					return default(Color);
				}
			}
		}

		public static Color Get(string hex)
		{
			return default(Color);
		}
	}
}
