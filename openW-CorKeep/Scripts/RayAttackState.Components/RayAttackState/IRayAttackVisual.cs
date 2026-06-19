using UnityEngine;

namespace RayAttackState
{
	public interface IRayAttackVisual
	{
		void UpdateBeam(Vector3 fromWorldPos, Vector3 toWorldPos, bool isHittingSomething);

		void DisableBeam();
	}
}
