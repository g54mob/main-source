using System.Collections;
using DV.Interaction;
using DV.Utils;
using UnityEngine;

namespace DV.CabControls.NonVR
{
	public class WheelNonVR : WheelBase
	{
		private GrabHandlerHingeJoint grabHandler;

		protected override void Awake()
		{
			base.Awake();
			hj.useSpring = true;
			JointSpring spring = hj.spring;
			spring.spring = springStrength;
			spring.damper = 2f;
			hj.spring = spring;
			grabHandler = AGrabHandler.AddGrabHandler<GrabHandlerHingeJoint>(base.gameObject, spec.colliderGameObjects);
			grabHandler.Grabbed += FireGrabbed;
			grabHandler.UnGrabbed += FireUngrabbed;
			grabHandler.invertFeedValueDirection = Mathf.Sign(spec.scrollWheelHoverScroll) * (float)((!spec.invertDirection) ? 1 : (-1)) < 0f;
			grabHandler.AssignInteractionPassThrough(base.BaseInteractionPassThrough);
			SingletonBehaviour<CoroutineManager>.Instance.Run(InitializeStaticArea());
		}

		private IEnumerator InitializeStaticArea()
		{
			while (spec == null)
			{
				yield return null;
			}
			yield return WaitFor.EndOfFrame;
			StaticInteractionArea nonVrStaticInteractionArea = spec.nonVrStaticInteractionArea;
			if (nonVrStaticInteractionArea != null)
			{
				nonVrStaticInteractionArea.Initialize(grabHandler, base.gameObject.layer);
			}
		}

		public override bool IsGrabbed()
		{
			return grabHandler.IsGrabbed();
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
