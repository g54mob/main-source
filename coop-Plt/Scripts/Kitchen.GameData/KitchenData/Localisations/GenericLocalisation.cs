using System;
using Sirenix.Serialization;
using UnityEngine;

namespace KitchenData.Localisations
{
	[CreateAssetMenu(fileName = "Generic Localisation", menuName = "Kitchen/Localisation/Generic")]
	public class GenericLocalisation : LocalisationSet<BasicInfo>
	{
		[OdinSerialize]
		public LocalisationObject<BasicInfo> Info;

		[NonSerialized]
		[HideInInspector]
		public string Name = "Title";

		[NonSerialized]
		[HideInInspector]
		public string Description = "Description!";

		public override LocalisationObject<BasicInfo> LocalisationInfo => Info;

		protected override void InitialiseDefaults()
		{
		}

		public override bool Localise(Locale locale, StringSubstitutor subs)
		{
			if (Info == null)
			{
				return false;
			}
			BasicInfo basicInfo = Info.Get(locale);
			if (basicInfo == null)
			{
				return false;
			}
			Name = subs.Parse(basicInfo.Name);
			Description = subs.Parse(basicInfo.Description);
			return true;
		}
	}
}
