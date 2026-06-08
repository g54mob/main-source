using System;
using System.Collections.Generic;
using Kitchen;
using Sirenix.Serialization;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Start Day Warning Localisation", menuName = "Kitchen/Localisation/Start Day Warning Text")]
	public class StartDayWarningLocalisation : LocalisationSet<StartDayWarningInfo>
	{
		[OdinSerialize]
		public LocalisationObject<StartDayWarningInfo> Info;

		[NonSerialized]
		[HideInInspector]
		public Dictionary<StartDayWarning, GenericLocalisationStruct> Text;

		public override LocalisationObject<StartDayWarningInfo> LocalisationInfo => Info;

		protected override void InitialiseDefaults()
		{
		}

		public override bool Localise(Locale locale, StringSubstitutor subs)
		{
			if (Info == null)
			{
				return false;
			}
			StartDayWarningInfo startDayWarningInfo = Info.Get(locale);
			if (startDayWarningInfo == null)
			{
				return false;
			}
			Text = new Dictionary<StartDayWarning, GenericLocalisationStruct>();
			foreach (KeyValuePair<StartDayWarning, GenericLocalisationStruct> item in startDayWarningInfo.Text)
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
