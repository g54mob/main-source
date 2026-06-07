using System;
using System.Collections;
using DV.CabControls;
using DV.CabControls.Spec;
using DV.Utils;
using UnityEngine;

namespace DV.Items.Snapping
{
	public abstract class ItemSnapPointBase : MonoBehaviour
	{
		public delegate void ItemSnappedChangedDelegate(ItemSnapPointBase snapPoint, ItemBase item, bool snapped, bool forced);

		[Serializable]
		private class ItemSnapState
		{
			private ItemBase item;

			private bool originalKinematic;

			private CollisionDetectionMode originalCollisionDetectionMode;

			private Transform originalParent;

			private Transform newParent;

			private Rigidbody originalParentReceiveForcesFrom;

			private Rigidbody newParentReceiveForcesFrom;

			private ItemStaticParent originalStaticParent;

			private ItemStaticParent newStaticParent;

			private bool hasForcedParent;

			public ItemSnapState(ItemBase item, Transform newParent, bool hasForcedParent, bool makeNonInteractable)
			{
				if (!(item == null))
				{
					this.item = item;
					TrainCar trainCar = TrainCar.Resolve(newParent);
					this.newParent = ((trainCar != null && !hasForcedParent) ? trainCar.interior : newParent);
					newParentReceiveForcesFrom = ((trainCar != null) ? trainCar.rb : null);
					Rigidbody rigidbody = item.CabItem.GetRigidbody();
					newStaticParent = ((trainCar != null) ? null : newParent.GetComponentInParent<ItemStaticParent>());
					if (rigidbody != null)
					{
						originalKinematic = rigidbody.isKinematic;
						originalCollisionDetectionMode = rigidbody.collisionDetectionMode;
					}
					else
					{
						originalKinematic = false;
						originalCollisionDetectionMode = CollisionDetectionMode.Discrete;
					}
					TrainCar trainCar2 = TrainCar.Resolve(item.transform.parent);
					originalParent = ((trainCar2 != null) ? trainCar2.interior : item.transform.parent);
					originalParentReceiveForcesFrom = ((trainCar2 != null) ? trainCar2.rb : null);
					originalStaticParent = ((trainCar2 != null) ? null : item.GetComponentInParent<ItemStaticParent>());
					ToggleInteraction(restore: false, makeNonInteractable);
					SetLayers(restore: false);
				}
			}

			public void Restore()
			{
				if (!(item == null))
				{
					ToggleInteraction(restore: true, makeNonInteractable: false);
					SetLayers(restore: true);
				}
			}

			private void ToggleInteraction(bool restore, bool makeNonInteractable)
			{
				Rigidbody rigidbody = item.CabItem.GetRigidbody();
				if (restore)
				{
					item.InteractionAllowed = true;
					if (rigidbody != null)
					{
						rigidbody.isKinematic = originalKinematic;
						rigidbody.collisionDetectionMode = originalCollisionDetectionMode;
					}
					ItemReparentingBase component = item.GetComponent<ItemReparentingBase>();
					if (component != null)
					{
						component.ParentItemExternal(originalParent, originalParentReceiveForcesFrom, originalStaticParent);
						if (originalStaticParent as StorageStaticParent != null && item.BelongsToPlayer() && !SingletonBehaviour<StorageController>.Instance.StorageLostAndFound.ContainsItem(item))
						{
							SingletonBehaviour<StorageController>.Instance.AddItemToLostAndFound(item, updateTransformData: false);
						}
					}
					else
					{
						item.transform.SetParent(originalParent, worldPositionStays: true);
					}
					return;
				}
				if (makeNonInteractable)
				{
					item.InteractionAllowed = false;
				}
				if (rigidbody != null)
				{
					rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
					rigidbody.isKinematic = true;
				}
				ItemReparentingBase component2 = item.GetComponent<ItemReparentingBase>();
				if (component2 == null)
				{
					item.transform.SetParent(newParent, worldPositionStays: true);
					Debug.LogError("ItemReparentingBase not found on " + item.name + ". Parenting directly to " + newParent.name + ".", item);
				}
				else if (!hasForcedParent || newStaticParent == null)
				{
					component2.ParentItemExternal(newParent, newParentReceiveForcesFrom, newStaticParent);
				}
				else
				{
					component2.ParentItemExternal(newParent, newParentReceiveForcesFrom);
					if (newStaticParent as StorageStaticParent != null && item.BelongsToPlayer() && !SingletonBehaviour<StorageController>.Instance.StorageLostAndFound.ContainsItem(item))
					{
						SingletonBehaviour<StorageController>.Instance.AddItemToLostAndFound(item, updateTransformData: false);
					}
				}
			}

			private void SetLayers(bool restore)
			{
				int layerToInteractionColliders = LayerMask.NameToLayer(restore ? "World_Item" : "Inventory");
				item.SetLayerToInteractionColliders(layerToInteractionColliders);
			}
		}

		public static readonly int snapPointTypeCount = Enum.GetValues(typeof(SnapPointTypes)).Length;

		[SerializeField]
		private SnapPointTypes snapPointType;

		public bool snapAllowed = true;

		[SerializeField]
		protected Transform snapPointTarget;

		[SerializeField]
		protected float standardSnapDuration = 0.2f;

		[SerializeField]
		protected bool slotRotated;

		private ItemSnapState itemSnapState;

		private Quaternion uprightCorrection = Quaternion.Euler(-90f, 0f, 0f);

		private Coroutine transitionCoro;

		protected abstract bool DisallowInteractionOnSnap { get; }

		public SnapPointTypes SnapPointType => snapPointType;

		public ItemBase SnappedItem { get; private set; }

		public event ItemSnappedChangedDelegate ItemSnappedChanged;

		public static int SnapPointTypesToIndex(SnapPointTypes types)
		{
			int num = (int)types;
			int num2 = -1;
			while (num != 0)
			{
				num >>= 1;
				num2++;
			}
			return num2;
		}

		protected virtual void Awake()
		{
			if (!NumberUtils.IsPowerOfTwo((int)snapPointType))
			{
				Debug.LogError($"Snap point type {snapPointType} is not a valid. It can't be {SnapPointTypes.None} or a combination of flags.", this);
			}
		}

		protected virtual void OnDisable()
		{
			if (transitionCoro != null && !UnloadWatcher.isUnloading)
			{
				StopCoroutine(transitionCoro);
				transitionCoro = null;
				FinalizeSnap();
			}
		}

		public bool SnapItem(GameObject itemToSnap, bool forced = false)
		{
			return SnapItem((itemToSnap != null) ? itemToSnap.GetComponent<ItemBase>() : null, forced);
		}

		public virtual bool SnapItem(ItemBase itemToSnap, bool forced = false)
		{
			if (!CanSnapCheck(itemToSnap.SnappableItem, forced))
			{
				return false;
			}
			if (itemToSnap.IsGrabbed())
			{
				itemToSnap.ForceEndInteraction();
			}
			SnappedItem = itemToSnap;
			bool flag = snapPointTarget != null;
			Transform newParent = (flag ? snapPointTarget : base.transform);
			itemSnapState = new ItemSnapState(SnappedItem, newParent, flag, DisallowInteractionOnSnap);
			if (!base.gameObject.activeInHierarchy)
			{
				HandleDisabledState();
			}
			if (transitionCoro != null)
			{
				StopCoroutine(transitionCoro);
				transitionCoro = null;
			}
			if (forced || !base.gameObject.activeInHierarchy)
			{
				FinalizeSnap();
			}
			else
			{
				transitionCoro = StartCoroutine(AnimateSnap(standardSnapDuration));
			}
			itemToSnap.SnappableItem.OnSnapped(this);
			this.ItemSnappedChanged?.Invoke(this, itemToSnap, snapped: true, forced);
			return true;
		}

		public virtual bool CanSnapCheck(SnappableItem snappableItem, bool forced)
		{
			if (snappableItem == null || SnappedItem != null)
			{
				return false;
			}
			if (!snappableItem.AllowedSnapPointTypes.HasIntFlag(snapPointType))
			{
				return false;
			}
			return snapAllowed || forced;
		}

		public virtual bool UnsnapItem(bool forced = false)
		{
			if (SnappedItem == null)
			{
				Debug.LogError("ItemSnapPointBase does not have a snapped item to unsnap.", this);
				return false;
			}
			ItemBase snappedItem = SnappedItem;
			if (transitionCoro != null)
			{
				StopCoroutine(transitionCoro);
				transitionCoro = null;
			}
			SnappedItem = null;
			if (itemSnapState != null)
			{
				itemSnapState.Restore();
			}
			else
			{
				Debug.LogError("Unsnapping " + snappedItem.name + " but ItemSnapState is null.", this);
			}
			itemSnapState = null;
			if (snappedItem.IsSnapped)
			{
				snappedItem.SnappableItem.OnUnsnapped();
			}
			this.ItemSnappedChanged?.Invoke(this, snappedItem, snapped: false, forced);
			return true;
		}

		private IEnumerator AnimateSnap(float duration)
		{
			float elapsedTime = 0f;
			Transform snapPointTarget = ((this.snapPointTarget != null) ? this.snapPointTarget : base.transform);
			Transform itemTransform = SnappedItem.transform;
			Vector3 startPosition = itemTransform.position - snapPointTarget.position;
			Quaternion startRotation = itemTransform.rotation;
			while (elapsedTime < duration)
			{
				elapsedTime += Time.deltaTime;
				if (itemTransform != null && snapPointTarget != null)
				{
					(Vector3 pos, Quaternion rot) tuple = CalculateWorldEndPose(SnappedItem);
					Vector3 item = tuple.pos;
					Quaternion item2 = tuple.rot;
					itemTransform.position = Vector3.Lerp(startPosition + snapPointTarget.position, item, elapsedTime / duration);
					itemTransform.rotation = Quaternion.Slerp(startRotation, item2, elapsedTime / duration);
				}
				yield return null;
			}
			FinalizeSnap();
			transitionCoro = null;
		}

		private void FinalizeSnap()
		{
			if (!(SnappedItem == null))
			{
				Transform obj = SnappedItem.transform;
				(obj.position, obj.rotation) = CalculateWorldEndPose(SnappedItem);
				SnappedItem.CabItem.GetRigidbody().isKinematic = true;
			}
		}

		protected virtual bool ShouldKeepUpright(ItemBase item)
		{
			if (item != null)
			{
				return slotRotated;
			}
			return false;
		}

		public (Vector3 pos, Quaternion rot) CalculateWorldEndPose(ItemBase item)
		{
			Transform matchTo = ((snapPointTarget != null) ? snapPointTarget : base.transform);
			Transform anchor = null;
			if (item != null && item.SnappableItem != null)
			{
				anchor = item.SnappableItem.GetAnchor(snapPointType);
			}
			(Vector3, Quaternion) result = TransformUtils.CalculateAlignmentTargets(item.transform, matchTo, anchor);
			if (ShouldKeepUpright(item))
			{
				result.Item2 = uprightCorrection * result.Item2;
			}
			return result;
		}

		protected virtual void HandleDisabledState()
		{
		}

		public virtual void ToggleSnapPoint(bool shouldEnable)
		{
			base.gameObject.SetActive(shouldEnable);
		}

		public virtual void HoverVR(SnappableItem hoveredBy, bool hovered)
		{
		}
	}
}
