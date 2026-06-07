using System.Collections.Generic;
using Data.Buildings;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Maps;
using Data.Variables;
using Logic.Threading.Events;
using UnityEngine;

namespace Data.FactoryFloor.Buildings
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/OverclockStationBehaviour", fileName = "OverclockStationBehaviour", order = 0)]
	public class OverclockStationBehaviour : FactoryObjectBehaviour
	{
		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private BuildingObjectDatabase _buildingObjectDatabase;

		[SerializeField]
		private List<float> _overclockMultiplierPerBuildingLevel = new List<float>();

		[SerializeField]
		private int _ticksForOverclockToRunOut = 1440;

		[SerializeField]
		private MainThreadBoolVariableSO _yellowMonumentIsChargedSO;

		private int _currentTimeUntilOverclockRunsOut;

		private BuildingBehaviour _buildingBehaviour;

		private IslandObject _islandObject;

		private readonly List<BuildingBehaviour> _overclockedBuildings = new List<BuildingBehaviour>();

		public MainThreadEvent OnOverclockActivationStart = new MainThreadEvent();

		public MainThreadEvent OnOverclockActivationEnd = new MainThreadEvent();

		public bool IsOverclockActive => _currentTimeUntilOverclockRunsOut > 0;

		public float OverclockTimePercentage => (float)_currentTimeUntilOverclockRunsOut / (float)_ticksForOverclockToRunOut;

		public IslandObject IslandObject => _islandObject;

		public List<BuildingBehaviour> OverclockedBuildings => _overclockedBuildings;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			_buildingBehaviour = factoryObject.GetFactoryObjectBehaviour<BuildingBehaviour>();
			_buildingBehaviour.OnStageCompleted.RegisterInline(HandleBuildingStageChanged);
			_buildingBehaviour.OnClearedResources.RegisterInline(OnClearedResources);
			_yellowMonumentIsChargedSO.ValueChanged.RegisterMainThread(OnIsMonumentChargedChanged);
			_islandLayer.TryGetIslandAtWorldPosition(factoryObject.Position, out _islandObject);
			IslandObject.OnObjectsOnIslandChanged += GetAllBuildingsWhenIslandIsUpdated;
			GetAllBuildingsOnIsland();
			HandleBuildingStageChanged(_buildingBehaviour.CurrentBuildingStage);
		}

		public override void UnInit()
		{
			_overclockedBuildings.Clear();
			_buildingBehaviour.OnStageCompleted.UnRegisterInline(HandleBuildingStageChanged);
			_buildingBehaviour.OnClearedResources.UnRegisterInline(OnClearedResources);
			_yellowMonumentIsChargedSO.ValueChanged.UnRegisterMainThread(OnIsMonumentChargedChanged);
			IslandObject.OnObjectsOnIslandChanged -= GetAllBuildingsWhenIslandIsUpdated;
			_islandObject.OverclockData.UnregisterOverclockStation(this);
			_islandObject.OverclockData.UnregisterActiveOverclockStation(this);
			_islandObject.OverclockData.ReCalculateOverclockMultiplier();
			base.UnInit();
		}

		private void GetAllBuildingsWhenIslandIsUpdated(IslandObject islandObject, FactoryLayer factoryLayer)
		{
			if (!(factoryLayer != _factoryLayer))
			{
				GetAllBuildingsOnIsland();
			}
		}

		private void GetAllBuildingsOnIsland()
		{
			_overclockedBuildings.Clear();
			foreach (BuildingObjectData buildingData in _buildingObjectDatabase.BuildingDatas)
			{
				foreach (FactoryObject objectsFromDatum in _islandObject.GetObjectsFromData(_factoryLayer, buildingData))
				{
					if (objectsFromDatum.TryGetFactoryObjectBehaviour<BuildingBehaviour>(out var behaviour) && behaviour.CanBeOverclocked)
					{
						_overclockedBuildings.Add(behaviour);
					}
				}
			}
		}

		public override void Process(int step)
		{
			if (_currentTimeUntilOverclockRunsOut > 0)
			{
				_currentTimeUntilOverclockRunsOut--;
				if (_currentTimeUntilOverclockRunsOut == 0)
				{
					_islandObject.OverclockData.UnregisterActiveOverclockStation(this);
					_islandObject.OverclockData.ReCalculateOverclockMultiplier();
					OnOverclockActivationEnd.Fire();
				}
			}
			base.Process(step);
		}

		public override void Update()
		{
		}

		private void OnIsMonumentChargedChanged(bool isCharged)
		{
			_currentTimeUntilOverclockRunsOut = 0;
			_islandObject.OverclockData.UnregisterActiveOverclockStation(this);
			_islandObject.OverclockData.ReCalculateOverclockMultiplier();
			OnOverclockActivationEnd.Fire();
			if (isCharged)
			{
				_buildingBehaviour.CheckIfAllRequirementsMet();
			}
		}

		private void OnClearedResources()
		{
			_currentTimeUntilOverclockRunsOut = _ticksForOverclockToRunOut;
			_islandObject.OverclockData.RegisterActiveOverclockStation(this);
			_islandObject.OverclockData.ReCalculateOverclockMultiplier();
			OnOverclockActivationStart.Fire();
		}

		private void HandleBuildingStageChanged(int stage)
		{
			_islandObject.OverclockData.ReCalculateOverclockMultiplier();
			_islandObject.OverclockData.RegisterOverclockStation(this);
		}

		public float GetOverclockMultiplier()
		{
			if (_buildingBehaviour.CurrentBuildingStage <= 0)
			{
				return 1f;
			}
			int index = Mathf.Min(_buildingBehaviour.CurrentBuildingStage - 1, _overclockMultiplierPerBuildingLevel.Count - 1);
			return _overclockMultiplierPerBuildingLevel[index];
		}
	}
}
