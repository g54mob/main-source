using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.Tutorial;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones
{
	public class DroneManager : SerializableMonobehaviour<DroneManager, DroneManagerData>
	{
		public Material DroneJointMaterial;

		public SpriteRenderer SkinRendererPrefab;

		public PhysicMaterial DronePhysicMaterial;

		public PhysicMaterial FrictionLessMaterial;

		public PhysicMaterial SuperFrictionMaterial;

		public PhysicMaterial RubberTireMaterial;

		[NonSerialized]
		[HideInInspector]
		public Dictionary<int, DroneData> ActiveDrones = new Dictionary<int, DroneData>();

		[NonSerialized]
		[HideInInspector]
		public List<DroneData> Drones;

		[NonSerialized]
		[HideInInspector]
		public List<DroneData> SteamDrones;

		public DroneSettingsObject DefaultDroneSettings;

		[HideInInspector]
		public DroneSettings ActiveDroneSettings;

		[HideInInspector]
		public List<DefaultDrone> DefaultDrones;

		public bool DronesLoaded;

		private DroneData _backupDrone;

		public DroneData ActiveDrone
		{
			get
			{
				return GetActiveDrone(ActiveDroneIndex);
			}
		}

		[HideInInspector]
		public int ActiveDroneIndex { get; set; }

		internal override string Filename
		{
			get
			{
				return "Drones.xml";
			}
		}

		protected override void PreLoad()
		{
			base.PreLoad();
			DronesLoaded = false;
			ActiveDroneSettings = DefaultDroneSettings.Settings;
		}

		protected override void PostLoad()
		{
			LoadDefaultDrones();
			DronesLoaded = false;
			StartCoroutine(UpdateDroneList());
		}

		public void SetDroneSettings(DroneSettings settings)
		{
			ActiveDroneSettings = settings;
		}

		public List<DronePrecondition> GetPreconditions()
		{
			List<DronePrecondition> list = new List<DronePrecondition>();
			if (GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.Subtutorial != null)
			{
				return GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.Subtutorial.Preconditions.ToList();
			}
			if (ActiveDroneSettings != null)
			{
				list = ActiveDroneSettings.DronePreconditions.ToList();
			}
			if (RuntimeGlobals.GameModeSettings.HasPartUnlocking)
			{
				list.Add(new AllPartsAvailable());
			}
			if (RuntimeGlobals.GameModeSettings.DeployCost)
			{
				list.Add(new AffordDeployCost());
			}
			if (SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects != null && SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects.Any((DroneEffect e) => e is Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects.NoInputAllowed) && RuntimeGlobals.GameMode == EGameMode.Campaign)
			{
				list.Add(new Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions.NoInputAllowed());
			}
			return list;
		}

		private void LoadDefaultDrones()
		{
			DefaultDrones = new List<DefaultDrone>();
			DefaultDrones = Resources.LoadAll<DefaultDrone>("DefaultDrones").ToList();
		}

		public List<DefaultDrone> GetDefaultDrones(EDefaultDroneType droneType, ETrainingDifficulty difficulty)
		{
			return DefaultDrones.Where((DefaultDrone d) => d.Difficulty == difficulty && d.DroneType == droneType).ToList();
		}

		public DroneData LoadDefaultDrone(int index)
		{
			return DroneData.LoadFromBytes(DefaultDrones[index].DroneBytes);
		}

		public DroneData LoadDefaultDrone(DefaultDrone toLoad)
		{
			DefaultDrone defaultDrone = DefaultDrones.FirstOrDefault((DefaultDrone d) => d.name == toLoad.name);
			if (defaultDrone != null)
			{
				return DroneData.LoadFromBytes(defaultDrone.DroneBytes);
			}
			return null;
		}

		public DroneData GetDroneById(string id)
		{
			return Drones.FirstOrDefault((DroneData d) => d.UniqueId == id);
		}

		public IEnumerator UpdateDroneList()
		{
			Drones = new List<DroneData>();
			ClearActiveDrones();
			if (SaveManager.LoadedSave.Mode != EGameMode.Tutorial)
			{
				List<FileInfo> list = (from f in new DirectoryInfo(SaveManager.GetActiveDroneFolderPath()).GetFiles("*.drn")
					orderby f.LastWriteTime descending
					select f).ToList();
				foreach (FileInfo item in list)
				{
					try
					{
						DroneData data = DroneData.Load(item.FullName);
						if (Drones.All((DroneData d) => d.UniqueId != data.UniqueId))
						{
							Drones.Add(data);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
					yield return true;
				}
			}
			DronesLoaded = true;
		}

		public void UpdateSteamDrones()
		{
			SteamDrones = new List<DroneData>();
			if (!SteamManager.Initialized)
			{
				return;
			}
			uint numSubscribedItems = SteamUGC.GetNumSubscribedItems();
			PublishedFileId_t[] array = new PublishedFileId_t[numSubscribedItems];
			SteamUGC.GetSubscribedItems(array, numSubscribedItems);
			PublishedFileId_t[] array2 = array;
			foreach (PublishedFileId_t itemFileId in array2)
			{
				try
				{
					ImportSteamDrone(itemFileId);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		public void ImportDroneFromFile(string path)
		{
			DroneData droneData = DroneData.Load(path);
			if (droneData != null)
			{
				droneData.UniqueId = Guid.NewGuid().ToString();
				Drones.Add(droneData);
				droneData.Save(GetCurrentFilePath(droneData));
			}
		}

		public DroneData ImportSteamDrone(PublishedFileId_t itemFileId)
		{
			ulong punSizeOnDisk;
			string pchFolder;
			uint punTimeStamp;
			if (SteamManager.Initialized && SteamUGC.GetItemInstallInfo(itemFileId, out punSizeOnDisk, out pchFolder, 1024u, out punTimeStamp) && Directory.Exists(pchFolder) && ((EItemState)SteamUGC.GetItemState(itemFileId)).Contains(EItemState.k_EItemStateInstalled))
			{
				return ImportSteamDroneFromFolder(pchFolder);
			}
			return null;
		}

		public DroneData ImportSteamDroneFromFolder(string path)
		{
			string text = Path.Combine(path, "Drone.drn");
			DroneData droneData = DroneData.Load(text);
			if (droneData != null)
			{
				if (droneData.UserId == SteamUser.GetSteamID().m_SteamID)
				{
					droneData.WasShared = false;
				}
				else
				{
					droneData.WasShared = true;
				}
				droneData.DownloadedFromSteam = true;
				droneData.LastEditTime = File.GetCreationTimeUtc(text);
				SteamDrones.Add(droneData);
				return droneData;
			}
			return null;
		}

		public DroneData CreateDrone(string droneName)
		{
			DroneData droneData = new DroneData
			{
				WasShared = false,
				DroneName = droneName,
				UniqueId = Guid.NewGuid().ToString()
			};
			droneData.WeaponPresets = new List<WeaponPresetData>();
			droneData.RootDronePart = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<RootDronePart>().First().GenerateData();
			Drones.Add(droneData);
			return droneData;
		}

		public DroneData DuplicateDrone(DroneData drone)
		{
			DroneData droneData = drone.Clone();
			droneData.UniqueId = Guid.NewGuid().ToString();
			droneData.LastEditTime = DateTime.UtcNow;
			droneData.LastUseTime = DateTime.UtcNow;
			droneData.Save(GetCurrentFilePath(droneData));
			Drones.Add(droneData);
			return droneData;
		}

		public void RevertActiveDrone()
		{
			if (_backupDrone == null)
			{
				return;
			}
			if (_backupDrone.NumberOfParts < 1 && _backupDrone.Image == null)
			{
				_backupDrone = null;
				DroneData droneById = GetDroneById(ActiveDrone.UniqueId);
				if (droneById != null)
				{
					Drones.Remove(droneById);
				}
				ResetActiveDrone();
				return;
			}
			_backupDrone.Save(GetCurrentFilePath(_backupDrone));
			DroneData droneById2 = GetDroneById(ActiveDrone.UniqueId);
			if (droneById2 != null)
			{
				Drones[Drones.IndexOf(droneById2)] = _backupDrone;
			}
			ResetActiveDrone();
			_backupDrone = null;
		}

		public void StoreDroneBackup()
		{
			DroneData backupDrone = ActiveDrone.Clone();
			_backupDrone = backupDrone;
		}

		public void SaveDrone(DroneData drone, string path)
		{
			if (!path.EndsWith("drn"))
			{
				path += ".drn";
			}
			drone.Save(path);
		}

		public void Save(DroneData item)
		{
			if (Drones.Contains(item))
			{
				item.Save(GetCurrentFilePath(item));
			}
		}

		public void DeleteDrone(DroneData information)
		{
			File.Delete(GetCurrentFilePath(information));
			foreach (KeyValuePair<int, DroneData> item in ActiveDrones.Where((KeyValuePair<int, DroneData> kvp) => kvp.Value == information).ToList())
			{
				ActiveDrones.Remove(item.Key);
			}
			Drones.RemoveAll((DroneData d) => d.UniqueId == information.UniqueId);
		}

		private string GetCurrentFilePath(DroneData data)
		{
			return Path.Combine(SaveManager.GetActiveDroneFolderPath(), data.UniqueId + ".drn");
		}

		public void SetActiveDrone(DroneData data, int index = -1)
		{
			if (index < 0)
			{
				index = ActiveDroneIndex;
			}
			if (ActiveDrones.ContainsKey(index))
			{
				if (ActiveDrones[index] != data)
				{
					ActiveDrones[index] = data;
					if (DronePartManager.Instance != null)
					{
						DronePartManager.Instance.ReloadActiveDrone();
					}
				}
			}
			else
			{
				ActiveDrones.Add(index, data);
				if (DronePartManager.Instance != null)
				{
					DronePartManager.Instance.ReloadActiveDrone();
				}
			}
		}

		public void ResetActiveDrone(int index = -1)
		{
			if (index < 0)
			{
				index = ActiveDroneIndex;
			}
			if (ActiveDrones.ContainsKey(index))
			{
				ActiveDrones.Remove(index);
			}
		}

		public void ClearActiveDrones()
		{
			ActiveDrones.Clear();
		}

		public DroneData GetActiveDrone(int index)
		{
			if (ActiveDrones.ContainsKey(index))
			{
				return ActiveDrones[index];
			}
			return null;
		}

		protected override void LoadFromFile(DroneManagerData data)
		{
		}

		protected override DroneManagerData SaveToFile()
		{
			return new DroneManagerData();
		}

		public bool IsDroneEditable(DroneData activeDrone)
		{
			if (activeDrone == null)
			{
				return false;
			}
			if (Drones == null || !Drones.Contains(activeDrone))
			{
				if (SteamDrones != null)
				{
					return SteamDrones.Contains(activeDrone);
				}
				return false;
			}
			return true;
		}
	}
}
