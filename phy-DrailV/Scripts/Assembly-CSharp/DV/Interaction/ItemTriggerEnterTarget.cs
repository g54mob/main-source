using System.Collections.Generic;
using System.Linq;
using DV.CabControls;
using DV.Utils;
using UnityEngine;

namespace DV.Interaction
{
	public class ItemTriggerEnterTarget : MonoBehaviour
	{
		private enum SupportedMode
		{
			VR = 0,
			NonVR = 1,
			All = 2
		}

		[SerializeField]
		private SupportedMode supportedMode;

		private ItemUseTarget itemUseTarget;

		[SerializeField]
		private bool requiresUngrab;

		[SerializeField]
		private bool destroyGameObjectInUnSupportedMode;

		private bool initialized;

		private Dictionary<ControlImplBase, HashSet<Collider>> waitingForUngrab = new Dictionary<ControlImplBase, HashSet<Collider>>();

		private void Awake()
		{
			bool flag = VRManager.IsVREnabled();
			if ((flag && supportedMode == SupportedMode.NonVR) || (!flag && supportedMode == SupportedMode.VR))
			{
				if (destroyGameObjectInUnSupportedMode)
				{
					Object.Destroy(base.gameObject);
				}
				else
				{
					Object.Destroy(this);
				}
				return;
			}
			itemUseTarget = GetComponentInParent<ItemUseTarget>();
			if (itemUseTarget == null)
			{
				Debug.LogError("ItemTriggerEnterTarget must be a child of ItemUseTarget. Destroying self.", this);
				Object.Destroy(this);
			}
			else
			{
				initialized = true;
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other == null || !initialized)
			{
				return;
			}
			ReliableOnTriggerExit.NotifyTriggerEnter(other, base.gameObject, OnTriggerExit);
			ControlImplBase componentInParent = other.GetComponentInParent<ControlImplBase>();
			if (!componentInParent || !componentInParent.InteractionColliderObjects.Contains(other.gameObject))
			{
				return;
			}
			if (requiresUngrab && componentInParent.IsGrabbed())
			{
				if (waitingForUngrab.TryGetValue(componentInParent, out var value))
				{
					value.Add(other);
					return;
				}
				waitingForUngrab.Add(componentInParent, new HashSet<Collider> { other });
				componentInParent.Ungrabbed += OnUngrab;
			}
			else
			{
				CheckUse(other);
			}
		}

		private void OnUngrab(ControlImplBase controlBase)
		{
			if (requiresUngrab && waitingForUngrab.TryGetValue(controlBase, out var value))
			{
				waitingForUngrab.Remove(controlBase);
				controlBase.Ungrabbed -= OnUngrab;
				if (initialized)
				{
					CheckUse(value.First());
				}
			}
		}

		private void OnTriggerExit(Collider other)
		{
			ReliableOnTriggerExit.NotifyTriggerExit(other, base.gameObject);
			if (requiresUngrab)
			{
				ControlImplBase componentInParent = other.GetComponentInParent<ControlImplBase>();
				if ((bool)componentInParent && waitingForUngrab.TryGetValue(componentInParent, out var value) && value.Remove(other) && value.Count == 0)
				{
					waitingForUngrab.Remove(componentInParent);
				}
			}
		}

		private void CheckUse(Collider other)
		{
			IItemUse[] componentsInParent = other.GetComponentsInParent<IItemUse>();
			foreach (IItemUse itemUse in componentsInParent)
			{
				if (itemUse.IsUseCompatible(itemUseTarget) && itemUse.HandleUse(itemUseTarget))
				{
					break;
				}
			}
		}
	}
}
