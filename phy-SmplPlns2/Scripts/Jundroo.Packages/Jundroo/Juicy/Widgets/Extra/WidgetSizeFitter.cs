using UnityEngine;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets.Extra
{
	public class WidgetSizeFitter : ContentSizeFitter
	{
		[SerializeField]
		private float _maxHeight;

		[SerializeField]
		private float _maxWidth;

		private RectTransform _rect;

		public float MaxHeight
		{
			get
			{
				return _maxHeight;
			}
			set
			{
				_maxWidth = value;
				SetDirty();
			}
		}

		public float MaxWidth
		{
			get
			{
				return _maxWidth;
			}
			set
			{
				_maxWidth = value;
				SetDirty();
			}
		}

		public override void SetLayoutHorizontal()
		{
			base.SetLayoutHorizontal();
			if (MaxWidth > 0f && _rect.sizeDelta.x > MaxWidth)
			{
				_rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, MaxWidth);
			}
		}

		public override void SetLayoutVertical()
		{
			base.SetLayoutVertical();
			if (MaxHeight > 0f && _rect.sizeDelta.y > MaxHeight)
			{
				_rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, MaxHeight);
			}
		}

		protected override void Awake()
		{
			base.Awake();
			_rect = GetComponent<RectTransform>();
		}
	}
}
