using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class TrophyCaseDialog3DUIView : BaseDialog3DUIView
	{
		[SerializeField]
		private DissolveArea3DUIView _dissolveArea;

		[Header("Buttons")]
		[SerializeField]
		private Button3DUIView _bronzeFilterButton;

		[SerializeField]
		private Button3DUIView _silverFilterButton;

		[SerializeField]
		private Button3DUIView _goldFilterButton;

		[SerializeField]
		private Button3DUIView _commonFilterButton;

		[SerializeField]
		private Button3DUIView _rareFilterButton;

		[SerializeField]
		private Button3DUIView _epicFilterButton;

		[SerializeField]
		private Button3DUIView _legendaryFilterButton;

		[SerializeField]
		private Button3DUIView _achievementsButton;

		[SerializeField]
		private Button3DUIView _cardsButton;

		[SerializeField]
		private Button3DUIView _newCardsButton;

		[SerializeField]
		private BaseInteractable3DUIView _starTokensVisual;

		[SerializeField]
		private CollectibleCardInspector3DUIView _cardInspector;

		[Header("Pages")]
		[SerializeField]
		private GameObject _achievementsPage;

		[SerializeField]
		private GameObject _cardsPage;

		private List<string> _filterKeys;

		[Header("Display Prefabs")]
		[SerializeField]
		private GameObject _achievementTrophyDisplayPrefab;

		[SerializeField]
		private GameObject _cardTrophyDisplayPrefab;

		[Header("Containers")]
		[SerializeField]
		private Container3DUIView _achievementTrophyDisplayContainer;

		[SerializeField]
		private Container3DUIView _cardTrophyDisplayContainer;

		private List<AchievementTrophy3DUIView> _allAchievementTrophyDisplays;

		private List<CollectibleCardTrophy3DUIView> _allCardTrophyDisplays;

		protected override void Awake()
		{
		}

		public void EnableAchievementsPage()
		{
		}

		public void EnableCollectibleCardsPage()
		{
		}

		private void InitTrophyDisplays()
		{
		}

		private void UpdateNewCardsButtonState()
		{
		}

		private void UpdateStarTokenVisual()
		{
		}

		private void UpdateCardTrophys()
		{
		}

		private void UpdateAchievementTrophys()
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		private void SetOnlineFeaturesEnabled(bool isEnabled)
		{
		}

		public override bool IsBackable()
		{
			return false;
		}

		public override void Back()
		{
		}
	}
}
