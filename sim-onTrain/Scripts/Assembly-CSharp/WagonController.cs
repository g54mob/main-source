using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonController : PropBase
{
	public Transform buildParent;

	public Transform propParent;

	[Header("Wagon Settings")]
	public int wagonID;

	public Animator animator;

	[Tooltip("DEPRECATED: Artık kullanılmıyor - oyuncular direkt wagon'a parent olur")]
	public Transform playerAttachmentPivot;

	[Header("Spawn Points")]
	public Transform playerSpawnPoint;

	public Transform nextWagonSpawnPoint;

	private bool isLastWagon;

	public List<Transform> snapPoints = new List<Transform>();

	public CollectableItemData groundData;

	public string GetWagonItemName()
	{
		if (!(data != null))
		{
			return "DefaultWagon";
		}
		return data.itemName;
	}

	public void InitializeWagon(int id)
	{
		wagonID = id;
	}

	public void CreateDefaultWagon()
	{
		Debug.Log($"=== WagonController.CreateDefaultWagon ÇAĞRILDI === WagonID: {wagonID} [TREN]");
		if (snapPoints == null)
		{
			Debug.LogWarning("snapPoints NULL! [TREN]");
		}
		else if (snapPoints.Count == 0)
		{
			Debug.LogWarning("snapPoints boş! Count=0 [TREN]");
		}
		else
		{
			StartCoroutine(CreateDefaultWagonDelayed());
		}
	}

	private IEnumerator CreateDefaultWagonDelayed()
	{
		yield return new WaitForSeconds(0.1f);
		TrainBuildManager trainBuildManager = Object.FindObjectOfType<TrainBuildManager>();
		if (trainBuildManager == null)
		{
			Debug.LogWarning("TrainBuildManager bulunamadı! [TREN]");
			yield break;
		}
		if (trainBuildManager.groundData == null)
		{
			Debug.LogWarning("TrainBuildManager groundData NULL! [TREN]");
			yield break;
		}
		int num = 0;
		foreach (Transform snapPoint in snapPoints)
		{
			if (snapPoint == null)
			{
				Debug.LogWarning($"SnapPoint {num} NULL! [TREN]");
				continue;
			}
			Vector3 localPosition = snapPoint.localPosition;
			Vector3 localEulerAngles = snapPoint.localEulerAngles;
			trainBuildManager.SpawnBuildObjectOnServer(localPosition, localEulerAngles, trainBuildManager.groundData.itemName, wagonID);
			num++;
		}
	}

	public void ShowWagonInfo()
	{
		if (data != null)
		{
			_ = data.itemName;
		}
	}

	public void AddBuildItems(Transform t)
	{
		if (buildParent != null)
		{
			t.SetParent(buildParent, worldPositionStays: false);
		}
		else
		{
			t.SetParent(base.transform, worldPositionStays: false);
		}
	}

	public void AddPropItems(Transform t)
	{
		if (propParent != null)
		{
			t.SetParent(propParent, worldPositionStays: false);
		}
		else
		{
			t.SetParent(base.transform, worldPositionStays: false);
		}
	}

	public void AddItemByType(Transform t, ItemType itemType)
	{
		switch (itemType)
		{
		case ItemType.Placeable:
			AddPropItems(t);
			break;
		case ItemType.BuildItem:
			AddBuildItems(t);
			break;
		default:
			t.SetParent(base.transform, worldPositionStays: false);
			break;
		}
	}

	public void ListAllItemsOnWagon()
	{
		PropBase[] componentsInChildren = GetComponentsInChildren<PropBase>();
		foreach (PropBase propBase in componentsInChildren)
		{
			if (!(propBase.transform == base.transform) && propBase.data != null)
			{
				_ = propBase.data.itemName;
			}
		}
	}

	private CollectableItemData FindItemDataByName(string itemName)
	{
		CollectableItemData[] array = Resources.LoadAll<CollectableItemData>("");
		foreach (CollectableItemData collectableItemData in array)
		{
			if (collectableItemData.itemName == itemName)
			{
				return collectableItemData;
			}
		}
		return null;
	}
}
