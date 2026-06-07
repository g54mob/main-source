using System.Collections.Generic;
using DG.Tweening;
using Gh.Tk.UI;
using Gh.UI;
using UnityEngine;

namespace Gh.Tk
{
	public class UnlockScreenDialog3DUIView : BaseDialog3DUIView
	{
		[SerializeField]
		private Button3DUIView _backButton;

		[SerializeField]
		private Button3DUIView _nextButton;

		[SerializeField]
		private Button3DUIView _fastForwardButton;

		private UnlockCard3DUIView _cardManuallySwitchedTo;

		private Dictionary<UnlockType, List<string>> _unlocksToShow;

		private List<GreenbackRewardData> _rewardsToShow;

		[SerializeField]
		private GameObject _cardPrefab;

		[SerializeField]
		private GameObject _finalCardPrefab;

		private UnlockCard3DUIView _collectUnlocksCard;

		[SerializeField]
		private Container3DUIView _cardContainer;

		private List<UnlockCard3DUIView> _allCards;

		public float cardScale;

		private UnlocksScreenNotificationEvent _unlockScreenNotificationEvent;

		[SerializeField]
		private Transform _giftBoxSocket;

		private GameObject _currentGiftBox;

		public float cardContainerEndPadding;

		private PrefabObjectPool _cardPool;

		[SerializeField]
		private DragScrollDetector _dragScrollDetector;

		[SerializeField]
		private ScrollableUIView _scrollableUIView;

		private float _scrollSpeed;

		public float skipToNextCardDuration;

		private Tween _scrollingTween;

		private bool _isDragAnimEnabled;

		public Ease skipToNextCardEase;

		private Tween _speedUpTween;

		private Tween _slowDownTween;

		public float baseScale;

		public float scaleAtCenter;

		public float showcaseScreenPercentageWidth;

		public float cardSpotlightScreenPercentageWidth;

		public float centerCardPadding;

		public float maxRotationOffset;

		public float spotlightOffsetLocalX;

		public float maxLocalZFromSpotlight;

		private UnlockCard3DUIView _nextOrCurrentCardInSpotlight;

		private UnlockCard3DUIView previousCard;

		[Header("Finish animation")]
		public float finishAnimationDuration;

		private Tween _finishAnimationTween;

		private bool _isFinishingUnlocks;

		protected override void Awake()
		{
		}

		private void ChangeSpotlight(int indexAdjustment)
		{
		}

		public override bool IsBackable()
		{
			return false;
		}

		public override void Back()
		{
		}

		public bool DidUnlockCards()
		{
			return false;
		}

		public void OnUnlocked(UnlockType unlockType, string key)
		{
		}

		public UnlockCard3DUIView CreateCard(BuildableTemplate template, string titleKey, string author)
		{
			return null;
		}

		private UnlockCard3DUIView CreateBaseCase()
		{
			return null;
		}

		public UnlockCard3DUIView CreateCard(CollectibleCardData card, GameObject obj, string titleKey)
		{
			return null;
		}

		public void TryTriggerUnlockScreen()
		{
		}

		public void TryTriggerUnlockScreenForImportedProps()
		{
		}

		public void FireUnlockEventsForStarRating(float starRating, List<string> unseenProps = null)
		{
		}

		public void OpenWithEvent(UnlocksScreenNotificationEvent unlocksScreenNotificationEvent)
		{
		}

		private void CreateUIGift(int tier)
		{
		}

		private void OnGiftBoxAnimEvent(object sender, AnimationEventArgs e)
		{
		}

		private void ShowUnlocks()
		{
		}

		private void HideUnlocks()
		{
		}

		public void OpenWithProps(List<string> templates)
		{
		}

		public void OpenWithUnseenRewards()
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override void Closed()
		{
		}

		private void PopulateCards(Dictionary<UnlockType, List<string>> unlocks)
		{
		}

		private void UpdateCardContainerSize()
		{
		}

		private void PopulateCollectibleCards(IEnumerable<CollectibleCardData> cards)
		{
		}

		private void PopulateBuildableTemplates(IEnumerable<BuildableTemplate> buildableTemplates)
		{
		}

		private void ClearCards()
		{
		}

		private void Update()
		{
		}

		private void UpdateDraggingAnimation()
		{
		}

		private void SpeedUpToCard(GameObject card, float overrideDuration = -1f)
		{
		}

		private void ForceFocusOnCard(GameObject card, float overrideDuration = 1f)
		{
		}

		private void UpdateSizeAndSpacing()
		{
		}

		private void ClearAllTweens()
		{
		}

		private void ClearScrollTweens()
		{
		}

		private void PlayCarouselArrowSFX(int indexAdjustment)
		{
		}

		protected override void OnDisable()
		{
		}

		private void PlayCloseAnimation()
		{
		}
	}
}
