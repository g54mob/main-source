using System.Collections;
using DV.Interaction;
using DV.Utils;
using UnityEngine;

namespace DV.CabControls.NonVR
{
	public class GizmoNonVR : GizmoBase
	{
		private AGrabHandler grabHandler;

		protected override void Awake()
		{
			base.Awake();
			if (spec.behaveAsItem)
			{
				GrabHandlerGizmoItem grabHandlerGizmoItem = AGrabHandler.AddGrabHandler<GrabHandlerGizmoItem>(base.gameObject, spec.colliderGameObjects);
				grabHandlerGizmoItem.mustHoldButton = true;
				grabHandlerGizmoItem.carryingPosition = spec.carryingPosition;
				grabHandler = grabHandlerGizmoItem;
			}
			else
			{
				grabHandler = AGrabHandler.AddGrabHandler<GrabHandlerGizmo>(base.gameObject, spec.colliderGameObjects);
			}
			grabHandler.Grabbed += delegate
			{
				FireGrabbed();
			};
			grabHandler.UnGrabbed += delegate
			{
				FireUngrabbed();
			};
			base.InteractionAllowedChanged += delegate(bool val)
			{
				grabHandler.interactionAllowed = val;
			};
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
			if (grabHandler != null)
			{
				return grabHandler.IsGrabbed();
			}
			return false;
		}

		protected override void AcceptSetValue(float newValue)
		{
			Debug.Log("GizmoNonVR doesn't support setting value", this);
		}

		public override void ForceEndInteraction()
		{
			if ((bool)grabHandler)
			{
				grabHandler.ForceEndInteraction();
			}
		}

		protected override void OnInteractionAllowedChanged(bool value)
		{
			base.OnInteractionAllowedChanged(value);
			GetComponent<Collider>().enabled = value;
		}
	}
}
