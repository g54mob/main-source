using System.Collections.Generic;
using Data.FactoryFloor.Maps;
using Events;
using Events.FactoryFloor.Islands;
using Events.Generic;
using UnityEngine;

namespace Presentation.FactoryFloor.Islands
{
	public class IslandBuilder : MonoBehaviour
	{
		[SerializeField]
		private IslandConfigEvent _createIslandEvent;

		[SerializeField]
		private IslandObjectEvent _createIslandObjectEvent;

		[SerializeField]
		private IntEvent _deleteIslandEvent;

		[SerializeField]
		private UpdateIslandIdEvent _updateIslandIdEvent;

		[SerializeField]
		private UpdateIslandEvent _updateIslandEvent;

		[SerializeField]
		private IslandView _islandView;

		[SerializeField]
		private IslandView _gnnIslandView;

		[SerializeField]
		private BaseEvent _clearMapEvent;

		private readonly Dictionary<int, IslandView> _islands = new Dictionary<int, IslandView>();

		private void Awake()
		{
			_createIslandEvent.Register(CreateNewIsland);
			_createIslandObjectEvent.Register(CreateNewIsland);
			_deleteIslandEvent.Register(DeleteIsland);
			_updateIslandEvent.Register(UpdateIsland);
			_updateIslandIdEvent.Register(ChangeId);
			_clearMapEvent.Register(ClearMap);
		}

		private void ClearMap()
		{
			foreach (KeyValuePair<int, IslandView> island in _islands)
			{
				Object.Destroy(island.Value.gameObject);
			}
			_islands.Clear();
		}

		private void OnDestroy()
		{
			_createIslandEvent.UnRegister(CreateNewIsland);
			_createIslandObjectEvent.UnRegister(CreateNewIsland);
			_deleteIslandEvent.UnRegister(DeleteIsland);
			_updateIslandEvent.UnRegister(UpdateIsland);
			_updateIslandIdEvent.UnRegister(ChangeId);
			_clearMapEvent.UnRegister(ClearMap);
		}

		private void ChangeId(IdPair pair)
		{
			if (_islands.Remove(pair.OldId, out var value))
			{
				_islands.Add(pair.NewId, value);
			}
		}

		private void CreateNewIsland(IslandConfig islandConfig)
		{
			IslandView islandView = InstantiateIsland(islandConfig);
			islandView.SetConfig(islandConfig);
			_islands.Add(islandConfig.CreatedID, islandView);
		}

		private void CreateNewIsland(IslandObject islandObject)
		{
			IslandView islandView = InstantiateIsland(islandObject.IslandConfig);
			islandView.SetConfig(islandObject.IslandConfig);
			_islands.Add(islandObject.CreatedId, islandView);
			islandObject.SetIslandView(islandView);
		}

		private IslandView InstantiateIsland(IslandConfig islandConfig)
		{
			return Object.Instantiate(islandConfig.IsGNNGateIsland ? _gnnIslandView : _islandView);
		}

		private void DeleteIsland(int islandId)
		{
			if (_islands.Remove(islandId, out var value))
			{
				Object.Destroy(value.gameObject);
			}
		}

		private void UpdateIsland(UpdateIslandDto updateIslandDto)
		{
			_islands[updateIslandDto.CreatedId].UpdateValues(updateIslandDto);
		}
	}
}
