using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.CampaignTutorial.Scripts;
using Assets.Nimbatus.GUI.MissionControl.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Controls;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Campaign
{
	public class CampaignTutorialComponent : MonoBehaviour
	{
		public Camera UiCamera;

		public CampaignTutorialArrow TutorialArrow;

		public CampaignTutorialTextbox TutorialTextbox;

		public CampaignTutorialVignette TutorialVignette;

		public List<CampaignTutorialSetting> Tutorials = new List<CampaignTutorialSetting>();

		public CampaignTutorialSetting LastActive { get; private set; }

		public void Start()
		{
			Reset();
			StartCoroutine(WaitForLoad());
		}

		public IEnumerator WaitForLoad()
		{
			while (RuntimeGlobals.IsGameLoading)
			{
				yield return null;
			}
			SerializableMonobehaviour<CampaignTutorialManager, CampaignTutorialSaveData>.Instance.Register(this);
		}

		public void OnDestroy()
		{
			SerializableMonobehaviour<CampaignTutorialManager, CampaignTutorialSaveData>.Instance.Unregister(this);
		}

		public void Init()
		{
			StartCoroutine(_Init());
		}

		public IEnumerator _Init()
		{
			Reset();
			CampaignTutorialSetting campaignTutorialSetting = Tutorials.FirstOrDefault((CampaignTutorialSetting t) => !SerializableMonobehaviour<CampaignTutorialManager, CampaignTutorialSaveData>.Instance.CheckFlag(t.UniqueId));
			CampaignTutorialSetting setting = ((campaignTutorialSetting == null || !campaignTutorialSetting.IsAllowed()) ? null : campaignTutorialSetting);
			if (setting == null || !setting.HasVignette)
			{
				TutorialVignette.SetActive(false);
			}
			else if ((((LastActive != null) ? LastActive.VignetteSetting.VignetteCutoutPosition : Vector3.zero) - setting.VignetteSetting.VignetteCutoutPosition).magnitude < float.Epsilon)
			{
				TutorialVignette.StartCoroutine(TutorialVignette.LerpSize(setting.VignetteSetting.VignetteCutoutSize));
			}
			if (setting == null)
			{
				if (Tutorials.Count - 1 > Tutorials.IndexOf(LastActive))
				{
					StartCoroutine(WaitForNext());
				}
				yield break;
			}
			if (StarmapCamera.Instance != null)
			{
				StarmapCamera.Instance.Blocked = setting.IsMissionControl && setting.MiCoSettings.BlockMapMovement;
				if (setting.IsMissionControl)
				{
					LocationUi locationUi = null;
					GalaxyMapUiManager manager = setting.MiCoSettings.Manager;
					switch (setting.MiCoSettings.Target)
					{
					case EMiCoTutorialTarget.CurrentLocation:
						locationUi = manager.GetLocationUi(SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.UniqueId);
						break;
					case EMiCoTutorialTarget.StartLocation:
						locationUi = manager.GetLocationUi(SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.StartLocationId);
						break;
					case EMiCoTutorialTarget.EndLocation:
						locationUi = manager.GetLocationUi(SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.EndLocationId);
						StarmapCamera.Instance.MoveToLocation(locationUi.transform);
						break;
					case EMiCoTutorialTarget.InfluenceLabel:
						StarmapCamera.Instance.MoveToLocation(setting.MiCoSettings.Manager.GetInfluenceLabelPosition(setting.MiCoSettings.InfIndex));
						break;
					case EMiCoTutorialTarget.SpecificLocation:
					{
						List<LocationData> list = new List<LocationData>();
						foreach (GalaxyMapSector item in SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.Sectors.Where((GalaxyMapSector s) => s is SolarSystem).ToList())
						{
							list.AddRange(((SolarSystem)item).Locations);
						}
						locationUi = manager.GetLocationUi(list[setting.MiCoSettings.LocIndex].UniqueId);
						break;
					}
					}
					if (locationUi != null)
					{
						SerializableMonobehaviour<CampaignTutorialManager, CampaignTutorialSaveData>.Instance.SetFlag("LocationSelected", false);
						locationUi.gameObject.AddMissingComponent<SetCampaignTutorialFlag>().Id = "LocationSelected";
						StarmapCamera.Instance.MoveToLocation(locationUi.transform);
						if (setting.MiCoSettings.SelectLocation)
						{
							locationUi.Select();
						}
					}
					if (setting.MiCoSettings.OverrideZoom)
					{
						StarmapCamera.Instance.StartCoroutine(StarmapCamera.Instance.LerpZoom(setting.MiCoSettings.TargetZoom));
					}
					while (StarmapCamera.Instance != null && (StarmapCamera.Instance.transform.position - StarmapCamera.Instance.TargetPosition).magnitude > 0.5f)
					{
						yield return null;
					}
				}
			}
			if (setting.HasArrow)
			{
				TutorialArrow.Init(setting.ArrowSetting);
			}
			if (setting.HasText)
			{
				TutorialTextbox.Init(setting.TextboxSetting, setting);
			}
			if (setting.HasVignette)
			{
				TutorialVignette.Init(setting.VignetteSetting, UiCamera);
			}
			else
			{
				TutorialVignette.SetActive(false);
			}
			LastActive = setting;
			if (!string.IsNullOrEmpty(setting.WaitForFlag))
			{
				StartCoroutine(WaitForFlag(setting.WaitForFlag));
			}
		}

		public IEnumerator WaitForFlag(string id)
		{
			while (LastActive != null && LastActive.IsAllowed() && !SerializableMonobehaviour<CampaignTutorialManager, CampaignTutorialSaveData>.Instance.CheckFlag(id))
			{
				yield return null;
			}
			if (LastActive != null && !LastActive.IsAllowed())
			{
				LastActive = null;
			}
			SerializableMonobehaviour<CampaignTutorialManager, CampaignTutorialSaveData>.Instance.Next();
		}

		public IEnumerator WaitForNext()
		{
			CampaignTutorialSetting candidate = Tutorials.FirstOrDefault((CampaignTutorialSetting t) => !SerializableMonobehaviour<CampaignTutorialManager, CampaignTutorialSaveData>.Instance.CheckFlag(t.UniqueId));
			CampaignTutorialSetting setting = ((candidate == null || !candidate.IsAllowed()) ? null : candidate);
			if (candidate == null)
			{
				yield break;
			}
			while (setting == null)
			{
				if (candidate.IsAllowed())
				{
					setting = candidate;
				}
				yield return null;
			}
			SerializableMonobehaviour<CampaignTutorialManager, CampaignTutorialSaveData>.Instance.Next();
		}

		public void Reset()
		{
			TutorialArrow.SetActive(false);
			TutorialTextbox.SetActive(false);
			LastActive = null;
		}
	}
}
