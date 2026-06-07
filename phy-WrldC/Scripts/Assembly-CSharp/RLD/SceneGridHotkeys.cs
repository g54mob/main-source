using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class SceneGridHotkeys : Settings
	{
		[SerializeField]
		private Hotkeys _gridUp = new Hotkeys("Grid up", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			Key = KeyCode.RightBracket
		};

		[SerializeField]
		private Hotkeys _gridDown = new Hotkeys("Grid down", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			Key = KeyCode.LeftBracket
		};

		private Hotkeys _snapToCursorPickPoint = new Hotkeys("Snap to cursor pick point", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			LAlt = true
		};

		public Hotkeys GridUp => _gridUp;

		public Hotkeys GridDown => _gridDown;

		public Hotkeys SnapToCursorPickPoint => _snapToCursorPickPoint;
	}
}
