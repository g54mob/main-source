using System;
using System.Collections.Generic;
using DG.Tweening;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Observables;
using Loxodon.Framework.Views;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.HUD
{
	public class ToolInfoView : UIView
	{
		[SerializeField]
		private List<ToolSpriteType> _toolSprites;

		[SerializeField]
		private Image _toolImage;

		[SerializeField]
		private TextMeshProUGUI _toolText;

		[SerializeField]
		private Image _progressMask;

		[SerializeField]
		private Gradient _gradient;

		[SerializeField]
		private Image _progressImage;

		[SerializeField]
		private GameObject _holderObject;

		[SerializeField]
		private Ease _progressEase;

		[SerializeField]
		private float _progressTime = 0.5f;

		[SerializeField]
		private RectTransform _upArrow;

		[SerializeField]
		private RectTransform _downArrow;

		private float _maxSize;

		private float _oldValue;

		private ObservableProperty<float> _progress = new ObservableProperty<float>();

		private Ease _punchEase;

		private float _punchPower = 0.2f;

		private float _punchDuration = 0.2f;

		private int _punchVibrato = 2;

		private float _punchRotation = 12f;

		private Tweener _progressTweener;

		private Tween _upTween;

		private Tween _downTween;

		private Vector3 _defaultScale = Vector3.one;

		private float _jumpHeight = 20f;

		private float _duration = 0.25f;

		[Inject]
		private IPlayerInputService _inputService;

		public List<ToolSpriteType> ToolSprites => _toolSprites;

		protected override void Awake()
		{
			RectTransform rectTransform = _progressMask.transform.GetChild(0) as RectTransform;
			_maxSize = rectTransform.sizeDelta.x;
			_progressMask.rectTransform.sizeDelta = new Vector2(0f, _progressMask.rectTransform.sizeDelta.y);
			Debug.Log("Max Size " + _maxSize);
		}

		protected override void OnEnable()
		{
			_progress.ValueChanged += ProgressValueChanged;
			_inputService.OnRotate += TryAnimateValue;
		}

		protected override void OnDisable()
		{
			_progress.ValueChanged -= ProgressValueChanged;
			_inputService.OnRotate -= TryAnimateValue;
		}

		protected override void Start()
		{
			ToolInfoViewModel service = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetService<ToolInfoViewModel>();
			this.SetDataContext(service);
			BindingSet<ToolInfoView, ToolInfoViewModel> bindingSet = this.CreateBindingSet<ToolInfoView, ToolInfoViewModel>();
			bindingSet.Bind(_toolImage).For((Image v) => v.sprite).To((ToolInfoViewModel vm) => vm.CurrentToolSprite)
				.OneWay();
			bindingSet.Bind(_toolText).For((TextMeshProUGUI v) => v.text).To((ToolInfoViewModel vm) => vm.ToolText)
				.OneWay();
			bindingSet.Bind(base.gameObject).For((GameObject v) => v.activeSelf).To((ToolInfoViewModel vm) => vm.Active)
				.OneWay();
			bindingSet.Bind(this).For((ToolInfoView v) => v._progress).To((ToolInfoViewModel vm) => vm.Progress)
				.OneWay();
			bindingSet.Build();
		}

		private void TryAnimateValue(float value)
		{
			if (value > 0f)
			{
				AnimateUpArrow();
			}
			else if (value < 0f)
			{
				AnimateDownArrow();
			}
		}

		private void AnimateUpArrow()
		{
			_downTween?.Kill();
			_upTween?.Kill();
			_upArrow.localScale = _defaultScale;
			_upArrow.anchoredPosition = Vector2.zero;
			_upTween = DOTween.Sequence().Append(_upArrow.DOScale(new Vector3(0.9f, 1.1f, 1f), _duration * 0.3f).SetEase(Ease.OutQuad)).Append(_upArrow.DOAnchorPosY(_jumpHeight, _duration).SetEase(Ease.OutQuad))
				.Append(_upArrow.DOAnchorPosY(0f, _duration).SetEase(Ease.InQuad))
				.Append(_upArrow.DOScale(_defaultScale, _duration * 0.3f).SetEase(Ease.OutQuad));
		}

		private void AnimateDownArrow()
		{
			_upTween?.Kill();
			_downTween?.Kill();
			_downArrow.localScale = _defaultScale;
			_downArrow.anchoredPosition = Vector2.zero;
			_downTween = DOTween.Sequence().Append(_downArrow.DOScale(new Vector3(1.1f, 0.9f, 1f), _duration * 0.3f).SetEase(Ease.OutQuad)).Append(_downArrow.DOAnchorPosY(0f - _jumpHeight, _duration).SetEase(Ease.OutQuad))
				.Append(_downArrow.DOAnchorPosY(0f, _duration).SetEase(Ease.InQuad))
				.Append(_downArrow.DOScale(_defaultScale, _duration * 0.3f).SetEase(Ease.OutQuad));
		}

		private void ProgressValueChanged(object sender, EventArgs e)
		{
			AnimateProgress();
		}

		private void JumpBar()
		{
			base.transform.DOComplete();
			base.transform.DOPunchScale(Vector3.one * _punchPower, _punchDuration, _punchVibrato).SetEase(_punchEase);
			base.transform.DOPunchRotation(Vector3.forward * UnityEngine.Random.Range(0f - _punchRotation, _punchRotation), _punchDuration, _punchVibrato).SetEase(_punchEase);
		}

		private void AnimateProgress()
		{
			_ = _progressMask.rectTransform.sizeDelta;
			float x = _progress.Value * _maxSize;
			_progressMask.rectTransform.DOKill();
			_progressImage.DOKill();
			_progressMask.rectTransform.DOSizeDelta(new Vector2(x, _progressMask.rectTransform.sizeDelta.y), _progressTime).SetEase(_progressEase);
			_progressImage.DOColor(_gradient.Evaluate(_progress.Value), _progressTime).SetEase(_progressEase);
		}
	}
}
