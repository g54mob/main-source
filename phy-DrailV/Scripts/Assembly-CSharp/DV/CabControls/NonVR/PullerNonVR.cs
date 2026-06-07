using System.Collections;
using DV.Interaction;
using DV.Utils;
using UnityEngine;

namespace DV.CabControls.NonVR
{
	public class PullerNonVR : PullerBase
	{
		private GrabHandlerPuller grabHandler;

		protected override void Awake()
		{
			base.Awake();
			grabHandler = AGrabHandler.AddGrabHandler<GrabHandlerPuller>(base.gameObject, spec.colliderGameObjects);
			grabHandler.Grabbed += FireGrabbed;
			grabHandler.UnGrabbed += FireUngrabbed;
			grabHandler.invertFeedValueDirection = Mathf.Sign(spec.scrollWheelHoverScroll) * (float)((!spec.invertDirection) ? 1 : (-1)) < 0f;
			grabHandler.AssignInteractionPassThrough(base.BaseInteractionPassThrough);
			if (hasInsideVolume)
			{
				grabHandler.PositionChanged += base.MoveItemsAlong;
			}
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
