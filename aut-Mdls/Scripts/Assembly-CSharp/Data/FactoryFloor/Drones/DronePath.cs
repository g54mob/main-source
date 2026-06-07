using UnityEngine;

namespace Data.FactoryFloor.Drones
{
	public class DronePath
	{
		public readonly Vector3 StartPos;

		public readonly Vector3 TargetPos;

		public readonly Vector3 CornerPos;

		public readonly Vector3 Diff;

		public DronePath(Vector3 startPos, Vector3 targetPos)
		{
			StartPos = startPos;
			TargetPos = targetPos;
			Diff = targetPos - startPos;
			CornerPos = ((targetPos.y > startPos.y) ? (startPos + new Vector3(0f, Diff.y, 0f)) : (targetPos + new Vector3(0f, Mathf.Abs(Diff.y), 0f)));
			Vector3 vector = TargetPos - startPos;
			Vector3 cornerPos = startPos + vector * 0.5f;
			cornerPos.y = CornerPos.y;
			CornerPos = cornerPos;
		}

		public DronePath(Vector3 startPos, Vector3 targetPos, Vector3 cornerPos)
		{
			StartPos = startPos;
			TargetPos = targetPos;
			Diff = targetPos - startPos;
			CornerPos = cornerPos;
		}

		public Vector3 GetPositionAtPercentage(float perc)
		{
			Vector3 a = Vector3.Lerp(StartPos, CornerPos, perc);
			Vector3 b = Vector3.Lerp(CornerPos, TargetPos, perc);
			return Vector3.Lerp(a, b, perc);
		}
	}
}
