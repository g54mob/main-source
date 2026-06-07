using System;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltGroup : ISavable
{
	[Serializable]
	public class ConveyorBeltGroupPart
	{
		[SerializeField]
		private ConveyorBelt belt;

		private float startTotalDistance;

		private float endTotalDistance;

		public ConveyorBelt Belt => belt;

		public float EndTotalDistance => endTotalDistance;

		public float StartTotalDistance => startTotalDistance;

		public ConveyorBeltGroupPart(ConveyorBelt belt, ConveyorBeltGroup beltGroup)
		{
			this.belt = belt;
			this.belt.CurrentBeltGroup = beltGroup;
		}

		public void UpdateTotalDistances(float startTotalDistance)
		{
			this.startTotalDistance = startTotalDistance;
			endTotalDistance = startTotalDistance + belt.GetBeltDistance();
		}
	}

	public Action<ConveyorBeltGroup> onBeltsModified;

	[Savable("id", false, false)]
	private string id;

	private List<ConveyorBeltGroupPart> beltParts;

	private List<ConveyorBelt> belts;

	[Savable("resources", false, true)]
	private List<Resource> resources;

	private bool isLoop;

	private Storage_ResourceData inputStorage;

	private Storage_ResourceData outputStorage;

	public string Id => id;

	public Storage_ResourceData InputStorage
	{
		get
		{
			return inputStorage;
		}
		set
		{
			inputStorage = value;
		}
	}

	public Storage_ResourceData OutputStorage
	{
		get
		{
			return outputStorage;
		}
		set
		{
			outputStorage = value;
		}
	}

	public List<Resource> Resources
	{
		get
		{
			return resources;
		}
		private set
		{
			resources = value;
		}
	}

	public bool IsLoop
	{
		get
		{
			return isLoop;
		}
		set
		{
			isLoop = value;
		}
	}

	public List<ConveyorBelt> Belts => belts;

	public float GroupDistance => beltParts[beltParts.Count - 1].EndTotalDistance;

	public event Action<ResourceData, int> onStoreResource;

	public ConveyorBeltGroup(List<ConveyorBelt> belts, List<Resource> resources)
	{
		beltParts = new List<ConveyorBeltGroupPart>();
		this.resources = new List<Resource>();
		this.belts = new List<ConveyorBelt>();
		AddBelts(belts, addAtBeginning: false);
		AddResources(resources, addAtBeginning: false, 0f, 0);
	}

	private void UpdateId()
	{
		if (beltParts.Count == 0)
		{
			id = "";
			return;
		}
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		if (beltParts.Count == 1)
		{
			zero = beltParts[0].Belt.transform.position;
			zero2 = zero + beltParts[0].Belt.transform.forward;
			id = "(1)";
		}
		else if (beltParts.Count == 2)
		{
			zero = beltParts[0].Belt.transform.position;
			zero2 = beltParts[1].Belt.transform.position;
			id = "(2)";
		}
		else
		{
			zero = beltParts[1].Belt.transform.position;
			zero2 = beltParts[beltParts.Count - 1].Belt.transform.position;
			id = "(N)";
		}
		id = id + zero.ToString() + zero2.ToString();
	}

	public void AddBelts(List<ConveyorBelt> beltsToAdd, bool addAtBeginning)
	{
		if (beltsToAdd == null)
		{
			return;
		}
		List<ConveyorBeltGroupPart> list = new List<ConveyorBeltGroupPart>();
		foreach (ConveyorBelt item in beltsToAdd)
		{
			list.Add(new ConveyorBeltGroupPart(item, this));
		}
		if (addAtBeginning)
		{
			beltParts.InsertRange(0, list);
			foreach (Resource resource in Resources)
			{
				resource.CurrentConveyorBeltIdx += beltsToAdd.Count;
			}
		}
		else
		{
			beltParts.AddRange(list);
		}
		RecalculateBeltDistances(addAtBeginning);
		UpdateBeltsList();
		UpdateId();
		onBeltsModified?.Invoke(this);
	}

	private void RemoveBelt(int beltIdx, bool removeResources, bool recalculateDistances, bool updateResourcesTraveledDistance)
	{
		if (removeResources)
		{
			List<Resource> resourcesOnBelt = GetResourcesOnBelt(Belts[beltIdx]);
			for (int num = resourcesOnBelt.Count - 1; num >= 0; num--)
			{
				UnityEngine.Object.Destroy(resourcesOnBelt[num]);
			}
		}
		beltParts[beltIdx].Belt.CurrentBeltGroup = null;
		beltParts.RemoveAt(beltIdx);
		if (beltParts.Count > 0)
		{
			if (recalculateDistances)
			{
				RecalculateBeltDistances(updateResourcesTraveledDistance);
			}
			UpdateId();
		}
		else
		{
			ConveyorBeltSystem.instance.RemoveConveyorBeltGroup(this);
		}
		UpdateBeltsList();
		onBeltsModified?.Invoke(this);
	}

	public void RemoveFirstBelt(bool removeResources, bool recalculateDistances)
	{
		RemoveBelt(0, removeResources, recalculateDistances, updateResourcesTraveledDistance: true);
		foreach (Resource resource in Resources)
		{
			resource.CurrentConveyorBeltIdx--;
		}
	}

	public void RemoveLastBelt(bool removeResources, bool recalculateDistances)
	{
		RemoveBelt(Belts.Count - 1, removeResources, recalculateDistances, updateResourcesTraveledDistance: false);
	}

	private void UpdateBeltsList()
	{
		belts.Clear();
		foreach (ConveyorBeltGroupPart beltPart in beltParts)
		{
			belts.Add(beltPart.Belt);
		}
	}

	public void AddResources(List<Resource> resourcesToAdd, bool addAtBeginning, float traveledDistanceToAdd, int conveyorBeltIdxToAdd)
	{
		if (resourcesToAdd == null)
		{
			return;
		}
		if (addAtBeginning)
		{
			Resources.AddRange(resourcesToAdd);
		}
		else
		{
			Resources.InsertRange(0, resourcesToAdd);
		}
		foreach (Resource item in resourcesToAdd)
		{
			item.TraveledDistance += traveledDistanceToAdd;
			item.CurrentConveyorBeltIdx += conveyorBeltIdxToAdd;
		}
	}

	public List<Resource> GetResourcesOnBelt(ConveyorBelt belt, bool removeFromBelt = true)
	{
		List<Resource> list = new List<Resource>();
		for (int num = Resources.Count - 1; num >= 0; num--)
		{
			if (Belts[Resources[num].CurrentConveyorBeltIdx] == belt)
			{
				list.Add(Resources[num]);
				if (removeFromBelt)
				{
					Resources.RemoveAt(num);
				}
			}
		}
		return list;
	}

	public void GatherResourcesOnBelt(ConveyorBelt belt)
	{
		List<Resource> resourcesOnBelt = GetResourcesOnBelt(belt);
		for (int num = resourcesOnBelt.Count - 1; num >= 0; num--)
		{
			LTFunctionLibrary.GetPlayerInventory()?.StoreObject(resourcesOnBelt[num].ResourceData, 1, Storage_ResourceData.EStoreSource.Production);
			UnityEngine.Object.DestroyImmediate(resourcesOnBelt[num].gameObject);
		}
	}

	public int GetBeltIndex(ConveyorBelt belt)
	{
		for (int i = 0; i < Belts.Count; i++)
		{
			if (Belts[i] == belt)
			{
				return i;
			}
		}
		return -1;
	}

	private bool CanAddNextResource()
	{
		if (inputStorage != null && !inputStorage.IsEmpty())
		{
			if (Resources.Count != 0)
			{
				return Resources[Resources.Count - 1].TraveledDistance >= inputStorage.StoredObjects[0].obj.LengthOnConveyorBelt;
			}
			return true;
		}
		return false;
	}

	public void AddResourceFromStorage()
	{
		if (CanAddNextResource())
		{
			Resources.Add(UnityEngine.Object.Instantiate(inputStorage.GetStoredObjectAtIndex(0).Prefab, beltParts[0].Belt.GetStartPosition(), Quaternion.LookRotation(LTFunctionLibrary.GetDirectionFromOrientation(LTFunctionLibrary.OrientationToWorldSpace(beltParts[0].Belt.OutputOrientation, beltParts[0].Belt.transform)))).GetComponent<Resource>());
			inputStorage.RemoveStoredObjectAtIndex(0, 1);
		}
	}

	public void MoveResources(float tickTime)
	{
		float alreadyMovedTime = tickTime;
		float num = Resources.Count;
		for (int i = 0; (float)i < num; i++)
		{
			float maxDistance = GetDistanceFromNext(i);
			bool flag = false;
			if (maxDistance <= 0f)
			{
				continue;
			}
			while ((double)alreadyMovedTime > 0.001)
			{
				Resources[i].TraveledDistance += beltParts[Resources[i].CurrentConveyorBeltIdx].Belt.MovePosition(Resources[i].gameObject, ref maxDistance, ref alreadyMovedTime);
				if (!((double)alreadyMovedTime > 0.001))
				{
					continue;
				}
				if (!IsLoop && Resources[i].CurrentConveyorBeltIdx == beltParts.Count - 1)
				{
					if (ResourceReachEnd(i))
					{
						num -= 1f;
						i--;
					}
					break;
				}
				if (IsLoop && Resources[i].CurrentConveyorBeltIdx == beltParts.Count - 1)
				{
					Resources[i].CurrentConveyorBeltIdx = 0;
					Resources[i].TraveledDistance = 0f;
					flag = true;
				}
				else
				{
					Resources[i].CurrentConveyorBeltIdx++;
				}
			}
			if (flag)
			{
				Resources.Add(Resources[i]);
				Resources.Remove(Resources[i]);
				i--;
				num -= 1f;
			}
			alreadyMovedTime = tickTime;
		}
	}

	private bool ResourceReachEnd(int resourceIdx)
	{
		if (outputStorage != null && outputStorage.CanStore(Resources[resourceIdx].ResourceData.Id, 1))
		{
			outputStorage.StoreObject(Resources[resourceIdx].ResourceData, 1, Storage_ResourceData.EStoreSource.Production);
			this.onStoreResource?.Invoke(resources[resourceIdx].ResourceData, 1);
			UnityEngine.Object.Destroy(Resources[resourceIdx].gameObject);
			Resources.RemoveAt(resourceIdx);
			return true;
		}
		if (outputStorage != null && outputStorage.DestroyUnfilteredObjects && outputStorage.StorageEnabled && !outputStorage.HasFilter(Resources[resourceIdx].ResourceData.Id))
		{
			UnityEngine.Object.Destroy(Resources[resourceIdx].gameObject);
			Resources.RemoveAt(resourceIdx);
			return true;
		}
		return false;
	}

	private float GetDistanceFromNext(int resourceIdx)
	{
		if (resourceIdx == 0)
		{
			if (IsLoop)
			{
				return GroupDistance - Resources[0].TraveledDistance - Resources[0].ResourceData.LengthOnConveyorBelt * 0.5f + (Resources[resources.Count - 1].TraveledDistance - Resources[resources.Count - 1].ResourceData.LengthOnConveyorBelt * 0.5f);
			}
			return float.PositiveInfinity;
		}
		return Resources[resourceIdx - 1].TraveledDistance - Resources[resourceIdx - 1].ResourceData.LengthOnConveyorBelt * 0.5f - Resources[resourceIdx].TraveledDistance - Resources[resourceIdx].ResourceData.LengthOnConveyorBelt * 0.5f;
	}

	private void RecalculateBeltDistances(bool affectResources = false)
	{
		float groupDistance = GroupDistance;
		float startTotalDistance = 0f;
		foreach (ConveyorBeltGroupPart beltPart in beltParts)
		{
			beltPart.UpdateTotalDistances(startTotalDistance);
			startTotalDistance = beltPart.EndTotalDistance;
		}
		if (affectResources)
		{
			float distanceDiff = GroupDistance - groupDistance;
			resources.ForEach(delegate(Resource r)
			{
				r.TraveledDistance += distanceDiff;
			});
		}
	}

	public void BreakLoop(ConveyorBelt beltToRemove)
	{
		int beltIndex = GetBeltIndex(beltToRemove);
		float endTotalDistance = beltParts[beltIndex].EndTotalDistance;
		float groupDistance = GroupDistance;
		List<ConveyorBeltGroupPart> list = new List<ConveyorBeltGroupPart>();
		for (int i = 0; i < beltParts.Count; i++)
		{
			list.Add(beltParts[(beltIndex + 1 + i) % beltParts.Count]);
		}
		beltParts = list;
		foreach (Resource resource in resources)
		{
			resource.CurrentConveyorBeltIdx = Mathf.RoundToInt(Mathf.Repeat(resource.CurrentConveyorBeltIdx - beltIndex + (beltParts.Count - 1), beltParts.Count));
			resource.TraveledDistance = Mathf.Repeat(resource.TraveledDistance - endTotalDistance + groupDistance, groupDistance);
		}
		resources.Sort((Resource x, Resource y) => (x.CurrentConveyorBeltIdx == y.CurrentConveyorBeltIdx) ? (x.TraveledDistance.CompareTo(y.TraveledDistance) * -1) : (x.CurrentConveyorBeltIdx.CompareTo(y.CurrentConveyorBeltIdx) * -1));
		RecalculateBeltDistances();
		RemoveLastBelt(removeResources: true, recalculateDistances: true);
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (!data.ContainsKey("resources"))
		{
			return;
		}
		foreach (Dictionary<string, object> item in data["resources"] as List<Dictionary<string, object>>)
		{
			Resource component = UnityEngine.Object.Instantiate(LTAssetsReferences.instance.GetResourceDataById((item["resourceData"] as Dictionary<string, object>)["id"] as string).Prefab).GetComponent<Resource>();
			resources.Add(component);
			SaveSystem.LoadObjectData(component.gameObject, item, hasSaveTransformAtt: true);
		}
	}
}
