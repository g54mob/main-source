using UnityEngine;

namespace TH20.UI
{
	public class PanelItemCashFlowBar : PanelItem
	{
		[SerializeField]
		private RectTransform _cachedAmountBar;

		[SerializeField]
		private RectTransform _cachedDirectionIconTransform;

		private float _defaultHeight;

		private float _maxHeight;

		private float _minHeight;

		private Vector2 _barSize = Vector2.zero;

		public float BarHeight
		{
			get
			{
				return _defaultHeight;
			}
			set
			{
				if ((bool)_cachedAmountBar)
				{
					_barSize.y = _minHeight + (_maxHeight - _minHeight) * Mathf.Clamp01(value);
					_cachedAmountBar.sizeDelta = _barSize;
				}
			}
		}

		public override void Setup()
		{
			base.Setup();
			if ((bool)_cachedAmountBar)
			{
				_barSize.x = _cachedAmountBar.rect.width;
				_defaultHeight = _cachedAmountBar.rect.height;
			}
		}

		public void SetTrendDown()
		{
			if (_cachedDirectionIconTransform != null)
			{
				_cachedDirectionIconTransform.localRotation = Quaternion.Euler(0f, 0f, 180f);
			}
		}

		public void SetTrendUp()
		{
			if (_cachedDirectionIconTransform != null)
			{
				_cachedDirectionIconTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
			}
		}

		public void SetMetrics(float min, float max)
		{
			_maxHeight = max;
			_minHeight = min;
		}
	}
}
