using System;
using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.BTA
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	[TaskCategory(" TH20/Level Script")]
	public class WaitForChallengeToStart : ExpiringLevelAction
	{
		[SerializeField]
		private SharedInstance_TH20TH20_ChallengeConfig[] _challenges;

		private bool _challengeStarted;

		public override void OnStart()
		{
			base.OnStart();
			if (!HasTaskExpired())
			{
				_challengeStarted = false;
				ObjectiveEvents objectiveEvents = base.Owner.Level.ObjectiveEvents;
				objectiveEvents.OnObjectiveStarted = (Action<Objective>)Delegate.Combine(objectiveEvents.OnObjectiveStarted, new Action<Objective>(OnObjectiveStarted));
			}
		}

		public override void OnEnd()
		{
			ObjectiveEvents objectiveEvents = base.Owner.Level.ObjectiveEvents;
			objectiveEvents.OnObjectiveStarted = (Action<Objective>)Delegate.Remove(objectiveEvents.OnObjectiveStarted, new Action<Objective>(OnObjectiveStarted));
			HasTaskExpired();
			base.OnEnd();
		}

		private void OnObjectiveStarted(Objective objective)
		{
			if (_challenges == null)
			{
				return;
			}
			SharedInstance_TH20TH20_ChallengeConfig[] challenges = _challenges;
			foreach (SharedInstance_TH20TH20_ChallengeConfig sharedInstance_TH20TH20_ChallengeConfig in challenges)
			{
				if (sharedInstance_TH20TH20_ChallengeConfig.NotNull() && sharedInstance_TH20TH20_ChallengeConfig.Instance == objective.Definition)
				{
					_challengeStarted = true;
				}
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			if (!_challengeStarted)
			{
				return TaskStatus.Running;
			}
			return TaskStatus.Success;
		}
	}
}
