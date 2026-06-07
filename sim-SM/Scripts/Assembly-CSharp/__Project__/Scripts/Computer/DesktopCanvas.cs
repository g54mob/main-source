using System.Collections.Generic;
using UnityEngine;
using __Project__.Scripts.ControllerInputModule;

namespace __Project__.Scripts.Computer
{
	public class DesktopCanvas : MonoBehaviour
	{
		[SerializeField]
		private List<ButtonHandler> m_Buttons;

		[SerializeField]
		private ButtonHandler m_VendingButton;

		[HideInInspector]
		public GamePadUIPanel desktopPanel;

		private void Start()
		{
		}

		public void SwitchVendingButton(bool willEnable)
		{
		}
	}
}
