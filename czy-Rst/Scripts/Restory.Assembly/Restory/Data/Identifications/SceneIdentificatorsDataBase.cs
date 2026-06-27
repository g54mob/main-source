using System;
using System.Collections.Generic;
using System.Linq;
using Helpers.Extensions;
using Restory.TimeSystems;
using UnityEngine;

namespace Restory.Data.Identifications
{
	[CreateAssetMenu(menuName = "Restory/Data/Identificators/Create SceneIdentificatorsDataBase", fileName = "IdentificatorsDataBase - Scenes", order = 0)]
	public class SceneIdentificatorsDataBase : ScriptableObject
	{
		[SerializeField]
		private List<SceneObjectIdRecord> all = new List<SceneObjectIdRecord>();

		public bool TryGetValue(string id, out SceneObjectIdRecord result)
		{
			foreach (SceneObjectIdRecord item in all)
			{
				if (item.ID == id)
				{
					result = item;
					return true;
				}
			}
			result = null;
			return false;
		}

		public void Register(string id, GameObject gameObject)
		{
			if (HasAny(id))
			{
				Debug.LogError("[SceneIdentificatorsDataBase] can't add " + gameObject.name + ". Reason: object with ID \"" + id + "\" already registered");
			}
			else
			{
				SceneObjectIdRecord sceneObjectIdRecord = new SceneObjectIdRecord();
				sceneObjectIdRecord.ID = id;
				sceneObjectIdRecord.AssetName = gameObject.name;
				sceneObjectIdRecord.SceneName = gameObject.scene.name;
				sceneObjectIdRecord.FullPath = gameObject.GetFullPath();
				sceneObjectIdRecord.RegistrationDate = new UDateTime(DateTime.Now);
				all.Add(sceneObjectIdRecord);
			}
		}

		public bool HasAny(string id)
		{
			return all.Any((SceneObjectIdRecord x) => x.ID == id);
		}

		public void Clean()
		{
			all.Clear();
		}
	}
}
