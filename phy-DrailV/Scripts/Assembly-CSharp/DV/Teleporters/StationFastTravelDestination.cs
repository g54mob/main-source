using System.Collections.Generic;
using System.Linq;
using DV.Localization;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

namespace DV.Teleporters
{
	public class StationFastTravelDestination : FastTravelDestination
	{
		private StationController _stationController;

		public StationController StationController
		{
			get
			{
				if (_stationController == null)
				{
					_stationController = base.gameObject.GetComponentInParent<StationController>();
				}
				return _stationController;
			}
		}

		public override string MarkerName => LocalizationAPI.L(StationController?.stationInfo.LocalizationKey);

		public override bool IsDynamic => false;

		public static StationFastTravelDestination GetClosestStationTeleporterWithPlayerLicensedLoco(Vector3 positionToCheck)
		{
			LicenseManager lm = SingletonBehaviour<LicenseManager>.Instance;
			List<StationFastTravelDestination> list = new List<StationFastTravelDestination>();
			foreach (FastTravelDestination activeDestination in FastTravelDestination.ActiveDestinations)
			{
				if (!(activeDestination is StationFastTravelDestination stationFastTravelDestination))
				{
					continue;
				}
				StationLocoSpawner[] componentsInChildren = stationFastTravelDestination.transform.parent.GetComponentsInChildren<StationLocoSpawner>();
				if (componentsInChildren.Length == 0)
				{
					continue;
				}
				StationLocoSpawner[] array = componentsInChildren;
				foreach (StationLocoSpawner stationLocoSpawner in array)
				{
					List<TrainCarLivery> locoTypesCurrentlyOnSpawnTrack = stationLocoSpawner.GetLocoTypesCurrentlyOnSpawnTrack();
					if (locoTypesCurrentlyOnSpawnTrack.Count > 0)
					{
						if (locoTypesCurrentlyOnSpawnTrack.Any((TrainCarLivery locoType) => lm.IsLicensedForCar(locoType)))
						{
							list.Add(stationFastTravelDestination);
							break;
						}
					}
					else if (stationLocoSpawner.GetNextSpawnLocoList().TrueForAll((TrainCarLivery carType) => lm.IsLicensedForCar(carType)))
					{
						list.Add(stationFastTravelDestination);
						break;
					}
				}
			}
			return GetClosestStationTeleporter(list, positionToCheck);
		}

		public static StationFastTravelDestination GetClosestStationTeleporter(List<StationFastTravelDestination> stationTeleporters, Vector3 positionToCheck)
		{
			if (stationTeleporters.Count == 0)
			{
				return null;
			}
			float num = (stationTeleporters[0].playerTeleportAnchor.position - positionToCheck).sqrMagnitude;
			int index = 0;
			for (int i = 1; i < stationTeleporters.Count; i++)
			{
				float sqrMagnitude = (stationTeleporters[i].playerTeleportAnchor.position - positionToCheck).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					index = i;
				}
			}
			return stationTeleporters[index];
		}
	}
}
