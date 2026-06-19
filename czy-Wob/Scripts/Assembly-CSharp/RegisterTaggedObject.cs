using UnityEngine;

public class RegisterTaggedObject : MonoBehaviour
{
	public TagsEnum objectType;

	public bool placeableObject;

	public bool canSaveLoad = true;

	public InventoryItem spawnOnDestroy;

	public InventoryItem saveAsAlternativeItem;

	private bool safeDestroy;

	private bool safeDestroyFromTravel;

	private bool registered;

	private bool needsRegistration;

	private bool shuttingDown;

	private SceneTransition transitionRef;

	public void OnEnable()
	{
		if (!placeableObject)
		{
			needsRegistration = true;
		}
		transitionRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneTransition>(GlobalObject.SCENE_TRANSITION);
	}

	private void OnDestroy()
	{
		if (!placeableObject && !shuttingDown)
		{
			Unregister();
		}
	}

	private void LateUpdate()
	{
		if (needsRegistration && !placeableObject)
		{
			Register(auto: true);
		}
	}

	private void OnApplicationQuit()
	{
		shuttingDown = true;
	}

	public void SetSafeDestroy(bool fromTravel = false)
	{
		safeDestroy = true;
		if (fromTravel)
		{
			safeDestroyFromTravel = fromTravel;
		}
	}

	public void ManualRegister(bool playerOwned = true)
	{
		Register(auto: false, playerOwned);
	}

	private void Register(bool auto, bool playerOwned = true)
	{
		needsRegistration = false;
		if (!registered && !(objectType == TagsEnum.DOG && auto))
		{
			registered = true;
			if (playerOwned && !placeableObject)
			{
				ObjectRegistration.GetRegistrationScript().RegisterTaggedObject(base.gameObject, objectType);
			}
			else if (placeableObject)
			{
				ObjectRegistration.GetRegistrationScript().RegisterPlaceableObject(base.gameObject, objectType);
			}
			if (objectType == TagsEnum.DOG)
			{
				ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).RegisterDog(base.gameObject, playerOwned);
			}
			else if (objectType == TagsEnum.ALL)
			{
				Debug.LogError("Invalid tag type ALL for object registration.");
			}
			else if (base.gameObject.GetComponent<BoundingBoxComponent>() == null)
			{
				base.gameObject.AddComponent<BoundingBoxComponent>();
			}
		}
	}

	public void ManualUnregister()
	{
		Unregister();
	}

	private void Unregister()
	{
		registered = false;
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		if (registrationScript == null)
		{
			return;
		}
		bool flag = false;
		if (transitionRef != null && transitionRef.IsTransitioning())
		{
			flag = true;
		}
		if (objectType == TagsEnum.DOG)
		{
			DogRegistration globalComponent = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION, nullAllowed: true);
			if (globalComponent != null)
			{
				if (!safeDestroy && !flag)
				{
					globalComponent.SaveDog(base.gameObject, inWorld: false);
				}
				globalComponent.OnDogRemoved(base.gameObject, safeDestroyFromTravel);
			}
		}
		if (objectType == TagsEnum.COCOON)
		{
			DogRegistration globalComponent2 = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION, nullAllowed: true);
			if (globalComponent2 != null)
			{
				Cocoon component = GetComponent<Cocoon>();
				if (!component.HasHatched() && !component.HasRequestedHatchling())
				{
					ulong associatedDogID = component.GetAssociatedDogID();
					if (!safeDestroy && !flag)
					{
						SaveableDog saveableDogFromID = globalComponent2.GetSaveableDogFromID(associatedDogID);
						saveableDogFromID.inWorld = false;
						globalComponent2.UpdateSaveableDog(saveableDogFromID);
					}
					globalComponent2.OnCocoonRemoved(base.gameObject, associatedDogID);
				}
			}
		}
		if (!placeableObject)
		{
			registrationScript.UnregisterTaggedObject(base.gameObject, objectType);
			if (!safeDestroy && !flag)
			{
				ObjectID component2 = GetComponent<ObjectID>();
				InventoryManager globalComponent3 = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER, nullAllowed: true);
				if (globalComponent3 != null)
				{
					if (objectType == TagsEnum.DOG_CORE)
					{
						globalComponent3.playerInventory.AddDogCoreToInventory(new SaveableDogCore(GetComponent<DogCore>()));
					}
					else if (component2 != null && !base.gameObject.CompareTag(Tags.POOP) && !base.gameObject.CompareTag(Tags.DIRT_CLUMP) && !base.gameObject.CompareTag(Tags.SNOWBALL))
					{
						globalComponent3.playerInventory.AddObjectToIventory(component2.item);
					}
				}
			}
			if (spawnOnDestroy != null && !flag && !shuttingDown)
			{
				BoundingBoxComponent component3 = GetComponent<BoundingBoxComponent>();
				GameObject obj = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME).TrySpawnItem(spawnOnDestroy, component3.GetBoxCenter());
				DogCore component4 = obj.GetComponent<DogCore>();
				DogCore component5 = GetComponent<DogCore>();
				if (obj != null && component5 != null && component4 != null)
				{
					component4.TransferDogDataFromCore(component5);
				}
			}
		}
		else
		{
			registrationScript.UnregisterPlaceableObject(base.gameObject, objectType);
		}
	}
}
