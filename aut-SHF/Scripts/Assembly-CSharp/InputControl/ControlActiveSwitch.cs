using System;
using System.Collections.Generic;
using UnityEngine;

namespace InputControl
{
	public class ControlActiveSwitch : MonoBehaviour
	{
		[SerializeField]
		private PadInputManager.InputType _activeInputType;

		private readonly List<IDisposable> _disposable;

		private void Awake()
		{
		}

		private void OnSwitchInputType(PadInputManager.InputType inputType)
		{
		}

		private void OnSwitchMouseMode(bool isSwitchMouse)
		{
		}

		public void OnDestroy()
		{
		}
	}
}
