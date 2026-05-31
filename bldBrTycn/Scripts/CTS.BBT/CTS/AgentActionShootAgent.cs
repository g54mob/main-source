using System;
using System.Collections;
using CTS.AI;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class AgentActionShootAgent : AgentAction<Agent>
	{
		private PooledRef<Agent> _target;

		private MoveTarget _moveTarget;

		private float _shootDistance;

		private Crossbow _crossbow;

		private bool _didShoot;

		public Agent Target
		{
			get
			{
				if (!_target.TryGetValue(out var outValue))
				{
					return null;
				}
				return outValue;
			}
			set
			{
				_target = new PooledRef<Agent>(value);
			}
		}

		public static event Action<Agent> TargetSurvived;

		public static event Action<Agent> TargetGotKilled;

		public static event Action<Agent> HunterShoot;

		public static event Action<Agent> HunterReload;

		public static event Action<Agent> HunterDraw;

		public static event Action<Agent> HunterSheathe;

		public AgentActionShootAgent(Agent target, float shootDistance = 6f)
		{
			Target = target;
			_shootDistance = shootDistance;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			Agent target = Target;
			if (target == null)
			{
				return false;
			}
			if (!target.Tags.HasTag(EAgentTag.IsInside))
			{
				return false;
			}
			if (!base.IsPlaying && target.HasTag(BBTAgentTags.HunterTarget))
			{
				return false;
			}
			if (target.IsDead)
			{
				return false;
			}
			if (agentRef.ObjectHolding.IsCurrentlyHolding)
			{
				return false;
			}
			if (!agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal, ContextualStatePanicking>())
			{
				return false;
			}
			if (!target.IsVisible)
			{
				return false;
			}
			return true;
		}

		public override void OnStart()
		{
			if (!Target.ContextActorData.TryGetInteractionTarget(EInteractionKey.PickUp, base.ActionAgent.transform.position, out _moveTarget))
			{
				CancelAction("couldn't get pickup point on human", playBlockedAction: true);
			}
			else if (Target.HasTag(BBTAgentTags.HunterTarget))
			{
				CancelAction("");
			}
			else
			{
				Target.AddTag(BBTAgentTags.HunterTarget);
			}
		}

		public override IEnumerator WaitForRoutine()
		{
			yield return MoveToLookAt(_moveTarget.transform, 0.2f, _shootDistance, 0.5f, AgentsMover.AllAreas);
		}

		public override IEnumerator ActionRoutine()
		{
			_crossbow = base.ActionAgent.GetComponentInChildren<Crossbow>(includeInactive: true);
			SyncWithAgent(Target);
			yield return Draw(_crossbow);
			_didShoot = false;
			yield return Shoot(_crossbow);
			if (_didShoot)
			{
				yield return Reload(_crossbow);
			}
			yield return Sheathe(_crossbow);
		}

		private IEnumerator Draw(Crossbow crossbow)
		{
			bool didDraw = false;
			AnimationTracker drawAnim = base.ActionAgent.Animator.PlayPunctual(AgentAnim.CrossbowDraw);
			AgentActionShootAgent.HunterDraw?.Invoke(base.ActionAgent);
			while (drawAnim.keepWaiting)
			{
				if (drawAnim.GetNormalizedTime > 0.5f)
				{
					DoDraw();
				}
				yield return null;
			}
			DoDraw();
			void DoDraw()
			{
				if (!didDraw)
				{
					didDraw = true;
					crossbow.SetInHands();
				}
			}
		}

		private IEnumerator Shoot(Crossbow crossbow)
		{
			AnimationTracker shootAnim = base.ActionAgent.Animator.PlayPunctual(AgentAnim.CrossbowShoot);
			bool didShoot = false;
			bool didSendProjectile = false;
			while (shootAnim.keepWaiting)
			{
				yield return null;
				if (shootAnim.GetNormalizedTime > 0.5f && !DoShoot())
				{
					yield break;
				}
				if (shootAnim.GetNormalizedTime > 0.55f)
				{
					DoSendProjectile();
				}
				if (!didSendProjectile)
				{
					Vector3 vector = Target.transform.position - base.ActionAgent.transform.position;
					base.ActionAgent.Movement.FaceDirection(Quaternion.LookRotation(vector.normalized, Vector3.up));
				}
			}
			if (DoShoot())
			{
				DoSendProjectile();
			}
			void DoSendProjectile()
			{
				if (!didSendProjectile)
				{
					didSendProjectile = true;
					_didShoot = true;
					AgentActionShootAgent.HunterShoot?.Invoke(base.ActionAgent);
					Target.SkeletonData.TryGetBone(EBone.UpperSpine, out var boneTransform);
					StopAgentSyncing();
					base.ActionAgent.Cooldowns.StartCooldown(BBTAgentTags.ShotSomeone);
					if (Target.Statistics.TryGetStatisticUnitInterval(EAgentStatistics.HunterBaseHitChance, out var statisticValue))
					{
						float value = UnityEngine.Random.value;
						if (Target.Statistics.TryGetStatisticUnitInterval(EAgentStatistics.HunterLevelHitChanceDecrease, out var statisticValue2) && Target is Worker worker)
						{
							statisticValue -= statisticValue2 * (float)(worker.Level.CurrentLevel - 1);
							if (worker.PowerFeatures.HavePower(WorkerPowerFeature.e_PowerFeatures.Reaper) && worker.Statistics.TryGetStatisticValue(EAgentStatistics.HunterReaperHitChanceMultiplier, out var statisticValue3))
							{
								statisticValue *= statisticValue3;
							}
						}
						if (value > statisticValue)
						{
							crossbow.MissTarget(boneTransform);
							AgentActionShootAgent.TargetSurvived?.Invoke(Target);
							return;
						}
					}
					Target.ActionPlayer.ForceStopAll();
					Target.Health.ForceDeath();
					crossbow.ShootTarget(boneTransform);
					AgentActionShootAgent.TargetGotKilled?.Invoke(Target);
				}
			}
			bool DoShoot()
			{
				if (didShoot)
				{
					return true;
				}
				didShoot = true;
				if (AgentsMover.IsLineValidOnStaticWorld(base.ActionAgent.transform.position, Target.transform.position))
				{
					crossbow.Shoot();
					return true;
				}
				return false;
			}
		}

		private IEnumerator Reload(Crossbow crossbow)
		{
			AnimationTracker anim = base.ActionAgent.Animator.PlayPunctual(AgentAnim.CrossbowReload);
			bool didReload = false;
			AgentActionShootAgent.HunterReload?.Invoke(base.ActionAgent);
			while (anim.keepWaiting)
			{
				if (anim.GetNormalizedTime > 0.2f)
				{
					DoReload();
				}
				yield return null;
			}
			DoReload();
			void DoReload()
			{
				if (!didReload)
				{
					didReload = true;
					crossbow.Reload();
				}
			}
		}

		private IEnumerator Sheathe(Crossbow crossbow)
		{
			bool didSheathe = false;
			AnimationTracker drawAnim = base.ActionAgent.Animator.PlayPunctual(AgentAnim.CrossbowSheathe);
			AgentActionShootAgent.HunterSheathe?.Invoke(base.ActionAgent);
			while (drawAnim.keepWaiting)
			{
				if (drawAnim.GetNormalizedTime > 0.75f)
				{
					DoSheathe();
				}
				yield return null;
			}
			DoSheathe();
			void DoSheathe()
			{
				if (!didSheathe)
				{
					didSheathe = true;
					crossbow.SetAtRest();
				}
			}
		}

		protected internal override void OnRemovedFromQueue()
		{
			base.OnRemovedFromQueue();
			Target?.RemoveTag(BBTAgentTags.HunterTarget);
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
			if ((bool)_crossbow)
			{
				_crossbow.SetAtRest();
			}
		}
	}
}
