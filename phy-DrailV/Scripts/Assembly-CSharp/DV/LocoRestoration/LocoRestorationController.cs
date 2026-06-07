using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.Customization.Paint;
using DV.Damage;
using DV.JObjectExtstensions;
using DV.Logic.Job;
using DV.OriginShift;
using DV.PitStops;
using DV.Shops;
using DV.Simulation.Cars;
using DV.ThingTypes;
using DV.UserManagement;
using DV.Utils;
using LocoSim.Resources;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.LocoRestoration
{
	public class LocoRestorationController : MonoBehaviour
	{
		public enum RestorationState
		{
			S0_Initialized = 0,
			S1_UnlockedRestorationLicense = 1,
			S2_LocoUnblocked = 2,
			S3_RerailedCars = 3,
			S4_OnDestinationTrack = 4,
			S5_PartOrdered = 5,
			S6_PartPickedUp = 6,
			S7_PartDelivered = 7,
			S8_PartInstalled = 8,
			S9_LocoServiced = 9,
			S10_PaintJobDone = 10
		}

		private const string STATE_SAVE_KEY = "state";

		private const string LOCO_GUID_SAVE_KEY = "loco";

		private const string SECOND_CAR_GUID_SAVE_KEY = "secondCar";

		private const string TRANSPORTING_CARS_ARRAY_SAVE_KEY = "transCars";

		private const float DELIVER_PART_CHECK_CORO_PERIOD = 10f;

		private const float CAR_NOT_MOVING_THRESHOLD_M_PER_S = 0.25f;

		public static List<LocoRestorationController> allLocoRestorationControllers = new List<LocoRestorationController>();

		[Header("Base setup")]
		public GeneralLicenseType_v2 requiredRestorationLicense;

		public GarageCarSpawner garageSpawner;

		public string destinationTrackId;

		public Transform restorationAreaAnchor;

		public string restorationAreaLocKey;

		public float restorationAreaRadius = 10f;

		public PaintTheme abandonedTheme;

		public PaintTheme primerTheme;

		public LocoRestorationSpawnPoint[] spawnPoints;

		[Header("Main loco setup - set blockers only if it doesn't exist on prefab")]
		public TrainCarLivery locoLivery;

		public GameObject locoBlockerPrefab;

		[Header("Second car setup - set blockers only if it doesn't exist on prefab")]
		public TrainCarLivery secondCarLivery;

		public GameObject secondCarBlockerPrefab;

		[Header("Loco parts cargo")]
		public CargoType_v2 locoPartCargo;

		public WarehouseMachineController warehouseMachineForPartPickup;

		public AudioClip partInstallationAudio;

		[Header("Loco parts cash register modules")]
		public GenericThingCashRegisterModule orderPartsModule;

		public GenericThingCashRegisterModule installPartsModule;

		private TrainCar loco;

		private TrainCar secondCar;

		private List<TrainCar> transportingCars;

		private RailTrack destinationRailTrack;

		private WarehouseSpecialDelivery locoPartDelivery;

		private JObject saveData;

		private bool loadingDone;

		private Coroutine unexpectedDestroyHandlingCoro;

		private int lastStateChangeFrame = -1;

		private RestorationState previousState;

		public string SaveID => locoLivery.id;

		public RestorationState State { get; private set; }

		public event Action<LocoRestorationController, TrainCarLivery, RestorationState> StateChanged;

		public static JObject GetSaveData()
		{
			JObject jObject = new JObject();
			foreach (LocoRestorationController allLocoRestorationController in allLocoRestorationControllers)
			{
				jObject.SetJObject(allLocoRestorationController.SaveID, allLocoRestorationController.saveData);
			}
			return jObject;
		}

		private void Awake()
		{
			allLocoRestorationControllers.Add(this);
		}

		private void OnDestroy()
		{
			allLocoRestorationControllers.Remove(this);
		}

		private IEnumerator Start()
		{
			if (!(SingletonBehaviour<UserManager>.Instance?.CurrentUser?.CurrentSession?.GameMode == "Career"))
			{
				UnityEngine.Object.Destroy(this);
				base.gameObject.SetActive(value: false);
				yield break;
			}
			destinationRailTrack = SingletonBehaviour<RailTrackRegistryBase>.Instance.GetTrackWithName(destinationTrackId);
			if (destinationRailTrack == null)
			{
				Debug.LogError("Unexpected state: Can't find destinationRailTrack, id: " + destinationTrackId + ". Destroying self!");
				UnityEngine.Object.Destroy(this);
				yield break;
			}
			if (orderPartsModule == null)
			{
				Debug.LogError("Unexpected state: orderPartsModule is null. Destroying self!");
				UnityEngine.Object.Destroy(this);
				yield break;
			}
			if (installPartsModule == null)
			{
				Debug.LogError("Unexpected state: installPartsModule is null. Destroying self!");
				UnityEngine.Object.Destroy(this);
				yield break;
			}
			if (warehouseMachineForPartPickup == null)
			{
				Debug.LogError("Unexpected state: warehouseMachineForPartPickup is null. Destroying self!");
				UnityEngine.Object.Destroy(this);
				yield break;
			}
			if (locoPartCargo == null)
			{
				Debug.LogError("Unexpected state: locoPartCargo is null. Destroying self!");
				UnityEngine.Object.Destroy(this);
				yield break;
			}
			if (garageSpawner == null)
			{
				Debug.LogError("Unexpected state: garageSpawner is null. Destroying self!");
				UnityEngine.Object.Destroy(this);
				yield break;
			}
			if (spawnPoints == null)
			{
				Debug.LogError("Unexpected state: spawnPoints are null. Destroying self!");
				UnityEngine.Object.Destroy(this);
				yield break;
			}
			while (!AStartGameData.carsAndJobsLoadingFinished)
			{
				yield return null;
			}
			if (loco == null)
			{
				Bounds bounds = locoLivery.prefab.GetComponent<TrainCar>().Bounds;
				Transform transform = null;
				List<LocoRestorationSpawnPoint> list = new List<LocoRestorationSpawnPoint>(spawnPoints);
				list.Shuffle();
				foreach (LocoRestorationSpawnPoint item in list)
				{
					if (!item.pointUsed)
					{
						Transform transform2 = item.transform;
						if (!CarSpawner.IsBoxOverlappingSimple(transform2.position + transform2.up * bounds.center.y + transform2.forward * bounds.center.z, bounds.extents, transform2.rotation))
						{
							transform = transform2;
							item.pointUsed = true;
							break;
						}
						Debug.LogError("Spawn anchor " + item.gameObject.GetPath() + " was blocked");
					}
				}
				if (transform == null)
				{
					Debug.LogError("Something is crucially wrong, couldn't find a spot to spawn restoration loco! Will use spawnPoint[0]");
					transform = spawnPoints[0].transform;
				}
				loco = SingletonBehaviour<CarSpawner>.Instance.SpawnDerailedCar(locoLivery.prefab, transform.position, transform.rotation, playerSpawnedCar: true, uniqueCar: true);
				if (CarTypes.IsSteamLocomotive(loco.carLivery))
				{
					loco.SimController.portsOverrider.BoilerSpecialRequest(1f);
				}
				InitCarForRestoration(loco, locoBlockerPrefab, subToUnblocked: true);
				if (secondCarLivery != null && secondCar == null)
				{
					Bounds bounds2 = secondCarLivery.prefab.GetComponent<TrainCar>().Bounds;
					Vector3 vector = transform.position + transform.forward * bounds.center.z - transform.forward * bounds.extents.z - transform.forward * 0.3f + transform.up * bounds2.center.y - transform.forward * bounds2.extents.z;
					if (CarSpawner.IsBoxOverlappingSimple(vector, bounds2.extents, transform.rotation))
					{
						Debug.LogError("Spawn anchor " + transform.gameObject.GetPath() + " was blocked for second car");
					}
					Vector3 position = vector - transform.up * bounds2.center.y - transform.forward * bounds2.center.z;
					secondCar = SingletonBehaviour<CarSpawner>.Instance.SpawnDerailedCar(secondCarLivery.prefab, position, transform.rotation, playerSpawnedCar: true, uniqueCar: true);
					InitCarForRestoration(secondCar, secondCarBlockerPrefab, subToUnblocked: false);
				}
				saveData = new JObject();
				SetState(RestorationState.S0_Initialized);
				saveData.SetString("loco", loco.CarGUID);
				if (secondCar != null)
				{
					saveData.SetString("secondCar", secondCar.CarGUID);
				}
			}
			loadingDone = true;
		}

		private void InitCarForRestoration(TrainCar car, GameObject blockerPrefab, bool subToUnblocked, bool dataLoaded = false)
		{
			if (!dataLoaded)
			{
				if (car.PaintExterior != null)
				{
					car.PaintExterior.CurrentTheme = abandonedTheme;
				}
				if (car.PaintInterior != null)
				{
					car.PaintInterior.CurrentTheme = abandonedTheme;
				}
				if (car.TryGetComponent<DamageController>(out var component))
				{
					component.DamageFullyAll();
					if (component.windows != null)
					{
						component.windows.windowsBroken = true;
					}
				}
				if (car.TryGetComponent<SimController>(out var component2) && component2.resourceContainerController != null)
				{
					component2.resourceContainerController.DepleteAllResourceContainers();
				}
			}
			car.preventFastTravelWithCar = true;
			car.preventFastTravelDestination = true;
			if (car.FastTravelDestination != null)
			{
				car.FastTravelDestination.showOnMap = false;
				car.FastTravelDestination.RefreshMarkerVisibility();
			}
			car.preventDebtDisplay = true;
			car.preventRerail = true;
			car.preventDelete = true;
			car.preventService = true;
			car.preventCouple = true;
			car.OnDestroyCar += OnUnexpectedDestroy;
			LocoZoneBlocker componentInChildren = car.GetComponentInChildren<LocoZoneBlocker>();
			if (componentInChildren != null)
			{
				componentInChildren.additionalLicenseRequired = requiredRestorationLicense;
				if (subToUnblocked)
				{
					SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired += OnRestorationLicenseAcquired;
					componentInChildren.Unblocked += OnBlockersRemovedWrapper;
				}
			}
			else if (blockerPrefab != null)
			{
				componentInChildren = UnityEngine.Object.Instantiate(blockerPrefab, car.transform, worldPositionStays: false).GetComponent<LocoZoneBlocker>();
				componentInChildren.cab = car.cabTeleportDestination;
				componentInChildren.additionalLicenseRequired = requiredRestorationLicense;
				if (subToUnblocked)
				{
					SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired += OnRestorationLicenseAcquired;
					componentInChildren.Unblocked += OnBlockersRemovedWrapper;
				}
			}
			else
			{
				Debug.LogError("Unexpected state: Missing blocker prefab on LocoRestorationController: " + base.gameObject.GetPath());
			}
		}

		private void SetState(RestorationState newState)
		{
			State = newState;
			saveData.SetInt("state", (int)newState);
			Debug.Log(string.Format("{0}[{1}]: {2} @ {3}", "LocoRestorationController", locoLivery.id, newState, Time.frameCount));
			if (loadingDone && newState >= RestorationState.S1_UnlockedRestorationLicense && (Time.frameCount > lastStateChangeFrame + 1 || previousState != RestorationState.S1_UnlockedRestorationLicense))
			{
				string statusMessageFor = LocoRestorationView.GetStatusMessageFor(locoLivery, newState, popupMode: true);
				if (!string.IsNullOrEmpty(statusMessageFor))
				{
					SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(statusMessageFor + "\n\n" + TutorialHelper.GetContinuePromptSuffix(), null, Vector3.zero, localize: false, targetIsUI: false, TutorialHelper.SoundType.Acknowledge, manualDismiss: true);
				}
			}
			lastStateChangeFrame = Time.frameCount;
			previousState = newState;
			this.StateChanged?.Invoke(this, locoLivery, newState);
		}

		private void OnRestorationLicenseAcquired(GeneralLicenseType_v2 acquiredLicense)
		{
			if (!(acquiredLicense != requiredRestorationLicense))
			{
				SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired -= OnRestorationLicenseAcquired;
				if (State == RestorationState.S0_Initialized)
				{
					SetState(RestorationState.S1_UnlockedRestorationLicense);
				}
			}
		}

		private void OnBlockersRemovedWrapper()
		{
			OnBlockersRemoved(subToRerailed: true);
		}

		private void OnBlockersRemoved(bool subToRerailed)
		{
			SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired -= OnRestorationLicenseAcquired;
			if (State != RestorationState.S1_UnlockedRestorationLicense)
			{
				SetState(RestorationState.S1_UnlockedRestorationLicense);
			}
			SetState(RestorationState.S2_LocoUnblocked);
			loco.preventRerail = false;
			loco.preventCouple = false;
			if (secondCar != null)
			{
				secondCar.preventRerail = false;
				secondCar.preventCouple = false;
			}
			if (subToRerailed)
			{
				loco.OnRerailed += OnRerailed;
				if ((bool)secondCar)
				{
					secondCar.OnRerailed += OnRerailed;
				}
			}
		}

		private void OnRerailed()
		{
			if (!loco.derailed && (!(secondCar != null) || !secondCar.derailed))
			{
				loco.OnRerailed -= OnRerailed;
				if ((bool)secondCar)
				{
					secondCar.OnRerailed -= OnRerailed;
				}
				SetState(RestorationState.S3_RerailedCars);
				SetupTrackChangedCheck();
			}
		}

		private void SetupTrackChangedCheck()
		{
			loco.logicCar.CurrentTrackChanged += OnTrackChanged;
			if (secondCar != null)
			{
				secondCar.logicCar.CurrentTrackChanged += OnTrackChanged;
			}
			OnTrackChanged();
		}

		private void OnTrackChanged()
		{
			if (loco.logicCar.CurrentTrack == destinationRailTrack.LogicTrack() && (!(secondCar != null) || secondCar.logicCar.CurrentTrack == destinationRailTrack.LogicTrack()))
			{
				loco.logicCar.CurrentTrackChanged -= OnTrackChanged;
				if (secondCar != null)
				{
					secondCar.logicCar.CurrentTrackChanged -= OnTrackChanged;
				}
				SetState(RestorationState.S4_OnDestinationTrack);
				orderPartsModule.AddThingToCart();
				orderPartsModule.ThingBought += OnPartsOrdered;
			}
		}

		private void OnPartsOrdered()
		{
			orderPartsModule.ThingBought -= OnPartsOrdered;
			SetState(RestorationState.S5_PartOrdered);
			locoPartDelivery = new WarehouseSpecialDelivery(loco.ID, new List<CargoType_v2> { locoPartCargo }, WarehouseTaskType.Loading);
			warehouseMachineForPartPickup.warehouseMachine.AddSpecialDelivery(locoPartDelivery);
			locoPartDelivery.Processed += OnOrderedPartLoadedCargo;
		}

		private void OnOrderedPartLoadedCargo(List<Car> cars)
		{
			locoPartDelivery.Processed -= OnOrderedPartLoadedCargo;
			locoPartDelivery = null;
			transportingCars = TrainCar.ExtractTrainCars(cars);
			foreach (TrainCar transportingCar in transportingCars)
			{
				transportingCar.preventFastTravelWithCar = true;
				transportingCar.preventDelete = true;
			}
			string[] array = new string[transportingCars.Count];
			for (int i = 0; i < transportingCars.Count; i++)
			{
				array[i] = transportingCars[i].CarGUID;
			}
			saveData.SetStringArray("transCars", array);
			SetState(RestorationState.S6_PartPickedUp);
			StartCoroutine(DeliverPartCoro());
		}

		private IEnumerator DeliverPartCoro()
		{
			float sqrRadius = restorationAreaRadius * restorationAreaRadius;
			do
			{
				yield return WaitFor.Seconds(10f);
			}
			while (!transportingCars.TrueForAll((TrainCar c) => (c.transform.position - restorationAreaAnchor.position).sqrMagnitude < sqrRadius) || !transportingCars.TrueForAll((TrainCar c) => c.GetAbsSpeed() < 0.25f));
			foreach (TrainCar transportingCar in transportingCars)
			{
				transportingCar.preventFastTravelWithCar = false;
				transportingCar.preventDelete = false;
				Car logicCar = transportingCar.logicCar;
				if (logicCar.CurrentCargoTypeInCar != CargoType.None)
				{
					logicCar.UnloadCargo(logicCar.LoadedCargoAmount, logicCar.CurrentCargoTypeInCar, warehouseMachineForPartPickup.warehouseMachine);
				}
				else
				{
					Debug.LogError("Unexpected state: transportingCars: " + transportingCar.ID + " wasn't loaded with loco part! Continuing just as the part was delivered");
				}
			}
			transportingCars = null;
			SetState(RestorationState.S7_PartDelivered);
			installPartsModule.AddThingToCart();
			installPartsModule.ThingBought += OnInstallPartsPaid;
		}

		private void OnInstallPartsPaid()
		{
			if (partInstallationAudio != null)
			{
				partInstallationAudio.Play(loco.transform.position, 1f, 1f, 0f, 1f, 100f, default(AudioSourceCurves), null, base.transform);
			}
			if (CarTypes.IsSteamLocomotive(loco.carLivery))
			{
				loco.SimController.portsOverrider.BoilerSpecialRequest(2f);
			}
			SetupServiceCheck();
			SetState(RestorationState.S8_PartInstalled);
		}

		private void SetupServiceCheck()
		{
			SimulatedCarPitStopParameters component = loco.GetComponent<SimulatedCarPitStopParameters>();
			SimulatedCarPitStopParameters simulatedCarPitStopParameters = ((secondCar != null) ? secondCar.GetComponent<SimulatedCarPitStopParameters>() : null);
			loco.preventService = false;
			if (secondCar != null)
			{
				secondCar.preventService = false;
			}
			component.ParametersUpdated += OnServiceDone;
			if (simulatedCarPitStopParameters != null)
			{
				simulatedCarPitStopParameters.ParametersUpdated += OnServiceDone;
			}
		}

		private void OnServiceDone()
		{
			DamageController component = loco.GetComponent<DamageController>();
			if (component.bodyDamage.currentHealth < component.bodyDamage.maxHealth * 0.5f)
			{
				return;
			}
			ResourceContainerController resourceContainerController = loco.SimController?.resourceContainerController;
			if (resourceContainerController != null && (!resourceContainerController.IsAbovePercentage(ResourceContainerType.FUEL, 0.05f) || !resourceContainerController.IsAbovePercentage(ResourceContainerType.OIL, 0.05f) || !resourceContainerController.IsAbovePercentage(ResourceContainerType.COAL, 0.05f) || !resourceContainerController.IsAbovePercentage(ResourceContainerType.WATER, 0.05f)))
			{
				return;
			}
			if (secondCar != null)
			{
				DamageController component2 = secondCar.GetComponent<DamageController>();
				if (component2 != null && component2.bodyDamage.currentHealth < component2.bodyDamage.maxHealth * 0.5f)
				{
					return;
				}
				ResourceContainerController resourceContainerController2 = secondCar.SimController?.resourceContainerController;
				if (resourceContainerController2 != null && (!resourceContainerController2.IsAbovePercentage(ResourceContainerType.FUEL, 0.05f) || !resourceContainerController2.IsAbovePercentage(ResourceContainerType.OIL, 0.05f) || !resourceContainerController2.IsAbovePercentage(ResourceContainerType.COAL, 0.05f) || !resourceContainerController2.IsAbovePercentage(ResourceContainerType.WATER, 0.05f)))
				{
					return;
				}
			}
			loco.GetComponent<SimulatedCarPitStopParameters>().ParametersUpdated -= OnServiceDone;
			SimulatedCarPitStopParameters simulatedCarPitStopParameters = ((secondCar != null) ? secondCar.GetComponent<SimulatedCarPitStopParameters>() : null);
			if (simulatedCarPitStopParameters != null)
			{
				simulatedCarPitStopParameters.ParametersUpdated -= OnServiceDone;
			}
			SetState(RestorationState.S9_LocoServiced);
			loco.preventDelete = false;
			loco.preventDebtDisplay = false;
			loco.preventFastTravelWithCar = false;
			loco.preventFastTravelDestination = false;
			if (loco.FastTravelDestination != null)
			{
				loco.FastTravelDestination.showOnMap = true;
				loco.FastTravelDestination.RefreshMarkerVisibility();
			}
			if (secondCar != null)
			{
				secondCar.preventDelete = false;
				secondCar.preventDebtDisplay = false;
				secondCar.preventFastTravelWithCar = false;
				secondCar.preventFastTravelDestination = false;
				if (secondCar.FastTravelDestination != null)
				{
					secondCar.FastTravelDestination.showOnMap = true;
					secondCar.FastTravelDestination.RefreshMarkerVisibility();
				}
			}
			garageSpawner.OverrideSpawnedCarReference(loco);
			if (secondCar != null)
			{
				garageSpawner.OverrideSpawnedCarReference(secondCar);
			}
			garageSpawner.AllowSpawning();
			SingletonBehaviour<LicenseManager>.Instance.UnlockGarage(garageSpawner.garageType);
			SetupListenersForPaintJob(on: true);
			OnPaintJobChanged();
		}

		private void OnPaintJobChanged(TrainCarPaint _ = null)
		{
			if ((!(loco != null) || (IsPainted(loco.PaintExterior) && IsPainted(loco.PaintInterior))) && (!(secondCar != null) || (IsPainted(secondCar.PaintExterior) && IsPainted(secondCar.PaintInterior))))
			{
				SetupListenersForPaintJob(on: false);
				SetState(RestorationState.S10_PaintJobDone);
			}
			bool IsPainted(TrainCarPaint tcPaint)
			{
				if (tcPaint == null)
				{
					return true;
				}
				if (tcPaint.CurrentTheme != abandonedTheme)
				{
					return tcPaint.CurrentTheme != primerTheme;
				}
				return false;
			}
		}

		private void SetupListenersForPaintJob(bool on)
		{
			if (on)
			{
				if (loco.PaintExterior != null)
				{
					loco.PaintExterior.OnThemeChanged += OnPaintJobChanged;
				}
				if (loco.PaintInterior != null)
				{
					loco.PaintInterior.OnThemeChanged += OnPaintJobChanged;
				}
				if (secondCar != null)
				{
					if (secondCar.PaintExterior != null)
					{
						secondCar.PaintExterior.OnThemeChanged += OnPaintJobChanged;
					}
					if (secondCar.PaintInterior != null)
					{
						secondCar.PaintInterior.OnThemeChanged += OnPaintJobChanged;
					}
				}
				return;
			}
			if (loco.PaintExterior != null)
			{
				loco.PaintExterior.OnThemeChanged -= OnPaintJobChanged;
			}
			if (loco.PaintInterior != null)
			{
				loco.PaintInterior.OnThemeChanged -= OnPaintJobChanged;
			}
			if (secondCar != null)
			{
				if (secondCar.PaintExterior != null)
				{
					secondCar.PaintExterior.OnThemeChanged -= OnPaintJobChanged;
				}
				if (secondCar.PaintInterior != null)
				{
					secondCar.PaintInterior.OnThemeChanged -= OnPaintJobChanged;
				}
			}
		}

		private IEnumerator UnexpectedDestroyUnservicedLocoHandling()
		{
			yield return Start();
			Debug.LogError($"Loco respawned at: {loco.transform.AbsolutePosition()}");
		}

		private IEnumerator UnexpectedDestroyServicedLocoHandling()
		{
			if (State == RestorationState.S9_LocoServiced)
			{
				SetupListenersForPaintJob(on: false);
			}
			yield return WaitFor.EndOfFrame;
			List<TrainCar> list = garageSpawner.ForceCarsRespawn();
			if (list == null || list.Count == 0)
			{
				Debug.LogError("Unexpected state: Some demonstrator cars should have been spawned in attempt to recover from deletion!");
				unexpectedDestroyHandlingCoro = null;
				yield break;
			}
			foreach (TrainCar item in list)
			{
				if (item.carLivery == locoLivery)
				{
					loco = item;
				}
				else if (item.carLivery == secondCarLivery)
				{
					secondCar = item;
				}
				item.OnDestroyCar += OnUnexpectedDestroy;
			}
			if (State == RestorationState.S9_LocoServiced)
			{
				SetupListenersForPaintJob(on: true);
			}
			saveData.SetString("loco", loco.CarGUID);
			if (secondCar != null)
			{
				saveData.SetString("secondCar", secondCar.CarGUID);
			}
			unexpectedDestroyHandlingCoro = null;
		}

		private void OnUnexpectedDestroy(TrainCar destroyedCar)
		{
			destroyedCar.OnDestroyCar -= OnUnexpectedDestroy;
			if (State >= RestorationState.S9_LocoServiced)
			{
				Debug.LogError("Unexpected state: Last resort of respawning loco to garage");
				if (unexpectedDestroyHandlingCoro == null)
				{
					unexpectedDestroyHandlingCoro = StartCoroutine(UnexpectedDestroyServicedLocoHandling());
				}
				return;
			}
			if (destroyedCar == loco)
			{
				loco = null;
				if (secondCar != null)
				{
					secondCar.OnDestroyCar -= OnUnexpectedDestroy;
					SingletonBehaviour<CarSpawner>.Instance.DeleteCar(secondCar);
					secondCar = null;
				}
			}
			else if (destroyedCar == secondCar)
			{
				secondCar = null;
				if (loco != null)
				{
					loco.OnDestroyCar -= OnUnexpectedDestroy;
					SingletonBehaviour<CarSpawner>.Instance.DeleteCar(loco);
					loco = null;
				}
			}
			StopAllCoroutines();
			if (locoPartDelivery != null)
			{
				warehouseMachineForPartPickup.warehouseMachine.RemoveSpecialDelivery(locoPartDelivery);
				locoPartDelivery.Processed -= OnOrderedPartLoadedCargo;
				locoPartDelivery = null;
			}
			SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired -= OnRestorationLicenseAcquired;
			orderPartsModule.ThingBought -= OnPartsOrdered;
			installPartsModule.ThingBought -= OnInstallPartsPaid;
			if (transportingCars != null)
			{
				foreach (TrainCar transportingCar in transportingCars)
				{
					transportingCar.preventFastTravelWithCar = false;
					transportingCar.preventDelete = false;
					Car logicCar = transportingCar.logicCar;
					if (logicCar.CurrentCargoTypeInCar != CargoType.None)
					{
						logicCar.UnloadCargo(logicCar.LoadedCargoAmount, logicCar.CurrentCargoTypeInCar, warehouseMachineForPartPickup.warehouseMachine);
					}
				}
			}
			Debug.LogError("Unexpected state: Last resort of respawning new loco to new restore point");
			StartCoroutine(UnexpectedDestroyUnservicedLocoHandling());
		}

		public void LoadData(JObject restorationData)
		{
			bool flag = loadingDone;
			int? num = restorationData.GetInt("state");
			if (!num.HasValue || !Enum.IsDefined(typeof(RestorationState), num))
			{
				Debug.LogError("Unexpected state: Missing state data for LocoRestorationController: " + locoLivery.id);
				loadingDone = flag;
				return;
			}
			string text = restorationData.GetString("loco");
			if (text == null)
			{
				Debug.LogError("Unexpected state: Missing locoGuid for LocoRestorationController: " + locoLivery.id);
				loadingDone = flag;
				return;
			}
			string text2 = null;
			if (secondCarLivery != null)
			{
				text2 = restorationData.GetString("secondCar");
			}
			loco = SingletonBehaviour<TrainCarRegistry>.Instance.GetTrainCarByCarGuid(text);
			if (secondCarLivery != null && text2 != null)
			{
				secondCar = SingletonBehaviour<TrainCarRegistry>.Instance.GetTrainCarByCarGuid(text2);
			}
			if (loco == null)
			{
				if (secondCar != null)
				{
					UnityEngine.Object.Destroy(secondCar);
					secondCar = null;
				}
				Debug.LogError("Unexpected state: loco not found with guid: " + text + ", LocoRestorationController: " + locoLivery.id);
				loadingDone = flag;
				return;
			}
			if (secondCarLivery != null && secondCar == null)
			{
				UnityEngine.Object.Destroy(loco);
				loco = null;
				Debug.LogError("Unexpected state: Missing secondCarGuid for LocoRestorationController: " + locoLivery.id);
				loadingDone = flag;
				return;
			}
			saveData = restorationData;
			RestorationState restorationState = (RestorationState)num.Value;
			switch (restorationState)
			{
			case RestorationState.S0_Initialized:
			case RestorationState.S1_UnlockedRestorationLicense:
			case RestorationState.S2_LocoUnblocked:
				InitCarForRestoration(loco, locoBlockerPrefab, subToUnblocked: true, dataLoaded: true);
				if (secondCar != null)
				{
					InitCarForRestoration(secondCar, secondCarBlockerPrefab, subToUnblocked: false, dataLoaded: true);
				}
				break;
			case RestorationState.S3_RerailedCars:
				InitCarForRestoration(loco, locoBlockerPrefab, subToUnblocked: false, dataLoaded: true);
				if (secondCar != null)
				{
					InitCarForRestoration(secondCar, secondCarBlockerPrefab, subToUnblocked: false, dataLoaded: true);
				}
				OnBlockersRemoved(subToRerailed: false);
				SetupTrackChangedCheck();
				break;
			case RestorationState.S4_OnDestinationTrack:
				InitCarForRestoration(loco, locoBlockerPrefab, subToUnblocked: false, dataLoaded: true);
				if (secondCar != null)
				{
					InitCarForRestoration(secondCar, secondCarBlockerPrefab, subToUnblocked: false, dataLoaded: true);
				}
				OnBlockersRemoved(subToRerailed: false);
				orderPartsModule.AddThingToCart();
				orderPartsModule.ThingBought += OnPartsOrdered;
				break;
			case RestorationState.S5_PartOrdered:
				InitCarForRestoration(loco, locoBlockerPrefab, subToUnblocked: false, dataLoaded: true);
				if (secondCar != null)
				{
					InitCarForRestoration(secondCar, secondCarBlockerPrefab, subToUnblocked: false, dataLoaded: true);
				}
				OnBlockersRemoved(subToRerailed: false);
				OnPartsOrdered();
				break;
			case RestorationState.S6_PartPickedUp:
			{
				InitCarForRestoration(loco, locoBlockerPrefab, subToUnblocked: false, dataLoaded: true);
				if (secondCar != null)
				{
					InitCarForRestoration(secondCar, secondCarBlockerPrefab, subToUnblocked: false, dataLoaded: true);
				}
				OnBlockersRemoved(subToRerailed: false);
				string[] stringArray = saveData.GetStringArray("transCars");
				if (stringArray == null)
				{
					Debug.LogError("Unexpected state: transportingCarsGuids not found in saveData. Backtracking to previous step");
					OnPartsOrdered();
					restorationState = RestorationState.S5_PartOrdered;
					break;
				}
				List<TrainCar> source = stringArray.Select((string carGuid) => SingletonBehaviour<TrainCarRegistry>.Instance.GetTrainCarByCarGuid(carGuid)).ToList();
				if (source.Any((TrainCar c) => c == null))
				{
					Debug.LogError("Unexpected state: transportingCarsGuids not found in saveData. Backtracking to previous step");
					OnPartsOrdered();
					restorationState = RestorationState.S5_PartOrdered;
					break;
				}
				transportingCars = source;
				foreach (TrainCar transportingCar in transportingCars)
				{
					if (transportingCar.LoadedCargo == CargoType.None)
					{
						Debug.LogError("Unexpected state: transportingCars: " + transportingCar.ID + " is not loaded. Something is wrong!");
					}
					transportingCar.preventFastTravelWithCar = true;
					transportingCar.preventDelete = true;
				}
				StartCoroutine(DeliverPartCoro());
				break;
			}
			case RestorationState.S7_PartDelivered:
				InitCarForRestoration(loco, locoBlockerPrefab, subToUnblocked: false, dataLoaded: true);
				if (secondCar != null)
				{
					InitCarForRestoration(secondCar, secondCarBlockerPrefab, subToUnblocked: false, dataLoaded: true);
				}
				OnBlockersRemoved(subToRerailed: false);
				installPartsModule.AddThingToCart();
				installPartsModule.ThingBought += OnInstallPartsPaid;
				break;
			case RestorationState.S8_PartInstalled:
				InitCarForRestoration(loco, locoBlockerPrefab, subToUnblocked: false, dataLoaded: true);
				if (secondCar != null)
				{
					InitCarForRestoration(secondCar, secondCarBlockerPrefab, subToUnblocked: false, dataLoaded: true);
				}
				OnBlockersRemoved(subToRerailed: false);
				SetupServiceCheck();
				break;
			case RestorationState.S9_LocoServiced:
				garageSpawner.AllowSpawning();
				SetupListenersForPaintJob(on: true);
				loco.OnDestroyCar += OnUnexpectedDestroy;
				if (secondCar != null)
				{
					secondCar.OnDestroyCar += OnUnexpectedDestroy;
				}
				break;
			case RestorationState.S10_PaintJobDone:
				garageSpawner.AllowSpawning();
				loco.OnDestroyCar += OnUnexpectedDestroy;
				if (secondCar != null)
				{
					secondCar.OnDestroyCar += OnUnexpectedDestroy;
				}
				break;
			default:
				Debug.LogError("Unexpected state: Unhandled case for " + restorationState);
				break;
			}
			SetState(restorationState);
			loadingDone = flag;
		}

		public static LocoRestorationController GetForTrainCar(TrainCar car)
		{
			return allLocoRestorationControllers.FirstOrDefault((LocoRestorationController c) => c.loco == car || c.secondCar == car);
		}

		public static LocoRestorationController GetForLivery(TrainCarLivery livery)
		{
			return allLocoRestorationControllers.FirstOrDefault((LocoRestorationController c) => c.locoLivery == livery || (c.secondCar != null && c.secondCar.carLivery == livery));
		}
	}
}
