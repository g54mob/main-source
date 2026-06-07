using System.Collections;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

namespace DV.Customization.Gadgets
{
	public class GadgetHandVR : GadgetHandBase
	{
		public GadgetBase gadget;

		private Coroutine delayedGrabCoroutine;

		private VRTK_InteractGrab_DV lastGrab;

		private void Start()
		{
			GetComponent<VRTK_InteractableObject_DV>().InteractableObjectUngrabbed += OnUngrabbed;
		}

		private void OnUngrabbed(object sender, InteractableObjectEventArgs e)
		{
			GameObject interactingObject = e.interactingObject;
			lastGrab = interactingObject.GetComponent<VRTK_InteractGrab_DV>();
			OnUpdate(gadget, null, null, use: true);
		}

		internal void HoleTouch(MountPoint hole, bool use)
		{
			OnUpdate(gadget, null, hole, use);
		}

		protected override bool TryGrab(GadgetBase target)
		{
			if (delayedGrabCoroutine != null)
			{
				return false;
			}
			delayedGrabCoroutine = SingletonBehaviour<CoroutineManager>.Instance.Run(DelayedGrabGadgetItem());
			return true;
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading && delayedGrabCoroutine != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(delayedGrabCoroutine);
			}
		}

		private IEnumerator DelayedGrabGadgetItem()
		{
			GadgetItem item = gadget.Remove();
			yield return null;
			lastGrab.ForceGrabInteractable(item.gameObject, usingGrabButton: true);
			delayedGrabCoroutine = null;
		}
	}
}
