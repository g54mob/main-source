using UnityEngine;
using __Project__.Scripts.ControllerInputModule;

namespace __Project__.Scripts.UI.ColorPickerUI
{
	public class ColorPickerGamepadHandler : MonoBehaviour
	{
		[SerializeField]
		private ColorPicker m_ColorPicker;

		[SerializeField]
		private GamePadUIPanel m_GamePadUIPanel;

		private bool m_IsInitialized;

		public void Initialize()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void OnGamepadConnected(bool isConnected)
		{
		}
	}
}
