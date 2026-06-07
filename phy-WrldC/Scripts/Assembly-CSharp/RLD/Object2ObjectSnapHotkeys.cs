using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class Object2ObjectSnapHotkeys : Settings
	{
		[SerializeField]
		private Hotkeys _toggleSnap = new Hotkeys("Toggle on/off", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictModifierCheck = true,
			UseStrictMouseCheck = true,
			Key = KeyCode.S
		};

		[SerializeField]
		private Hotkeys _toggleSitBelowSurface = new Hotkeys("Toggle sit below surface", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictModifierCheck = true,
			UseStrictMouseCheck = true,
			Key = KeyCode.N
		};

		[SerializeField]
		private Hotkeys _enableMoreControl = new Hotkeys("Enable more control", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictModifierCheck = true,
			UseStrictMouseCheck = true,
			LShift = true
		};

		[SerializeField]
		private Hotkeys _enableFlexiSnap = new Hotkeys("Enable flexi-snap", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictModifierCheck = true,
			UseStrictMouseCheck = true,
			LCtrl = true
		};

		public Hotkeys ToggleSnap => _toggleSnap;

		public Hotkeys ToggleSitBelowSurface => _toggleSitBelowSurface;

		public Hotkeys EnableMoreControl => _enableMoreControl;

		public Hotkeys EnableFlexiSnap => _enableFlexiSnap;
	}
}
