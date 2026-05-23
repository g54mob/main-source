#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Data.FactoryFloor.Islands;
using Events;
using SFB;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.Island;
using UnityEngine;
using Utils;

namespace Data.FactoryFloor.Maps
{
	[CreateAssetMenu(menuName = "Factory/MapEditor/IslandsDatabase", fileName = "IslandsDatabase", order = 0)]
	public class IslandDatabase : ScriptableObject
	{
		private class SavedIsland
		{
			public IslandData IslandData;

			public IslandSaveData IslandSaveData;

			public string Path;
		}

		[SerializeField]
		private StringVariableSO _currentIslandWorkingPath;

		[SerializeField]
		private BaseEvent _disableInput;

		[SerializeField]
		private BaseEvent _enableInput;

		private readonly Dictionary<Guid, SavedIsland> _islandDatas = new Dictionary<Guid, SavedIsland>();

		public event Action<IslandData> NewIslandLoaded;

		public void TryLoadNewIslandFromFileSystem()
		{
			_disableInput.Fire();
			string directoryName = Path.GetDirectoryName(_currentIslandWorkingPath.Value);
			string[] array = StandaloneFileBrowser.OpenFilePanel("Load Island", directoryName, "json", multiselect: false);
			_enableInput.Fire();
			if (array != null && array.Length != 0)
			{
				string text = array[0];
				_currentIslandWorkingPath.SetValue(text);
				TryLoadIsland(text);
			}
		}

		public void TryLoadIsland(string path)
		{
			if (SaveSystem.TryLoadData<IslandSaveData>(path, out var data) && Guid.TryParse(data.Guid, out var result) && !_islandDatas.ContainsKey(result))
			{
				IslandData islandData = new IslandData(Path.GetFileNameWithoutExtension(path), result, data.Size);
				islandData.SetTexturePixels(data.FloorTextureColors);
				_islandDatas.Add(result, new SavedIsland
				{
					IslandData = islandData,
					IslandSaveData = data,
					Path = Path.GetRelativePath(Application.streamingAssetsPath, path)
				});
				this.NewIslandLoaded?.Invoke(islandData);
			}
		}

		public void TryLoadIsland(FactoryIslandSaveData islandSaveData)
		{
			if (!Guid.TryParse(islandSaveData.Guid, out var result) || _islandDatas.ContainsKey(result))
			{
				this.LogError("An island has an issue with it's Guid not parsing or already being loaded", "TryLoadIsland", 76);
				return;
			}
			IslandData islandData = new IslandData("Island", result, islandSaveData.Size);
			islandData.SetTexturePixels(islandSaveData.FloorTextureColors);
			_islandDatas.Add(result, new SavedIsland
			{
				IslandData = islandData,
				IslandSaveData = null,
				Path = "No path"
			});
			this.NewIslandLoaded?.Invoke(islandData);
		}

		public void Clear()
		{
			_islandDatas.Clear();
		}

		public IslandData GetIslandDataById(Guid id)
		{
			return _islandDatas.GetValueOrDefault(id)?.IslandData;
		}

		public IslandSaveData GetIslandSaveDataById(Guid id)
		{
			return _islandDatas.GetValueOrDefault(id)?.IslandSaveData;
		}

		public List<string> GetAllPaths()
		{
			return _islandDatas.Select((KeyValuePair<Guid, SavedIsland> x) => x.Value.Path).ToList();
		}

		public IEnumerable<IslandData> GetAllIslandDatas()
		{
			return _islandDatas.Select((KeyValuePair<Guid, SavedIsland> x) => x.Value.IslandData).Distinct();
		}

		public IEnumerable<IslandData> GetAllIslands()
		{
			return _islandDatas.Select((KeyValuePair<Guid, SavedIsland> x) => x.Value.IslandData).Distinct();
		}
	}
}
