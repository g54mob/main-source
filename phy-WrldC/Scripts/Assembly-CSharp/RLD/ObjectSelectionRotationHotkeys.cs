using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class ObjectSelectionRotationHotkeys : Settings
	{
		[SerializeField]
		private Hotkeys _rotateAroundX = new Hotkeys("Rotate around X", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			Key = KeyCode.X,
			UseStrictModifierCheck = true,
			UseStrictMouseCheck = false
		};

		[SerializeField]
		private Hotkeys _rotateAroundY = new Hotkeys("Rotate around Y", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			Key = KeyCode.Y,
			UseStrictModifierCheck = true,
			UseStrictMouseCheck = false
		};

		[SerializeField]
		private Hotkeys _rotateAroundZ = new Hotkeys("Rotate around Z", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			Key = KeyCode.Z,
			UseStrictModifierCheck = true,
			UseStrictMouseCheck = false
		};

		[SerializeField]
		private Hotkeys _setRotationToIdentity = new Hotkeys("Set rotation to identity", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			Key = KeyCode.I,
			UseStrictModifierCheck = true,
			UseStrictMouseCheck = false
		};

		public Hotkeys RotateAroundX => _rotateAroundX;

		public Hotkeys RotateAroundY => _rotateAroundY;

		public Hotkeys RotateAroundZ => _rotateAroundZ;

		public Hotkeys SetRotationToIdentity => _setRotationToIdentity;
	}
}
