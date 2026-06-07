using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV;
using DV.Logic.Job;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.Utils;
using UnityEngine;

public class LogicController : SingletonBehaviour<LogicController>
{
	public Dictionary<WarehouseMachine, WarehouseMachineController> LogicWarehouseMachineToWarehouseMachineController;

	public Dictionary<string, StationController> YardIdToStationController;

	private Dictionary<StationController, HashSet<TrainCarType_v2>> stationToSupportedCarTypes;

	public bool initialized;

	public new static string AllowAutoCreate()
	{
		return null;
	}

	protected override void Awake()
	{
		base.Awake();
		StationController[] array = Object.FindObjectsOfType<StationController>();
		YardIdToStationController = new Dictionary<string, StationController>();
		stationToSupportedCarTypes = new Dictionary<StationController, HashSet<TrainCarType_v2>>();
		StationController[] array2 = array;
		foreach (StationController stationController in array2)
		{
			YardIdToStationController.Add(stationController.stationInfo.YardID, stationController);
			stationToSupportedCarTypes.Add(stationController, GetCarTypesThatStationUses(stationController));
		}
	}

	private HashSet<TrainCarType_v2> GetCarTypesThatStationUses(StationController stationController)
	{
		List<CargoGroup> outputCargoGroups = stationController.proceduralJobsRuleset.outputCargoGroups;
		if (outputCargoGroups == null || outputCargoGroups.Count == 0)
		{
			return new HashSet<TrainCarType_v2>();
		}
		return new HashSet<TrainCarType_v2>(outputCargoGroups.SelectMany((CargoGroup cargoGroup) => cargoGroup.cargoTypes).Distinct().SelectMany((CargoType cargoType) => Globals.G.Types.CargoToLoadableCarTypes[cargoType.ToV2()])
			.Distinct());
	}

	private IEnumerator Start()
	{
		yield return null;
		yield return null;
		LogicWarehouseMachineToWarehouseMachineController = new Dictionary<WarehouseMachine, WarehouseMachineController>();
		foreach (WarehouseMachineController allController in WarehouseMachineController.allControllers)
		{
			LogicWarehouseMachineToWarehouseMachineController.Add(allController.warehouseMachine, allController);
		}
		initialized = true;
	}

	public List<StationController> GetStationsThatUseCarTypes(HashSet<TrainCarType_v2> carTypesSet, StationController stationToIgnore)
	{
		List<StationController> list = new List<StationController>();
		if (carTypesSet.Count == 0)
		{
			return list;
		}
		foreach (KeyValuePair<StationController, HashSet<TrainCarType_v2>> stationToSupportedCarType in stationToSupportedCarTypes)
		{
			if (!(stationToSupportedCarType.Key == stationToIgnore) && stationToSupportedCarType.Value.IsSupersetOf(carTypesSet))
			{
				list.Add(stationToSupportedCarType.Key);
			}
		}
		return list;
	}
}
