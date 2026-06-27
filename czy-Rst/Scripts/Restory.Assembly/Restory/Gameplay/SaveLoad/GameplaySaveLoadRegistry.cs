using System;
using System.Collections.Generic;
using Restory.Data.Identifications;
using Restory.Gameplay.SaveLoad.Services;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.SaveLoad
{
	public class GameplaySaveLoadRegistry : MonoBehaviour, IGameplaySaveLoadRegistry, IInitializable, IDisposable
	{
		private Dictionary<GameObject, SaveLoadGameObjectRecord> all = new Dictionary<GameObject, SaveLoadGameObjectRecord>();

		private List<SaveableEntity> cachedSaveables = new List<SaveableEntity>();

		public IReadOnlyCollection<SaveLoadGameObjectRecord> All => all.Values;

		public void Initialize()
		{
			SaveableEntity[] array = UnityEngine.Object.FindObjectsByType<SaveableEntity>(FindObjectsInactive.Include, FindObjectsSortMode.None);
			foreach (SaveableEntity saveableEntity in array)
			{
				saveableEntity.Initialize();
				GameObject gameObject = saveableEntity.gameObject;
				SaveLoadGameObjectRecord value = new SaveLoadGameObjectRecord
				{
					GameObject = gameObject,
					Name = gameObject.name,
					SaveableEntity = saveableEntity,
					Identificator = gameObject.GetComponent<Identificator>()
				};
				all[gameObject] = value;
			}
		}

		public void Register(GameObject objectToAdd)
		{
			objectToAdd.GetComponentsInChildren(includeInactive: true, cachedSaveables);
			foreach (SaveableEntity cachedSaveable in cachedSaveables)
			{
				cachedSaveable.Initialize();
				GameObject gameObject = cachedSaveable.gameObject;
				SaveLoadGameObjectRecord value = new SaveLoadGameObjectRecord
				{
					GameObject = gameObject,
					Name = gameObject.name,
					SaveableEntity = cachedSaveable,
					Identificator = gameObject.GetComponent<Identificator>()
				};
				all[gameObject] = value;
			}
		}

		public void Dispose()
		{
			cachedSaveables.Clear();
			all.Clear();
		}

		public void Unregister(GameObject objectToRemove)
		{
			objectToRemove.GetComponentsInChildren(includeInactive: true, cachedSaveables);
			foreach (SaveableEntity cachedSaveable in cachedSaveables)
			{
				all.Remove(cachedSaveable.gameObject);
			}
		}
	}
}
