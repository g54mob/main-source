using System.Collections;
using DV.CabControls;
using DV.Interaction;
using DV.Utils;
using UnityEngine;

namespace DV.Items
{
	public abstract class ItemUseNonVR : MonoBehaviour
	{
		protected GrabHandlerItem grabHandler;

		protected ItemBase item;

		protected RaycastHitDV currentHit;

		private bool interactionTextUpdate;

		private void Start()
		{
			SingletonBehaviour<CoroutineManager>.Instance.Run(Init());
		}

		private IEnumerator Init()
		{
			yield return null;
			grabHandler = GetComponent<GrabHandlerItem>();
			item = GetComponent<ItemBase>();
			if (grabHandler == null || item == null)
			{
				Debug.LogWarning("Couldn't extract GrabHandlerItem or ItemBase used for non VR interaction. Deleting this script!", this);
				Object.Destroy(this);
				yield break;
			}
			item.Grabbed += OnGrab;
			item.Ungrabbed += OnUnGrab;
			base.enabled = item.IsGrabbed();
			FinishInit();
		}

		protected virtual void FinishInit()
		{
		}

		private void OnDestroy()
		{
			if (!(item == null))
			{
				item.Grabbed -= OnGrab;
				item.Ungrabbed -= OnUnGrab;
				item.Used -= OnItemUsed;
			}
		}

		private void OnGrab(ControlImplBase _)
		{
			item.Used += OnItemUsed;
			interactionTextUpdate = true;
			base.enabled = true;
		}

		private void OnUnGrab(ControlImplBase _)
		{
			item.Used -= OnItemUsed;
			interactionTextUpdate = false;
			base.enabled = false;
		}

		private void Update()
		{
			if (interactionTextUpdate && (bool)SingletonBehaviour<InteractionTextControllerNonVr>.Instance)
			{
				currentHit = grabHandler.GetGrabber().Raycaster.CurrentlyHit;
				GameObject hovered = GetHovered();
				if ((bool)hovered)
				{
					HandleHover(hovered);
				}
			}
		}

		private GameObject GetHovered()
		{
			if ((bool)currentHit.rigidbody)
			{
				return currentHit.rigidbody.gameObject;
			}
			if ((bool)currentHit.collider)
			{
				return currentHit.collider.gameObject;
			}
			return null;
		}

		protected virtual void HandleHover(GameObject hovered)
		{
		}

		private void OnItemUsed()
		{
			OnItemUsed(GetHovered());
		}

		protected virtual void OnItemUsed(GameObject hovered)
		{
		}
	}
}
