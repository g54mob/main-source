using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DV;
using DV.OriginShift;
using DV.Teleporters;
using DV.Utils;
using UnityEngine;
using VLB;

public class MapMarkersController : MonoBehaviour
{
	private static readonly RequestSystem interactableRequestSystem = new RequestSystem(1f);

	[SerializeField]
	[Header("Map Settings")]
	private BoxCollider bounds;

	[SerializeField]
	private float markerRefreshInterval = 0.1f;

	[SerializeField]
	private float sideMarkerOffset = 0.0055f;

	[SerializeField]
	private float staticMarkerYOffset = 0.001f;

	[SerializeField]
	private float dynamicMarkerYOffset = 0.0015f;

	[Header("Marker Prefabs")]
	[SerializeField]
	private MapMarker stationMarkerPrefab;

	[SerializeField]
	private MapMarker houseMarkerPrefab;

	[SerializeField]
	private MapMarker playerMarkerPrefab;

	[SerializeField]
	private MapMarker locoMarkerPrefab;

	[SerializeField]
	private MapMarker cabooseMarkerPrefab;

	[SerializeField]
	private GameObject coalServiceMarkerPrefab;

	[SerializeField]
	private GameObject dieselServiceMarkerPrefab;

	[SerializeField]
	private GameObject electricChargeMarkerPrefab;

	[SerializeField]
	private GameObject repairMarkerPrefab;

	[SerializeField]
	private GameObject shopMarkerPrefab;

	private Vector2 mapBounds;

	private GameParams gameParams;

	private readonly Dictionary<FastTravelDestination, MapMarker> markers = new Dictionary<FastTravelDestination, MapMarker>();

	private static bool MapMarkerInteractionAllowed => interactableRequestSystem.Value > 0.5f;

	public static event Action<FastTravelDestination> OnMapMarkerUsed;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void StaticReload()
	{
		interactableRequestSystem.ClearValueRequests();
		interactableRequestSystem.ClearEventListeners();
		MapMarkersController.OnMapMarkerUsed = null;
	}

	public static void RequestToggleMapMarkerInteraction(object caller, bool on, int priority = 0)
	{
		interactableRequestSystem.RequestValue(caller, on ? 1 : 0, priority);
	}

	public static void RemoveMapMarkerInteractionRequest(object caller)
	{
		interactableRequestSystem.RemoveValue(caller);
	}

	internal static void InvokeMarkerUsed(FastTravelDestination destination)
	{
		MapMarkersController.OnMapMarkerUsed?.Invoke(destination);
	}

	private void Awake()
	{
		mapBounds = bounds.size.xz() * 0.5f;
		gameParams = Globals.G.GameParams;
		foreach (FastTravelDestination activeDestination in FastTravelDestination.ActiveDestinations)
		{
			OnDestinationUpdated(activeDestination, added: true);
		}
		interactableRequestSystem.ValueChanged += UpdateAllMapMarkersInteractionState;
		FastTravelDestination.DestinationUpdated += OnDestinationUpdated;
		gameParams.PropertyChanged += OnGameParamsChanged;
	}

	private IEnumerator Start()
	{
		if (!gameParams.FastTravelAllowed)
		{
			yield return null;
			RequestToggleMapMarkerInteraction(this, on: false, int.MaxValue);
		}
	}

	private void OnEnable()
	{
		StartCoroutine(UpdateDynamicMarkers());
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	private void OnDestroy()
	{
		RemoveMapMarkerInteractionRequest(this);
		interactableRequestSystem.ValueChanged -= UpdateAllMapMarkersInteractionState;
		FastTravelDestination.DestinationUpdated -= OnDestinationUpdated;
		gameParams.PropertyChanged -= OnGameParamsChanged;
	}

	private void OnDestinationUpdated(FastTravelDestination destination, bool added)
	{
		if (!added)
		{
			if (markers.TryGetValue(destination, out var value))
			{
				markers.Remove(destination);
				UnityEngine.Object.Destroy(value.gameObject);
			}
		}
		else
		{
			if (!GetMarkerPrefab(destination.markerType).IsSome(out var value2))
			{
				return;
			}
			if (!destination.mapMarkerAnchor)
			{
				Debug.LogError((!destination) ? "Tried to add a map marker for a destroyed FastTravelController!" : ("FastTravelDestination " + destination.name + " has no map marker anchor! Not adding it to the map."), destination);
				return;
			}
			MapMarker mapMarker = UnityEngine.Object.Instantiate(value2, base.transform);
			mapMarker.Init(destination);
			markers.Add(destination, mapMarker);
			UpdateMarker(mapMarker, destination);
			if (!destination.showOnMap || (mapMarker.MarkerType.HasAnyUShortFlag(FastTravelDestination.MarkerType.Train) && !gameParams.LocoMarkersDisplayed) || (mapMarker.MarkerType == FastTravelDestination.MarkerType.Player && !gameParams.PlayerMarkerDisplayed))
			{
				mapMarker.gameObject.SetActive(value: false);
			}
			if (destination.IsDynamic)
			{
				FastTravelDestination.SideMarkers[] sideMarkers = destination.sideMarkers;
				if (sideMarkers != null && sideMarkers.Length != 0)
				{
					Debug.LogError("Dynamic FastTravelDestination " + destination.name + " has side markers, which isn't allowed!", destination);
					return;
				}
			}
			Vector3 vector = Quaternion.Euler(0f, destination.sideMarkersStackingYRotation, 0f) * Vector3.forward;
			Vector3 localPosition = mapMarker.transform.localPosition;
			for (int i = 0; i < destination.sideMarkers?.Length; i++)
			{
				if (GetSideMarkerPrefab(destination.sideMarkers[i]).IsSome(out var value3))
				{
					UnityEngine.Object.Instantiate(value3, base.transform).transform.localPosition = localPosition + vector * ((float)(i + 1) * sideMarkerOffset);
				}
			}
		}
	}

	private IEnumerator UpdateDynamicMarkers()
	{
		while (true)
		{
			foreach (KeyValuePair<FastTravelDestination, MapMarker> marker in markers)
			{
				FastTravelDestination key = marker.Key;
				MapMarker value = marker.Value;
				if (!key.IsDynamic)
				{
					continue;
				}
				switch ((ushort)key.markerType)
				{
				case 2:
					if (!gameParams.PlayerMarkerDisplayed)
					{
						continue;
					}
					break;
				case 4:
					if (!gameParams.LocoMarkersDisplayed)
					{
						continue;
					}
					break;
				case 8:
					if (!gameParams.LocoMarkersDisplayed)
					{
						continue;
					}
					break;
				}
				GameObject gameObject = value.gameObject;
				if (gameObject.activeSelf != key.showOnMap)
				{
					gameObject.SetActive(key.showOnMap);
				}
				if (key.showOnMap)
				{
					UpdateMarker(value, key);
				}
			}
			yield return WaitFor.Seconds(markerRefreshInterval);
		}
	}

	private void UpdateMarker(MapMarker marker, FastTravelDestination destination)
	{
		marker.transform.localPosition = GetMapPosition(destination.mapMarkerAnchor.AbsolutePosition(), destination.IsDynamic);
		if (destination.IsDynamic)
		{
			marker.rotationVisuals.localRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(destination.mapMarkerAnchor.forward, Vector3.up).normalized);
		}
	}

	private void UpdateAllMapMarkersInteractionState(float _value)
	{
		foreach (MapMarker value in markers.Values)
		{
			UpdateMapMarkerInteractionState(value);
		}
	}

	public static void UpdateMapMarkerInteractionState(MapMarker marker)
	{
		if ((bool)marker.Button)
		{
			marker.Button.InteractionAllowed = MapMarkerInteractionAllowed;
		}
	}

	private void OnGameParamsChanged(object _, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "FastTravelAllowed":
			if (gameParams.FastTravelAllowed)
			{
				RemoveMapMarkerInteractionRequest(this);
			}
			else
			{
				RequestToggleMapMarkerInteraction(this, on: false, int.MaxValue);
			}
			break;
		case "LocoMarkersDisplayed":
		{
			foreach (KeyValuePair<FastTravelDestination, MapMarker> marker in markers)
			{
				if (marker.Key.showOnMap && marker.Value.MarkerType.HasAnyUShortFlag(FastTravelDestination.MarkerType.Train))
				{
					marker.Value.gameObject.SetActive(gameParams.LocoMarkersDisplayed);
				}
			}
			break;
		}
		case "PlayerMarkerDisplayed":
		{
			foreach (KeyValuePair<FastTravelDestination, MapMarker> marker2 in markers)
			{
				if (marker2.Key.showOnMap && marker2.Value.MarkerType == FastTravelDestination.MarkerType.Player)
				{
					marker2.Value.gameObject.SetActive(gameParams.PlayerMarkerDisplayed);
				}
			}
			break;
		}
		}
	}

	private Option<MapMarker> GetMarkerPrefab(FastTravelDestination.MarkerType markerType)
	{
		switch (markerType)
		{
		case FastTravelDestination.MarkerType.Station:
			return Option<MapMarker>.Some(stationMarkerPrefab);
		case FastTravelDestination.MarkerType.House:
			return Option<MapMarker>.Some(houseMarkerPrefab);
		case FastTravelDestination.MarkerType.Player:
			return Option<MapMarker>.Some(playerMarkerPrefab);
		case FastTravelDestination.MarkerType.Loco:
			return Option<MapMarker>.Some(locoMarkerPrefab);
		case FastTravelDestination.MarkerType.Caboose:
			return Option<MapMarker>.Some(cabooseMarkerPrefab);
		default:
			Debug.LogError(string.Format("Unexpected {0}: {1}. Skipping marker.", "markerType", markerType));
			return Option<MapMarker>.None;
		}
	}

	private Option<GameObject> GetSideMarkerPrefab(FastTravelDestination.SideMarkers sideMarkerType)
	{
		switch (sideMarkerType)
		{
		case FastTravelDestination.SideMarkers.DieselService:
			return Option<GameObject>.Some(dieselServiceMarkerPrefab);
		case FastTravelDestination.SideMarkers.CoalService:
			return Option<GameObject>.Some(coalServiceMarkerPrefab);
		case FastTravelDestination.SideMarkers.Shop:
			return Option<GameObject>.Some(shopMarkerPrefab);
		case FastTravelDestination.SideMarkers.RepairService:
			return Option<GameObject>.Some(repairMarkerPrefab);
		case FastTravelDestination.SideMarkers.ElectricCharger:
			return Option<GameObject>.Some(electricChargeMarkerPrefab);
		default:
			Debug.LogError(string.Format("Unexpected {0} type: {1}. Skipping marker.", "SideMarkers", sideMarkerType));
			return Option<GameObject>.None;
		}
	}

	private Vector3 GetMapPosition(Vector3 absPosition, bool dynamic)
	{
		Vector2 normalizedPosition = GetNormalizedPosition(absPosition);
		return new Vector3(Mathf.Lerp(0f - mapBounds.x, mapBounds.x, normalizedPosition.x), dynamic ? dynamicMarkerYOffset : staticMarkerYOffset, Mathf.Lerp(0f - mapBounds.y, mapBounds.y, normalizedPosition.y));
	}

	private static Vector2 GetNormalizedPosition(Vector3 absPosition)
	{
		Vector3 worldSize = LevelInfo.WorldSize;
		Vector3 worldOffset = LevelInfo.WorldOffset;
		return new Vector2(Mathf.InverseLerp(0f, worldSize.x, absPosition.x - worldOffset.x), Mathf.InverseLerp(0f, worldSize.z, absPosition.z - worldOffset.z));
	}
}
