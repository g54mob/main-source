using System.Collections.Generic;
using UnityEngine;

public class DogGut : MonoBehaviour
{
	public Transform gutFloraSpawnerTransform;

	public GutFloraResource dirtFloraRef;

	public GutFloraResource scaphFloraRef;

	public GutFloraResource bacillusVitusFloraRef;

	private bool floraUpdated;

	private float purgeChance = 0.66f;

	private float floraSizeJiggle = 0.1f;

	private int maximumGutFloraCount = 35;

	private List<GutFloraBase> existingGutFlora = new List<GutFloraBase>();

	private DogGutController controllerRef;

	private int maxDirtBeforeBarfing = 10;

	private float barfChance = 0.1f;

	private float bacillusVitusProductionTime = 120f;

	private float currentBacillusVitusProductionTimer;

	private float gutRadius = 5f;

	private DoggyBrain brainRef;

	private DogGutGUIManager guiRef;

	private FloraManager floraManagerRef;

	private DogGutsManager gutsManagerRef;

	private InventoryManager inventoryRef;

	private void Awake()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		floraManagerRef = registrationScript.GetGlobalComponent<FloraManager>(GlobalObject.FLORA_MANAGER);
		gutsManagerRef = registrationScript.GetGlobalComponent<DogGutsManager>(GlobalObject.DOG_GUT_MANAGER);
		inventoryRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
	}

	private void Update()
	{
		CheckEscapedFlora();
		CheckFloraProduction();
	}

	public void ManualFixedUpdate()
	{
		for (int i = 0; i < existingGutFlora.Count; i++)
		{
			existingGutFlora[i].ManualFixedUpdateMove();
		}
	}

	public DogGutsManager GetGutsManager()
	{
		return gutsManagerRef;
	}

	public void AssignController(DogGutController newRef)
	{
		controllerRef = newRef;
		brainRef = controllerRef.GetComponent<DoggyBrain>();
	}

	public void SetGUIRef(DogGutGUIManager newRef)
	{
		guiRef = newRef;
	}

	public void ClearGut()
	{
		for (int i = 0; i < existingGutFlora.Count; i++)
		{
			Object.Destroy(existingGutFlora[i].gameObject);
		}
		existingGutFlora.Clear();
		floraUpdated = true;
	}

	public void Purge(float purgeModifier = 1f)
	{
		for (int num = existingGutFlora.Count - 1; num >= 0; num--)
		{
			if (Random.value <= purgeChance * purgeModifier)
			{
				Object.Destroy(existingGutFlora[num].gameObject);
				existingGutFlora.RemoveAt(num);
			}
		}
		floraUpdated = true;
	}

	public int GetScaphCount()
	{
		int num = 0;
		for (int i = 0; i < existingGutFlora.Count; i++)
		{
			if (existingGutFlora[i].GetFloraType() == scaphFloraRef)
			{
				num++;
			}
		}
		return num;
	}

	public List<GutFloraResource> GetAllFloraTypes(bool boosted)
	{
		List<GutFloraResource> list = new List<GutFloraResource>();
		for (int i = 0; i < existingGutFlora.Count; i++)
		{
			if (existingGutFlora[i].IsBoosted() == boosted && !list.Contains(existingGutFlora[i].GetFloraType()))
			{
				list.Add(existingGutFlora[i].GetFloraType());
			}
		}
		return list;
	}

	public List<GutFloraBase> GetAllGutFlora()
	{
		return existingGutFlora;
	}

	public bool HasEatenTooMuchDirt()
	{
		int num = 0;
		for (int i = 0; i < existingGutFlora.Count; i++)
		{
			if (!(existingGutFlora[i].GetFloraType() == dirtFloraRef))
			{
				continue;
			}
			num++;
			if (num >= maxDirtBeforeBarfing)
			{
				if (Random.value <= barfChance)
				{
					return true;
				}
				return false;
			}
		}
		return false;
	}

	public void SpawnSavedGutFlora(SaveableGutFlora floraRef)
	{
		Vector3 value = Vector3.one;
		if (floraRef.localScale != null)
		{
			value = floraRef.localScale.Load();
		}
		SpawnNewGutFlora(gutsManagerRef.GetFloraForPath(floraRef.path), floraRef.localPosition.Load(), null, value, null, floraRef.boosted);
	}

	public bool FloraUpdated()
	{
		return floraUpdated;
	}

	public void OnFloraUpdateProcessedByGUI()
	{
		floraUpdated = false;
	}

	public void SpawnNewGutFlora(GutFloraResource floraType, Vector3? customPos = null, Vector3? absoluteCustomPos = null, Vector3? customScale = null, Eatable eatableRef = null, bool isBoosted = false)
	{
		if (!(floraType == null))
		{
			GameObject gameObject = Object.Instantiate(floraType.gutFloraPrefab, gutFloraSpawnerTransform.position, Quaternion.Euler(0f, 0f, Random.Range(0, 360)));
			gameObject.transform.SetParent(base.transform);
			if (customScale.HasValue)
			{
				gameObject.transform.localScale = customScale.Value;
			}
			else
			{
				float num = Random.Range(0f - floraSizeJiggle, floraSizeJiggle);
				gameObject.transform.localScale += gameObject.transform.localScale * num;
			}
			GutFloraBase component = gameObject.GetComponent<GutFloraBase>();
			if (customPos.HasValue)
			{
				component.rigidbodyRef.transform.localPosition = customPos.Value;
			}
			if (absoluteCustomPos.HasValue)
			{
				component.rigidbodyRef.transform.position = absoluteCustomPos.Value;
			}
			if (isBoosted)
			{
				component.Boost();
			}
			existingGutFlora.Add(component);
			component.SetOwningGut(this);
			component.SetFloraInfo(floraType);
			while (existingGutFlora.Count > maximumGutFloraCount)
			{
				int index = Random.Range(0, existingGutFlora.Count);
				DestroyExistingGutFlora(existingGutFlora[index]);
			}
			floraUpdated = true;
			string pathForFlora = gutsManagerRef.GetPathForFlora(floraType);
			if (eatableRef != null)
			{
				floraManagerRef.ReportFloraUnlock(pathForFlora, unlockStatus: true, controllerRef.gameObject, isBoosted);
				floraManagerRef.ReportFoodUnlock(pathForFlora, inventoryRef.GetPathForItem(eatableRef.GetComponent<ObjectID>().item), unlockStatus: true, fromConsumption: true);
			}
			else
			{
				floraManagerRef.ReportFloraUnlock(pathForFlora, unlockStatus: true);
			}
			if (guiRef != null)
			{
				guiRef.OnFloraSpawned();
			}
		}
	}

	public void DestroyExistingGutFlora(GutFloraBase flora)
	{
		if (flora == null)
		{
			return;
		}
		int num = -1;
		for (int i = 0; i < existingGutFlora.Count; i++)
		{
			if (existingGutFlora[i].gameObject == flora.gameObject)
			{
				num = i;
				break;
			}
		}
		flora.ManualDestroy();
		if (num != -1)
		{
			existingGutFlora.RemoveAt(num);
			floraUpdated = true;
			if (guiRef != null)
			{
				guiRef.OnFloraDestroyed();
			}
		}
	}

	private void CheckFloraProduction()
	{
		if (!(brainRef == null) && brainRef.GetCurrentDogAge() == DogAge.ANCIENT)
		{
			currentBacillusVitusProductionTimer += Time.deltaTime;
			if (currentBacillusVitusProductionTimer >= bacillusVitusProductionTime)
			{
				currentBacillusVitusProductionTimer = 0f;
				SpawnNewGutFlora(bacillusVitusFloraRef);
			}
		}
	}

	private void CheckEscapedFlora()
	{
		Vector2 vector = new Vector2(base.transform.position.x, base.transform.position.y);
		for (int i = 0; i < existingGutFlora.Count; i++)
		{
			if (Vector3.Distance(existingGutFlora[i].rigidbodyRef.position, vector) > gutRadius)
			{
				existingGutFlora[i].rigidbodyRef.transform.position = gutFloraSpawnerTransform.position;
			}
		}
	}
}
