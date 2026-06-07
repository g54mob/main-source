using System;
using System.Xml.Linq;
using DG.Tweening;
using Jundroo.Juicy.Widgets.Extra;
using Jundroo.Juicy.Widgets.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets
{
	public class ToggleWidget : Widget, ISelectableWidget
	{
		[SerializeField]
		private Image _background;

		[SerializeField]
		private Image _checkmark;

		private RectTransform _checkRect;

		private float _percentage;

		[SerializeField]
		private Toggle _toggle;

		public ColorProperty BackgroundColor { get; private set; }

		public ColorProperty CheckColor { get; private set; }

		public override bool Interactable
		{
			get
			{
				return base.Interactable;
			}
			set
			{
				base.Interactable = value;
				Selectable.interactable = value;
			}
		}

		public bool IsOn
		{
			get
			{
				return _toggle.isOn;
			}
			set
			{
				if (_toggle.isOn != value)
				{
					_toggle.isOn = value;
				}
			}
		}

		public string OnClass { get; set; }

		public Selectable Selectable => _toggle;

		public Toggle Toggle => _toggle;

		protected override AttributeSet AttributeSet => ToggleAttributes.Set;

		private float AnimationPercentage
		{
			get
			{
				return _percentage;
			}
			set
			{
				_percentage = value;
				_checkRect.anchorMin = Vector2.LerpUnclamped(new Vector2(0f, 0f), new Vector2(0.5f, 0f), _percentage);
				_checkRect.anchorMax = Vector2.LerpUnclamped(new Vector2(0.5f, 1f), new Vector2(1f, 1f), _percentage);
			}
		}

		public event Action<bool> ValueChanged;

		public override void Initialize(IWidgetContext context, XElement element)
		{
			base.Initialize(context, element);
			_checkRect = _checkmark.GetComponent<RectTransform>();
			BackgroundColor = new ColorProperty(_background.color, delegate(Color x)
			{
				_background.color = x;
			});
			CheckColor = new ColorProperty(_checkmark.color, delegate(Color x)
			{
				_checkmark.color = x;
			});
			_toggle.onValueChanged.AddListener(delegate(bool x)
			{
				this.ValueChanged?.Invoke(x);
				UpdateOnClass();
			});
		}

		protected override void Start()
		{
			base.Start();
			UpdateOnClass(animate: false);
		}

		private void UpdateOnClass(bool animate = true)
		{
			if (!string.IsNullOrEmpty(OnClass))
			{
				if (_toggle.isOn)
				{
					AddClass(OnClass);
				}
				else
				{
					RemoveClass(OnClass);
				}
			}
			if (animate)
			{
				DOTween.To(() => AnimationPercentage, delegate(float x)
				{
					AnimationPercentage = x;
				}, IsOn ? 1f : 0f, 0.25f).SetLink(base.gameObject).SetEase(Ease.OutBack)
					.SetUpdate(isIndependentUpdate: true);
			}
			else
			{
				AnimationPercentage = (IsOn ? 1f : 0f);
			}
		}
	}
}
