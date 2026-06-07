using System.Collections.Generic;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Motorways.Views;
using Server;
using Unity.Profiling;

namespace Motorways.Processes
{
	public class AchievementCheckingProcess : IProcess, IReusable
	{
		[Dependency]
		private Clock _clock;

		[Dependency]
		private IScope _scope;

		[Dependency]
		private AchievementDatabase _achievements;

		[Dependency]
		private City _city;

		[Dependency]
		private CityModel _cityModel;

		[Dependency]
		private ActivePlayer _player;

		[Dependency]
		private ActiveChallengesModel _challenges;

		[Serialize(false, null)]
		private List<MotorwaysAchievementDefinition> _trackedAchievements;

		[Serialize(false, null)]
		private GameContainerScreen _gameContainer;

		private static readonly ProfilerMarker Profiler_Step = new ProfilerMarker(ProfilerUtility.CategoryProcess, "AchievmentCheckingProcess.Step");

		public void Step(ISimulation simulation, Fix64 timestep)
		{
			if (!_city.Rules.RecordsGameStatistics())
			{
				return;
			}
			if (_gameContainer == null)
			{
				_gameContainer = _scope.Get<GameContainerScreen>();
			}
			if (_trackedAchievements == null && _gameContainer != null && _gameContainer.CurrentCityName != null)
			{
				_trackedAchievements = new List<MotorwaysAchievementDefinition>();
				for (int i = 0; i < _achievements.Count; i++)
				{
					MotorwaysAchievementDefinition motorwaysAchievementDefinition = _achievements[i] as MotorwaysAchievementDefinition;
					if (Diagnostics.Verify(motorwaysAchievementDefinition != null, "The achievement {0} isn't a motorways achievement!"))
					{
						bool flag = (motorwaysAchievementDefinition.Scale == AchievementScale.City && motorwaysAchievementDefinition.CityName == _gameContainer.CurrentCityName && (motorwaysAchievementDefinition.ChallengeIndex == _challenges.cityChallengeIndex || motorwaysAchievementDefinition.ChallengeIndex == -1)) || (motorwaysAchievementDefinition.Scale == AchievementScale.City && motorwaysAchievementDefinition.CityName == _gameContainer.CurrentCityName && motorwaysAchievementDefinition.ChallengeIndex == -2 && _challenges.cityChallengeIndex != -1) || motorwaysAchievementDefinition.Scale == AchievementScale.Game;
						flag &= motorwaysAchievementDefinition.DoesGameModeMatch(_cityModel.Mode);
						if (!_challenges.IsCityChallenge && _challenges.HasChallenges && motorwaysAchievementDefinition.Type == AchievementType.Score)
						{
							flag = false;
						}
						if (flag)
						{
							_trackedAchievements.Add(motorwaysAchievementDefinition);
						}
					}
				}
			}
			if (_trackedAchievements != null && _trackedAchievements.Count > 0)
			{
				int index = _clock.FrameCount % _trackedAchievements.Count;
				if (_trackedAchievements[index].IsGameAchievementSatisfied(_gameContainer.GetActiveGame() as MotorwaysGame))
				{
					_player.CompleteAchievement(_trackedAchievements[index], showNotification: true);
					_trackedAchievements.RemoveAt(index);
				}
			}
		}

		public void Reset()
		{
			_trackedAchievements = null;
		}
	}
}
