using System;
using System.Collections.Generic;
using ClockStone;
using UnityEngine;

public class LiquidPuddle : MonoBehaviour
{
	public GameObject liquidStatusPrefab;

	public Transform liquidStatusGUITransform;

	public GameObject puddleDestructionParticles;

	public List<GameObject> puddleVariations = new List<GameObject>();

	private LiquidStatusGUI createdLiquidStatus;

	private string cleanStart = "blowdry_start";

	private string cleanEnd = "blowdry_end";

	private AudioObject startSound;

	private float lifetime = 1f;

	private float maxLifetime = 1f;

	private bool cleanupThisFrame;

	private LiquidSpreader spreaderRef;

	private void Awake()
	{
		int num = UnityEngine.Random.Range(0, puddleVariations.Count);
		for (int i = 0; i < puddleVariations.Count; i++)
		{
			puddleVariations[i].SetActive(i == num);
		}
		spreaderRef = puddleVariations[num].GetComponentInChildren<LiquidSpreader>();
	}

	public void Save(SaveablePlacedObject saveableObject)
	{
		LiquidType liquidType = spreaderRef.liquidType;
		saveableObject.floatList.Add(lifetime);
		saveableObject.stringList.Add(liquidType.ToString());
	}

	public void Load(SaveablePlacedObject saveableObject)
	{
		LiquidController globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<LiquidController>(GlobalObject.LIQUID_CONTROLLER);
		if (saveableObject.floatList.Count > 0)
		{
			lifetime = saveableObject.floatList[0];
		}
		if (saveableObject.stringList.Count > 0)
		{
			if (!Enum.TryParse<LiquidType>(saveableObject.stringList[0], out var result))
			{
				Debug.LogError("Something went wrong loading liquid type: " + saveableObject.stringList[0]);
				result = LiquidType.SWEAT;
			}
			LiquidInfo liquidForType = globalComponent.GetLiquidForType(result);
			GetComponentInChildren<Renderer>().material = liquidForType.puddleMat;
			GetComponentInChildren<LiquidSpreader>().SetLiquidInfo(liquidForType);
		}
	}

	private void LateUpdate()
	{
		if (!cleanupThisFrame && createdLiquidStatus != null)
		{
			StopCleanLoop();
			createdLiquidStatus.HideTimer();
		}
		cleanupThisFrame = false;
	}

	private void Update()
	{
		if (GameSettings.IsPassiveModeEnabled() && GameSettings.PassiveModeAutoCleanPuddles())
		{
			UpdateLife();
		}
	}

	private void OnDestroy()
	{
		if (createdLiquidStatus != null)
		{
			StopCleanLoop();
			UnityEngine.Object.Destroy(createdLiquidStatus.gameObject);
			createdLiquidStatus = null;
		}
	}

	public float GetLifetime()
	{
		return lifetime;
	}

	private void StopCleanLoop()
	{
		if (startSound != null)
		{
			startSound.Stop(0.25f);
			startSound = null;
			lifetime = maxLifetime;
			AudioController.Play(cleanEnd, base.transform.position);
		}
	}

	public void OnCleanup()
	{
		if (startSound == null)
		{
			startSound = AudioController.Play(cleanStart, base.transform.position);
		}
		cleanupThisFrame = true;
		if (createdLiquidStatus == null)
		{
			CreateLiquidStatusGUI();
		}
		UpdateLife();
		UpdateLiquidStatusGUI();
	}

	private void CreateLiquidStatusGUI()
	{
		createdLiquidStatus = UnityEngine.Object.Instantiate(liquidStatusPrefab).GetComponent<LiquidStatusGUI>();
		createdLiquidStatus.SetFollowTransform(liquidStatusGUITransform);
		UpdateLiquidStatusGUI();
	}

	private void UpdateLiquidStatusGUI()
	{
		createdLiquidStatus.ShowTimer();
		createdLiquidStatus.UpdateTimer(lifetime / maxLifetime);
	}

	private void UpdateLife(float mult = 1f)
	{
		lifetime -= Time.deltaTime * mult;
		if (lifetime <= 0f)
		{
			RemovePuddle();
		}
	}

	public void RemovePuddle(bool fromMassClean = false)
	{
		BoundingBoxComponent component = GetComponent<BoundingBoxComponent>();
		ulong? roomUID = component.GetRoomUID();
		if (!roomUID.HasValue)
		{
			Debug.LogError("Something went wrong! This puddle somehow isn't inside of a room.");
			return;
		}
		RoomBase roomForUID = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME).GetRoomForUID(roomUID.Value);
		PlacedObjectID component2 = GetComponent<PlacedObjectID>();
		if (component2 == null)
		{
			Debug.LogError("Something went wrong! This puddle has no ID!");
			return;
		}
		if (!fromMassClean)
		{
			Vector3 vector = component.GetBoxCenter() + Vector3.up * 0.1f;
			Renderer component3 = UnityEngine.Object.Instantiate(puddleDestructionParticles, vector, Quaternion.identity).GetComponent<Renderer>();
			Material material = component3.material;
			material.color = spreaderRef.GetLiquidColor();
			component3.material = material;
			spreaderRef.RequestSplashSound(vector);
		}
		ObjectPlacementManager.RemovePuddleManually(roomForUID.GetPuddleInfoForUID(component2.GetUID()), roomForUID);
		GoalsController.ReportGoalEvent(GoalCondition.CLEAN_PUDDLE);
	}
}
