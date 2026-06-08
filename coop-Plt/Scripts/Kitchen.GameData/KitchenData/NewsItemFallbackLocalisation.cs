using System;
using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "News Item Fallback Localisation", menuName = "Kitchen/Localisation/News Item Fallback Text")]
	public class NewsItemFallbackLocalisation : LocalisationSet<NewsItemFallbackInfo>
	{
		[OdinSerialize]
		public LocalisationObject<NewsItemFallbackInfo> Info;

		[NonSerialized]
		[HideInInspector]
		public Dictionary<NewsItemType, GenericLocalisationStruct> Text;

		public override LocalisationObject<NewsItemFallbackInfo> LocalisationInfo => Info;

		protected override void InitialiseDefaults()
		{
		}

		public override bool Localise(Locale locale, StringSubstitutor subs)
		{
			if (Info == null)
			{
				return false;
			}
			NewsItemFallbackInfo newsItemFallbackInfo = Info.Get(locale);
			if (newsItemFallbackInfo == null)
			{
				return false;
			}
			Text = new Dictionary<NewsItemType, GenericLocalisationStruct>();
			foreach (KeyValuePair<NewsItemType, GenericLocalisationStruct> item in newsItemFallbackInfo.Text)
			{
				Text.Add(item.Key, new GenericLocalisationStruct
				{
					Name = subs.Parse(item.Value.Name),
					Description = subs.Parse(item.Value.Description)
				});
			}
			return true;
		}
	}
}
