using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomItemUpgradeDefinition : ISilverUnlockable, ISilverUnlockToken
	{
		public LocalisedString LocalisedName;

		public LocalisedString LocalisedDescription;

		public LocalisedString UnlockedMessage;

		public Sprite Icon;

		public int Cost;

		public int EnergyCost;

		public float Points = 1f;

		public float Prestige;

		public SharedInstance<QualificationDefinition> UpgradeQualification;

		public GameObject Prefab;

		public GameObject BlueprintPrefab;

		public GameObject AddOnPrefab;

		public GameObject AddOnBlueprintPrefab;

		public RoomModifier[] RoomModifiers;

		public SharedInstance<AmbulanceConfig> AmbulanceConfig;

		public bool RequiresSandboxResearch;

		public ISilverUnlockToken SilverUnlockToken => this;

		public int SilverCost()
		{
			return 0;
		}

		public LocalisedString GetUnlockName()
		{
			return LocalisedName;
		}

		public LocalisedString GetUnlockMessage()
		{
			return UnlockedMessage;
		}

		public Sprite GetUnlockIcon()
		{
			return Icon;
		}

		public ESandboxCheckType GetSandboxCheckType()
		{
			return ESandboxCheckType.RoomItems;
		}

		public override string ToString()
		{
			return LocalisedName.ToString();
		}
	}
}
