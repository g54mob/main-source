using System.Collections.Generic;
using DG.Tweening;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.Data;
using Zenject;

namespace VampireSurvivors
{
	public class AchievementPopup : MonoBehaviour
	{
		[SerializeField]
		private Localize _TitleText;

		[SerializeField]
		private Localize AchievementName;

		[SerializeField]
		private TextMeshProUGUI _AchievementUnlock;

		[SerializeField]
		private Image Icon;

		[SerializeField]
		private Image _Frame;

		[SerializeField]
		private RectTransform AchievementPanel;

		[SerializeField]
		private TextMeshProUGUI PageCount;

		[SerializeField]
		private GameObject _UnlocksCircle;

		[SerializeField]
		private TextMeshProUGUI _UnlockText;

		private List<AchievementData> _achievementsToShow;

		private int _currentAchievementIndex;

		private AchievementManager _achievementManager;

		private DataManager _dataManager;

		private Sequence _showLoop;

		private bool _cancelAfterOneCycle;

		private static Color _defaultBackgroundPanelColor;

		private static Color _adventureBackgroundPanelColor;

		private static string _defaultBackgroundSpriteName;

		private static string _adventureBackgroundSpriteName;

		[Inject]
		private void Construct(AchievementManager achiement, DataManager data)
		{
		}

		private void OnDestroy()
		{
		}

		public void SetAchievements(List<AchievementData> achievements, bool cancelAfterOneCycle = false)
		{
		}

		public void CancelLoop()
		{
		}

		private void StartShowLoop()
		{
		}

		private void SetLocalizedTitleText(bool isAdventure)
		{
		}
	}
}
