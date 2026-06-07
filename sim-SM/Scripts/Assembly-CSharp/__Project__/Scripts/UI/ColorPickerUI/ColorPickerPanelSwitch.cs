using UnityEngine;
using UnityEngine.UI;

namespace __Project__.Scripts.UI.ColorPickerUI
{
	public class ColorPickerPanelSwitch : MonoBehaviour
	{
		[SerializeField]
		private ChangeNameOverlay m_NameOverlay;

		[SerializeField]
		private GameObject m_ColorPickerParent;

		[SerializeField]
		private bool m_IsBackground;

		private Button m_Button;

		private void Awake()
		{
		}

		public void OpenColorPicker()
		{
		}
	}
}
