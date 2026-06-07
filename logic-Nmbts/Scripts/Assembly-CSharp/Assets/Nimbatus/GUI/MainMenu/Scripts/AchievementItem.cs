using Assets.Nimbatus.Scripts.Persistence.Achievements;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class AchievementItem : MonoBehaviour
	{
		public UITexture Image;

		public UILabel TitleLabel;

		public UILabel DescriptionLabel;

		public UILabel RewardLabel;

		private AchievementSetting _achievement;

		public void Init(AchievementSetting achievement, bool unlocked)
		{
			_achievement = achievement;
			if (unlocked)
			{
				Image.mainTexture = achievement.UnlockedIcon;
			}
			else
			{
				Image.mainTexture = achievement.LockedIcon;
			}
			TitleLabel.text = achievement.Name.GetTranslation();
			DescriptionLabel.text = achievement.Description.GetTranslation();
			RewardLabel.text = achievement.RewardText.GetTranslation();
		}
	}
}
