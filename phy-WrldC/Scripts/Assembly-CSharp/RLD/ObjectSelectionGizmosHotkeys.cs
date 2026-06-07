using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class ObjectSelectionGizmosHotkeys : Settings
	{
		[SerializeField]
		private Hotkeys _activateMoveGizmo = new Hotkeys("Activate move gizmo", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictMouseCheck = true,
			Key = KeyCode.W
		};

		[SerializeField]
		private Hotkeys _activateRotationGizmo = new Hotkeys("Activate rotation gizmo", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictMouseCheck = true,
			Key = KeyCode.E
		};

		[SerializeField]
		private Hotkeys _activateScaleGizmo = new Hotkeys("Activate scale gizmo", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictMouseCheck = true,
			Key = KeyCode.R
		};

		[SerializeField]
		private Hotkeys _activateBoxScaleGizmo = new Hotkeys("Activate box scale gizmo", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictMouseCheck = true,
			Key = KeyCode.T
		};

		[SerializeField]
		private Hotkeys _activateUniversalGizmo = new Hotkeys("Activate universal gizmo", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictMouseCheck = true,
			Key = KeyCode.U
		};

		[SerializeField]
		private Hotkeys _activateExtrudeGizmo = new Hotkeys("Activate extrude gizmo", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictMouseCheck = true,
			Key = KeyCode.Q
		};

		[SerializeField]
		private Hotkeys _toggleTransformSpace = new Hotkeys("Toggle transform space (global/local)", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictModifierCheck = true,
			UseStrictMouseCheck = true,
			Key = KeyCode.L
		};

		public Hotkeys ActivateMoveGizmo => _activateMoveGizmo;

		public Hotkeys ActivateRotationGizmo => _activateRotationGizmo;

		public Hotkeys ActivateScaleGizmo => _activateScaleGizmo;

		public Hotkeys ActivateBoxScaleGizmo => _activateBoxScaleGizmo;

		public Hotkeys ActivateUniversalGizmo => _activateUniversalGizmo;

		public Hotkeys ActivateExtrudeGizmo => _activateExtrudeGizmo;

		public Hotkeys ToggleTransformSpace => _toggleTransformSpace;
	}
}
