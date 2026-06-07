using System.Collections;
using DV.Interaction;
using DV.Utils;
using UnityEngine;

namespace DV.CabControls.NonVR
{
	public class RotaryNonVR : RotaryBase
	{
		private GrabHandlerHingeJoint grabHandler;

		protected override void Awake()
		{
			base.Awake();
			SingletonBehaviour<CoroutineManager>.Instance.Run(Initialize());
		}

		private IEnumerator Initialize()
		{
			while (hj == null)
			{
				yield return null;
			}
			grabHandler = AGrabHandler.AddGrabHandler<GrabHandlerHingeJoint>(base.gameObject, base.Spec.colliderGameObjects);
			grabHandler.resetTargetPositionOnUngrab = !base.Spec.useSteppedJoint;
			grabHandler.Grabbed += FireGrabbed;
			grabHandler.UnGrabbed += FireUngrabbed;
			grabHandler.invertFeedValueDirection = Mathf.Sign(base.Spec.scrollWheelHoverScroll) * (float)((!base.Spec.invertDirection) ? 1 : (-1)) < 0f;
			grabHandler.AssignInteractionPassThrough(base.BaseInteractionPassThrough);
			yield return WaitFor.EndOfFrame;
			StaticInteractionArea nonVrStaticInteractionArea = base.Spec.nonVrStaticInteractionArea;
			if (nonVrStaticInteractionArea != null)
			{
				nonVrStaticInteractionArea.Initialize(grabHandler, base.gameObject.layer);
			}
		}

		public override bool IsGrabbed()
		{
			if ((bool)grabHandler)
			{
				return grabHandler.IsGrabbed();
			}
			return false;
		}

		public override void ForceEndInteraction()
		{
			if ((bool)grabHandler)
			{
				grabHandler.ForceEndInteraction();
			}
		}

		public override void BlockControl(bool setBlock)
		{
			base.BlockControl(setBlock);
			if ((bool)grabHandler)
			{
				grabHandler.SetMovingDisabled(setBlock);
			}
			isScrollingBlocked = setBlock;
		}
	}
}
