using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
	public delegate void OnCapsuleOpenedCallback();

	public MeshRenderer top;

	public MeshRenderer bot;

	public List<Material> materialListTop = new List<Material>();

	public List<Material> materialListBot = new List<Material>();

	public GameObject smoke;

	public GameObject confetti;

	public GameObject newItemPrefab;

	public GameObject existingItemPrefab;

	public GameObject existingDogToSpawn;

	public List<InventoryItem> itemsToSpawnAfterUpgrades;

	private bool canOpen = true;

	private OnCapsuleOpenedCallback openCallback;

	private SaveableDog containedDog;

	private bool spawnNewDog;

	private bool spawnCustomizationObject = true;

	private string capsuleOpenSound = "capsule_open";

	private float currentTimer;

	private float autoCollectTimer = 10f;

	private float autoCollectionJiggle = 5f;

	private DogRegistration dogRegRef;

	private void Awake()
	{
		RandomizeColors();
		currentTimer = Random.Range(0f - autoCollectionJiggle, 0f);
	}

	public void Update()
	{
		if (GameSettings.IsPassiveModeEnabled() && GameSettings.PassiveModeAutoCapsuleOpen())
		{
			currentTimer += Time.deltaTime;
			if (currentTimer >= autoCollectTimer)
			{
				Open(autoOpen: true);
			}
		}
	}

	public void RandomizeColors()
	{
		top.material = ListUtil.GetRandomElement(materialListTop);
		bot.material = ListUtil.GetRandomElement(materialListBot);
	}

	public void SetContainedDog(SaveableDog dog)
	{
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		dogRegRef.ReserveDogs(1);
		containedDog = dog;
	}

	public void SetSpawnNewDog()
	{
		spawnNewDog = true;
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
	}

	public void SetSpawnExistingDog(GameObject dog)
	{
		dog.SetActive(value: false);
		existingDogToSpawn = dog;
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
	}

	public void SetOnOpenCallback(OnCapsuleOpenedCallback newCallback)
	{
		openCallback = newCallback;
	}

	public void Open(bool autoOpen = false)
	{
		if (canOpen)
		{
			canOpen = false;
			AudioController.Play(capsuleOpenSound);
			GameObject gameObject = Object.Instantiate(smoke, top.transform.position, Quaternion.identity);
			Object.Instantiate(confetti, top.transform.position, Quaternion.identity);
			if (spawnCustomizationObject && !UnlockCustomizationObject(autoOpen))
			{
				InventoryItem randomElement = ListUtil.GetRandomElement(itemsToSpawnAfterUpgrades);
				ObjectSpawnParticles component = gameObject.GetComponent<ObjectSpawnParticles>();
				component.SetContainedItem(randomElement);
				component.spawnPos = top.transform.position;
			}
			if (containedDog != null)
			{
				ObjectSpawnParticles component2 = gameObject.GetComponent<ObjectSpawnParticles>();
				component2.SetContainedDog(containedDog);
				component2.dogRegRef = dogRegRef;
				component2.spawnPos = top.transform.position;
				component2.useReservedDog = true;
			}
			if (spawnNewDog)
			{
				ObjectSpawnParticles component3 = gameObject.GetComponent<ObjectSpawnParticles>();
				component3.SetSpawnNewDog();
				component3.dogRegRef = dogRegRef;
				component3.spawnPos = top.transform.position;
			}
			if (existingDogToSpawn != null)
			{
				ObjectSpawnParticles component4 = gameObject.GetComponent<ObjectSpawnParticles>();
				component4.SetExistingDogToSpawn(existingDogToSpawn);
				component4.dogRegRef = dogRegRef;
				component4.spawnPos = top.transform.position;
			}
			if (openCallback != null)
			{
				OnCapsuleOpenedCallback onCapsuleOpenedCallback = openCallback;
				openCallback = null;
				onCapsuleOpenedCallback();
			}
			GoalsController.ReportGoalEvent(GoalCondition.OPEN_CAPSULE);
			DogRegistration.SafeDestroy(base.gameObject);
		}
	}

	private bool UnlockCustomizationObject(bool autoOpen = false)
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		Researchable researchable = registrationScript.GetGlobalComponent<ResearchManager>(GlobalObject.RESEARCH_MANAGER).UnlockRandomResearch();
		if (researchable == null)
		{
			return false;
		}
		registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI).ShowObjectUnlockGUI(researchable, null, -1f, autoOpen);
		return true;
	}
}
