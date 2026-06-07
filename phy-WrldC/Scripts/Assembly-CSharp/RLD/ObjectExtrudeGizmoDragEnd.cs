using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class ObjectExtrudeGizmoDragEnd : IUndoRedoAction
	{
		private bool _wasExecuted;

		private bool _destroyClones;

		private List<GameObject> _targetParents = new List<GameObject>();

		private List<LocalTransformSnapshot> _undoTargetSnapshots = new List<LocalTransformSnapshot>();

		private List<LocalTransformSnapshot> _redoTargetSnapshots = new List<LocalTransformSnapshot>();

		private List<GameObject> _extrudeClones = new List<GameObject>();

		public int NumTargets => _targetParents.Count;

		public void SetTargetParents(IEnumerable<GameObject> targetParents)
		{
			if (!_wasExecuted)
			{
				_targetParents = new List<GameObject>(targetParents);
			}
		}

		public void TakeUndoTargetSnapshots()
		{
			if (!_wasExecuted)
			{
				_undoTargetSnapshots = LocalTransformSnapshot.GetSnapshotCollection(_targetParents);
			}
		}

		public void TakeRedoTargetSnapshots()
		{
			if (!_wasExecuted)
			{
				_redoTargetSnapshots = LocalTransformSnapshot.GetSnapshotCollection(_targetParents);
			}
		}

		public void AddExtrudeClones(List<GameObject> extrudeClones)
		{
			if (_wasExecuted)
			{
				return;
			}
			foreach (GameObject extrudeClone in extrudeClones)
			{
				AddExtrudeClone(extrudeClone);
			}
		}

		public void AddExtrudeClone(GameObject extrudeClone)
		{
			if (!_wasExecuted && extrudeClone != null)
			{
				_extrudeClones.Add(extrudeClone);
			}
		}

		public void Execute()
		{
			MonoSingleton<RTUndoRedo>.Get.RecordAction(this);
			_wasExecuted = true;
		}

		public void Undo()
		{
			foreach (LocalTransformSnapshot undoTargetSnapshot in _undoTargetSnapshots)
			{
				undoTargetSnapshot.Apply();
			}
			foreach (GameObject extrudeClone in _extrudeClones)
			{
				if (extrudeClone != null)
				{
					extrudeClone.SetActive(value: false);
				}
			}
			_destroyClones = true;
		}

		public void Redo()
		{
			foreach (LocalTransformSnapshot redoTargetSnapshot in _redoTargetSnapshots)
			{
				redoTargetSnapshot.Apply();
			}
			foreach (GameObject extrudeClone in _extrudeClones)
			{
				if (extrudeClone != null)
				{
					extrudeClone.SetActive(value: true);
				}
			}
			_destroyClones = false;
		}

		public void OnRemovedFromUndoRedoStack()
		{
			if (!_destroyClones || _extrudeClones.Count == 0)
			{
				return;
			}
			foreach (GameObject extrudeClone in _extrudeClones)
			{
				Object.Destroy(extrudeClone);
			}
			_extrudeClones.Clear();
		}
	}
}
