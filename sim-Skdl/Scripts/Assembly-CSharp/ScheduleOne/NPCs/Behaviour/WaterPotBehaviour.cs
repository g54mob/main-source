using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;

namespace ScheduleOne.NPCs.Behaviour
{
	public class WaterPotBehaviour : GrowContainerBehaviour
	{
		public AvatarEquippable Equippable;

		private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EWaterPotBehaviourAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EWaterPotBehaviourAssembly_002DCSharp_002Edll_Excuted;

		public override void Awake()
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

		public override bool AreTaskConditionsMetForContainer(GrowContainer container)
		{
			return false;
		}

		public virtual bool AreTaskConditionsMetForContainer(GrowContainer container, float wateringThreshold)
		{
			return false;
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

		protected virtual void Awake_UserLogic_ScheduleOne_002ENPCs_002EBehaviour_002EWaterPotBehaviour_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
