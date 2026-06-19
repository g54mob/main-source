using System;
using System.Collections;
using DG.Tweening;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Observables;
using Loxodon.Framework.Views;
using MyBox;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.HUD.SystemInfo
{
	public class SystemInfoMessageView : UIView
	{
		[SerializeField]
		private TextMeshProUGUI _messageText;

		[SerializeField]
		private Image _messageIcon;

		[SerializeField]
		private Image _progressLine;

		[Header("Animation Settings")]
		[SerializeField]
		private float _slideInDuration = 0.45f;

		[SerializeField]
		private float _slideOutDuration = 0.3f;

		[SerializeField]
		private float _iconBouncePower = 12f;

		[SerializeField]
		private float _iconBounceDuration = 0.5f;

		[SerializeField]
		private float _offscreenOffsetX = -600f;

		private ObservableProperty<float> _progress = new ObservableProperty<float>();

		private float _maxWidth;

		private CanvasGroup _canvasGroup;

		private Vector2 _textOnscreenPos;

		private bool _initialized;

		protected override void Awake()
		{
			_maxWidth = _progressLine.rectTransform.rect.width;
			_canvasGroup = CanvasGroup;
		}

		protected override void Start()
		{
			StartCoroutine(InitAndAnimate());
		}

		private IEnumerator InitAndAnimate()
		{
			yield return null;
			_textOnscreenPos = _messageText.rectTransform.anchoredPosition;
			_messageText.rectTransform.anchoredPosition = new Vector2(_textOnscreenPos.x + _offscreenOffsetX, _textOnscreenPos.y);
			_initialized = true;
			PlayEnterAnimation();
		}

		private void PlayEnterAnimation()
		{
			_messageText.rectTransform.DOAnchorPosX(_textOnscreenPos.x, _slideInDuration).SetEase(Ease.OutCubic);
			_messageIcon.rectTransform.DOPunchPosition(new Vector3(0f, _iconBouncePower, 0f), _iconBounceDuration, 1, 0.4f).SetDelay(0.1f);
		}

		public void CreateBinding()
		{
			BindingSet<SystemInfoMessageView, SystemInfoMessageViewModel> bindingSet = this.CreateBindingSet<SystemInfoMessageView, SystemInfoMessageViewModel>();
			bindingSet.Bind(_messageText).For((TextMeshProUGUI v) => v.text).To((SystemInfoMessageViewModel vm) => vm.MessageText)
				.OneWay();
			bindingSet.Bind(_messageIcon).For((Image v) => v.sprite).To((SystemInfoMessageViewModel vm) => vm.IconSprite)
				.OneWay();
			bindingSet.Bind(this).For((SystemInfoMessageView v) => v._progress).To((SystemInfoMessageViewModel vm) => vm.Progress)
				.OneWay();
			bindingSet.Bind().For((SystemInfoMessageView v) => v.DestroyCurrent).To((SystemInfoMessageViewModel vm) => vm.OnTimeUp);
			bindingSet.Build();
			_progress.ValueChanged += ProgressValueChanged;
		}

		private void DestroyCurrent(object sender, InteractionEventArgs args)
		{
			PlayExitAnimation(delegate
			{
				UnityEngine.Object.Destroy(base.gameObject);
			});
		}

		private void PlayExitAnimation(Action onComplete)
		{
			Sequence sequence = DOTween.Sequence();
			sequence.Join(_messageText.rectTransform.DOAnchorPosX(_textOnscreenPos.x + _offscreenOffsetX, _slideOutDuration).SetEase(Ease.InCubic));
			sequence.Join(_canvasGroup.DOFade(0f, _slideOutDuration).SetEase(Ease.InQuad));
			sequence.OnComplete(delegate
			{
				onComplete?.Invoke();
			});
		}

		private void ProgressValueChanged(object sender, EventArgs e)
		{
			_progressLine.rectTransform.SetWidth(_maxWidth * _progress.Value);
		}

		protected override void OnDestroy()
		{
			DOTween.Kill(_messageText.rectTransform);
			DOTween.Kill(_messageIcon.rectTransform);
			DOTween.Kill(_canvasGroup);
			_progress.ValueChanged -= ProgressValueChanged;
		}
	}
}
