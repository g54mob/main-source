using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class DroneSelectionManager : MonoBehaviour, IDroneInformationList
	{
		public static bool HideLaunchButton;

		public static bool HideBackButton;

		[HideInInspector]
		public DroneData SelectedItem;

		public UIGrid ResultGrid;

		public UIScrollView ResultScrollView;

		public DroneInformationItem DroneItemPrefab;

		public GameObject SteamWorkshopButton;

		public GameObject ImportButton;

		public GameObject ProgrammerImportButton;

		public ShowDrones MyDronesButton;

		public ShowDrones SteamDronesButton;

		public UIInput SearchInput;

		public DroneInformationPanel InformationPanel;

		public SteamDroneInformationPanel SteamInformationPanel;

		public DroneUploadPanel UploadPanel;

		public ImportDronePanel ImportPanel;

		public ImportDronePanel ProgrammerImportPanel;

		public DeleteDronePanel DeletePanel;

		public LaunchDroneWindow LaunchPanel;

		public DroneSortModeSelector SortModeSelector;

		public GameObject HealthThreatPanel;

		public GameObject ResourcesPanel;

		public GameObject DroneEmptypanel;

		public GameObject SteamEmptyPanel;

		public GameObject BackButton;

		private bool _showSteamDrones;

		private BackgroundWorker _loadSteamDronesWorker;

		private bool _shouldUpdate;

		private List<DroneData> _drones;

		public void Start()
		{
			UploadPanel.gameObject.SetActive(false);
			DeletePanel.gameObject.SetActive(false);
			InformationPanel.gameObject.SetActive(false);
			LaunchPanel.gameObject.SetActive(false);
			LaunchPanel.Init(this);
			MyDronesButton.Init(this);
			SteamDronesButton.Init(this);
			ImportPanel.Init(this);
			ProgrammerImportPanel.Init(this);
			SortModeSelector.Init(this);
			SteamWorkshopButton.SetActive(SaveManager.LoadedSave.Settings.ImportDrones);
			MyDronesButton.gameObject.SetActive(SaveManager.LoadedSave.Settings.ImportDrones);
			SteamDronesButton.gameObject.SetActive(SaveManager.LoadedSave.Settings.ImportDrones);
			ImportButton.SetActive(SaveManager.LoadedSave.Settings.ImportDrones);
			ProgrammerImportButton.SetActive(!SaveManager.LoadedSave.Settings.ImportDrones && RuntimeGlobals.GameMode == EGameMode.Campaign && SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActivePerk != null && SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActivePerk.StarterSet.AllPartsUnlocked);
			HealthThreatPanel.gameObject.SetActive(!SaveManager.LoadedSave.Settings.ImportDrones && SaveManager.LoadedSave.Settings.NimbatusHealthAndThreat);
			ResourcesPanel.gameObject.SetActive(!SaveManager.LoadedSave.Settings.ImportDrones && SaveManager.LoadedSave.Settings.DeployCost);
			if (!ResourcesPanel.gameObject.activeSelf)
			{
				Vector3 localPosition = HealthThreatPanel.transform.localPosition;
				localPosition.x = ResourcesPanel.transform.localPosition.x;
				HealthThreatPanel.transform.localPosition = localPosition;
			}
			FillUpDrones();
			ResultScrollView.ResetPosition();
			DroneData activeDrone = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone;
			if (SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.IsDroneEditable(activeDrone))
			{
				SelectDrone(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone);
			}
			else
			{
				SelectDrone(null);
			}
			_loadSteamDronesWorker = new BackgroundWorker();
			_loadSteamDronesWorker.DoWork += _loadSteamDronesWorker_DoWork;
			_loadSteamDronesWorker.RunWorkerAsync();
			BackButton.SetActive(!HideBackButton);
		}

		private void _loadSteamDronesWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.UpdateSteamDrones();
			if (_showSteamDrones)
			{
				_shouldUpdate = true;
			}
		}

		public void Update()
		{
			if (_shouldUpdate)
			{
				FillUpDrones();
				_shouldUpdate = false;
			}
		}

		private void FillUpDrones()
		{
			ResultGrid.transform.DestroyAllChildren();
			_drones = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.Drones;
			if (_showSteamDrones)
			{
				_drones = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SteamDrones;
			}
			if (!string.IsNullOrEmpty(SearchInput.value))
			{
				_drones = _drones.Where((DroneData d) => d.DroneName.ToUpperInvariant().Contains(SearchInput.value.ToUpperInvariant())).ToList();
			}
			if (!_drones.Contains(SelectedItem))
			{
				SelectDrone(null);
			}
			switch (DroneSortModeSelector.CurrentSortMode)
			{
			case EDroneSortMode.AlphabeticalDescending:
				_drones = _drones.OrderByDescending((DroneData d) => d.DroneName).ToList();
				break;
			case EDroneSortMode.AlphabeticalAscending:
				_drones = _drones.OrderBy((DroneData d) => d.DroneName).ToList();
				break;
			case EDroneSortMode.Newest:
				_drones = _drones.OrderByDescending((DroneData d) => d.LastEditTime).ToList();
				break;
			case EDroneSortMode.Oldest:
				_drones = _drones.OrderBy((DroneData d) => d.LastEditTime).ToList();
				break;
			}
			if (_drones.Count <= 0)
			{
				if (_showSteamDrones)
				{
					SteamEmptyPanel.gameObject.SetActive(true);
					DroneEmptypanel.gameObject.SetActive(false);
				}
				else
				{
					DroneEmptypanel.gameObject.SetActive(true);
					SteamEmptyPanel.gameObject.SetActive(false);
				}
			}
			else
			{
				DroneEmptypanel.gameObject.SetActive(false);
				SteamEmptyPanel.gameObject.SetActive(false);
			}
			foreach (DroneData drone in _drones)
			{
				DroneInformationItem droneInformationItem = UnityEngine.Object.Instantiate(DroneItemPrefab);
				droneInformationItem.Init(this, drone);
				droneInformationItem.gameObject.transform.position = ResultGrid.transform.position;
				droneInformationItem.gameObject.transform.parent = ResultGrid.transform;
				droneInformationItem.gameObject.transform.localScale = ResultGrid.transform.localScale;
			}
			ResultGrid.enabled = true;
			ResultGrid.repositionNow = true;
			ResultScrollView.UpdateScrollbars(true);
		}

		public void SelectDrone(DroneData item)
		{
			if (item == null)
			{
				UploadPanel.gameObject.SetActive(false);
				DeletePanel.gameObject.SetActive(false);
				InformationPanel.gameObject.SetActive(false);
				SteamInformationPanel.gameObject.SetActive(false);
			}
			if (SelectedItem == item)
			{
				return;
			}
			SelectedItem = item;
			if (item != null)
			{
				if (_drones != null && !_drones.Contains(SelectedItem))
				{
					UploadPanel.gameObject.SetActive(false);
					DeletePanel.gameObject.SetActive(false);
					InformationPanel.gameObject.SetActive(false);
					SteamInformationPanel.gameObject.SetActive(false);
					return;
				}
				if (item.DownloadedFromSteam != _showSteamDrones)
				{
					_showSteamDrones = item.DownloadedFromSteam;
					UpdateList();
				}
				UploadPanel.gameObject.SetActive(false);
				if (item.DownloadedFromSteam)
				{
					InformationPanel.gameObject.SetActive(false);
					DeletePanel.gameObject.SetActive(false);
					SteamInformationPanel.gameObject.SetActive(true);
					SteamInformationPanel.Init(this, item);
				}
				else
				{
					SteamInformationPanel.gameObject.SetActive(false);
					DeletePanel.gameObject.SetActive(false);
					InformationPanel.gameObject.SetActive(true);
					InformationPanel.Init(this, item);
				}
			}
			else
			{
				UploadPanel.gameObject.SetActive(false);
				DeletePanel.gameObject.SetActive(false);
				InformationPanel.gameObject.SetActive(false);
				SteamInformationPanel.gameObject.SetActive(false);
			}
		}

		public void ShowDroneUploadPanel(DroneData item)
		{
			UploadPanel.Init(this, item);
			UploadPanel.gameObject.SetActive(true);
			InformationPanel.gameObject.SetActive(false);
			SteamInformationPanel.gameObject.SetActive(false);
		}

		public void HideDroneUploadPanel()
		{
			UploadPanel.gameObject.SetActive(false);
			if (SelectedItem != null)
			{
				InformationPanel.gameObject.SetActive(true);
			}
		}

		public void HideDeletePanel()
		{
			DeletePanel.gameObject.SetActive(false);
			if (SelectedItem != null)
			{
				InformationPanel.gameObject.SetActive(true);
			}
		}

		public void ShowDeletePanel(DroneData item)
		{
			DeletePanel.gameObject.SetActive(true);
			DeletePanel.Init(this, item);
			UploadPanel.gameObject.SetActive(false);
			InformationPanel.gameObject.SetActive(false);
			SteamInformationPanel.gameObject.SetActive(false);
		}

		public void ShowLaunchPanel(DroneData drone, Action launchAction)
		{
			LaunchPanel.InitDrone(drone, launchAction);
			LaunchPanel.gameObject.SetActive(true);
		}

		public void HideLaunchPanel()
		{
			LaunchPanel.gameObject.SetActive(false);
		}

		public void ClearItems()
		{
			ResultScrollView.ResetPosition();
			(from Transform child in ResultGrid.transform
				select child.gameObject).ToList().ForEach(UnityEngine.Object.Destroy);
			ResultGrid.gameObject.SetActive(true);
			ResultGrid.Reposition();
			ResultScrollView.ResetPosition();
			ResultScrollView.UpdateScrollbars(true);
		}

		public void UpdateList()
		{
			FillUpDrones();
		}

		public void DeleteDrone(DroneData item)
		{
			ShowDeletePanel(item);
		}

		public void DuplicateDrone(DroneData item)
		{
			DroneData item2 = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.DuplicateDrone(item);
			FillUpDrones();
			SelectDrone(item2);
			SaveManager.StoreSaveGame(false, false);
		}

		public void ShowSteamDrones(bool show)
		{
			_showSteamDrones = show;
			UpdateList();
			if (show)
			{
				SelectDrone(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SteamDrones.FirstOrDefault());
			}
			else
			{
				SelectDrone(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.Drones.FirstOrDefault());
			}
		}

		public bool AreSteamDronesShown()
		{
			return _showSteamDrones;
		}

		public DroneData GetSelectedDrone()
		{
			return SelectedItem;
		}
	}
}
