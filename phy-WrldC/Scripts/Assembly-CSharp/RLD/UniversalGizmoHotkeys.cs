using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class UniversalGizmoHotkeys : Settings
	{
		[SerializeField]
		private Hotkeys _enable2DMode = new Hotkeys("Enable 2D mode", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			Key = KeyCode.None,
			LShift = true
		};

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
		private Hotkeys _enableVertexSnapping = new Hotkeys("Enable vertex snapping", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictModifierCheck = false,
			Key = KeyCode.V
		};

		public Hotkeys Enable2DMode => _enable2DMode;

		public Hotkeys EnableSnapping => _enableSnapping;

		public Hotkeys EnableVertexSnapping => _enableVertexSnapping;
	}
}
