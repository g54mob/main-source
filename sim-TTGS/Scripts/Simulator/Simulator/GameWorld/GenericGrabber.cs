using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class GenericGrabber : MonoBehaviour, IGrabber, IGiver
	{
		[SerializeField]
		private Transform m_anchor;

		[SerializeField]
		private ClippingObjectBehaviour.ELayerType m_clippingLayerType;

		public IGrabbable CurrentGrabbable { get; private set; }

		public ClippingObjectBehaviour.ELayerType ClippingLayerType => m_clippingLayerType;

		public event Action<IGrabbable> Grabbed;

		public event Action<IGrabbable> Gave;

		public bool CanGrab(IGrabbable grabbable)
		{
			return CurrentGrabbable == null;
		}

		public bool Grab(IGrabbable grabbable)
		{
			CurrentGrabbable = grabbable;
			CurrentGrabbable.OnGrabbedBy(this);
			CurrentGrabbable.Anchor(m_anchor);
			this.Grabbed?.Invoke(grabbable);
			return true;
		}

		public bool HasGrabbable(out IGrabbable grabbable)
		{
			grabbable = CurrentGrabbable;
			return grabbable != null;
		}

		public bool CanGive(out IGrabbable grabbable)
		{
			grabbable = CurrentGrabbable;
			return grabbable != null;
		}

		public IGrabbable GiveTo(IGrabber grabber)
		{
			IGrabbable currentGrabbable = CurrentGrabbable;
			if (CurrentGrabbable != null)
			{
				CurrentGrabbable.OnGivenBy(this);
				CurrentGrabbable = null;
				this.Gave?.Invoke(currentGrabbable);
				if (grabber != null)
				{
					currentGrabbable.OnGivenTo(grabber);
				}
			}
			return currentGrabbable;
		}
	}
}
