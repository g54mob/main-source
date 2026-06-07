using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.TravelScene;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Controls;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.Achievements;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.GalaxyMap
{
	public class GalaxyMapUiManager : MonoBehaviour
	{
		public LocationUi LocationPrefab;

		public SolarSystemUi SolarSystemPrefab;

		public UniqueLocationUi UniqueLocationSectorPrefab;

		public GameObject SelectionBorder;

		public GameObject CurrentLocationUi;

		public SectorConnectionLine ConnectionLinePrefab;

		public DisplaySectorInfluence InfluenceLabel;

		private List<DisplaySectorInfluence> _infLabelList = new List<DisplaySectorInfluence>();

		private List<LocationUi> _locationsList = new List<LocationUi>();

		private LocationUi _currentLocation;

		private LocationUi _selectedLocation;

		private Vector3 _borderScale;

		public LocationUi SelectedLocation
		{
			get
			{
				return _selectedLocation;
			}
			set
			{
				_selectedLocation = value;
				if (SelectionBorder != null && _selectedLocation != null)
				{
					Vector3 position = _selectedLocation.transform.position;
					SelectionBorder.transform.position = new Vector3(position.x, position.y, position.z - 1f);
					SelectionBorder.transform.localScale = _borderScale * _selectedLocation.Location.CustomScale;
				}
			}
		}

		public LocationUi HoveredLocation { get; set; }

		public LocationUi CurrentLocation
		{
			get
			{
				return _currentLocation;
			}
			set
			{
				_currentLocation = value;
				if (_currentLocation != null)
				{
					SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation = _currentLocation.Location;
				}
				else
				{
					SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation = null;
				}
				if (CurrentLocationUi != null && _currentLocation != null)
				{
					Vector3 position = _currentLocation.transform.position;
					CurrentLocationUi.transform.position = new Vector3(position.x, position.y, position.z - 1f);
				}
			}
		}

		public float SelectedLocationThreatIncrease { get; private set; }

		public bool SelectedLocationReachable { get; private set; }

		public IEnumerator Start()
		{
			RuntimeGlobals.IsGameLoading = true;
			_borderScale = SelectionBorder.transform.localScale;
			while (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.IsLoading)
			{
				yield return true;
			}
			SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.ScanGalaxy(SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(EMothershipUpgradeType.Bridge));
			if (RuntimeGlobals.GameModeSettings.FreeExploration)
			{
				SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.Sectors[1].ExploreAllNeighbours();
			}
			yield return StartCoroutine(GenerateMap());
			yield return new WaitForSeconds(0.5f);
			RuntimeGlobals.IsGameLoading = false;
			CalculateTravelCost();
		}

		private IEnumerator GenerateMap()
		{
			if (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.Level >= 10)
			{
				BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.ToInfinity);
			}
			List<Tuple<GalaxyMapSector, GalaxyMapSector>> sectorLineList = new List<Tuple<GalaxyMapSector, GalaxyMapSector>>();
			foreach (GalaxyMapSector sector in SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.Sectors)
			{
				SolarSystem solarSystem;
				if ((solarSystem = sector as SolarSystem) != null)
				{
					SolarSystemUi solarSystemUi = UnityEngine.Object.Instantiate(SolarSystemPrefab);
					solarSystemUi.transform.parent = base.transform;
					solarSystemUi.transform.position = solarSystem.Position;
					solarSystemUi.name = solarSystem.UniqueId;
					solarSystemUi.Init(this, solarSystem);
				}
				UniqueLocationSector uniqueLocationSector;
				if ((uniqueLocationSector = sector as UniqueLocationSector) != null)
				{
					UniqueLocationUi uniqueLocationUi = UnityEngine.Object.Instantiate(UniqueLocationSectorPrefab);
					uniqueLocationUi.transform.parent = base.transform;
					uniqueLocationUi.transform.position = uniqueLocationSector.Position;
					uniqueLocationUi.name = uniqueLocationSector.UniqueId;
					uniqueLocationUi.Init(this, uniqueLocationSector);
				}
				foreach (GalaxyMapSector neighbour in sector.GetNeighbours())
				{
					if (!sectorLineList.Any((Tuple<GalaxyMapSector, GalaxyMapSector> t) => (t.Item1 == sector || t.Item1 == neighbour) && (t.Item2 == sector || t.Item2 == neighbour)))
					{
						UnityEngine.Object.Instantiate(ConnectionLinePrefab, base.transform).Init(sector, neighbour);
						sectorLineList.Add(new Tuple<GalaxyMapSector, GalaxyMapSector>(sector, neighbour));
					}
					if (sector.InfluenceToUnlock > 0 && !neighbour.Explored)
					{
						DisplaySectorInfluence displaySectorInfluence = UnityEngine.Object.Instantiate(InfluenceLabel, base.transform);
						displaySectorInfluence.Init(sector, neighbour);
						_infLabelList.Add(displaySectorInfluence);
					}
				}
				yield return true;
			}
		}

		public void Update()
		{
			foreach (DisplaySectorInfluence infLabel in _infLabelList)
			{
				if (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation != null && SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.Sector == infLabel.StartSector && !infLabel.BothExplored())
				{
					infLabel.ChangeText(infLabel.StartSector);
				}
				else if (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation != null && SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.Sector == infLabel.EndSector && !infLabel.BothExplored())
				{
					infLabel.ChangeText(infLabel.EndSector);
				}
				else if (infLabel.StartSector.Explored && !infLabel.BothExplored())
				{
					infLabel.ChangeText(infLabel.StartSector);
				}
				else if (infLabel.EndSector.Explored && !infLabel.BothExplored())
				{
					infLabel.ChangeText(infLabel.EndSector);
				}
				else
				{
					infLabel.gameObject.SetActive(false);
				}
			}
		}

		public void ReloadMap(bool exploreAll)
		{
			SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.ScanGalaxy(SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(EMothershipUpgradeType.Bridge));
			if (exploreAll)
			{
				CurrentLocation.Location.Sector.ExploreAllNeighbours();
			}
			foreach (Transform item in base.transform)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			_infLabelList.Clear();
			StartCoroutine(GenerateMap());
		}

		public void AddToLocations(LocationUi loc)
		{
			if (!_locationsList.Contains(loc))
			{
				_locationsList.Add(loc);
			}
		}

		public LocationUi GetLocationUi(string id)
		{
			LocationUi locationUi = _locationsList.FirstOrDefault((LocationUi l) => l.Location.UniqueId == id);
			if (locationUi != null)
			{
				return locationUi;
			}
			throw new NullReferenceException("No location with specified id found");
		}

		public Vector3 GetInfluenceLabelPosition(int index)
		{
			DisplaySectorInfluence displaySectorInfluence = _infLabelList.FirstOrDefault((DisplaySectorInfluence i) => i.StartSector.Step == index);
			if (!(displaySectorInfluence == null))
			{
				return displaySectorInfluence.transform.position;
			}
			throw new Exception("no influence label found");
		}

		public void FocusLocation(LocationUi location, bool focus = false)
		{
			StarmapCamera.Instance.MoveToLocation(location.transform, focus);
		}

		public void TravelToSelectedLocation()
		{
			if (SelectedLocation != null)
			{
				if (SelectedLocation == CurrentLocation)
				{
					VisitCurrentLocation();
					return;
				}
				TravelManager.ThreatIncrease = SelectedLocationThreatIncrease;
				SelectedLocationThreatIncrease = 0f;
				TravelToLocation(SelectedLocation);
			}
		}

		public void VisitCurrentLocation()
		{
			SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.ApplyLocationSettings();
			SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.LoadLocationScene();
		}

		public void TravelToLocation(LocationUi target)
		{
			NimbatusSceneManager.LoadScene("TravelScene");
			SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.TargetLocation = SelectedLocation.Location;
		}

		public void CalculateTravelCost()
		{
			if (SelectedLocation == null || CurrentLocation == null)
			{
				SelectedLocationReachable = false;
			}
			else if (SelectedLocation.Location.Sector.Explored)
			{
				bool foundPath;
				SelectedLocationThreatIncrease = ThreatHelper.CalculateTravelCost(CurrentLocation.Location, SelectedLocation.Location, out foundPath);
				SelectedLocationReachable = foundPath;
			}
		}
	}
}
