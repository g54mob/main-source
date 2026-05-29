using UnityEngine;
using UnityEngine.UI;

namespace __Project__.Scripts.UI.ColorPickerUI
{
	public class BackgroundColorPickerButton : MonoBehaviour
	{
		public bool IsDefaultBGSetted;

		[SerializeField]
		private ColorPicker m_ColorPicker;

		[SerializeField]
		private ChangeNameOverlay m_ChangeNameOverlay;

		[SerializeField]
		private GameObject m_ColorPickerParent;

		[SerializeField]
		private GameObject m_TextColorPickerReference;

		[SerializeField]
		private Button m_Button;

		[SerializeField]
		private Button m_ButtonSetDefault;

		private void Awake()
		{
		}

		private void ChangeNameBackgroundColor(Color obj)
		{
		}

		public void SelectColor()
		{
		}

		public void SetDefault()
		{
		}
	}
}
