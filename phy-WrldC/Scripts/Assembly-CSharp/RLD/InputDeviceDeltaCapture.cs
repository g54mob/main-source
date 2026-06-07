using UnityEngine;

namespace RLD
{
	public class InputDeviceDeltaCapture
	{
		private int _id;

		private Vector3 _origin;

		private Vector3 _delta;

		public int Id => _id;

		public Vector3 Origin => _origin;

		public Vector3 Delta => _delta;

		public InputDeviceDeltaCapture(int id, Vector3 origin)
		{
			_id = id;
			_origin = origin;
		}

		public void Update(Vector3 devicePosition)
		{
			_delta = devicePosition - _origin;
		}
	}
}
