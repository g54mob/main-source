using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class ObjectSelectionHotkeys : Settings
	{
		[SerializeField]
		private Hotkeys _appendToSelection = new Hotkeys("Append to selection", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			LCtrl = true
		};

		[SerializeField]
		private Hotkeys _multiDeselect = new Hotkeys("Multi deselect", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			LShift = true
		};

		[SerializeField]
		private Hotkeys _deleteSelected = new Hotkeys("Delete selected", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			Key = KeyCode.Delete
		};

		[SerializeField]
		private Hotkeys _focusCameraOnSelection = new Hotkeys("Focus camera on selection", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			Key = KeyCode.F
		};

		[SerializeField]
		private Hotkeys _duplicateSelection = new Hotkeys("Duplicate selected", new HotkeysStaticData
		{
			CanHaveMouseButtons = false
		})
		{
			UseStrictMouseCheck = true,
			UseStrictModifierCheck = true,
			LCtrl = true,
			Key = KeyCode.D
		};

		public Hotkeys AppendToSelection => _appendToSelection;

		public Hotkeys MultiDeselect => _multiDeselect;

		public Hotkeys DeleteSelected => _deleteSelected;

		public Hotkeys FocusCameraOnSelection => _focusCameraOnSelection;

		public Hotkeys DuplicateSelection => _duplicateSelection;
	}
}
