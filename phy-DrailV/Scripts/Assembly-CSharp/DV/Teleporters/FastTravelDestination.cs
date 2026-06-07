using System;
using System.Collections.Generic;
using UnityEngine;

namespace DV.Teleporters
{
	public abstract class FastTravelDestination : MonoBehaviour
	{
		[Flags]
		public enum MarkerType : ushort
		{
			Station = 0,
			House = 1,
			Player = 2,
			Loco = 4,
			Caboose = 8,
			Train = 0xC
		}

		public enum SideMarkers
		{
			DieselService = 0,
			CoalService = 1,
			Shop = 2,
			RepairService = 3,
			ElectricCharger = 4
		}

		private static readonly HashSet<FastTravelDestination> activeDestinations = new HashSet<FastTravelDestination>();

		public Transform playerTeleportAnchor;

		[Header("Map Markers")]
		public bool showOnMap = true;

		public MarkerType markerType;

		public Transform mapMarkerAnchor;

		public SideMarkers[] sideMarkers;

		public float sideMarkersStackingYRotation;

		private bool useOnEnable;

		public static IReadOnlyCollection<FastTravelDestination> ActiveDestinations => activeDestinations;

		public abstract string MarkerName { get; }

		public abstract bool IsDynamic { get; }

		public static event Action<FastTravelDestination, bool> DestinationUpdated;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void StaticReload()
		{
			activeDestinations.Clear();
			FastTravelDestination.DestinationUpdated = null;
		}

		private static void AddMarker(FastTravelDestination marker)
		{
			if (!marker)
			{
				Debug.LogError("Tried to register a destroyed FastTravelDestination!");
			}
			else if (activeDestinations.Add(marker))
			{
				FastTravelDestination.DestinationUpdated?.Invoke(marker, arg2: true);
			}
		}

		private static void RemoveMarker(FastTravelDestination marker)
		{
			if (activeDestinations.Remove(marker))
			{
				FastTravelDestination.DestinationUpdated?.Invoke(marker, arg2: false);
			}
		}

		private void Start()
		{
			useOnEnable = true;
			RefreshMarkerVisibility();
		}

		private void OnEnable()
		{
			if (useOnEnable)
			{
				RefreshMarkerVisibility();
			}
		}

		private void OnDisable()
		{
			RemoveMarker(this);
		}

		private void OnDestroy()
		{
			RemoveMarker(this);
		}

		public void RefreshMarkerVisibility()
		{
			if (showOnMap)
			{
				AddMarker(this);
			}
			else
			{
				RemoveMarker(this);
			}
		}

		public void TeleportPlayer()
		{
			PlayerManager.TeleportPlayer(playerTeleportAnchor.position, playerTeleportAnchor.rotation, null, useRotation: true);
		}
	}
}
