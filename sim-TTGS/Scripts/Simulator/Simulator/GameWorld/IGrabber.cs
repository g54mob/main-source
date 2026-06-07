namespace Simulator.GameWorld
{
	public interface IGrabber
	{
		ClippingObjectBehaviour.ELayerType ClippingLayerType { get; }

		bool CanGrab(IGrabbable grabbable);

		bool Grab(IGrabbable grabbable);

		bool HasGrabbable(out IGrabbable grabbable);
	}
}
