using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.Employees;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.Trash;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour
{
	public abstract class GrowContainerBehaviour : Behaviour
	{
		protected enum EState
		{
			Idle = 0,
			Walking = 1,
			GrabbingSupplies = 2,
			PerformingAction = 3
		}

		private Coroutine _walkRoutine;

		private Coroutine _grabRoutine;

		private Coroutine _performActionRoutine;

		private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EGrowContainerBehaviourAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EGrowContainerBehaviourAssembly_002DCSharp_002Edll_Excuted;

		protected GrowContainer _growContainer { get; private set; }

		protected EState _currentState { get; private set; }

		protected Botanist _botanist { get; private set; }

		protected BotanistConfiguration _botanistConfiguration => null;

		public override void Awake()
		{
		}

		public virtual void AssignAndEnable(GrowContainer growContainer)
		{
		}

		public override void Activate()
		{
		}

		public override void Resume()
		{
		}

		public override void Pause()
		{
		}

		public override void Deactivate()
		{
		}

		public virtual bool AreTaskConditionsMetForContainer(GrowContainer container)
		{
			return false;
		}

		public bool DoesBotanistHaveAccessToRequiredSupplies(GrowContainer container)
		{
			return false;
		}

		public override void OnActiveTick()
		{
		}

		protected virtual void OnStartPerformAction()
		{
		}

		protected virtual void OnStopPerformAction()
		{
		}

		protected virtual Vector3 GetGrowContainerLookPoint()
		{
			return default(Vector3);
		}

		protected virtual AvatarEquippable GetActionEquippable()
		{
			return null;
		}

		protected virtual TrashItem GetTrashPrefab(ItemInstance usedItem)
		{
			return null;
		}

		protected abstract void OnActionSuccess(ItemInstance usedItem);

		protected abstract string GetAnimationBool();

		protected abstract float GetActionDuration();

		private void WalkTo(ITransitEntity entity)
		{
		}

		private void GrabRequiredItemFromSupplies()
		{
		}

		private void PerformAction()
		{
		}

		protected virtual bool CheckSuccess(ItemInstance usedItem)
		{
			return false;
		}

		private void StopAllRoutines()
		{
		}

		protected virtual string[] GetRequiredItemSuitableIDs(GrowContainer growContainer)
		{
			return null;
		}

		private bool DoesTaskRequireItem(GrowContainer growContainer, out string[] suitableItemIDs)
		{
			suitableItemIDs = null;
			return false;
		}

		private bool IsRequiredItemInInventory(GrowContainer growContainer)
		{
			return false;
		}

		private bool DoSuppliesContainRequiredItem(GrowContainer growContainer)
		{
			return false;
		}

		private ItemSlot GetSuppliesSlotContainingRequiredItem(string[] suitableItemIDs)
		{
			return null;
		}

		protected ItemSlot GetItemSlotContainingRequiredItem(IItemSlotOwner itemSlotOwner, string[] suitableItemIDs)
		{
			return null;
		}

		private bool IsAtSupplies()
		{
			return false;
		}

		private bool IsAtGrowContainer()
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

		protected virtual void Awake_UserLogic_ScheduleOne_002ENPCs_002EBehaviour_002EGrowContainerBehaviour_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
