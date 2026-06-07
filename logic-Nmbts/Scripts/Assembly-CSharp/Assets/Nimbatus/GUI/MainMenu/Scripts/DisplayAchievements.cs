using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.Achievements;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class DisplayAchievements : MonoBehaviour
	{
		public UIGrid Grid;

		public UIScrollView ResultScrollView;

		public AchievementItem UnlockedPrefab;

		public AchievementItem LockedPrefab;

		private string _language;

		public void Start()
		{
			InitAchievements();
		}

		private void InitAchievements()
		{
			_language = LocalizationManager.CurrentLanguageCode;
			Grid.enabled = true;
			Grid.transform.DestroyChildren();
			foreach (AchievementSetting item in BaseSingleton<AchievementManager>.Instance.AchievementSettings.Where((AchievementSetting a) => BaseSingleton<AchievementManager>.Instance.IsAchievementUnlocked(a.AchievementType)))
			{
				AchievementItem achievementItem = Object.Instantiate(UnlockedPrefab);
				achievementItem.Init(item, true);
				achievementItem.transform.position = Grid.transform.position;
				achievementItem.transform.parent = Grid.transform;
				achievementItem.transform.localScale = Grid.transform.localScale;
			}
			foreach (AchievementSetting item2 in BaseSingleton<AchievementManager>.Instance.AchievementSettings.Where((AchievementSetting a) => !BaseSingleton<AchievementManager>.Instance.IsAchievementUnlocked(a.AchievementType)))
			{
				AchievementItem achievementItem2 = Object.Instantiate(LockedPrefab);
				achievementItem2.Init(item2, false);
				achievementItem2.transform.position = Grid.transform.position;
				achievementItem2.transform.parent = Grid.transform;
				achievementItem2.transform.localScale = Grid.transform.localScale;
			}
			ResultScrollView.ResetPosition();
			ResultScrollView.UpdateScrollbars(true);
			Grid.Reposition();
			Grid.repositionNow = true;
		}

		public void Update()
		{
			if (_language != LocalizationManager.CurrentLanguageCode)
			{
				InitAchievements();
			}
		}
	}
}
