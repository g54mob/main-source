using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

namespace __Project__.Scripts.UI.ColorPickerUI
{
	public class NameFontSizer : MonoBehaviour
	{
		[SerializeField]
		private Slider m_SizeSlider;

		[SerializeField]
		private ChangeNameOverlay m_ChangeNameOverlay;

		[SerializeField]
		private TMP_Text m_SizeText;

		[SerializeField]
		private bool m_IsHorizontal;

		[SerializeField]
		private LocalizeStringEvent m_LocalizedSizeText;

		private void Awake()
		{
		}

		public void Initialize()
		{
		}

		private void SetFontSize(float size)
		{
		}

		public void SetSliderValueForGamepad(bool isLeft)
		{
		}
	}
}
