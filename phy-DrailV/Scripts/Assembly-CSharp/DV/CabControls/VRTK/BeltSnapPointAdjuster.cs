using System.Collections.Generic;
using DV.CabControls.Spec;
using DV.Interaction;
using DV.Items.Snapping;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;
using VRTK.GrabAttachMechanics;
using VRTK.SecondaryControllerGrabActions;

namespace DV.CabControls.VRTK
{
	public class BeltSnapPointAdjuster : ControlImplBase, IInteractableTag
	{
		private ItemSnapPointVisualController visualController;

		private ItemSnapPointBase snapPoint;

		private float maxDistanceSquared;

		private Transform initialParent;

		private Vector3 initialLocalPosition;

		private Quaternion initialLocalRotation;

		private Quaternion initialSnapPointLocalRotation;

		private VRTK_InteractGrab_DV grabRight;

		private VRTK_InteractGrab_DV grabLeft;

		private Collider[] overlapCache = new Collider[16];

		private float overlapRadius;

		private float depenetrationAdjustment = 0.01f;

		private HashSet<BeltSnapPointAdjuster> otherBeltAdjusters = new HashSet<BeltSnapPointAdjuster>();

		private bool tooFar;

		private bool validPosition = true;

		private BeltAdjuster spec;

		public VRTK_ControlImplBaseInteractableObject Interactable { get; private set; }

		public InteractableTag InteractableTag => InteractableTag.BeltSlot;

		protected override InteractionHandPoses GenericHandPoses { get; } = new InteractionHandPoses(HandPose.PreGrab, HandPose.PreGrab, HandPose.Grab);

		private void Awake()
		{
			if (!VRManager.IsVREnabled())
			{
				Debug.LogError("BeltSnapPointAdjuster is only supported in VR. Destroying self.");
				Object.Destroy(this);
				return;
			}
			spec = GetComponent<BeltAdjuster>();
			if (spec == null)
			{
				Debug.LogError("BeltSnapPointAdjuster requires a BeltAdjuster component. Destroying self.");
				Object.Destroy(this);
				return;
			}
			snapPoint = ((spec.snapPointGameObject != null) ? spec.snapPointGameObject.GetComponent<ItemSnapPointBase>() : null);
			if (snapPoint == null)
			{
				Debug.LogError("BeltSnapPointAdjuster requires a valid ItemSnapPointBelt reference. Destroying self.");
				Object.Destroy(this);
				return;
			}
			if (spec.collisionCollider == null)
			{
				Debug.LogError("BeltSnapPointAdjuster requires a SphereCollider. Destroying self.");
				Object.Destroy(this);
				return;
			}
			visualController = ((spec.visualControllerGameObject != null) ? spec.visualControllerGameObject.GetComponent<ItemSnapPointVisualController>() : null);
			if (visualController == null)
			{
				Debug.LogError("BeltSnapPointAdjuster requires a valid ItemSnapPointVisualController reference. Destroying self.");
				Object.Destroy(this);
				return;
			}
			maxDistanceSquared = spec.maxDistance * spec.maxDistance;
			initialParent = base.transform.parent;
			initialLocalPosition = base.transform.localPosition;
			initialLocalRotation = base.transform.localRotation;
			initialSnapPointLocalRotation = snapPoint.transform.localRotation;
			overlapRadius = spec.collisionCollider.radius;
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Register(OnControlsSet);
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		private void OnControlsSet(SDK_BaseController.ControllerHand hand)
		{
			if (hand == SDK_BaseController.ControllerHand.Left && grabLeft == null)
			{
				grabLeft = VRTK_DeviceFinder.GetControllerLeftHand(getActual: true).GetComponent<VRTK_InteractGrab_DV>();
			}
			else if (hand == SDK_BaseController.ControllerHand.Right && grabRight == null)
			{
				grabRight = VRTK_DeviceFinder.GetControllerRightHand(getActual: true).GetComponent<VRTK_InteractGrab_DV>();
			}
			if (grabLeft != null && grabRight != null)
			{
				SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
			}
		}

		protected override void Start()
		{
			Interactable = base.gameObject.AddComponent<VRTK_ControlImplBaseInteractableObject>();
			Interactable.grabAttachMechanicScript = base.gameObject.AddComponent<VRTK_ChildOfControllerGrabAttach>();
			Interactable.grabAttachMechanicScript.precisionGrab = true;
			Interactable.secondaryGrabActionScript = base.gameObject.AddComponent<VRTK_SwapControllerGrabAction>();
			Interactable.isGrabbable = snapPoint.SnappedItem == null;
			Interactable.holdButtonToGrab = true;
			Interactable.priority = -1;
			Interactable.pipaExclusiveInteraction = true;
			Interactable.controlImplBase = this;
			Interactable.interactionHandPoses = GenerateHandPoses();
			SetupListeners(on: true);
		}

		public void SetInteractable(bool on)
		{
			Interactable.controlImplBase.InteractionAllowed = on;
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isQuitting)
			{
				VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
				SetupListeners(on: false);
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				Interactable.InteractableObjectGrabbed += OnGrabbed;
				Interactable.InteractableObjectUngrabbed += OnUngrabbed;
				snapPoint.ItemSnappedChanged += OnSnappedChanged;
				SingletonBehaviour<AppUtil>.Instance.GamePaused += OnGamePaused;
				SingletonBehaviour<AppUtil>.Instance.GameUnpaused += OnGameUnpaused;
				return;
			}
			if (Interactable != null)
			{
				Interactable.InteractableObjectGrabbed -= OnGrabbed;
				Interactable.InteractableObjectUngrabbed -= OnUngrabbed;
			}
			if (snapPoint != null)
			{
				snapPoint.ItemSnappedChanged -= OnSnappedChanged;
			}
			if (SingletonBehaviour<AppUtil>.Instance != null)
			{
				SingletonBehaviour<AppUtil>.Instance.GamePaused -= OnGamePaused;
				SingletonBehaviour<AppUtil>.Instance.GameUnpaused -= OnGameUnpaused;
			}
		}

		private void OnSnappedChanged(ItemSnapPointBase snapPointBase, ItemBase item, bool snapped, bool forced)
		{
			Interactable.isGrabbable = !snapped;
		}

		private void OnGamePaused()
		{
			if (Interactable.IsGrabbed())
			{
				Interactable.ForceStopInteracting();
			}
			Interactable.isGrabbable = false;
		}

		private void OnGameUnpaused()
		{
			Interactable.isGrabbable = snapPoint.SnappedItem == null;
		}

		private void OnGrabbed(object sender, InteractableObjectEventArgs e)
		{
			FireGrabbed();
			UpdateOverlaps(base.transform.position, clearCache: false);
			visualController.grabbed = true;
			visualController.UpdateDirectionGuideVisibility(on: true);
		}

		private void OnUngrabbed(object sender, InteractableObjectEventArgs e)
		{
			FireUngrabbed();
			UpdatePosition(base.transform.localPosition);
			visualController.grabbed = false;
			visualController.UpdateDirectionGuideVisibility(on: false);
		}

		public void UpdatePosition(Vector3 localPos)
		{
			Vector3 vector = initialParent.TransformPoint(localPos);
			if (tooFar)
			{
				Vector3 vector2 = initialParent.TransformPoint(initialLocalPosition);
				Vector3 normalized = (vector - vector2).normalized;
				vector = vector2 + normalized * spec.maxDistance;
				UpdateOverlaps(vector, clearCache: true);
			}
			if (otherBeltAdjusters.Count == 1)
			{
				BeltSnapPointAdjuster beltSnapPointAdjuster = null;
				foreach (BeltSnapPointAdjuster otherBeltAdjuster in otherBeltAdjusters)
				{
					beltSnapPointAdjuster = otherBeltAdjuster;
				}
				Vector3 vector3 = (vector - beltSnapPointAdjuster.transform.position).normalized;
				if (vector3 == Vector3.zero)
				{
					vector3 = Vector3.up;
				}
				vector = beltSnapPointAdjuster.transform.position + vector3 * (overlapRadius * 2f + depenetrationAdjustment);
				UpdateOverlaps(vector, clearCache: false);
			}
			if (otherBeltAdjusters.Count > 1)
			{
				Vector3 vector4 = Vector3.zero;
				BeltSnapPointAdjuster beltSnapPointAdjuster2 = null;
				foreach (BeltSnapPointAdjuster otherBeltAdjuster2 in otherBeltAdjusters)
				{
					vector4 += otherBeltAdjuster2.transform.position;
					if (beltSnapPointAdjuster2 == null)
					{
						beltSnapPointAdjuster2 = otherBeltAdjuster2;
					}
				}
				vector4 /= (float)otherBeltAdjusters.Count;
				if (beltSnapPointAdjuster2 != null)
				{
					Vector3 normalized2 = (vector - vector4).normalized;
					Vector3 vector5 = beltSnapPointAdjuster2.transform.position - vector4;
					Vector3 normalized3 = vector5.normalized;
					Vector3 vector6 = Vector3.Cross(normalized2, normalized3);
					if (vector6 == Vector3.zero)
					{
						Debug.LogError("Collinearity triggered");
						vector6 = ((!(normalized3 != Vector3.up) || !(normalized3 != Vector3.down)) ? Vector3.Cross(Vector3.forward, normalized3) : Vector3.Cross(Vector3.up, normalized3));
					}
					Vector3 normalized4 = Vector3.Cross(normalized3, vector6).normalized;
					float num = overlapRadius * 2f + depenetrationAdjustment;
					float num2 = num * num;
					float num3;
					if (num2 >= vector5.sqrMagnitude)
					{
						num3 = Mathf.Sqrt(num2 - vector5.sqrMagnitude);
					}
					else
					{
						num3 = num * 0.707106f;
						vector4 = beltSnapPointAdjuster2.transform.position - normalized3 * num3;
					}
					Vector3 vector7 = normalized4 * num3;
					vector = vector4 + vector7;
				}
				else
				{
					Debug.LogError("Could not properly calculate depenetration direction for BeltSnapPointAdjuster due to missing overlaps. This should not happen. Resetting to initial position", this);
					vector = initialParent.TransformPoint(initialLocalPosition);
				}
				otherBeltAdjusters.Clear();
			}
			base.transform.position = vector;
			UpdateValidPositionState(state: true);
			SnapRotation();
			UpdateSnapPointTransform();
			visualController.UpdateDirectionGuideVisibility(on: false);
		}

		private void SnapRotation()
		{
			bool flag = false;
			float num = (base.transform.localEulerAngles.x + 360f) % 360f;
			float num2 = (base.transform.localEulerAngles.y + 360f) % 360f;
			float num3 = (base.transform.localEulerAngles.z + 360f) % 360f;
			float num4 = 90f - num % 90f;
			if (num4 > spec.angleSnappingThreshold)
			{
				num4 -= 90f;
			}
			float num5 = 90f - num2 % 90f;
			if (num5 > spec.angleSnappingThreshold)
			{
				num5 -= 90f;
			}
			float num6 = 90f - num3 % 90f;
			if (num6 > spec.angleSnappingThreshold)
			{
				num6 -= 90f;
			}
			if (num4 >= 0f - spec.angleSnappingThreshold && num4 <= spec.angleSnappingThreshold)
			{
				num += num4;
				flag = true;
			}
			if (num5 >= 0f - spec.angleSnappingThreshold && num5 <= spec.angleSnappingThreshold)
			{
				num2 += num5;
				flag = true;
			}
			if (num6 >= 0f - spec.angleSnappingThreshold && num6 <= spec.angleSnappingThreshold)
			{
				num3 += num6;
				flag = true;
			}
			if (flag)
			{
				base.transform.localRotation = Quaternion.Euler(new Vector3(num, num2, num3));
			}
		}

		private void UpdateOverlaps(Vector3 overlapCenter, bool clearCache)
		{
			if (clearCache)
			{
				otherBeltAdjusters.Clear();
			}
			int num = Physics.OverlapSphereNonAlloc(overlapCenter, overlapRadius + depenetrationAdjustment, overlapCache, LayerMask.GetMask("Controller"));
			for (int i = 0; i < num; i++)
			{
				BeltSnapPointAdjuster component = overlapCache[i].GetComponent<BeltSnapPointAdjuster>();
				if (component != null && component != this)
				{
					otherBeltAdjusters.Add(component);
				}
			}
		}

		public override bool IsGrabbed()
		{
			return Interactable.IsGrabbed();
		}

		public override void ForceEndInteraction()
		{
			if (Interactable == null)
			{
				Debug.LogError("Trying to force end interaction on BeltSnapPointAdjuster but it is not currently grabbed");
			}
			else
			{
				Interactable.ForceStopInteracting();
			}
		}

		private void Update()
		{
			if (IsGrabbed())
			{
				UpdateOverlaps(base.transform.position, clearCache: true);
				tooFar = (initialParent.TransformPoint(initialLocalPosition) - base.transform.position).sqrMagnitude >= maxDistanceSquared;
				bool flag = !tooFar && otherBeltAdjusters.Count == 0;
				UpdateSnapPointTransform();
				if (validPosition != flag)
				{
					UpdateValidPositionState(flag);
				}
			}
		}

		private void UpdateSnapPointTransform()
		{
			Transform transform = ((snapPoint != null) ? snapPoint.transform : null);
			if (!(transform == null))
			{
				transform.position = base.transform.position;
				UpdateSnapPointRotation(transform);
			}
		}

		public void UpdateSnapPointRotation()
		{
			Transform transform = ((snapPoint != null) ? snapPoint.transform : null);
			if (!(transform == null))
			{
				UpdateSnapPointRotation(transform);
			}
		}

		private void UpdateSnapPointRotation(Transform snapPointTransform)
		{
			snapPointTransform.rotation = base.transform.rotation;
			snapPointTransform.localRotation *= initialSnapPointLocalRotation;
		}

		private void UpdateValidPositionState(bool state)
		{
			validPosition = state;
			visualController.ToggleColor(state);
		}

		public void Reset()
		{
			base.transform.localRotation = initialLocalRotation;
			UpdatePosition(initialLocalPosition);
		}

		protected override void AcceptSetValue(float newValue)
		{
		}
	}
}
