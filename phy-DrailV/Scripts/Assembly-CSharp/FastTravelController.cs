using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV;
using DV.Common;
using DV.InventorySystem;
using DV.OriginShift;
using DV.Simulation.Cars;
using DV.Teleporters;
using DV.TerrainSystem;
using DV.ThingTypes;
using DV.UI;
using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;

public class FastTravelController : SingletonBehaviour<FastTravelController>
{
	private const int FAST_TRAVEL_PRICE_PER_KM = 150;

	private const int FAST_TRAVEL_LOCO_MULTIPLIER = 6;

	private const float FAST_TRAVEL_MU_MULTIPLIER_ADDITION_PER_LOCO = 0.5f;

	private const float FAST_TRAVEL_SPEED_KM_PER_H = 39.42f;

	private const float FAST_TRAVEL_SECONDS_PER_KM = 91.3242f;

	public AudioClip teleportNotAllowedSound;

	public AudioClip moneyRemovedSound;

	private FastTravelDestination lastMarkerClicked;

	private FastTravelUIController fastTravelMenu;

	public static bool IsFastTravelling { get; private set; }

	public event Action AboutToFastTravel;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void StaticReload()
	{
		IsFastTravelling = false;
	}

	protected override void Awake()
	{
		base.Awake();
		MapMarkersController.OnMapMarkerUsed += OnMapMarkerPressed;
	}

	private void Start()
	{
		SetupListeners(on: true);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		IsFastTravelling = false;
		MapMarkersController.RemoveMapMarkerInteractionRequest(this);
		MapMarkersController.OnMapMarkerUsed -= OnMapMarkerPressed;
		if (!UnloadWatcher.isUnloading)
		{
			SetupListeners(on: false);
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled += CanvasElementToggled;
			return;
		}
		SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled -= CanvasElementToggled;
		if (fastTravelMenu != null)
		{
			SetupMenuListeners(on: false);
		}
	}

	private void CanvasElementToggled(ACanvasController<CanvasController.ElementType>.Element element)
	{
		if (CanvasController.ElementType.Blockers.HasIntFlag(element.Type))
		{
			if (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(element))
			{
				MapMarkersController.RequestToggleMapMarkerInteraction(this, on: false);
			}
			else
			{
				MapMarkersController.RemoveMapMarkerInteractionRequest(this);
			}
		}
	}

	private void OnMapMarkerPressed(FastTravelDestination marker)
	{
		if (!IsFastTravelling && SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TryGetElement(CanvasController.ElementType.FastTravel, out var element))
		{
			fastTravelMenu = element.reference.GetComponentInChildren<FastTravelUIController>(includeInactive: true);
			if ((bool)fastTravelMenu)
			{
				lastMarkerClicked = marker;
				FastTravelData ftd = ExtractFastTravelData(marker, PlayerManager.Car);
				fastTravelMenu.Show(ftd);
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.FastTravel, on: true);
				SetupMenuListeners(on: true);
			}
		}
	}

	private void CloseFastTravel()
	{
		if ((bool)fastTravelMenu && SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TryGetElement(CanvasController.ElementType.FastTravel, out var element) && SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(element))
		{
			SetupMenuListeners(on: false);
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.FastTravel, on: false);
			fastTravelMenu = null;
		}
	}

	private void SetupMenuListeners(bool on)
	{
		fastTravelMenu.JumpRequested -= OnJumpRequested;
		fastTravelMenu.FastTravelRequested -= OnFastTravelRequested;
		fastTravelMenu.TeleportDenied -= OnTeleportDenied;
		if (on)
		{
			fastTravelMenu.JumpRequested += OnJumpRequested;
			fastTravelMenu.FastTravelRequested += OnFastTravelRequested;
			fastTravelMenu.TeleportDenied += OnTeleportDenied;
		}
	}

	private void OnJumpRequested()
	{
		SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(FastTravel(lastMarkerClicked, FastTravelWithoutLocomotive, skipLoading: true, 0));
	}

	private void OnTeleportDenied()
	{
		teleportNotAllowedSound?.Play2D();
	}

	private void OnFastTravelRequested(bool withLoco)
	{
		FastTravelData ftData = ExtractFastTravelData(lastMarkerClicked, PlayerManager.Car);
		if (!IsFastTravelAllowed(ftData, withLoco))
		{
			Debug.LogWarning("Fast travel conditions changed, aborting fast travel");
			OnTeleportDenied();
			return;
		}
		if (withLoco)
		{
			Debug.Log($"Fast travelling with locomotive(s) to {lastMarkerClicked.MarkerName} for ${ftData.fastTravelWithLocoPrice}");
			if (ftData.fastTravelPrice > 0)
			{
				moneyRemovedSound?.Play2D();
			}
			if (SingletonBehaviour<Inventory>.Instance.RemoveMoney(ftData.fastTravelWithLocoPrice))
			{
				SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(FastTravel(lastMarkerClicked, FastTravelWithLocomotive, skipLoading: false, ftData.fastTravelDuration));
			}
			return;
		}
		if (ftData.isDestinationWithinSameTrainset)
		{
			Debug.Log("Jumping to " + lastMarkerClicked.MarkerName);
		}
		else
		{
			Debug.Log($"Fast travelling to {lastMarkerClicked.MarkerName} for ${ftData.fastTravelPrice}");
		}
		if (ftData.fastTravelPrice > 0)
		{
			moneyRemovedSound?.Play2D();
		}
		if (SingletonBehaviour<Inventory>.Instance.RemoveMoney(ftData.fastTravelPrice))
		{
			SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(FastTravel(lastMarkerClicked, FastTravelWithoutLocomotive, ftData.isDestinationWithinSameTrainset, ftData.fastTravelDuration));
		}
	}

	private static bool IsFastTravelAllowed(FastTravelData ftData, bool withLoco)
	{
		if (!GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.FastTravel))
		{
			return false;
		}
		if (!withLoco)
		{
			return ftData.CanTravelWithoutLoco;
		}
		return ftData.CanTravelWithLoco;
	}

	public static FastTravelData ExtractFastTravelData(FastTravelDestination fastTravelMarker, TrainCar playerCar)
	{
		float num = GetDistanceTo(fastTravelMarker) * 0.001f;
		int num2 = Mathf.RoundToInt(num * 150f * Globals.G.GameParams.FastTravelPriceModifier);
		int num3 = num2 * 6;
		int num4 = num3;
		bool hasMoneyForFastTravel = SingletonBehaviour<Inventory>.Instance.PlayerMoney >= (double)num2;
		bool hasMoneyForFastTravelWithLoco = SingletonBehaviour<Inventory>.Instance.PlayerMoney >= (double)num3;
		bool isDestinationLoco = false;
		bool isDestinationWithinSameTrainset = false;
		bool hasLicenseForDestinationLoco = false;
		float dayLengthInMinutes = Globals.G.GameParams.DayLengthInMinutes;
		float num5 = ((dayLengthInMinutes > 0f) ? (1440f / dayLengthInMinutes) : 0f);
		int num6 = Mathf.RoundToInt(num * 91.3242f * num5);
		DateTime arrivalTime = (SingletonBehaviour<WeatherDriver>.Instance ? SingletonBehaviour<WeatherDriver>.Instance.manager.DateTime.AddSeconds(num6) : DateTime.Now);
		bool flag = playerCar != null;
		bool flag2 = flag && playerCar.IsLoco;
		bool isLocoFastTravelPrevented = playerCar != null && playerCar.preventFastTravelWithCar;
		if (fastTravelMarker.playerTeleportAnchor.TryGetComponent<TrainCar>(out var component))
		{
			if (flag && playerCar.trainset == component.trainset)
			{
				num2 = 0;
				hasMoneyForFastTravel = true;
				isDestinationWithinSameTrainset = true;
			}
			isDestinationLoco = component.IsLoco;
			hasLicenseForDestinationLoco = SingletonBehaviour<LicenseManager>.Instance.IsLicensedForCar(component.carLivery);
		}
		bool flag3 = false;
		bool flag4 = false;
		if (flag2)
		{
			if (playerCar.carType == TrainCarType.HandCar)
			{
				num3 = num2;
				hasMoneyForFastTravelWithLoco = SingletonBehaviour<Inventory>.Instance.PlayerMoney >= (double)num3;
			}
			flag3 = !playerCar.derailed;
			List<TrainCar> connectedLocoMultipleUnitCars = TrainCarTeleporter.GetConnectedLocoMultipleUnitCars(playerCar);
			if (connectedLocoMultipleUnitCars != null)
			{
				flag4 = true;
				foreach (TrainCar item in connectedLocoMultipleUnitCars)
				{
					if (flag3 && item.derailed)
					{
						flag3 = false;
					}
					if (item.preventFastTravelWithCar)
					{
						isLocoFastTravelPrevented = true;
					}
					if (flag4)
					{
						flag4 = SingletonBehaviour<LicenseManager>.Instance.IsLicensedForCar(item.carLivery);
					}
				}
				if (!CarTypes.IsMUSteamLocomotive(playerCar.carType))
				{
					num3 = Mathf.RoundToInt((float)num3 * (1f + 0.5f * (float)(connectedLocoMultipleUnitCars.Count - 1)));
					hasMoneyForFastTravelWithLoco = SingletonBehaviour<Inventory>.Instance.PlayerMoney >= (double)num3;
				}
			}
			else
			{
				flag4 = SingletonBehaviour<LicenseManager>.Instance.IsLicensedForCar(playerCar.carLivery);
			}
			if (GarageCarSpawner.Spawners.TryGetValue(playerCar.carLivery, out var value) && value.GetCar(playerCar.carLivery) == playerCar && connectedLocoMultipleUnitCars == null)
			{
				float b = (float)num2 + value.garageType.summonPrice;
				num3 = Mathf.RoundToInt(Mathf.Min(num3, b));
				hasMoneyForFastTravelWithLoco = SingletonBehaviour<Inventory>.Instance.PlayerMoney >= (double)num3;
			}
			else if (connectedLocoMultipleUnitCars != null && connectedLocoMultipleUnitCars.Any((TrainCar l) => GarageCarSpawner.Spawners.TryGetValue(l.carLivery, out var value3) && value3.GetCar(l.carLivery) == l))
			{
				float num7 = 0f;
				bool flag5 = false;
				foreach (TrainCar item2 in connectedLocoMultipleUnitCars)
				{
					if (GarageCarSpawner.Spawners.TryGetValue(item2.carLivery, out var value2) && value2.GetCar(item2.carLivery) == item2)
					{
						num7 += value2.garageType.summonPrice;
						continue;
					}
					num7 += ((!flag5) ? ((float)num4) : ((float)num4 * 0.5f));
					flag5 = true;
				}
				if (!flag5)
				{
					num7 += (float)num2;
				}
				num3 = Mathf.RoundToInt(Mathf.Min(num3, num7));
				hasMoneyForFastTravelWithLoco = SingletonBehaviour<Inventory>.Instance.PlayerMoney >= (double)num3;
			}
		}
		return new FastTravelData(fastTravelMarker.MarkerName, num2, num3, hasMoneyForFastTravel, hasMoneyForFastTravelWithLoco, isDestinationLoco, isDestinationWithinSameTrainset, hasLicenseForDestinationLoco, flag2, flag4, flag3, isLocoFastTravelPrevented, !GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.FastTravel), arrivalTime, num6);
	}

	private IEnumerator FastTravel(FastTravelDestination marker, Func<Transform, IEnumerator> method, bool skipLoading, int fastTravelDuration)
	{
		if (IsFastTravelling)
		{
			Debug.LogError("Cannot fast travel during fast travel");
			yield break;
		}
		IsFastTravelling = true;
		yield return WaitFor.SecondsRealtime(0.5f);
		bool vrShortLoadInsteadOfSkip = skipLoading && VRManager.IsVREnabled();
		if (!skipLoading || vrShortLoadInsteadOfSkip)
		{
			SingletonBehaviour<LoadingScreenManager>.Instance.StartLoading();
			MapMarkersController.RequestToggleMapMarkerInteraction(this, on: false);
		}
		yield return SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(method(marker.playerTeleportAnchor));
		if (vrShortLoadInsteadOfSkip)
		{
			yield return WaitFor.Seconds(1.25f);
		}
		else if (!skipLoading)
		{
			yield return SingletonBehaviour<FpsStabilityMeasurer>.Instance.WaitForStableFps();
		}
		if (!skipLoading || vrShortLoadInsteadOfSkip)
		{
			SingletonBehaviour<LoadingScreenManager>.Instance.FinishLoading();
			MapMarkersController.RemoveMapMarkerInteractionRequest(this);
		}
		TimeAdvance.AdvanceTime(fastTravelDuration);
		IsFastTravelling = false;
		if ((bool)SingletonBehaviour<StorageController>.Instance)
		{
			SingletonBehaviour<StorageController>.Instance.RequestLostAndFoundItemActivation();
		}
	}

	private IEnumerator FastTravelWithoutLocomotive(Transform anchor)
	{
		try
		{
			this.AboutToFastTravel?.Invoke();
		}
		catch (Exception ex)
		{
			Debug.LogError("Error invoking AboutToFastTravel event: " + ex.Message);
			Debug.LogException(ex);
		}
		TrainCar trainCar = TrainCar.Resolve(anchor.gameObject);
		bool isToCar = trainCar != null;
		if (isToCar)
		{
			if (!trainCar.IsLoco && !trainCar.IsCaboose)
			{
				Debug.LogWarning("Trying to fast-travel to invalid car '" + trainCar.name + "', this shouldn't be possible", trainCar);
				yield break;
			}
			PlayerManager.TeleportPlayerToCar(trainCar);
		}
		else
		{
			PlayerManager.TeleportPlayer(anchor.position, anchor.rotation, null, useRotation: true);
		}
		yield return null;
		if ((bool)SingletonBehaviour<UnusedTrainCarDeleter>.Instance)
		{
			SingletonBehaviour<UnusedTrainCarDeleter>.Instance.InstantConditionalDeleteOfUnusedCars();
		}
		if ((bool)SingletonBehaviour<TerrainGrid>.Instance)
		{
			while (!SingletonBehaviour<TerrainGrid>.Instance.IsInLoadedRegion(PlayerManager.PlayerTransform.position))
			{
				yield return null;
			}
		}
		if (!isToCar)
		{
			PlayerManager.TeleportPlayer(anchor.position, anchor.rotation, null, useRotation: true);
		}
	}

	private IEnumerator FastTravelWithLocomotive(Transform anchor)
	{
		TrainCar locoCar = PlayerManager.Car;
		if (!locoCar || !locoCar.IsLoco)
		{
			Debug.LogError("Unexpected error: loco is null");
			yield break;
		}
		try
		{
			this.AboutToFastTravel?.Invoke();
		}
		catch (Exception ex)
		{
			Debug.LogError("Error invoking AboutToFastTravel event: " + ex.Message);
			Debug.LogException(ex);
		}
		List<TrainCar> locoMultipleUnitCars = TrainCarTeleporter.GetConnectedLocoMultipleUnitCars(locoCar);
		PlayerManager.TeleportPlayer(anchor.position, anchor.rotation, null, useRotation: true);
		yield return null;
		List<TrainCar> ignoreDeleteCars = locoMultipleUnitCars ?? new List<TrainCar> { locoCar };
		if ((bool)SingletonBehaviour<UnusedTrainCarDeleter>.Instance)
		{
			SingletonBehaviour<UnusedTrainCarDeleter>.Instance.InstantConditionalDeleteOfUnusedCars(ignoreDeleteCars);
		}
		yield return null;
		Debug.Log("Teleporting locomotive '" + locoCar.name + "'", locoCar);
		BaseControlsOverrider baseControlsOverrider = locoCar.SimController?.controlsOverrider;
		baseControlsOverrider?.Brake?.Set(0f);
		if (locoCar.brakeSystem != null && locoCar.brakeSystem.MainResPressureNormalized > 0.7f)
		{
			baseControlsOverrider?.Handbrake?.Set(0f);
			baseControlsOverrider?.IndependentBrake?.Set(1f);
		}
		else
		{
			baseControlsOverrider?.IndependentBrake?.Set(0f);
			baseControlsOverrider?.Handbrake?.Set(1f);
		}
		baseControlsOverrider?.DynamicBrake?.Set(0f);
		baseControlsOverrider?.Throttle?.Set(0f);
		baseControlsOverrider?.Reverser?.Set(0.5f);
		if (locoMultipleUnitCars != null)
		{
			yield return TrainCarTeleporter.TeleportTrainset(locoMultipleUnitCars, anchor.position);
		}
		else
		{
			yield return TrainCarTeleporter.TeleportTrainNew(locoCar, anchor.position);
		}
		PlayerManager.TeleportPlayerToCar(locoCar);
		if ((bool)SingletonBehaviour<TerrainGrid>.Instance)
		{
			while (!SingletonBehaviour<TerrainGrid>.Instance.IsInLoadedRegion(PlayerManager.PlayerTransform.position))
			{
				yield return null;
			}
		}
	}

	private static float GetDistanceTo(FastTravelDestination marker)
	{
		return Vector3.Distance(PlayerManager.PlayerTransform.AbsolutePosition(), marker.playerTeleportAnchor.AbsolutePosition());
	}
}
