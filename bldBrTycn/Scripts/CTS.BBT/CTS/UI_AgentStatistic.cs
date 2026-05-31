using CTS.Core;
using CTS.Core.StatisticsSystem;
using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_AgentStatistic : CTSBehaviour
	{
		[SerializeField]
		private Image _iconContainer;

		[SerializeField]
		private Image _fillImage;

		[Inject(false)]
		private ToolTipsShower _tipsShower;

		private NumericStatistic _stat;

		private AgentStatisticData _data;

		public EAgentStatistics StatType { get; private set; }

		public void SetStatisticData(AgentStatisticData data)
		{
			_data = data;
			StatType = _data.Statistic;
			_iconContainer.overrideSprite = _data.Icon;
		}

		private void Start()
		{
			_tipsShower.SetTootipsInfo(_data.Name, _data.Description, base.gameObject);
		}

		private void OnDestroy()
		{
			SetStatistic(null);
		}

		public void SetDisplay(bool isOn)
		{
			base.gameObject.SetActive(isOn);
		}

		public void SetFill(float value)
		{
			_fillImage.fillAmount = value;
		}

		public void SetStatistic(NumericStatistic stat)
		{
			if (_stat != stat)
			{
				if (_stat != null)
				{
					_stat.UnitIntervalChanged -= OnValueChanged;
				}
				_stat = stat;
				if (_stat != null)
				{
					_stat.UnitIntervalChanged += OnValueChanged;
					OnValueChanged(_stat.UnitInterval);
				}
			}
		}

		private void OnValueChanged(float obj)
		{
			SetFill(obj);
		}
	}
}
