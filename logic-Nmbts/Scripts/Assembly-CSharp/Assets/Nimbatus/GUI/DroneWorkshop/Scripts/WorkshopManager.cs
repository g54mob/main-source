using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.Tutorial;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Tutorial;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class WorkshopManager : SerializedMonoBehaviour
	{
		public List<GameObject> DisableOnTutorial = new List<GameObject>();

		public List<GameObject> EnableOnTutorial = new List<GameObject>();

		public GameObject WorkshopButton;

		public EnableTags TagButton;

		public TweenTutorial ShowTutorialButton;

		public Transform TransparencySlider;

		public LoadAllDroneParts DronePartList;

		public GameObject CampaignTutorialPopup;

		public UIGrid WarningGrid;

		public GameObject KeyAssignWarning;

		public GameObject OverlapWarning;

		public GameObject NoFuelWarning;

		public GameObject NoBatteryWarning;

		public GameObject InstabilityWarning;

		public GameObject PerformanceWarning;

		public void Awake()
		{
			CampaignTutorialPopup.SetActive(true);
			DronePartList.SelectedDronePartType = EDronePartType.None;
			WorkshopButton.SetActive(RuntimeGlobals.HasWeaponWorkshop);
			if (GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.ActiveTutorial != null)
			{
				foreach (GameObject item in DisableOnTutorial)
				{
					item.SetActive(false);
				}
				foreach (GameObject item2 in EnableOnTutorial)
				{
					item2.SetActive(true);
				}
				TagButton.gameObject.SetActive(GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.Subtutorial.AllowTags);
				if (GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.Subtutorial.AllowTags)
				{
					ShowTutorialButton.GetComponent<UITexture>().leftAnchor.absolute += 40;
					ShowTutorialButton.GetComponent<UITexture>().rightAnchor.absolute += 40;
					TransparencySlider.GetComponent<UILabel>().leftAnchor.absolute += 40;
					TransparencySlider.GetComponent<UILabel>().rightAnchor.absolute += 40;
				}
				WorkshopButton.SetActive(false);
				if (GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.FirstVisit)
				{
					Debug.Log("Workshop in Tutorial Mode for " + GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.ActiveTutorial.Name);
					ShowTutorialButton.ShowTutorial(true);
					SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ClearActiveDrones();
					if (GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.Subtutorial.CustomDrone)
					{
						DroneData data = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.LoadDefaultDrone(GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.Subtutorial.Drone);
						SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SetActiveDrone(data);
					}
					else
					{
						DroneData droneById = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetDroneById("TutorialDrone");
						if (droneById != null)
						{
							SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.DeleteDrone(droneById);
						}
						DroneData droneData = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.CreateDrone("TutorialDrone");
						droneData.UniqueId = "TutorialDrone";
						SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SetActiveDrone(droneData);
					}
					GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.FirstVisit = false;
				}
			}
			else if (RuntimeGlobals.GameModeSettings.InCampaignTutorial)
			{
				TagButton.gameObject.SetActive(false);
				ShowTutorialButton.gameObject.SetActive(true);
			}
			StartCoroutine(CheckWarnings());
		}

		public IEnumerator CheckWarnings()
		{
			while (true)
			{
				List<DronePart> parts = DronePartManager.Instance.ActiveDrone.RootDronePart.GetAllChildParts<DronePart>();
				List<EDronePartType> types = new List<EDronePartType>();
				foreach (DronePart item in parts)
				{
					types.Add(item.DronePartType);
				}
				bool flag = false;
				bool flag2 = false;
				bool showFuelWarning = false;
				bool showBatteryWarning = false;
				bool showInstabilityWarning = false;
				bool showPerformanceWarning = false;
				foreach (DronePart item2 in parts)
				{
					BindableDronePart bindableDronePart;
					if ((object)(bindableDronePart = item2 as BindableDronePart) != null && !flag)
					{
						foreach (KeyBinding keyBinding in bindableDronePart.KeyBindings)
						{
							if (keyBinding.DisplayNotAssignedWarning && keyBinding.KeyCode == KeyCode.None)
							{
								flag = true;
							}
						}
						SensorPart sensorPart;
						if ((object)(sensorPart = bindableDronePart as SensorPart) != null)
						{
							foreach (EventKeyBinding eventBinding in sensorPart.EventBindings)
							{
								if (eventBinding.DisplayNotAssignedWarning && eventBinding.KeyCode == KeyCode.None)
								{
									flag = true;
								}
							}
						}
					}
					if (item2.IsOverlapping && !flag2)
					{
						flag2 = true;
					}
					if (!(item2 is RootDronePart) && item2.Children.Count > 6)
					{
						showInstabilityWarning = true;
					}
				}
				OverlapWarning.SetActive(flag2);
				KeyAssignWarning.SetActive(flag);
				WarningGrid.gameObject.SetActive(true);
				WarningGrid.Reposition();
				WarningGrid.repositionNow = true;
				yield return true;
				List<DroneEffect> activeEffects = SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects;
				SuperchargedBatteries superchargedBatteries = ((activeEffects != null) ? activeEffects.OfType<SuperchargedBatteries>().FirstOrDefault() : null);
				if (parts.Any((DronePart p) => p is IFuelConsumer) && ((superchargedBatteries == null && !types.Contains(EDronePartType.FuelTank)) || (superchargedBatteries != null && !types.Contains(EDronePartType.Battery))))
				{
					showFuelWarning = true;
				}
				NoFuelWarning.SetActive(showFuelWarning);
				WarningGrid.gameObject.SetActive(true);
				WarningGrid.Reposition();
				WarningGrid.repositionNow = true;
				yield return true;
				if (parts.Any((DronePart p) => p is IEnergyConsumer) && !types.Contains(EDronePartType.Battery))
				{
					showBatteryWarning = true;
				}
				NoBatteryWarning.SetActive(showBatteryWarning);
				WarningGrid.gameObject.SetActive(true);
				WarningGrid.Reposition();
				WarningGrid.repositionNow = true;
				yield return true;
				if (DronePartManager.Instance.ActiveDrone.RootDronePart.Children.Count > 15)
				{
					showInstabilityWarning = true;
				}
				InstabilityWarning.SetActive(showInstabilityWarning);
				WarningGrid.gameObject.SetActive(true);
				WarningGrid.Reposition();
				WarningGrid.repositionNow = true;
				yield return true;
				if (parts.Count > 1000 || parts.OfType<Weapon>().Count() > 50)
				{
					showPerformanceWarning = true;
				}
				PerformanceWarning.SetActive(showPerformanceWarning);
				WarningGrid.gameObject.SetActive(true);
				WarningGrid.Reposition();
				WarningGrid.repositionNow = true;
				yield return new WaitForSeconds(0.1f);
			}
		}
	}
}
