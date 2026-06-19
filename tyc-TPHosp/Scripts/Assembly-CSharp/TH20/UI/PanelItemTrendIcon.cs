using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	public class PanelItemTrendIcon : PanelItem
	{
		[SerializeField]
		private Color _downColor;

		[SerializeField]
		private Color _upColor;

		[SerializeField]
		private Image _trendIcon;

		[SerializeField]
		private RectTransform _trendDirection;

		[SerializeField]
		private TMP_Text _trendValue;

		[SerializeField]
		private TooltipSpawner _trendTooltipSpawner;

		[SerializeField]
		private bool _useSystemNumTrendMonths = true;

		private Quaternion _trendDown;

		private Quaternion _trendUp;

		private int _numTrendMonths = 3;

		public override void Setup()
		{
			base.Setup();
			_trendDown = Quaternion.AngleAxis(180f, Vector3.forward);
			_trendUp = Quaternion.identity;
			if (_trendTooltipSpawner != null && !_trendTooltipSpawner.TooltipLocText.IsNullOrEmpty())
			{
				_trendTooltipSpawner.SetDataProvider(delegate(Tooltip tooltip)
				{
					string tooltipLocText = _trendTooltipSpawner.TooltipLocText;
					tooltipLocText = tooltipLocText.Replace("{[NUM_MONTHS]}", $"{GetNumTrendMonths()}");
					tooltip.Text = tooltipLocText;
				});
			}
		}

		public void SetTrend(float previousValue, float currentValue, float maxRef, float minRef)
		{
		}

		public void SetTrend(float previousValue, float currentValue)
		{
			float num = currentValue - previousValue;
			if ((bool)_trendValue)
			{
				float num2 = 0f;
				num2 = ((previousValue.CompareTo(0f) != 0) ? (num / previousValue) : ((currentValue.CompareTo(0f) != 0) ? 10.99f : 0f));
				if (Mathf.Abs(num2) > 9.99f)
				{
					_trendValue.text = $">{StringUtils.FormatPercentageValue(9.99f)}";
				}
				else
				{
					_trendValue.text = StringUtils.FormatPercentageValue(Mathf.Abs(num2));
				}
			}
			SetTrendIconDirection(num);
		}

		public void SetTrendIconDirection(float trendVector)
		{
			if (Mathf.Sign(trendVector) >= 0f)
			{
				if ((bool)_trendDirection)
				{
					_trendDirection.localRotation = _trendUp;
				}
				if ((bool)_trendIcon)
				{
					_trendIcon.color = _upColor;
				}
			}
			else
			{
				if ((bool)_trendDirection)
				{
					_trendDirection.localRotation = _trendDown;
				}
				if ((bool)_trendIcon)
				{
					_trendIcon.color = _downColor;
				}
			}
		}

		public void SetNumTrendMonths(int numTrendMonths)
		{
			_numTrendMonths = numTrendMonths;
		}

		private int GetNumTrendMonths()
		{
			int result = GameAlgorithms.Config.NumMonthsForGeneralTrendIndicators;
			if (!_useSystemNumTrendMonths)
			{
				result = _numTrendMonths;
			}
			return result;
		}
	}
}
