using UnityEngine;

namespace Animancer
{
	public interface IMotion
	{
		float AverageAngularSpeed { get; }

		Vector3 AverageVelocity { get; }
	}
}
