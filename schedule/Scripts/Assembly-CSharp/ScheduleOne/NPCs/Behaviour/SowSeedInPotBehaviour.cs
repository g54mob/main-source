using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.Trash;

namespace ScheduleOne.NPCs.Behaviour
{
	public class SowSeedInPotBehaviour : GrowContainerBehaviour
	{
		private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002ESowSeedInPotBehaviourAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002ESowSeedInPotBehaviourAssembly_002DCSharp_002Edll_Excuted;

		protected override float GetActionDuration()
		{
			return 0f;
		}

		protected override string GetAnimationBool()
		{
			return null;
		}

		protected override void OnStartPerformAction()
		{
		}

		protected override void OnStopPerformAction()
		{
		}

		protected override string[] GetRequiredItemSuitableIDs(GrowContainer growContainer)
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

		protected override TrashItem GetTrashPrefab(ItemInstance usedItem)
		{
			return null;
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

		public override void Awake()
		{
		}
	}
}
