using DV.Interaction;
using DV.UI;
using DV.Utils;
using UnityEngine;

namespace DV.Customization.Gadgets
{
	public class GadgetHandNonVR : GadgetHandBase
	{
		private const float REACH = 3f;

		public Grabber grabber;

		private bool use;

		private void Start()
		{
			grabber.InteractionHandler.StartInteractionRequested += OnUse;
		}

		private void Update()
		{
			Transform transform = PlayerManager.ActiveCamera.transform;
			if (!grabber.IsGrabbing() && !SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Blockers | CanvasController.ElementType.MouseMode))
			{
				if (PhysicsQueryBuilder.Raycast(transform.transform.position, transform.transform.forward, 3f, (Layers.DVLayerMask.Default | Layers.DVLayerMask.Terrain | Layers.DVLayerMask.Train_Interior | Layers.DVLayerMask.Interactable | Layers.DVLayerMask.Gadget_Mesh_Placing).ToLayerMask()).FilterGadgetDepthHack().TryGetFirst(out var hit))
				{
					if (GadgetInteractor.TryGetTarget(hit, out var result))
					{
						MountPoint hole = null;
						if (result.TryGetComponent<Drillable>(out var component))
						{
							int mountPointUsingWorldRay = component.GetMountPointUsingWorldRay(transform.transform.position, transform.transform.forward);
							if (mountPointUsingWorldRay != -1)
							{
								hole = component.GetMountPoint(mountPointUsingWorldRay);
							}
						}
						OnUpdate(result, hit.rigidbody, hole, use);
					}
					else
					{
						OnUpdate(null, null, null, use);
					}
				}
			}
			else
			{
				OnUpdate(null, null, null, use: false);
			}
			use = false;
		}

		private void OnUse()
		{
			if (!grabber.IsGrabbing())
			{
				use = true;
			}
		}

		protected override bool TryGrab(GadgetBase target)
		{
			if (!target.Remove().TryGetComponent<AGrabHandler>(out var component))
			{
				return false;
			}
			grabber.InteractionHandler.RequestForceHold(component);
			return true;
		}
	}
}
