using System.Collections.Generic;
using UnityEngine;

public class TreeController : PlantController
{
	public List<GameObject> branchPrefabs = new List<GameObject>();

	public float branchDist = 2f;

	public float branchRotDiff = 45f;

	public int initialBranchNum = 4;

	public float branchesPerMeter = 4f;

	public float branchGrowthAmount = 0.001f;

	public float foliageGrowthAmount = 0.02f;

	public Vector3 startingBranchScale = new Vector3(1f, 1f, 1f);

	public int maxBranchGrowth = 20;

	private int currentBranchGrowth;

	public InventoryItem fruitItem;

	public float fruitSpawnTimer = 30f;

	public float fruitChance = 0.5f;

	public float fallChance = 0.25f;

	private float currentFruitTimer;

	private List<GameObject> currentFruit = new List<GameObject>();

	private float randomNoBranchChance = 0.1f;

	private Transform branchHolder;

	private Vector3 startingBranchPos;

	private int branchCount;

	private List<Branch> branchList = new List<Branch>();

	private List<Vector3> branchScale = new List<Vector3>();

	private Rigidbody treeRB;

	protected override void AwakeBehavior()
	{
		base.AwakeBehavior();
		treeRB = finalPlant.GetComponentInChildren<Rigidbody>();
		branchHolder = new GameObject("Branch Holder").transform;
		branchHolder.parent = finalPlant.transform;
		currentFruitTimer = fruitSpawnTimer;
	}

	protected override void FinalStageConfirmation(bool fromLoad = false)
	{
		base.FinalStageConfirmation();
		startingBranchPos = treeRB.transform.position;
		if (!fromLoad)
		{
			for (int i = 0; i < initialBranchNum; i++)
			{
				TryGrowBranch();
			}
		}
	}

	protected override void FinalGrow()
	{
		base.FinalGrow();
		currentGrowTimer -= Time.deltaTime * debugTimeMultiplier;
		if (currentGrowTimer <= 0f)
		{
			TryGrow();
			currentGrowTimer = Random.Range(moundGrowthTimeLow, moundGrowthTimeHigh);
		}
		TickFruit();
	}

	protected float GetTreeHeight()
	{
		return treeBox.GetBoxSize().y * 2f;
	}

	private void TryGrow()
	{
		float treeHeight = GetTreeHeight();
		if (startingBranchPos.y + (finalPlant.transform.up * ((float)branchCount * branchDist)).y < (treeHeight * finalPlant.transform.up).y + finalPlant.transform.position.y)
		{
			TryGrowBranch();
		}
		else if (treeHeight < branchesPerMeter * (float)branchList.Count)
		{
			TryGrowTrunk();
		}
		TryScaleBranches();
	}

	private void TryScaleBranches()
	{
		Vector3 vector = Vector3.one * foliageGrowthAmount;
		for (int i = 0; i < branchScale.Count; i++)
		{
			if (branchList[i].foliage.transform.localScale.x < branchScale[i].x)
			{
				branchList[i].foliage.transform.localScale += vector;
				BoundingBoxComponent component = branchList[i].GetComponent<BoundingBoxComponent>();
				component.ForceUpdateBoundingBox();
				if (component.CheckGlobalIntersect(allowDogIntersection: true))
				{
					branchList[i].foliage.transform.localScale -= vector;
					break;
				}
			}
		}
		if ((float)currentBranchGrowth >= (float)maxBranchGrowth * GetTreeHeight())
		{
			return;
		}
		for (int j = 0; j < branchList.Count; j++)
		{
			if (!(branchList[j].foliage == null) && (j >= branchList.Count - 1 || !(branchList[j + 1].foliage != null) || !(branchScale[j].x - branchScale[j + 1].x > foliageGrowthAmount * 2f)))
			{
				branchScale[j] += vector;
				branchList[j].foliage.transform.localScale += vector;
				BoundingBoxComponent component2 = branchList[j].GetComponent<BoundingBoxComponent>();
				component2.ForceUpdateBoundingBox();
				if (component2.CheckGlobalIntersect(allowDogIntersection: true))
				{
					branchScale[j] -= vector;
					branchList[j].foliage.transform.localScale -= vector;
					break;
				}
				currentBranchGrowth++;
			}
		}
	}

	private void TryGrowTrunk()
	{
		Transform parent = branchHolder.transform.parent;
		branchHolder.transform.SetParent(null);
		Vector3 vector = new Vector3(0f, sproutAmount, 0f);
		finalPlant.transform.localScale += vector;
		Vector3 localPosition = finalPlant.transform.localPosition;
		finalPlant.transform.localPosition = sproutStages[0].transform.localPosition;
		treeBox.ForceUpdateBoundingBox();
		finalPlant.transform.localPosition = localPosition;
		finalPlant.transform.localScale -= vector;
		branchHolder.SetParent(parent);
		if (!DoesPlantIntersect(treeBox, 0f))
		{
			branchHolder.SetParent(null);
			finalPlant.transform.localScale += vector;
			branchHolder.SetParent(parent);
		}
	}

	private void TryGrowBranch()
	{
		if (Random.value <= randomNoBranchChance)
		{
			branchCount++;
			return;
		}
		Vector3 vector = finalPlant.transform.up * ((float)branchCount * branchDist);
		int num = Random.Range(0, branchPrefabs.Count - 1);
		GameObject gameObject = Object.Instantiate(branchPrefabs[num]);
		gameObject.transform.parent = treeRB.transform;
		gameObject.transform.position = startingBranchPos + vector;
		gameObject.transform.parent = branchHolder;
		gameObject.transform.localScale = startingBranchScale;
		gameObject.transform.localRotation = Quaternion.Euler(0f, (float)branchCount * branchRotDiff, 0f);
		branchCount++;
		if (gameObject.AddComponent<BoundingBoxComponent>().CheckGlobalIntersect(allowDogIntersection: true))
		{
			Object.Destroy(gameObject);
			return;
		}
		Branch component = gameObject.GetComponent<Branch>();
		component.prefabIndex = num;
		UpdateBranchCollisions(gameObject);
		branchList.Add(component);
		branchScale.Add(component.transform.localScale);
	}

	private void UpdateBranchCollisions(GameObject newObj, bool ignore = true)
	{
		Collider component = treeRB.GetComponent<Collider>();
		Collider[] componentsInChildren = newObj.transform.GetComponentsInChildren<Collider>();
		foreach (Collider collider in componentsInChildren)
		{
			Physics.IgnoreCollision(collider, component, ignore);
			for (int j = 0; j < branchList.Count; j++)
			{
				if (!branchList[j].gameObject.activeSelf)
				{
					continue;
				}
				Collider[] componentsInChildren2 = branchList[j].transform.GetComponentsInChildren<Collider>();
				foreach (Collider collider2 in componentsInChildren2)
				{
					if (collider != collider2)
					{
						Physics.IgnoreCollision(collider, collider2, ignore);
					}
				}
			}
		}
	}

	private void TickFruit()
	{
		if (fruitItem == null)
		{
			return;
		}
		for (int num = currentFruit.Count - 1; num >= 0; num--)
		{
			if (currentFruit[num] == null)
			{
				currentFruit.RemoveAt(num);
			}
			else
			{
				Joint component = currentFruit[num].GetComponent<Joint>();
				if (component.connectedBody == null || component.connectedBody.transform.localScale.x == 0f)
				{
					DropFruit(currentFruit[num]);
				}
			}
		}
		currentFruitTimer -= Time.deltaTime;
		if (currentFruitTimer <= 0f)
		{
			TrySpawnFruit();
		}
	}

	private void TrySpawnFruit()
	{
		for (int num = currentFruit.Count - 1; num >= 0; num--)
		{
			if (currentFruit[num] == null)
			{
				currentFruit.RemoveAt(num);
			}
		}
		currentFruitTimer = fruitSpawnTimer;
		if (currentFruit.Count < branchList.Count && !(Random.value > fruitChance))
		{
			GameObject gameObject = Object.Instantiate(fruitItem.itemPrefab);
			currentFruit.Add(gameObject);
			Branch randomElement = ListUtil.GetRandomElement(branchList);
			Collider component = randomElement.foliage.GetComponent<Collider>();
			gameObject.transform.position = randomElement.foliage.transform.position + component.bounds.extents.x * new Vector3(Random.value, Random.value, Random.value);
			ObjectRegistration.GetRegistrationScript().AssignID(gameObject, fruitItem);
			gameObject.AddComponent<FixedJoint>();
			UpdateBranchCollisions(gameObject);
		}
	}

	public override void OnBreak()
	{
		base.OnBreak();
		for (int i = 0; i < currentFruit.Count; i++)
		{
			Object.Destroy(currentFruit[i].GetComponent<FixedJoint>());
			ClearIgnoredCollisions(currentFruit[i]);
		}
	}

	public override void OnAttackedByDog()
	{
		base.OnAttackedByDog();
		if (currentFruit.Count > 0 && !(Random.value > fallChance))
		{
			GameObject randomElement = ListUtil.GetRandomElement(currentFruit);
			DropFruit(randomElement);
		}
	}

	private void DropFruit(GameObject fruit)
	{
		currentFruit.Remove(fruit);
		Object.Destroy(fruit.GetComponent<FixedJoint>());
		ClearIgnoredCollisions(fruit);
	}

	private void ClearIgnoredCollisions(GameObject obj)
	{
		UpdateBranchCollisions(obj, ignore: false);
	}
}
