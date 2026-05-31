using UnityEngine;
using UnityEngine.UI;

namespace __Project__.Scripts.UI.ColorPickerUI
{
	public class ColorPreview : MonoBehaviour
	{
		public Graphic previewGraphic;

		public ColorPicker colorPicker;

		[SerializeField]
		private bool m_IsBackground;

		[SerializeField]
		private ChangeNameOverlay m_ChangeNameOverlay;

		private void Start()
		{
		}

		public void ResetColor()
		{
		}

		public void OnColorChanged(Color c)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
