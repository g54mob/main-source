using System;
using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.CustomSettings
{
	[Serializable]
	public class UI_SliderPlayerPrefFloatOptions : UI_BasePlayerPrefMemberOptions<PlayerPrefFloat>
	{
		[SerializeField]
		private SliderExtended m_slider;

		[SerializeField]
		private Vector2 m_range;

		[SerializeField]
		private EnabledValue<float> m_divideFinalValue;

		[SerializeField]
		private bool m_wholeNumbers;

		public event Action<float> OnValueChanged
		{
			add
			{
				playerPrefMember.OnValueChanged += value;
			}
			remove
			{
				playerPrefMember.OnValueChanged -= value;
			}
		}

		public override void Awake()
		{
			m_slider.minValue = m_range.x;
			m_slider.maxValue = m_range.y;
			m_slider.wholeNumbers = m_wholeNumbers;
		}

		public override void OnEnable()
		{
			SelectCurrentValue();
			m_slider.onValueChanged.AddListener(OnSliderValueChange);
			m_slider.onPointerUp.AddListener(OnPointerUp);
		}

		public override void OnDisable()
		{
			m_slider.onPointerUp.RemoveListener(OnPointerUp);
			m_slider.onValueChanged.RemoveListener(OnSliderValueChange);
		}

		public override void SelectCurrentValue()
		{
			float num = playerPrefMember.Value;
			if (m_divideFinalValue.IsEnabled(out var value))
			{
				num *= value;
			}
			m_slider.SetValueWithoutNotify(num);
			m_slider.UpdateValueTextToCurrentValue();
		}

		private void OnSliderValueChange(float value)
		{
			SaveSliderValueToPlayerPrefMember();
		}

		private void OnPointerUp(float value)
		{
			SaveSliderValueToPlayerPrefMember();
		}

		private void SaveSliderValueToPlayerPrefMember()
		{
			float num = m_slider.value;
			if (m_divideFinalValue.IsEnabled(out var value))
			{
				num /= value;
			}
			playerPrefMember.Value = num;
		}
	}
}
