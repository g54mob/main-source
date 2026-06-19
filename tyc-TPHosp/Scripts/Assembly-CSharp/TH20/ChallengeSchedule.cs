using System;
using System.Collections.Generic;

namespace TH20
{
	public class ChallengeSchedule : MustCallDestroy
	{
		private readonly Level _level;

		private Challenge _activeChallenge;

		private readonly ChallengeScheduleDefinition _definition;

		private int _cooldown;

		public bool IsEnabled { get; set; }

		public Challenge ActiveChallenge => _activeChallenge;

		public ChallengeSchedule(Level level, ChallengeScheduleDefinition definition)
		{
			_level = level;
			_definition = definition;
			IsEnabled = definition.IsEnabledOnStart;
			if (definition.StartWithCooldown)
			{
				ResetCooldown();
			}
			ChallengeEvents challengeEvents = _level.ChallengeEvents;
			challengeEvents.OnChallengeCompleted = (Action<Challenge>)Delegate.Combine(challengeEvents.OnChallengeCompleted, new Action<Challenge>(OnChallengeCompleted));
			foreach (ChallengeScheduleDefinition.Item challenge in definition.Challenges)
			{
				if (challenge.Config.Instance is ChallengeWaveObjectivesHordeConfig challengeWaveObjectivesHordeConfig && !challengeWaveObjectivesHordeConfig.ConstructionSequenceName.IsNullOrEmpty())
				{
					RoomItemConstructionSequenceComponent roomItemConstructionSequenceComponent = RoomItemConstructionSequenceComponent.Get(challengeWaveObjectivesHordeConfig.ConstructionSequenceName);
					if (roomItemConstructionSequenceComponent != null && !roomItemConstructionSequenceComponent.HasEverBeenRefreshed())
					{
						roomItemConstructionSequenceComponent.Refresh(0, restoring: false);
					}
				}
			}
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			ChallengeEvents challengeEvents = _level.ChallengeEvents;
			challengeEvents.OnChallengeCompleted = (Action<Challenge>)Delegate.Combine(challengeEvents.OnChallengeCompleted, new Action<Challenge>(OnChallengeCompleted));
		}

		public override void Destroy()
		{
			ChallengeEvents challengeEvents = _level.ChallengeEvents;
			challengeEvents.OnChallengeCompleted = (Action<Challenge>)Delegate.Remove(challengeEvents.OnChallengeCompleted, new Action<Challenge>(OnChallengeCompleted));
			base.Destroy();
		}

		public void Update(float timeDelta)
		{
			if (_activeChallenge != null)
			{
				_activeChallenge.Update(timeDelta);
			}
		}

		private void Play()
		{
			if (_definition.Challenges == null)
			{
				return;
			}
			ResetCooldown();
			List<ChallengeScheduleDefinition.Item> list = new List<ChallengeScheduleDefinition.Item>();
			foreach (ChallengeScheduleDefinition.Item challenge in _definition.Challenges)
			{
				ChallengeConfig instance = challenge.Config.Instance;
				if (instance != null && instance.CheckConditions(_level) && !instance.HasGoalBeenAchieved(_level, _activeChallenge) && SandboxSettings.IsChallengeConfigValid(instance))
				{
					list.Add(challenge);
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			List<float> list2 = new List<float>();
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].Weight > 0)
				{
					list2.Add(list[i].Weight);
				}
			}
			int index = RandomUtils.RandomIndexFromProbabilityMassFunction(list2.ToArray(), RandomUtils.GlobalRandomInstance);
			_activeChallenge = list[index].Config.Instance.CreateChallenge(_level);
			_level.LevelScriptManager.AddObjective(_activeChallenge);
		}

		private void ResetCooldown()
		{
			_cooldown = RandomUtils.GlobalRandomInstance.Next(_definition.MinCooldownInDays, _definition.MaxCooldownInDays);
		}

		public void ResetSchedule()
		{
			if (_definition.StartWithCooldown)
			{
				ResetCooldown();
			}
		}

		public void OnTimelineUpdated()
		{
			if (!IsEnabled || _definition.Deprecated)
			{
				return;
			}
			if (_activeChallenge != null)
			{
				if (SandboxSettings.IsChallengeConfigValid(_activeChallenge.GetConfig<ChallengeConfig>()))
				{
					return;
				}
				_activeChallenge.OnBecameInvalid();
			}
			if (_definition.CheckConditions(_level))
			{
				if (_cooldown > 0)
				{
					_cooldown--;
				}
				else
				{
					Play();
				}
			}
		}

		private void OnChallengeCompleted(Challenge challenge)
		{
			if (_activeChallenge != null && _activeChallenge == challenge)
			{
				_activeChallenge.Destroy();
				_activeChallenge = null;
			}
		}
	}
}
