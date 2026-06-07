using System.Collections.Generic;
using System.Linq;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

namespace DV.Logic.Job
{
	public class Yard
	{
		public readonly List<Track> StorageTracks;

		public readonly List<Track> TransferInTracks;

		public readonly List<Track> TransferOutTracks;

		public readonly List<WarehouseMachine> WarehouseMachines;

		public Yard(List<Track> storageTracks, List<Track> transferInTracks, List<Track> transferOutTracks, List<WarehouseMachine> warehouseMachines, string stationID)
		{
			StorageTracks = storageTracks;
			TransferInTracks = transferInTracks;
			TransferOutTracks = transferOutTracks;
			WarehouseMachines = warehouseMachines;
			for (int i = 0; i < WarehouseMachines.Count; i++)
			{
				WarehouseMachines[i].ID = $"{stationID}-{i}";
			}
			if (AnyYardTrackHasGenericID())
			{
				Debug.LogWarning("Overriding TrackIds for yard tracks of station " + stationID + ", because they had generic ID. Tracks will have default yard IDs.");
				OverrideTrackIDsWithDefaultYardIDs(stationID);
			}
			InitializeYardTracksOrganizer();
		}

		private void InitializeYardTracksOrganizer()
		{
			foreach (Track allYardTrack in GetAllYardTracks())
			{
				SingletonBehaviour<YardTracksOrganizer>.Instance.InitializeYardTrack(allYardTrack);
				SingletonBehaviour<YardTracksOrganizer>.Instance.yardTrackIdToTrack.Add(allYardTrack.ID.FullID, allYardTrack);
			}
		}

		private bool AnyYardTrackHasGenericID()
		{
			foreach (Track allYardTrack in GetAllYardTracks())
			{
				if (allYardTrack.ID.IsGeneric())
				{
					return true;
				}
			}
			return false;
		}

		private void OverrideTrackIDsWithDefaultYardIDs(string stationID)
		{
			OverrideTrackIDs(stationID, "A", StorageTracks, "S");
			OverrideTrackIDs(stationID, "B", TransferInTracks, "I");
			OverrideTrackIDs(stationID, "C", TransferOutTracks, "O");
			List<Track> tracks = WarehouseMachines.Select((WarehouseMachine warehouseMachine) => warehouseMachine.WarehouseTrack).Distinct().ToList();
			OverrideTrackIDs(stationID, "D", tracks, "L");
			void OverrideTrackIDs(string stationId, string subYardId, List<Track> list, string trackType)
			{
				for (int i = 0; i < list.Count; i++)
				{
					list[i].OverrideTrackID(new TrackID(stationId, subYardId, (i + 1).ToString(), trackType));
				}
			}
		}

		public List<WarehouseMachine> GetWarehouseMachinesThatSupportCargoTypes(List<CargoType> cargoTypes)
		{
			List<WarehouseMachine> list = new List<WarehouseMachine>();
			for (int i = 0; i < WarehouseMachines.Count; i++)
			{
				bool flag = true;
				for (int j = 0; j < cargoTypes.Count; j++)
				{
					if (!WarehouseMachines[i].IsCargoSupported(cargoTypes[j]))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					list.Add(WarehouseMachines[i]);
				}
			}
			return list;
		}

		public IEnumerable<Track> GetAllYardTracks()
		{
			IEnumerable<Track> second = WarehouseMachines.Select((WarehouseMachine warehouseMachine) => warehouseMachine.WarehouseTrack).Distinct();
			return StorageTracks.Union(TransferInTracks).Union(TransferOutTracks).Union(second);
		}
	}
}
