using System;
using System.Linq;
using DG.Tweening;
using JSAM;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Views;
using MyBox;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.HUD
{
	public class InfoCursorsView : UIView
	{
		[SerializeField]
		private Canvas _mainCanvas;

		[SerializeField]
		private Image _tickImage;

		[SerializeField]
		private Image _vehicleImage;

		[SerializeField]
		private Image _useImage;

		[SerializeField]
		private TextMeshProUGUI _itemNameText;

		[SerializeField]
		private TextMeshProUGUI _useExtraText;

		[SerializeField]
		private Image _pickupImage;

		[SerializeField]
		private Image _equipImage;

		[SerializeField]
		private Image _toWorldImage;

		[SerializeField]
		private Image _holdImage;

		[SerializeField]
		private Image _dropImage;

		[SerializeField]
		private Image _upImage;

		[SerializeField]
		private Image _downImage;

		[SerializeField]
		private Image _scrollUpImage;

		[SerializeField]
		private Image _scrollDownImage;

		[SerializeField]
		private Image _bgImage;

		private CanvasGroup _bgCanvasGroup;

		[Space(5f)]
		[SerializeField]
		private HorizontalLayoutGroup _horizontalLayoutGroup;

		[SerializeField]
		private float _startSpacing;

		[SerializeField]
		private float _targetSpacing;

		[SerializeField]
		private float _timeToFold;

		[SerializeField]
		private Ease _ease;

		[SerializeField]
		private float _scaleTime;

		[SerializeField]
		private AnimationCurve _scaleCurve;

		[SerializeField]
		private float _punchPower = 1.15f;

		[SerializeField]
		private int _punchVibrato = 2;

		[SerializeField]
		private Vector2 _separatedIconsPos;

		private InfoCursorsViewModel vm;

		private Image _useHintSeparate;

		private TextMeshProUGUI _useSeparatedExtraText;

		private Sequence _sequence;

		private Image[] _icons;

		private int _cachedActiveCount = -1;

		private float _cachedPreferredWidth = -1f;

		protected override void Awake()
		{
			_bgCanvasGroup = _bgImage.GetComponent<CanvasGroup>();
			_icons = new Image[10] { _tickImage, _vehicleImage, _useImage, _pickupImage, _equipImage, _toWorldImage, _holdImage, _dropImage, _upImage, _downImage };
		}

		protected override void Start()
		{
			_sequence = DOTween.Sequence();
			vm = Context.GetApplicationContext().GetService<InfoCursorsViewModel>();
			this.SetDataContext(vm);
			BindingSet<InfoCursorsView, InfoCursorsViewModel> bindingSet = this.CreateBindingSet<InfoCursorsView, InfoCursorsViewModel>();
			bindingSet.Bind(_tickImage.gameObject).For((GameObject v) => v.activeSelf).To((InfoCursorsViewModel vm) => vm.TickEnabled)
				.OneWay();
			bindingSet.Bind(_vehicleImage.gameObject).For((GameObject v) => v.activeSelf).To((InfoCursorsViewModel vm) => vm.VehicleEnterEnabled)
				.OneWay();
			bindingSet.Bind(_useImage.gameObject).For((GameObject v) => v.activeSelf).To((InfoCursorsViewModel vm) => vm.UseEnabled)
				.OneWay();
			bindingSet.Bind(_pickupImage.gameObject).For((GameObject v) => v.activeSelf).To((InfoCursorsViewModel vm) => vm.PickupEnabled)
				.OneWay();
			bindingSet.Bind(_equipImage.gameObject).For((GameObject v) => v.activeSelf).To((InfoCursorsViewModel vm) => vm.EquipEnabled)
				.OneWay();
			bindingSet.Bind(_toWorldImage.gameObject).For((GameObject v) => v.activeSelf).To((InfoCursorsViewModel vm) => vm.ToWorldEnabled)
				.OneWay();
			bindingSet.Bind(_holdImage.gameObject).For((GameObject v) => v.activeSelf).To((InfoCursorsViewModel vm) => vm.HoldEnabled)
				.OneWay();
			bindingSet.Bind(_dropImage.gameObject).For((GameObject v) => v.activeSelf).To((InfoCursorsViewModel vm) => vm.DropEnabled)
				.OneWay();
			bindingSet.Bind(_upImage.gameObject).For((GameObject v) => v.activeSelf).To((InfoCursorsViewModel vm) => vm.UpEnabled)
				.OneWay();
			bindingSet.Bind(_downImage.gameObject).For((GameObject v) => v.activeSelf).To((InfoCursorsViewModel vm) => vm.DownEnabled)
				.OneWay();
			bindingSet.Bind(_scrollUpImage.gameObject).For((GameObject v) => v.activeSelf).To((InfoCursorsViewModel vm) => vm.ScrollUpEnabled)
				.OneWay();
			bindingSet.Bind(_scrollDownImage.gameObject).For((GameObject v) => v.activeSelf).To((InfoCursorsViewModel vm) => vm.ScrollDownEnabled)
				.OneWay();
			bindingSet.Bind(_bgImage.gameObject).For((GameObject v) => v.activeSelf).To((InfoCursorsViewModel vm) => vm.BGEnabled)
				.OneWay();
			bindingSet.Bind(_useExtraText.gameObject).For((GameObject v) => v.activeSelf).To((InfoCursorsViewModel vm) => vm.UseExtraTextEnabled)
				.OneWay();
			bindingSet.Bind(_useExtraText).For((TextMeshProUGUI v) => v.text).To((InfoCursorsViewModel vm) => vm.UseExtraText)
				.OneWay();
			bindingSet.Bind(_itemNameText).For((TextMeshProUGUI v) => v.text).To((InfoCursorsViewModel vm) => vm.ItemName)
				.OneWay();
			bindingSet.Bind().For((InfoCursorsView v) => OnInfoCursorsChanged).To((InfoCursorsViewModel vm) => vm.InfoCursorChangedRequest);
			bindingSet.Bind().For((InfoCursorsView v) => OnUseHintSeperately).To((InfoCursorsViewModel vm) => vm.UseEnableSeparatellyRequest);
			bindingSet.Build();
			vm.Visible.ValueChanged += VisibleValueChanged;
		}

		private void Update()
		{
			AdjustLayout();
		}

		private void AdjustLayout()
		{
			int num = 0;
			for (int i = 0; i < _icons.Length; i++)
			{
				if (_icons[i].gameObject.activeSelf)
				{
					num++;
				}
			}
			if (num == 0)
			{
				return;
			}
			float preferredWidth = _itemNameText.preferredWidth;
			if (num != _cachedActiveCount || !Mathf.Approximately(preferredWidth, _cachedPreferredWidth))
			{
				_cachedActiveCount = num;
				_cachedPreferredWidth = preferredWidth;
				float num2 = preferredWidth + 45f + 45f;
				if (num == 1)
				{
					float num3 = num2 / 2f;
					float num4 = 32.5f;
					int b = Mathf.CeilToInt(num3 - num4);
					b = Mathf.Max(0, b);
					_horizontalLayoutGroup.padding.left = b;
					_horizontalLayoutGroup.padding.right = b;
					_horizontalLayoutGroup.spacing = _targetSpacing;
				}
				else
				{
					_horizontalLayoutGroup.padding.left = 35;
					_horizontalLayoutGroup.padding.right = 35;
					_horizontalLayoutGroup.spacing = _targetSpacing;
				}
			}
		}

		private void VisibleValueChanged(object sender, EventArgs e)
		{
			_bgCanvasGroup.alpha = (vm.Visible.Value ? 1f : 0f);
		}

		private void OnInfoCursorsChanged(object sender, InteractionEventArgs args)
		{
			AudioManager.PlaySound(UILibrarySounds.UIInfoCursorChanged);
			Debug.Log("Info Cursor Changed");
			_sequence.Complete();
			_sequence = DOTween.Sequence();
			_horizontalLayoutGroup.spacing = _startSpacing;
			_bgImage.transform.localScale = Vector3.one;
			_cachedActiveCount = -1;
			_sequence.Insert(0f, _bgImage.transform.DOPunchScale(Vector3.one * _punchPower, _scaleTime, _punchVibrato).SetRelative(isRelative: true).SetEase(_scaleCurve));
			_sequence.Insert(0f, DOTween.To(() => _horizontalLayoutGroup.spacing, delegate(float x)
			{
				_horizontalLayoutGroup.spacing = x;
			}, _targetSpacing, _timeToFold).SetEase(_ease));
		}

		private float CalculateRequiredSpacing()
		{
			int num = 0;
			for (int i = 0; i < _icons.Length; i++)
			{
				if (_icons[i].gameObject.activeSelf)
				{
					num++;
				}
			}
			if (num == 0)
			{
				return _targetSpacing;
			}
			float num2 = (float)num * 65f;
			float num3 = _itemNameText.preferredWidth + 45f + 45f;
			float num4 = num2 + num3;
			float width = ((RectTransform)_horizontalLayoutGroup.transform).rect.width;
			int num5 = num;
			float b = (width - num4) / (float)num5;
			return Mathf.Max(_targetSpacing, b);
		}

		private void OnTickEnabled(object sender, InteractionEventArgs args)
		{
		}

		private void OnUseHintSeperately(object sender, InteractionEventArgs value)
		{
			SeparateHintsArgs separateHintsArgs = (SeparateHintsArgs)value.Context;
			if (_useHintSeparate == null)
			{
				_useHintSeparate = UnityEngine.Object.Instantiate(_useImage, _mainCanvas.transform);
				_useHintSeparate.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
				_useHintSeparate.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
				_useHintSeparate.rectTransform.pivot = new Vector2(0.5f, 0.5f);
				_useHintSeparate.rectTransform.anchoredPosition = _separatedIconsPos;
				TextMeshProUGUI[] componentsInChildren = _useHintSeparate.GetComponentsInChildren<TextMeshProUGUI>(includeInactive: true);
				_useSeparatedExtraText = componentsInChildren.FirstOrDefault((TextMeshProUGUI x) => x.gameObject.name == "Extra Text");
			}
			_useHintSeparate.gameObject.SetActive(separateHintsArgs.Enabled);
			_useSeparatedExtraText.gameObject.SetActive(!separateHintsArgs.AdditionalText.IsNullOrEmpty());
			_useSeparatedExtraText?.SetText(separateHintsArgs.AdditionalText);
		}
	}
}
