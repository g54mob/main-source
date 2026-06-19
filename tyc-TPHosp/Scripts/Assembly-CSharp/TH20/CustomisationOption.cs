using BehaviorDesigner.Runtime;
using FullInspector.Generated.SharedInstance;
using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/Customisation Option", order = 1103)]
	public class CustomisationOption : ScriptableObjectWithID, ISilverUnlockable, ISilverUnlockToken
	{
		public LocalisedString Name;

		public Sprite Icon;

		public ModularMeshMaterialBindings MeshMaterialBinding;

		public SharedInstance_TH20TH20_CharModule_Mask Mask;

		public SharedInstance_TH20TH20_DLCItemDefinition DlcPackRequired;

		[SerializeField]
		private int _silverCost;

		public int LocoOverridePriority;

		public RuntimeAnimatorController[] LocoOverrideGraphs;

		public RuntimeAnimatorController[] HappyIdleAnimGraphs;

		public ExternalBehavior BehaviourSatisfyToiletOverride;

		public bool UseAlternateInteractionAnimGraphs;

		public SharedInstance_TH20TH20_RoomDefinition CantChangeWhileInRoom;

		public bool DisallowNauseaFulfilment;

		public int PrimeEntitlementRequired;

		public ISilverUnlockToken SilverUnlockToken => this;

		public int SilverCost()
		{
			return _silverCost;
		}

		public LocalisedString GetUnlockName()
		{
			return Name;
		}

		public LocalisedString GetUnlockMessage()
		{
			return default(LocalisedString);
		}

		public Sprite GetUnlockIcon()
		{
			return Icon;
		}

		public ESandboxCheckType GetSandboxCheckType()
		{
			return ESandboxCheckType.RoomItems;
		}
	}
}
