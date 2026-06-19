using I2.Loc;
using UnityEngine;

public class DogMemorial : MonoBehaviour
{
	public string dogName;

	public SaveableDogGene dogGene;

	public DogAge dogAge;

	public DogLabelType labelType;

	public SaveableThumbSet thumbSet;

	public DeathReason dogDeathReason;

	public SaveableDogProfile dogProfile;

	public SaveableDogPersonality dogPersonality;

	public string epitaph;

	public GameObject memorialGUIPrefab;

	public InventoryItem dogCoreObjectRef;

	private bool moveCoreToInventory = true;

	private float zoomOrtho = 2.88f;

	private Quaternion dogRot = Quaternion.Euler(0f, -50f, -15f);

	private GhostManager ghostManagerRef;

	private GameObject thumbnailDog;

	private void Awake()
	{
		epitaph = ScriptLocalization.GUI.GUI_MEMORIAL_DEFAULTEP;
	}

	private void Start()
	{
		ghostManagerRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GhostManager>(GlobalObject.GHOST_MANAGER);
		ulong uID = GetComponent<PlacedObjectID>().GetUID();
		ghostManagerRef.RegisterNewMemorial(uID);
	}

	private void OnDestroy()
	{
		if (ghostManagerRef != null)
		{
			ulong uID = GetComponent<PlacedObjectID>().GetUID();
			ghostManagerRef.UnregisterMemorial(uID);
		}
	}

	public void Save(SaveablePlacedObject saveableObject)
	{
		saveableObject.stringList.Add(dogName);
		saveableObject.stringList.Add(epitaph);
		saveableObject.intList.Add((int)dogAge);
		saveableObject.intList.Add((int)dogDeathReason);
		saveableObject.intList.Add((int)labelType);
		saveableObject.geneA = dogGene;
		saveableObject.thumbSetA = thumbSet;
		saveableObject.profileA = dogProfile;
		saveableObject.personalityA = dogPersonality;
		saveableObject.floatList.Add(zoomOrtho);
		saveableObject.floatList.Add(dogRot.x);
		saveableObject.floatList.Add(dogRot.y);
		saveableObject.floatList.Add(dogRot.z);
		saveableObject.floatList.Add(dogRot.w);
	}

	public void Load(SaveablePlacedObject saveableObject)
	{
		dogName = saveableObject.stringList[0];
		epitaph = saveableObject.stringList[1];
		dogAge = (DogAge)saveableObject.intList[0];
		if (saveableObject.intList.Count > 1)
		{
			dogDeathReason = (DeathReason)saveableObject.intList[1];
		}
		if (saveableObject.intList.Count > 2)
		{
			labelType = (DogLabelType)saveableObject.intList[2];
		}
		dogGene = saveableObject.geneA.GetCopy();
		dogProfile = saveableObject.profileA.GetCopy();
		if (saveableObject.personalityA != null)
		{
			dogPersonality = saveableObject.personalityA.GetCopy();
		}
		else
		{
			dogPersonality = new SaveableDogPersonality(new DogPersonality(traitsAllowed: false));
		}
		if (saveableObject.thumbSetA != null)
		{
			thumbSet = saveableObject.thumbSetA.GetCopy();
		}
		else
		{
			thumbSet = null;
		}
		if (saveableObject.floatList.Count > 1)
		{
			zoomOrtho = saveableObject.floatList[0];
			dogRot = new Quaternion(saveableObject.floatList[1], saveableObject.floatList[2], saveableObject.floatList[3], saveableObject.floatList[4]);
		}
		MasterDogGene.MigrateSaveableDogGene(dogGene);
		if (thumbSet == null || thumbSet.defaultPortrait == null)
		{
			CacheThumbnail();
		}
	}

	public void SetDogInfo(DogCore dogCoreRef)
	{
		dogAge = dogCoreRef.dogAge;
		dogGene = dogCoreRef.dogGene;
		dogName = dogCoreRef.dogName;
		thumbSet = dogCoreRef.thumbSet;
		labelType = dogCoreRef.labelType;
		dogProfile = dogCoreRef.dogProfile;
		dogDeathReason = dogCoreRef.dogDeathReason;
		dogPersonality = dogCoreRef.dogPersonality;
	}

	public void SetMoveCoreToInventory(bool val)
	{
		moveCoreToInventory = val;
	}

	public void OnRemovedFromRoom()
	{
		if (moveCoreToInventory)
		{
			InventoryManager globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
			SaveableDogCore core = new SaveableDogCore(dogGene, dogName, dogAge, dogProfile, dogPersonality, dogDeathReason, labelType, thumbSet);
			globalComponent.playerInventory.AddDogCoreToInventory(core);
			moveCoreToInventory = false;
		}
	}

	public void RemoveCore(bool destroyCore = false)
	{
		DogHome globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		if (globalComponent == null)
		{
			Debug.LogError("No DogHome reference found.");
			return;
		}
		BoundingBoxComponent component = GetComponent<BoundingBoxComponent>();
		Vector3 boxCenter = component.GetBoxCenter();
		ulong? roomUID = component.GetRoomUID();
		if (!roomUID.HasValue)
		{
			Debug.LogError("No room found for memorial.");
			return;
		}
		moveCoreToInventory = false;
		RoomBase roomForUID = globalComponent.GetRoomForUID(roomUID.Value);
		ObjectPlacementManager.RemoveObjectManually(roomForUID.GetPlacedObjectInfoForObject(base.gameObject), roomForUID);
		if (!destroyCore)
		{
			SaveableDogCore core = new SaveableDogCore(dogGene, dogName, dogAge, dogProfile, dogPersonality, dogDeathReason, labelType, thumbSet);
			GameObject gameObject = globalComponent.TrySpawnItem(dogCoreObjectRef, boxCenter);
			if (gameObject == null)
			{
				Debug.LogError("Not able to find a valid position to spawn in a dog core. Moving to inventory.");
				ObjectRegistration.GetRegistrationScript().GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).playerInventory.AddDogCoreToInventory(core);
			}
			else
			{
				gameObject.GetComponent<DogCore>().LoadSaveableDogCore(core);
			}
		}
	}

	public void SummonGhost()
	{
		ghostManagerRef.SpawnGhost(GetComponent<PlacedObjectID>().GetUID());
	}

	public void DisplayMemorialGUI()
	{
		if (dogGene != null)
		{
			if (dogGene.dogGeneEncoded != null && dogGene.dogGeneEncoded.Length > 0)
			{
				dogGene.dogGene = MathUtil.GeneticDecode(dogGene.dogGeneEncoded);
				dogGene.dogGeneEncoded = "";
			}
			if (dogGene.domRecGeneEncoded != null && dogGene.domRecGeneEncoded.Length > 0)
			{
				string text = MathUtil.GeneticDecode(dogGene.domRecGeneEncoded);
				text = text.Replace('0', 'a');
				text = text.Replace('1', 'A');
				dogGene.domRecGene = text;
				dogGene.domRecGeneEncoded = "";
			}
		}
		Object.Instantiate(memorialGUIPrefab).GetComponent<DogMemorialGUIController>().SetInfo(this, epitaph, zoomOrtho, dogRot);
	}

	public void SetRotationInfo(float zoom, Quaternion rot)
	{
		dogRot = rot;
		zoomOrtho = zoom;
	}

	private void CacheThumbnail()
	{
		ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).RequestNewDog(new Vector3(1000f, 1000f, 1000f), Quaternion.identity, dogGene, null, manualDog: false, dogProfile: dogProfile, callback: OnThumbnailDogCreated, playerOwned: false, useBaseGeneWithoutMutation: false, timeslice: true, forceCacheThumbnails: false, dummyDog: false, customDogAge: dogAge, customDogAgeProgress: 0f);
	}

	private void OnThumbnailDogCreated(GameObject dog)
	{
		thumbnailDog = dog;
		Rigidbody[] componentsInChildren = thumbnailDog.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody obj in componentsInChildren)
		{
			obj.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
			obj.isKinematic = true;
		}
		DogRegistration globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		globalComponent.StartCoroutine(globalComponent.GenerateDogThumbnailFromDog(dog, 0uL, highQuality: false, OnThumbnailGenerated));
	}

	private void OnThumbnailGenerated(ThumbnailSet newSet)
	{
		if (thumbnailDog != null)
		{
			Object.Destroy(thumbnailDog);
			thumbnailDog = null;
		}
		thumbSet = new SaveableThumbSet(newSet);
	}
}
