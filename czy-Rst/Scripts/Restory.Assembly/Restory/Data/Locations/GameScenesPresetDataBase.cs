using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Restory.Data.Locations
{
	[CreateAssetMenu(fileName = "Create GameScenesPresetDataBase", menuName = "Restory/Data/GameScenesPresetDataBase", order = 0)]
	public class GameScenesPresetDataBase : ScriptableObject
	{
		[SerializeField]
		private List<GameScenesPreset> objects = new List<GameScenesPreset>();

		public IReadOnlyList<GameScenesPreset> All => objects;

		public GameScenesPreset this[string id] => objects.FirstOrDefault((GameScenesPreset x) => (bool)x && x.ID == id);

		public bool TryGetValue(string id, out GameScenesPreset gameEntity)
		{
			gameEntity = this[id];
			return gameEntity != null;
		}
	}
}
