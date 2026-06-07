using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class ObjectSelectionChangedEventArgs
	{
		private ObjectSelectReason _selectReason;

		private List<GameObject> _objectsWhichWereSelected = new List<GameObject>();

		private ObjectDeselectReason _deselectReason;

		private List<GameObject> _objectsWhichWereDeselected = new List<GameObject>();

		private ObjectSelectionSnapshot _undoRedoSnapshot;

		public ObjectSelectReason SelectReason => _selectReason;

		public int NumObjectsSelected => _objectsWhichWereSelected.Count;

		public List<GameObject> ObjectsWhichWereSelected => new List<GameObject>(_objectsWhichWereSelected);

		public ObjectDeselectReason DeselectReason => _deselectReason;

		public int NumObjectsDeselected => _objectsWhichWereDeselected.Count;

		public List<GameObject> ObjectsWhichWereDeselected => new List<GameObject>(_objectsWhichWereDeselected);

		public ObjectSelectionSnapshot UndoRedoSnapshot => _undoRedoSnapshot;

		public ObjectSelectionChangedEventArgs(ObjectSelectReason selectReason, List<GameObject> objectsWhichWereSelected, ObjectDeselectReason deselectReason, List<GameObject> objectsWhichWereDeselected, ObjectSelectionSnapshot undoRedoSnapshot = null)
		{
			_selectReason = selectReason;
			if (objectsWhichWereSelected != null)
			{
				_objectsWhichWereSelected = new List<GameObject>(objectsWhichWereSelected);
			}
			else
			{
				_objectsWhichWereSelected = new List<GameObject>();
			}
			_deselectReason = deselectReason;
			if (objectsWhichWereDeselected != null)
			{
				_objectsWhichWereDeselected = new List<GameObject>(objectsWhichWereDeselected);
			}
			else
			{
				_objectsWhichWereDeselected = new List<GameObject>();
			}
			if (_selectReason == ObjectSelectReason.Undo || _selectReason == ObjectSelectReason.Redo || _deselectReason == ObjectDeselectReason.Undo || _deselectReason == ObjectDeselectReason.Redo)
			{
				_undoRedoSnapshot = undoRedoSnapshot;
			}
		}
	}
}
