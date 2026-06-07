using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.CabControls;
using DV.CabControls.Spec;
using DV.CabControls.VRTK;
using DV.Common;
using DV.Damage;
using DV.InventorySystem;
using DV.JObjectExtstensions;
using DV.Localization;
using DV.Utils;
using DV.VRTK_Extensions;
using Newtonsoft.Json.Linq;
using UnityEngine;
using VRTK;

namespace DV.Customization.Gadgets
{
	[RequireComponent(typeof(InventoryItemSpec))]
	[ExecuteAfter(typeof(CameraSmoothing))]
	[ExecuteAfter(typeof(CameraDampening))]
	[ExecuteAfter(typeof(CustomFirstPersonController))]
	[RequireComponent(typeof(ItemSaveData))]
	public class GadgetItem : MonoBehaviour
	{
		public delegate bool CustomRaycastingDelegate(RaycastHitDV hit, out GadgetBase customGadget, out Vector3 previewPosition, out Quaternion previewRotation, out Color previewColor);

		public delegate GadgetBase CustomUseDelegate(RaycastHitDV hit, Vector3 previewPosition, Quaternion previewRotation);

		public class GadgetPlacingContext
		{
			public bool instantiateGadget;

			public bool onlyPlaceInOneAxis;

			public Vector3 placingAxis;

			public Vector3 placingUp;

			public Transform transform;

			public GadgetItem item;

			public Transform telegrab;

			public TelegrabBeamAndPointer telegrabBeam;

			public SDK_BaseController.ControllerHand hand;

			public bool isPressed;

			public bool wasPressed;

			public int placementRotationStep;

			public Mount currentlyProcessedMount;

			public AttachmentPosition[] currentlyProcessedPositions;

			public int currentlySelectedPosition;

			public float reachOverride;

			public bool customRaycast;

			public LayerMask customLayerMask;

			public Predicate<RaycastHitDV> customRaycastPredicate;

			public CustomRaycastingDelegate customRaycastingDelegate;

			public CustomUseDelegate customUseDelegate;

			public GadgetBase delayedGadget;

			public VRTK_ControllerReference ControllerReference => VRTK_DeviceFinder.GetControllerReferenceForHand(hand);

			public GadgetPlacingContext(GadgetItem item, bool instantiateGadget, Transform transform, Vector3 placingAxis, Vector3 placingUp, bool onlyPlaceInOneAxis, float reachOverride = 0f)
			{
				this.instantiateGadget = instantiateGadget;
				this.onlyPlaceInOneAxis = onlyPlaceInOneAxis;
				this.placingAxis = placingAxis;
				this.placingUp = placingUp;
				this.transform = transform;
				this.item = item;
				this.reachOverride = reachOverride;
			}

			public void SetupCustomRaycasting(LayerMask layerMask, Predicate<RaycastHitDV> raycastingPredicate, CustomRaycastingDelegate raycastingDelegate, CustomUseDelegate useDelegate)
			{
				customRaycast = true;
				customLayerMask = layerMask;
				customRaycastPredicate = raycastingPredicate;
				customRaycastingDelegate = raycastingDelegate;
				customUseDelegate = useDelegate;
			}

			public void ClearCustomRaycasting()
			{
				customRaycast = false;
				customLayerMask = 0;
				customRaycastingDelegate = null;
				customUseDelegate = null;
			}
		}

		[Serializable]
		public struct Attribute
		{
			public string name;

			public float value;
		}

		private enum UpdateResult : byte
		{
			NoSurface = 0,
			NoTarget = 1,
			InvalidTarget = 2,
			IsObstructed = 3,
			CanPlace = 4
		}

		public const float REACH = 3f;

		public const float HORIZONTAL_SENSITIVITY = 0.05f;

		public const float CHECK_TOLERANCE = 0.005f;

		public const int ROTATION_STEP = 15;

		public const int ROTATION_STEP_COUNT = 24;

		public const string KEY_GADGET_CUSTOM_DATA = "gadgetData";

		public const string KEY_GADGET_POSITION = "position";

		public const string KEY_GADGET_ROTATION = "rotation";

		public const string KEY_GADGET_PLACED_ON = "placedOn";

		public const string LOC_PLACEMENT_OBSTRUCTED = "interaction/gadget_placement/obstructed";

		public const string LOC_PLACEMENT_NOT_SECURED = "interaction/gadget_placement/mount_not_secured";

		public const string LOC_REQUIRES_MOUNT = "interaction/gadget_placement/requires_mount";

		public const string LOC_WRONG_MOUNT_SIZE = "interaction/gadget_placement/wrong_mount_size";

		[SerializeField]
		private GadgetBase gadgetPrefab;

		[SerializeField]
		private Attribute[] customAttributes;

		[SerializeField]
		private Material specificMaterial;

		[Tooltip("In which direction should the normal of the destination surface point")]
		[SerializeField]
		private Vector3 placingAxis = -Vector3.forward;

		[SerializeField]
		private Vector3 placingUp = Vector3.up;

		[SerializeField]
		[Tooltip("If enabled, will use placingAxis and only allow placing in that direction")]
		private bool onlyPlaceInOneAxis;

		private bool place;

		private ItemScrolling scrolling;

		private readonly JObject gadgetData = new JObject();

		private GadgetPlacingContext context;

		public bool OnlyPlaceInOneAxis => onlyPlaceInOneAxis;

		public Vector3 PlacingAxis => placingAxis;

		public GadgetBase GadgetPrefab => gadgetPrefab;

		public GadgetBase Gadget { get; private set; }

		public ItemBase Item { get; private set; }

		public bool IsPressed => context.isPressed;

		public Material SpecificMaterial => specificMaterial;

		protected virtual void Awake()
		{
			if (TryGetComponent<ItemSaveData>(out var component))
			{
				component.ItemSaveDataRequested += OnItemSaveDataRequestedInternal;
				component.ItemSaveDataLoaded += OnItemSaveDataLoadedInternal;
				component.AfterItemSaveDataLoaded += OnAfterItemSaveDataLoadedInternal;
			}
			else
			{
				Debug.LogError("[CUSTOMIZATION] " + base.gameObject.name + " does not have ItemSaveData! This gadget will not serialize!");
			}
			Gadget = UnityEngine.Object.Instantiate(gadgetPrefab);
			Gadget.gameObject.SetActive(value: false);
			Gadget.AssignItem(this);
			if (VRManager.IsVREnabled())
			{
				scrolling = base.gameObject.AddComponent<ItemScrollingVR>();
			}
			else
			{
				scrolling = base.gameObject.AddComponent<ItemScrollingNonVR>();
			}
			scrolling.Scrolled += OnMouseWheelScrolled;
			if (GetComponent<Item>().itemUseApproach != ItemUseApproach.Continuous)
			{
				Debug.LogError($"[CUSTOMIZATION] Gadget Item '{base.gameObject.name}' does not have it's interaction set to '{ItemUseApproach.Continuous}': Placement may not work correctly!");
			}
			context = new GadgetPlacingContext(this, instantiateGadget: false, base.transform, placingAxis, placingUp, onlyPlaceInOneAxis);
		}

		protected virtual void Start()
		{
			Item = GetComponent<ItemBase>();
			if (Item == null)
			{
				Debug.LogError("GadgetItem: ItemBase component not found on " + base.name + ". This should not happen", this);
				return;
			}
			Item.Used += OnUsed;
			Item.UnUsed += OnUnUsed;
			Item.Grabbed += OnGrabbed;
			Item.Ungrabbed += OnUngrabbed;
			base.enabled = false;
			if (Item.IsGrabbed())
			{
				OnGrabbed(null);
			}
		}

		private JObject OnItemSaveDataRequestedInternal(JObject data)
		{
			gadgetData.RemoveAll();
			try
			{
				Gadget.SaveDataRequested(gadgetData);
			}
			catch (Exception exception)
			{
				Debug.LogError("[CUSTOMIZATION] Gadget '" + Item.InventorySpecs.ItemPrefabName + "' could not serialize correctly! Logging exception below.", this);
				Debug.LogException(exception, this);
			}
			data.SetJObject("gadgetData", gadgetData);
			OnItemSaveDataRequested(data);
			if (Gadget.Custom != null)
			{
				data.SetString("placedOn", Gadget.Custom.GetIdentificationKey());
				data.SetVector3("position", Gadget.transform.localPosition);
				data.SetVector3("rotation", Gadget.transform.localEulerAngles);
			}
			else
			{
				data.SetString("placedOn", string.Empty);
			}
			return data;
		}

		private void OnItemSaveDataLoadedInternal(JObject data)
		{
			gadgetData.RemoveAll();
			string text = data.GetString("placedOn");
			if (!string.IsNullOrWhiteSpace(text))
			{
				Vector3? vector = data.GetVector3("position");
				Vector3? vector2 = data.GetVector3("rotation");
				if (vector.HasValue && vector2.HasValue && Customization.TryGetFromIdentificationKey(text, out var result))
				{
					Place(result, vector.Value, Quaternion.Euler(vector2.Value), this);
				}
				else
				{
					SingletonBehaviour<StorageController>.Instance.AddItemToLostAndFound(Item);
					Debug.LogError("[CUSTOMIZATION] Gadget '" + Item.InventorySpecs.ItemPrefabName + "' did not find it's destination, moving to L&F.");
				}
			}
			OnItemSaveDataLoaded(data);
			JObject jObject = data.GetJObject("gadgetData");
			try
			{
				Gadget.SaveDataLoaded(jObject ?? gadgetData);
			}
			catch (Exception exception)
			{
				Debug.LogError("[CUSTOMIZATION] Gadget '" + Item.InventorySpecs.ItemPrefabName + "' could not load correctly! Logging exception below.", this);
				Debug.LogException(exception, this);
			}
		}

		private void OnAfterItemSaveDataLoadedInternal(JObject data)
		{
			try
			{
				Gadget.AfterSaveDataLoaded(data.GetJObject("gadgetData") ?? gadgetData);
			}
			catch (Exception exception)
			{
				Debug.LogError("[CUSTOMIZATION] Gadget '" + Item.InventorySpecs.ItemPrefabName + "' could not load correctly! Logging exception below.", this);
				Debug.LogException(exception, this);
			}
		}

		protected virtual void OnItemSaveDataLoaded(JObject data)
		{
		}

		protected virtual void OnItemSaveDataRequested(JObject data)
		{
		}

		public static GadgetBase Place(Customization destination, Vector3 localPos, Quaternion localRot, GadgetItem gadgetItem, Collider colliderForPlacementData = null)
		{
			gadgetItem.Gadget.transform.SetParent(destination.GetParentingTransform(), worldPositionStays: false);
			gadgetItem.Gadget.transform.localPosition = localPos;
			gadgetItem.Gadget.transform.localRotation = localRot;
			gadgetItem.Gadget.Link(destination);
			gadgetItem.Gadget.gameObject.SetActive(value: true);
			if (colliderForPlacementData != null)
			{
				gadgetItem.Gadget.GeneratePlacementData(colliderForPlacementData);
			}
			if (VRManager.IsVREnabled() && gadgetItem.Item is ItemVRTK itemVRTK)
			{
				itemVRTK.Interactable.ForceStopAllInteractions_Public();
			}
			else
			{
				gadgetItem.Item.ForceEndInteraction();
			}
			SingletonBehaviour<Inventory>.Instance.DropItemFromHandsOrInventory(gadgetItem.Item.gameObject);
			SingletonBehaviour<Inventory>.Instance.PurgeFromInventory(gadgetItem.Item.gameObject);
			SingletonBehaviour<StorageController>.Instance.AddItemToInstalledGadgets(gadgetItem.Item);
			gadgetItem.Item.ForceRemoveFromActivityHandler();
			return gadgetItem.Gadget;
		}

		private static bool CanAttemptRaycastPlace(bool doPlaceRaycast, GadgetPlacingContext c)
		{
			if (!VRManager.IsVREnabled())
			{
				return true;
			}
			if (c.ControllerReference.scriptAlias.GetComponent<VRTK_InteractGrab_DV>().IsGrabButtonPressed() && (c.isPressed || doPlaceRaycast))
			{
				return Globals.G.GameParams.VRRemoteDrivingAllowed;
			}
			return false;
		}

		private static bool TryGetRaycasterTransform(out Transform raycasterTransform, Transform telegrab)
		{
			raycasterTransform = (VRManager.IsVREnabled() ? telegrab : PlayerManager.ActiveCamera.transform);
			return raycasterTransform != null;
		}

		protected virtual void Update()
		{
			if (base.isActiveAndEnabled)
			{
				bool doPlace = place;
				place = false;
				UpdatePlacementForContext(context, doPlace, this);
			}
		}

		public static GadgetBase UpdatePlacementForContext(GadgetPlacingContext context, bool doPlace, MonoBehaviour owner)
		{
			if ((bool)context.delayedGadget)
			{
				GadgetBase delayedGadget = context.delayedGadget;
				context.delayedGadget = null;
				return delayedGadget;
			}
			if (VRManager.IsVREnabled())
			{
				GadgetBase gadgetBase = null;
				if (context.isPressed && !context.wasPressed)
				{
					owner.StartCoroutine(PlaceAfterOneFrame());
				}
				else if (!context.isPressed && context.wasPressed)
				{
					gadgetBase = AttemptPlace(doPlaceRaycast: true, doPlaceOverlap: false, context);
				}
				context.wasPressed = context.isPressed;
				if ((bool)gadgetBase)
				{
					return gadgetBase;
				}
			}
			if (GadgetSystemUtility.AllowGadgetPlacement)
			{
				return AttemptPlace(doPlace && !VRManager.IsVREnabled(), doPlaceOverlap: false, context);
			}
			return null;
			IEnumerator PlaceAfterOneFrame()
			{
				yield return null;
				if (owner.GetComponent<ItemVRTK>().IsGrabbed())
				{
					context.delayedGadget = AttemptPlace(doPlaceRaycast: false, doPlaceOverlap: true, context);
				}
			}
		}

		private static bool PlacementRaycastPredicate(RaycastHitDV h)
		{
			if (h.collider.GetComponent<LocoWindowMesh>() == null)
			{
				return true;
			}
			TrainCar trainCar = TrainCar.Resolve(h.collider.gameObject);
			if (trainCar == null)
			{
				return true;
			}
			if (!trainCar.TryGetComponent<WindowsBreakingController>(out var component))
			{
				return true;
			}
			return !component.windowsBroken;
		}

		private static GadgetBase AttemptPlace(bool doPlaceRaycast, bool doPlaceOverlap, GadgetPlacingContext c)
		{
			CustomizationPlacementMeshes.EnsurePlacingMeshesAreActive();
			if (VRManager.IsVREnabled() && AttemptProximityVRPlace(doPlaceOverlap, c, out var placedGadget))
			{
				return placedGadget;
			}
			if (CanAttemptRaycastPlace(doPlaceRaycast, c) && TryGetRaycasterTransform(out var raycasterTransform, c.telegrab))
			{
				return AttemptRaycastPlace(doPlaceRaycast, raycasterTransform.position, raycasterTransform.forward, c, (c.reachOverride != 0f) ? c.reachOverride : 3f);
			}
			return null;
		}

		private static bool AttemptProximityVRPlace(bool doPlace, GadgetPlacingContext c, out GadgetBase placedGadget)
		{
			if (c.customRaycast && PhysicsQueryBuilder.Raycast(c.transform.position, c.transform.forward, 3f, c.customLayerMask).Where(c.customRaycastPredicate).TryGetFirst(out var hit) && c.customRaycastingDelegate(hit, out var customGadget, out var previewPosition, out var previewRotation, out var previewColor))
			{
				if (doPlace)
				{
					placedGadget = c.customUseDelegate(hit, previewPosition, previewRotation);
				}
				else
				{
					placedGadget = null;
					(customGadget ? customGadget : c.item.gadgetPrefab).DrawHighlight(previewPosition, previewRotation, previewColor);
				}
				return true;
			}
			RaycastHitDV? closestHit = null;
			Quaternion placeRot = default(Quaternion);
			Vector3 placePos = default(Vector3);
			Bounds bounds = c.item.gadgetPrefab.Bounds;
			if (c.onlyPlaceInOneAxis)
			{
				(int, int) valueTuple;
				if (!(c.placingAxis.x > 0f))
				{
					if (!(c.placingAxis.x < 0f))
					{
						if (!(c.placingAxis.y > 0f))
						{
							if (!(c.placingAxis.y < 0f))
							{
								if (!(c.placingAxis.z > 0f))
								{
									if (!(c.placingAxis.z < 0f))
									{
										throw new Exception("PlacingAxis should not be zero!");
									}
									valueTuple = (2, 1);
								}
								else
								{
									valueTuple = (2, -1);
								}
							}
							else
							{
								valueTuple = (1, 1);
							}
						}
						else
						{
							valueTuple = (1, -1);
						}
					}
					else
					{
						valueTuple = (0, 1);
					}
				}
				else
				{
					valueTuple = (0, -1);
				}
				var (axis, direction) = valueTuple;
				CheckSide(axis, direction);
			}
			else
			{
				CheckSide(0, 1);
				CheckSide(0, -1);
				CheckSide(1, 1);
				CheckSide(1, -1);
				CheckSide(2, 1);
				CheckSide(2, -1);
			}
			if (!closestHit.HasValue)
			{
				placedGadget = null;
				return false;
			}
			placeRot *= Quaternion.LookRotation(-c.placingAxis, c.placingUp);
			PhysicsQueryBuilder.QueryResults queryResults = PhysicsQueryBuilder.OverlapBox(placePos + placeRot * c.item.gadgetPrefab.Bounds.center, Vector3.Max(c.item.gadgetPrefab.Bounds.extents, new Vector3(0.001f, 0.001f, 0.001f)), placeRot, (Layers.DVLayerMask.Default | Layers.DVLayerMask.Terrain | Layers.DVLayerMask.Interactable | Layers.DVLayerMask.Gadget_Mesh_Placing).ToLayerMask());
			RaycastHitDV value = default(RaycastHitDV);
			Option<Mount> option = default(Option<Mount>);
			foreach (RaycastHitDV item in queryResults)
			{
				Mount componentInParent = item.collider.GetComponentInParent<Mount>();
				if (!(componentInParent == null))
				{
					if (option.IsSome(out var value2) && value2 != componentInParent)
					{
						option = default(Option<Mount>);
						break;
					}
					value = item;
					option = componentInParent;
				}
			}
			if (option.IsSome())
			{
				closestHit = value;
			}
			placedGadget = TryPlaceOnHit(closestHit.Value, placePos, placeRot, doPlace, c);
			return true;
			void CheckSide(int num, int num2)
			{
				Vector3 direction2 = new Vector3 { [num] = num2 };
				Vector3 vector = c.transform.TransformDirection(direction2);
				if ((from h in PhysicsQueryBuilder.Boxcast(c.transform.TransformPoint(bounds.center), bounds.extents, vector, c.transform.rotation, 0.1f, (Layers.DVLayerMask.Default | Layers.DVLayerMask.Terrain | Layers.DVLayerMask.Interactable | Layers.DVLayerMask.Gadget_Mesh_Placing).ToLayerMask()).Where(PlacementRaycastPredicate)
					where h.collider.GetComponentInParent<GadgetItem>() != c.item
					select h).TryGetFirst(out var hit2) && (!closestHit.HasValue || closestHit.Value.distance > hit2.distance))
				{
					Vector3 position = c.transform.InverseTransformPoint(hit2.point);
					float value3 = GetDistFromCenterToBoundsEdge(num);
					position[num] = value3;
					if (IsAligned(hit2.normal, -vector, out var _))
					{
						if (IsAligned(hit2.normal, c.transform.right, out var dot2))
						{
							Vector3 vector2 = Vector3.Cross(hit2.normal, c.transform.up) * dot2;
							Vector3 upwards = Vector3.Cross(vector2, hit2.normal) * dot2;
							placeRot = Quaternion.LookRotation(vector2, upwards);
						}
						else if (IsAligned(hit2.normal, c.transform.up, out dot2))
						{
							Vector3 forward = Vector3.Cross(c.transform.right, hit2.normal) * dot2;
							placeRot = Quaternion.LookRotation(forward, hit2.normal * dot2);
						}
						else if (IsAligned(hit2.normal, c.transform.forward, out dot2))
						{
							Vector3 upwards2 = Vector3.Cross(hit2.normal, c.transform.right) * dot2;
							placeRot = Quaternion.LookRotation(hit2.normal * dot2, upwards2);
						}
						closestHit = hit2;
						(placePos, _) = TransformUtils.CalculateAlignmentTargets(c.transform.position, c.transform.rotation, hit2.point, placeRot, c.transform.TransformPoint(position), c.transform.rotation);
					}
				}
			}
			float GetDistFromCenterToBoundsEdge(int index)
			{
				return bounds.extents[index] + bounds.center[index];
			}
		}

		private static bool IsAligned(Vector3 a, Vector3 b, out float dot)
		{
			dot = Vector3.Dot(a, b);
			return Mathf.Abs(dot) > 0.707f;
		}

		private static GadgetBase AttemptRaycastPlace(bool doPlace, Vector3 origin, Vector3 forward, GadgetPlacingContext c, float reach = 3f)
		{
			if (c.customRaycast && PhysicsQueryBuilder.Raycast(origin, forward, reach, c.customLayerMask).Where(c.customRaycastPredicate).TryGetFirst(out var hit) && c.customRaycastingDelegate(hit, out var customGadget, out var previewPosition, out var previewRotation, out var previewColor))
			{
				if (doPlace)
				{
					return c.customUseDelegate(hit, previewPosition, previewRotation);
				}
				(customGadget ? customGadget : c.item.gadgetPrefab).DrawHighlight(previewPosition, previewRotation, previewColor);
				return null;
			}
			if (!PhysicsQueryBuilder.Raycast(origin, forward, reach, (Layers.DVLayerMask.Default | Layers.DVLayerMask.Terrain | Layers.DVLayerMask.Interactable | Layers.DVLayerMask.Gadget_Mesh_Placing).ToLayerMask()).Where(PlacementRaycastPredicate).TryGetFirst(out var hit2))
			{
				return null;
			}
			Vector3 normal = hit2.normal;
			Vector3 up = hit2.transform.up;
			float num = Vector3.Dot(normal, up);
			Quaternion rotation = ((num < -0.95f || num > 0.95f) ? Quaternion.LookRotation(-normal, PlayerManager.ActiveCamera.transform.up) : Quaternion.LookRotation(-normal, up));
			if (VRManager.IsVREnabled())
			{
				Vector3 upwards = ((c.ControllerReference.hand == SDK_BaseController.ControllerHand.Right) ? (-c.telegrab.right) : c.telegrab.right);
				rotation = Quaternion.LookRotation(-normal, upwards);
				c.telegrabBeam.OverrideOneFrame(hit2.distance);
			}
			else
			{
				rotation *= Quaternion.AngleAxis(c.placementRotationStep * -15, Vector3.forward);
			}
			Vector3 position = hit2.point + normal * (c.item.gadgetPrefab.Bounds.center.z + c.item.gadgetPrefab.Bounds.extents.z);
			return TryPlaceOnHit(hit2, position, rotation, doPlace, c);
		}

		private static GadgetBase TryPlaceOnHit(RaycastHitDV hit, Vector3 position, Quaternion rotation, bool doPlace, GadgetPlacingContext c)
		{
			GadgetBase componentInParent = hit.collider.GetComponentInParent<GadgetBase>();
			Mount mount = ((componentInParent != null) ? componentInParent.GetComponent<Mount>() : null);
			Vector3 visualPosition = default(Vector3);
			UpdateVisualPosition();
			Vector3 targetNormal = rotation * Vector3.up;
			if (!GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.MountingGadgets) || !SingletonBehaviour<GadgetSystemUtility>.Instance.CheckGadgetAgainstRestrictions(c.item.Item) || !SingletonBehaviour<GadgetSystemUtility>.Instance.CheckPlacementAgainstRestrictions(position, targetNormal))
			{
				c.item.gadgetPrefab.DrawHighlight(visualPosition, rotation, GadgetSystemUtility.COLOR_HIGHLIGHT_BAD);
				return null;
			}
			if (!hit.collider.gameObject.layer.ToDVLayerEnum().ToDVLayerMask().HasAnyFlag(Layers.DVLayerMask.Default | Layers.DVLayerMask.Terrain | Layers.DVLayerMask.Gadget_Mesh_Placing) && mount == null)
			{
				c.item.gadgetPrefab.DrawHighlight(visualPosition, rotation, GadgetSystemUtility.COLOR_HIGHLIGHT_BAD);
				return null;
			}
			if (mount != null && c.item.gadgetPrefab.TryGetComponent<Mount>(out var _))
			{
				c.item.gadgetPrefab.DrawHighlight(visualPosition, rotation, GadgetSystemUtility.COLOR_HIGHLIGHT_BAD);
				return null;
			}
			if (c.currentlyProcessedMount != mount)
			{
				c.currentlyProcessedMount = mount;
				c.currentlyProcessedPositions = mount?.GetAttachmentPositions(c.item.Gadget);
			}
			bool flag = false;
			bool flag2 = mount != null && mount.Accepts(c.item.Gadget);
			if (mount == null || c.item.gadgetPrefab.RequiredMountPoints == 0 || (c.item.gadgetPrefab.RequiredMountPoints > 0 && c.currentlyProcessedPositions.Length == 0 && !flag2))
			{
				c.currentlyProcessedMount = null;
				c.currentlyProcessedPositions = null;
				if (c.item.gadgetPrefab.RequiredMountPoints > 0)
				{
					c.item.gadgetPrefab.DrawHighlight(visualPosition, rotation, GadgetSystemUtility.COLOR_HIGHLIGHT_BAD);
					if (!VRManager.IsVREnabled())
					{
						SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(LocalizationAPI.L("interaction/gadget_placement/requires_mount"));
					}
					return null;
				}
				mount = null;
			}
			else
			{
				if (c.currentlyProcessedPositions == null || c.currentlyProcessedPositions.Length == 0 || (componentInParent.TryGetComponent<Drillable>(out var component2) && component2.MountPointCount < c.item.gadgetPrefab.RequiredMountPoints))
				{
					c.item.gadgetPrefab.DrawHighlight(visualPosition, rotation, GadgetSystemUtility.COLOR_HIGHLIGHT_BAD);
					if (!VRManager.IsVREnabled() && flag2)
					{
						SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(LocalizationAPI.L("interaction/gadget_placement/wrong_mount_size"));
					}
					return null;
				}
				if (VRManager.IsVREnabled())
				{
					Vector3 localPos = c.currentlyProcessedMount.transform.InverseTransformPoint(position);
					Quaternion localRot = Quaternion.Inverse(c.currentlyProcessedMount.transform.rotation) * rotation;
					bool flag3 = false;
					using (IEnumerator<AttachmentPosition> enumerator = (from p in c.currentlyProcessedPositions.Where(delegate(AttachmentPosition p)
						{
							if (Vector3.Angle(p.rotation * Vector3.forward, localRot * Vector3.forward) > 45f)
							{
								return false;
							}
							if (Vector3.Angle(p.rotation * Vector3.up, localRot * Vector3.up) > 45f)
							{
								return false;
							}
							return !(Vector3.Distance(localPos, p.offset) > 0.1f);
						})
						orderby Vector3.SqrMagnitude(p.offset - localPos)
						select p).GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							AttachmentPosition current = enumerator.Current;
							flag3 = true;
							position = c.currentlyProcessedMount.AttachmentTransform(current, out rotation);
							UpdateVisualPosition();
						}
					}
					if (!flag3)
					{
						c.item.gadgetPrefab.DrawHighlight(visualPosition, rotation, GadgetSystemUtility.COLOR_HIGHLIGHT_BAD);
						return null;
					}
				}
				else
				{
					int num = c.currentlyProcessedPositions.Length;
					c.currentlySelectedPosition = Mathf.RoundToInt(Mathf.Repeat(c.currentlySelectedPosition, num));
					position = c.currentlyProcessedMount.AttachmentTransform(c.currentlyProcessedPositions[c.currentlySelectedPosition], out rotation);
					UpdateVisualPosition();
				}
				if (mount.IsInUse || (componentInParent.TryGetComponent<Drillable>(out component2) && component2.AttachedPointCount < c.item.gadgetPrefab.RequiredMountPoints))
				{
					if (!mount.IsInUse && !VRManager.IsVREnabled())
					{
						SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(LocalizationAPI.L("interaction/gadget_placement/mount_not_secured"));
					}
					flag = true;
				}
			}
			Customization customization = Customization.Resolve(hit.transform.gameObject);
			if (customization == null)
			{
				c.item.gadgetPrefab.DrawHighlight(visualPosition, rotation, GadgetSystemUtility.COLOR_HIGHLIGHT_BAD);
				return null;
			}
			if (!SingletonBehaviour<GadgetSystemUtility>.Instance.StrictPlacementMode && (!CanPlace(position, rotation, c.item.gadgetPrefab) || customization.IsHole(hit.collider)))
			{
				if (!VRManager.IsVREnabled())
				{
					SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(LocalizationAPI.L("interaction/gadget_placement/obstructed"));
				}
				c.item.gadgetPrefab.DrawHighlight(visualPosition, rotation, GadgetSystemUtility.COLOR_HIGHLIGHT_MAYBE);
				return null;
			}
			if (flag)
			{
				c.item.gadgetPrefab.DrawHighlight(visualPosition, rotation, GadgetSystemUtility.COLOR_HIGHLIGHT_NOT_YET);
				return null;
			}
			c.item.gadgetPrefab.DrawHighlight(visualPosition, rotation, GadgetSystemUtility.COLOR_HIGHLIGHT_GOOD);
			if (doPlace && TryPlace(customization, position, rotation, c.item, hit.collider, c.instantiateGadget, out var gadget))
			{
				if (mount != null)
				{
					mount.MountGadget(gadget);
				}
				if (c.item.gadgetPrefab.AutoPlaySoundOnPlaced)
				{
					((c.item.gadgetPrefab.SoundOnPlaced != null) ? c.item.gadgetPrefab.SoundOnPlaced : SingletonBehaviour<GadgetSystemUtility>.Instance.SoundOnGadgetPlaced).Play(position);
				}
				return gadget;
			}
			return null;
			void UpdateVisualPosition()
			{
				visualPosition = position;
				if ((bool)PlayerManager.Car)
				{
					visualPosition += PlayerManager.Car.GetNextInteriorPositionOffset();
				}
			}
		}

		public static bool CanPlace(Vector3 position, Quaternion rotation, GadgetBase gadget)
		{
			return !Physics.CheckBox(position + rotation * gadget.Bounds.center, Vector3.Max(gadget.Bounds.extents - new Vector3(0.005f, 0.005f, 0.005f), new Vector3(0.001f, 0.001f, 0.001f)), rotation, (Layers.DVLayerMask.Default | Layers.DVLayerMask.Terrain | Layers.DVLayerMask.Interactable | Layers.DVLayerMask.Gadget_Mesh_Placing).ToLayerMask(), QueryTriggerInteraction.Ignore);
		}

		public static bool TryPlace(Customization destination, Vector3 position, Quaternion rotation, GadgetItem gadgetItem, Collider colliderForPlacementData, bool instantiateGadget, out GadgetBase gadget)
		{
			gadget = null;
			if (!CanPlace(position, rotation, gadgetItem.gadgetPrefab))
			{
				return false;
			}
			Transform parentingTransform = destination.GetParentingTransform();
			Vector3 localPos = parentingTransform.InverseTransformPoint(position);
			Quaternion localRot = Quaternion.Inverse(parentingTransform.rotation) * rotation;
			GadgetItem gadgetItem2;
			if (instantiateGadget)
			{
				gadgetItem2 = UnityEngine.Object.Instantiate(gadgetItem);
				gadgetItem2.Item = gadgetItem2.GetComponent<ItemBase>();
			}
			else
			{
				gadgetItem2 = gadgetItem;
			}
			gadget = Place(destination, localPos, localRot, gadgetItem2, colliderForPlacementData);
			return true;
		}

		public bool AttributeQuery(string name, out float value)
		{
			value = 0f;
			if (customAttributes == null)
			{
				return false;
			}
			for (int i = 0; i < customAttributes.Length; i++)
			{
				if (string.Equals(customAttributes[i].name, name, StringComparison.InvariantCultureIgnoreCase))
				{
					value = customAttributes[i].value;
					return true;
				}
			}
			return false;
		}

		private void OnMouseWheelScrolled(ScrollAction action)
		{
			int num = 0;
			if (action == ScrollAction.ScrollRight || action == ScrollAction.ScrollDown)
			{
				num++;
			}
			if (action == ScrollAction.ScrollLeft || action == ScrollAction.ScrollUp)
			{
				num--;
			}
			if (context.currentlyProcessedMount != null)
			{
				context.currentlySelectedPosition += num;
				return;
			}
			context.placementRotationStep += num;
			if (context.placementRotationStep < 0)
			{
				context.placementRotationStep += 24;
			}
			if (context.placementRotationStep >= 24)
			{
				context.placementRotationStep -= 24;
			}
		}

		private void OnUsed()
		{
			place = true;
			context.isPressed = true;
		}

		private void OnUnUsed()
		{
			context.isPressed = false;
		}

		private void OnGrabbed(object _)
		{
			Cleanup();
			base.enabled = true;
			if (VRManager.IsVREnabled())
			{
				GameObject grabbingObject = base.gameObject.GetComponent<ItemVRTK>().Interactable.GetGrabbingObject();
				context.hand = VRTK_DeviceFinder.GetControllerHand(grabbingObject);
				context.telegrab = context.ControllerReference.scriptAlias.transform.Find("[telegrab]");
				context.telegrabBeam = context.telegrab.GetComponentInChildren<TelegrabBeamAndPointer>(includeInactive: true);
			}
		}

		private void OnUngrabbed(object _)
		{
			base.enabled = false;
			Cleanup();
		}

		private void Cleanup()
		{
			place = false;
			context.isPressed = false;
			context.wasPressed = false;
			context.placementRotationStep = 0;
			context.currentlyProcessedMount = null;
			context.currentlyProcessedPositions = null;
		}
	}
}
