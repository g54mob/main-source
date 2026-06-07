using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class RotationGizmoHotkeys : Settings
	{
		[SerializeField]
		private Hotkeys _enableSnapping = new Hotkeys("Enable snapping", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			Key = KeyCode.None,
			LCtrl = true
		};

		public Hotkeys EnableSnapping => _enableSnapping;
	}
}
