using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
	public enum AutoCleanFoodType
	{
		NONE = 0,
		EMPTY_COCOON = 1,
		HALF_EATEN_FOOD = 2,
		BABY_TOOTH = 3,
		DIRT = 4,
		SNOW = 5
	}

	public AutoCleanFoodType autoCleanupFoodType;

	public int bitesTotal = 5;

	public GameObject particleObj;

	public GameObject lastBiteParticleObj;

	public float hungerGivenPerBite = 0.25f;

	public List<GutFloraResource> gutFloraTypes = new List<GutFloraResource>();

	public List<GutFloraResource> boostedGutFloraTypes = new List<GutFloraResource>();

	public List<Color> associatedColors = new List<Color>();

	public bool isPoop;

	private int bitesCurrent;

	private float stolenFoodAnger = -0.25f;

	private Material eatMat;

	private string biteSFX = "food_bite";

	private string lastBiteSFX = "food_bite_last";

	private List<GameObject> eatingDogs = new List<GameObject>();

	private float foodDistractionChance = 0.1f;

	private float distractionTimer = 5f;

	private float currentDistractionTimer;

	private List<GameObject> dogList = new List<GameObject>();

	public GameObject actionParticles;

	private string objectDestroySound = "object_destroy";

	private float currentTimer;

	private float autoCleanupTimer = 10f;

	private float autoCleanupJiggle = 5f;

	private DogRegistration dogRegRef;

	private void Awake()
	{
		AwakeBehavior();
		currentTimer = Random.Range(0f - autoCleanupJiggle, 0f);
	}

	private void Update()
	{
		TryDistractDogs();
		TickAutoClean();
	}

	private void TickAutoClean()
	{
		if (GameSettings.IsPassiveModeEnabled() && autoCleanupFoodType != AutoCleanFoodType.NONE && ((GameSettings.PassiveModeAutoCleanEmptyCocoons() && autoCleanupFoodType == AutoCleanFoodType.EMPTY_COCOON) || (GameSettings.PassiveModeAutoCleanHalfEatenFood() && autoCleanupFoodType == AutoCleanFoodType.HALF_EATEN_FOOD) || (GameSettings.PassiveModeAutoCleanBabyTeeth() && autoCleanupFoodType == AutoCleanFoodType.BABY_TOOTH) || (GameSettings.PassiveModeAutoCleanDirt() && autoCleanupFoodType == AutoCleanFoodType.DIRT) || (GameSettings.PassiveModeAutoCleanSnow() && autoCleanupFoodType == AutoCleanFoodType.SNOW)))
		{
			currentTimer += Time.deltaTime;
			if (currentTimer >= autoCleanupTimer)
			{
				Vector3 objCenter = ObjectUtil.GetObjCenter(base.gameObject);
				Object.Instantiate(actionParticles, objCenter, Quaternion.identity);
				AudioController.Play(objectDestroySound, objCenter);
				Object.Destroy(base.gameObject);
			}
		}
	}

	protected virtual void AwakeBehavior()
	{
		ManualAwaken();
	}

	public void ManualAwaken()
	{
		if (!(particleObj == null))
		{
			bitesCurrent = bitesTotal;
			Renderer component = particleObj.GetComponentInChildren<ParticleSystem>().GetComponent<Renderer>();
			eatMat = new Material(component.sharedMaterial);
			dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		}
	}

	public Color GetRandomColor()
	{
		if (associatedColors.Count == 0)
		{
			return GetComponentInChildren<Renderer>().sharedMaterial.color;
		}
		return ListUtil.GetRandomElement(associatedColors);
	}

	public int GetBitesLeft()
	{
		return bitesCurrent;
	}

	public void SetBitesLeft(int newVal)
	{
		bitesCurrent = newVal;
	}

	public bool CanBite()
	{
		return bitesCurrent > 0;
	}

	public void RequestBite(GameObject dog, int activeMouthIndex, bool fromGhost = false)
	{
		eatMat.color = GetRandomColor();
		if (bitesCurrent == 1)
		{
			ulong iDFromDog = dogRegRef.GetIDFromDog(dog);
			InteractableBase component = GetComponent<InteractableBase>();
			if (component.IsObjectInUseByAnotherDog(iDFromDog))
			{
				List<ulong> useList = component.GetUseList();
				for (int i = 0; i < useList.Count; i++)
				{
					if (useList[i] != iDFromDog)
					{
						DoggyBrain component2 = dogRegRef.GetDogFromID(useList[i]).GetComponent<DoggyBrain>();
						if (component2.GetFeelingTowardsTarget(dog) == Opinion.DISLIKE)
						{
							component2.UpdateAnger(stolenFoodAnger);
						}
						else
						{
							component2.GetComponent<DogParticleController>().RequestSurpriseParticlesStart();
						}
					}
				}
			}
		}
		if (!fromGhost)
		{
			bitesCurrent--;
		}
		RequestParticleBurst(dog, activeMouthIndex);
		if (!fromGhost)
		{
			OnBiteTaken(dog);
		}
	}

	public void AssignDog(GameObject newDog)
	{
		if (eatingDogs.Contains(newDog))
		{
			Debug.LogError(string.Concat("Dog: ", newDog, " is already eating this object: ", base.gameObject));
		}
		else
		{
			eatingDogs.Add(newDog);
		}
	}

	public void ReleaseDog(GameObject dogToRelease)
	{
		if (!eatingDogs.Contains(dogToRelease))
		{
			Debug.LogError(string.Concat("Dog: ", dogToRelease, " is not eating this object: ", base.gameObject));
			return;
		}
		eatingDogs.Remove(dogToRelease);
		if (eatingDogs.Count == 0 && bitesCurrent == 0)
		{
			if (base.gameObject.CompareTag(Tags.DIRT_CLUMP))
			{
				GoalsController.ReportGoalEvent(GoalCondition.EAT_DIRT);
			}
			else if (base.gameObject.CompareTag(Tags.POOP))
			{
				GoalsController.ReportGoalEvent(GoalCondition.EAT_POOP);
			}
			Object.Destroy(base.gameObject);
		}
	}

	private void RequestParticleBurst(GameObject dog, int activeMouthIndex)
	{
		GameObject gameObject = dog.GetComponent<FaceController>().GetDogHeadForIndex(activeMouthIndex).mouthTransform.gameObject;
		GameObject gameObject2;
		if (bitesCurrent > 0)
		{
			AudioController.Play(biteSFX, gameObject.transform.position);
			gameObject2 = Object.Instantiate(particleObj, gameObject.transform.position, Quaternion.identity);
		}
		else
		{
			AudioController.Play(lastBiteSFX, gameObject.transform.position);
			gameObject2 = Object.Instantiate(lastBiteParticleObj, gameObject.transform.position, Quaternion.identity);
		}
		gameObject2.GetComponentInChildren<ParticleSystem>().GetComponent<Renderer>().material = eatMat;
	}

	protected virtual void OnBiteTaken(GameObject dog)
	{
		if (bitesCurrent <= 0)
		{
			CrackedDogCore component = base.gameObject.GetComponent<CrackedDogCore>();
			if (component != null)
			{
				component.TransferLifeBonusToConsumingDog(dog);
			}
		}
		dog.GetComponent<DoggyBrain>().OnBiteTaken();
	}

	private void TryDistractDogs()
	{
		currentDistractionTimer -= Time.deltaTime;
		if (currentDistractionTimer > 0f)
		{
			return;
		}
		currentDistractionTimer = distractionTimer;
		dogRegRef.GetNearbyDogList(base.gameObject, ref dogList);
		for (int i = 0; i < dogList.Count; i++)
		{
			if (dogList[i].GetComponent<DoggyBrain>().GetPersonality().GetFoodPersonality() == FoodPersonalityType.FOOD_OBSESSED)
			{
				DogAI component = dogList[i].GetComponent<DogAI>();
				if (!component.WillBehaviorSolveForNeed(component.GetCurrentBehavior(), Need.Hunger))
				{
					DistractionFood newDistraction = new DistractionFood(component, foodDistractionChance, base.gameObject);
					component.TryAddNewDistraction(newDistraction);
				}
			}
		}
	}
}
