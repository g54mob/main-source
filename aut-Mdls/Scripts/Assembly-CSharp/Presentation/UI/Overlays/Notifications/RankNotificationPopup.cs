using DG.Tweening;
using Data.Notifications;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Overlays.Notifications
{
	public class RankNotificationPopup : NotificationPopup
	{
		[Header("Rank UI")]
		[SerializeField]
		private RankConfigSO _rankConfigSO;

		[SerializeField]
		private Image _emblem;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private TextMeshProUGUI _rewardText;

		[SerializeField]
		private RectTransform _reward;

		[SerializeField]
		private CanvasGroup _rewardTextCG;

		[SerializeField]
		private RectTransform _line;

		protected override void BuildPopup(AbstractNotificationData notificationData)
		{
			RankConfig rankConfig = (notificationData as RankNotificationData).RankConfig;
			_icon.sprite = rankConfig.IconLarge;
			int expansionPermitsRewarded = _rankConfigSO.GetExpansionPermitsRewarded(rankConfig);
			_rewardText.SetText($"+{expansionPermitsRewarded}");
		}

		protected override void AnimateIn()
		{
			base.AnimateIn();
			DOTween.Sequence().AppendInterval(0.3f).Append(_rectTransform.DOScale(Vector3.one, 0.4f).From(Vector3.zero).SetEase(Ease.OutBack, 2f))
				.Insert(0.3f, _gradientLeft.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutSine))
				.Insert(0.3f, _gradientRight.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutSine))
				.Insert(0.6f, _icon.rectTransform.DOScale(Vector3.one, 0.4f).From(Vector3.zero).SetEase(Ease.OutBack, 4f))
				.Insert(0.6f, _reward.DOScale(Vector3.one, 0.4f).From(Vector3.zero).SetEase(Ease.OutBack, 4f))
				.Insert(0.6f, _textCanvasGroup.DOFade(1f, 0.3f).From(0f))
				.Insert(0.6f, _rewardTextCG.DOFade(1f, 0.3f).From(0f))
				.Insert(0.6f, _line.DOScaleX(1f, 0.3f).From(0f).SetEase(Ease.OutBack))
				.OnComplete(base.StartTimer);
		}
	}
}
