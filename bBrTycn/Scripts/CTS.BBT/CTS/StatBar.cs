using CTS.Core.StatisticsSystem;
using CTS.UI;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace CTS
{
	public class StatBar : MonoBehaviour
	{
		[SerializeField]
		private Image foregroundBarImage;

		[SerializeField]
		private Image _backgroundBarImage;

		[SerializeField]
		private Image _backgroundIconImage;

		[SerializeField]
		private PaletteData _backgroundIconSpecializedColor;

		[SerializeField]
		private PaletteData _backgroundIconNormalColor;

		[SerializeField]
		private LocalizedString _tooltipTitle;

		[SerializeField]
		private LocalizedString _tooltipText;

		[SerializeField]
		private float _valueMultiplier = 1f;

		private ToolTipsShower _toolTips;

		private NumericStatistic _assignedStatistic;

		[field: SerializeField]
		public string Key { get; private set; }

		[field: SerializeField]
		public bool EditorOnly { get; private set; }

		private void Awake()
		{
			_toolTips = GetComponent<ToolTipsShower>();
		}

		private void OnEnable()
		{
			RegisterToStatisticChange();
		}

		private void OnDisable()
		{
			UnregisterToStatisticChange();
		}

		private void RegisterToStatisticChange()
		{
			if (_assignedStatistic != null)
			{
				_assignedStatistic.ValueChanged += UpdateBar;
			}
		}

		private void UnregisterToStatisticChange()
		{
			if (_assignedStatistic != null)
			{
				_assignedStatistic.ValueChanged -= UpdateBar;
			}
		}

		public void AssignAgentStatistic(NumericStatistic statistic, bool specialized = false)
		{
			if (base.isActiveAndEnabled)
			{
				UnregisterToStatisticChange();
				_assignedStatistic = statistic;
				RegisterToStatisticChange();
			}
			else
			{
				_assignedStatistic = statistic;
			}
			if ((bool)_backgroundIconImage)
			{
				_backgroundIconImage.color = (specialized ? _backgroundIconSpecializedColor : _backgroundIconNormalColor);
			}
			UpdateBar();
		}

		public void AssignColor(Color colorBG, Color colorFG)
		{
			foregroundBarImage.color = colorFG;
			_backgroundBarImage.color = colorBG;
		}

		private void UpdateBar(float unused = 0f)
		{
			if (foregroundBarImage != null)
			{
				foregroundBarImage.fillAmount = _assignedStatistic.UnitInterval;
			}
			if (_toolTips == null)
			{
				_toolTips = GetComponent<ToolTipsShower>();
			}
			_toolTips.SetTootipsInfo(_tooltipTitle, _tooltipText.GetLocalizedString() + "\n" + $"{_assignedStatistic.IntValue} / {Mathf.RoundToInt(_assignedStatistic.Max)}");
		}

		public void SetValue(float current, float max)
		{
			if (foregroundBarImage != null)
			{
				foregroundBarImage.fillAmount = Mathf.Clamp01(current / max);
			}
			if (_toolTips == null)
			{
				_toolTips = GetComponent<ToolTipsShower>();
			}
			_toolTips.SetTootipsInfo(_tooltipTitle, _tooltipText.GetLocalizedString() + "\n" + Mathf.RoundToInt(current * _valueMultiplier) + " / " + Mathf.RoundToInt(max * _valueMultiplier));
		}
	}
}
