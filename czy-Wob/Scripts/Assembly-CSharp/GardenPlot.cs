using UnityEngine;

public class GardenPlot : MonoBehaviour
{
	public delegate void GardenPlotCallback();

	public Transform growSlot;

	public GrowStages growStages;

	public GameObject gardenSignGUI;

	public LineRenderer vineLine;

	public ConfigurableJoint growJoint;

	public GameObject gardenPlotIndicatorPrefab;

	public GameObject dirtParticles;

	public GameObject snapParticles;

	public GameObject finalSpawnParticles;

	private GardenPlotIndicator indicatorRef;

	private GardenPlotCallback currentFoodGrownCallback;

	private GardenPlotCallback currentFoodPlantedCallback;

	private GrowableObject growable;

	private GrowableObject previousGrowable;

	private GameObject grownObject;

	private Mulch mulch;

	private Mulch previousMulch;

	private int currentGrowStage;

	private float currentGrowTime;

	private GameObject currentGrowObject;

	private float growMultiplier = 1f;

	private bool indicatorEnabled = true;

	private bool hasRunStartBehavior;

	private float bounceTime = 0.35f;

	private Segment currentBounceSegment;

	private bool vineHasBroken;

	private JointDataStruct savedVineJointData;

	private Inchworm inchwormRef;

	private NavmeshHelper navmeshRef;

	private PlayerInventory inventoryRef;

	private ConstructionManager constructionRef;

	private void Start()
	{
		StartBehavior();
	}

	private void StartBehavior()
	{
		if (!hasRunStartBehavior)
		{
			hasRunStartBehavior = true;
			savedVineJointData = new JointDataStruct(growJoint);
			ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
			inchwormRef = registrationScript.GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
			navmeshRef = registrationScript.GetGlobalComponent<NavmeshHelper>(GlobalObject.NAVMESH_HELPER);
			constructionRef = registrationScript.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
			inventoryRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).playerInventory;
			CreateIndicator();
			SetGrowStage(0);
			HandleIndicatorVisibility();
		}
	}

	public void SaveObject(SaveablePlacedObject data)
	{
		data.intList.Add(currentGrowStage);
		data.floatList.Add(currentGrowTime);
		if (grownObject != null)
		{
			data.ulongList.Add(grownObject.GetComponent<ObjectID>().GetUID());
		}
		data.stringList.Add(inventoryRef.GetManagerRef().GetPathForGrowable(growable));
		data.stringList.Add(inventoryRef.GetManagerRef().GetPathForGrowable(previousGrowable));
	}

	public void LoadObject(SaveablePlacedObject data)
	{
		StartBehavior();
		InventoryManager managerRef = inventoryRef.GetManagerRef();
		if (data.stringList.Count > 0)
		{
			PlantNewGrowable(managerRef.GetGrowableForPath(data.stringList[0]), null);
		}
		if (data.stringList.Count > 1)
		{
			previousGrowable = managerRef.GetGrowableForPath(data.stringList[1]);
		}
		currentGrowTime = data.floatList[0];
		SetGrowStage(data.intList[0]);
		if (data.ulongList.Count > 0)
		{
			HideIndicator();
			vineLine.enabled = true;
			grownObject = ObjectRegistration.GetRegistrationScript().GetObjectForUID(data.ulongList[0]);
			AttachGrownObject();
		}
	}

	private void OnDestroy()
	{
		if (indicatorRef != null)
		{
			Object.Destroy(indicatorRef.gameObject);
			indicatorRef = null;
		}
	}

	private void OnEnable()
	{
		if (indicatorRef != null)
		{
			indicatorRef.gameObject.SetActive(value: true);
		}
		HandleIndicatorVisibility();
	}

	private void OnDisable()
	{
		if (indicatorRef != null)
		{
			indicatorRef.gameObject.SetActive(value: false);
		}
		HandleIndicatorVisibility();
	}

	private void Update()
	{
		HandleIndicatorVisibility();
		UpdateVine();
		if (growable == null)
		{
			if ((grownObject == null && currentGrowStage == 0) || growJoint == null)
			{
				ShowNoCropsIndicator();
			}
		}
		else if (currentGrowStage < growStages.stages.Count)
		{
			UpdateGrowTimer();
		}
	}

	public void SetFoodGrownCallback(GardenPlotCallback newCallback)
	{
		currentFoodGrownCallback = newCallback;
	}

	public void SetFoodPlantedCallback(GardenPlotCallback newCallback)
	{
		currentFoodPlantedCallback = newCallback;
	}

	private void HandleIndicatorVisibility()
	{
		if (!(indicatorRef == null))
		{
			if (constructionRef.IsInStandardMode())
			{
				EnableIndicator();
			}
			else
			{
				DisableIndicator();
			}
		}
	}

	private void HideVine()
	{
		vineLine.enabled = false;
		vineLine.positionCount = 0;
	}

	private void UpdateVine()
	{
		if (growJoint == null)
		{
			if (!vineHasBroken)
			{
				vineHasBroken = true;
				if (grownObject != null)
				{
					Object.Instantiate(snapParticles, grownObject.GetComponentInChildren<Rigidbody>().position, Quaternion.identity);
				}
			}
			HideVine();
		}
		else if (grownObject == null)
		{
			HideVine();
		}
		else
		{
			vineLine.positionCount = 2;
			vineLine.SetPosition(0, growJoint.transform.position);
			vineLine.SetPosition(1, growJoint.connectedBody.transform.position);
		}
	}

	public void OnClick()
	{
		if (currentGrowStage == growStages.stages.Count)
		{
			HarvestCrops();
		}
		else
		{
			ShowPlantGUI();
		}
	}

	public void ShowPlantGUI()
	{
		GardenSignGUIController component = Object.Instantiate(gardenSignGUI, Vector3.zero, Quaternion.identity).GetComponent<GardenSignGUIController>();
		component.SetPlotRef(this);
		if (previousGrowable != null)
		{
			component.UpdateGrowable(previousGrowable);
		}
	}

	public void HarvestCrops()
	{
		SetGrowStage(0);
		currentGrowTime = 0f;
		HideIndicator();
		ObjectSpawnParticles component = Object.Instantiate(finalSpawnParticles, growSlot.transform.position, Quaternion.identity).GetComponent<ObjectSpawnParticles>();
		component.SetContainedItem(growable.finalObject);
		component.SetSpawnCallback(OnFinalObjectSpawned);
	}

	private void OnFinalObjectSpawned(GameObject spawnedObject)
	{
		vineHasBroken = false;
		vineLine.enabled = true;
		grownObject = spawnedObject;
		grownObject.name = growable.finalObject.itemName;
		grownObject.transform.position = growSlot.transform.position;
		ObjectRegistration.GetRegistrationScript().AssignID(grownObject, growable.finalObject);
		AttachGrownObject();
		previousMulch = mulch;
		previousGrowable = growable;
		mulch = null;
		growable = null;
		if (currentFoodGrownCallback != null)
		{
			currentFoodGrownCallback();
			currentFoodGrownCallback = null;
		}
	}

	private void CreateNewGrowJoint()
	{
		growJoint = savedVineJointData.CreateJoint(autoConfigure: true);
	}

	private void AttachGrownObject()
	{
		if (growJoint == null)
		{
			CreateNewGrowJoint();
		}
		growJoint.connectedBody = grownObject.GetComponentInChildren<Rigidbody>();
		BoundingBoxComponent boundingBoxComponent = grownObject.GetComponent<BoundingBoxComponent>();
		if (boundingBoxComponent == null)
		{
			boundingBoxComponent = grownObject.AddComponent<BoundingBoxComponent>();
		}
		grownObject.transform.position += Vector3.up * boundingBoxComponent.GetBoxSize().y;
	}

	public void ClearPreviousMulch()
	{
		previousMulch = null;
	}

	public Mulch GetCurrentMulch()
	{
		return mulch;
	}

	public GrowableObject GetCurrentGrowable()
	{
		return growable;
	}

	public void PlantNewGrowable(GrowableObject newGrowable, Mulch newMulch)
	{
		currentGrowTime = 0f;
		mulch = newMulch;
		growable = newGrowable;
		SetGrowStage(0);
		HideIndicator();
		AddPlantTimeMulchEffect();
		if (currentFoodPlantedCallback != null)
		{
			currentFoodPlantedCallback();
			currentFoodPlantedCallback = null;
		}
	}

	private void AddPlantTimeMulchEffect()
	{
		if (mulch == null)
		{
			return;
		}
		for (int i = 0; i < mulch.effects.Count; i++)
		{
			switch (mulch.effects[i])
			{
			case MulchEffect.ONE_POINT_FIVE_SPEED:
				growMultiplier = 1.5f;
				break;
			case MulchEffect.DOUBLE_SPEED:
				growMultiplier = 2f;
				break;
			}
		}
	}

	private void AddPickTimeMulchEffect()
	{
		if (mulch == null)
		{
			return;
		}
		for (int i = 0; i < mulch.effects.Count; i++)
		{
			switch (mulch.effects[i])
			{
			case MulchEffect.ONE_POINT_FIVE_SPEED:
				growMultiplier = 1f;
				break;
			case MulchEffect.DOUBLE_SPEED:
				growMultiplier = 1f;
				break;
			case MulchEffect.BIG_CROPS:
				MonoBehaviour.print("Need BIG CROPS effect implementation.");
				break;
			}
		}
	}

	public void DisableIndicator()
	{
		indicatorEnabled = false;
		HideIndicator();
	}

	public void EnableIndicator()
	{
		indicatorEnabled = true;
	}

	private void HideIndicator()
	{
		indicatorRef.gameObject.SetActive(value: false);
	}

	private void ShowNoCropsIndicator()
	{
		if (indicatorEnabled && !indicatorRef.gameObject.activeSelf)
		{
			indicatorRef.SetDefaultOffset();
			indicatorRef.gameObject.SetActive(value: true);
			indicatorRef.SetFollowTransform(base.transform);
			if (previousGrowable != null)
			{
				PlantNewGrowable(previousGrowable, previousMulch);
			}
		}
	}

	private void CreateIndicator()
	{
		GameObject gameObject = Object.Instantiate(gardenPlotIndicatorPrefab);
		indicatorRef = gameObject.GetComponent<GardenPlotIndicator>();
		indicatorRef.SetGardenPlotRef(this);
		indicatorRef.SetFollowTransform(base.transform);
	}

	private void UpdateGrowTimer()
	{
		currentGrowTime += Time.deltaTime * growMultiplier;
		CheckGrowStageAdvance();
	}

	private void CheckGrowStageAdvance()
	{
		int num = GetCurrentGrowStage();
		if (num != currentGrowStage)
		{
			SetGrowStage(num);
		}
	}

	private int GetCurrentGrowStage()
	{
		float num = 1f / (float)growStages.stages.Count;
		float num2 = currentGrowTime / growable.growTime;
		for (int num3 = growStages.stages.Count; num3 >= 0; num3--)
		{
			if (num2 >= (float)num3 * num)
			{
				return num3;
			}
		}
		return 0;
	}

	private void SetGrowStage(int newStage)
	{
		currentGrowStage = newStage;
		if (currentGrowObject != null)
		{
			Object.Destroy(currentGrowObject);
		}
		if (currentGrowStage != 0)
		{
			if (currentBounceSegment != null)
			{
				inchwormRef.CancelAndFinishEase(ref currentBounceSegment);
				currentBounceSegment = null;
			}
			currentGrowObject = Object.Instantiate(growStages.stages[newStage - 1], growSlot);
			currentGrowObject.transform.localPosition = Vector3.zero;
			if (newStage == growStages.stages.Count)
			{
				HarvestCrops();
			}
			else
			{
				HideIndicator();
				currentGrowObject.transform.localScale = Vector3.zero;
				Object.Instantiate(dirtParticles, currentGrowObject.transform.position + Vector3.up * 1.25f, Quaternion.identity);
				currentBounceSegment = inchwormRef.RequestEaseToScale(currentGrowObject, Vector3.one, bounceTime, Inchworm.EaseStyle.ElasticOut, BounceCallback);
			}
			navmeshRef.Rebuild();
		}
	}

	private void BounceCallback()
	{
		currentBounceSegment = null;
	}
}
