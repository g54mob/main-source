using System.Collections;
using DV.Interaction;
using DV.Utils;
using UnityEngine;

namespace DV.CabControls.NonVR
{
	public class LeverNonVR : LeverBase
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
			grabHandler = AGrabHandler.AddGrabHandler<GrabHandlerHingeJoint>(base.gameObject, spec.colliderGameObjects);
			grabHandler.resetTargetPositionOnUngrab = !spec.useSteppedJoint;
			grabHandler.invertFeedValueDirection = Mathf.Sign(spec.scrollWheelHoverScroll) * (float)((!spec.invertDirection) ? 1 : (-1)) < 0f;
			grabHandler.Grabbed += FireGrabbed;
			grabHandler.UnGrabbed += FireUngrabbed;
			grabHandler.AssignInteractionPassThrough(base.BaseInteractionPassThrough);
			yield return WaitFor.EndOfFrame;
			StaticInteractionArea nonVrStaticInteractionArea = spec.nonVrStaticInteractionArea;
			if (nonVrStaticInteractionArea != null)
			{
				nonVrStaticInteractionArea.Initialize(grabHandler, base.gameObject.layer);
			}
		}

		public override bool IsGrabbed()
		{
			if (grabHandler != null)
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
			base.IsScrollingBlocked = setBlock;
		}
	}
}
