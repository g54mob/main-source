using System;
using System.Collections;
using Animancer;
using CTS.AI;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public class AgentActionReaperDash : AgentAction<Agent>
	{
		private PooledRef<Customer> _targetPooledRef;

		private readonly LockToggle _customerBusyToggle = new LockToggle();

		private static readonly StringKey _dashCooldown = "CD_ReaperDash";

		private static readonly Resource<VFXData> _reaperVFX = "Scriptables/VFX/VFX_ReaperEyes";

		private static readonly Resource<VFXData> _reaperSlashVFX = "Scriptables/VFX/VFX_ReaperSlash";

		private static Addressable<PrestigeUIStatsSO> _investigatorKilledStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/InvestigatorsKilled.asset");

		private static Addressable<PrestigeUIStatsSO> _hunterKilledStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/HunterKilled.asset");

		private bool _setStateStuck;

		private bool _wasPanicking;

		public Customer Target
		{
			get
			{
				if (!_targetPooledRef.TryGetValue(out var outValue))
				{
					return null;
				}
				return outValue;
			}
			set
			{
				_targetPooledRef = new PooledRef<Customer>(value);
			}
		}

		public static event Action<Agent, Agent> ReaperDashKill;

		public static event Action<Agent> ReaperDashSound;

		public override bool CanBePerformed(Agent agentRef)
		{
			Customer target = Target;
			if (target == null)
			{
				return false;
			}
			if (!ActionHubKillHostile.IsTargetValid(target))
			{
				return false;
			}
			if (!agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
			{
				return false;
			}
			return true;
		}

		public override void OnStart()
		{
			_setStateStuck = false;
			SyncWithAgent(Target);
			if (base.ActionAgent.SkeletonData.TryGetBone(EBone.Eyes, out var boneTransform))
			{
				base.ActionAgent.VFXManager.Play(_reaperVFX, boneTransform);
			}
			base.ActionAgent.Movement.AddSpeedModifier("Reaper", 2f);
			_customerBusyToggle.Lock();
			_customerBusyToggle.Clear();
			_customerBusyToggle.Add(Target.Business);
		}

		public override IEnumerator WaitForRoutine()
		{
			PathingTracker movement = MoveToLookAt(Target.transform, 0.2f, 1f);
			while (movement.keepWaiting)
			{
				yield return null;
				AgentPath currentPath = base.ActionAgent.Movement.CurrentPath;
				if (currentPath?.Corners == null)
				{
					continue;
				}
				float num = currentPath.RemainingDistance + Vector3.Distance(base.ActionAgent.transform.position, currentPath.Corners[^1].Position);
				if (num < 8f && num > 3f)
				{
					Vector3 direction = Target.transform.position - base.ActionAgent.transform.position;
					if (!base.ActionAgent.Cooldowns.IsOnCooldown(_dashCooldown) && AgentMovement.IsTransformAtDestinationLookAt(base.ActionAgent.transform, direction, 8f, 0.5f))
					{
						yield break;
					}
				}
				yield return null;
			}
			base.ActionAgent.ActionPlayer.InsertAction(new AgentActionSuckBlood(Target), AgentActionPlayer.EInsertType.CancelAction, Priority);
		}

		public override IEnumerator ActionRoutine()
		{
			base.ActionAgent.Cooldowns.StartCooldown(_dashCooldown);
			Target.ActionPlayer.ForceStopAll();
			_wasPanicking = Target.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>();
			Target.ContextualFSM.SetStateStuck();
			Target.Movement.ResetPath();
			Target.Movement.Velocity = Vector3.zero;
			_setStateStuck = true;
			AnimationTracker jumpAnim = base.ActionAgent.Animator.PlayPunctual(AgentAnim.ReaperDash, FadeMode.FromStart);
			AgentActionReaperDash.ReaperDashSound?.Invoke(base.ActionAgent);
			base.ActionAgent.Selection.Collider.enabled = false;
			Vector3 startPos = base.ActionAgent.transform.position;
			Vector3 endPos = Target.transform.position;
			Vector3 vector = endPos - startPos;
			float magnitude = vector.magnitude;
			magnitude = Math.Max(0.5f, magnitude - 1.5f);
			endPos = startPos + vector.normalized * magnitude;
			Debug.DrawRay(startPos, Vector3.up, Color.blue, 5f);
			while (jumpAnim.keepWaiting)
			{
				float getNormalizedTime = jumpAnim.GetNormalizedTime;
				float t = getNormalizedTime.Remap(0f, 0.5f, 0f, 1f);
				if (NavMesh.SamplePosition(endPos, out var hit, 1f, AgentsMover.AllAreas))
				{
					endPos = hit.position;
				}
				base.ActionAgent.transform.position = Vector3.Lerp(startPos, endPos, t);
				base.ActionAgent.transform.rotation = Quaternion.LookRotation(Vector3.Normalize(endPos - startPos).FlattenY(), Vector3.up);
				if ((double)getNormalizedTime > 0.5 && Target.IsAlive)
				{
					Pooler.Pull(_reaperSlashVFX.Value.Prefab, active: true).transform.SetPositionAndRotation(base.ActionAgent.transform);
					if (Target.IsAlive)
					{
						int vigilanceForKilling = Target.VigilanceMultipliersData.GetVigilanceForKilling(Target);
						MonoSingleton<VigilanceHandlers>.Instance.ChangeVigilanceBy(vigilanceForKilling, Target, EBone.HeadTop);
						if (Target.Skin.SubSpecies == ESubSpecies.Investigateur)
						{
							_investigatorKilledStat.Value.AddToCurrentValue(vigilanceForKilling);
						}
						else if (Target.Skin.SubSpecies == ESubSpecies.Hunter)
						{
							_hunterKilledStat.Value.AddToCurrentValue(vigilanceForKilling);
						}
						Target.Health.ForceDeath();
						AgentActionReaperDash.ReaperDashKill?.Invoke(base.ActionAgent, Target);
					}
					FreeAgents();
				}
				yield return null;
			}
		}

		protected override void OnStopped()
		{
			FreeAgents();
			base.ActionAgent.VFXManager.Kill(_reaperVFX);
		}

		public override void OnCancel()
		{
		}

		protected internal override void OnRemovedFromQueue()
		{
			base.OnRemovedFromQueue();
			FreeAgents();
		}

		private void FreeAgents()
		{
			base.ActionAgent.Movement.RemoveSpeedModifier("Reaper");
			base.ActionAgent.Selection.Collider.enabled = true;
			_customerBusyToggle.Unlock();
			if (_setStateStuck && (bool)Target && Target.ContextualFSM.CurrentStateEquals<ContextualStateStuck>())
			{
				if (_wasPanicking)
				{
					Target.ContextualFSM.SetStatePanicking();
				}
				else
				{
					Target.ContextualFSM.SetStateNormal();
				}
			}
			_setStateStuck = false;
		}
	}
}
