using DV.CabControls;
using UnityEngine;

namespace DV.VR
{
	public abstract class TelegrabbableInteractionTarget : Telegrabbable
	{
		protected TelegrabInteractionHandler handler;

		private ControlImplBase control;

		public override bool RemoteInteractionOnly => true;

		public override bool ShouldHighlightWhenNearby => false;

		protected override void Start()
		{
			base.Start();
			control = GetComponent<ControlImplBase>();
		}

		public virtual void StartInteraction(TelegrabInteractionHandler handler)
		{
			this.handler = handler;
		}

		public virtual void StopInteraction(TelegrabInteractionHandler handler)
		{
			this.handler = null;
		}

		protected virtual void OnDisable()
		{
			if ((bool)handler)
			{
				handler.StopInteracting();
			}
		}

		public override bool IsTelegrabAllowed(Vector3 _)
		{
			if (Globals.G.GameParams.VRRemoteDrivingAllowed && handler == null)
			{
				if ((bool)control)
				{
					return control.InteractionAllowed;
				}
				return true;
			}
			return false;
		}

		public override Transform GetAnchor(bool _)
		{
			return base.transform;
		}

		public override bool ShouldRotateToController()
		{
			return false;
		}

		protected override void SetState(bool _)
		{
		}
	}
}
