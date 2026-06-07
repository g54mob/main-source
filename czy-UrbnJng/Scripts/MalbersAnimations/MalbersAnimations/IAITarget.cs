using UnityEngine;

namespace MalbersAnimations
{
	public interface IAITarget
	{
		Transform transform { get; }

		float Height { get; }

		bool ArriveLookAt { get; }

		WayPointType TargetType { get; }

		float StopDistance();

		float SlowDistance();

		Vector3 GetCenterPosition(int index);

		Vector3 GetCenterPosition();

		Vector3 GetCenterY();

		void TargetArrived(GameObject target);
	}
}
