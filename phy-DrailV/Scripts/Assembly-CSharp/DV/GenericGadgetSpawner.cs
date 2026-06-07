using DV.CabControls;
using DV.CabControls.VRTK;
using DV.Customization.Gadgets;
using UnityEngine;
using VRTK;

namespace DV
{
	public abstract class GenericGadgetSpawner : MonoBehaviour
	{
		[SerializeField]
		[Header("Gadget spawning settings")]
		private GadgetItem gadgetToPlace;

		[SerializeField]
		[Tooltip("In which direction should the normal of the destination surface point")]
		private Vector3 placingAxis = -Vector3.forward;

		[SerializeField]
		private Vector3 placingUp = Vector3.up;

		[SerializeField]
		[Tooltip("If enabled, will use placingAxis and only allow placing in that direction")]
		private bool onlyPlaceInOneAxis;

		[SerializeField]
		[Tooltip("Use mouse wheel or VR joystick to rotate the gadget preview while placing")]
		private bool allowRotation;

		[SerializeField]
		[Tooltip("Transform which is used as a reference during the gadget placement (optional)")]
		private Transform interactionOrigin;

		[SerializeField]
		[Tooltip("Raycasting distance for placement, leave at 0 to use internal defaults")]
		private float reachOverride;

		private ItemBase item;

		private bool place;

		protected GadgetItem.GadgetPlacingContext context;

		private ItemScrolling scrolling;

		public Transform InteractionOrigin => interactionOrigin ?? base.transform;

		private void Awake()
		{
			context = new GadgetItem.GadgetPlacingContext(gadgetToPlace, instantiateGadget: true, InteractionOrigin, placingAxis, placingUp, onlyPlaceInOneAxis, reachOverride);
		}

		private void Start()
		{
			item = GetComponent<ItemBase>();
			if (item == null)
			{
				Debug.LogError("LabelMakerController: ItemBase component not found on " + base.name + ". This should not happen", this);
				return;
			}
			item.Used += OnUsed;
			item.UnUsed += OnUnUsed;
			item.Grabbed += OnGrabbed;
			item.Ungrabbed += OnUngrabbed;
			if (VRManager.IsVREnabled())
			{
				scrolling = base.gameObject.AddComponent<ItemScrollingVR>();
			}
			else
			{
				scrolling = base.gameObject.AddComponent<ItemScrollingNonVR>();
			}
			scrolling.Scrolled += OnMouseWheelScrolled;
			base.enabled = false;
			OnInitialize();
		}

		protected virtual void OnInitialize()
		{
		}

		protected virtual void InternalOnUsed()
		{
		}

		protected virtual void InternalOnUnUsed()
		{
		}

		protected virtual void InternalUpdate()
		{
		}

		protected virtual void OnGadgetPlaced(GadgetBase gadget)
		{
		}

		private void OnUsed()
		{
			place = true;
			context.isPressed = true;
			InternalOnUsed();
		}

		private void OnUnUsed()
		{
			context.isPressed = false;
			InternalOnUnUsed();
		}

		private void OnGrabbed(ControlImplBase obj)
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

		private void OnUngrabbed(ControlImplBase obj)
		{
			base.enabled = false;
			Cleanup();
		}

		private void OnMouseWheelScrolled(ScrollAction action)
		{
			if (!allowRotation)
			{
				return;
			}
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

		private void Update()
		{
			if (base.isActiveAndEnabled)
			{
				InternalUpdate();
				bool doPlace = place;
				place = false;
				GadgetBase gadgetBase = GadgetItem.UpdatePlacementForContext(context, doPlace, this);
				if (gadgetBase != null)
				{
					OnGadgetPlaced(gadgetBase);
				}
			}
		}

		private void Cleanup()
		{
			place = false;
			context.placementRotationStep = 0;
			context.currentlyProcessedMount = null;
			context.currentlyProcessedPositions = null;
		}
	}
}
