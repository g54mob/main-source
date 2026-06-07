using UnityEngine;

namespace ModApi.Craft.Parts
{
	public interface IPartFlightCollision
	{
		Collision Collision { get; }

		ContactPoint Contact { get; }

		float Impulse { get; }

		bool IsGroundCollision { get; }

		float NormalVelocity { get; }

		int OtherColliderLayer { get; }

		IPartScript OtherPartScript { get; }

		IPartScript PartScript { get; }

		Vector3 RelativeVelocity { get; }

		float RelativeVelocityMagnitude { get; }
	}
}
