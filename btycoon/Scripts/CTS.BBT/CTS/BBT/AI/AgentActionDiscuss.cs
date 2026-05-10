using System.Collections;
using Animancer;
using CTS.AI;
using CTS.Core;
using CTS.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace CTS.BBT.AI
{
	public class AgentActionDiscuss : AgentAction<Agent>
	{
		private SoftReference<Agent> _otherAgent;

		private bool _initiator;

		private MoveTarget _moveTarget;

		private bool _prepared;

		private bool _canAnswer;

		private bool _answerToSelf;

		private int _talkCount;

		private int? _specificTalkCount;

		private AnimKey _lastAnimation;

		private static readonly NamedLayerMask MoveTargetMask = new NamedLayerMask("InterractionZone", "AgentInterCollision");

		private const int NavMeshArea = 8;

		public Agent OtherAgent
		{
			get
			{
				return _otherAgent;
			}
			set
			{
				_otherAgent = SoftReference.Create(value);
			}
		}

		private AgentActionDiscuss OtherAction { get; set; }

		private bool IsReady { get; set; }

		public AgentActionDiscuss(SoftReference<Agent> agent, bool initiator, int? specificTalkCount = null)
		{
			_otherAgent = agent;
			_initiator = initiator;
			_specificTalkCount = specificTalkCount;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			if (!_otherAgent.Value)
			{
				return false;
			}
			if (agentRef is Customer && !agentRef.Tags.HasTag(EAgentTag.IsInside))
			{
				return false;
			}
			if (!agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
			{
				return false;
			}
			return true;
		}

		private bool TryPrepare()
		{
			if (_initiator)
			{
				return false;
			}
			if (_prepared)
			{
				return false;
			}
			_prepared = true;
			if ((object)base.ActionAgent.FurnitureAssignment.CurrentSeat != null && base.ActionAgent is Customer customer && _otherAgent.Value is Customer customer2 && customer.GroupData == customer2.GroupData)
			{
				return false;
			}
			PlayActionAndResumeThis(new AgentActionPrepareForSyncedAction(_otherAgent.Value));
			return true;
		}

		public override void OnStart()
		{
			Priority = EActionPriority.Default;
			if (TryPrepare())
			{
				return;
			}
			if (!base.ActionAgent.Statistics.HasStatistic(EAgentStatistics.Social))
			{
				int valueOrDefault = _specificTalkCount.GetValueOrDefault();
				if (!_specificTalkCount.HasValue)
				{
					valueOrDefault = 4;
					_specificTalkCount = valueOrDefault;
				}
			}
			Agent agent = _otherAgent.Get();
			if (_initiator && agent.ActionPlayer.ActionQueue.Count > 0)
			{
				if (agent.ActionPlayer.ActionQueue.Count > 1)
				{
					CancelAction("");
					return;
				}
				if (agent.ActionPlayer.ActionQueue.Count == 1 && !agent.ActionPlayer.HasAnyActionOfType<AgentActionDiscuss>())
				{
					CancelAction("");
					return;
				}
			}
			if (!agent.ContextActorData.TryGetInteractionTarget(EInteractionKey.PickUp, base.ActionAgent.transform.position, out _moveTarget))
			{
				CancelAction("couldn't get pick up target of other agent", playBlockedAction: true);
			}
			else if (_initiator && OtherAction == null)
			{
				OtherAction = new AgentActionDiscuss(base.ActionAgent, initiator: false, _specificTalkCount)
				{
					OtherAction = this
				};
				agent.ActionPlayer.ForceAction(OtherAction, EActionPriority.Default);
				AgentAction.LinkCancellation(OtherAction, this);
			}
		}

		private bool OtherAgentHasAction()
		{
			if ((bool)OtherAction.ActionAgent)
			{
				return OtherAction.ActionAgent.ActionPlayer.HasAction(OtherAction);
			}
			return false;
		}

		public override IEnumerator WaitForRoutine()
		{
			Agent otherAgent = _otherAgent.Get();
			float lookDistance = (base.ActionAgent.FurnitureAssignment.CurrentSeat ? 2.5f : 1.8f);
			if (_initiator)
			{
				while (_otherAgent.Value.ActionPlayer.HasAnyActionOfType<AgentActionPrepareForSyncedAction>())
				{
					yield return null;
				}
				if (!base.ActionAgent.Movement.CheckDestinationLookAt(_moveTarget, lookDistance, -0.1f))
				{
					yield return MoveToLookAt(_moveTarget.transform, 0.2f, 1.5f, -0.1f);
				}
			}
			IsReady = true;
			while (!OtherAction.IsReady)
			{
				if (!OtherAgentHasAction())
				{
					CancelAction("");
					yield break;
				}
				yield return null;
			}
			if (!_initiator && !base.ActionAgent.Movement.CheckDestinationLookAt(_moveTarget, lookDistance, -0.1f))
			{
				yield return MoveToLookAt(_moveTarget.transform, 0.2f, 1.5f, -0.1f);
			}
			if (otherAgent.SkeletonData.TryGetBone(EBone.Head, out var headBone))
			{
				base.ActionAgent.ProceduralAnimator.LookAt(headBone);
			}
			if ((bool)OtherAction.ActionAgent && _initiator)
			{
				yield return Talk();
			}
			if (_specificTalkCount.HasValue)
			{
				while (OtherAgentHasAction() && _talkCount < _specificTalkCount)
				{
					if (!_canAnswer)
					{
						yield return CheckSpot(otherAgent);
						continue;
					}
					base.ActionAgent.ProceduralAnimator.LookAt(headBone);
					yield return Talk();
				}
				yield break;
			}
			base.ActionAgent.Statistics.TryGetStatisticUnitInterval(EAgentStatistics.Social, out var socializeValue);
			while (OtherAgentHasAction() && socializeValue < 0.95f)
			{
				if (!_canAnswer)
				{
					yield return CheckSpot(otherAgent);
					continue;
				}
				base.ActionAgent.ProceduralAnimator.LookAt(headBone);
				yield return Talk();
				base.ActionAgent.Statistics.TryGetStatisticUnitInterval(EAgentStatistics.Social, out socializeValue);
			}
			IEnumerator CheckSpot(Agent agent)
			{
				if (!base.ActionAgent.FurnitureAssignment.CurrentSeat)
				{
					base.ActionAgent.Selection.InterCollider.enabled = false;
					if (Physics.CheckSphere(base.ActionAgent.transform.position, 0.2f, MoveTargetMask, QueryTriggerInteraction.Ignore))
					{
						base.ActionAgent.Selection.InterCollider.enabled = true;
						if (NavMesh.SamplePosition(agent.transform.position + agent.transform.forward, out var hit, 1f, 8))
						{
							yield return MoveToPosition(hit.position, 8);
							yield return MoveToLookAt(_moveTarget.transform, 0.2f, 1.5f, 0.5f, 8);
							yield break;
						}
					}
					base.ActionAgent.Selection.InterCollider.enabled = true;
				}
				yield return null;
			}
			IEnumerator Talk()
			{
				_talkCount++;
				OtherAction._canAnswer = false;
				_canAnswer = false;
				AnimationTracker animation = base.ActionAgent.Animator.PlayPunctual(GetAnimationSafe(), FadeMode.FromStart);
				bool startedOther = false;
				while (!animation.IsCompleted)
				{
					if (!startedOther && animation.GetNormalizedTime >= 0.8f)
					{
						startedOther = true;
						OtherAction._canAnswer = true;
					}
					yield return null;
				}
				if (!startedOther)
				{
					OtherAction._canAnswer = true;
				}
				if (base.ActionAgent.Statistics.HasStatistic(EAgentStatistics.Social))
				{
					base.ActionAgent.Statistics.AddToStatistic(EAgentStatistics.Social, 5f);
				}
			}
		}

		private AnimKey GetAnimationSafe()
		{
			AnimKey animation = GetAnimation();
			while ((int)animation == (int)_lastAnimation)
			{
				animation = GetAnimation();
			}
			_lastAnimation = animation;
			OtherAction._lastAnimation = animation;
			return animation;
		}

		private AnimKey GetAnimation()
		{
			return Random.Range(0, 6) switch
			{
				0 => AgentAnim.Talk01, 
				1 => AgentAnim.Talk02, 
				2 => AgentAnim.Talk03, 
				3 => AgentAnim.Talk04, 
				4 => AgentAnim.Talk05, 
				5 => AgentAnim.DistractedTalk01, 
				_ => AgentAnim.Talk01, 
			};
		}

		public override IEnumerator ActionRoutine()
		{
			OtherAction?.CancelAction("");
			yield break;
		}

		protected override void OnStopped()
		{
			base.ActionAgent.ProceduralAnimator.StopLookAt();
		}

		public override void OnCancel()
		{
			base.ActionAgent.Animator.ReturnToIdle();
			OtherAction?.CancelAction("other action got cancelled");
		}
	}
}
