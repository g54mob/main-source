using System;
using System.Collections.Generic;
using System.Linq;
using Jundroo.SocialPlatforms;
using Jundroo.SocialPlatforms.Achievements;
using UnityEngine;

namespace Assets.Scripts.Achievements
{
	internal sealed class AchievementManager : MonoBehaviour
	{
		private static readonly List<IAchievement> EmptyAchievementList = new List<IAchievement>();

		private static bool _disabled;

		private static AchievementManager _instance;

		private AchievementDatabase _achievementDatabase;

		private List<IAchievement> _achievements;

		public static bool Disabled => _disabled;

		public static AchievementManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = UnityEngine.Object.FindFirstObjectByType<AchievementManager>();
					if (_instance == null)
					{
						_instance = new GameObject("AchievementManager").AddComponent<AchievementManager>();
						UnityEngine.Object.DontDestroyOnLoad(_instance.gameObject);
					}
				}
				return _instance;
			}
		}

		public AchievementDatabase Achievements
		{
			get
			{
				if (_achievementDatabase == null)
				{
					_achievementDatabase = Resources.Load<AchievementDatabase>("Achievements/AchievementDatabase");
					bool disabled = _disabled;
					AchievementDatabase achievementDatabase = _achievementDatabase;
					_disabled = disabled | ((object)achievementDatabase == null || !achievementDatabase.AchievementsEnabled);
				}
				return _achievementDatabase;
			}
		}

		private AchievementManager()
		{
		}

		public static void DisableAchievements()
		{
			_disabled = true;
		}

		public IAchievement GetAchievement(AchievementKey achievement)
		{
			AchievementInfo info = Achievements.FindByKey(achievement);
			if (info != null)
			{
				IAchievement achievement2 = (_achievements ?? EmptyAchievementList).FirstOrDefault((IAchievement x) => x.id == info.Id);
				if (achievement2 != null)
				{
					return achievement2;
				}
			}
			return null;
		}

		public AchievementInfo GetAchievementInfo(AchievementKey achievement)
		{
			return Achievements.FindByKey(achievement);
		}

		public bool? HasUnlocked(AchievementKey achievement)
		{
			AchievementInfo info = Achievements.FindByKey(achievement);
			if (info != null)
			{
				IAchievement achievement2 = (_achievements ?? EmptyAchievementList).FirstOrDefault((IAchievement x) => x.id == info.Id);
				if (achievement2 != null)
				{
					return achievement2.completed;
				}
			}
			return null;
		}

		public void IncrementAchievement(AchievementKey achievement, int incrementAmount, bool showProgress)
		{
			if (!Disabled)
			{
				AchievementInfo achievementInfo = Achievements.FindByKey(achievement);
				if (achievementInfo != null)
				{
					SocialExt.Active.IncrementAchievement(achievementInfo.Id, incrementAmount, showProgress, null);
				}
			}
		}

		public void IncrementAchievement(AchievementKey achievement, float incrementAmount, bool showProgress)
		{
			if (!Disabled)
			{
				AchievementInfo achievementInfo = Achievements.FindByKey(achievement);
				if (achievementInfo != null)
				{
					SocialExt.Active.IncrementAchievement(achievementInfo.Id, incrementAmount, showProgress, null);
				}
			}
		}

		public void LoadAchievements()
		{
			try
			{
				SocialExt.LoadAchievements(delegate(IAchievement[] x)
				{
					_achievements = new List<IAchievement>(x);
				});
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		public void UnlockAchievement(AchievementKey achievement)
		{
			if (!Disabled)
			{
				AchievementInfo achievementInfo = Achievements.FindByKey(achievement);
				if (achievementInfo != null)
				{
					SocialExt.ReportProgress(achievementInfo.Id, 100.0, null);
				}
			}
		}
	}
}
