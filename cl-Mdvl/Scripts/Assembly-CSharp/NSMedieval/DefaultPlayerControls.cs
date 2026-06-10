using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public class DefaultPlayerControls : NSEipix.Base.Model
	{
		[SerializeField]
		private Keybinding[] keybindings;

		[SerializeField]
		private KeyCode keybindingCancelKey;

		[SerializeField]
		private KeyCode[] restrictedKeys;

		[SerializeField]
		private string mouseXAxis;

		[SerializeField]
		private string mouseYAxis;

		[SerializeField]
		private string mouseZoomAxis;

		[SerializeField]
		private KeyCode cameraPanKey;

		public Keybinding[] Keybindings => keybindings;

		public KeyCode KeybindingCancelKey => keybindingCancelKey;

		public KeyCode[] RestrictedKeys => restrictedKeys;

		public string MouseXAxis => mouseXAxis;

		public string MouseYAxis => mouseYAxis;

		public string MouseZoomAxis => mouseZoomAxis;

		public KeyCode CameraPanKey => cameraPanKey;

		public override string GetID()
		{
			return "DefaultPlayerControls";
		}
	}
}
