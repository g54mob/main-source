using System;
using System.Collections;
using Animancer;
using CTS.Core;

namespace CTS.BBT.AI
{
	public sealed class WorkerChoreDiscardJunk : WorkerChore
	{
		private readonly JunkObject _junkObject;

		public static event Action<Agent, JunkObject> GoingToDiscardJunk;

		public static event Action<Agent> DiscardingJunk;

		public static event Action<Agent, JunkObject> JunkDiscarded;

		private WorkerChoreDiscardJunk()
			: base(ChoreCategory.Cleaning)
		{
		}

		public WorkerChoreDiscardJunk(JunkObject p_junkObject)
			: base(ChoreCategory.Cleaning, p_junkObject.RoomData)
		{
			_junkObject = p_junkObject;
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			if ((bool)_junkObject.InsideFurniture && _junkObject.InsideFurniture.Interactor.InUse)
			{
				return false;
			}
			if (p_agentRef.ObjectHolding.IsCurrentlyHolding)
			{
				return false;
			}
			return p_agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal>();
		}

		public override string GetDisplayName()
		{
			return _junkObject.Parameters.GetLocalizedString();
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			WorkerChoreDiscardJunk.GoingToDiscardJunk?.Invoke(base.ActionAgent, _junkObject);
			yield return MoveToActor(_junkObject, EInteractionKey.RegularUsage);
		}

		public override IEnumerator ActionRoutine()
		{
			float animMultiplier = base.ActionAgent.GetSpeedMultiplier();
			base.ActionAgent.Animator.Speed = animMultiplier;
			_junkObject.SetAnimationSpeed(animMultiplier);
			if ((bool)_junkObject.InsideFurniture)
			{
				FurnitureInteractor interactor = _junkObject.InsideFurniture.Interactor;
				if (interactor is Toilet toilet)
				{
					yield return toilet.OpenCloseDoor(_junkObject.Parameters.AnimationDuration / animMultiplier);
					toilet.IsDirty = false;
				}
			}
			if (_junkObject.Parameters.DiscardImmediately)
			{
				_junkObject.Discard();
			}
			if (_junkObject.Parameters.IsAnimationLoop)
			{
				yield return base.ActionAgent.Animator.PlayTimedLoop(_junkObject.Parameters.Animation, _junkObject.Parameters.AnimationDuration / animMultiplier);
				base.ActionAgent.Tools.DisableTools();
				yield return Coroutines.WaitForSeconds(0.5f / animMultiplier);
				base.ActionAgent.Tools.DisableTools();
			}
			else
			{
				yield return base.ActionAgent.Animator.PlayPunctual(_junkObject.Parameters.Animation, FadeMode.FromStart);
				base.ActionAgent.Tools.DisableTools();
			}
		}

		public override void OnComplete()
		{
			base.OnComplete();
			if (!_junkObject.Parameters.IsAnimationLoop)
			{
				WorkerChoreDiscardJunk.DiscardingJunk?.Invoke(base.ActionAgent);
			}
			_junkObject.Discard();
			WorkerChoreDiscardJunk.JunkDiscarded?.Invoke(base.ActionAgent, _junkObject);
		}

		protected override void OnStopped()
		{
			base.ActionAgent.Animator.Speed = 1f;
		}

		public override void OnCancel()
		{
			base.OnCancel();
			if (!_junkObject.IsDiscarded)
			{
				_junkObject.SetAnimationSpeed(1f);
			}
		}

		protected override void OnDestroy()
		{
		}
	}
}
