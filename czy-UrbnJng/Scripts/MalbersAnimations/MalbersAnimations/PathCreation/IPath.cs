using UnityEngine;

namespace MalbersAnimations.PathCreation
{
	public interface IPath
	{
		Vector3 StartPath { get; }

		Vector3 EndPath { get; }

		bool IsClosed { get; }

		Bounds bounds { get; }

		float GetClosestTimeOnPath(Vector3 position);

		Vector3 GetPointAtTime(float NormalizedTime);

		Quaternion GetPathRotation(float NormalizedTime);
	}
}
