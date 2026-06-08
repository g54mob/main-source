using System;
using Sirenix.Serialization;
using UnityEngine;

namespace KitchenData.Localisations
{
	[CreateAssetMenu(fileName = "Contract Localisation", menuName = "Kitchen/Localisation/Contract")]
	public class ContractLocalisation : LocalisationSet<ContractInfo>
	{
		[OdinSerialize]
		public LocalisationObject<ContractInfo> Info;

		[NonSerialized]
		[HideInInspector]
		public string Name = "Title";

		[NonSerialized]
		[HideInInspector]
		public string Description = "Description!";

		public override LocalisationObject<ContractInfo> LocalisationInfo => Info;

		protected override void InitialiseDefaults()
		{
		}

		public override bool Localise(Locale locale, StringSubstitutor subs)
		{
			if (Info == null)
			{
				return false;
			}
			ContractInfo contractInfo = Info.Get(locale);
			if (contractInfo == null)
			{
				return false;
			}
			Name = subs.Parse(contractInfo.Name);
			Description = subs.Parse(contractInfo.Description);
			return true;
		}
	}
}
