using System.Collections;
using CTS.BBT.AI;
using CTS.Core;

namespace CTS.BBT
{
	internal sealed class WorkerChoreClean : WorkerChore
	{
		private readonly CleanableObject _cleanableObject;

		public WorkerChoreClean(ChoreCategory p_category, CleanableObject p_cleanableObject)
			: base(p_category, p_cleanableObject.RoomObject)
		{
			_cleanableObject = p_cleanableObject;
		}

		public override string GetDisplayName()
		{
			return ContextualActionDisplayNames.GetAction(EActionName.Clean);
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			if (p_agentRef.ObjectHolding.IsCurrentlyHolding)
			{
				return false;
			}
			return p_agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal>();
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			yield return MoveToActor(_cleanableObject, EInteractionKey.RegularUsage);
		}

		public override IEnumerator ActionRoutine()
		{
			float animMultiplier = base.ActionAgent.GetSpeedMultiplier();
			base.ActionAgent.Animator.Speed = animMultiplier;
			yield return base.ActionAgent.Animator.PlayTimedLoop(_cleanableObject.CleaningAnimation, _cleanableObject.AnimationDuration / animMultiplier);
			base.ActionAgent.Tools.DisableTools();
			yield return Coroutines.WaitForSeconds(0.5f / animMultiplier);
			base.ActionAgent.Tools.DisableTools();
		}

		public override void OnComplete()
		{
			base.OnComplete();
			_cleanableObject.Clean();
		}

		protected override void OnStopped()
		{
			base.ActionAgent.Animator.Speed = 1f;
		}

		protected override void OnDestroy()
		{
		}
	}
}
