using System;
using UnityEngine;

namespace InputControl
{
	[Serializable]
	public class InputFocusData
	{
		public InputActionController.IUIControlActions Input;

		public MonoBehaviour ParentComponent;

		public string Name;

		public InputFocusData(InputActionController.IUIControlActions input, MonoBehaviour parentComponent)
		{
		}
	}
}
