using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using ES3Internal;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class GameObjectSaver : CTSBehaviour
	{
		[Serializable]
		public struct SaveData
		{
			public string Key;

			public bool InitLoad;

			public bool PostLoad;
		}

		[Serializable]
		public class SaveDictionary : SerializableDictionaryBase<Component, SaveData>
		{
			[Serializable]
			public struct ComponentSave
			{
				public Component Component;

				public SaveData Data;

				public ComponentSave(Component component, SaveData data)
				{
					Component = component;
					Data = data;
				}
			}

			[SerializeField]
			private List<ComponentSave> _list = new List<ComponentSave>();

			public ReadOnlyList<ComponentSave> SaveList => _list;

			protected override Component GetKeyAtIndex(int index)
			{
				return _list[index].Component;
			}

			protected override SaveData GetValueAtIndex(int index)
			{
				return _list[index].Data;
			}

			protected override int GetListCount()
			{
				return _list.Count;
			}

			protected override void SetKeyAndValueAtIndex(int index, Component key, SaveData value)
			{
				_list[index] = new ComponentSave(key, value);
			}

			protected override void AddKeyAndValue(Component key, SaveData value)
			{
				_list.Add(new ComponentSave(key, value));
			}

			protected override void RemoveAtIndex(int index)
			{
				_list.RemoveAt(index);
			}

			protected override void ClearList()
			{
				_list.Clear();
			}
		}

		[Serializable]
		private struct WorldTransformSave
		{
			public Vector3 Position;

			public Vector3 Rotation;

			public WorldTransformSave(Transform transform)
			{
				Position = transform.position;
				Rotation = transform.eulerAngles;
			}

			public void ApplyTo(Transform transform)
			{
				transform.SetPositionAndRotation(Position, Quaternion.Euler(Rotation));
				transform.SetParent(null);
			}
		}

		[SerializeField]
		private bool _saveTransform = true;

		[SerializeField]
		[ShowIf("_saveTransform")]
		private bool _transformInLocalSpace = true;

		[SerializeField]
		private ES3RefIdDictionary _localRefs = new ES3RefIdDictionary();

		[SerializeField]
		private SaveDictionary _componentsToSave = new SaveDictionary();

		public bool ShouldSaveTransform => _saveTransform;

		public bool SaveTransformInLocalSpace => _transformInLocalSpace;

		public ReadOnlyList<SaveDictionary.ComponentSave> ComponentsToSave => _componentsToSave.SaveList;
	}
}
