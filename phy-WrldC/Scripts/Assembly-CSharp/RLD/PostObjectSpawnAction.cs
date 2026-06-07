using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class PostObjectSpawnAction : IUndoRedoAction
	{
		private bool _cleanupOnRemovedFromStack;

		private List<GameObject> _spawnedParents = new List<GameObject>();

		public PostObjectSpawnAction(List<GameObject> spawnedParents)
		{
			_spawnedParents = new List<GameObject>(spawnedParents);
		}

		public void Execute()
		{
			MonoSingleton<RTUndoRedo>.Get.RecordAction(this);
		}

		public void Undo()
		{
			if (_spawnedParents == null)
			{
				return;
			}
			foreach (GameObject spawnedParent in _spawnedParents)
			{
				spawnedParent.SetActive(value: false);
			}
			_cleanupOnRemovedFromStack = true;
		}

		public void Redo()
		{
			if (_spawnedParents == null)
			{
				return;
			}
			foreach (GameObject spawnedParent in _spawnedParents)
			{
				spawnedParent.SetActive(value: true);
			}
			_cleanupOnRemovedFromStack = false;
		}

		public void OnRemovedFromUndoRedoStack()
		{
			if (!_cleanupOnRemovedFromStack || _spawnedParents.Count == 0)
			{
				return;
			}
			foreach (GameObject spawnedParent in _spawnedParents)
			{
				Object.Destroy(spawnedParent);
			}
			_spawnedParents.Clear();
		}
	}
}
