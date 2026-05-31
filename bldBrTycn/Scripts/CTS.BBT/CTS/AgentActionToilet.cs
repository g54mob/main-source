using System;
using System.Collections;
using CTS.AI;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public class AgentActionToilet : AgentAction<Agent>
	{
		private NavMeshObstacle _toiletNavMeshObstacle;

		private LockToggle _lockAndUnlockToggle;

		private MachineSoundsScriptableObject _sfxToiletList;

		private float _executionDuration;

		private float _executionTimeClamped;

		private bool _doAPoop;

		private Vector3 _positionBeforePickup;

		private Coroutine _followRoutine;

		public Toilet Toilet { get; private set; }

		public static event Action<Agent, Toilet> ToiletUsed;

		public static event Action CustomerIn;

		public static event Action CustomerOut;

		public AgentActionToilet(Toilet toilet)
		{
			SetToilet(toilet);
		}

		public void SetToilet(Toilet toilet)
		{
			Toilet = toilet;
			if ((object)Toilet != null)
			{
				_toiletNavMeshObstacle = toilet.NavMeshObstacle;
			}
		}

		public override void OnStart()
		{
			SyncWithFurniture(Toilet);
			base.ActionAgent.FurnitureAssignment.StartUsing(Toilet);
			_lockAndUnlockToggle = new LockToggle(base.ActionAgent.Selection.SelectableObject);
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			if (!Toilet)
			{
				return false;
			}
			if (!agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
			{
				return false;
			}
			if (!Toilet.CanBeUsed(agentRef))
			{
				return false;
			}
			return Toilet.UsageCondition(agentRef);
		}

		public override IEnumerator WaitForRoutine()
		{
			base.ActionAgent.FurnitureAssignment.StartUsing(Toilet);
			yield return MoveToTarget(Toilet.LoadTarget);
		}

		public override IEnumerator ActionRoutine()
		{
			yield return ProcessIn();
			yield return LoadUnload(Toilet.LoadedTarget);
			_positionBeforePickup = base.ActionAgent.transform.position;
			ParentToToilet();
			SyncWithFurniturePlacement(Toilet);
			_doAPoop = true;
			_lockAndUnlockToggle.Lock();
			yield return Process();
			_lockAndUnlockToggle.Unlock();
			_doAPoop = false;
			UnParentFromToilet();
			SyncWithFurniture(Toilet);
			yield return LoadUnload(Toilet.UnloadTarget);
			yield return ProcessOut();
		}

		private void ParentToToilet()
		{
			_followRoutine = base.ActionAgent.StartCoroutine(FollowToilet(Toilet.transform));
		}

		private void UnParentFromToilet()
		{
			if (_followRoutine != null)
			{
				base.ActionAgent.StopCoroutine(_followRoutine);
			}
			AgentActionToilet.CustomerOut?.Invoke();
			_followRoutine = null;
		}

		private IEnumerator FollowToilet(Transform transformToFollow)
		{
			Vector3 localPosition = transformToFollow.InverseTransformPoint(base.ActionAgent.transform.position);
			while (true)
			{
				base.ActionAgent.transform.position = transformToFollow.TransformPoint(localPosition);
				yield return null;
			}
		}

		private IEnumerator ProcessIn()
		{
			_sfxToiletList = Toilet.sfxToiletList;
			_executionDuration = Toilet.ToiletSettingsSO.executionDuration;
			AgentActionToilet.CustomerIn?.Invoke();
			yield break;
		}

		private IEnumerator Process()
		{
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.SitDownWC);
			if (base.ActionAgent.HasDeepVoice)
			{
				Toilet.OnPlaySFXMachine(_sfxToiletList.SoundsList[2]);
			}
			else
			{
				Toilet.OnPlaySFXMachine(_sfxToiletList.SoundsList[3]);
			}
			base.ActionAgent.Statistics.TryGetStatisticValue(EAgentStatistics.Bladder, out var statisticValue);
			_executionTimeClamped = _executionDuration * Mathf.Clamp01(statisticValue);
			_executionTimeClamped = ((_executionTimeClamped < _executionDuration) ? _executionDuration : _executionTimeClamped);
			yield return Coroutines.WaitForSeconds(_executionTimeClamped);
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.Idle);
			Toilet.OnPlaySFXMachine(_sfxToiletList.SoundsList[4]);
			base.ActionAgent.Statistics.SetStatisticFromUnitInterval(EAgentStatistics.Bladder, 1f);
			AgentActionToilet.ToiletUsed?.Invoke(base.ActionAgent, Toilet);
		}

		private IEnumerator ProcessOut()
		{
			base.ActionAgent.Animator.ReturnToIdle();
			if (base.ActionAgent.TryGetComponent<SituationnalBarks_CustomerHuman>(out var component))
			{
				component.GoOuttoilet();
			}
			base.ActionAgent.Statistics.TryGetStatisticValue(EAgentStatistics.ToiletDirtiness, out var statisticValue);
			Toilet.DirtinessUpdate(statisticValue);
			yield break;
		}

		private IEnumerator LoadUnload(MoveTarget target)
		{
			_toiletNavMeshObstacle.enabled = false;
			yield return Toilet.OpenDoorTween();
			yield return MoveToTarget(target);
			yield return Toilet.CloseDoorTween();
			_toiletNavMeshObstacle.enabled = true;
		}

		public override void OnCancel()
		{
			if (_lockAndUnlockToggle.Locked)
			{
				_lockAndUnlockToggle.Unlock();
			}
			if (!_doAPoop)
			{
				if (Toilet.IsOpened)
				{
					Toilet.CloseDoorTween();
				}
				if (!_toiletNavMeshObstacle.enabled)
				{
					_toiletNavMeshObstacle.enabled = true;
				}
			}
			else
			{
				base.ActionAgent.Animator.PlayPunctual(AgentAnim.Idle);
				base.ActionAgent.transform.position = _positionBeforePickup;
			}
			AgentActionToilet.CustomerOut?.Invoke();
		}

		protected override void OnStopped()
		{
			UnParentFromToilet();
			StopFurnitureSyncing();
			base.ActionAgent.FurnitureAssignment.StopUsing();
		}
	}
}
