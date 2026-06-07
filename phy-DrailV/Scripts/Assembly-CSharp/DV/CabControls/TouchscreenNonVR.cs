using DV.Interaction;
using DV.Utils;
using UnityEngine;

namespace DV.CabControls
{
	public class TouchscreenNonVR : TouchscreenBase
	{
		private const float MAX_INTERACTION_RANGE_SQUARED = 4f;

		private GrabHandlerTouchscreen grabHandler;

		private ItemBase item;

		private bool scanAllowed;

		private Grabber grabber;

		private LayerMask interactableLayerMask;

		protected override void Start()
		{
			if ((bool)PlayerManager.PlayerTransform)
			{
				OnPlayerChanged();
			}
			else
			{
				PlayerManager.PlayerChanged += OnPlayerChanged;
			}
			interactableLayerMask = LayerMask.GetMask("Interactable");
			grabHandler = AGrabHandler.AddGrabHandler<GrabHandlerTouchscreen>(base.gameObject, touchscreenSpec.colliderGameObjects);
			grabHandler.AssignInteractionPassThrough(base.InteractionPassThrough);
			grabHandler.Pressed += OnPress;
			grabHandler.Hovered += delegate
			{
				base.enabled = true;
				Update();
			};
			grabHandler.UnHovered += delegate
			{
				Untouch();
				base.enabled = false;
			};
			base.Start();
			base.enabled = false;
		}

		private void OnPlayerChanged()
		{
			PlayerManager.PlayerChanged -= OnPlayerChanged;
			grabber = PlayerManager.PlayerTransform.GetComponentInChildren<Grabber>(includeInactive: true);
		}

		private void OnDestroy()
		{
			PlayerManager.PlayerChanged -= OnPlayerChanged;
		}

		private void OnPress(AGrabHandler _)
		{
			Use();
		}

		public override bool IsGrabbed()
		{
			return grabHandler.IsGrabbed();
		}

		private void Update()
		{
			if (!(grabber == null) && TimeUtil.IsFlowing)
			{
				RaycastHitDV currentlyHit = grabber.Raycaster.CurrentlyHit;
				Vector3 vector = new Vector3(localInteractionHalfSize.x, 0f, localInteractionHalfSize.y);
				Vector3 localPosition = VectorUtils.ClampCoords(base.transform.InverseTransformPoint(currentlyHit.point), -vector, vector);
				Touch(localPosition);
			}
		}

		public override void ForceEndInteraction()
		{
			if ((bool)grabHandler)
			{
				grabHandler.ForceEndInteraction();
			}
		}
	}
}
