using DV.CabControls;
using DV.Simulation.Ports;
using UnityEngine;

namespace DV.Interaction
{
	public class ManualOilerUseVR : MonoBehaviour
	{
		private OilingPointPortFeederReader interactingOilingPoint;

		private OilingPointReactionOnControlChange interactingOilingPointReaction;

		private bool isGrabbed;

		private void Start()
		{
			if (!VRManager.IsVREnabled())
			{
				Object.Destroy(base.gameObject);
				return;
			}
			ItemBase componentInParent = GetComponentInParent<ItemBase>();
			componentInParent.Grabbed += OnGrabbedChanged;
			componentInParent.Ungrabbed += OnGrabbedChanged;
			OnGrabbedChanged(componentInParent);
		}

		private void OnDisable()
		{
			if (interactingOilingPoint != null)
			{
				interactingOilingPoint.SetRefill(0f);
			}
			interactingOilingPoint = null;
			interactingOilingPointReaction = null;
		}

		private void OnGrabbedChanged(ControlImplBase item)
		{
			isGrabbed = item.IsGrabbed();
		}

		private void OnTriggerEnter(Collider other)
		{
			Transform parent = other.transform.parent;
			if (!(parent == null) && parent.TryGetComponent<OilingPointPortFeederReader>(out var component) && parent.TryGetComponent<OilingPointReactionOnControlChange>(out var component2))
			{
				interactingOilingPoint = component;
				interactingOilingPointReaction = component2;
			}
		}

		private void OnTriggerStay(Collider other)
		{
			if (!(interactingOilingPoint == null) && !(interactingOilingPointReaction == null))
			{
				Transform parent = other.transform.parent;
				if (!(parent != interactingOilingPoint.transform))
				{
					bool flag = isGrabbed && interactingOilingPointReaction.OilingPointOpened && Vector3.Dot(-parent.up, base.transform.forward) > 0.5f;
					interactingOilingPoint.SetRefill(flag ? 1f : 0f);
				}
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (!(interactingOilingPoint == null) && !(interactingOilingPointReaction == null) && !(other.transform.parent != interactingOilingPoint.transform))
			{
				interactingOilingPoint.SetRefill(0f);
				interactingOilingPoint = null;
				interactingOilingPointReaction = null;
			}
		}
	}
}
