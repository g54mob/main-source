using System;
using CTS.BBT;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class ContextualActionDisposeCustomerBody : ContextualAction<Customer>
	{
		[SerializeField]
		private bool _allowMorgue;

		private ActionHubDisposeBody _action;

		private ActionHubDisposeBody GetAction()
		{
			return _action ?? (_action = new ActionHubDisposeBody(contextActor, _allowMorgue));
		}

		public override void Setup()
		{
		}

		public override bool CanBeExecutedWithoutWorker()
		{
			return true;
		}

		public override bool ShowAlways()
		{
			return contextActor.IsDead;
		}

		public override bool CanBePerformed(Worker pWorker)
		{
			if (!contextActor.IsDead)
			{
				return false;
			}
			return GetAction().CanBePerformed(pWorker);
		}

		protected override void Execution(Worker p_worker)
		{
			p_worker.ActionPlayer.ForceAction(GetAction(), EActionPriority.Player);
			Setup();
		}
	}
}
