using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityConsole;

namespace TH20
{
	public class StaffChallengeManager : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public float MinimumGenerationTimeInSeconds = 180f;

			public float MaximumGenerationTimeInSeconds = 300f;

			public int MaximumActiveStaffChallenges = 10;

			public int MinimumDifficultyRating;

			public int MaximumDifficultyRating = 10;

			public SharedInstance<ChallengeList> Challenges;

			public readonly NotificationMessages.Definition IntroMessage;

			public readonly NotificationMessages.Definition SuccessMessage;

			public readonly NotificationMessages.Definition FailureMessage;
		}

		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class ChallengeList
		{
			public SharedInstance<StaffChallengeDefinition>[] Challenges;
		}

		private readonly Config _config;

		private readonly Level _level;

		private readonly List<Staff> _staff;

		private readonly List<StaffChallengeDefinition> _availableChallenges;

		private readonly Dictionary<StaffChallengeDefinition, float> _coolDownChallenges;

		private float _timeToGenerate;

		public Config Configuration => _config;

		public StaffChallengeManager(Level level, Config config)
		{
			_level = level;
			_config = config;
			_staff = new List<Staff>();
			_availableChallenges = new List<StaffChallengeDefinition>();
			_coolDownChallenges = new Dictionary<StaffChallengeDefinition, float>();
			SharedInstance<StaffChallengeDefinition>[] challenges = _config.Challenges.Instance.Challenges;
			foreach (SharedInstance<StaffChallengeDefinition> sharedInstance in challenges)
			{
				_availableChallenges.Add(sharedInstance.Instance);
			}
			ResetGenerationTime();
			RegisterEvents();
			ConsoleCommandsDatabase.RegisterCommand("CreateStaffChallenge", "Instantly creates a new staff challenge", "CreateStaffChallenge", Debug_CreateChallenge);
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			RegisterEvents();
			ConsoleCommandsDatabase.RegisterCommand("CreateStaffChallenge", "Instantly creates a new staff challenge", "CreateStaffChallenge", Debug_CreateChallenge);
		}

		private void RegisterEvents()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffSpawned = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffSpawned, new Action<Staff>(AddStaff));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnStaffDestroyed = (Action<Staff>)Delegate.Combine(characterEvents2.OnStaffDestroyed, new Action<Staff>(RemoveStaff));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnStaffFired = (Action<Staff>)Delegate.Combine(characterEvents3.OnStaffFired, new Action<Staff>(RemoveStaff));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnStaffResigned = (Action<Staff>)Delegate.Combine(characterEvents4.OnStaffResigned, new Action<Staff>(RemoveStaff));
		}

		public override void Destroy()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("CreateStaffChallenge");
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffSpawned = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffSpawned, new Action<Staff>(AddStaff));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnStaffDestroyed = (Action<Staff>)Delegate.Remove(characterEvents2.OnStaffDestroyed, new Action<Staff>(RemoveStaff));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnStaffFired = (Action<Staff>)Delegate.Remove(characterEvents3.OnStaffFired, new Action<Staff>(RemoveStaff));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnStaffResigned = (Action<Staff>)Delegate.Remove(characterEvents4.OnStaffResigned, new Action<Staff>(RemoveStaff));
			base.Destroy();
		}

		private ConsoleCommandResult Debug_CreateChallenge(string[] args)
		{
			GenerateChallenge();
			return ConsoleCommandResult.Succeeded();
		}

		private void ResetGenerationTime()
		{
			_timeToGenerate = GameTime.time + RandomUtils.GlobalRandomInstance.NextFloat(_config.MinimumGenerationTimeInSeconds, _config.MaximumGenerationTimeInSeconds);
		}

		public void Update()
		{
			_coolDownChallenges.RemoveAll(delegate(KeyValuePair<StaffChallengeDefinition, float> x)
			{
				if (GameTime.time >= x.Value + x.Key.CoolDownTimeSeconds)
				{
					_availableChallenges.Add(x.Key);
					return true;
				}
				return false;
			});
			if (GameTime.time >= _timeToGenerate)
			{
				GenerateChallenge();
				ResetGenerationTime();
			}
		}

		private void GenerateChallenge()
		{
			if (!SandboxSettings.AreStaffChallengesAvailable() || _level.LevelScriptManager.StaffChallenges.Count >= _config.MaximumActiveStaffChallenges || _staff.Count == 0)
			{
				return;
			}
			Staff staff = _staff.RandomItem();
			List<StaffChallengeDefinition> list = new List<StaffChallengeDefinition>();
			foreach (StaffChallengeDefinition availableChallenge in _availableChallenges)
			{
				if (availableChallenge.DifficultyRating >= _config.MinimumDifficultyRating && availableChallenge.DifficultyRating <= _config.MaximumDifficultyRating && availableChallenge.IsSuitable(_level, staff) && !availableChallenge.HasGoalBeenAchieved(_level))
				{
					list.Add(availableChallenge);
				}
			}
			StaffChallengeDefinition staffChallengeDefinition = list.WeightedRandomItem((StaffChallengeDefinition definition) => definition.ChallengeWeight);
			if (staffChallengeDefinition != null)
			{
				OnChallengeStart(staffChallengeDefinition, staff);
			}
		}

		private void AddStaff(Staff staff)
		{
			_staff.Add(staff);
		}

		private void RemoveStaff(Staff staff)
		{
			_staff.Remove(staff);
		}

		private void OnChallengeStart(StaffChallengeDefinition definition, Staff staff)
		{
			_staff.Remove(staff);
			_availableChallenges.Remove(definition);
			StaffChallenge levelObjective = new StaffChallenge(_level, this, definition, staff);
			_level.LevelScriptManager.AddObjective(levelObjective);
		}

		public void OnChallengeFinished(StaffChallenge staffChallenge)
		{
			if (staffChallenge != null && _level.LevelScriptManager.StaffChallenges.Contains(staffChallenge))
			{
				if (_level.CharacterManager.StaffMembers.Contains(staffChallenge.Staff))
				{
					_staff.Add(staffChallenge.Staff);
				}
				if (!_coolDownChallenges.ContainsKey(staffChallenge.Definition))
				{
					_coolDownChallenges.Add(staffChallenge.Definition, GameTime.time);
				}
			}
		}
	}
}
