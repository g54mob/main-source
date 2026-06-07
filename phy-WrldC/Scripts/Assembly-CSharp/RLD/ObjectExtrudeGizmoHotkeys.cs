using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class ObjectExtrudeGizmoHotkeys : Settings
	{
		[SerializeField]
		private Hotkeys _enableOverlapTest = new Hotkeys("Enable overlap test", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			Key = KeyCode.None,
			LShift = true
		};

		public Hotkeys EnableOverlapTest => _enableOverlapTest;
	}
}
