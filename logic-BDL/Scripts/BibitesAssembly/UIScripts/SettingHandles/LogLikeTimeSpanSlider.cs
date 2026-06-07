using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utility;

namespace UIScripts.SettingHandles
{
	public class LogLikeTimeSpanSlider : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI timeText;

		[SerializeField]
		private Slider slider;

		private LogLikeConfig config;

		private bool hasInit;

		public UnityEvent<int> onTimeIndexChange = new UnityEvent<int>();

		public int value
		{
			get
			{
				return Mathf.RoundToInt(slider.value);
			}
			set
			{
				slider.value = value;
			}
		}

		private void Initialize()
		{
			slider.onValueChanged.AddListener(UpdateTime);
			hasInit = true;
		}

		public void SetConfig(LogLikeConfig logLikeConfig)
		{
			if (!hasInit)
			{
				Initialize();
			}
			config = logLikeConfig;
			UpdateTime(slider.value);
		}

		public void SetMinMax(int min, int max)
		{
			slider.minValue = min;
			slider.maxValue = max;
		}

		public void SetValueWithoutNotify(int val)
		{
			slider.SetValueWithoutNotify(val);
		}

		public void UpdateTime(float val)
		{
			int num = Mathf.RoundToInt(val);
			timeText.text = ((num < 0) ? "Now" : (config.TimeOfPointInSerialConfig(num).FormattedTimeValue(1, "", smallUnits: true, spaceBeforeUnits: false, config.acquisition) + " ago"));
			onTimeIndexChange.Invoke(num);
		}
	}
}
