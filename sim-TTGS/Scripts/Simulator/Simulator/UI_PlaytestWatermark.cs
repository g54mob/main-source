using I2.Loc;
using TMPro;
using UnityEngine;

namespace Simulator
{
	public class UI_PlaytestWatermark : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text m_textComponent;

		private Localize m_localize;

		private void Awake()
		{
			m_localize = m_textComponent.GetComponent<Localize>();
		}

		private void Start()
		{
			FormatText();
		}

		private void OnEnable()
		{
			LocalizationManager.OnLocalizedEvent += FormatText;
		}

		private void OnDisable()
		{
			LocalizationManager.OnLocalizedEvent -= FormatText;
		}

		private void FormatText()
		{
			m_textComponent.text = string.Format(m_textComponent.text, Application.version);
		}
	}
}
