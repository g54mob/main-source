using UnityEngine;

namespace MalbersAnimations
{
	public interface IGravity
	{
		Vector3 Gravity { get; set; }

		Vector3 UpVector { get; }

		void Gravity_ResetDirection();
	}
}
