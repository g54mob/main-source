using System;
using UI.Elements;
using UnityEngine;

namespace UI.Apps
{
	[Serializable]
	public struct ButtonsAndPanels
	{
		public UIButton button;

		public GameObject panel;

		public ButtonsAndPanels(UIButton button, GameObject panel)
		{
			this.button = null;
			this.panel = null;
		}
	}
}
