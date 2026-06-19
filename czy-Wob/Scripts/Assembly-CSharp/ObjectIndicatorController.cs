using System.Collections;
using I2.Loc;
using UnityEngine;

public class ObjectIndicatorController : MonoBehaviour
{
	public GameObject objectIndicatorPrefab;

	private bool indicatorEnabled = true;

	private ObjectIndicatorPens currentIndicator;

	private ScreenSpaceBillboard tutorialArrowIndicator;

	private string lastLanguage;

	private Coroutine indicationRoutine;

	private void Start()
	{
		CreateIndicator();
	}

	private void OnDestroy()
	{
		StopIndicationRoutine();
		if (currentIndicator != null)
		{
			Object.Destroy(currentIndicator.transform.root.gameObject);
			currentIndicator = null;
		}
		if (tutorialArrowIndicator != null)
		{
			Object.Destroy(tutorialArrowIndicator.gameObject);
			tutorialArrowIndicator = null;
		}
	}

	public void OnMemorialEpitaphUpdated(string updatedEpitaph)
	{
		currentIndicator.UpdateDescription(updatedEpitaph);
	}

	public ObjectIndicatorPens GetIndicatorRef()
	{
		return currentIndicator;
	}

	public void EnableTutorialArrow(GameObject prefabObj)
	{
		if (!(tutorialArrowIndicator != null))
		{
			tutorialArrowIndicator = Object.Instantiate(prefabObj).GetComponent<ScreenSpaceBillboard>();
			tutorialArrowIndicator.transform.localScale = Vector3.one;
			tutorialArrowIndicator.transform.localPosition = Vector3.zero;
			tutorialArrowIndicator.GetComponentInChildren<Animator>().updateMode = AnimatorUpdateMode.Normal;
			Rigidbody componentInChildren = GetComponentInChildren<Rigidbody>();
			if (componentInChildren != null)
			{
				tutorialArrowIndicator.SetFollowTransform(componentInChildren.transform);
			}
			else
			{
				tutorialArrowIndicator.SetFollowTransform(base.transform);
			}
			if (indicatorEnabled)
			{
				tutorialArrowIndicator.gameObject.SetActive(value: false);
			}
		}
	}

	public void DisableTutorialArrow()
	{
		if (!(tutorialArrowIndicator == null))
		{
			Object.Destroy(tutorialArrowIndicator.gameObject);
			tutorialArrowIndicator = null;
		}
	}

	public void OnDenFinalized()
	{
		if (currentIndicator != null)
		{
			currentIndicator.OnDenFinalized();
		}
	}

	public void EnableIndicator()
	{
		if (!indicatorEnabled)
		{
			indicatorEnabled = true;
			if (currentIndicator != null)
			{
				currentIndicator.gameObject.SetActive(value: true);
				currentIndicator.UpdateBillboard();
			}
			if (tutorialArrowIndicator != null)
			{
				tutorialArrowIndicator.gameObject.SetActive(value: false);
			}
		}
	}

	public void DisableIndicator()
	{
		indicatorEnabled = false;
		if (currentIndicator != null)
		{
			currentIndicator.gameObject.SetActive(value: false);
		}
		if (tutorialArrowIndicator != null)
		{
			tutorialArrowIndicator.gameObject.SetActive(value: true);
		}
		StopIndicationRoutine();
	}

	private void StopIndicationRoutine()
	{
		if (indicationRoutine != null)
		{
			StopCoroutine(indicationRoutine);
			indicationRoutine = null;
		}
	}

	private IEnumerator IndicateObjectAfterWait()
	{
		yield return new WaitForSeconds(0.1f);
		if (currentIndicator != null)
		{
			currentIndicator.gameObject.SetActive(value: true);
			currentIndicator.UpdateBillboard();
		}
		indicationRoutine = null;
	}

	public bool GetIndicatorStatus()
	{
		return indicatorEnabled;
	}

	private void Update()
	{
		if (LocalizationManager.CurrentLanguage != lastLanguage)
		{
			OnLanguageUpdated();
		}
	}

	private void OnLanguageUpdated()
	{
		lastLanguage = LocalizationManager.CurrentLanguage;
		ObjectID component = GetComponent<ObjectID>();
		if (component != null && !base.gameObject.CompareTag(Tags.DOG))
		{
			string labelString = GetLabelString(component.item.type);
			currentIndicator.SetNameAndDescription(GetModifiedName(component.item.itemNameLocalized), GetModifiedDescription(component.item.itemDescriptionLocalized), labelString);
		}
		else if (base.gameObject.CompareTag(Tags.DOG_MEMORIAL))
		{
			PlacedObjectID component2 = GetComponent<PlacedObjectID>();
			RoomCustomizationObject customizationObjectForPath = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).GetCustomizationObjectForPath(component2.GetResourceString());
			DogMemorial component3 = base.gameObject.GetComponent<DogMemorial>();
			currentIndicator.SetNameAndDescription(customizationObjectForPath.GetName(), component3.epitaph, component3.dogName);
		}
		else if (base.gameObject.CompareTag(Tags.DOG_DEN))
		{
			currentIndicator.UpdateDogDenText();
		}
	}

	private void CreateIndicator()
	{
		lastLanguage = LocalizationManager.CurrentLanguage;
		if (objectIndicatorPrefab == null)
		{
			objectIndicatorPrefab = ObjectRegistration.GetRegistrationScript().objectIndicatorPrefab;
		}
		if (currentIndicator == null)
		{
			currentIndicator = Object.Instantiate(objectIndicatorPrefab).GetComponent<ObjectIndicatorPens>();
		}
		currentIndicator.SetNameAndDescription("Test Object", "Test Object Description");
		currentIndicator.transform.localScale = Vector3.one;
		currentIndicator.transform.localPosition = Vector3.zero;
		ScreenSpaceBillboard component = currentIndicator.GetComponent<ScreenSpaceBillboard>();
		Rigidbody componentInChildren = GetComponentInChildren<Rigidbody>();
		if (componentInChildren != null)
		{
			component.SetFollowTransform(componentInChildren.transform);
		}
		else
		{
			component.SetFollowTransform(base.transform);
		}
		ObjectID component2 = GetComponent<ObjectID>();
		PlacedObjectID component3 = GetComponent<PlacedObjectID>();
		if (component2 != null)
		{
			if (base.gameObject.CompareTag(Tags.DOG))
			{
				currentIndicator.SetIsDog();
			}
			else
			{
				string labelString = GetLabelString(component2.item.type);
				currentIndicator.SetNameAndDescription(GetModifiedName(component2.item.itemNameLocalized), GetModifiedDescription(component2.item.itemDescriptionLocalized), labelString);
			}
		}
		else if (base.gameObject.CompareTag(Tags.DOG_DEN))
		{
			currentIndicator.SetIsDogDen(base.gameObject.GetComponent<DogDen>());
			float num = base.gameObject.GetComponent<BoundingBoxComponent>().GetBoxSize(checkDisabledColliders: true).y;
			if (num == float.PositiveInfinity)
			{
				num = 0f;
			}
			component.worldspaceOffset = new Vector3(0f, num, 0f);
			currentIndicator.AddIndicatorAction(IndicatorAction.DEN_LOOK_INSIDE);
			currentIndicator.AddIndicatorAction(IndicatorAction.DEN_EXPEL);
			currentIndicator.AddIndicatorAction(IndicatorAction.DEN_EXPEL_OBJECTS);
			currentIndicator.AddIndicatorAction(IndicatorAction.UPGRADE_DEN);
		}
		else if (component3 != null)
		{
			currentIndicator.SetIsPlaceableObject();
		}
		if (base.gameObject.CompareTag(Tags.TOY))
		{
			currentIndicator.AddIndicatorAction(IndicatorAction.DESTROY);
			currentIndicator.AddIndicatorAction(IndicatorAction.PUT_AWAY);
		}
		else if (base.gameObject.CompareTag(Tags.GIFT))
		{
			currentIndicator.AddIndicatorAction(IndicatorAction.DESTROY);
			currentIndicator.AddIndicatorAction(IndicatorAction.PUT_AWAY);
			currentIndicator.AddIndicatorAction(IndicatorAction.GIFT_UNWRAP);
		}
		else if (base.gameObject.CompareTag(Tags.VACUUM))
		{
			currentIndicator.AddIndicatorAction(IndicatorAction.DESTROY);
			currentIndicator.AddIndicatorAction(IndicatorAction.PUT_AWAY);
		}
		else if (base.gameObject.CompareTag(Tags.DOG_CORE))
		{
			currentIndicator.AddIndicatorAction(IndicatorAction.DESTROY);
			currentIndicator.AddIndicatorAction(IndicatorAction.PUT_AWAY);
			currentIndicator.AddIndicatorAction(IndicatorAction.MEMORIALIZE);
			currentIndicator.AddIndicatorAction(IndicatorAction.CRACK_CORE);
		}
		else if (base.gameObject.CompareTag(Tags.DOG_MEMORIAL))
		{
			float num2 = base.gameObject.GetComponent<BoundingBoxComponent>().GetBoxSize(checkDisabledColliders: true).y;
			if (num2 == float.PositiveInfinity)
			{
				num2 = 0f;
			}
			component.worldspaceOffset = new Vector3(0f, num2, 0f);
			RoomCustomizationObject customizationObjectForPath = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).GetCustomizationObjectForPath(component3.GetResourceString());
			DogMemorial component4 = base.gameObject.GetComponent<DogMemorial>();
			currentIndicator.SetIsDogMemorial();
			currentIndicator.SetNameAndDescription(customizationObjectForPath.GetName(), component4.epitaph, component4.dogName);
			currentIndicator.AddIndicatorAction(IndicatorAction.VIEW_MEMORIAL);
			currentIndicator.AddIndicatorAction(IndicatorAction.REMOVE_CORE);
			currentIndicator.AddIndicatorAction(IndicatorAction.SUMMON_GHOST);
		}
		else if (base.gameObject.CompareTag(Tags.SEED_PACKET) || base.gameObject.CompareTag(Tags.DEN_UPGRADE))
		{
			currentIndicator.AddIndicatorAction(IndicatorAction.DESTROY);
			currentIndicator.AddIndicatorAction(IndicatorAction.COLLECT);
		}
		else if (base.gameObject.CompareTag(Tags.TV))
		{
			currentIndicator.AddIndicatorAction(IndicatorAction.TV_TURN_ON);
			currentIndicator.AddIndicatorAction(IndicatorAction.TV_TURN_OFF);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_TV_WATCH);
		}
		else if (base.gameObject.CompareTag(Tags.MUSIC_PLAYER))
		{
			currentIndicator.AddIndicatorAction(IndicatorAction.MUSIC_TURN_ON);
			currentIndicator.AddIndicatorAction(IndicatorAction.MUSIC_TURN_OFF);
		}
		else if (base.gameObject.CompareTag(Tags.FAN))
		{
			currentIndicator.AddIndicatorAction(IndicatorAction.FAN_TURN_ON);
			currentIndicator.AddIndicatorAction(IndicatorAction.FAN_TURN_OFF);
		}
		else if (base.gameObject.CompareTag(Tags.DOG_STACK))
		{
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_GRAB);
			currentIndicator.AddIndicatorAction(IndicatorAction.STACK_SPIN);
		}
		else if (base.gameObject.CompareTag(Tags.BOPPER))
		{
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_GRAB);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_BITE);
		}
		else if (base.gameObject.CompareTag(Tags.SNOWGLOBE))
		{
			currentIndicator.AddIndicatorAction(IndicatorAction.SHAKE_SNOWGLOBE);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_BITE);
		}
		else if (base.gameObject.CompareTag(Tags.SAMPLESTABLE))
		{
			currentIndicator.AddIndicatorAction(IndicatorAction.GET_SAMPLE);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_BITE);
		}
		else if (base.gameObject.CompareTag(Tags.PRICKLYPEAR))
		{
			currentIndicator.AddIndicatorAction(IndicatorAction.PICK_FRUIT);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_BITE);
		}
		else if (base.gameObject.CompareTag(Tags.EGG))
		{
			DogEgg component5 = base.gameObject.GetComponent<DogEgg>();
			if (!component5.dud)
			{
				currentIndicator.AddIndicatorAction(IndicatorAction.COLLECT);
				if (component5.fertilized)
				{
					currentIndicator.AddIndicatorAction(IndicatorAction.HATCH_EGG);
				}
			}
		}
		else if (base.gameObject.CompareTag(Tags.POOP))
		{
			currentIndicator.AddIndicatorAction(IndicatorAction.CLEAN_UP);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_EAT_POOP);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_GHOST_EAT);
		}
		else if (base.gameObject.CompareTag(Tags.DIRT_CLUMP) || base.gameObject.CompareTag(Tags.SNOWBALL))
		{
			currentIndicator.AddIndicatorAction(IndicatorAction.DESTROY);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_EAT_DIRT);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_GHOST_EAT);
		}
		else if (base.gameObject.CompareTag(Tags.HOLE))
		{
			currentIndicator.AddIndicatorAction(IndicatorAction.FILL_IN);
			currentIndicator.AddIndicatorAction(IndicatorAction.PLANT_SEED);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_DIG_UP);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_BURY_OBJECT);
		}
		else if (base.gameObject.CompareTag(Tags.FOOD))
		{
			currentIndicator.AddIndicatorAction(IndicatorAction.DESTROY);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_EAT);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_GHOST_EAT);
		}
		else if (base.gameObject.CompareTag(Tags.DOG))
		{
			currentIndicator.AddIndicatorAction(IndicatorAction.PUPATE_DOG);
			currentIndicator.AddIndicatorAction(IndicatorAction.PRAISE);
			currentIndicator.AddIndicatorAction(IndicatorAction.SCOLD);
			if (ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).GetSaveableDogFromDog(base.gameObject)
				.isGhost)
			{
				currentIndicator.AddIndicatorAction(IndicatorAction.BANISH_GHOST);
				currentIndicator.AddIndicatorAction(IndicatorAction.DOG_SELF_LEVITATE);
			}
			else
			{
				currentIndicator.AddIndicatorAction(IndicatorAction.STORE);
			}
			if (GetComponent<DogLooks>().GetWingType() != WingType.NO_WINGS)
			{
				currentIndicator.AddIndicatorAction(IndicatorAction.DOG_SELF_FLY);
			}
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_SELF_SIT);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_SELF_DROP);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_SELF_SPEAK);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_SELF_ROLLOVER);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_SELF_SLEEP);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_SELF_PLAY_DEAD);
		}
		else if (base.gameObject.CompareTag(Tags.CAPSULE))
		{
			currentIndicator.AddIndicatorAction(IndicatorAction.CAPSULE_OPEN);
		}
		if (!base.gameObject.CompareTag(Tags.DOG_DEN) && !base.gameObject.CompareTag(Tags.HOLE) && !base.gameObject.CompareTag(Tags.TV) && !base.gameObject.CompareTag(Tags.FAN) && !base.gameObject.CompareTag(Tags.DOG_STACK) && !base.gameObject.CompareTag(Tags.DOG_MEMORIAL) && !base.gameObject.CompareTag(Tags.BOPPER) && !base.gameObject.CompareTag(Tags.MUSIC_PLAYER) && !base.gameObject.CompareTag(Tags.SNOWGLOBE) && !base.gameObject.CompareTag(Tags.SAMPLESTABLE) && !base.gameObject.CompareTag(Tags.PRICKLYPEAR))
		{
			currentIndicator.AddIndicatorAction(IndicatorAction.EXPEL_FROM_DEN);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_OBJECT_LEVITATE);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_GRAB);
			currentIndicator.AddIndicatorAction(IndicatorAction.DOG_THROW);
		}
		currentIndicator.SetIndicatedObject(base.gameObject);
		DisableIndicator();
	}

	private string GetLabelString(ItemType objectType)
	{
		switch (objectType)
		{
		case ItemType.TOY:
			return ScriptLocalization.GUI.GUI_OBJINFO_TOY;
		case ItemType.FOOD:
			return ScriptLocalization.GUI.GUI_OBJINFO_EDIBLE;
		case ItemType.DOG_CORE:
			return base.gameObject.GetComponent<DogCore>().dogName;
		default:
			return "";
		}
	}

	private string GetReadableCoreQuality(CoreQuality quality)
	{
		switch (quality)
		{
		case CoreQuality.LOW:
			return ScriptLocalization.InventoryItems.INV_DOGCORE_LQ_NAME;
		case CoreQuality.STANDARD:
			return ScriptLocalization.InventoryItems.INV_DOGCORE_NAME;
		case CoreQuality.HIGH:
			return ScriptLocalization.InventoryItems.INV_DOGCORE_HQ_NAME;
		default:
			Debug.LogError("No quality found for: " + quality);
			return ScriptLocalization.InventoryItems.INV_DOGCORE_NAME;
		}
	}

	public static string GetReadableCrackedCoreQuality(CoreQuality quality)
	{
		switch (quality)
		{
		case CoreQuality.LOW:
			return ScriptLocalization.InventoryItems.INV_DOGCORECRACKED_LQ_NAME;
		case CoreQuality.STANDARD:
			return ScriptLocalization.InventoryItems.INV_DOGCORECRACKED_NAME;
		case CoreQuality.HIGH:
			return ScriptLocalization.InventoryItems.INV_DOGCORECRACKED_HQ_NAME;
		default:
			Debug.LogError("No quality found for: " + quality);
			return ScriptLocalization.InventoryItems.INV_DOGCORECRACKED_NAME;
		}
	}

	private string GetModifiedName(string baseName)
	{
		DogCore component = base.gameObject.GetComponent<DogCore>();
		CrackedDogCore component2 = base.gameObject.GetComponent<CrackedDogCore>();
		if (component != null && base.gameObject.GetComponent<Eatable>() == null)
		{
			return GetReadableCoreQuality(component.GetCoreQuality());
		}
		if (component2 != null)
		{
			return GetReadableCrackedCoreQuality(component2.GetCoreQuality());
		}
		if (base.gameObject.CompareTag(Tags.EGG) && base.gameObject.GetComponent<DogEgg>().fertilized)
		{
			return ScriptLocalization.InventoryItems.INV_EGGFERT_NAME;
		}
		return baseName;
	}

	private string GetModifiedDescription(string baseDesc)
	{
		if (base.gameObject.CompareTag(Tags.EGG) && base.gameObject.GetComponent<DogEgg>().fertilized)
		{
			return ScriptLocalization.InventoryItems.INV_EGGFERT_DESC;
		}
		return baseDesc;
	}
}
