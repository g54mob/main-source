using System;
using CTS.BBT;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class ContextualActionDisposeBody : ContextualAction<BodyBag>
	{
		[SerializeField]
		private bool _allowMorgue;

		private ActionHubDisposeBody _action;

		public override void Setup()
		{
		}

		public override bool CanBeExecutedWithoutWorker()
		{
			return true;
		}

		public override bool ShowAlways()
		{
			return true;
		}

		public override bool CanBePerformed(Worker pWorker)
		{
			GetAction().BodyBag = contextActor;
			return _action.CanBePerformed(pWorker);
		}

		private ActionHubDisposeBody GetAction()
		{
			return _action ?? (_action = new ActionHubDisposeBody(contextActor, _allowMorgue));
		}

		protected override void Execution(Worker p_worker)
		{
			p_worker.ActionPlayer.ForceAction(GetAction(), EActionPriority.Player);
			Setup();
		}
	}
}
