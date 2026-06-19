using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreedingController : MonoBehaviour
{
	public InventoryItem eggItem;

	public Transform spawnTransform;

	public DogDispensor dispensorRef;

	public GameObject destroyDogParticles;

	public float stabilityLossMin = 0.1f;

	public float stabilityLossMax = 0.15f;

	public float expectedMaxGenerations = 10f;

	public AnimationCurve stabilityLossCurve;

	private int dogsToSpawnDefault = 5;

	private int dogsToSpawnLow = 1;

	private int dogsToSpawnHigh = 8;

	private float defaultExtraDogChance = 0.5f;

	private float defaultFewerDogsChance;

	private float extraDogChanceLowerBound;

	private float fewerDogsChanceUpperBound = 0.75f;

	private string poofInSound = "breedingCenter_poofIn";

	private string poofOutSound = "breedingCenter_poofOut";

	private float currentStability = 1f;

	private int lastLitterSize;

	private int dogsToSpawnCurrent;

	private int currentGeneration;

	private DogRegistration dogRegRef;

	private PlayerInventory inventoryRef;

	private BreedingPenGUI breedingPenGUIRef;

	private ConstructionManager constructionRef;

	private void Awake()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		registrationScript.GetGlobalComponent<NavmeshHelper>(GlobalObject.NAVMESH_HELPER).Rebuild();
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		constructionRef = registrationScript.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
		breedingPenGUIRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI).GetBreedingPenGUIRef();
		inventoryRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).playerInventory;
		dispensorRef.HideDispensor();
	}

	public void OnFinalDogSelected()
	{
		breedingPenGUIRef.OnDogSelected();
	}

	public void AddFinalEggToInventory(SaveableDog sd, SaveableDog initialDogA, SaveableDog initialDogB)
	{
		List<string> list = new List<string>();
		if (initialDogA != null && initialDogA.gut != null && initialDogA.gut.gutFlora != null)
		{
			for (int i = 0; i < initialDogA.gut.gutFlora.Count; i++)
			{
				list.Add(initialDogA.gut.gutFlora[i].path);
			}
		}
		if (initialDogB != null && initialDogB.gut != null && initialDogB.gut.gutFlora != null)
		{
			for (int j = 0; j < initialDogB.gut.gutFlora.Count; j++)
			{
				list.Add(initialDogB.gut.gutFlora[j].path);
			}
		}
		bool newEmptyGut = list.Count == 0;
		SaveableDogEgg egg = new SaveableDogEgg(sd.dogGene, sd.dogProfile, fertilizedStatus: true, list, newEmptyGut);
		inventoryRef.AddEggToInventory(egg);
	}

	public void BreedSelectedDogs(SaveableDogGene geneA, SaveableDogGene geneB, bool playSounds = true)
	{
		currentGeneration++;
		breedingPenGUIRef.SetGeneration(currentGeneration);
		if (currentGeneration <= 1)
		{
			currentStability = 1f;
		}
		else
		{
			float num = Mathf.Clamp(1f - stabilityLossCurve.Evaluate((float)currentGeneration / expectedMaxGenerations), 0f, 1f);
			currentStability = Mathf.Clamp(currentStability - Random.Range(stabilityLossMin * (1f - num), stabilityLossMax * (1f - num)), 0f, 1f);
		}
		StartCoroutine(BreedRoutine(geneA, geneB, playSounds));
	}

	public float GetStability()
	{
		return currentStability;
	}

	private IEnumerator BreedRoutine(SaveableDogGene geneA, SaveableDogGene geneB, bool playSounds)
	{
		if (playSounds)
		{
			AudioController.Play(poofOutSound);
		}
		CheatEngine.DestroyAllDogs(destroyDogParticles, safeDestroy: true, fromScript: true);
		breedingPenGUIRef.HideBreedingObjects();
		yield return new WaitForSeconds(1f);
		float num = defaultExtraDogChance - extraDogChanceLowerBound;
		float num2 = defaultExtraDogChance - (1f - currentStability) * num;
		float num3 = fewerDogsChanceUpperBound - defaultFewerDogsChance;
		float num4 = defaultFewerDogsChance + (1f - currentStability) * num3;
		lastLitterSize = dogsToSpawnDefault;
		while (lastLitterSize > dogsToSpawnLow && Random.value <= num4)
		{
			lastLitterSize--;
		}
		while (lastLitterSize < dogsToSpawnHigh && Random.value <= num2)
		{
			lastLitterSize++;
		}
		lastLitterSize = Mathf.Min(lastLitterSize, dogRegRef.GetMaxDogs());
		dogsToSpawnCurrent = lastLitterSize;
		BoundingBoxComponent component = constructionRef.GetAllRooms()[0].GetComponent<BoundingBoxComponent>();
		for (int i = 0; i < lastLitterSize; i++)
		{
			string dogGene = MasterDogGene.MutateGenome(MasterDogGene.Breed(geneA.dogGene, geneB.dogGene));
			string domRecGene = MasterDogGene.BreedDomRecGenes(geneA.domRecGene, geneB.domRecGene, currentStability);
			SaveableDogGene saveableDogGene = new SaveableDogGene();
			saveableDogGene.dogGene = dogGene;
			saveableDogGene.domRecGene = domRecGene;
			saveableDogGene.geneVersion = MasterDogGene.currentGeneticVersion;
			dogRegRef.RequestNewDog(component.GetBoxCenter(), Random.rotation, saveableDogGene, null, manualDog: false, OnDogSpawned, playerOwned: true, useBaseGeneWithoutMutation: false, timeslice: true, forceCacheThumbnails: true, dummyDog: false, null, DogAge.ADULT, 0f, traitsAllowed: true, useTemporaryID: true, null, null, respectMaxDogs: true, isGhost: false, null, null, spawnDuringPause: false);
		}
	}

	private void OnDogSpawned(GameObject dog)
	{
		if (dog != null)
		{
			dog.GetComponent<DoggyBrain>().SetNeedsFrozen(val: true);
			dog.GetComponent<DogIndicatorController>().DisableEntireIndicator();
			BoundingBoxComponent component = dog.GetComponent<BoundingBoxComponent>();
			component.MoveToGoodLocation();
			AudioController.Play(poofInSound);
			Object.Instantiate(destroyDogParticles, component.GetBoxCenter(), Quaternion.identity);
		}
		else
		{
			Debug.LogError("Failed to spawn dog.");
		}
		dogsToSpawnCurrent--;
		if (dogsToSpawnCurrent <= 0)
		{
			OnAllDogsSpawned();
		}
	}

	private void OnAllDogsSpawned()
	{
		if (lastLitterSize >= dogsToSpawnHigh)
		{
			breedingPenGUIRef.OnMassiveLitter();
		}
		else if (lastLitterSize <= dogsToSpawnLow)
		{
			breedingPenGUIRef.OnTinyLitter();
		}
		else
		{
			breedingPenGUIRef.ShowBreedingObjects();
		}
	}
}
