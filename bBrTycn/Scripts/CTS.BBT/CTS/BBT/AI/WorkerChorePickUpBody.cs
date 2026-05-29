using System;
using System.Collections;

namespace CTS.BBT.AI
{
	internal sealed class WorkerChorePickUpBody : WorkerChore
	{
		private AgentActionPickUpBody _pickUpBodyAction;

		public BodyBag CreatedBodyBag => _pickUpBodyAction.CreatedBodyBag;

		public event Action BodyBagCreated
		{
			add
			{
				_pickUpBodyAction.BodyBagCreated += value;
			}
			remove
			{
				_pickUpBodyAction.BodyBagCreated -= value;
			}
		}

		public WorkerChorePickUpBody(ChoreCategory category, Customer body)
			: base(category)
		{
			_pickUpBodyAction = new AgentActionPickUpBody(body);
			base.VisibleInContextualMenu = false;
		}

		public override string GetDisplayName()
		{
			return "Put in Body Bag";
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			return _pickUpBodyAction.CanBePerformed(p_agentRef);
		}

		public override void OnStart()
		{
			_pickUpBodyAction.Status = EStatus.Idle;
			_pickUpBodyAction.SetAgent(base.ActionAgent);
			_pickUpBodyAction.OnStart();
		}

		public override IEnumerator WaitForRoutine()
		{
			_pickUpBodyAction.Status = EStatus.Wait;
			yield return _pickUpBodyAction.WaitForRoutine();
		}

		public override IEnumerator ActionRoutine()
		{
			_pickUpBodyAction.Status = EStatus.InProgress;
			yield return _pickUpBodyAction.ActionRoutine();
		}

		protected override void OnStopped()
		{
			_pickUpBodyAction.OnStoppedInternal();
			_pickUpBodyAction.ClearAgent();
		}

		public override void OnCancel()
		{
			_pickUpBodyAction.Status = EStatus.Idle;
			_pickUpBodyAction.OnCancel();
		}

		public override void OnComplete()
		{
			_pickUpBodyAction.Status = EStatus.Completed;
			base.OnComplete();
		}

		protected override void OnDestroy()
		{
		}
	}
}
