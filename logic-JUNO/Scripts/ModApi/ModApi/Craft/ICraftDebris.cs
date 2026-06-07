using UnityEngine;

namespace ModApi.Craft
{
	public interface ICraftDebris
	{
		Rigidbody RigidBody { get; }

		Transform Transform { get; }
	}
}
