using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.Customization;
using DV.Customization.Paint;
using DV.JObjectExtstensions;
using DV.OriginShift;
using DV.Simulation.Cars;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

public static class CarsSaveManager
{
	public class CarDataToLoad
	{
		public TrainCarType carType;

		public string id;

		public string carGuid;

		public bool playerSpawnedCar;

		public bool uniqueCar;

		public Vector3 worldPos;

		public Vector3 worldRotEuler;

		public bool bogie1Derailed;

		public int bogie1TrackChildIndex;

		public double bogie1PositionAlongTrack;

		public bool bogie2Derailed;

		public int bogie2TrackChildIndex;

		public double bogie2PositionAlongTrack;

		public bool useExplodedModel;

		public CargoType loadedCargoType;

		public byte? loadedCargoModel;

		public string paintThemeExterior;

		public string paintThemeInterior;

		public JObject carState;

		public JObject simCarState;

		public JObject modCarState;

		public CarDataToLoad(TrainCarType carType, string id, string carGuid, bool playerSpawnedCar, bool uniqueCar, Vector3 worldPos, Vector3 worldRotEuler, bool bogie1Derailed, int bogie1TrackChildIndex, double bogie1PositionAlongTrack, bool bogie2Derailed, int bogie2TrackChildIndex, double bogie2PositionAlongTrack, bool useExplodedModel, CargoType loadedCargoType, byte? loadedCargoModel, string paintThemeExterior, string paintThemeInterior, JObject carState, JObject simCarState, JObject modCarState)
		{
			this.carType = carType;
			this.id = id;
			this.carGuid = carGuid;
			this.playerSpawnedCar = playerSpawnedCar;
			this.uniqueCar = uniqueCar;
			this.worldPos = worldPos;
			this.worldRotEuler = worldRotEuler;
			this.bogie1Derailed = bogie1Derailed;
			this.bogie1TrackChildIndex = bogie1TrackChildIndex;
			this.bogie1PositionAlongTrack = bogie1PositionAlongTrack;
			this.bogie2Derailed = bogie2Derailed;
			this.bogie2TrackChildIndex = bogie2TrackChildIndex;
			this.bogie2PositionAlongTrack = bogie2PositionAlongTrack;
			this.useExplodedModel = useExplodedModel;
			this.loadedCargoType = loadedCargoType;
			this.loadedCargoModel = loadedCargoModel;
			this.paintThemeExterior = paintThemeExterior;
			this.paintThemeInterior = paintThemeInterior;
			this.carState = carState;
			this.simCarState = simCarState;
			this.modCarState = modCarState;
		}
	}

	public class UniqueCarDataToLoad
	{
		public string id;

		public string carGuid;

		public bool isExploded;

		public CargoType loadedCargoType;

		public byte? loadedCargoModel;

		public string paintThemeExterior;

		public string paintThemeInterior;

		public float handbrakePosition;

		public float brakePipePressure;

		public float auxResPressure;

		public float mainResPressure;

		public float controlResPressure;

		public float brakeCylPressure;

		public float visitCheckerTimeLeftData;

		public JObject carState;

		public JObject simCarState;

		public JObject modCarState;

		public UniqueCarDataToLoad(JObject carData)
		{
			id = carData.GetString("id");
			carGuid = carData.GetString("carGuid");
			isExploded = carData.GetBool("exploded") ?? false;
			paintThemeExterior = carData.GetString("paintExterior");
			paintThemeInterior = carData.GetString("paintInterior");
			loadedCargoModel = (byte?)carData.GetInt("loadedCargoModel");
			int? num = carData.GetInt("loadedCargo");
			if (num.HasValue && Enum.IsDefined(typeof(CargoType), num))
			{
				loadedCargoType = (CargoType)num.Value;
			}
			handbrakePosition = carData.GetFloat("hb") ?? (-1f);
			brakePipePressure = carData.GetFloat("bp") ?? (-1f);
			auxResPressure = carData.GetFloat("aux") ?? (-1f);
			mainResPressure = carData.GetFloat("mr") ?? (-1f);
			controlResPressure = carData.GetFloat("cr") ?? (-1f);
			brakeCylPressure = carData.GetFloat("bc") ?? (-1f);
			visitCheckerTimeLeftData = carData.GetFloat("visit") ?? (-1f);
			carState = carData.GetJObject("carState");
			simCarState = carData.GetJObject("simCarState");
			modCarState = carData.GetJObject("modCarState");
		}

		public static string GetIdFromCarData(JObject carData)
		{
			return carData.GetString("id");
		}
	}

	private const string TRACK_HASH_SAVE_KEY = "trackHash";

	private const string CARS_DATA_SAVE_KEY = "carsData";

	private const string CAR_TYPE_SAVE_KEY = "type";

	private const string ID_SAVE_KEY = "id";

	private const string CAR_GUID_SAVE_KEY = "carGuid";

	private const string PLAYER_SPAWNED_CAR_KEY = "playerSpawn";

	private const string UNIQUE_CAR_KEY = "unique";

	private const string WORLD_POSITION_SAVE_KEY = "position";

	private const string WORLD_ROTATION_SAVE_KEY = "rotation";

	private const string BOGIE_1_TRACK_CHILD_INDEX_SAVE_KEY = "bog1TrackChildInd";

	private const string BOGIE_2_TRACK_CHILD_INDEX_SAVE_KEY = "bog2TrackChildInd";

	private const string BOGIE_1_POSITION_ALONG_TRACK_SAVE_KEY = "bog1PosOnTrack";

	private const string BOGIE_2_POSITION_ALONG_TRACK_SAVE_KEY = "bog2PosOnTrack";

	private const string BOGIE_1_DERAILED_SAVE_KEY = "bog1Derailed";

	private const string BOGIE_2_DERAILED_SAVE_KEY = "bog2Derailed";

	private const string COUPLER_STATE_F_SAVE_KEY = "couplerStateF";

	private const string COUPLER_STATE_R_SAVE_KEY = "couplerStateR";

	private const string AIR_HOSE_F_SAVE_KEY = "airHoseF";

	private const string AIR_HOSE_R_SAVE_KEY = "airHoseR";

	private const string AIR_COCK_F_SAVE_KEY = "airCockF";

	private const string AIR_COCK_R_SAVE_KEY = "airCockR";

	private const string LOADED_CARGO_MODEL_SAVE_KEY = "loadedCargoModel";

	private const string LOADED_CARGO_SAVE_KEY = "loadedCargo";

	private const string VISIT_CHECKER_KEY = "visit";

	private const string HANDBRAKE_POSITION_SAVE_KEY = "hb";

	private const string BRAKE_PIPE_PRESSURE_SAVE_KEY = "bp";

	private const string AUX_RES_PRESSURE_SAVE_KEY = "aux";

	private const string MAIN_RES_PRESSURE_SAVE_KEY = "mr";

	private const string CONTROL_RES_PRESSURE_SAVE_KEY = "cr";

	private const string BRAKE_CYLINDER_PRESSURE_SAVE_KEY = "bc";

	private const string SIM_CAR_STATE_SAVE_KEY = "simCarState";

	private const string MOD_CAR_STATE_SAVE_KEY = "modCarState";

	private const string CAR_STATE_SAVE_KEY = "carState";

	private const string CAR_EXPLODED_SAVE_KEY = "exploded";

	private const string CAR_PAINT_EXTERIOR_SAVE_KEY = "paintExterior";

	private const string CAR_PAINT_INTERIOR_SAVE_KEY = "paintInterior";

	public static bool Load(JObject savedData)
	{
		if (savedData == null)
		{
			Debug.LogError("Given save data is null, loading will not be performed");
			return false;
		}
		string text = savedData.GetString("trackHash");
		if (text == null)
		{
			Debug.LogError("loadedTracksHash is null, cars loading aborted");
			return false;
		}
		JObject[] jObjectArray = savedData.GetJObjectArray("carsData");
		if (jObjectArray == null)
		{
			Debug.LogError("carsData not found, cars loading aborted");
			return false;
		}
		if (text != SingletonBehaviour<RailTrackRegistryBase>.Instance.TracksHash)
		{
			Debug.LogWarning("Given save data was made in a different scene, loading will not be performed");
			Debug.Log("DEBUG: Current rail track hash '" + SingletonBehaviour<RailTrackRegistryBase>.Instance.TracksHash + "' doesn't match save data hash '" + text + "', will not load");
			return false;
		}
		Debug.Log("Rail track hashes match '" + SingletonBehaviour<RailTrackRegistryBase>.Instance.TracksHash + "'");
		DeleteAllExistingCars();
		RailTrack[] orderedRailtracks = SingletonBehaviour<RailTrackRegistryBase>.Instance.OrderedRailtracks;
		List<TrainCar> list = new List<TrainCar>();
		JObject[] array = jObjectArray;
		for (int i = 0; i < array.Length; i++)
		{
			TrainCar trainCar = InstantiateCarFromSavegame(array[i], orderedRailtracks);
			if (trainCar != null)
			{
				list.Add(trainCar);
			}
		}
		array = jObjectArray;
		for (int i = 0; i < array.Length; i++)
		{
			RestoreCarConnections(array[i]);
		}
		foreach (TrainCar item in list)
		{
			SetBrakesOnSpawn(item);
		}
		SingletonBehaviour<CoroutineManager>.Instance.Run(IgnoreTrainStressForLoadedCarsUntilCouplingIsSettled());
		Debug.Log("Cars loaded");
		return true;
	}

	public static CarDataToLoad GetFirstCarDataForCarTypeFromSavegame(JObject savedData, TrainCarType carTypeToLoad)
	{
		if (savedData.GetString("trackHash") == null)
		{
			Debug.LogError("Unexpected state: loadedTracksHash is null, can't extract car data!");
			return null;
		}
		JObject[] jObjectArray = savedData.GetJObjectArray("carsData");
		if (jObjectArray == null)
		{
			Debug.LogError("Unexpected state: carsData not found, can't extract car data!");
			return null;
		}
		JObject[] array = jObjectArray;
		foreach (JObject dataObject in array)
		{
			int? num = dataObject.GetInt("type");
			if (!num.HasValue || !Enum.IsDefined(typeof(TrainCarType), num))
			{
				continue;
			}
			TrainCarType value = (TrainCarType)num.Value;
			if (carTypeToLoad == value)
			{
				string text = dataObject.GetString("id");
				string text2 = dataObject.GetString("carGuid");
				bool playerSpawnedCar = dataObject.GetBool("playerSpawn") ?? false;
				bool uniqueCar = dataObject.GetBool("unique") ?? false;
				Vector3? vector = dataObject.GetVector3("position");
				Vector3? vector2 = dataObject.GetVector3("rotation");
				bool flag = dataObject.GetBool("bog1Derailed") ?? false;
				int? num2 = dataObject.GetInt("bog1TrackChildInd");
				double? num3 = dataObject.GetDouble("bog1PosOnTrack");
				bool flag2 = dataObject.GetBool("bog2Derailed") ?? false;
				int? num4 = dataObject.GetInt("bog2TrackChildInd");
				double? num5 = dataObject.GetDouble("bog2PosOnTrack");
				bool useExplodedModel = dataObject.GetBool("exploded") ?? false;
				byte? loadedCargoModel = (byte?)dataObject.GetInt("loadedCargoModel");
				int? num6 = dataObject.GetInt("loadedCargo");
				JObject jObject = dataObject.GetJObject("carState");
				JObject jObject2 = dataObject.GetJObject("simCarState");
				JObject jObject3 = dataObject.GetJObject("modCarState");
				string paintThemeExterior = dataObject.GetString("paintExterior");
				string paintThemeInterior = dataObject.GetString("paintInterior");
				if (text != null && text2 != null && vector.HasValue && vector2.HasValue && (flag || (num2.HasValue && num3.HasValue)) && (flag2 || (num4.HasValue && num5.HasValue)) && num6.HasValue && Enum.IsDefined(typeof(CargoType), num6) && num.HasValue && Enum.IsDefined(typeof(TrainCarType), num))
				{
					return new CarDataToLoad(value, text, text2, playerSpawnedCar, uniqueCar, vector.Value, vector2.Value, flag, num2 ?? 0, num3 ?? 0.0, flag2, num4 ?? 0, num5 ?? 0.0, useExplodedModel, (CargoType)num6.Value, loadedCargoModel, paintThemeExterior, paintThemeInterior, jObject, jObject2, jObject3);
				}
				Debug.LogError("Error while loading car data (not all data was present), skipping this entry!");
			}
		}
		return null;
	}

	private static IEnumerator IgnoreTrainStressForLoadedCarsUntilCouplingIsSettled()
	{
		TrainStress.globalIgnoreStressCalculation = true;
		float seconds = 10.5f;
		yield return WaitFor.Seconds(seconds);
		TrainStress.globalIgnoreStressCalculation = false;
	}

	public static JObject GetCarsSaveData()
	{
		RailTrack[] tracks = SingletonBehaviour<RailTrackRegistryBase>.Instance.OrderedRailtracks;
		List<TrainCar> allCars = SingletonBehaviour<CarSpawner>.Instance.AllCars;
		JObject[] array = (from car in allCars
			where car.logicCar != null
			select GetCarSaveData(car, tracks)).ToArray();
		if (array.Length != allCars.Count)
		{
			int num = allCars.Count - array.Length;
			Debug.LogWarning($"Found {num} uninitialized cars, those will be excluded from save data");
		}
		JObject jObject = new JObject();
		jObject.SetString("trackHash", SingletonBehaviour<RailTrackRegistryBase>.Instance.TracksHash);
		jObject.SetJObjectArray("carsData", array);
		return jObject;
	}

	private static TrainCar InstantiateCarFromSavegame(JObject carData, RailTrack[] tracks)
	{
		string text = carData.GetString("id");
		string text2 = carData.GetString("carGuid");
		int? num = carData.GetInt("type");
		bool playerSpawnedCar = carData.GetBool("playerSpawn") ?? false;
		bool uniqueCar = carData.GetBool("unique") ?? false;
		Vector3? vector = carData.GetVector3("position");
		Vector3? vector2 = carData.GetVector3("rotation");
		bool flag = carData.GetBool("bog1Derailed") ?? false;
		int? num2 = carData.GetInt("bog1TrackChildInd");
		double? num3 = carData.GetDouble("bog1PosOnTrack");
		bool flag2 = carData.GetBool("bog2Derailed") ?? false;
		int? num4 = carData.GetInt("bog2TrackChildInd");
		double? num5 = carData.GetDouble("bog2PosOnTrack");
		bool isExploded = carData.GetBool("exploded") ?? false;
		string carPaintExterior = carData.GetString("paintExterior");
		string carPaintInterior = carData.GetString("paintInterior");
		byte? loadedCargoModel = (byte?)carData.GetInt("loadedCargoModel");
		int? num6 = carData.GetInt("loadedCargo");
		float handbrakePosition = carData.GetFloat("hb") ?? (-1f);
		float brakePipePressure = carData.GetFloat("bp") ?? (-1f);
		float auxResPressure = carData.GetFloat("aux") ?? (-1f);
		float mainResPressure = carData.GetFloat("mr") ?? (-1f);
		float controlResPressure = carData.GetFloat("cr") ?? (-1f);
		float brakeCylPressure = carData.GetFloat("bc") ?? (-1f);
		JObject jObject = carData.GetJObject("carState");
		JObject jObject2 = carData.GetJObject("simCarState");
		JObject jObject3 = carData.GetJObject("modCarState");
		if (text == null || text2 == null || !IsVectorValid(vector) || !IsVectorValid(vector2) || (!flag && (!num2.HasValue || !num3.HasValue)) || (!flag2 && (!num4.HasValue || !num5.HasValue)) || !num6.HasValue || !Enum.IsDefined(typeof(CargoType), num6) || !num.HasValue || !Enum.IsDefined(typeof(TrainCarType), num))
		{
			Debug.LogError("Error while loading car data (not all data was present), skipping this entry!");
			return null;
		}
		int value = num.Value;
		CargoType value2 = (CargoType)num6.Value;
		GameObject carPrefab = TrainCar.GetCarPrefab((TrainCarType)value);
		RailTrack bogie1Track = ((!flag) ? tracks[num2.Value] : null);
		double bogie1PositionAlongTrack = ((!flag) ? num3.Value : 0.0);
		RailTrack bogie2Track = ((!flag2) ? tracks[num4.Value] : null);
		double bogie2PositionAlongTrack = ((!flag2) ? num5.Value : 0.0);
		TrainCar trainCar = SingletonBehaviour<CarSpawner>.Instance.SpawnLoadedCar(carPrefab, text, text2, playerSpawnedCar, uniqueCar, vector.Value + WorldMover.currentMove, Quaternion.Euler(vector2.Value), flag, bogie1Track, bogie1PositionAlongTrack, flag2, bogie2Track, bogie2PositionAlongTrack);
		float visitCheckerTimeLeftData = ((trainCar.visitChecker == null) ? (-1f) : (carData.GetFloat("visit") ?? (-1f)));
		RestoreCarState(trainCar, value2, loadedCargoModel, isExploded, carPaintExterior, carPaintInterior, handbrakePosition, brakePipePressure, auxResPressure, mainResPressure, controlResPressure, brakeCylPressure, visitCheckerTimeLeftData, jObject, jObject2, jObject3);
		return trainCar;
	}

	public static void RestoreCarState(TrainCar spawnedCar, CargoType loadedCargoType, byte? loadedCargoModel, bool isExploded, string carPaintExterior, string carPaintInterior, float handbrakePosition, float brakePipePressure, float auxResPressure, float mainResPressure, float controlResPressure, float brakeCylPressure, float visitCheckerTimeLeftData, JObject carState, JObject simCarState, JObject modCarState)
	{
		if (loadedCargoType != CargoType.None)
		{
			spawnedCar.CargoModelController.currentCargoModelIndex = loadedCargoModel;
			spawnedCar.logicCar.LoadCargo(spawnedCar.cargoCapacity, loadedCargoType);
		}
		if (isExploded)
		{
			UpdateToExplodedModel(spawnedCar);
		}
		if (!string.IsNullOrEmpty(carPaintExterior) && spawnedCar.PaintExterior != null && PaintTheme.TryLoad(carPaintExterior, out var theme))
		{
			spawnedCar.PaintExterior.CurrentTheme = theme;
		}
		if (!string.IsNullOrEmpty(carPaintInterior) && spawnedCar.PaintInterior != null && PaintTheme.TryLoad(carPaintInterior, out var theme2))
		{
			spawnedCar.PaintInterior.CurrentTheme = theme2;
		}
		if (handbrakePosition > 0f)
		{
			spawnedCar.brakeSystem.SetHandbrakePosition(handbrakePosition);
		}
		if (brakePipePressure > 0f)
		{
			spawnedCar.brakeSystem.SetBrakePipePressure(brakePipePressure);
		}
		if (auxResPressure > 0f)
		{
			spawnedCar.brakeSystem.SetAuxReservoirPressure(auxResPressure);
		}
		if (mainResPressure > 0f)
		{
			spawnedCar.brakeSystem.SetMainReservoirPressure(mainResPressure);
		}
		if (controlResPressure > 0f)
		{
			spawnedCar.brakeSystem.SetControlReservoirPressure(controlResPressure);
		}
		if (brakeCylPressure > 0f)
		{
			spawnedCar.brakeSystem.ForceCylinderPressure(brakeCylPressure);
		}
		if (spawnedCar.visitChecker != null && visitCheckerTimeLeftData > 0f)
		{
			spawnedCar.visitChecker.LoadData(visitCheckerTimeLeftData);
		}
		if (carState != null)
		{
			spawnedCar.GetComponent<CarStateSave>()?.SetCarStateSaveData(carState);
		}
		if (simCarState != null)
		{
			spawnedCar.GetComponent<SimCarStateSave>()?.SetStateSaveData(simCarState);
		}
		if (modCarState != null)
		{
			spawnedCar.GetComponent<TrainCarCustomization>()?.Deserialize(modCarState);
		}
	}

	private static void RestoreHoseAndCock(Coupler coupler, bool? connect, bool? open)
	{
		if (connect.HasValue)
		{
			if (connect.Value)
			{
				coupler.ConnectAirHose(coupler.CoupledToOrWithinBreakDistance, playAudio: false);
			}
			else
			{
				coupler.DisconnectAirHose(playAudio: false);
			}
		}
		if (open.HasValue)
		{
			coupler.IsCockOpen = open.Value;
		}
	}

	private static void RestoreCarConnections(JObject carData)
	{
		TrainCar trainCarByCarGuid = SingletonBehaviour<TrainCarRegistry>.Instance.GetTrainCarByCarGuid(carData.GetString("carGuid"));
		if (!(trainCarByCarGuid == null))
		{
			trainCarByCarGuid.frontCoupler.InitFromSave((ChainCouplerInteraction.State)carData.GetInt("couplerStateF").GetValueOrDefault());
			trainCarByCarGuid.rearCoupler.InitFromSave((ChainCouplerInteraction.State)carData.GetInt("couplerStateR").GetValueOrDefault());
			RestoreHoseAndCock(trainCarByCarGuid.frontCoupler, carData.GetBool("airHoseF"), carData.GetBool("airCockF"));
			RestoreHoseAndCock(trainCarByCarGuid.rearCoupler, carData.GetBool("airHoseR"), carData.GetBool("airCockR"));
		}
	}

	private static void SetBrakesOnSpawn(TrainCar spawnedCar)
	{
		BaseControlsOverrider baseControlsOverrider = spawnedCar.SimController?.controlsOverrider;
		if (baseControlsOverrider != null)
		{
			baseControlsOverrider.SetBrakesOnSpawn();
		}
	}

	public static void UpdateToExplodedModel(TrainCar trainCar)
	{
		if (trainCar.TryGetComponent<ResourceExplosionBase>(out var component))
		{
			component.UpdateToExplodedStateExternal();
		}
		else
		{
			TrainCarExplosion.UpdateModelToExploded(trainCar);
		}
	}

	public static JObject GetCarSaveData(TrainCar car, RailTrack[] tracks, bool includeWorldBogieCouplerData = true)
	{
		JObject jObject = new JObject();
		jObject.SetString("id", car.logicCar.ID);
		jObject.SetString("carGuid", car.logicCar.carGuid);
		jObject.SetInt("type", (int)car.carType);
		if (car.playerSpawnedCar)
		{
			jObject.SetBool("playerSpawn", value: true);
		}
		if (car.uniqueCar)
		{
			jObject.SetBool("unique", value: true);
		}
		if (includeWorldBogieCouplerData)
		{
			jObject.SetVector3("position", car.transform.AbsolutePosition());
			jObject.SetVector3("rotation", car.transform.rotation.eulerAngles);
			Bogie rearBogie = car.RearBogie;
			Bogie frontBogie = car.FrontBogie;
			if (!rearBogie.HasDerailed)
			{
				int value = Array.IndexOf(tracks, rearBogie.track);
				jObject.SetInt("bog1TrackChildInd", value);
				jObject.SetDouble("bog1PosOnTrack", rearBogie.traveller.Span);
			}
			else
			{
				jObject.SetBool("bog1Derailed", rearBogie.HasDerailed);
			}
			if (!frontBogie.HasDerailed)
			{
				int value2 = Array.IndexOf(tracks, frontBogie.track);
				jObject.SetInt("bog2TrackChildInd", value2);
				jObject.SetDouble("bog2PosOnTrack", frontBogie.traveller.Span);
			}
			else
			{
				jObject.SetBool("bog2Derailed", frontBogie.HasDerailed);
			}
			jObject.SetInt("couplerStateF", (int)car.frontCoupler.state);
			jObject.SetInt("couplerStateR", (int)car.rearCoupler.state);
			jObject.SetBool("airHoseF", car.frontCoupler.hoseAndCock.IsHoseConnected);
			jObject.SetBool("airHoseR", car.rearCoupler.hoseAndCock.IsHoseConnected);
			jObject.SetBool("airCockF", car.frontCoupler.hoseAndCock.cockOpen);
			jObject.SetBool("airCockR", car.rearCoupler.hoseAndCock.cockOpen);
		}
		if (car.isExploded)
		{
			jObject.SetBool("exploded", value: true);
		}
		if (car.PaintExterior != null)
		{
			jObject.SetString("paintExterior", car.PaintExterior.CurrentTheme.AssetName);
		}
		if (car.PaintInterior != null)
		{
			jObject.SetString("paintInterior", car.PaintInterior.CurrentTheme.AssetName);
		}
		jObject.SetInt("loadedCargo", (int)car.LoadedCargo);
		if (car.LoadedCargo != CargoType.None && car.CargoModelController.currentCargoModelIndex.HasValue)
		{
			GameObject[] cargoPrefabsForCarType = car.LoadedCargo.ToV2().GetCargoPrefabsForCarType(car.carLivery.parentType);
			if (cargoPrefabsForCarType != null && cargoPrefabsForCarType.Length > 1)
			{
				jObject.SetInt("loadedCargoModel", car.CargoModelController.currentCargoModelIndex.Value);
			}
		}
		if (car.brakeSystem.handbrakePosition > 0f)
		{
			jObject.SetFloat("hb", car.brakeSystem.handbrakePosition);
		}
		if (car.brakeSystem.brakePipePressure > 1.1f)
		{
			jObject.SetFloat("bp", car.brakeSystem.brakePipePressure);
		}
		if (car.brakeSystem.auxReservoirPressure > 1.1f)
		{
			jObject.SetFloat("aux", car.brakeSystem.auxReservoirPressure);
		}
		if (car.brakeSystem.mainReservoirPressure > 1.1f)
		{
			jObject.SetFloat("mr", car.brakeSystem.mainReservoirPressure);
		}
		if (car.brakeSystem.controlReservoirPressure > 1.1f)
		{
			jObject.SetFloat("cr", car.brakeSystem.controlReservoirPressure);
		}
		if (car.brakeSystem.brakeCylinderPressure > 1.1f)
		{
			jObject.SetFloat("bc", car.brakeSystem.brakeCylinderPressure);
		}
		if (car.visitChecker != null && car.visitChecker.RecentlyVisitedRemainingTime > 0f)
		{
			jObject.SetFloat("visit", car.visitChecker.RecentlyVisitedRemainingTime);
		}
		JObject jObject2 = car.GetComponent<CarStateSave>()?.GetCarStateSaveData();
		if (jObject2 != null)
		{
			jObject.SetJObject("carState", jObject2);
		}
		JObject jObject3 = car.GetComponent<SimCarStateSave>()?.GetStateSaveData();
		if (jObject3 != null)
		{
			jObject.SetJObject("simCarState", jObject3);
		}
		JObject jObject4 = car.GetComponent<TrainCarCustomization>()?.Serialize();
		if (jObject4 != null)
		{
			jObject.SetJObject("modCarState", jObject4);
		}
		return jObject;
	}

	public static void DeleteAllExistingCars()
	{
		CarSpawner instance = SingletonBehaviour<CarSpawner>.Instance;
		List<TrainCar> trainCarsToDelete = new List<TrainCar>(instance.AllCars);
		instance.DeleteTrainCars(trainCarsToDelete, forceInstantDestroy: true);
		SingletonBehaviour<UnusedTrainCarDeleter>.Instance.ClearInvalidCarReferencesAfterManualDelete();
	}

	private static bool IsVectorValid(Vector3? vec)
	{
		if (vec.HasValue)
		{
			return !NumberUtil.AnyInfinityMinMaxNaN(vec.Value);
		}
		return false;
	}
}
