using FractureField.Achievements.UI;
using FractureField.Currencies.UI;
using FractureField.Quarry.UI.Tip;
using FractureField.UI;
using UnityEngine;

namespace FractureField
{
	public class CHub : Singleton<CHub>
	{
		[SerializeField]
		private TipController _tipController;

		[SerializeField]
		private AchievementController _achievementController;

		[SerializeField]
		private TopPanelController _topPanelController;

		public static TipController Tips => null;

		public static AchievementController Achievements => null;

		public static TopPanelController TopPanel => null;

		public TextAnimationCanvas TextAnimation { get; private set; }

		protected override void Awake()
		{
		}

		private void Init()
		{
		}
	}
}
