using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class ObjectGrabHotkeys : Settings
	{
		[SerializeField]
		private Hotkeys _toggleGrab = new Hotkeys("Toggle on/off", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictModifierCheck = true,
			UseStrictMouseCheck = true,
			Key = KeyCode.C
		};

		[SerializeField]
		private Hotkeys _enableRotation = new Hotkeys("Enable rotation", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictModifierCheck = true,
			UseStrictMouseCheck = true,
			LShift = true
		};

		[SerializeField]
		private Hotkeys _enableRotationAroundAnchor = new Hotkeys("Enable rotation around anchor", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictModifierCheck = true,
			UseStrictMouseCheck = true,
			LShift = true,
			LCtrl = true
		};

		[SerializeField]
		private Hotkeys _enableScaling = new Hotkeys("Enable scaling", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictModifierCheck = true,
			UseStrictMouseCheck = true,
			LCtrl = true
		};

		[SerializeField]
		private Hotkeys _enableOffsetFromSurface = new Hotkeys("Enable offset from surface", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictModifierCheck = true,
			UseStrictMouseCheck = true,
			Key = KeyCode.Q
		};

		[SerializeField]
		private Hotkeys _enableAnchorAdjust = new Hotkeys("Enable anchor adjust", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictModifierCheck = true,
			UseStrictMouseCheck = true,
			LAlt = true
		};

		[SerializeField]
		private Hotkeys _enableOffsetFromAnchor = new Hotkeys("Enable offset from anchor", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictModifierCheck = true,
			UseStrictMouseCheck = true,
			Key = KeyCode.Space
		};

		[SerializeField]
		private Hotkeys _nextAlignmentAxis = new Hotkeys("Next alignment axis", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictModifierCheck = true,
			UseStrictMouseCheck = true,
			Key = KeyCode.B
		};

		public Hotkeys ToggleGrab => _toggleGrab;

		public Hotkeys EnableRotation => _enableRotation;

		public Hotkeys EnableRotationAroundAnchor => _enableRotationAroundAnchor;

		public Hotkeys EnableScaling => _enableScaling;

		public Hotkeys EnableOffsetFromSurface => _enableOffsetFromSurface;

		public Hotkeys EnableAnchorAdjust => _enableAnchorAdjust;

		public Hotkeys EnableOffsetFromAnchor => _enableOffsetFromAnchor;

		public Hotkeys NextAlignmentAxis => _nextAlignmentAxis;

		public ObjectGrabHotkeys()
		{
			EstablishPotentialOverlaps();
		}

		private void EstablishPotentialOverlaps()
		{
			Hotkeys.EstablishPotentialOverlaps(new List<Hotkeys> { EnableRotation, EnableRotationAroundAnchor, EnableScaling, EnableOffsetFromSurface, EnableAnchorAdjust, EnableOffsetFromAnchor });
		}
	}
}
