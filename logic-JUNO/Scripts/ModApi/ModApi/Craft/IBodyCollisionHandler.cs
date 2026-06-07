using ModApi.Craft.Parts;

namespace ModApi.Craft
{
	public interface IBodyCollisionHandler
	{
		void CollidePart(IPartFlightCollision collision);

		void DisconnectPart(IPartScript part);
	}
}
