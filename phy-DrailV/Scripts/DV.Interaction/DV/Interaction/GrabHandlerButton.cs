using System;
using UnityEngine;

namespace DV.Interaction
{
	public class GrabHandlerButton : AGrabHandler
	{
		public override bool IsItem => false;

		public event Action<GrabHandlerButton> Pressed;

		public event Action<GrabHandlerButton> Released;

		public override Vector3 GetAxis()
		{
			return Vector3.forward;
		}

		public override Vector3 GetAnchor()
		{
			return Vector3.zero;
		}

		public override void StartInteraction(Vector3 startWorldPosition, Grabber grabbedBy)
		{
			base.StartInteraction(startWorldPosition, grabbedBy);
			this.Pressed?.Invoke(this);
		}

		public override void FeedPosition(Vector3 worldPosition)
		{
		}

		public override void EndInteraction()
		{
			base.EndInteraction();
			this.Released?.Invoke(this);
		}
	}
}
