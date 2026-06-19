using System;
using System.Collections.Generic;
using Coffee.UIEffects;
using DG.Tweening;
using JSAM;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Observables;
using Loxodon.Framework.Views;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace UI.Craft
{
	public class CraftItemView : UIView, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public class Factory : PlaceholderFactory<CraftItemView>, ICraftItemFactory, IFactory<CraftItemView>, IFactory
		{
		}

		[SerializeField]
		private Image _image;

		[SerializeField]
		private Image _itemImage;

		[SerializeField]
		private RectTransform _background;

		[SerializeField]
		private Button _button;

		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private CraftProgressIndicatorView _progressIndicatorPrefab;

		[SerializeField]
		private Transform _progressParent;

		[SerializeField]
		private CanvasGroup _readyIndicator;

		[SerializeField]
		private Image _readyTick;

		[SerializeField]
		private Sprite _defaultSprite;

		private Sequence _openSequence;

		private Tweener _backgroundTweener;

		[SerializeField]
		private UIEffect _uiEffect;

		[SerializeField]
		private float _defaultSize = 210f;

		[SerializeField]
		private float _shrinkValue = 15f;

		[SerializeField]
		private float _shrinkDuration = 0.15f;

		[SerializeField]
		private Ease _shrinkEase;

		[SerializeField]
		private float _upscaleValue = 15f;

		[SerializeField]
		private float _upscaleDuration = 0.2f;

		[SerializeField]
		private Ease _upscaleEase;

		[SerializeField]
		private float _targetScaleDuration = 0.2f;

		[SerializeField]
		private Ease _targetSacaleEase;

		[SerializeField]
		private float _upAmmount = 15f;

		[SerializeField]
		private float _upTime = 0.2f;

		[SerializeField]
		private Ease _upEase;

		[SerializeField]
		private Ease _downEase;

		[SerializeField]
		private float _downTime = 0.25f;

		[SerializeField]
		private Canvas _canvas;

		[SerializeField]
		private float _canCraftPreLoadValue = 15f;

		[SerializeField]
		private float _canCraftPreLoadTime = 0.15f;

		[SerializeField]
		private Ease _preLoadEase;

		[SerializeField]
		private float _canCraftUpValue = 25f;

		[SerializeField]
		private float _canCraftUpTime = 0.2f;

		[SerializeField]
		private Ease _canCraftUpEase;

		[SerializeField]
		private float _craftShrinkValue = 0.75f;

		private Vector2 _backgroudnDefaultAnchoredPos;

		private ObservableProperty<bool> _canCraft = new ObservableProperty<bool>();

		private ObservableProperty<int> _currentPartsAmount = new ObservableProperty<int>();

		private ObservableProperty<int> _currentBasePartsAmount = new ObservableProperty<int>();

		private Sequence _canCraftSequence;

		private Tween _shakeTween;

		private int _totalBasePartsNumber;

		private List<CraftProgressIndicatorViewModel> _progressIndicators = new List<CraftProgressIndicatorViewModel>();

		public void CreateBinding()
		{
			BindingSet<CraftItemView, CraftItemViewModel> bindingSet = this.CreateBindingSet<CraftItemView, CraftItemViewModel>();
			bindingSet.Bind(_button).For((Button v) => v.onClick).To((CraftItemViewModel vm) => vm.CraftCommand)
				.OneWay();
			bindingSet.Bind(_text).For((TextMeshProUGUI v) => v.text).To((CraftItemViewModel vm) => vm.Name)
				.OneWay();
			bindingSet.Bind(this).For((CraftItemView v) => v._canCraft).To((CraftItemViewModel vm) => vm.CanCraft)
				.OneWay();
			bindingSet.Bind(this).For((CraftItemView v) => v._currentPartsAmount).To((CraftItemViewModel vm) => vm.CurrentPartsAmount)
				.OneWay();
			bindingSet.Bind(this).For((CraftItemView v) => v._currentBasePartsAmount).To((CraftItemViewModel vm) => vm.CurrentBasePartsAmount)
				.OneWay();
			bindingSet.Bind(this).For((CraftItemView v) => v._totalBasePartsNumber).To((CraftItemViewModel vm) => vm.MainPartsAmount)
				.OneWay();
			bindingSet.Bind(_itemImage).For((Image v) => v.sprite).To((CraftItemViewModel vm) => vm.CraftItemImage)
				.OneTime();
			bindingSet.Bind().For((CraftItemView v) => v.OnViewClick).To((CraftItemViewModel vm) => vm.ClickRequest);
			bindingSet.Build();
			SpawnProgressParts();
			_canCraft.ValueChanged += CanCraftValueChanged;
			_currentPartsAmount.ValueChanged += PartsAmountChanged;
			_currentBasePartsAmount.ValueChanged += CurrentBasePartsAmountChanged;
			_button.interactable = false;
			if (_itemImage.sprite == null)
			{
				_itemImage.sprite = _defaultSprite;
			}
		}

		private void CurrentBasePartsAmountChanged(object sender, EventArgs e)
		{
			UpdateProgressIndicators(_currentBasePartsAmount.Value);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
		}

		private void PartsAmountChanged(object sender, EventArgs e)
		{
			_shakeTween?.Complete();
			AudioManager.PlaySound(UILibrarySounds.UIClick);
			_background.DOComplete();
			_shakeTween = _background.DOShakeRotation(0.2f);
		}

		private void UpdateProgressIndicators(int activeCount)
		{
			for (int i = 0; i < _progressIndicators.Count; i++)
			{
				_progressIndicators[i].IndicatorActive.Value = i < activeCount;
			}
		}

		private void CanCraftValueChanged(object sender, EventArgs e)
		{
			if (_canCraft.Value)
			{
				AudioManager.PlaySound(UILibrarySounds.UIRecieptCanBuild);
				CanCraftAnimation();
				EnableUIEffects();
			}
			else
			{
				AudioManager.PlaySound(UILibrarySounds.UIRecieptCantBuild);
				AnimateToDefault();
				DisableUIEffects();
			}
			_button.interactable = _canCraft.Value;
		}

		private void DisableUIEffects()
		{
			_uiEffect.enabled = false;
		}

		private void EnableUIEffects()
		{
			_uiEffect.enabled = true;
		}

		private void CanCraftAnimation()
		{
			_canCraftSequence?.Complete();
			_canCraftSequence = DOTween.Sequence();
			_canCraftSequence.Append(_background.DOAnchorPosY(_backgroudnDefaultAnchoredPos.y - _canCraftPreLoadValue, _canCraftPreLoadTime).SetEase(_preLoadEase));
			_canCraftSequence.Append(_background.DOAnchorPosY(_backgroudnDefaultAnchoredPos.y + _canCraftUpValue, _canCraftUpTime).SetEase(_canCraftUpEase));
			_canCraftSequence.Insert(0f, _background.DOScale(Vector3.one * _craftShrinkValue, _canCraftPreLoadTime).SetEase(_preLoadEase));
			_canCraftSequence.Insert(_canCraftPreLoadTime * 2f, _background.DOScale(Vector3.one, _upTime * 2f).SetEase(_canCraftUpEase));
			_canCraftSequence.OnComplete(delegate
			{
				_readyTick.DOFade(1f, 0.2f);
				_readyIndicator.DOFade(1f, 0.2f);
			});
		}

		protected override void Start()
		{
			AnimateOpenOnStart();
			_backgroudnDefaultAnchoredPos = _background.anchoredPosition;
			AudioManager.PlaySound(UILibrarySounds.UIRecieptAppear);
			_button.interactable = _canCraft.Value;
		}

		private void SpawnProgressParts()
		{
			for (int i = 0; i < (this.GetDataContext() as CraftItemViewModel).MainPartsAmount; i++)
			{
				CraftProgressIndicatorView craftProgressIndicatorView = UnityEngine.Object.Instantiate(_progressIndicatorPrefab, _progressParent);
				CraftProgressIndicatorViewModel craftProgressIndicatorViewModel = new CraftProgressIndicatorViewModel();
				craftProgressIndicatorView.CreateBinding(craftProgressIndicatorViewModel);
				_progressIndicators.Add(craftProgressIndicatorViewModel);
			}
		}

		protected override void OnDisable()
		{
			AudioManager.PlaySound(UILibrarySounds.UIRecieptDisappear);
		}

		private void AnimateOpenOnStart()
		{
			_openSequence?.Complete();
			_openSequence = DOTween.Sequence();
			RectTransform.sizeDelta = new Vector2(0f, RectTransform.sizeDelta.y);
			Vector2 sizeDelta = RectTransform.sizeDelta;
			Vector2 vector = new Vector2(_defaultSize, RectTransform.sizeDelta.y);
			_openSequence.Append(RectTransform.DOSizeDelta(sizeDelta - new Vector2(_shrinkValue, 0f), _shrinkDuration).SetEase(_shrinkEase));
			_openSequence.Append(RectTransform.DOSizeDelta(vector + new Vector2(_upscaleValue, 0f), _upscaleDuration).SetEase(_upscaleEase));
			_openSequence.Append(RectTransform.DOSizeDelta(vector, _targetScaleDuration).SetEase(_targetSacaleEase));
		}

		private void OnViewClick(object sender, InteractionEventArgs args)
		{
			AudioManager.PlaySound(UILibrarySounds.UIClick);
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			if (!_canCraft.Value)
			{
				AudioManager.PlaySound(InteractionLibrarySounds.CrateItemJump);
				AnimateUp();
			}
			_canvas.overrideSorting = true;
			_canvas.sortingOrder = 1;
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			if (!_canCraft.Value)
			{
				AnimateToDefault();
			}
			_canvas.overrideSorting = false;
		}

		private void AnimateUp()
		{
			_backgroundTweener?.Kill();
			_backgroundTweener = _background.DOAnchorPosY(_backgroudnDefaultAnchoredPos.y + _upAmmount, _upTime).SetEase(_upEase);
		}

		private void AnimateToDefault()
		{
			_backgroundTweener?.Kill();
			_backgroundTweener = _background.DOAnchorPosY(_backgroudnDefaultAnchoredPos.y, _downTime).SetEase(_downEase);
			_backgroundTweener.OnComplete(delegate
			{
				_readyTick.DOFade(0f, 0.2f);
				_readyIndicator.DOFade(0f, 0.2f);
			});
		}
	}
}
