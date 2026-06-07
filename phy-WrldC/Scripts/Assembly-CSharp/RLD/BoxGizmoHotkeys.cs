using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class BoxGizmoHotkeys : Settings
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
		private Hotkeys _enableCenterPivot = new Hotkeys("Enable center pivot", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			Key = KeyCode.None,
			LShift = true
		};

		public Hotkeys EnableSnapping => _enableSnapping;

		public Hotkeys EnableCenterPivot => _enableCenterPivot;
	}
}
