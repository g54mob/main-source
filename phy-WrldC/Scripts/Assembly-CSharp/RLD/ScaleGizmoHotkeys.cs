using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class ScaleGizmoHotkeys : Settings
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

		[SerializeField]
		private Hotkeys _changeMultiAxisMode = new Hotkeys("Change multi-axis mode", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			Key = KeyCode.None,
			LShift = true
		};

		public Hotkeys EnableSnapping => _enableSnapping;

		public Hotkeys ChangeMultiAxisMode => _changeMultiAxisMode;
	}
}
