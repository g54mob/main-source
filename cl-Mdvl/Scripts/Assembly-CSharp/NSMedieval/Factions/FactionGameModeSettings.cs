using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.Model;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.Factions
{
	[Serializable]
	public class FactionGameModeSettings : NSEipix.Base.Model
	{
		[SerializeField]
		private List<VillagePlacement> villagePlacement;

		[SerializeField]
		private FloatRange neutralRange;

		[SerializeField]
		private float friendlinessTargetEnemy;

		[SerializeField]
		private float friendlinessTargetNeutral;

		[SerializeField]
		private float friendlinessTargetFriendly;

		[SerializeField]
		private float friendlinessChangePerDay;

		[SerializeField]
		private List<string> friendlinessTextKeys;

		[SerializeField]
		private string colorFriendlyLow;

		[SerializeField]
		private string colorFriendlyHigh;

		[SerializeField]
		private string colorHostileLow;

		[SerializeField]
		private string colorHostileHigh;

		[SerializeField]
		private string colorNeutral;

		[SerializeField]
		private List<TraderStockModifiersContainer> stockModifiersByFriendliness;

		[SerializeField]
		private float friendlinessAddToEnemiesOfFriend;

		[SerializeField]
		private float friendlinessAddToEnemiesOfEnemy;

		[SerializeField]
		private float friendlinessChangePerHourOnLockedTrader;

		[NonSerialized]
		private Color colorFriendlyLowCache;

		[NonSerialized]
		private Color colorFriendlyHighCache;

		[NonSerialized]
		private Color colorHostileLowCache;

		[NonSerialized]
		private Color colorHostileHighCache;

		[NonSerialized]
		private Color colorNeutralCache;

		[NonSerialized]
		private bool colorInit;

		public Color ColorFriendlyLow
		{
			get
			{
				ColorInit();
				return colorFriendlyLowCache;
			}
		}

		public Color ColorFriendlyHigh
		{
			get
			{
				ColorInit();
				return colorFriendlyHighCache;
			}
		}

		public Color ColorHostileLow
		{
			get
			{
				ColorInit();
				return colorHostileLowCache;
			}
		}

		public Color ColorHostileHigh
		{
			get
			{
				ColorInit();
				return colorHostileHighCache;
			}
		}

		public Color ColorNeutral
		{
			get
			{
				ColorInit();
				return colorNeutralCache;
			}
		}

		public FloatRange NeutralRange => neutralRange;

		public float FriendlinessTargetEnemy => friendlinessTargetEnemy;

		public float FriendlinessTargetNeutral => friendlinessTargetNeutral;

		public float FriendlinessTargetFriendly => friendlinessTargetFriendly;

		public float FriendlinessChangePerDay => friendlinessChangePerDay;

		public List<string> FriendlinessTextKeys => friendlinessTextKeys;

		public float FriendlinessAddToEnemiesOfFriend => friendlinessAddToEnemiesOfFriend;

		public float FriendlinessAddToEnemiesOfEnemy => friendlinessAddToEnemiesOfEnemy;

		public float FriendlinessChangePerHourOnLockedTrader => friendlinessChangePerHourOnLockedTrader;

		public List<VillagePlacement> VillagePlacement => villagePlacement;

		public List<TraderStockModifier> GetStockModifiersForFriendliness(FactionFriendliness friendliness)
		{
			string text = friendliness.ToString();
			foreach (TraderStockModifiersContainer item in stockModifiersByFriendliness)
			{
				if (text.Equals(item.GetID(), StringComparison.InvariantCultureIgnoreCase))
				{
					return item.StockModifiers;
				}
			}
			return null;
		}

		public Color[] GetFriendlinessColors()
		{
			return new Color[5] { ColorHostileHigh, ColorHostileLow, ColorNeutral, ColorFriendlyLow, ColorFriendlyHigh };
		}

		private void ColorInit()
		{
			if (!colorInit)
			{
				ColorUtility.TryParseHtmlString(colorFriendlyLow, out colorFriendlyLowCache);
				ColorUtility.TryParseHtmlString(colorFriendlyHigh, out colorFriendlyHighCache);
				ColorUtility.TryParseHtmlString(colorHostileLow, out colorHostileLowCache);
				ColorUtility.TryParseHtmlString(colorHostileHigh, out colorHostileHighCache);
				ColorUtility.TryParseHtmlString(colorNeutral, out colorNeutralCache);
				colorInit = true;
			}
		}

		public override string GetID()
		{
			return "FactionGameMode";
		}
	}
}
