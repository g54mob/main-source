using System.Collections;
using I2.Loc;
using UnityEngine;

public class DogEgg : MonoBehaviour
{
	public Rigidbody rb;

	public Renderer eggRenderer;

	public bool dud;

	public bool fertilized;

	public GameObject eggBreakParticles;

	public GameObject hatchDustParticles;

	public GameObject hatchConfettiParticles;

	public GameObject worldMessagePrefab;

	public Color saleTextColor = Color.green;

	private Vector3 messageOffset = new Vector3(0f, 1.5f, 0f);

	private SaveableDogEgg associatedSaveableEgg;

	private Vector3 hatchlingBodySizeMod;

	private Color finalBodyBaseColor;

	private Color finalBodyEmissionColor;

	private Color initialBodyBaseColor;

	private Color initialBodyEmissionColor;

	private bool isBroken;

	private LiquidInfo eggGoopInfo;

	private string eggBreakSound = "egg_break";

	private string eggCollectSound = "egg_collect";

	private string incubatorHatchSound = "incubator_hatch";

	private string incubatorSmokePuffSound = "incubator_smokePuff";

	private float incubationLevel;

	private float incubationMax = 30f;

	private MaterialPropertyBlock propertyBlock;

	private bool isHatching;

	private bool textureUpdate = true;

	private bool canBreak = true;

	private float currentTimer;

	private float autoCollectTimer = 10f;

	private float autoCollectionJiggle = 5f;

	private bool wasCollected;

	private PenFocus penFocusRef;

	private GUIManagerPens guiRef;

	private DogRegistration dogRegRef;

	private PlayerInventory inventoryRef;

	private DogPettingController pettingRef;

	private void Awake()
	{
		penFocusRef = Camera.main.GetComponent<PenFocus>();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		pettingRef = registrationScript.GetGlobalComponent<DogPettingController>(GlobalObject.DOG_PETTING_CONTROLLER);
		inventoryRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).playerInventory;
		eggGoopInfo = registrationScript.GetGlobalComponent<LiquidController>(GlobalObject.LIQUID_CONTROLLER).GetLiquidForType(LiquidType.BROKEN_EGG);
		propertyBlock = new MaterialPropertyBlock();
		currentTimer = Random.Range(0f - autoCollectionJiggle, 0f);
	}

	public void LoadSaveableFertilizedDogEgg(SaveableFertilizedDogEgg savedEgg)
	{
		fertilized = true;
		incubationLevel = savedEgg.incubationLevel;
		associatedSaveableEgg = savedEgg.savedEgg.GetCopy();
		SetEggTexture(savedEgg.finalBodyBaseColor.Load(), savedEgg.finalBodyEmissionColor.Load());
	}

	private void Update()
	{
		if (!dud && !isHatching)
		{
			if (fertilized)
			{
				CheckAutoHatch();
			}
			if (GameSettings.IsPassiveModeEnabled() && !fertilized && GameSettings.PassiveModeAutoEggCollect())
			{
				CheckAutoCollect();
			}
		}
	}

	public void SetUnbreakable()
	{
		canBreak = false;
	}

	public void CollectEgg(bool immediate = false)
	{
		if (dud)
		{
			Debug.LogError("This shouldn't have been possible");
		}
		else if (!wasCollected && !isHatching)
		{
			wasCollected = true;
			if (!immediate)
			{
				Vector3 position = base.transform.GetComponentInChildren<Rigidbody>().position;
				GameObject obj = Object.Instantiate(worldMessagePrefab, position + messageOffset, Quaternion.identity);
				obj.transform.localScale = Vector3.one;
				WorldMessage component = obj.GetComponent<WorldMessage>();
				component.SetFadeTime(0.75f);
				component.SetDisplayColor(saleTextColor);
				component.SetDisplayMessage(ScriptLocalization.GUI.GUI_MESSAGE_EGGCOLLECT);
				AudioController.Play(eggCollectSound, position);
			}
			if (fertilized)
			{
				SaveableDogEgg copy = associatedSaveableEgg.GetCopy();
				inventoryRef.AddEggToInventory(copy);
			}
			else
			{
				SaveableDogEgg egg = new SaveableDogEgg(new SaveableDogGene(), new SaveableDogProfile(""), fertilizedStatus: false, null, newEmptyGut: true);
				inventoryRef.AddEggToInventory(egg);
				TutorialController.ReportEggCollected();
			}
			GoalsController.ReportGoalEvent(GoalCondition.COLLECT_EGG);
			Object.Destroy(base.gameObject);
		}
	}

	public float GetIncubationLevel()
	{
		return incubationLevel;
	}

	public void SetIncubationLevel(float newVal)
	{
		incubationLevel = newVal;
		EaseTexture();
	}

	public Color GetFinalBodyBaseColor()
	{
		return finalBodyBaseColor;
	}

	public Color GetFinalBodyEmissionColor()
	{
		return finalBodyEmissionColor;
	}

	public void FreezeTextureEase()
	{
		textureUpdate = false;
	}

	public void RestoreTextureEase()
	{
		textureUpdate = true;
	}

	public void SetAssociatedSaveableEgg(SaveableDogEgg newEgg)
	{
		associatedSaveableEgg = newEgg;
	}

	public SaveableDogEgg GetAssociatedSaveableEgg()
	{
		return associatedSaveableEgg;
	}

	private void CheckAutoHatch()
	{
		Incubate();
	}

	private void CheckAutoCollect()
	{
		currentTimer += Time.deltaTime;
		if (currentTimer >= autoCollectTimer)
		{
			CollectEgg();
		}
	}

	public void Incubate()
	{
		if (isHatching)
		{
			return;
		}
		incubationLevel += Time.deltaTime;
		if (incubationLevel > incubationMax)
		{
			incubationLevel = incubationMax;
		}
		EaseTexture();
		if (!(incubationLevel >= incubationMax) || !GameSettings.IsPassiveModeEnabled() || !GameSettings.PassiveModeAutoEggHatch() || dogRegRef.IsCurrentlySpawningDogs() || dogRegRef.GetNumberOfOwnedAndLoadingDogsMinusGhosts() >= dogRegRef.GetMaxDogs())
		{
			return;
		}
		if (guiRef == null)
		{
			guiRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI, nullAllowed: true);
		}
		if (!wasCollected && guiRef != null && guiRef.GetGUIInteractiveStatus() && !dogRegRef.AnyDogHatching() && !pettingRef.InPettingMode() && !PauseController.IsPaused())
		{
			if (GameSettings.PassiveModeFocusOnHatchingEggs())
			{
				penFocusRef.AutoFocusOnRoomObjectIsInIfNeeded(base.gameObject);
			}
			StartCoroutine(EggHatchRoutine());
		}
	}

	public bool CanHatch()
	{
		if (!fertilized)
		{
			return false;
		}
		if (isHatching)
		{
			return false;
		}
		if (incubationLevel < incubationMax)
		{
			return false;
		}
		if (dogRegRef.GetNumberOfOwnedAndLoadingDogsMinusGhosts() >= dogRegRef.GetMaxDogs())
		{
			return false;
		}
		if (wasCollected)
		{
			return false;
		}
		return true;
	}

	public void HatchEgg()
	{
		if (CanHatch())
		{
			StartCoroutine(EggHatchRoutine());
		}
	}

	private IEnumerator EggHatchRoutine()
	{
		GetComponent<OOBDestroy>().SetDestroyFlag(flag: false);
		DenInteriorManager.ExpelObjectFromDen(base.gameObject);
		isHatching = true;
		if (guiRef == null)
		{
			guiRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI, nullAllowed: true);
		}
		guiRef.DisableBG(LockReason.EGG_HATCH, blur: false, pause: false);
		ObjectSpawnParticles component = Object.Instantiate(hatchDustParticles, rb.position, Quaternion.identity).GetComponent<ObjectSpawnParticles>();
		component.SetSpawnNewDog();
		component.SetSpawnCallback(OnNewDogCreated);
		AudioController.Play(incubatorSmokePuffSound, rb.position);
		if (associatedSaveableEgg != null)
		{
			if (associatedSaveableEgg.floraPool != null)
			{
				component.SetFloraPool(associatedSaveableEgg.floraPool);
			}
			if (associatedSaveableEgg.emptyGut)
			{
				component.SetEmptyGut(associatedSaveableEgg.emptyGut);
			}
			if (associatedSaveableEgg.associatedGene != null)
			{
				component.SetDogGene(associatedSaveableEgg.associatedGene);
			}
		}
		yield return new WaitForSeconds(0.15f);
		eggRenderer.enabled = false;
		rb.useGravity = false;
		rb.isKinematic = false;
		Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = false;
		}
		Object.Instantiate(hatchConfettiParticles, rb.position, Quaternion.identity);
	}

	private void OnNewDogCreated(GameObject newDog)
	{
		dogRegRef.StartCoroutine(OnNewDogCreatedRoutine(newDog));
		AudioController.Play(incubatorHatchSound, newDog.GetComponent<LegController>().bodyFront.transform);
		if (GameSettings.PassiveModeEggNotificationOption() == GameSettings.PassiveNotificationsOption.SMALL_NOTIF)
		{
			string gUI_POPUP_HATCH_SHORT = ScriptLocalization.GUI.GUI_POPUP_HATCH_SHORT;
			int length = gUI_POPUP_HATCH_SHORT.IndexOf("[");
			int num = gUI_POPUP_HATCH_SHORT.IndexOf("]");
			gUI_POPUP_HATCH_SHORT = gUI_POPUP_HATCH_SHORT.Substring(0, length) + dogRegRef.GetSaveableDogFromDog(newDog).dogName + gUI_POPUP_HATCH_SHORT.Substring(num + 1);
			guiRef.ShowPassiveModeNotification(ScriptLocalization.GUI.GUI_POPUP_HATCH_HEADER, gUI_POPUP_HATCH_SHORT, dogRegRef.GetDefaultThumbnailForDog(newDog));
		}
	}

	private IEnumerator OnNewDogCreatedRoutine(GameObject newDog)
	{
		newDog.GetComponent<DoggyBrain>().SetDogHatchedFromEgg(status: true);
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
		GoalsController.ReportGoalEvent(GoalCondition.HATCH_EGG);
		geneRef.CheckGeneticGoals();
		isHatching = false;
		if (base.gameObject != null)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void EaseTexture()
	{
		if (textureUpdate)
		{
			eggRenderer.GetPropertyBlock(propertyBlock);
			float easeInCircValue = Inchworm.GetEaseInCircValue(incubationLevel / incubationMax, 0f, -1f, 1f);
			propertyBlock.SetColor("_Color", Color.Lerp(initialBodyBaseColor, finalBodyBaseColor, easeInCircValue));
			propertyBlock.SetColor("_EmissionColor", Color.Lerp(initialBodyEmissionColor, finalBodyEmissionColor, incubationLevel / incubationMax));
			eggRenderer.SetPropertyBlock(propertyBlock);
			if (incubationLevel >= incubationMax)
			{
				FreezeTextureEase();
			}
		}
	}

	public void SetEggSize(Vector3 eggSizeMod)
	{
		hatchlingBodySizeMod = eggSizeMod;
		float num = (hatchlingBodySizeMod.x + hatchlingBodySizeMod.y) / 2f;
		float num2 = base.transform.localScale.x * num;
		base.transform.localScale = base.transform.localScale + new Vector3(num2, num2, num2);
	}

	public void SetEggTexture(Color bodyBaseColor, Color bodyEmissionColor)
	{
		initialBodyBaseColor = eggRenderer.materials[0].color;
		initialBodyEmissionColor = eggRenderer.materials[0].GetColor("_EmissionColor");
		finalBodyBaseColor = bodyBaseColor;
		finalBodyEmissionColor = bodyEmissionColor;
		eggRenderer.materials = new Material[1] { eggRenderer.materials[0] };
	}

	public void Break()
	{
		if (!isBroken && canBreak)
		{
			isBroken = true;
			CreateGoopPuddle();
			Vector3 boxCenter = GetComponent<BoundingBoxComponent>().GetBoxCenter();
			AudioController.Play(eggBreakSound, boxCenter);
			Object.Instantiate(eggBreakParticles, boxCenter, Quaternion.identity);
			Object.Destroy(base.gameObject);
		}
	}

	private void CreateGoopPuddle()
	{
		RaycastUtil.StageRaycast(GetComponent<BoundingBoxComponent>().GetBoxCenter(), Vector3.down, out var hitInfo, 50f);
		if (!(hitInfo.transform == null) && !(hitInfo.transform.root.gameObject.GetComponent<RoomBase>() == null))
		{
			Vector3 position = hitInfo.point + Vector3.up * 0.1f;
			GameObject obj = new GameObject("Egg Puddle Creator");
			obj.transform.position = position;
			Liquid liquid = obj.AddComponent<Liquid>();
			liquid.ApplyLiquid(eggGoopInfo);
			liquid.CreatePuddle();
			Object.Destroy(obj);
		}
	}
}
