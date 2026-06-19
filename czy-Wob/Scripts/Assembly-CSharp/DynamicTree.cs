using System.Collections.Generic;
using UnityEngine;

public class DynamicTree : MonoBehaviour
{
	public Transform foliageTransform;

	public List<Transform> trunkBones;

	public List<float> boneScaleMod;

	public List<float> foliageScaleMod;

	public float trunkFoliageScaleMod;

	public List<Transform> allTrunkBones = new List<Transform>();

	public List<GameObject> trunkColliders = new List<GameObject>();

	public GameObject branchPrefab;

	public GameObject foliagePrefab;

	public Transform trunkScaler;

	private float treeTrunkExtensionMin;

	private float treeTrunkExtensionMax = 1.5f;

	private float treeBranchExtensionMin;

	private float treeBranchExtensionMax = 0.75f;

	private float treeTrunkRotationMax = 10f;

	private float treeBranchRotationMax = 35f;

	private Vector3 awakeScale = Vector3.zero;

	private Vector3 startingTrunkScale = new Vector3(0.1f, 0.1f, 0.1f);

	private Vector3 maximumTrunkScale = new Vector3(1.1f, 1.1f, 1.1f);

	private List<float> startingTrunkColliderScales = new List<float>();

	private List<float> finalTrunkGrowth = new List<float>();

	private List<Vector3> finalTrunkRotation = new List<Vector3>();

	private List<float> currentTrunkGrowth = new List<float>();

	private List<Vector3> currentTrunkRotation = new List<Vector3>();

	private List<TreeBranch> branches = new List<TreeBranch>();

	private List<GameObject> foliage = new List<GameObject>();

	private List<float> maximumFoliageScale = new List<float>();

	private float totalGrowthTime;

	private float growTimeMultiplier = 1f;

	private float defaultGrowTimeMultiplier = 1f;

	private float rotSpeed = 0.0075f;

	private float scaleSpeed = 0.00025f;

	private float positionSpeed = 0.00025f;

	private float foliageScaleSpeed = 0.00025f;

	private bool doneGrowing;

	private void Awake()
	{
		awakeScale = trunkScaler.transform.localScale;
		GenerateBranches();
		GameObject gameObject = Object.Instantiate(foliagePrefab);
		gameObject.transform.SetParent(foliageTransform);
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localScale = Vector3.zero;
		foliage.Insert(0, gameObject);
		maximumFoliageScale.Insert(0, trunkFoliageScaleMod);
		GenerateBoneJiggle(trunkBones, treeTrunkExtensionMin, treeTrunkExtensionMax, treeTrunkRotationMax, finalTrunkRotation, finalTrunkGrowth, currentTrunkRotation, currentTrunkGrowth);
		trunkScaler.transform.localScale = startingTrunkScale;
		StoreTrunkColliderScales();
	}

	public void SaveTree(SaveableTree tree)
	{
		tree.finalTrunkGrowth.Clear();
		tree.finalTrunkGrowth.AddRange(finalTrunkGrowth);
		tree.finalTrunkRotation.Clear();
		for (int i = 0; i < finalTrunkRotation.Count; i++)
		{
			tree.finalTrunkRotation.Add(new SerializableVector3(finalTrunkRotation[i]));
		}
		tree.currentTrunkGrowth.Clear();
		tree.currentTrunkGrowth.AddRange(currentTrunkGrowth);
		tree.currentTrunkRotation.Clear();
		for (int j = 0; j < currentTrunkRotation.Count; j++)
		{
			tree.currentTrunkRotation.Add(new SerializableVector3(currentTrunkRotation[j]));
		}
		tree.currentTrunkPositions.Clear();
		tree.currentTrunkRotations.Clear();
		for (int k = 0; k < trunkBones.Count; k++)
		{
			tree.currentTrunkPositions.Add(new SerializableVector3(trunkBones[k].localPosition));
			tree.currentTrunkRotations.Add(new SerializableQuaternion(trunkBones[k].localRotation));
		}
		tree.branches.Clear();
		for (int l = 0; l < branches.Count; l++)
		{
			tree.branches.Add(new SaveableBranch(branches[l], foliage[l + 1].GetComponent<LeafSpawner>()));
		}
		tree.foliageIndex = foliage[0].GetComponent<LeafSpawner>().GetCluster();
		tree.currentFoliageScale = new SerializableVector3(foliage[0].transform.localScale);
		tree.currentTrunkScale = trunkScaler.transform.localScale.x;
		tree.doneGrowing = doneGrowing;
		tree.totalGrowthTime = totalGrowthTime;
		tree.awakeScale = new SerializableVector3(awakeScale);
	}

	public void LoadTree(SaveableTree tree)
	{
		trunkScaler.transform.localScale = tree.awakeScale.Load();
		finalTrunkGrowth.Clear();
		finalTrunkGrowth.AddRange(tree.finalTrunkGrowth);
		finalTrunkRotation.Clear();
		for (int i = 0; i < tree.finalTrunkRotation.Count; i++)
		{
			finalTrunkRotation.Add(tree.finalTrunkRotation[i].Load());
		}
		currentTrunkGrowth.Clear();
		currentTrunkRotation.Clear();
		currentTrunkGrowth.AddRange(tree.currentTrunkGrowth);
		for (int j = 0; j < tree.currentTrunkRotation.Count; j++)
		{
			Vector3 item = tree.currentTrunkRotation[j].Load();
			currentTrunkRotation.Add(item);
		}
		for (int k = 0; k < trunkBones.Count; k++)
		{
			trunkBones[k].localPosition = tree.currentTrunkPositions[k].Load();
			trunkBones[k].localRotation = tree.currentTrunkRotations[k].Load();
		}
		for (int num = branches.Count - 1; num >= 0; num--)
		{
			branches[num].Cleanup();
			Object.Destroy(branches[num].gameObject);
		}
		for (int num2 = foliage.Count - 1; num2 >= 0; num2--)
		{
			Object.Destroy(foliage[num2]);
		}
		foliage.Clear();
		branches.Clear();
		GameObject gameObject = Object.Instantiate(foliagePrefab);
		gameObject.transform.SetParent(foliageTransform);
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localScale = Vector3.zero;
		foliage.Insert(0, gameObject);
		maximumFoliageScale.Insert(0, trunkFoliageScaleMod);
		gameObject.GetComponent<LeafSpawner>().SetCluster(tree.foliageIndex);
		for (int l = 0; l < tree.branches.Count; l++)
		{
			CreateBranch(tree.branches[l].trunkBoneIndex);
		}
		trunkScaler.transform.localScale = Vector3.one * tree.currentTrunkScale;
		for (int m = 0; m < tree.branches.Count; m++)
		{
			tree.branches[m].Load(branches[m], foliage[m + 1].GetComponent<LeafSpawner>());
		}
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = tree.currentFoliageScale.Load();
		totalGrowthTime = 0f;
		doneGrowing = tree.doneGrowing;
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.S) && !CheatEngine.cheatRef.publicBuild)
		{
			growTimeMultiplier = 1000f;
		}
		else
		{
			growTimeMultiplier = defaultGrowTimeMultiplier;
		}
		Grow(Time.deltaTime * growTimeMultiplier);
	}

	private void Grow(float deltaTime)
	{
		if (doneGrowing)
		{
			return;
		}
		totalGrowthTime += deltaTime;
		bool flag = false;
		if (trunkScaler.localScale.x < maximumTrunkScale.x)
		{
			flag = true;
			trunkScaler.transform.localScale += Vector3.one * scaleSpeed * deltaTime;
		}
		for (int i = 0; i < trunkBones.Count; i++)
		{
			if (!(currentTrunkGrowth[i] >= finalTrunkGrowth[i]))
			{
				flag = true;
				float num = positionSpeed * deltaTime;
				currentTrunkGrowth[i] += num;
				trunkBones[i].position += num * Vector3.up;
			}
		}
		for (int j = 0; j < trunkBones.Count; j++)
		{
			Vector3 value = currentTrunkRotation[j];
			float num2 = rotSpeed * deltaTime;
			Vector3 zero = Vector3.zero;
			if (value.x < Mathf.Abs(finalTrunkRotation[j].x))
			{
				flag = true;
				zero.x = num2;
				value.x += num2;
				if (finalTrunkRotation[j].x < 0f)
				{
					zero.x *= -1f;
				}
			}
			if (value.y < Mathf.Abs(finalTrunkRotation[j].y))
			{
				flag = true;
				zero.y = num2;
				value.y += num2;
				if (finalTrunkRotation[j].y < 0f)
				{
					zero.y *= -1f;
				}
			}
			if (value.z < Mathf.Abs(finalTrunkRotation[j].z))
			{
				flag = true;
				zero.z = num2;
				value.z += num2;
				if (finalTrunkRotation[j].z < 0f)
				{
					zero.z *= -1f;
				}
			}
			trunkBones[j].Rotate(zero);
			currentTrunkRotation[j] = value;
		}
		for (int k = 0; k < branches.Count; k++)
		{
			for (int l = 1; l < branches[k].branchBones.Count; l++)
			{
				if (!(branches[k].currentBranchGrowth[l] >= branches[k].finalBranchGrowth[l]))
				{
					flag = true;
					float num3 = branches[k].finalBranchGrowth[l] * positionSpeed * deltaTime;
					branches[k].currentBranchGrowth[l] += num3;
					branches[k].branchBones[l].position += num3 * Vector3.up;
				}
			}
			for (int m = 0; m < branches[k].branchBones.Count; m++)
			{
				Vector3 value2 = branches[k].currentBranchRotation[m];
				float num4 = rotSpeed * deltaTime;
				Vector3 zero2 = Vector3.zero;
				if (value2.x < Mathf.Abs(branches[k].finalBranchRotation[m].x))
				{
					flag = true;
					zero2.x = num4;
					value2.x += num4;
					if (branches[k].finalBranchRotation[m].x < 0f)
					{
						zero2.x *= -1f;
					}
				}
				if (value2.y < Mathf.Abs(branches[k].finalBranchRotation[m].y))
				{
					flag = true;
					zero2.y = num4;
					value2.y += num4;
					if (branches[k].finalBranchRotation[m].y < 0f)
					{
						zero2.y *= -1f;
					}
				}
				if (value2.z < Mathf.Abs(branches[k].finalBranchRotation[m].z))
				{
					flag = true;
					zero2.z = num4;
					value2.z += num4;
					if (branches[k].finalBranchRotation[m].z < 0f)
					{
						zero2.z *= -1f;
					}
				}
				branches[k].branchBones[m].Rotate(zero2);
				branches[k].currentBranchRotation[m] = value2;
			}
		}
		for (int n = 0; n < foliage.Count; n++)
		{
			foliage[n].transform.rotation = Quaternion.identity;
			if (foliage[n].transform.localScale.x < maximumFoliageScale[n])
			{
				flag = true;
				foliage[n].transform.localScale += Vector3.one * foliageScaleSpeed * deltaTime;
			}
		}
		AdjustColliders();
		if (!flag)
		{
			doneGrowing = true;
		}
	}

	private void AdjustColliders()
	{
		for (int i = 0; i < allTrunkBones.Count - 1; i++)
		{
			Vector3 position = allTrunkBones[i].transform.position;
			Vector3 position2 = allTrunkBones[i + 1].transform.position;
			float z = Vector3.Distance(position, position2);
			Vector3 vector = position2 - position;
			trunkColliders[i].transform.localScale = new Vector3(trunkScaler.transform.localScale.x * startingTrunkColliderScales[i], trunkScaler.transform.localScale.z * startingTrunkColliderScales[i], z);
			trunkColliders[i].transform.position = position + vector / 2f;
			trunkColliders[i].transform.rotation = Quaternion.LookRotation(position2 - position, Vector3.forward);
		}
		for (int j = 0; j < branches.Count; j++)
		{
			for (int k = 0; k < branches[j].allBranchBones.Count - 1; k++)
			{
				Vector3 position3 = branches[j].allBranchBones[k].transform.position;
				Vector3 position4 = branches[j].allBranchBones[k + 1].transform.position;
				float z2 = Vector3.Distance(position3, position4);
				Vector3 vector2 = position4 - position3;
				branches[j].branchColliders[k].transform.localScale = new Vector3(trunkScaler.transform.localScale.x * branches[j].startingBranchColliderScales[k], trunkScaler.transform.localScale.z * branches[j].startingBranchColliderScales[k], z2);
				branches[j].branchColliders[k].transform.position = position3 + vector2 / 2f;
				branches[j].branchColliders[k].transform.rotation = Quaternion.LookRotation(position4 - position3, Vector3.forward);
			}
		}
	}

	private void StoreTrunkColliderScales()
	{
		startingTrunkColliderScales.Clear();
		for (int i = 0; i < trunkColliders.Count; i++)
		{
			startingTrunkColliderScales.Add(trunkColliders[i].transform.localScale.x);
		}
	}

	private void GenerateBranches()
	{
		foliage.Clear();
		for (int i = 0; i < trunkBones.Count - 1; i++)
		{
			if (!(Random.value < 0.05f))
			{
				CreateBranch(i);
			}
		}
	}

	private TreeBranch CreateBranch(int boneIndex)
	{
		TreeBranch component = Object.Instantiate(branchPrefab).GetComponent<TreeBranch>();
		component.trunkBoneIndex = boneIndex;
		component.transform.localScale *= boneScaleMod[boneIndex];
		GenerateBoneJiggle(component.branchBones, treeBranchExtensionMin * boneScaleMod[boneIndex], treeBranchExtensionMax * boneScaleMod[boneIndex], treeBranchRotationMax, component.finalBranchRotation, component.finalBranchGrowth, component.currentBranchRotation, component.currentBranchGrowth);
		component.transform.SetParent(trunkBones[boneIndex]);
		component.transform.localPosition = Vector3.zero;
		branches.Add(component);
		for (int i = 0; i < component.branchColliders.Count; i++)
		{
			component.branchColliders[i].transform.SetParent(trunkColliders[boneIndex].transform.parent);
			component.startingBranchColliderScales.Add(component.branchColliders[i].transform.localScale.x);
		}
		GameObject gameObject = Object.Instantiate(foliagePrefab);
		gameObject.transform.SetParent(component.foliageTransform);
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localScale = Vector3.zero;
		foliage.Add(gameObject);
		maximumFoliageScale.Add(foliageScaleMod[boneIndex]);
		return component;
	}

	private void GenerateBoneJiggle(List<Transform> boneList, float minHeightJiggle, float maxHeightJiggle, float rotationJiggle, List<Vector3> rotationAmount, List<float> growthAmount, List<Vector3> currentRotation, List<float> currentGrowth)
	{
		growthAmount.Clear();
		rotationAmount.Clear();
		currentGrowth.Clear();
		currentRotation.Clear();
		for (int i = 0; i < boneList.Count; i++)
		{
			currentGrowth.Add(0f);
			growthAmount.Add(Random.Range(minHeightJiggle, maxHeightJiggle));
		}
		for (int j = 0; j < boneList.Count; j++)
		{
			currentRotation.Add(Vector3.zero);
			rotationAmount.Add(new Vector3(Random.Range(0f - rotationJiggle, rotationJiggle), Random.Range(0f - rotationJiggle, rotationJiggle), Random.Range(0f - rotationJiggle, rotationJiggle)));
		}
	}
}
