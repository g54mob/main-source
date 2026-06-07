using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class ObjectGridSnapHotkeys : Settings
	{
		[SerializeField]
		private Hotkeys _beginGridSnap = new Hotkeys("Begin grid snap", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictModifierCheck = true,
			UseStrictMouseCheck = false,
			Key = KeyCode.B
		};

		public Hotkeys BeginGridSnap => _beginGridSnap;
	}
}
