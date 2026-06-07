using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class DeleteSelectedObjectsAction : IUndoRedoAction
	{
		private List<GameObject> _selectedObjects;

		private List<GameObject> _deletedObjects;

		private ObjectSelectionSnapshot _preDeleteSnapshot;

		private ObjectSelectionSnapshot _postDeleteSnapshot;

		private bool _canDestroyObjects;

		public ObjectSelectionSnapshot PreDeleteSnapshot => _preDeleteSnapshot;

		public ObjectSelectionSnapshot PostDeleteSnapshot => _postDeleteSnapshot;

		public DeleteSelectedObjectsAction(List<GameObject> selectedObjects, ObjectSelectionSnapshot preDeleteSnapshot)
		{
			_selectedObjects = new List<GameObject>(selectedObjects);
			_preDeleteSnapshot = preDeleteSnapshot;
		}

		public void Execute()
		{
			if (_postDeleteSnapshot != null || _selectedObjects.Count == 0)
			{
				return;
			}
			_deletedObjects = new List<GameObject>(_selectedObjects.Count);
			foreach (GameObject selectedObject in _selectedObjects)
			{
				_deletedObjects.Add(selectedObject);
				selectedObject.SetActive(value: false);
			}
			_postDeleteSnapshot = new ObjectSelectionSnapshot();
			_postDeleteSnapshot.Snapshot();
			MonoSingleton<RTUndoRedo>.Get.RecordAction(this);
			_canDestroyObjects = true;
		}

		public void Undo()
		{
			if (_deletedObjects == null)
			{
				return;
			}
			foreach (GameObject deletedObject in _deletedObjects)
			{
				deletedObject.SetActive(value: true);
			}
			_canDestroyObjects = false;
		}

		public void Redo()
		{
			if (_deletedObjects == null)
			{
				return;
			}
			foreach (GameObject deletedObject in _deletedObjects)
			{
				deletedObject.SetActive(value: false);
			}
			_canDestroyObjects = true;
		}

		public void OnRemovedFromUndoRedoStack()
		{
			if (_deletedObjects == null || _deletedObjects.Count == 0 || !_canDestroyObjects)
			{
				return;
			}
			foreach (GameObject deletedObject in _deletedObjects)
			{
				Object.Destroy(deletedObject);
			}
			_deletedObjects.Clear();
			_deletedObjects = null;
		}
	}
}
