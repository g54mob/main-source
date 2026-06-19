using UnityEngine;

namespace TH20
{
	public class RoomSizeMeasurement : MonoBehaviour
	{
		[SerializeField]
		private Transform _arrow;

		[SerializeField]
		private LineRenderer _line;

		private readonly Vector3[] _points = new Vector3[2];

		public void SetPosition(Vector3 start, Vector3 end)
		{
			_arrow.position = end;
			_arrow.forward = (end - start).normalized;
			_points[0] = start;
			_points[1] = end;
			_line.SetPositions(_points);
		}
	}
}
