using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EggPipe : Pipe
{
	public GameObject suckPrefab;

	private GameObject currentSuckEffect;

	private float distMax = 40f;

	private float forceMax = 50f;

	private float dogMod = 1f;

	private List<GameObject> eggList = new List<GameObject>();

	private Dictionary<GameObject, Material> eggMatDebugDict = new Dictionary<GameObject, Material>();

	private RaycastHit[] results = new RaycastHit[100];

	private float eggCheckTimer = 5f;

	private float lastEggCheckTime;

	private bool isSuckingEggs;

	private Vector3 suctionPoint;

	private bool debugVis = true;

	private ObjectRegistration objRegRef;

	private DogRegistration dogRegRef;

	protected override void OnStart()
	{
		base.OnStart();
		objRegRef = ObjectRegistration.GetRegistrationScript();
		dogRegRef = objRegRef.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		CheckSuckEggs();
		UpdateSuckEffect();
	}

	private void UpdateSuckEffect()
	{
		if (isSuckingEggs && currentSuckEffect == null)
		{
			currentSuckEffect = Object.Instantiate(suckPrefab, GetFirstSegmentEntranceCenter(), GetCorrectRotationForFirstSegment());
		}
		else if (!isSuckingEggs && currentSuckEffect != null)
		{
			Object.Destroy(currentSuckEffect);
			currentSuckEffect = null;
		}
	}

	private void CheckSuckEggs()
	{
		if (isSuckingEggs || lastEggCheckTime >= eggCheckTimer)
		{
			SuckEggs();
			lastEggCheckTime = 0f;
		}
		else
		{
			lastEggCheckTime += Time.deltaTime;
		}
	}

	private void SuckEggs()
	{
		bool flag = false;
		eggList.Clear();
		eggList.AddRange(objRegRef.GetAllObjectsForTag(TagsEnum.EGG));
		eggList.AddRange(dogRegRef.GetComponent<DogRegistration>().GetAllDogs());
		suctionPoint = GetFirstSegmentEntranceCenter();
		for (int i = 0; i < eggList.Count; i++)
		{
			bool flag2 = eggList[i].transform.root.CompareTag(Tags.EGG);
			Rigidbody rigidbody = ((!flag2) ? eggList[i].GetComponent<LegController>().bodyFront.GetComponent<Rigidbody>() : eggList[i].GetComponentInChildren<Rigidbody>());
			float num = Vector3.Distance(suctionPoint, rigidbody.position);
			if (num > distMax)
			{
				RestoreEggMat(eggList[i]);
				continue;
			}
			bool flag3 = false;
			int num2 = 0;
			Debug.LogError("Egg pipes need reimplementation!");
			for (int j = 0; j < num2; j++)
			{
				if (!results[j].transform.root.CompareTag(Tags.DOG) && !results[j].transform.root.CompareTag(Tags.EGG) && !(results[j].transform.root.gameObject == eggList[i]))
				{
					flag3 = true;
					break;
				}
			}
			if (flag3)
			{
				RestoreEggMat(eggList[i]);
				continue;
			}
			SetEggMat(eggList[i]);
			Vector3 vector = suctionPoint - rigidbody.position;
			float num3 = forceMax * (Mathf.Max(distMax - num, 0.1f) / distMax);
			if (!flag2)
			{
				num3 *= dogMod;
			}
			else
			{
				flag = true;
			}
			rigidbody.AddForce(vector * num3);
		}
		isSuckingEggs = flag;
	}

	private void SetEggMat(GameObject egg)
	{
		if (debugVis && egg.transform.root.CompareTag(Tags.EGG) && !eggMatDebugDict.ContainsKey(egg))
		{
			Renderer componentInChildren = egg.GetComponentInChildren<Renderer>();
			eggMatDebugDict[egg] = componentInChildren.material;
			Material material = new Material(componentInChildren.material);
			material.color = Color.blue;
			componentInChildren.material = material;
			egg.GetComponent<DogEgg>().FreezeTextureEase();
		}
	}

	private void RestoreEggMat(GameObject egg)
	{
		if (debugVis && egg.transform.root.CompareTag(Tags.EGG) && eggMatDebugDict.ContainsKey(egg))
		{
			egg.GetComponentInChildren<Renderer>().material = eggMatDebugDict[egg];
			eggMatDebugDict.Remove(egg);
			egg.GetComponent<DogEgg>().RestoreTextureEase();
		}
	}
}
