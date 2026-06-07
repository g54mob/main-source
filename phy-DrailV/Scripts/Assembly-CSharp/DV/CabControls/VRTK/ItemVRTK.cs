using DV.CabControls.Spec;
using DV.InventorySystem;
using DV.Items;
using DV.Items.Snapping;
using DV.Utils;
using DV.VFX;
using TMPro;
using UnityEngine;
using VRTK;
using VRTK.GrabAttachMechanics;
using VRTK.SecondaryControllerGrabActions;

namespace DV.CabControls.VRTK
{
	public class ItemVRTK : ItemBase, IInteractionStyleTarget
	{
		private bool isTwoHanded;

		private Item spec;

		private VRTK_InteractUse currentUse;

		private bool usePressedAtUi;

		public VRTK_ControlImplBaseInteractableObject Interactable { get; private set; }

		public Transform GrabAnchorLeft { get; private set; }

		public Transform GrabAnchorRight { get; private set; }

		public override bool IsTwoHanded => isTwoHanded;

		public Transform ForceDropTransform { get; private set; }

		public override void AssignForceDropAnchor(Transform forceDropTransform)
		{
			ForceDropTransform = forceDropTransform;
		}

		protected override void Setup()
		{
			spec = base.SpecItem;
			Interactable = base.gameObject.AddComponent<VRTK_ControlImplBaseInteractableObject>();
			ItemUseApproach itemUseApproach = spec.itemUseApproach;
			bool flag = itemUseApproach != ItemUseApproach.None && itemUseApproach != ItemUseApproach.OneShotNonVROnly;
			Interactable.isUsable = flag;
			Interactable.useOnlyIfGrabbed = flag;
			Interactable.continuousUse = useApproach == ItemUseApproach.Continuous;
			Interactable.isGrabbable = true;
			Interactable.priority = spec.interactionPriority;
			Interactable.pipaExclusiveInteraction = spec.pipaExclusiveInteraction;
			Interactable.controlImplBase = this;
			Interactable.interactionHandPoses = GenerateHandPoses();
			Interactable.InteractableObjectGrabbed += OnInteractableObjectGrabbed;
			Interactable.InteractableObjectUngrabbed += OnInteractableObjectUngrabbed;
			Interactable.InteractableObjectUsed += delegate
			{
				if (!InventoryViewVR.IsPointingAtUI && !usePressedAtUi)
				{
					Use();
				}
			};
			Interactable.InteractableObjectUnused += delegate
			{
				UnUse();
			};
			TelegrabbableItem telegrabbableItem = Telegrabbable.MakeTelegrabbable<TelegrabbableItem>(base.gameObject);
			telegrabbableItem.item = this;
			telegrabbableItem.rb = GetComponent<Rigidbody>();
			isTwoHanded = false;
			VRTK_BaseGrabAttach vRTK_BaseGrabAttach;
			VRTK_BaseGrabAction secondaryGrabActionScript;
			switch (spec.controllerAttachMethod)
			{
			case ItemControllerAttachMethod.NonPhysicsTracking:
				vRTK_BaseGrabAttach = base.gameObject.AddComponent<VRTK_TrackObjectGrabAttach>();
				secondaryGrabActionScript = base.gameObject.AddComponent<VRTK_SwapControllerGrabAction>();
				break;
			case ItemControllerAttachMethod.ReparentToController:
				vRTK_BaseGrabAttach = base.gameObject.AddComponent<VRTK_ChildOfControllerGrabAttach>();
				secondaryGrabActionScript = base.gameObject.AddComponent<VRTK_SwapControllerGrabAction>();
				break;
			case ItemControllerAttachMethod.FixedJoint:
				vRTK_BaseGrabAttach = base.gameObject.AddComponent<VRTK_FixedJointGrabAttach>();
				secondaryGrabActionScript = base.gameObject.AddComponent<VRTK_SwapControllerGrabAction>();
				break;
			case ItemControllerAttachMethod.TwoHandedPole:
				isTwoHanded = true;
				vRTK_BaseGrabAttach = base.gameObject.AddComponent<VRTK_TwoHandedPoleGrab>();
				secondaryGrabActionScript = base.gameObject.AddComponent<VRTK_TwoHandedPoleSecondaryGrab>();
				break;
			default:
				vRTK_BaseGrabAttach = base.gameObject.AddComponent<VRTK_TrackObjectGrabAttach>();
				secondaryGrabActionScript = base.gameObject.AddComponent<VRTK_SwapControllerGrabAction>();
				Debug.LogError("Should never get here", this);
				break;
			}
			Interactable.grabAttachMechanicScript = vRTK_BaseGrabAttach;
			Interactable.secondaryGrabActionScript = secondaryGrabActionScript;
			vRTK_BaseGrabAttach.precisionGrab = spec.precisionGrab;
			SetupAttachPoint(vRTK_BaseGrabAttach);
			if (isTwoHanded)
			{
				base.gameObject.AddComponent<CarryTwoHandedItemAfterTeleportVRTK>();
			}
			else
			{
				base.gameObject.AddComponent<CarryItemAfterTeleportVRTK>();
			}
			TextMeshPro[] componentsInChildren = GetComponentsInChildren<TextMeshPro>(includeInactive: true);
			foreach (TextMeshPro textMeshPro in componentsInChildren)
			{
				if (!(textMeshPro.fontMaterial.shader != SingletonBehaviour<MaterialUtils>.Instance.DistanceFieldSurfaceShader))
				{
					textMeshPro.gameObject.AddComponent<ItemTransparencyTextDisabler>();
				}
			}
			base.AboutToBeDestroyed += OnAboutToBeDestroyed;
		}

		private void OnAboutToBeDestroyed(ItemBase _)
		{
			if (!UnloadWatcher.isUnloading && currentUse != null)
			{
				currentUse.UseButtonPressed -= OnUseButtonPressed;
			}
		}

		private void OnInteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
		{
			if (currentUse != null)
			{
				currentUse.UseButtonPressed -= OnUseButtonPressed;
			}
			currentUse = e.interactingObject.GetComponentInParent<VRTK_InteractUse>();
			if (currentUse != null)
			{
				currentUse.UseButtonPressed += OnUseButtonPressed;
			}
			FireGrabbed();
		}

		private void OnUseButtonPressed(object sender, ControllerInteractionEventArgs e)
		{
			usePressedAtUi = InventoryViewVR.IsPointingAtUI;
		}

		private void OnInteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
		{
			if (currentUse != null)
			{
				currentUse.UseButtonPressed -= OnUseButtonPressed;
				currentUse = null;
			}
			usePressedAtUi = false;
			FireUngrabbed();
		}

		private void SetupAttachPoint(VRTK_BaseGrabAttach attach)
		{
			Transform transform = base.transform.Find("[anchor]");
			Transform transform2 = base.transform.Find("[left anchor]");
			Transform transform3 = base.transform.Find("[right anchor]");
			if ((bool)transform2 && (bool)transform3)
			{
				if (!attach.precisionGrab)
				{
					attach.leftSnapHandle = transform2;
					attach.rightSnapHandle = transform3;
				}
				GrabAnchorLeft = transform2;
				GrabAnchorRight = transform3;
			}
			else if ((bool)transform)
			{
				if (!attach.precisionGrab)
				{
					attach.leftSnapHandle = transform;
					attach.rightSnapHandle = transform;
				}
				GrabAnchorLeft = transform;
				GrabAnchorRight = transform;
			}
		}

		protected override void AddItemReparenting()
		{
			base.gameObject.AddComponent<ItemReparentingVRTK>();
		}

		public override bool IsGrabbed()
		{
			return Interactable.IsGrabbed();
		}

		public override void ForceEndInteraction()
		{
			Interactable.ForceStopInteracting();
		}

		public GameObject GetGrabbingObject()
		{
			return Interactable.GetGrabbingObject();
		}

		protected override void FireGrabbed()
		{
			Interactable.GetPreviousState(out var previousParent, out var _, out var previousGrabbable);
			ItemSnapPointBase itemSnapPointBase = (base.IsSnapped ? base.SnappableItem.SnappedTo : null);
			if (itemSnapPointBase != null)
			{
				itemSnapPointBase.UnsnapItem();
			}
			Interactable.OverridePreviousState(previousParent, previousKinematic: false, previousGrabbable);
			base.FireGrabbed();
		}
	}
}
