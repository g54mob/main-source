using ScheduleOne.Economy;
using ScheduleOne.Quests;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour
{
	public class DealerAttendDealBehaviour : Behaviour
	{
		private Dealer _dealer;

		private Contract _contract;

		private Customer _customer;

		private Coroutine _handoverRoutine;

		private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EDealerAttendDealBehaviourAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EDealerAttendDealBehaviourAssembly_002DCSharp_002Edll_Excuted;

		public override void Awake()
		{
		}

		public void AssignContract(Contract contract)
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

		public override void OnActiveTick()
		{
		}

		private void BeginHandover()
		{
		}

		private void StopHandover()
		{
		}

		private bool IsAtDestination()
		{
			return false;
		}

		private bool IsCustomerReadyForHandover()
		{
			return false;
		}

		private Vector3 GetStandPosition()
		{
			return default(Vector3);
		}

		private Vector3 GetDirectionToFace()
		{
			return default(Vector3);
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

		protected virtual void Awake_UserLogic_ScheduleOne_002ENPCs_002EBehaviour_002EDealerAttendDealBehaviour_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
