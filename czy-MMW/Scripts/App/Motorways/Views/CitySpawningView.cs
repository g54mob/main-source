using System.Collections.Generic;
using Client;
using Factory;
using Factory.Pools;
using Motorways.Models;
using UnityEngine;

namespace Motorways.Views
{
	public class CitySpawningView : MonoBehaviour, IReleasedFromScopeHandler, IReusable, IView
	{
		[Dependency]
		private City _city;

		[Dependency]
		private CityPlanModel _cityPlan;

		[SerializeField]
		private GameObject _tileGridsFolder;

		[SerializeField]
		private GameObject _buildingPlacementsFolder;

		private bool _hasSetName;

		private HashSet<int> _knownHouseGroupIds = new HashSet<int>();

		private HashSet<int> _knownDestinationGroupIds = new HashSet<int>();

		public void Reset()
		{
			_hasSetName = false;
			_knownHouseGroupIds.Clear();
			_knownDestinationGroupIds.Clear();
		}

		public void OnReleasedFromScope(IScope scope)
		{
			foreach (Transform item in _tileGridsFolder.transform)
			{
				Object.Destroy(item.gameObject);
			}
			foreach (Transform item2 in _buildingPlacementsFolder.transform)
			{
				Object.Destroy(item2.gameObject);
			}
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public void AddBuildingPlacementObject(GameObject buildingPlacementObject)
		{
			buildingPlacementObject.transform.SetParent(_buildingPlacementsFolder.transform);
		}

		private void AddTileMatrixObject(string name, TileMatrixInt tileMatrix, int minData, int maxData)
		{
			GameObject obj = new GameObject(name);
			TileMatrixView tileMatrixView = obj.AddComponent<TileMatrixView>();
			tileMatrixView.SourceMatrix = tileMatrix;
			tileMatrixView.SetTileColors(minData, maxData);
			obj.transform.SetParent(_tileGridsFolder.transform);
		}
	}
}
