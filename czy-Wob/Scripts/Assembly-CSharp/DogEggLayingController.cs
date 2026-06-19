using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogEggLayingController : MonoBehaviour
{
	public delegate void EggLaidCallback();

	public InventoryItem egg;

	public InventoryItem dudEgg;

	public InventoryItem capsule;

	public AnimationCurve dudChanceCurve;

	private EggLaidCallback currentEggLaidCallback;

	private bool makeNextEggUnbreakable;

	private int dudEggRangeLow = 2;

	private int dudEggRangeHigh = 15;

	private int dudEggAssuredScaphCount = 15;

	private float eggTimer;

	private float timeToLayEgg = 300f;

	private float capsuleTimer;

	private float timeToLayCapsule = 180f;

	private float capsuleChance = 0.5f;

	private float unhappyEggRateMultiplier = 0.5f;

	private string eggLayingSound = "egg_lay";

	private bool canStillLayEggs = true;

	private float multipleEggsChance = 0.01f;

	private Coroutine eggsRoutine;

	private int eggsOverride = -1;

	private float eggStress = -0.02f;

	private bool requestingEggDog;

	private Color eggDogMainColor = Color.white;

	private Color eggDogEmissionColor = Color.white;

	private Vector3 eggDogBodySizeMod = Vector3.zero;

	private float roomSwitchCost = 0.75f;

	private float minTargetDistance = 3f;

	private float maxTargetDistance = 20f;

	private float minTargetDistanceMultiplier = 1.2f;

	private float maxTargetDistanceMultiplier = 0.2f;

	private float dislikeRangeLow = 0.75f;

	private float dislikeRangeHigh = 0.15f;

	private float neutralRangeLow = 1f;

	private float neutralRangeHigh = 3f;

	private float likeRangeLow = 1.25f;

	private float likeRangeHigh = 10f;

	private Transform buttRef;

	private DoggyBrain brainRef;

	private FaceController faceRef;

	private DogParticleController particleRef;

	private SceneManagerBase sceneRef;

	private void Awake()
	{
		dudChanceCurve.preWrapMode = WrapMode.Once;
		dudChanceCurve.postWrapMode = WrapMode.Once;
		brainRef = GetComponent<DoggyBrain>();
		faceRef = GetComponent<FaceController>();
		particleRef = GetComponent<DogParticleController>();
		buttRef = GetComponent<LegController>().butt.transform;
		sceneRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
	}

	private void OnDestroy()
	{
		StopEggsRoutine();
	}

	private void Update()
	{
		if (eggsRoutine != null)
		{
			return;
		}
		CapsuleUpdate();
		if (CanLayEggs() && sceneRef.GetGameMode() == GameMode.HOME)
		{
			if (!brainRef.IsHappy())
			{
				eggTimer += Time.deltaTime * unhappyEggRateMultiplier;
			}
			else
			{
				eggTimer += Time.deltaTime;
			}
		}
	}

	private void CapsuleUpdate()
	{
		if (!(capsuleTimer >= timeToLayCapsule) && !PauseController.IsPaused() && sceneRef.GetGameMode() == GameMode.HOME && brainRef.GetCurrentDogAge() >= DogAge.ADULT && brainRef.IsHappy())
		{
			capsuleTimer += Time.deltaTime;
			if (capsuleTimer >= timeToLayCapsule && Random.value >= capsuleChance)
			{
				capsuleTimer = 0f;
			}
		}
	}

	public void SetEggOverride(int val)
	{
		eggsOverride = val;
		eggTimer = timeToLayEgg;
	}

	public float GetCurrentEggTimerValue()
	{
		return eggTimer;
	}

	public float GetCurrentCapsuleTimerValue()
	{
		return capsuleTimer;
	}

	public bool CanDogStillLayEggs()
	{
		return canStillLayEggs;
	}

	public bool CanLayCapsule()
	{
		if (sceneRef.GetGameMode() != GameMode.HOME)
		{
			return false;
		}
		return capsuleTimer >= timeToLayCapsule;
	}

	public void SetCurrentEggTimer(float newValue)
	{
		eggTimer = newValue;
	}

	public void SetCurrentCapsuleTimer(float newValue)
	{
		capsuleTimer = newValue;
	}

	public void SetCanLayEggs(bool newValue)
	{
		canStillLayEggs = newValue;
	}

	public bool ReadyToLayEggs()
	{
		if (sceneRef.GetGameMode() != GameMode.HOME)
		{
			return false;
		}
		if (TutorialController.IsTutorialActive())
		{
			return false;
		}
		return eggTimer >= timeToLayEgg;
	}

	public bool CanLayEggs()
	{
		if (canStillLayEggs)
		{
			return brainRef.GetCurrentDogAge() >= DogAge.ADULT;
		}
		return false;
	}

	public void SetNextEggUnbreakable()
	{
		makeNextEggUnbreakable = true;
	}

	public void SetEggLaidCallback(EggLaidCallback newCallback)
	{
		currentEggLaidCallback = newCallback;
	}

	public void LayEggs(EggLaidCallback newCallback, bool layCapsuleInstead = false)
	{
		StopEggsRoutine();
		SetEggLaidCallback(newCallback);
		if (TutorialController.HasInitialEggBeenCollected())
		{
			int scaphCount = GetComponent<DogGutController>().GetDogGut().GetScaphCount();
			float num = dudChanceCurve.Evaluate(scaphCount);
			if (Random.value <= num || scaphCount >= dudEggAssuredScaphCount)
			{
				eggsOverride = Random.Range(dudEggRangeLow, dudEggRangeHigh);
			}
		}
		eggsRoutine = StartCoroutine(EggLayingRoutine(layCapsuleInstead));
	}

	private IEnumerator EggLayingRoutine(bool layCapsuleInstead = false)
	{
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		if (!layCapsuleInstead)
		{
			canStillLayEggs = true;
		}
		DoggyBrain brainRef = GetComponent<DoggyBrain>();
		bool layDown = false;
		if (eggsOverride > 0)
		{
			layDown = true;
			GetComponent<LieDownBehavior>().RequestLieDown();
		}
		bool surpriseRequested = false;
		while (canStillLayEggs || layCapsuleInstead)
		{
			float finalDelay = 1f;
			if (eggsOverride > 0)
			{
				finalDelay = Random.Range(0.5f, 1f);
			}
			DogGut gutRefA = null;
			DogGut gutRefB = null;
			string dogGene = null;
			SaveableDogGene childSD = null;
			if (GameSettings.IsPassiveModeEnabled() && GameSettings.PassiveModeAutoBreedingOption() != GameSettings.PassiveBreedingOption.DISABLED)
			{
				DogRegistration globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
				List<GameObject> list = new List<GameObject>();
				List<float> list2 = new List<float>();
				GameObject weightedRandom = base.gameObject;
				if (GameSettings.PassiveModeAutoBreedingOption() != GameSettings.PassiveBreedingOption.SINGLE_PARENT)
				{
					if (GameSettings.PassiveModeAutoBreedingOption() == GameSettings.PassiveBreedingOption.RANDOM_PARENT)
					{
						List<GameObject> allInWorldOwnedDogs = globalComponent.GetAllInWorldOwnedDogs(includeGhosts: false);
						for (int i = 0; i < allInWorldOwnedDogs.Count; i++)
						{
							if (allInWorldOwnedDogs[i] != base.gameObject && allInWorldOwnedDogs[i].GetComponent<DoggyBrain>().GetCurrentDogAge() >= DogAge.ADULT)
							{
								list.Add(allInWorldOwnedDogs[i]);
								list2.Add(1f);
							}
						}
					}
					else if (GameSettings.PassiveModeAutoBreedingOption() == GameSettings.PassiveBreedingOption.PROXIMAL_PARENT)
					{
						NavmeshHelper globalComponent2 = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<NavmeshHelper>(GlobalObject.NAVMESH_HELPER);
						ConstructionManager globalComponent3 = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
						List<GameObject> allInWorldOwnedDogs2 = globalComponent.GetAllInWorldOwnedDogs(includeGhosts: false);
						for (int j = 0; j < allInWorldOwnedDogs2.Count; j++)
						{
							if (!(allInWorldOwnedDogs2[j] != base.gameObject) || allInWorldOwnedDogs2[j].GetComponent<DoggyBrain>().GetCurrentDogAge() < DogAge.ADULT || !globalComponent3.IsDogInRoomConnectedToObject(base.gameObject, allInWorldOwnedDogs2[j]))
							{
								continue;
							}
							float num = 1f;
							Vector3 hitPoint = allInWorldOwnedDogs2[j].GetComponent<LegController>().bodyFront.transform.position;
							ObjectUtil.GetStageHitpoint(hitPoint, ref hitPoint);
							if (globalComponent2.GetPath(base.gameObject, hitPoint).Length == 0)
							{
								continue;
							}
							Vector3 position = GetComponent<FaceController>().GetDogHeadForIndex(0).mouthTransform.position;
							Vector3 position2 = allInWorldOwnedDogs2[j].GetComponent<FaceController>().GetDogHeadForIndex(0).mouthTransform.position;
							float valueOfRangePercentage = MathUtil.GetValueOfRangePercentage(MathUtil.GetPercentageOfRange(Mathf.Clamp(Vector3.Distance(position, position2), minTargetDistance, maxTargetDistance), minTargetDistance, maxTargetDistance), minTargetDistanceMultiplier, maxTargetDistanceMultiplier);
							num *= valueOfRangePercentage;
							ulong? roomUID = GetComponent<BoundingBoxComponent>().GetRoomUID();
							ulong? roomUID2 = allInWorldOwnedDogs2[j].GetComponent<BoundingBoxComponent>().GetRoomUID();
							float num2 = RoomPathfinder.EstimatePathDistance(roomUID, roomUID2, globalComponent3);
							if (num2 != 0f && num2 != -1f)
							{
								for (int k = 0; (float)k < num2; k++)
								{
									num *= roomSwitchCost;
								}
							}
							list.Add(allInWorldOwnedDogs2[j]);
							list2.Add(num);
						}
					}
				}
				if (list.Count > 0)
				{
					if (GameSettings.PassiveModeAutoBreedingRelationshipRequirement() == GameSettings.PassiveBreedingRelationshipRequirement.REQUIRED || GameSettings.PassiveModeAutoBreedingRelationshipRequirement() == GameSettings.PassiveBreedingRelationshipRequirement.CONSIDERED_NOT_REQUIRED)
					{
						if (GameSettings.PassiveModeAutoBreedingRelationshipRequirement() == GameSettings.PassiveBreedingRelationshipRequirement.REQUIRED)
						{
							for (int num3 = list.Count - 1; num3 >= 0; num3--)
							{
								if (!brainRef.HasInteractedWithDog(list[num3]))
								{
									list.RemoveAt(num3);
									list2.RemoveAt(num3);
								}
							}
						}
						for (int l = 0; l < list.Count; l++)
						{
							if (brainRef.HasInteractedWithDog(list[l]))
							{
								Opinion feelingTowardsTarget = brainRef.GetFeelingTowardsTarget(list[l]);
								float opinionOfDogReinforcementPercentage = brainRef.GetOpinionOfDogReinforcementPercentage(list[l]);
								switch (feelingTowardsTarget)
								{
								case Opinion.DISLIKE:
									list2[l] *= MathUtil.GetValueOfRangePercentage(opinionOfDogReinforcementPercentage, dislikeRangeLow, dislikeRangeHigh);
									break;
								case Opinion.NEUTRAL:
									list2[l] *= MathUtil.GetValueOfRangePercentage(opinionOfDogReinforcementPercentage, neutralRangeLow, neutralRangeHigh);
									break;
								case Opinion.LIKE:
									list2[l] *= MathUtil.GetValueOfRangePercentage(opinionOfDogReinforcementPercentage, likeRangeLow, likeRangeHigh);
									break;
								}
							}
							else
							{
								list2[l] *= 0.1f;
							}
						}
					}
					if (list.Count > 0)
					{
						weightedRandom = ListUtil.GetWeightedRandom(list, list2);
					}
				}
				gutRefA = GetComponent<DogGutController>().GetDogGut();
				gutRefB = weightedRandom.GetComponent<DogGutController>().GetDogGut();
				MasterDogGene component = GetComponent<MasterDogGene>();
				MasterDogGene component2 = weightedRandom.GetComponent<MasterDogGene>();
				if (GameSettings.PassiveEggMutationRate() == GameSettings.PassiveMutationRate.NONE)
				{
					dogGene = MasterDogGene.Breed(component.GetFullGene(), component2.GetFullGene());
				}
				else if (GameSettings.PassiveEggMutationRate() == GameSettings.PassiveMutationRate.DEFAULT)
				{
					dogGene = MasterDogGene.MutateGenome(MasterDogGene.Breed(component.GetFullGene(), component2.GetFullGene()));
				}
				else if (GameSettings.PassiveEggMutationRate() == GameSettings.PassiveMutationRate.HIGH)
				{
					dogGene = MasterDogGene.MutateGenome(MasterDogGene.Breed(component.GetFullGene(), component2.GetFullGene()), allowSuperMutations: true, forceMutation: true, 2f);
				}
				else if (GameSettings.PassiveEggMutationRate() == GameSettings.PassiveMutationRate.VERY_HIGH)
				{
					dogGene = MasterDogGene.MutateGenome(MasterDogGene.Breed(component.GetFullGene(), component2.GetFullGene()), allowSuperMutations: true, forceMutation: true, 10f);
				}
				string domRecGene = MasterDogGene.BreedDomRecGenes(component.GetDomRecGene(), component2.GetDomRecGene(), 0.75f);
				childSD = new SaveableDogGene
				{
					dogGene = dogGene,
					domRecGene = domRecGene,
					geneVersion = MasterDogGene.currentGeneticVersion
				};
			}
			GameObject gameObject;
			if (layDown)
			{
				gameObject = Object.Instantiate(dudEgg.itemPrefab, buttRef.position, buttRef.rotation);
				ObjectRegistration.GetRegistrationScript().AssignID(gameObject, dudEgg);
			}
			else if (layCapsuleInstead)
			{
				gameObject = Object.Instantiate(capsule.itemPrefab, buttRef.position, buttRef.rotation);
				ObjectRegistration.GetRegistrationScript().AssignID(gameObject, capsule);
			}
			else
			{
				if (GameSettings.IsPassiveModeEnabled() && GameSettings.PassiveModeAutoBreedingOption() != GameSettings.PassiveBreedingOption.DISABLED && !requestingEggDog)
				{
					requestingEggDog = true;
					ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).RequestNewDog(new Vector3(-100f, -100f, -100f), Quaternion.identity, childSD, null, manualDog: false, OnEggDogCreated, playerOwned: false);
					float timeoutMax = 10f;
					while (requestingEggDog && timeoutMax > 0f)
					{
						yield return frameWait;
						timeoutMax -= Time.deltaTime;
					}
				}
				gameObject = Object.Instantiate(egg.itemPrefab, buttRef.position, buttRef.rotation);
				ObjectRegistration.GetRegistrationScript().AssignID(gameObject, egg);
			}
			AudioController.Play(eggLayingSound, buttRef.position);
			if (eggsOverride > 0)
			{
				if (!surpriseRequested)
				{
					surpriseRequested = true;
					faceRef.RequestFace(Face.SURPRISED);
				}
			}
			else
			{
				particleRef.RequestSurpriseParticlesStart();
			}
			DogEgg component3 = gameObject.GetComponent<DogEgg>();
			if (component3 != null)
			{
				if (GameSettings.IsPassiveModeEnabled() && GameSettings.PassiveModeAutoBreedingOption() != GameSettings.PassiveBreedingOption.DISABLED)
				{
					component3.fertilized = true;
					List<string> list3 = new List<string>();
					List<GutFloraBase> allGutFlora = gutRefA.GetAllGutFlora();
					List<GutFloraBase> allGutFlora2 = gutRefB.GetAllGutFlora();
					for (int m = 0; m < allGutFlora.Count; m++)
					{
						list3.Add(allGutFlora[m].GetFloraPath());
					}
					for (int n = 0; n < allGutFlora2.Count; n++)
					{
						list3.Add(allGutFlora2[n].GetFloraPath());
					}
					SaveableDogEgg associatedSaveableEgg = new SaveableDogEgg(childSD, null, fertilizedStatus: true, list3, newEmptyGut: false);
					component3.SetAssociatedSaveableEgg(associatedSaveableEgg);
					component3.SetEggSize(eggDogBodySizeMod);
					component3.SetEggTexture(eggDogMainColor, eggDogEmissionColor);
				}
				if (makeNextEggUnbreakable)
				{
					component3.SetUnbreakable();
				}
			}
			yield return new WaitForSeconds(finalDelay);
			if (makeNextEggUnbreakable)
			{
				makeNextEggUnbreakable = false;
			}
			if (layCapsuleInstead)
			{
				break;
			}
			if (Random.value > multipleEggsChance)
			{
				canStillLayEggs = false;
			}
			if (eggsOverride > 0)
			{
				eggsOverride--;
				canStillLayEggs = true;
				brainRef.UpdateStress(eggStress);
			}
		}
		if (surpriseRequested)
		{
			faceRef.RequestFace(Face.DEFAULT);
		}
		if (layDown)
		{
			GetComponent<LieDownBehavior>().RequestStandUp();
			yield return new WaitForSeconds(5f);
		}
		if (layCapsuleInstead)
		{
			capsuleTimer = 0f;
		}
		else
		{
			eggTimer = 0f;
		}
		eggsRoutine = null;
		if (currentEggLaidCallback != null)
		{
			currentEggLaidCallback();
			currentEggLaidCallback = null;
		}
	}

	private void OnEggDogCreated(GameObject newDog)
	{
		requestingEggDog = false;
		DogLooks component = newDog.GetComponent<DogLooks>();
		Material bodyMainMaterial = component.GetBodyMainMaterial();
		eggDogMainColor = bodyMainMaterial.color;
		eggDogEmissionColor = bodyMainMaterial.GetColor("_EmissionColor");
		eggDogBodySizeMod = component.GetBodySizeMod();
		Object.Destroy(newDog);
	}

	private void StopEggsRoutine()
	{
		if (eggsRoutine != null)
		{
			StopCoroutine(eggsRoutine);
			eggsRoutine = null;
			faceRef.RequestFace(Face.DEFAULT);
		}
	}
}
