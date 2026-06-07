using System.Collections;
using DV.Customization.Gadgets;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;

namespace VRTK.GrabAttachMechanics
{
	public class MountHoleAttachMethod : VRTK_BaseGrabAttach
	{
		public MountPoint hole;

		private VRTK_InteractableObject_DV interactableObjectDv;

		private GadgetHandVR hand;

		private Coroutine delayedUngrabCoro;

		protected override void Initialise()
		{
			hole = GetComponent<MountPoint>();
			hand = hole.Drillable.GetComponent<GadgetHandVR>();
			interactableObjectDv = GetComponent<VRTK_InteractableObject_DV>();
			interactableObjectDv.InteractableObjectTouched += delegate
			{
				hand.HoleTouch(hole, use: false);
			};
			interactableObjectDv.InteractableObjectUntouched += delegate
			{
				hand.HoleTouch(null, use: false);
			};
			interactableObjectDv.InteractableObjectUngrabbed += delegate
			{
				hand.HoleTouch(hole, use: true);
			};
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
			if (hole.State != MountPoint.States.Taped)
			{
				return false;
			}
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
