#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using Data.Buildings;
using Data.FactoryFloor;
using Data.FactoryFloor.Islands;
using Data.FactoryFloor.Resources;
using Data.FeatureFlags;
using NaughtyAttributes;
using Presentation.FactoryFloor.Toolbar;
using UnityEngine;
using Utils;

namespace Data.Operator
{
	[CreateAssetMenu(menuName = "Factory/FactoryObjectDatabase", fileName = "FactoryObjectDatabase", order = 0)]
	public class FactoryObjectDatabase : ScriptableObject
	{
		public List<FactoryObjectData> FactoryObjectsData = new List<FactoryObjectData>();

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		[SerializeField]
		private Data.FeatureFlags.FeatureFlags _featureFlags;

		[SerializeField]
		private BuildingObjectDatabase _buildingsObjectDataDefault;

		[SerializeField]
		private DecorationsObjectDatabase _decorationsObjectDatabase;

		[SerializeField]
		private EnvironmentObjectsDatabase _environmentObjectsDatabase;

		[SerializeField]
		private OperatorBarDatabaseCollection _operatorBarDatabaseCollection;

		[SerializeField]
		private FactoryObjectBlockedInDemoDatabase _factoryObjectBlockedInDemoDatabase;

		private readonly Dictionary<int, FactoryObjectData> _allFactoryObjectsData = new Dictionary<int, FactoryObjectData>();

		public BuildingObjectDatabase BuildingsObjectData => _buildingsObjectDataDefault;

		public DecorationsObjectDatabase DecorationsObjectDatabase => _decorationsObjectDatabase;

		public EnvironmentObjectsDatabase EnvironmentObjectsDatabase => _environmentObjectsDatabase;

		public OperatorBarDatabaseCollection OperatorBarDatabaseCollection => _operatorBarDatabaseCollection;

		public IEnumerable<FactoryObjectData> AllFactoryObjectsData => _allFactoryObjectsData.Values;

		private void OnValidate()
		{
			RefreshObjectsList();
		}

		private void Awake()
		{
			RefreshObjectsList();
		}

		[Button(null, EButtonEnableMode.Always)]
		public void RefreshObjectsList()
		{
			_allFactoryObjectsData.Clear();
			foreach (FactoryObjectData factoryObjectsDatum in FactoryObjectsData)
			{
				if (!(factoryObjectsDatum == null) && !_factoryObjectBlockedInDemoDatabase.IsFactoryObjectDataBlockedInDemo(factoryObjectsDatum))
				{
					if (_allFactoryObjectsData.ContainsKey(factoryObjectsDatum.ID))
					{
						this.LogError($"{factoryObjectsDatum.name}'s ID {factoryObjectsDatum.ID} is already used by {_allFactoryObjectsData[factoryObjectsDatum.ID].name}", "RefreshObjectsList", 68);
					}
					else
					{
						_allFactoryObjectsData.Add(factoryObjectsDatum.ID, factoryObjectsDatum);
					}
				}
			}
			if (BuildingsObjectData != null)
			{
				foreach (BuildingObjectData buildingData in BuildingsObjectData.BuildingDatas)
				{
					if (!_factoryObjectBlockedInDemoDatabase.IsFactoryObjectDataBlockedInDemo(buildingData) && !(buildingData == null))
					{
						if (_allFactoryObjectsData.ContainsKey(buildingData.ID))
						{
							this.LogError($"{buildingData.name}'s ID {buildingData.ID} is already used by {_allFactoryObjectsData[buildingData.ID].name}", "RefreshObjectsList", 89);
						}
						else
						{
							_allFactoryObjectsData.Add(buildingData.ID, buildingData);
						}
					}
				}
			}
			if (_decorationsObjectDatabase != null)
			{
				foreach (FactoryObjectData decorationData in _decorationsObjectDatabase.DecorationDatas)
				{
					if (!_factoryObjectBlockedInDemoDatabase.IsFactoryObjectDataBlockedInDemo(decorationData))
					{
						_allFactoryObjectsData.Add(decorationData.ID, decorationData);
					}
				}
			}
			if (_environmentObjectsDatabase != null)
			{
				foreach (FactoryObjectData allFactoryObjectData in _environmentObjectsDatabase.GetAllFactoryObjectDatas())
				{
					if (!_factoryObjectBlockedInDemoDatabase.IsFactoryObjectDataBlockedInDemo(allFactoryObjectData))
					{
						_allFactoryObjectsData.TryAdd(allFactoryObjectData.ID, allFactoryObjectData);
					}
				}
			}
			UpdateRelativePositions();
		}

		public FactoryObjectData GetObjectDataWithId(int id)
		{
			return _allFactoryObjectsData.GetValueOrDefault(id);
		}

		public bool TryGetObjectDataWithId(int id, out FactoryObjectData factoryObjectData)
		{
			if (!_allFactoryObjectsData.TryGetValue(id, out var value))
			{
				this.LogError($"Failed getting {id} from the factory object database!", "TryGetObjectDataWithId", 137);
				factoryObjectData = null;
				return false;
			}
			factoryObjectData = value;
			return true;
		}

		[Button(null, EButtonEnableMode.Always)]
		private void UpdateRelativePositions()
		{
			foreach (FactoryObjectData allFactoryObjectsDatum in AllFactoryObjectsData)
			{
				if (!(allFactoryObjectsDatum == null))
				{
					allFactoryObjectsDatum.UpdateRelativePositions();
					allFactoryObjectsDatum.UpdateIndex();
				}
			}
		}

		public void AddFactoryObject(FactoryObjectData factoryObjectData)
		{
			FactoryObjectsData.Add(factoryObjectData);
			factoryObjectData.UpdateRelativePositions();
			factoryObjectData.UpdateIndex();
		}
	}
}
