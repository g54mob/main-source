using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
	public GameObject ghostSpawnParticles;

	public GameObject ghostDespawnParticles;

	public GameObject levitationLinePrefab;

	[HideInInspector]
	public static string ghostGoalID = "Scary!";

	private List<ulong> activeMemorialIDs = new List<ulong>();

	private List<float> activeGhostTimers = new List<float>();

	private List<ulong> memorialIDsWithActiveGhosts = new List<ulong>();

	private Dictionary<ulong, GameObject> activeGhosts = new Dictionary<ulong, GameObject>();

	private List<ulong> currentlySpawningMemorialIDs = new List<ulong>();

	private float ghostCheckTime = 30f;

	private float currentGhostCheckTimer = 30f;

	private int maxGravesToCheckPerCycle = 15;

	private float defaultMemorialGhostChance = 0.005f;

	private float maximumMemorialGhostChance = 0.02f;

	private float ghostLifeLow = 200f;

	private float ghostLifeHigh = 500f;

	private float ghostAlmostGoneTime = 90f;

	private string ghostSpawnSound = "dog_ghost_spawn";

	private string ghostDespawnSound = "dog_ghost_despawn";

	private bool initialized;

	private bool isShuttingDown;

	private GUIManagerPens guiRef;

	private ObjectRegistration regRef;

	private DogRegistration dogRegRef;

	private ConstructionManager constructionRef;

	private void Start()
	{
		Initialize();
	}

	private void OnApplicationQuit()
	{
		isShuttingDown = true;
	}

	public void LoadSavedGhostManager()
	{
		Initialize(force: true);
	}

	private void Initialize(bool force = false)
	{
		if (!initialized || force)
		{
			initialized = true;
			regRef = ObjectRegistration.GetRegistrationScript();
			guiRef = regRef.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
			dogRegRef = regRef.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
			if (activeGhostTimers.Count > 0 || activeGhosts.Count > 0 || activeMemorialIDs.Count > 0 || memorialIDsWithActiveGhosts.Count > 0)
			{
				Debug.LogError("Something went wrong. Ghost Manager is being initialized with pre-existing ghost data.");
			}
		}
	}

	private void Update()
	{
		if (PauseController.IsPaused())
		{
			return;
		}
		currentGhostCheckTimer -= Time.deltaTime;
		if (currentGhostCheckTimer <= 0f)
		{
			CheckForGhosts();
			currentGhostCheckTimer = ghostCheckTime;
		}
		for (int num = activeGhostTimers.Count - 1; num >= 0; num--)
		{
			activeGhostTimers[num] -= Time.deltaTime;
			if (activeGhostTimers[num] <= 0f)
			{
				DespawnGhost(memorialIDsWithActiveGhosts[num]);
			}
		}
	}

	public int GetGhostCount()
	{
		return memorialIDsWithActiveGhosts.Count;
	}

	public bool IsGhostNearRemovalTime(GameObject ghost)
	{
		for (int i = 0; i < memorialIDsWithActiveGhosts.Count; i++)
		{
			if (ghost == activeGhosts[memorialIDsWithActiveGhosts[i]])
			{
				return activeGhostTimers[i] <= ghostAlmostGoneTime;
			}
		}
		return false;
	}

	public void RegisterNewMemorial(ulong newMemorialID)
	{
		if (activeMemorialIDs.Contains(newMemorialID))
		{
			Debug.LogError("Trying to double-register memorial: " + newMemorialID);
		}
		else
		{
			activeMemorialIDs.Add(newMemorialID);
		}
	}

	public void UnregisterMemorial(ulong memorialID)
	{
		if (activeMemorialIDs.Contains(memorialID))
		{
			activeMemorialIDs.Remove(memorialID);
			if (activeGhosts.ContainsKey(memorialID))
			{
				DespawnGhost(memorialID);
			}
		}
	}

	public List<ulong> GetAllMemorialIDs()
	{
		return activeMemorialIDs;
	}

	public bool IsGhostSpawnedForMemorial(ulong memorialID)
	{
		return activeGhosts.ContainsKey(memorialID);
	}

	public bool IsGhostSpawningForMemorial(ulong memorialID)
	{
		return currentlySpawningMemorialIDs.Contains(memorialID);
	}

	public void BanishGhost(GameObject ghost)
	{
		for (int i = 0; i < memorialIDsWithActiveGhosts.Count; i++)
		{
			if (ghost == activeGhosts[memorialIDsWithActiveGhosts[i]])
			{
				DespawnGhost(memorialIDsWithActiveGhosts[i]);
				return;
			}
		}
		Debug.LogError("Failed to find valid ghost entry for ghost: " + ghost);
		Object.Destroy(ghost);
	}

	private void CheckForGhosts()
	{
		if (!GameSettings.IsGhostAutoSpawnEnabled() || activeMemorialIDs.Count == 0 || currentlySpawningMemorialIDs.Count > 0 || dogRegRef.IsCurrentlySpawningDogs() || dogRegRef.GetDogCount() >= dogRegRef.GetMaxDogs())
		{
			return;
		}
		if (constructionRef == null)
		{
			constructionRef = regRef.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
		}
		List<ulong> objects = new List<ulong>();
		objects.AddRange(activeMemorialIDs);
		ListUtil.ShuffleList(ref objects);
		int num = 0;
		for (int i = 0; i < objects.Count; i++)
		{
			if (activeGhosts.ContainsKey(objects[i]))
			{
				continue;
			}
			float value = Random.value;
			if (value <= maximumMemorialGhostChance)
			{
				ulong? roomUID = regRef.GetPlaceableObjectForUID(objects[i]).GetComponent<BoundingBoxComponent>().GetRoomUID();
				if (!roomUID.HasValue)
				{
					continue;
				}
				float valueOfRangePercentage = MathUtil.GetValueOfRangePercentage(constructionRef.GetObjectForUID(roomUID.Value).GetComponent<RoomBase>().GetSpookiness(), defaultMemorialGhostChance, maximumMemorialGhostChance);
				if (value <= valueOfRangePercentage)
				{
					SpawnGhost(objects[i]);
					break;
				}
			}
			num++;
			if (num >= maxGravesToCheckPerCycle)
			{
				break;
			}
		}
	}

	public void SpawnGhost(ulong memorialID)
	{
		if (guiRef.IsAnyDogHatching())
		{
			return;
		}
		if (activeGhosts.ContainsKey(memorialID))
		{
			Debug.LogError("Attempting to double-spawn ghost for memorial: " + memorialID);
			return;
		}
		currentlySpawningMemorialIDs.Add(memorialID);
		DogMemorial component = regRef.GetPlaceableObjectForUID(memorialID).GetComponent<DogMemorial>();
		Vector3 vector = component.transform.forward * -2f;
		if (component.transform.localScale.x < 1f)
		{
			vector *= component.transform.localScale.x;
		}
		Vector3 vector2 = component.transform.position + vector;
		ObjectSpawnParticles component2 = Object.Instantiate(ghostSpawnParticles, vector2, Quaternion.identity).GetComponent<ObjectSpawnParticles>();
		AudioController.Play(ghostSpawnSound, vector2);
		component2.SetIsGhost(val: true);
		component2.SetSpawnNewDog();
		component2.SetAttachToSpawnedDog();
		component2.SetSpawnSoundOverride("");
		component2.RegisterRequestIntention();
		component2.SetDogAge(component.dogAge);
		component2.SetDogGene(component.dogGene);
		component2.SetDogProfile(component.dogProfile);
		component2.SetDogPersonality(component.dogPersonality);
		component2.dogRegRef = dogRegRef;
		component2.SetSpawnCallback(OnGhostSpawned, memorialID);
		component2.SetExpectedRoom(component.GetComponent<BoundingBoxComponent>().GetRoomUID());
	}

	public void DespawnOldestGhost()
	{
		if (memorialIDsWithActiveGhosts.Count != 0)
		{
			DespawnGhost(memorialIDsWithActiveGhosts[0]);
		}
	}

	public void DeIndexGhostIfFound(GameObject dog)
	{
		for (int i = 0; i < memorialIDsWithActiveGhosts.Count; i++)
		{
			if (dog == activeGhosts[memorialIDsWithActiveGhosts[i]])
			{
				DeIndexGhost(memorialIDsWithActiveGhosts[i]);
				break;
			}
		}
	}

	public void DespawnGhost(ulong memorialID)
	{
		if (activeGhosts.ContainsKey(memorialID))
		{
			GameObject gameObject = activeGhosts[memorialID];
			DeIndexGhost(memorialID);
			if (gameObject != null && !isShuttingDown)
			{
				Vector3 boxCenter = gameObject.GetComponent<BoundingBoxComponent>().GetBoxCenter();
				Object.Instantiate(ghostDespawnParticles, boxCenter, Quaternion.identity);
				AudioController.Play(ghostDespawnSound, boxCenter);
				gameObject.GetComponent<RegisterTaggedObject>().ManualUnregister();
				Object.Destroy(gameObject);
			}
		}
	}

	private void DeIndexGhost(ulong memorialID)
	{
		activeGhosts.Remove(memorialID);
		int index = memorialIDsWithActiveGhosts.IndexOf(memorialID);
		activeGhostTimers.RemoveAt(index);
		memorialIDsWithActiveGhosts.RemoveAt(index);
	}

	private void OnGhostSpawned(GameObject newGhost, ulong memorialID)
	{
		if (currentlySpawningMemorialIDs.Contains(memorialID))
		{
			currentlySpawningMemorialIDs.Remove(memorialID);
		}
		if (newGhost == null)
		{
			return;
		}
		if (!activeMemorialIDs.Contains(memorialID))
		{
			newGhost.GetComponent<RegisterTaggedObject>().ManualUnregister();
			Object.Destroy(newGhost);
			return;
		}
		DogMemorial component = regRef.GetPlaceableObjectForUID(memorialID).GetComponent<DogMemorial>();
		ulong iDFromDog = dogRegRef.GetIDFromDog(newGhost);
		SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID(iDFromDog);
		saveableDogFromID.dogName = component.dogName;
		dogRegRef.UpdateSaveableDog(saveableDogFromID);
		dogRegRef.RefreshNameForDogID(iDFromDog);
		dogRegRef.RefreshThumbnailForDogID(iDFromDog);
		activeGhosts[memorialID] = newGhost;
		activeGhostTimers.Add(Random.Range(ghostLifeLow, ghostLifeHigh));
		memorialIDsWithActiveGhosts.Add(memorialID);
		UpdateDogCollisionsForNewGhost(newGhost);
		GoalsController.ReportGoalEvent(GoalCondition.GHOST_SPAWN);
		if (dogRegRef.GetNumberOfOwnedAndLoadingDogsIncludingGhosts() > dogRegRef.GetMaxDogs() + 1)
		{
			Object.Destroy(newGhost);
			Debug.LogError("Ghost was spawned in a situation that caused the max dogs to rise above the allowed value. Despawning.");
		}
	}

	private void UpdateDogCollisionsForNewGhost(GameObject newGhost)
	{
		Collider[] componentsInChildren = newGhost.GetComponentsInChildren<Collider>();
		List<GameObject> allInWorldOwnedDogs = dogRegRef.GetAllInWorldOwnedDogs();
		for (int i = 0; i < allInWorldOwnedDogs.Count; i++)
		{
			if (allInWorldOwnedDogs[i] == newGhost)
			{
				continue;
			}
			Collider[] componentsInChildren2 = allInWorldOwnedDogs[i].GetComponentsInChildren<Collider>();
			foreach (Collider collider in componentsInChildren2)
			{
				for (int k = 0; k < componentsInChildren.Length; k++)
				{
					Physics.IgnoreCollision(collider, componentsInChildren[k]);
				}
			}
		}
	}

	public void UpdateGhostCollisionsForNewDog(GameObject newDog)
	{
		if (memorialIDsWithActiveGhosts.Count == 0)
		{
			return;
		}
		Collider[] componentsInChildren = newDog.GetComponentsInChildren<Collider>();
		for (int i = 0; i < memorialIDsWithActiveGhosts.Count; i++)
		{
			Collider[] componentsInChildren2 = activeGhosts[memorialIDsWithActiveGhosts[i]].GetComponentsInChildren<Collider>();
			foreach (Collider collider in componentsInChildren2)
			{
				for (int k = 0; k < componentsInChildren.Length; k++)
				{
					Physics.IgnoreCollision(collider, componentsInChildren[k]);
				}
			}
		}
	}
}
