namespace Simulator.GameWorld
{
	public interface IGiver
	{
		bool CanGive(out IGrabbable grabbable);

		IGrabbable GiveTo(IGrabber grabber);
	}
}
