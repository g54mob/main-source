using UnityEngine;
using UnityEngine.UI;

namespace __Project__.Scripts.UI.ColorPickerUI
{
	public class ColorPickerButton : MonoBehaviour
	{
		[SerializeField]
		private ColorPicker m_ColorPicker;

		[SerializeField]
		private ChangeNameOverlay m_ChangeNameOverlay;

		[SerializeField]
		private GameObject m_ColorPickerParent;

		[SerializeField]
		private GameObject m_BackgroundColorPickerReference;

		private Button m_Button;

		private void Awake()
		{
		}

		public void SelectColor()
		{
		}
	}
}
