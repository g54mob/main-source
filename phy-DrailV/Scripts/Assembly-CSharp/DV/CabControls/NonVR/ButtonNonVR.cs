using System.Collections;
using DV.Interaction;
using DV.Utils;

namespace DV.CabControls.NonVR
{
	public class ButtonNonVR : ButtonBase
	{
		private GrabHandlerButton grabHandler;

		protected override void Awake()
		{
			base.Awake();
			grabHandler = AGrabHandler.AddGrabHandler<GrabHandlerButton>(base.gameObject, spec.colliderGameObjects);
			grabHandler.Pressed += OnPress;
			grabHandler.Released += OnRelease;
			grabHandler.Grabbed += FireGrabbed;
			grabHandler.UnGrabbed += FireUngrabbed;
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

		private void OnPress(AGrabHandler _)
		{
			Use();
		}

		private void OnRelease(AGrabHandler _)
		{
			if (base.IsHoldMode && base.IsOn)
			{
				Use();
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
