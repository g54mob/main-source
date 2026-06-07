using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

public class StationControllersTrackSetup : MonoBehaviour
{
	private const string CONNECTING_TRACKS_MARK_TO_IGNORE = "--";

	[Header("Excluded track types from assignment")]
	public bool skipStorageTracks;

	public bool skipRegularInTracks;

	public bool skipRegularOutTracks;

	public bool skipLoadingTracks;

	public bool skipParkingTracks;

	private List<string> unusedTrackMarks = new List<string> { "M", "SP", "LP" };

	[InspectorButton("Execute", true, true)]
	public bool assignStationTracksNamesFromRailTrackNames;

	[InspectorButton("Validate", true, true)]
	public bool validateSetReferences;

	private void Execute()
	{
		List<RailTrack> list = (from rt in UnityEngine.Object.FindObjectsOfType<RailTrack>()
			where rt.name.StartsWith("[Y]")
			select rt).ToList();
		foreach (string unusedTrackMark in unusedTrackMarks)
		{
			RemoveTracksOfType(list, unusedTrackMark);
		}
		RemoveTracksWithConnectingTrackMark(list);
		RemoveSkippedTracks(list);
		int count = list.Count;
		foreach (StationController item in UnityEngine.Object.FindObjectsOfType<StationController>().ToList())
		{
			SetupStation(item, list);
			PrintStationTracks(item);
		}
		Debug.Log("Excluded track types from assignment:" + (skipStorageTracks ? "S, " : string.Empty) + (skipRegularInTracks ? "I, " : string.Empty) + (skipRegularOutTracks ? "O, " : string.Empty) + (skipLoadingTracks ? "L, " : string.Empty) + (skipParkingTracks ? "P, " : string.Empty));
		if (list.Count != 0)
		{
			Debug.LogWarning($"{list.Count} out of {count} tracks weren't assigned to any stations:");
			{
				foreach (RailTrack item2 in list)
				{
					Debug.LogWarning("  " + item2.name, item2);
				}
				return;
			}
		}
		Debug.Log($"All {count} tracks were assigned to stations");
	}

	private void RemoveSkippedTracks(List<RailTrack> yardTracks)
	{
		if (skipStorageTracks)
		{
			RemoveTracksOfType(yardTracks, "S");
		}
		if (skipRegularInTracks)
		{
			RemoveTracksOfType(yardTracks, "I");
		}
		if (skipRegularOutTracks)
		{
			RemoveTracksOfType(yardTracks, "O");
		}
		if (skipLoadingTracks)
		{
			RemoveTracksOfType(yardTracks, "L");
		}
		if (skipParkingTracks)
		{
			RemoveTracksOfType(yardTracks, "P");
		}
	}

	private void Validate()
	{
		List<RailTrack> list = (from rt in UnityEngine.Object.FindObjectsOfType<RailTrack>()
			where rt.name.StartsWith("[Y]")
			select rt).ToList();
		foreach (string unusedTrackMark in unusedTrackMarks)
		{
			RemoveTracksOfType(list, unusedTrackMark);
		}
		RemoveTracksWithConnectingTrackMark(list);
		int count = list.Count;
		List<StationController> list2 = UnityEngine.Object.FindObjectsOfType<StationController>().ToList();
		Dictionary<string, List<UnityEngine.Object>> dictionary = new Dictionary<string, List<UnityEngine.Object>>();
		foreach (StationController item in list2)
		{
			PrintStationTracks(item);
			DuplicatesCheck(item, dictionary);
			MissingTrackNamesCheck(item, list);
			NullOrEmptyTrackNamesCheck(item, list);
			TrackAssignmentCheck(item, list);
		}
		foreach (string key in dictionary.Keys)
		{
			if (dictionary[key].Count <= 1)
			{
				continue;
			}
			Debug.LogWarning($"Multiple referencing ({dictionary[key].Count}) of track name {key}:");
			foreach (UnityEngine.Object item2 in dictionary[key])
			{
				Debug.Log(key + " is referenced by: " + item2.name, item2);
			}
		}
		if (list.Count != 0)
		{
			Debug.LogWarning(string.Format("{0} out of {1} tracks weren't assigned to any {2} / {3} / {4}:", list.Count, count, "StationController", "WarehouseMachineController", "StationLocoSpawner"));
			{
				foreach (RailTrack item3 in list)
				{
					Debug.LogWarning("  " + item3.name, item3);
				}
				return;
			}
		}
		Debug.Log($"All {count} tracks were assigned to stations");
	}

	private void RemoveTracksOfType(List<RailTrack> railTracks, string trackTypeToRemove)
	{
		Regex re = new Regex("\\[Y\\]_\\[[a-z0-9]*\\]_\\[[a-z0-9]+-(\\d+)-" + trackTypeToRemove + "\\]", RegexOptions.IgnoreCase);
		railTracks.RemoveAll((RailTrack t) => re.Match(t.name).Success);
	}

	private void RemoveTracksWithConnectingTrackMark(List<RailTrack> railTracks)
	{
		Regex re = new Regex("\\[Y\\]_\\[[a-z0-9]*\\]_\\[--\\]", RegexOptions.IgnoreCase);
		railTracks.RemoveAll((RailTrack t) => re.Match(t.name).Success);
	}

	private void NullOrEmptyTrackNamesCheck(StationController station, List<RailTrack> yardTracks)
	{
		int countOfNullOrEmpty = GetCountOfNullOrEmpty(station.storageRailtracksGONames);
		if (countOfNullOrEmpty > 0)
		{
			Debug.LogError(string.Format("There are {0} uninitialized {1} in station {2}!", countOfNullOrEmpty, "storageRailtracksGONames", station.stationInfo.YardID), station);
		}
		int countOfNullOrEmpty2 = GetCountOfNullOrEmpty(station.transferInRailtracksGONames);
		if (countOfNullOrEmpty2 > 0)
		{
			Debug.LogError(string.Format("There are {0} uninitialized {1} in station {2}!", countOfNullOrEmpty2, "transferInRailtracksGONames", station.stationInfo.YardID), station);
		}
		int countOfNullOrEmpty3 = GetCountOfNullOrEmpty(station.transferOutRailtracksGONames);
		if (countOfNullOrEmpty3 > 0)
		{
			Debug.LogError(string.Format("There are {0} uninitialized {1} in station {2}!", countOfNullOrEmpty3, "transferOutRailtracksGONames", station.stationInfo.YardID), station);
		}
		List<string> trackNames = station.warehouseMachineControllers.Select((WarehouseMachineController w) => w.warehouseTrackName).ToList();
		int countOfNullOrEmpty4 = GetCountOfNullOrEmpty(trackNames);
		if (countOfNullOrEmpty4 > 0)
		{
			Debug.LogError(string.Format("There are {0} uninitialized {1} in station {2}!", countOfNullOrEmpty4, "WarehouseMachineController", station.stationInfo.YardID), station);
		}
		List<string> trackNames2 = (from spawner in station.GetComponentsInChildren<StationLocoSpawner>()
			select spawner.locoSpawnTrackName).ToList();
		int countOfNullOrEmpty5 = GetCountOfNullOrEmpty(trackNames2);
		if (countOfNullOrEmpty5 > 0)
		{
			Debug.LogError(string.Format("There are {0} uninitialized {1} in station {2}!", countOfNullOrEmpty5, "StationLocoSpawner", station.stationInfo.YardID), station);
		}
	}

	private void CheckMissingTracks(StationController station, List<string> trackNamesToCheck, List<string> yardTracksNames, string trackTypeMessage)
	{
		foreach (string item in trackNamesToCheck.Where((string trackName) => !yardTracksNames.Contains(trackName)))
		{
			Debug.LogError(trackTypeMessage + " track with name " + item + ", which is part of " + station.name + ", doesn't exist! Track won't be found, fix it!", station);
		}
	}

	private void MissingTrackNamesCheck(StationController station, List<RailTrack> yardTracks)
	{
		List<string> yardTracksNames = yardTracks.Select((RailTrack yardTrack) => yardTrack.name).ToList();
		CheckMissingTracks(station, station.storageRailtracksGONames, yardTracksNames, "Storage");
		CheckMissingTracks(station, station.transferInRailtracksGONames, yardTracksNames, "TransferInRegular");
		CheckMissingTracks(station, station.transferOutRailtracksGONames, yardTracksNames, "TransferOutRegular");
		List<string> trackNamesToCheck = station.warehouseMachineControllers.Select((WarehouseMachineController w) => w.warehouseTrackName).ToList();
		CheckMissingTracks(station, trackNamesToCheck, yardTracksNames, "Warehouse");
		List<string> trackNamesToCheck2 = (from spawner in station.GetComponentsInChildren<StationLocoSpawner>()
			select spawner.locoSpawnTrackName).ToList();
		CheckMissingTracks(station, trackNamesToCheck2, yardTracksNames, "Loco spawner");
	}

	private void DuplicatesCheck(StationController station, Dictionary<string, List<UnityEngine.Object>> referencedNames)
	{
		Action<List<string>, UnityEngine.Object> action = delegate(List<string> trackNames, UnityEngine.Object referencingObject)
		{
			foreach (string trackName in trackNames)
			{
				if (trackName != null)
				{
					if (referencedNames.ContainsKey(trackName))
					{
						referencedNames[trackName].Add(referencingObject);
					}
					else
					{
						referencedNames.Add(trackName, new List<UnityEngine.Object>());
						referencedNames[trackName].Add(referencingObject);
					}
				}
			}
		};
		action(station.storageRailtracksGONames, station);
		action(station.transferInRailtracksGONames, station);
		action(station.transferOutRailtracksGONames, station);
		foreach (WarehouseMachineController warehouseMachineController in station.warehouseMachineControllers)
		{
			action(new List<string> { warehouseMachineController.warehouseTrackName }, warehouseMachineController);
		}
		StationLocoSpawner[] componentsInChildren = station.GetComponentsInChildren<StationLocoSpawner>();
		foreach (StationLocoSpawner stationLocoSpawner in componentsInChildren)
		{
			action(new List<string> { stationLocoSpawner.locoSpawnTrackName }, stationLocoSpawner);
		}
	}

	private void TrackAssignmentCheck(StationController station, List<RailTrack> yardTracks)
	{
		Action<List<RailTrack>> action = delegate(List<RailTrack> stationTracks)
		{
			foreach (RailTrack stationTrack in stationTracks)
			{
				yardTracks.Remove(stationTrack);
			}
		};
		List<RailTrack> obj = yardTracks.Where((RailTrack track) => station.storageRailtracksGONames.Contains(track.name)).ToList();
		action(obj);
		List<RailTrack> obj2 = yardTracks.Where((RailTrack track) => station.transferInRailtracksGONames.Contains(track.name)).ToList();
		action(obj2);
		List<RailTrack> obj3 = yardTracks.Where((RailTrack track) => station.transferOutRailtracksGONames.Contains(track.name)).ToList();
		action(obj3);
		List<string> warehouseMachineTracksGONames = station.warehouseMachineControllers.Select((WarehouseMachineController w) => w.warehouseTrackName).ToList();
		List<RailTrack> obj4 = yardTracks.Where((RailTrack track) => warehouseMachineTracksGONames.Contains(track.name)).ToList();
		action(obj4);
		List<string> locoSpawnersTracksGONames = (from spawner in station.GetComponentsInChildren<StationLocoSpawner>()
			select spawner.locoSpawnTrackName).ToList();
		List<RailTrack> obj5 = yardTracks.Where((RailTrack track) => locoSpawnersTracksGONames.Contains(track.name)).ToList();
		action(obj5);
	}

	private void SetupStation(StationController station, List<RailTrack> tracks)
	{
		Action<List<RailTrack>> action = delegate(List<RailTrack> stationTracks)
		{
			foreach (RailTrack stationTrack in stationTracks)
			{
				tracks.Remove(stationTrack);
			}
		};
		if (!skipStorageTracks)
		{
			List<RailTrack> list = FindTracks(tracks, station, "S");
			station.storageRailtracksGONames = ExtractTrackNames(list);
			action(list);
		}
		if (!skipRegularInTracks)
		{
			List<RailTrack> list2 = FindTracks(tracks, station, "I");
			station.transferInRailtracksGONames = ExtractTrackNames(list2);
			action(list2);
		}
		if (!skipRegularOutTracks)
		{
			List<RailTrack> list3 = FindTracks(tracks, station, "O");
			station.transferOutRailtracksGONames = ExtractTrackNames(list3);
			action(list3);
		}
		if (!skipLoadingTracks)
		{
			List<RailTrack> list4 = FindTracks(tracks, station, "L");
			action(list4);
			if (list4.Count > 0)
			{
				if (list4.Count != station.warehouseMachineControllers.Count)
				{
					Debug.LogWarning("Different number of warehouseTracks and warehouseMachineControllers for station " + station.stationInfo.YardID + ". All warehouse machines will have same track " + list4[0].name + ". Change it manually if it should be different!", station);
					foreach (WarehouseMachineController warehouseMachineController in station.warehouseMachineControllers)
					{
						warehouseMachineController.warehouseTrackName = list4[0].name;
						warehouseMachineController.enabled = !warehouseMachineController.enabled;
						warehouseMachineController.enabled = !warehouseMachineController.enabled;
					}
					tracks.AddRange(list4.Skip(1));
				}
				else
				{
					if (list4.Count > 1)
					{
						Debug.LogWarning("Multiple warehouseTracks detected in station[" + station.stationInfo.YardID + "]. Check which track is connected to which warehouseMachineController!", station);
					}
					for (int num = 0; num < list4.Count; num++)
					{
						station.warehouseMachineControllers[num].warehouseTrackName = list4[num].name;
						station.warehouseMachineControllers[num].enabled = !station.warehouseMachineControllers[num].enabled;
						station.warehouseMachineControllers[num].enabled = !station.warehouseMachineControllers[num].enabled;
					}
				}
			}
			else
			{
				foreach (WarehouseMachineController warehouseMachineController2 in station.warehouseMachineControllers)
				{
					warehouseMachineController2.warehouseTrackName = null;
					Debug.LogError("No warehouseTracks found. warehouseMachineController will be uninitialized", warehouseMachineController2);
					warehouseMachineController2.enabled = !warehouseMachineController2.enabled;
					warehouseMachineController2.enabled = !warehouseMachineController2.enabled;
				}
			}
		}
		if (skipParkingTracks)
		{
			return;
		}
		List<RailTrack> list5 = FindTracks(tracks, station, "P");
		action(list5);
		StationLocoSpawner[] componentsInChildren = station.GetComponentsInChildren<StationLocoSpawner>();
		if (componentsInChildren.Length != 0)
		{
			if (list5.Count > 0)
			{
				if (list5.Count >= componentsInChildren.Length)
				{
					if (list5.Count > componentsInChildren.Length)
					{
						Debug.LogWarning(string.Format("There are more {0} than {1} for station {2}. Only first {3} {4} will be initialized. Change it manually or add more {5} if it should be different!", "parkingTracks", "stationLocoSpawners", station.stationInfo.YardID, componentsInChildren.Length, "stationLocoSpawners", "stationLocoSpawners"), station);
					}
					if (list5.Count > 1)
					{
						Debug.LogWarning("Multiple parkingTracks detected in station[" + station.stationInfo.YardID + "]. Check which track is connected to which locoSpawner!", station);
					}
					for (int num2 = 0; num2 < componentsInChildren.Length; num2++)
					{
						StationLocoSpawner obj = componentsInChildren[num2];
						obj.locoSpawnTrackName = list5[num2].name;
						obj.enabled = !obj.enabled;
						obj.enabled = !obj.enabled;
					}
					tracks.AddRange(list5.Skip(componentsInChildren.Length));
				}
				else
				{
					Debug.LogError(string.Format("There are less {0} than {1} for station {2}. Only first {3} {4} will be initialized. Add more tracks or delete some {5}!", "parkingTracks", "stationLocoSpawners", station.stationInfo.YardID, list5.Count, "stationLocoSpawners", "stationLocoSpawners"), station);
					for (int num3 = 0; num3 < componentsInChildren.Length; num3++)
					{
						StationLocoSpawner obj2 = componentsInChildren[num3];
						obj2.locoSpawnTrackName = ((num3 < list5.Count) ? list5[num3].name : null);
						obj2.enabled = !obj2.enabled;
						obj2.enabled = !obj2.enabled;
					}
				}
			}
			else
			{
				StationLocoSpawner[] array = componentsInChildren;
				foreach (StationLocoSpawner stationLocoSpawner in array)
				{
					stationLocoSpawner.locoSpawnTrackName = null;
					Debug.LogError("No parkingTracks found. locoSpawner will be uninitialized", stationLocoSpawner);
					stationLocoSpawner.enabled = !stationLocoSpawner.enabled;
					stationLocoSpawner.enabled = !stationLocoSpawner.enabled;
				}
			}
		}
		else
		{
			tracks.AddRange(list5);
		}
	}

	private List<RailTrack> FindTracks(List<RailTrack> railTracks, StationController station, string trackTypeMark)
	{
		Regex re = new Regex("\\[Y\\]_\\[" + station.stationInfo.YardID + "\\]_\\[[a-z0-9]+-(\\d+)-" + trackTypeMark + "\\]", RegexOptions.IgnoreCase);
		return (from rt in railTracks
			select new
			{
				track = rt,
				match = re.Match(rt.name)
			} into x
			where x.match.Success
			orderby int.Parse(x.match.Groups[1].Value)
			select x.track).ToList();
	}

	private List<string> ExtractTrackNames(List<RailTrack> railTracks)
	{
		return railTracks.Select((RailTrack track) => track.name).ToList();
	}

	private int GetCountOfNullOrEmpty(List<string> trackNames)
	{
		return trackNames.Where((string trackName) => string.IsNullOrEmpty(trackName)).Count();
	}

	private void PrintStationTracks(StationController station)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("[" + station.stationInfo.YardID + "]-" + station.stationInfo.Name + " tracks:");
		if (station.storageRailtracksGONames.Count > 0)
		{
			stringBuilder.AppendLine("Storage [S]:");
			foreach (string storageRailtracksGOName in station.storageRailtracksGONames)
			{
				stringBuilder.AppendLine("# " + storageRailtracksGOName);
			}
		}
		if (station.transferInRailtracksGONames.Count > 0)
		{
			stringBuilder.AppendLine("Transfer In [I]:");
			foreach (string transferInRailtracksGOName in station.transferInRailtracksGONames)
			{
				stringBuilder.AppendLine("# " + transferInRailtracksGOName);
			}
		}
		if (station.transferOutRailtracksGONames.Count > 0)
		{
			stringBuilder.AppendLine("Transfer Out [O]:");
			foreach (string transferOutRailtracksGOName in station.transferOutRailtracksGONames)
			{
				stringBuilder.AppendLine("# " + transferOutRailtracksGOName);
			}
		}
		if (station.warehouseMachineControllers.Count > 0)
		{
			stringBuilder.AppendLine("Loading [L]:");
			foreach (WarehouseMachineController warehouseMachineController in station.warehouseMachineControllers)
			{
				stringBuilder.AppendLine("# " + warehouseMachineController.warehouseTrackName);
			}
		}
		StationLocoSpawner[] componentsInChildren = station.GetComponentsInChildren<StationLocoSpawner>();
		if (componentsInChildren != null && componentsInChildren.Length != 0)
		{
			stringBuilder.AppendLine("Parking [P]:");
			StationLocoSpawner[] array = componentsInChildren;
			foreach (StationLocoSpawner stationLocoSpawner in array)
			{
				stringBuilder.AppendLine("# " + stationLocoSpawner.locoSpawnTrackName);
			}
		}
		Debug.Log(stringBuilder.ToString());
	}
}
