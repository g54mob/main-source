using System.Collections.Generic;
using System.Linq;
using Restory.Data.Base;
using UnityEngine;

namespace Restory.Data.GameEntities
{
	public class GameEntityDataBase : ScriptableObject
	{
		[SerializeField]
		private List<RestoryEntityInfoBase> objects = new List<RestoryEntityInfoBase>();

		public IReadOnlyList<RestoryEntityInfoBase> All => objects;

		public RestoryEntityInfoBase this[string id] => objects.FirstOrDefault((RestoryEntityInfoBase x) => (bool)x && x.ID == id);

		public bool TryGetValue(string id, out RestoryEntityInfoBase gameEntity)
		{
			gameEntity = this[id];
			return gameEntity != null;
		}

		public bool TryToGetEntityInfo<T>(string entityID, out T entityInfo) where T : RestoryEntityInfoBase
		{
			entityInfo = null;
			if (!TryGetValue(entityID, out var gameEntity) || !(gameEntity is T val))
			{
				return false;
			}
			entityInfo = val;
			return true;
		}
	}
}
