using System.Collections;
using Cinemachine;
using ClockStone;
using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

public class Incubator : ClickableObject
{
	public GameObject incubatedEgg;

	public GameObject incubationGUI;

	public GameObject incubationTimer;

	public Image incubationTimerFill;

	public Transform spawnTransform;

	public GameObject readyToHatchGUI;

	public GameObject dogSpawnParticles;

	public GameObject confettiParticles;

	public Renderer mainRenderer;

	public Material unlitMat;

	public Material litMat;

	public GameObject dogNamingPopup;

	public Transform tutorialPopupDisplayTransform;

	public CinemachineVirtualCamera hatchCam;

	public GameObject worldMessagePrefab;

	private Vector3 messageOffset = new Vector3(0f, 1.5f, 0f);

	private string incubatorDingSound = "incubator_ding";

	private string incubatorHatchSound = "incubator_hatch";

	private string incubatorRunningSound = "incubator_running";

	private string incubatorSmokePuffSound = "incubator_smokePuff";

	private AudioObject incubatorRunningAudioObject;

	private bool readyToHatch;

	private bool eggBeingIncubated;

	private bool incubatedEggIsDefault;

	private SaveableDogEgg currentlyIncubatedEgg;

	private float totalIncubationTime;

	private float requiredIncubationTime = 30f;

	private float requiredIncubationTimeTutorial = 5f;

	private DogRegistration dogRegRef;

	private PlayerInventory playerInventoryRef;

	private void Awake()
	{
		incubatedEgg.SetActive(value: false);
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		playerInventoryRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).playerInventory;
		incubationTimer.SetActive(value: false);
		readyToHatchGUI.SetActive(value: false);
		mainRenderer.material = unlitMat;
	}

	public void SaveObject(SaveablePlacedObject data)
	{
		data.boolList.Add(readyToHatch);
		data.boolList.Add(eggBeingIncubated);
		data.boolList.Add(incubatedEggIsDefault);
		data.eggA = currentlyIncubatedEgg;
		data.floatList.Add(totalIncubationTime);
	}

	public void LoadObject(SaveablePlacedObject data)
	{
		if (data.eggA != null && data.boolList[1])
		{
			bool isDefaultEgg = false;
			if (data.boolList.Count > 2)
			{
				isDefaultEgg = data.boolList[2];
			}
			PlaceEggInIncubator(data.eggA.GetCopy(), isDefaultEgg);
			totalIncubationTime = data.floatList[0];
			if (data.boolList[0])
			{
				OnIncubationFinished(sounds: false);
			}
		}
	}

	private void OnDestroy()
	{
		if (incubatorRunningAudioObject != null)
		{
			incubatorRunningAudioObject.Stop();
			incubatorRunningAudioObject = null;
		}
		if (eggBeingIncubated && currentlyIncubatedEgg != null && !incubatedEggIsDefault)
		{
			playerInventoryRef.AddEggToInventory(currentlyIncubatedEgg);
		}
	}

	private void Update()
	{
		if (eggBeingIncubated && !readyToHatch)
		{
			totalIncubationTime += Time.deltaTime;
			UpdateTimer();
			float num = requiredIncubationTime;
			if (TutorialController.IsTutorialActive())
			{
				num = requiredIncubationTimeTutorial;
			}
			if (totalIncubationTime >= num)
			{
				OnIncubationFinished();
			}
		}
	}

	protected override void OnClickInternal()
	{
		base.OnClickInternal();
		if (readyToHatch)
		{
			if (dogRegRef.GetNumberOfOwnedAndLoadingDogsMinusGhosts() >= dogRegRef.GetMaxDogs())
			{
				DisplayTooManyDogsError(ScriptLocalization.GUI.GUI_MESSAGE_NOMOREDOGS);
				return;
			}
			readyToHatch = false;
			eggBeingIncubated = false;
			incubatedEggIsDefault = false;
			incubatedEgg.SetActive(value: false);
			mainRenderer.material = unlitMat;
			readyToHatchGUI.SetActive(value: false);
			StartCoroutine(DogSpawnRoutine());
		}
		else
		{
			Object.Instantiate(incubationGUI, Vector3.zero, Quaternion.identity).GetComponent<IncubatorGUIController>().SetIncubationRef(this);
		}
	}

	private void DisplayTooManyDogsError(string message)
	{
		GameObject obj = Object.Instantiate(worldMessagePrefab, spawnTransform.position + messageOffset, Quaternion.identity);
		obj.transform.localScale = Vector3.one;
		WorldMessage component = obj.GetComponent<WorldMessage>();
		component.SetFadeTime(1.5f);
		component.SetDisplayColor(Color.red);
		component.SetDisplayMessage(message);
	}

	public bool IsCurrentlyIncubatingEgg()
	{
		return eggBeingIncubated;
	}

	public void PlaceEggInIncubator(SaveableDogEgg eggRef, bool isDefaultEgg)
	{
		if (eggBeingIncubated)
		{
			Debug.LogError("Attempting to incubate an egg but one is already being incubated.");
			return;
		}
		totalIncubationTime = 0f;
		eggBeingIncubated = true;
		incubatedEggIsDefault = isDefaultEgg;
		incubatedEgg.SetActive(value: true);
		mainRenderer.material = litMat;
		currentlyIncubatedEgg = eggRef;
		incubationTimer.SetActive(value: true);
		UpdateTimer();
		incubatorRunningAudioObject = AudioController.Play(incubatorRunningSound, incubatedEgg.transform);
	}

	private IEnumerator DogSpawnRoutine()
	{
		guiRef.DisableBG(LockReason.EGG_HATCH, blur: false, pause: false);
		ObjectSpawnParticles component = Object.Instantiate(dogSpawnParticles, spawnTransform.position, Quaternion.identity).GetComponent<ObjectSpawnParticles>();
		component.SetSpawnNewDog();
		component.SetSpawnCallback(OnNewDogCreated);
		if (currentlyIncubatedEgg.floraPool != null)
		{
			component.SetFloraPool(currentlyIncubatedEgg.floraPool);
		}
		if (currentlyIncubatedEgg.emptyGut)
		{
			component.SetEmptyGut(currentlyIncubatedEgg.emptyGut);
		}
		AudioController.Play(incubatorSmokePuffSound, spawnTransform.position);
		if (currentlyIncubatedEgg != null && currentlyIncubatedEgg.associatedGene != null)
		{
			component.SetDogGene(currentlyIncubatedEgg.associatedGene);
		}
		yield return new WaitForSeconds(0.15f);
		Object.Instantiate(confettiParticles, spawnTransform.position, Quaternion.identity);
	}

	private void OnIncubationFinished(bool sounds = true)
	{
		readyToHatch = true;
		totalIncubationTime = 0f;
		readyToHatchGUI.SetActive(value: true);
		incubationTimer.SetActive(value: false);
		if (incubatorRunningAudioObject != null)
		{
			incubatorRunningAudioObject.Stop();
			incubatorRunningAudioObject = null;
		}
		if (sounds)
		{
			AudioController.Play(incubatorDingSound, incubatedEgg.transform);
		}
	}

	private void UpdateTimer()
	{
		float num = requiredIncubationTime;
		if (TutorialController.IsTutorialActive())
		{
			num = requiredIncubationTimeTutorial;
		}
		incubationTimerFill.fillAmount = Mathf.Min(1f, totalIncubationTime / num);
	}

	private void OnNewDogCreated(GameObject newDog)
	{
		StartCoroutine(OnNewDogCreatedRoutine(newDog));
		AudioController.Play(incubatorHatchSound, newDog.GetComponent<LegController>().bodyFront.transform);
	}

	private IEnumerator OnNewDogCreatedRoutine(GameObject newDog)
	{
		newDog.GetComponent<DoggyBrain>().SetDogHatchedFromEgg(status: true);
		newDog.GetComponent<DogIndicatorController>().DisableEntireIndicator();
		if (TutorialController.IsTutorialActive())
		{
			TutorialController.OnDogHatched();
		}
		ulong dogID = dogRegRef.GetSaveableDogFromDog(newDog).dogID;
		MasterDogGene geneRef = newDog.GetComponent<MasterDogGene>();
		if (geneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_FRONT_LEFT_LEG))
		{
			bool flag = !geneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_BACK_LEFT_LEG);
			bool flag2 = !geneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_BACK_RIGHT_LEG);
			bool flag3 = !geneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_FRONT_RIGHT_LEG);
			if (flag3 && flag && flag2)
			{
				GoalsController.ReportGoalEvent(GoalCondition.HATCH_DOG_MISSING_FRONT_LEFT_LEG);
			}
			else if (!flag3 && !flag && !flag2)
			{
				GoalsController.ReportGoalEvent(GoalCondition.HATCH_DOG_NO_LEGS);
			}
		}
		WingType wingType = newDog.GetComponent<DogLooks>().GetWingType();
		bool domRecPropertyStatus = geneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.WING_ISSUES);
		bool flag4 = geneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_LEFT_WING);
		bool flag5 = geneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_RIGHT_WING);
		if (!domRecPropertyStatus)
		{
			flag4 = false;
			flag5 = false;
		}
		if (wingType != WingType.NO_WINGS)
		{
			if ((flag4 && !flag5) || (flag5 && !flag4))
			{
				if (GoalsController.GetCounterForCondition(GoalCondition.ONE_WING) == 0)
				{
					GoalsController.SetGoalEvent(GoalCondition.ONE_WING, 1);
				}
			}
			else if (!flag4 && !flag5 && GoalsController.GetCounterForCondition(GoalCondition.WINGS) == 0)
			{
				GoalsController.SetGoalEvent(GoalCondition.WINGS, 1);
			}
		}
		yield return new WaitForSeconds(1f);
		guiRef.EnableBG(LockReason.EGG_HATCH);
		Object.Instantiate(dogNamingPopup).GetComponent<DogNameInput>().SetDogRef(dogID);
		GoalsController.ReportGoalEvent(GoalCondition.HATCH_EGG);
		geneRef.CheckGeneticGoals();
		currentlyIncubatedEgg = null;
	}
}
