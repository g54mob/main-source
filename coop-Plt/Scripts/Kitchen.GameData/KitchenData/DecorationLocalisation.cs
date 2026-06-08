using System;
using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Decoration Localisation", menuName = "Kitchen/Localisation/Decoration")]
	public class DecorationLocalisation : LocalisationSet<DecorationBonusInfo>
	{
		[OdinSerialize]
		public LocalisationObject<DecorationBonusInfo> Info;

		[NonSerialized]
		[HideInInspector]
		public Dictionary<DecorationBonus, string> Text;

		[NonSerialized]
		[HideInInspector]
		public Dictionary<DecorationType, string> Icons;

		public string this[DecorationBonus b]
		{
			get
			{
				if (Text.TryGetValue(b, out var value))
				{
					return value;
				}
				return "";
			}
		}

		public override LocalisationObject<DecorationBonusInfo> LocalisationInfo => Info;

		protected override void InitialiseDefaults()
		{
		}

		public override bool Localise(Locale locale, StringSubstitutor subs)
		{
			if (Info == null)
			{
				return false;
			}
			DecorationBonusInfo decorationBonusInfo = Info.Get(locale);
			if (decorationBonusInfo == null)
			{
				return false;
			}
			Text = new Dictionary<DecorationBonus, string>();
			foreach (KeyValuePair<DecorationBonus, string> item in decorationBonusInfo.Text)
			{
				Text.Add(item.Key, subs.Parse(item.Value));
			}
			Icons = new Dictionary<DecorationType, string>();
			foreach (KeyValuePair<DecorationType, string> icon in decorationBonusInfo.Icons)
			{
				Icons.Add(icon.Key, subs.Parse(icon.Value));
			}
			return true;
		}
	}
}
