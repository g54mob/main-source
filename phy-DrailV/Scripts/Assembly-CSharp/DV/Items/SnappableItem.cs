using System;
using System.Collections;
using System.Collections.Generic;
using DV.CabControls;
using DV.CabControls.Spec;
using DV.CabControls.VRTK;
using DV.Customization;
using DV.Customization.Gadgets;
using DV.Customization.Gadgets.Implementations;
using DV.Interaction;
using DV.Items.Snapping;
using DV.JObjectExtstensions;
using DV.Utils;
using DV.VRTK_Extensions;
using Newtonsoft.Json.Linq;
using UnityEngine;
using VRTK;

namespace DV.Items
{
	public class SnappableItem : MonoBehaviour, IItemUse
	{
		public delegate void ItemSnappedChangedDelegate(SnappableItem item, bool snapped, SnapPointTypes snapPointType);

		private abstract class SpecialSnappedBehaviour
		{
			protected SnappableItem snappable;

			protected SpecialSnappedBehaviour(SnappableItem snappable)
			{
				this.snappable = snappable;
			}
		}

		private class SpecialSnappedBehaviourCoupler : SpecialSnappedBehaviour
		{
			private const string SNAPPED_ON_COUPLER_CAR_GUID_KEY = "SnappedOnCouplerCarID";

			private const string SNAPPED_ON_COUPLER_IS_FRONT_KEY = "SnappedOnCouplerIsFront";

			private readonly ItemBase item;

			public SpecialSnappedBehaviourCoupler(SnappableItem snappable, ItemBase item, ItemSaveData itemSaveData)
				: base(snappable)
			{
				this.item = item;
				itemSaveData.ItemSaveDataRequested += OnItemSaveDataRequested;
				itemSaveData.ItemSaveDataLoaded += OnItemSaveDataLoaded;
				if (item == null)
				{
					Debug.LogError("SpecialSnappedBehaviourCoupler: ItemBase component not found on " + snappable.name + ".", snappable);
				}
				if (itemSaveData == null)
				{
					Debug.LogError("SpecialSnappedBehaviourCoupler: ItemSaveData component not found on " + snappable.name + ".", snappable);
				}
			}

			private JObject OnItemSaveDataRequested(JObject data)
			{
				ItemSnapPointCoupler itemSnapPointCoupler = snappable.SnappedTo as ItemSnapPointCoupler;
				if (itemSnapPointCoupler == null)
				{
					data.Remove("SnappedOnCouplerCarID");
					data.Remove("SnappedOnCouplerIsFront");
					return data;
				}
				data.SetString("SnappedOnCouplerCarID", itemSnapPointCoupler.Car.CarGUID);
				data.SetBool("SnappedOnCouplerIsFront", itemSnapPointCoupler.IsFront);
				return data;
			}

			private void OnItemSaveDataLoaded(JObject data)
			{
				if (data == null)
				{
					return;
				}
				string text = data.GetString("SnappedOnCouplerCarID");
				if (string.IsNullOrEmpty(text))
				{
					return;
				}
				bool flag = data.GetBool("SnappedOnCouplerIsFront") ?? false;
				TrainCar trainCarByCarGuid = SingletonBehaviour<TrainCarRegistry>.Instance.GetTrainCarByCarGuid(text);
				if (trainCarByCarGuid == null)
				{
					Debug.LogError("SpecialSnappedBehaviourCoupler:  Loading snapped state failed - Could not find car with ID " + text + ".", snappable);
					return;
				}
				foreach (ItemSnapPointCoupler couplerSnapPoint in trainCarByCarGuid.GetComponent<TrainPhysicsLod>().GetCouplerSnapPoints())
				{
					if (couplerSnapPoint.IsFront == flag)
					{
						if (item.ItemRigidbody.isKinematic)
						{
							item.ItemRigidbody.isKinematic = false;
						}
						couplerSnapPoint.SnapItem(item);
						return;
					}
				}
				Debug.LogError("SpecialSnappedBehaviourCoupler: Loading snapped state failed - Could not ItemSnapPointCoupler point on car with guid " + text + ".", trainCarByCarGuid);
			}
		}

		private class SpecialSnappedBehaviourGadgetSnapPoint : SpecialSnappedBehaviour
		{
			private const string SNAPPED_ON_GADGET_CAR_GUID_KEY = "SnappedOnHangerCarID";

			private const string SNAPPED_ON_GADGET_GADGET_UID_KEY = "SnappedOnHangerUIDKey";

			private readonly ItemBase item;

			public SpecialSnappedBehaviourGadgetSnapPoint(SnappableItem snappable, ItemBase item, ItemSaveData itemSaveData)
				: base(snappable)
			{
				this.item = item;
				itemSaveData.ItemSaveDataRequested += OnItemSaveDataRequested;
				itemSaveData.ItemSaveDataLoaded += OnItemSaveDataLoaded;
				if (item == null)
				{
					Debug.LogError("SpecialSnappedBehaviourGadgetSnapPoint: ItemBase component not found on " + snappable.name + ".", snappable);
				}
				if (itemSaveData == null)
				{
					Debug.LogError("SpecialSnappedBehaviourGadgetSnapPoint: ItemSaveData component not found on " + snappable.name + ".", snappable);
				}
			}

			private JObject OnItemSaveDataRequested(JObject data)
			{
				SnapPointGadget snapPointGadget = snappable.SnappedTo as SnapPointGadget;
				if (snapPointGadget == null)
				{
					data.Remove("SnappedOnHangerCarID");
					data.Remove("SnappedOnHangerUIDKey");
					return data;
				}
				data.SetString("SnappedOnHangerCarID", snapPointGadget.gadgetBase.Custom.GetIdentificationKey());
				data.SetInt("SnappedOnHangerUIDKey", snapPointGadget.gadgetBase.UID);
				return data;
			}

			private void OnItemSaveDataLoaded(JObject data)
			{
				if (data == null)
				{
					return;
				}
				string text = data.GetString("SnappedOnHangerCarID");
				if (string.IsNullOrEmpty(text))
				{
					return;
				}
				if (!DV.Customization.Customization.TryGetFromIdentificationKey(text, out var result))
				{
					Debug.LogError("SpecialSnappedBehaviourGadgetSnapPoint:  Loading snapped state failed - Could not find customization with ID " + text + ".", snappable);
					return;
				}
				int? num = data.GetInt("SnappedOnHangerUIDKey");
				if (!num.HasValue)
				{
					return;
				}
				if (!result.TryGetCustomizerByUID(num.Value, out var customizer))
				{
					Debug.LogError(string.Format("{0}:  Loading snapped state failed - Could not find customizer with ID {1}.", "SpecialSnappedBehaviourGadgetSnapPoint", num.Value), snappable);
					return;
				}
				if (!(customizer is GadgetWithSnapPoint gadgetWithSnapPoint))
				{
					Debug.LogError("SpecialSnappedBehaviourGadgetSnapPoint:  Loading snapped state failed - Found customizer was not GadgetWithSnapPoint.", snappable);
					return;
				}
				if (item.ItemRigidbody.isKinematic)
				{
					item.ItemRigidbody.isKinematic = false;
				}
				gadgetWithSnapPoint.snapPoint.SnapItem(item, forced: true);
			}
		}

		private const SnapPointTypes REQUIRES_ITEM_SAVE_DATA_MASK = SnapPointTypes.Coupler | SnapPointTypes.Hanger | SnapPointTypes.LongCylinder | SnapPointTypes.StickyPad;

		private List<SpecialSnappedBehaviour> specialSnappedBehaviours = new List<SpecialSnappedBehaviour>();

		private bool initialized;

		private Transform[] anchorTransforms = new Transform[ItemSnapPointBase.snapPointTypeCount];

		private ItemSnapPointBase hoveringSnapPointVR;

		private int hoveringSnapPointCounter;

		public SnapPointTypes AllowedSnapPointTypes { get; private set; }

		public bool IsSnapped => SnappedTo != null;

		public ItemSnapPointBase SnappedTo { get; private set; }

		public ItemBase Item { get; private set; }

		public GadgetSystemUtility.HighlightMesh[] HighlightMeshes { get; private set; }

		private ItemSnapPointBase HoveringSnapPointVR
		{
			get
			{
				return hoveringSnapPointVR;
			}
			set
			{
				if (!(hoveringSnapPointVR == value))
				{
					if (hoveringSnapPointVR != null)
					{
						hoveringSnapPointVR.HoverVR(this, hovered: false);
					}
					hoveringSnapPointVR = value;
					if (hoveringSnapPointVR != null)
					{
						hoveringSnapPointVR.HoverVR(this, hovered: true);
					}
				}
			}
		}

		public event ItemSnappedChangedDelegate ItemSnappingChanged;

		public void Initialize(ItemBase itemBase, SnapPointTypes snapPointTypes)
		{
			if (initialized)
			{
				return;
			}
			Item = itemBase;
			AllowedSnapPointTypes = snapPointTypes;
			ItemSaveData itemSaveData = Item.GetComponent<ItemSaveData>();
			if (AllowedSnapPointTypes.HasAnyFlag(SnapPointTypes.Coupler | SnapPointTypes.Hanger | SnapPointTypes.LongCylinder | SnapPointTypes.StickyPad) && itemSaveData == null)
			{
				itemSaveData = Item.gameObject.AddComponent<ItemSaveData>();
			}
			if (AllowedSnapPointTypes.HasIntFlag(SnapPointTypes.Coupler))
			{
				specialSnappedBehaviours.Add(new SpecialSnappedBehaviourCoupler(this, Item, itemSaveData));
			}
			if (AllowedSnapPointTypes.HasIntFlag(SnapPointTypes.Hanger) || AllowedSnapPointTypes.HasIntFlag(SnapPointTypes.LongCylinder) || AllowedSnapPointTypes.HasIntFlag(SnapPointTypes.StickyPad))
			{
				specialSnappedBehaviours.Add(new SpecialSnappedBehaviourGadgetSnapPoint(this, Item, itemSaveData));
			}
			SnapPointTypes snapPointTypes2 = SnapPointTypes.None;
			SnapPointAnchor[] componentsInChildren = GetComponentsInChildren<SnapPointAnchor>(includeInactive: true);
			foreach (SnapPointAnchor snapPointAnchor in componentsInChildren)
			{
				for (int j = 0; j < anchorTransforms.Length; j++)
				{
					SnapPointTypes snapPointTypes3 = (SnapPointTypes)(1 << j);
					if (Enum.IsDefined(typeof(SnapPointTypes), snapPointTypes3) && snapPointAnchor.Type.HasIntFlag(snapPointTypes3))
					{
						anchorTransforms[j] = snapPointAnchor.transform;
						snapPointTypes2 |= snapPointTypes3;
					}
				}
			}
			if (Item.SpecItem.allowedSnapPointTypes.HasAnyFlag(SnapPointTypes.StickyPad) && !snapPointTypes2.HasAnyFlag(SnapPointTypes.StickyPad))
			{
				CustomNonVrGrabAnchor component = Item.GetComponent<CustomNonVrGrabAnchor>();
				if (component != null)
				{
					GameObject gameObject = new GameObject("StickyPadAnchor");
					gameObject.transform.SetParent(Item.transform, worldPositionStays: false);
					gameObject.transform.localRotation = Quaternion.Inverse(Quaternion.Euler(component.customLocalRotation));
					gameObject.AddComponent<SnapPointAnchor>().ForceSetType(SnapPointTypes.StickyPad);
					anchorTransforms[ItemSnapPointBase.SnapPointTypesToIndex(SnapPointTypes.StickyPad)] = gameObject.transform;
				}
			}
			if (VRManager.IsVREnabled())
			{
				itemBase.Ungrabbed -= OnUngrabbed;
				itemBase.Ungrabbed += OnUngrabbed;
				itemBase.Grabbed -= OnGrabbed;
				itemBase.Grabbed += OnGrabbed;
			}
			GameObject previewPrefab = Item.InventorySpecs.PreviewPrefab;
			HighlightMeshes = GadgetSystemUtility.GenerateHighlightMeshes(previewPrefab.transform, includeInactive: false);
			initialized = true;
		}

		private void OnUngrabbed(ControlImplBase _)
		{
			if (CanSnap())
			{
				StartCoroutine(WaitOneFrame());
			}
			IEnumerator WaitOneFrame()
			{
				yield return null;
				if (CanSnap())
				{
					hoveringSnapPointVR.SnapItem(Item);
				}
			}
		}

		private void OnGrabbed(ControlImplBase _)
		{
			StartCoroutine(CheckForUpdates());
			IEnumerator CheckForUpdates()
			{
				ItemSnapPointBase cachedSnapPoint = null;
				while (Item.IsGrabbed())
				{
					if (cachedSnapPoint != hoveringSnapPointVR)
					{
						cachedSnapPoint = hoveringSnapPointVR;
						HapticIntensityType intensityType = (cachedSnapPoint ? HapticIntensityType.Normal : HapticIntensityType.Weak);
						HapticUtils.DoHapticPulse(VRTK_ControllerReference.GetControllerReference((Item as ItemVRTK).GetGrabbingObject()), intensityType);
					}
					yield return null;
				}
			}
		}

		private bool CanSnap()
		{
			if (Item.IsGrabbed())
			{
				return false;
			}
			if (!hoveringSnapPointVR)
			{
				return false;
			}
			if (Item.IsSnapped)
			{
				return false;
			}
			if (hoveringSnapPointVR is ItemSnapPointBelt)
			{
				return false;
			}
			if (!hoveringSnapPointVR.CanSnapCheck(this, forced: false))
			{
				return false;
			}
			return true;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (!VRManager.IsVREnabled())
			{
				return;
			}
			ReliableOnTriggerExit.NotifyTriggerEnter(other, base.gameObject, OnTriggerExit);
			ItemSnapPointBase component = other.GetComponent<ItemSnapPointBase>();
			if (!(component == null) && AllowedSnapPointTypes.HasAnyFlag(component.SnapPointType))
			{
				if (component != hoveringSnapPointVR)
				{
					HoveringSnapPointVR = component;
					hoveringSnapPointCounter = 1;
				}
				else
				{
					hoveringSnapPointCounter++;
				}
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (!VRManager.IsVREnabled())
			{
				return;
			}
			ReliableOnTriggerExit.NotifyTriggerExit(other, base.gameObject);
			if (hoveringSnapPointVR != null && other.gameObject == hoveringSnapPointVR.gameObject)
			{
				hoveringSnapPointCounter--;
				if (hoveringSnapPointCounter == 0)
				{
					HoveringSnapPointVR = null;
				}
			}
		}

		public void OnSnapped(ItemSnapPointBase snappedTo)
		{
			SnapPointTypes snapPointType = snappedTo.SnapPointType;
			SnappedTo = snappedTo;
			this.ItemSnappingChanged?.Invoke(this, snapped: true, snapPointType);
		}

		public void OnUnsnapped()
		{
			SnapPointTypes snapPointType = SnappedTo.SnapPointType;
			SnappedTo = null;
			this.ItemSnappingChanged?.Invoke(this, snapped: false, snapPointType);
		}

		public Transform GetAnchor(SnapPointTypes type)
		{
			return anchorTransforms[ItemSnapPointBase.SnapPointTypesToIndex(type)];
		}

		public virtual bool HandleHover(ItemUseTarget target)
		{
			if (VRManager.IsVREnabled())
			{
				return false;
			}
			SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(InteractionInfoType.PlugIn);
			return true;
		}

		public virtual bool HandleUse(ItemUseTarget target)
		{
			ItemSnapPointBase component = target.GetComponent<ItemSnapPointBase>();
			if (component != null)
			{
				return component.SnapItem(base.gameObject);
			}
			return false;
		}

		public bool IsHoverCompatible(ItemUseTarget target)
		{
			return IsUseCompatible(target);
		}

		public virtual bool IsUseCompatible(ItemUseTarget target)
		{
			ItemSnapPointBase component = target.GetComponent<ItemSnapPointBase>();
			if (component != null)
			{
				return component.CanSnapCheck(this, forced: false);
			}
			return false;
		}
	}
}
