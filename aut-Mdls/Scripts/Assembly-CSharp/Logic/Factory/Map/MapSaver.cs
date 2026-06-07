#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.Collections.Generic;
using System.IO;
using Data.FactoryFloor.Maps;
using Data.Variables;
using SFB;
using SaveData.FactoryFloor.Map;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Logic.Factory.Map
{
	[CreateAssetMenu(menuName = "Factory/Tools/Map/MapSaver", fileName = "MapSaver", order = 0)]
	public class MapSaver : ScriptableObject
	{
		[SerializeField]
		private IslandDatabase _islandsDatabase;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private InputActionAsset _input;

		[SerializeField]
		private StreamingAssetsPathVariableSO _currentMapWorkingStreamingAssetsPath;

		public void SaveCurrentMap()
		{
			MapSaveData data = new MapSaveData(GetIslands(), GetPaths());
			_input.Disable();
			string text;
			try
			{
				text = StandaloneFileBrowser.SaveFilePanel("Save Map", _currentMapWorkingStreamingAssetsPath.Value, "MapName", "json");
			}
			catch (Exception ex)
			{
				this.LogAssertion(ex.Message, "SaveCurrentMap", 35);
				_input.Enable();
				return;
			}
			_input.Enable();
			if (!string.IsNullOrEmpty(text))
			{
				SaveSystem.TrySaveData(data, text);
				_currentMapWorkingStreamingAssetsPath.SetValue(Path.GetDirectoryName(text));
			}
		}

		private List<string> GetPaths()
		{
			return _islandsDatabase.GetAllPaths();
		}

		private List<IslandInMapSaveData> GetIslands()
		{
			return _islandLayer.GetAllIslandsInMap();
		}
	}
}
