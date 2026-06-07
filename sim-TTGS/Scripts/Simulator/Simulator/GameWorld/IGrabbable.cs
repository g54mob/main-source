using UnityEngine;

namespace Simulator.GameWorld
{
	public interface IGrabbable
	{
		Transform transform { get; }

		GrabbableData GrabbableData { get; }

		ClippingObjectBehaviour ClippingObjectBehaviour { get; }

		void OnGrabbedBy(IGrabber grabber);

		void OnDroppedBy(IGrabber grabber, Vector3 position);

		void OnGivenBy(IGrabber grabber);

		void OnGivenTo(IGrabber grabber);

		bool CanBeDropped();
	}
}
