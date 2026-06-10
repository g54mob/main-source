using System;
using TMPro;
using UnityEngine;

namespace Rewired.UI.ControlMapper
{
	[AddComponentMenu(null)]
	public class InputRow : MonoBehaviour
	{
		public TMP_Text label;

		private int rowIndex;

		private Action<int, ButtonInfo> inputFieldActivatedCallback;

		public ButtonInfo[] buttons { get; private set; }

		public void Initialize(int rowIndex, string label, Action<int, ButtonInfo> inputFieldActivatedCallback)
		{
		}

		public void OnButtonActivated(ButtonInfo buttonInfo)
		{
		}
	}
}
