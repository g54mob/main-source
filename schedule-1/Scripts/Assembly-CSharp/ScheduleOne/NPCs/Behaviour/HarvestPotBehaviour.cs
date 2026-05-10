using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;

namespace ScheduleOne.NPCs.Behaviour
{
	public class HarvestPotBehaviour : GrowContainerBehaviour
	{
		public AvatarEquippable TrimmersEquippable;

		private Pot _pot;

		private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EHarvestPotBehaviourAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EHarvestPotBehaviourAssembly_002DCSharp_002Edll_Excuted;

		public override void Awake()
		{
		}

		public override void AssignAndEnable(GrowContainer growContainer)
		{
		}

		protected override float GetActionDuration()
		{
			return 0f;
		}

		protected override string GetAnimationBool()
		{
			return null;
		}

		protected override AvatarEquippable GetActionEquippable()
		{
			return null;
		}

		protected override void OnActionSuccess(ItemInstance usedItem)
		{
		}

		private int GetQuantityToHarvest()
		{
			return 0;
		}

		public override bool AreTaskConditionsMetForContainer(GrowContainer container)
		{
			return false;
		}

		protected override bool CheckSuccess(ItemInstance usedItem)
		{
			return false;
		}

		public bool DoesPotHaveValidDestination(Pot pot)
		{
			return false;
		}

		private int GetDestinationCapacityForItem(Pot pot, ItemInstance item)
		{
			return 0;
		}

		public override void NetworkInitialize___Early()
		{
		}

		public override void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		protected virtual void Awake_UserLogic_ScheduleOne_002ENPCs_002EBehaviour_002EHarvestPotBehaviour_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
