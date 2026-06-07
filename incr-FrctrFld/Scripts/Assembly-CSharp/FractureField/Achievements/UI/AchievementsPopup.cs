using FractureField.UI.Components;
using FractureField.UI.Popups;
using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.Achievements.UI
{
	public class AchievementsPopup : Popup
	{
		[Header("References")]
		[SerializeField]
		private Transform _parent;

		[SerializeField]
		private AchievementItem _pfAchievementItem;

		[SerializeField]
		private RText _completedText;

		[SerializeField]
		private ToggleWithLabel _hideCompletedToggle;

		public AchievementTooltip Tooltip;

		protected override void Awake()
		{
		}

		private void Setup()
		{
		}
	}
}
