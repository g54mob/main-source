using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.Data;

namespace VampireSurvivors.UI
{
	public class AchievementDataUI : SelectableUI
	{
		[SerializeField]
		private Image Icon;

		[SerializeField]
		private Image Tick;

		[SerializeField]
		private TextMeshProUGUI Label;

		[SerializeField]
		private GameObject Moneybag;

		[SerializeField]
		private GameObject _Frame;

		[SerializeField]
		private Localize localizer;

		private AchievementsPage _page;

		private AchievementData _data;

		private DataManager _dataManager;

		private bool _isAdventureAchievement;

		private AchievementType _type;

		private AdventureAchievementType _adventureType;

		private bool _hasAchieved;

		public void SetData(AdventureAchievementType type, AchievementData bad, AchievementsPage page, DataManager dataManager, bool hasCompleted)
		{
		}

		public void SetData(AchievementType type, AchievementData bad, AchievementsPage page, DataManager dataManager, bool hasCompleted)
		{
		}

		private void Init(AchievementData achievementData, AchievementsPage page, DataManager dataManager, bool hasCompleted)
		{
		}

		protected override void OnSelected()
		{
		}

		private void SetSprite()
		{
		}

		public bool IsCompleted()
		{
			return false;
		}

		private Sprite GetSpriteForAchievement(AchievementData bad)
		{
			return null;
		}
	}
}
