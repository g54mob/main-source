using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class DuplicateObjectsAction : IUndoRedoAction
	{
		private List<GameObject> _rootsToDuplicate;

		private List<GameObject> _duplicateResult = new List<GameObject>();

		private bool _cleanupOnRemovedFromStack;

		public List<GameObject> DuplicateResult => new List<GameObject>(_duplicateResult);

		public DuplicateObjectsAction(List<GameObject> rootsToDuplicate)
		{
			_rootsToDuplicate = GameObjectEx.FilterParentsOnly(rootsToDuplicate);
		}

		public void Execute()
		{
			if (_rootsToDuplicate.Count == 0)
			{
				return;
			}
			ObjectCloning.Config defaultConfig = ObjectCloning.DefaultConfig;
			foreach (GameObject item2 in _rootsToDuplicate)
			{
				Transform transform = item2.transform;
				defaultConfig.Layer = item2.layer;
				defaultConfig.Parent = transform.parent;
				GameObject item = ObjectCloning.CloneHierarchy(item2, defaultConfig);
				_duplicateResult.Add(item);
			}
			if (MonoSingleton<RTObjectSelection>.Get.CanBeModifiedByAPI())
			{
				MonoSingleton<RTObjectSelection>.Get.SetSelectedObjects(_duplicateResult, allowUndoRedo: false);
			}
			MonoSingleton<RTUndoRedo>.Get.RecordAction(this);
		}

		public void Undo()
		{
			if (_duplicateResult == null)
			{
				return;
			}
			foreach (GameObject item in _duplicateResult)
			{
				item.SetActive(value: false);
			}
			if (MonoSingleton<RTObjectSelection>.Get.CanBeModifiedByAPI())
			{
				MonoSingleton<RTObjectSelection>.Get.SetSelectedObjects(_rootsToDuplicate, allowUndoRedo: false);
			}
			_cleanupOnRemovedFromStack = true;
		}

		public void Redo()
		{
			if (_duplicateResult == null)
			{
				return;
			}
			foreach (GameObject item in _duplicateResult)
			{
				item.SetActive(value: true);
			}
			if (MonoSingleton<RTObjectSelection>.Get.CanBeModifiedByAPI())
			{
				MonoSingleton<RTObjectSelection>.Get.SetSelectedObjects(_duplicateResult, allowUndoRedo: false);
			}
			_cleanupOnRemovedFromStack = false;
		}

		public void OnRemovedFromUndoRedoStack()
		{
			if (!_cleanupOnRemovedFromStack || _duplicateResult.Count == 0)
			{
				return;
			}
			foreach (GameObject item in _duplicateResult)
			{
				Object.Destroy(item);
			}
			_duplicateResult.Clear();
		}
	}
}
