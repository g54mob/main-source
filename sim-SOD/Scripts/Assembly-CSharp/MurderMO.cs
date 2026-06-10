using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "murdererMO_data", menuName = "Database/Murderer MO")]
public class MurderMO : SoCustomComparison
{
	[Serializable]
	public class CallingCardPick
	{
		[Tooltip("The item itself")]
		public InteractablePreset item;

		public CallingCardOrigin origin;

		[Space(7f)]
		public Vector2 randomScoreRange;

		public List<MurderPreset.MurdererModifierRule> traitModifiers;
	}

	public enum CallingCardOrigin
	{
		createAtScene = 0,
		createOnGoToLocation = 1
	}

	[Serializable]
	public class Graffiti
	{
		public enum GraffitiPosition
		{
			victim = 0,
			nearbyWall = 1
		}

		public InteractablePreset preset;

		public GraffitiPosition pos;

		[Space(7f)]
		public ArtPreset artImage;

		[Space(7f)]
		public string ddsMessageTextList;

		public Color color;

		public float size;
	}

	[Serializable]
	public class JobModifier
	{
		public List<OccupationPreset> jobs;

		[Range(-20f, 20f)]
		public int jobBoost;
	}

	[Serializable]
	public class CompanyModifier
	{
		public List<CompanyPreset> companies;

		public int mininumEmployees;

		[Range(-20f, 20f)]
		public int companyBoost;

		[Tooltip("Add even more for employee count over the minimum")]
		public int boostPerEmployeeOverMinimum;
	}

	[Header("Notes")]
	[ResizableTextArea]
	public string notes;

	[Header("Compatibility")]
	public bool disabled;

	[Tooltip("Compatible with these killer types")]
	public List<MurderPreset> compatibleWith;

	[Range(0f, 2f)]
	public int baseDifficulty;

	[Header("Murderer Suitability")]
	[ReadOnly]
	[InfoBox("The max score should equal roughly the same across all MOs if you want MOs to be balanced", EInfoBoxType.Normal)]
	public float maximumPotentialScore;

	[OnValueChanged("OnGUIDValueChangedCallback")]
	public bool updateThis;

	[Space(10f)]
	[OnValueChanged("OnGUIDValueChangedCallback")]
	public Vector2 pickRandomScoreRange;

	[OnValueChanged("OnGUIDValueChangedCallback")]
	public List<MurderPreset.MurdererModifierRule> murdererTraitModifiers;

	[OnValueChanged("OnGUIDValueChangedCallback")]
	public List<JobModifier> murdererJobModifiers;

	[OnValueChanged("OnGUIDValueChangedCallback")]
	public List<CompanyModifier> murdererCompanyModifiers;

	[OnValueChanged("OnGUIDValueChangedCallback")]
	public bool useMurdererSocialClassRange;

	[EnableIf("useMurdererSocialClassRange")]
	[OnValueChanged("OnGUIDValueChangedCallback")]
	public Vector2 murdererClassRange;

	[EnableIf("useMurdererSocialClassRange")]
	[OnValueChanged("OnGUIDValueChangedCallback")]
	public int murdererClassRangeBoost;

	[Space(7f)]
	[OnValueChanged("OnGUIDValueChangedCallback")]
	public bool useHexaco;

	[ShowIf("useHexaco")]
	[OnValueChanged("OnGUIDValueChangedCallback")]
	public HEXACO hexaco;

	[Tooltip("Ensures the killer will have sniper vantage points at home. Victim's home has to be within line-of-sight of this.")]
	[Space(7f)]
	public bool requiresSniperVantageAtHome;

	[InfoBox("The killer will pick one of these to kill ALL their victims...", EInfoBoxType.Normal)]
	[Header("Weapons Picking")]
	public List<MurderWeaponsPool> weaponsPool;

	[Tooltip("Block weapons from being dropped at scene")]
	[Space(7f)]
	public bool blockDroppingWeapons;

	[Header("Crime Scene")]
	[Tooltip("The murder can happen anywhere")]
	public bool allowAnywhere;

	[DisableIf("allowAnywhere")]
	[Tooltip("The murder can happen at home")]
	public bool allowHome;

	[DisableIf("allowAnywhere")]
	[Tooltip("The murder can happen at work")]
	public bool allowWork;

	[DisableIf("allowAnywhere")]
	[Tooltip("The murder can happen in public")]
	public bool allowPublic;

	[Tooltip("The murder can happen in public")]
	[DisableIf("allowAnywhere")]
	public bool allowStreets;

	[DisableIf("allowAnywhere")]
	[Tooltip("The murder can happen at the killers den")]
	public bool allowDen;

	[EnableIf("allowDen")]
	public List<FurnitureCluster> denFurniture;

	[EnableIf("allowDen")]
	public List<DesignStylePreset> denStyleOverride;

	[EnableIf("allowDen")]
	public List<InteractablePreset> denItems;

	[Header("Victim Suitability")]
	[InfoBox("The below rule will give a big boost to the chances of this person being chosen.", EInfoBoxType.Normal)]
	[Range(-20f, 20f)]
	public int acquaintedSuitabilityBoost;

	[Range(-20f, 20f)]
	public int attractedToSuitabilityBoost;

	[Range(-20f, 20f)]
	[Tooltip("The following is multiplied by the like value in acquaintance class.")]
	public int likeSuitabilityBoost;

	[Range(-20f, 20f)]
	public int sameWorkplaceBoost;

	[Range(-20f, 20f)]
	public int murdererIsTenantBoost;

	[InfoBox("The killer will rank using these settings to their victims...", EInfoBoxType.Normal)]
	public Vector2 victimRandomScoreRange;

	public List<MurderPreset.MurdererModifierRule> victimTraitModifiers;

	public List<JobModifier> victimJobModifiers;

	public List<CompanyModifier> victimCompanyModifiers;

	public bool useVictimSocialClassRange;

	[EnableIf("useVictimSocialClassRange")]
	public Vector2 victimClassRange;

	[EnableIf("useVictimSocialClassRange")]
	public int victimClassRangeBoost;

	[Header("Monkier DDS Message List")]
	public string monkierDDSMessageList;

	[Header("Confessional Responses")]
	public List<string> confessionalDDSResponses;

	[Header("Leads")]
	public List<MurderPreset.MurderLeadItem> MOleads;

	[Header("Calling Cards")]
	public List<Graffiti> graffiti;

	[InfoBox("The killer will pick one of these to leave at ALL crime scenes...", EInfoBoxType.Normal)]
	public List<CallingCardPick> callingCardPool;

	[InfoBox("Pool of player taunts to leave at their apartment", EInfoBoxType.Normal)]
	[Header("Player Taunts")]
	public List<InteractablePreset> playerTaunts;

	private void OnGUIDValueChangedCallback()
	{
	}
}
