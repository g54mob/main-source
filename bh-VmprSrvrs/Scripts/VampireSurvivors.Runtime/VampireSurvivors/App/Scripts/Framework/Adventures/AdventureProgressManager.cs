using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.App.Scripts.Framework.Adventures
{
	[UsedImplicitly]
	public class AdventureProgressManager : IInitializable, IDisposable
	{
		[Inject]
		private DataManager _dataManager;

		[Inject]
		private AdventureManager _adventureManager;

		[Inject]
		private PlayerOptions _playerOptions;

		private AchievementManager _achievementManager;

		public Dictionary<AdventureAchievementType, AchievementData> Achieved { get; set; }

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public void RunChecks(CharacterController currentCharacter, AchievementManager achievementManager, Dictionary<AdventureAchievementType, AchievementData> achieved, bool forceUnlockAll = false)
		{
		}

		public void RunProgressDataChecks(CharacterController currentCharacter, AdventureType adventureType, Dictionary<AdventureAchievementType, AchievementData> achieved, bool forceUnlockAll = false)
		{
		}

		public void UnlockAll(Dictionary<AdventureAchievementType, AchievementData> achieved)
		{
		}

		private bool UnlockRequirementsMet(AchievementData achievementData, CharacterController currentCharacter)
		{
			return false;
		}

		private bool checkIfCharacterInPlay(CharacterType requiredCharacterType)
		{
			return false;
		}

		private bool CheckPlayInStage(StageType requiredStage)
		{
			return false;
		}

		private List<EnemyType> GetEnemyTypesIncludingVariants(EnemyType baseRequiredEnemyType)
		{
			return null;
		}

		private void Unlock(AdventureAchievementType adventureAchievementType, AchievementData achievementData, AdventureData adventureData, PlayerOptionsData config)
		{
		}

		private bool HasAlreadyUnlocked(AdventureAchievementType adventureAchievementType, PlayerOptionsData config)
		{
			return false;
		}
	}
}
