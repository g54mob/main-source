using System.Collections;
using DV.Customization.Gadgets;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;

namespace VRTK.GrabAttachMechanics
{
	public class GadgetAttachMethod : VRTK_BaseGrabAttach
	{
		public GadgetBase gadget;

		private VRTK_InteractableObject_DV interactableObjectDv;

		private Coroutine delayedUngrabCoro;

		protected override void Initialise()
		{
			interactableObjectDv = GetComponent<VRTK_InteractableObject_DV>();
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading && delayedUngrabCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(delayedUngrabCoro);
			}
		}

		public override bool ValidGrab(Rigidbody checkAttachPoint)
		{
			if (delayedUngrabCoro != null)
			{
				return false;
			}
			delayedUngrabCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(DelayedUngrab());
			return true;
		}

		private IEnumerator DelayedUngrab()
		{
			yield return WaitFor.EndOfFrame;
			interactableObjectDv.ForceStopAllInteractions_Public();
			delayedUngrabCoro = null;
		}
	}
}
