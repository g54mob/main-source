using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Nimbatus.Scripts.Campaign
{
	public class CampaignTutorialManager : SerializableMonobehaviour<CampaignTutorialManager, CampaignTutorialSaveData>
	{
		public int TutorialSeed;

		internal List<CampaignTutorialFlagData> TutorialFlags = new List<CampaignTutorialFlagData>();

		private bool IsInTutorial
		{
			get
			{
				if (SaveManager.SelectedSave == null || SaveManager.SelectedSave.Settings == null || !SaveManager.SelectedSave.Settings.ViewCampaignTutorial)
				{
					if (RuntimeGlobals.GameModeSettings != null)
					{
						return RuntimeGlobals.GameModeSettings.InCampaignTutorial;
					}
					return false;
				}
				return true;
			}
		}

		internal CampaignTutorialComponent ActiveTutorial { get; private set; }

		internal override string Filename
		{
			get
			{
				return "CampaignTutorial.xml";
			}
		}

		public void Register(CampaignTutorialComponent tutorial)
		{
			if (IsInTutorial && ActiveTutorial != tutorial)
			{
				ActiveTutorial = tutorial;
				Next();
			}
		}

		public void Unregister(CampaignTutorialComponent tutorial)
		{
			if (IsInTutorial && ActiveTutorial == tutorial)
			{
				ActiveTutorial = null;
			}
		}

		private IEnumerator TutorialSequence()
		{
			yield return new WaitForEndOfFrame();
			while (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance == null || SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy == null || SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.IsLoading)
			{
				yield return null;
			}
			bool first = false;
			bool mainEnd = false;
			bool second = false;
			while (SaveManager.LoadedSave != null && SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy != null && !second)
			{
				int num = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.Sectors.Count((GalaxyMapSector s) => s.Explored) - 1;
				if (!first && SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.Drones.Count > 0)
				{
					SetFlag("DroneCreated");
				}
				if (!first && CheckFlag("DroneCreated"))
				{
					List<DronePrecondition> preconditions = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetPreconditions();
					if (SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.Drones.Count > 0 && SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.Drones.Any((DroneData d) => preconditions.TrueForAll((DronePrecondition p) => p.Check(d))))
					{
						if (SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone == null)
						{
							SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SetActiveDrone(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.Drones.FirstOrDefault());
						}
						SetFlag("DroneHangarInvalid");
						SetFlag("DroneInvalid", false);
						SetFlag("DroneValid");
					}
					else if (SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.Drones.Count <= 0)
					{
						SetFlag("DroneHangarInvalid", false);
						SetFlag("DroneInvalid", false);
						SetFlag("DroneValid", false);
						SetFlag("DroneCreated", false);
					}
					else
					{
						if (SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone == null)
						{
							SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SetActiveDrone(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.Drones.FirstOrDefault());
						}
						SetFlag("DroneHangarInvalid", false);
						SetFlag("DroneHangar3", false);
						SetFlag("DroneHangar4", false);
						SetFlag("DroneInvalid");
						SetFlag("DroneValid", false);
					}
				}
				if (!first && num >= 1)
				{
					first = true;
					SetFlag("FirstMissionCompleted");
					SetFlag("MissionControlEnd", false);
				}
				if (num >= 1 && !mainEnd && SceneManager.GetActiveScene().name != "MainScene")
				{
					mainEnd = true;
					SetFlag("MainEnd");
				}
				if (!second && num >= 2)
				{
					second = true;
					SetFlag("SecondMissionCompleted");
					SetFlag("MissionControlEnd", false);
				}
				yield return null;
			}
			yield return null;
		}

		public void ResetWorkshopFlags()
		{
			int num = 4;
			switch (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.Sectors.Count((GalaxyMapSector s) => s.Explored) - 1)
			{
			case 0:
			{
				for (int num3 = 0; num3 < num; num3++)
				{
					SetFlag(ActiveTutorial.Tutorials[num3].UniqueId, false);
				}
				break;
			}
			case 1:
			{
				for (int num2 = num; num2 < ActiveTutorial.Tutorials.Count; num2++)
				{
					SetFlag(ActiveTutorial.Tutorials[num2].UniqueId, false);
				}
				break;
			}
			}
		}

		public void SetFlag(string id, bool status = true)
		{
			if (!IsInTutorial)
			{
				return;
			}
			if (TutorialFlags.All((CampaignTutorialFlagData f) => f.Id != id))
			{
				TutorialFlags.Add(new CampaignTutorialFlagData
				{
					Id = id,
					Status = status
				});
			}
			else
			{
				TutorialFlags.First((CampaignTutorialFlagData f) => f.Id == id).Status = status;
			}
		}

		public bool CheckFlag(string id)
		{
			if (!IsInTutorial)
			{
				return false;
			}
			if (TutorialFlags.Any((CampaignTutorialFlagData f) => f.Id == id))
			{
				return TutorialFlags.First((CampaignTutorialFlagData f) => f.Id == id).Status;
			}
			return false;
		}

		public void Next()
		{
			if (!IsInTutorial || !(ActiveTutorial != null))
			{
				return;
			}
			if (ActiveTutorial.LastActive != null)
			{
				if (string.IsNullOrEmpty(ActiveTutorial.LastActive.UniqueId))
				{
					throw new Exception("Setting " + ActiveTutorial.Tutorials.IndexOf(ActiveTutorial.LastActive) + " requires an Id");
				}
				SetFlag(ActiveTutorial.LastActive.UniqueId);
			}
			ActiveTutorial.Init();
		}

		protected override void PreLoad()
		{
			base.PreLoad();
			StopAllCoroutines();
			TutorialFlags.Clear();
		}

		protected override void PostLoad()
		{
			base.PostLoad();
			if (IsInTutorial)
			{
				StartCoroutine(TutorialSequence());
			}
		}

		protected override void LoadFromFile(CampaignTutorialSaveData data)
		{
			TutorialFlags = data.TutorialFlags;
		}

		protected override CampaignTutorialSaveData SaveToFile()
		{
			return new CampaignTutorialSaveData
			{
				TutorialFlags = TutorialFlags
			};
		}
	}
}
