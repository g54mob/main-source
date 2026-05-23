using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ODev.UI
{
	public class SliderText : MonoBehaviour
	{
		[Tooltip("Xn - n number of decimal place \nX format - F (fixed-point), D (decimal), C (currency) P (percent), etc")]
		public string TextFormat = "F2";

		public string PreText = "";

		public string PostText = "";

		public bool AddPlusIfPositive;

		[Space]
		[SerializeField]
		private TMP_Text m_Text;

		[SerializeField]
		private Slider m_Slider;

		private void Awake()
		{
			m_Slider = GetComponent<Slider>();
			m_Slider.onValueChanged.AddListener(OnValueChanged);
			OnValueChanged(m_Slider.value);
		}

		private void OnDestroy()
		{
			m_Slider.onValueChanged.RemoveListener(OnValueChanged);
		}

		private void OnValidate()
		{
			if ((!(m_Slider == null) || TryGetComponent<Slider>(out m_Slider)) && (!(m_Text == null) || TryGetComponent<TMP_Text>(out m_Text)))
			{
				OnValueChanged(m_Slider.value);
			}
		}

		public void OnValueChanged(float pValue)
		{
			string text = string.Empty;
			if (AddPlusIfPositive && pValue > 0f)
			{
				text = "+";
			}
			m_Text.SetText(PreText + text + pValue.ToString(TextFormat) + PostText);
		}
	}
}
