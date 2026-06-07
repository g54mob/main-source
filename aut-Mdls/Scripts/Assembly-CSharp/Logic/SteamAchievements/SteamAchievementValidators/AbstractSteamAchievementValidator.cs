using UnityEngine;

namespace Logic.SteamAchievements.SteamAchievementValidators
{
	public abstract class AbstractSteamAchievementValidator : ScriptableObject
	{
		[SerializeField]
		private SteamAchievementConstants.SteamAchievementNames _steamAchievementName;

		public SteamAchievementConstants.SteamAchievementNames SteamAchievementName => _steamAchievementName;

		public virtual void Initialize()
		{
		}

		public virtual void UnInitialize()
		{
		}

		public abstract bool IsSteamAchievementReached();
	}
}
