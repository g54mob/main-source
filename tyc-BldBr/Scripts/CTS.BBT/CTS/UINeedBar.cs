using CTS.Core.StatisticsSystem;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UINeedBar : UICanvasGroup
	{
		[SerializeField]
		[Required(null)]
		private Image _fillBar;

		private TextMeshProUGUI _text;

		private NumericStatistic _assignedStatistic;

		protected override void Awake()
		{
			base.Awake();
			_text = GetComponentInChildren<TextMeshProUGUI>();
		}

		private void OnEnable()
		{
			if (_assignedStatistic != null)
			{
				_assignedStatistic.ValueChanged += UpdateBar;
			}
		}

		private void OnDisable()
		{
			if (_assignedStatistic != null)
			{
				_assignedStatistic.ValueChanged -= UpdateBar;
			}
		}

		public void AssignStatistic(NumericStatistic statistic)
		{
			if (_assignedStatistic != null)
			{
				_assignedStatistic.ValueChanged -= UpdateBar;
			}
			_assignedStatistic = statistic;
			_assignedStatistic.ValueChanged += UpdateBar;
			UpdateBar();
		}

		private void UpdateBar(float unused = 0f)
		{
			if (_fillBar != null)
			{
				_fillBar.fillAmount = _assignedStatistic.UnitInterval;
			}
		}

		public void SetText(string p_text)
		{
			if (!string.IsNullOrEmpty(p_text))
			{
				_text?.SetText(p_text);
			}
		}

		public void SetAmount(float p_amount)
		{
			_fillBar.fillAmount = p_amount;
		}
	}
}
