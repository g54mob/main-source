using System.Collections.Generic;
using DV.CabControls;
using DV.Utils;
using UnityEngine;

public class StorageStaticParent : ItemStaticParent
{
	private const float VELOCITY_THRESHOLD = 0.01f;

	private const float ANGULAR_VELOCITY_THRESHOLD = 0.01f;

	private const int MAX_UPDATE_ITERATIONS = 50;

	[SerializeField]
	private BoxCollider volumeCollider;

	private PointOnPlane transformValueRandomizer;

	private HashSet<ItemBase> settlingItems = new HashSet<ItemBase>();

	private HashSet<ItemBase> settledItems = new HashSet<ItemBase>();

	private int updateIteration;

	private void Awake()
	{
		transformValueRandomizer = GetComponentInChildren<PointOnPlane>(includeInactive: true);
		if (transformValueRandomizer == null)
		{
			Debug.LogError("StorageStaticParent: Missing PointOnPlane component. Random transform generation is no longer possible.", this);
		}
		base.enabled = false;
		if (volumeCollider == null)
		{
			Debug.LogError("StorageStaticParent: Missing volume collider. Item position safety is not guaranteed.", this);
		}
	}

	public bool IsInVolume(Vector3 worldPosition)
	{
		if (!(volumeCollider == null))
		{
			return volumeCollider.ClosestPoint(worldPosition) == worldPosition;
		}
		return true;
	}

	public override void ItemParented(ItemBase item, ItemReparentingBase reparenting)
	{
		if (item == null || reparenting == null)
		{
			Debug.LogError("StorageStaticParent received null item", this);
			return;
		}
		base.ItemParented(item, reparenting);
		SingletonBehaviour<StorageController>.Instance.ItemTransformControllerLostAndFound.UpdateItemTransformData(item);
		settlingItems.Add(item);
		updateIteration = 0;
		base.enabled = true;
	}

	private void Update()
	{
		settlingItems.RemoveWhere((ItemBase t) => t == null);
		foreach (ItemBase settlingItem in settlingItems)
		{
			if (!IsInMotion(settlingItem.ItemRigidbody) || !(settlingItem.transform.parent == base.transform))
			{
				settledItems.Add(settlingItem);
			}
		}
		foreach (ItemBase settledItem in settledItems)
		{
			if (settledItem.transform.parent == base.transform)
			{
				SingletonBehaviour<StorageController>.Instance.ItemTransformControllerLostAndFound.UpdateItemTransformData(settledItem);
			}
			settlingItems.Remove(settledItem);
		}
		settledItems.Clear();
		if (updateIteration < 50)
		{
			updateIteration++;
			return;
		}
		settlingItems.Clear();
		updateIteration = 0;
		base.enabled = false;
	}

	private bool IsInMotion(Rigidbody rb)
	{
		if (updateIteration < 50)
		{
			if (!(rb.velocity.sqrMagnitude > 0.01f))
			{
				return rb.angularVelocity.sqrMagnitude > 0.01f;
			}
			return true;
		}
		return false;
	}

	public (Vector3 randomLocalPosition, Quaternion randomLocalRotation) GetRandomTransformValues()
	{
		if (!(transformValueRandomizer == null))
		{
			return transformValueRandomizer.GetRandomPointWithRotationOnPlane();
		}
		return (randomLocalPosition: base.transform.position, randomLocalRotation: base.transform.rotation);
	}
}
