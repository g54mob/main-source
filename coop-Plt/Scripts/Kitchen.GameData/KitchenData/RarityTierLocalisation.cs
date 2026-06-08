using System;
using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Rarity Tier Localisation", menuName = "Kitchen/Localisation/Rarity Tier")]
	public class RarityTierLocalisation : LocalisationSet<RarityTierInfo>
	{
		[OdinSerialize]
		public LocalisationObject<RarityTierInfo> Info;

		[NonSerialized]
		[HideInInspector]
		public Dictionary<RarityTier, string> Text;

		public string this[RarityTier i]
		{
			get
			{
				if (Text.TryGetValue(i, out var value))
				{
					return value;
				}
				return i.ToString();
			}
		}

		public override LocalisationObject<RarityTierInfo> LocalisationInfo => Info;

		protected override void InitialiseDefaults()
		{
		}

		public override bool Localise(Locale locale, StringSubstitutor subs)
		{
			if (Info == null)
			{
				return false;
			}
			RarityTierInfo rarityTierInfo = Info.Get(locale);
			if (rarityTierInfo == null)
			{
				return false;
			}
			Text = new Dictionary<RarityTier, string>();
			foreach (KeyValuePair<RarityTier, string> item in rarityTierInfo.Name)
			{
				Text.Add(item.Key, subs.Parse(item.Value));
			}
			return true;
		}
	}
}
