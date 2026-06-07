using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Simulator
{
	public class SliderExtended : Slider
	{
		[SerializeField]
		private bool m_updateValueTextOnValueChanged;

		[SerializeField]
		private TMP_Text m_valueTextComponent;

		[SerializeField]
		private string m_suffix;

		public SliderEvent onPointerUp;

		protected override void OnEnable()
		{
			base.OnEnable();
			if (m_updateValueTextOnValueChanged)
			{
				UpdateValueTextToCurrentValue();
				base.onValueChanged.AddListener(OnValueChanged_UpdateValueText);
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (m_updateValueTextOnValueChanged)
			{
				base.onValueChanged.RemoveListener(OnValueChanged_UpdateValueText);
			}
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				base.OnPointerUp(eventData);
				onPointerUp.Invoke(value);
			}
		}

		private void OnValueChanged_UpdateValueText(float _)
		{
			UpdateValueTextToCurrentValue();
		}

		public void UpdateValueTextToCurrentValue()
		{
			if (m_updateValueTextOnValueChanged)
			{
				string text = (base.wholeNumbers ? "F0" : "F2");
				m_valueTextComponent.text = value.ToString(text, CultureInfo.InvariantCulture) + m_suffix;
			}
		}
	}
}
