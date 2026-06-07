using System.Collections.Generic;
using System.Linq;
using Assets.Packages.SocialPlatforms;
using Assets.Packages.SocialPlatforms.Achievements;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Assets.Scripts.Social.Achievements
{
	internal sealed class AchievementManagerScript : MonoBehaviour
	{
		private static readonly List<IAchievement> EmptyAchievementList = new List<IAchievement>();

		private static bool _disabled;

		private AchievementDatabase _achievementDatabase;

		private List<IAchievement> _achievements;

		public static bool Disabled => _disabled;

		public AchievementDatabase Achievements
		{
			get
			{
				if (_achievementDatabase == null)
				{
					_achievementDatabase = Resources.Load<AchievementDatabase>("Achievements/AchievementDatabase");
				}
				return _achievementDatabase;
			}
		}

		private AchievementManagerScript()
		{
		}

		public static AchievementManagerScript Create(GameObject parent)
		{
			AchievementManagerScript achievementManagerScript = new GameObject("AchievementManager").AddComponent<AchievementManagerScript>();
			achievementManagerScript.transform.SetParent(parent.transform);
			achievementManagerScript.Initialize();
			return achievementManagerScript;
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
			UnityEngine.Social.LoadAchievements(delegate(IAchievement[] x)
			{
				_achievements = new List<IAchievement>(x);
			});
		}

		public void UnlockAchievement(AchievementKey achievement)
		{
			if (!Disabled && IsAchievementEnabled(achievement))
			{
				AchievementInfo achievementInfo = Achievements.FindByKey(achievement);
				if (achievementInfo != null)
				{
					UnityEngine.Social.ReportProgress(achievementInfo.Id, 100.0, null);
				}
			}
		}

		private void Initialize()
		{
			AchievementHelper.Initialize();
		}

		private bool IsAchievementEnabled(AchievementKey achievement)
		{
			if (Game.InLevel)
			{
				switch (achievement)
				{
				case AchievementKey.PhotoLibraryTakePicture:
				case AchievementKey.PaintJob:
				case AchievementKey.CreateFlightProgram:
				case AchievementKey.UseQuickload:
				case AchievementKey.FirstPlannedBurn:
				case AchievementKey.SystemEscapeTrajectory:
				case AchievementKey.WalkOnLuna:
				case AchievementKey.LightThisCandle:
				case AchievementKey.LaunchedCraftZeroMass:
				case AchievementKey.LaunchedCraftManyParts:
				case AchievementKey.LaunchedCraftHeavyLifter:
				case AchievementKey.Icarus:
					return true;
				default:
					return false;
				}
			}
			return true;
		}
	}
}
