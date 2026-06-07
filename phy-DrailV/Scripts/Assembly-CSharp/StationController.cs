using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DV.Booklets;
using DV.CabControls;
using DV.InventorySystem;
using DV.Logic.Job;
using DV.Optimizers;
using DV.PointSet;
using DV.Utils;
using TMPro;
using UnityEngine;

public class StationController : MonoBehaviour
{
	public static List<StationController> allStations;

	public StationInfo stationInfo;

	public List<string> storageRailtracksGONames;

	public List<string> transferInRailtracksGONames;

	public List<string> transferOutRailtracksGONames;

	public List<WarehouseMachineController> warehouseMachineControllers;

	[SerializeField]
	private PointOnPlane jobBookletSpawnSurface;

	public StationProceduralJobsRuleset proceduralJobsRuleset;

	public Station logicStation;

	private StationJobGenerationRange stationRange;

	private bool playerEnteredJobGenerationZone;

	private List<JobOverview> spawnedJobOverviews = new List<JobOverview>();

	private HashSet<Job> processedNewJobs = new HashSet<Job>();

	private bool attemptJobOverviewGeneration = true;

	public List<RailTrack> AllStationTracks { get; private set; }

	public StationProceduralJobsController ProceduralJobsController { get; private set; }

	public bool StationInfoValid
	{
		get
		{
			if (stationInfo != null && !string.IsNullOrEmpty(stationInfo.Name) && !string.IsNullOrEmpty(stationInfo.YardID) && !string.IsNullOrEmpty(stationInfo.Type))
			{
				return !string.IsNullOrEmpty(stationInfo.LocalizationKey);
			}
			return false;
		}
	}

	public static StationController GetStationByYardID(string yardID)
	{
		foreach (StationController allStation in allStations)
		{
			if (allStation.stationInfo.YardID == yardID)
			{
				return allStation;
			}
		}
		return null;
	}

	public static (StationController station, RailTrack track) GetStationAndTrackByTrackID(string trackID)
	{
		Match match = new Regex("\\[.+\\]_\\[(.+)\\]_\\[.+\\]").Match(trackID);
		if (!match.Success)
		{
			return (station: null, track: null);
		}
		string value = match.Groups[1].Value;
		StationController stationByYardID = GetStationByYardID(value);
		if (stationByYardID == null)
		{
			return (station: null, track: null);
		}
		RailTrack yardTrack = stationByYardID.GetYardTrack(trackID);
		if (yardTrack == null)
		{
			Debug.LogWarning("Found station '" + value + "' but not track '" + trackID + "' in it");
			return (station: null, track: null);
		}
		return (station: stationByYardID, track: yardTrack);
	}

	private void Awake()
	{
		if (allStations == null)
		{
			allStations = new List<StationController>();
			UnloadWatcher.UnloadRequested += CleanupStations;
		}
		allStations.Add(this);
		stationRange = GetComponent<StationJobGenerationRange>();
		if (stationRange == null)
		{
			Debug.LogError("Station[" + stationInfo.YardID + "] doesn't have StationJobGenerationRange set! Station can't function properly.", this);
		}
		PlayerDistanceGameObjectsDisabler playerDistanceGameObjectsDisabler = base.gameObject.AddComponent<PlayerDistanceGameObjectsDisabler>();
		playerDistanceGameObjectsDisabler.optimizingGameObjects = warehouseMachineControllers.Select((WarehouseMachineController wm) => wm.gameObject).ToList();
		playerDistanceGameObjectsDisabler.disableSqrDistance = 360000f;
		playerDistanceGameObjectsDisabler.checkPeriodPerGO = 4f;
	}

	private IEnumerator Start()
	{
		yield return null;
		if (jobBookletSpawnSurface == null)
		{
			Debug.LogError("jobBookletSpawnSurface is not set, jobs will be spawned on StationController's position!", this);
		}
		if (!StationInfoValid)
		{
			Debug.LogError("stationInfo is not initialized properly!", this);
		}
		List<RailTrack> railTracksWithNames = SingletonBehaviour<RailTrackRegistryBase>.Instance.GetRailTracksWithNames(storageRailtracksGONames);
		if (railTracksWithNames == null)
		{
			Debug.LogError("storageRailtracks were not correctly initialized with storageRailtracksGONames!", this);
		}
		List<RailTrack> railTracksWithNames2 = SingletonBehaviour<RailTrackRegistryBase>.Instance.GetRailTracksWithNames(transferInRailtracksGONames);
		if (railTracksWithNames2 == null)
		{
			Debug.LogError("transferInRailtracks were not correctly initialized with transferInRailtracksGONames!", this);
		}
		List<RailTrack> railTracksWithNames3 = SingletonBehaviour<RailTrackRegistryBase>.Instance.GetRailTracksWithNames(transferOutRailtracksGONames);
		if (railTracksWithNames3 == null)
		{
			Debug.LogError("transferOutRailtracks were not correctly initialized with transferOutRailtracksGONames!", this);
		}
		List<Track> storageTracks = ExtractLogicTracks(railTracksWithNames);
		List<Track> transferInTracks = ExtractLogicTracks(railTracksWithNames2);
		List<Track> transferOutTracks = ExtractLogicTracks(railTracksWithNames3);
		List<WarehouseMachine> warehouseMachines = ((warehouseMachineControllers == null || warehouseMachineControllers.Count == 0) ? new List<WarehouseMachine>() : warehouseMachineControllers.Select((WarehouseMachineController warehouseMachineController) => warehouseMachineController.warehouseMachine).ToList());
		Yard yard = new Yard(storageTracks, transferInTracks, transferOutTracks, warehouseMachines, stationInfo.YardID);
		logicStation = new Station(stationInfo.Name, stationInfo.YardID, yard);
		logicStation.JobAddedToStation += delegate
		{
			attemptJobOverviewGeneration = true;
		};
		AllStationTracks = railTracksWithNames.Union(railTracksWithNames2).Union(railTracksWithNames3).Union(warehouseMachineControllers.Select((WarehouseMachineController warehouseMachineController) => warehouseMachineController.warehouseTrack))
			.ToList();
		GenerateTrackIdObject(AllStationTracks);
		ProceduralJobsController = base.gameObject.AddComponent<StationProceduralJobsController>();
	}

	public void TakeJobFromStation(JobOverview jobOverview)
	{
		SingletonBehaviour<JobsManager>.Instance.TakeJob(jobOverview.job);
		spawnedJobOverviews.Remove(jobOverview);
		jobOverview.DestroyJobOverview();
		Debug.Log("Job " + jobOverview.job.ID + " is assigned to player");
	}

	public void ExpireAllAvailableJobsInStation()
	{
		logicStation.ExpireAllAvailableJobsInStation();
		ClearAvailableJobOverviewGOs();
	}

	public void OverridePlayerEnteredJobGenerationZoneFlag()
	{
		float playerSqrDistanceFromStationCenter = stationRange.PlayerSqrDistanceFromStationCenter;
		if (stationRange.IsPlayerInJobGenerationZone(playerSqrDistanceFromStationCenter))
		{
			playerEnteredJobGenerationZone = true;
		}
		else if (!stationRange.IsPlayerOutOfJobDestroyZone(playerSqrDistanceFromStationCenter, logicStation.takenJobs.Count > 0) && (logicStation.availableJobs.Count > 0 || logicStation.takenJobs.Count > 0))
		{
			playerEnteredJobGenerationZone = true;
		}
		else
		{
			playerEnteredJobGenerationZone = false;
		}
	}

	private void Update()
	{
		if (logicStation == null || !AStartGameData.carsAndJobsLoadingFinished || PlayerManager.PlayerTransform == null)
		{
			return;
		}
		if (stationRange.IsPlayerInRangeForBookletGeneration(stationRange.PlayerSqrDistanceFromStationOffice) && attemptJobOverviewGeneration)
		{
			attemptJobOverviewGeneration = false;
			for (int i = 0; i < logicStation.availableJobs.Count; i++)
			{
				Job job = logicStation.availableJobs[i];
				if (!processedNewJobs.Contains(job))
				{
					(Vector3, Quaternion) tuple = jobBookletSpawnSurface?.GetRandomPointWithRotationOnPlane() ?? (base.transform.position, base.transform.rotation);
					JobOverview item = BookletCreator.CreateJobOverview(job, tuple.Item1, tuple.Item2, WorldMover.OriginShiftParent);
					spawnedJobOverviews.Add(item);
					processedNewJobs.Add(job);
					attemptJobOverviewGeneration = true;
					break;
				}
			}
		}
		float playerSqrDistanceFromStationCenter = stationRange.PlayerSqrDistanceFromStationCenter;
		bool num = stationRange.IsPlayerInJobGenerationZone(playerSqrDistanceFromStationCenter);
		bool flag = stationRange.IsPlayerOutOfJobDestroyZone(playerSqrDistanceFromStationCenter, logicStation.takenJobs.Count > 0);
		if (num && !playerEnteredJobGenerationZone)
		{
			ProceduralJobsController.TryToGenerateJobs();
			playerEnteredJobGenerationZone = true;
		}
		else if (flag && playerEnteredJobGenerationZone)
		{
			ProceduralJobsController.StopJobGeneration();
			ExpireAllAvailableJobsInStation();
			playerEnteredJobGenerationZone = false;
		}
	}

	private void GenerateTrackIdObject(List<RailTrack> stationRailTracks)
	{
		foreach (RailTrack stationRailTrack in stationRailTracks)
		{
			EquiPointSet kinkedPointSet = stationRailTrack.GetKinkedPointSet();
			int num = ((kinkedPointSet.points.Length - 1 >= 50) ? 50 : 0);
			int num2 = kinkedPointSet.points.Length - 1 - num;
			Vector3 position = (Vector3)kinkedPointSet.points[num].position;
			Vector3 forward = kinkedPointSet.points[num].forward;
			Vector3 position2 = (Vector3)kinkedPointSet.points[num2].position;
			Vector3 forward2 = kinkedPointSet.points[num2].forward;
			GameObject gameObject = Object.Instantiate(Resources.Load("TrackSignSide", typeof(GameObject)) as GameObject, position, Quaternion.LookRotation(-forward, Vector3.up), stationRailTrack.transform);
			GameObject gameObject2 = Object.Instantiate(Resources.Load("TrackSignSide", typeof(GameObject)) as GameObject, position2, Quaternion.LookRotation(forward2, Vector3.up), stationRailTrack.transform);
			gameObject.name = string.Join(" ", "[track id]", "0");
			gameObject2.name = string.Join(" ", "[track id]", "1");
			TextMeshPro[] componentsInChildren = gameObject.GetComponentsInChildren<TextMeshPro>();
			TextMeshPro[] componentsInChildren2 = gameObject2.GetComponentsInChildren<TextMeshPro>();
			List<TextMeshPro> list = componentsInChildren.Union(componentsInChildren2).ToList();
			string signIDSubYardPart = stationRailTrack.LogicTrack().ID.SignIDSubYardPart;
			string signIDTrackPart = stationRailTrack.LogicTrack().ID.SignIDTrackPart;
			foreach (TextMeshPro item in list)
			{
				item.text = ((item.name == "[SubYardID]") ? signIDSubYardPart : signIDTrackPart);
			}
		}
	}

	private void ClearAvailableJobOverviewGOs()
	{
		for (int i = 0; i < spawnedJobOverviews.Count; i++)
		{
			if (spawnedJobOverviews[i] == null)
			{
				continue;
			}
			ItemBase component = spawnedJobOverviews[i].GetComponent<ItemBase>();
			bool num = component != null && (component.IsGrabbed() || SingletonBehaviour<Inventory>.Instance.Contains(component.gameObject, includeDropped: false));
			bool flag = (spawnedJobOverviews[i].transform.position - base.transform.position).sqrMagnitude > stationRange.jobOverviewBookletGenerationSqrDistance;
			if (num || flag)
			{
				RespawnOnDrop component2 = spawnedJobOverviews[i].GetComponent<RespawnOnDrop>();
				if ((bool)component2)
				{
					component2.SetMaxDistance(100f);
					component2.ignoreDistanceFromSpawnPosition = true;
					component2.respawnOnDropThroughFloor = false;
				}
			}
			else
			{
				spawnedJobOverviews[i].DestroyJobOverview();
			}
		}
		spawnedJobOverviews.Clear();
		processedNewJobs.Clear();
	}

	public RailTrack GetYardTrack(string trackId)
	{
		foreach (Track allYardTrack in logicStation.yard.GetAllYardTracks())
		{
			if (allYardTrack.ID.RailTrackGameObjectID == trackId)
			{
				return allYardTrack.RailTrack();
			}
		}
		return null;
	}

	private List<Track> ExtractLogicTracks(List<RailTrack> railtracks)
	{
		if (railtracks == null || railtracks.Count == 0)
		{
			return new List<Track>();
		}
		return railtracks.Select((RailTrack railtrack) => railtrack.LogicTrack()).ToList();
	}

	private static void CleanupStations()
	{
		UnloadWatcher.UnloadRequested -= CleanupStations;
		allStations = null;
	}

	public void RegenerateJobs()
	{
		if (stationRange.IsPlayerInJobGenerationZone(stationRange.PlayerSqrDistanceFromStationCenter))
		{
			ProceduralJobsController.StopJobGeneration();
			ExpireAllAvailableJobsInStation();
			SingletonBehaviour<UnusedTrainCarDeleter>.Instance.ForceDeleteAllUnusedTrainCars();
			ProceduralJobsController.TryToGenerateJobs();
		}
	}
}
