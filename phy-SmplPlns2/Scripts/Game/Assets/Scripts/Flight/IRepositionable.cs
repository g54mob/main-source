using UnityEngine;

namespace Assets.Scripts.Flight
{
	public interface IRepositionable
	{
		Vector3 GlobalPosition { get; set; }

		Vector3 Rotation { get; set; }

		(Bounds Bounds, Vector3 BoundsOffset) GetBounds();

		void OnBeginReposition(Vector3 approximateGlobalPosition);

		void OnEndReposition(Vector3 finalGlobalPosition, Vector3 finalRotation);

		void RepositionOnGround();

		void SetVelocity(Vector3 velocity, bool ignoreDisconnectedBodies = false);
	}
}
