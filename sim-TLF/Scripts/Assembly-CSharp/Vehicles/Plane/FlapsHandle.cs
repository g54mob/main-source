using Items;
using UnityEngine;

namespace Vehicles.Plane
{
	public class FlapsHandle : MonoBehaviour, IMouseButtonManipulatable
	{
		[SerializeField]
		private AirplaneController _airplaneController;

		[SerializeField]
		private float _maxFlaps = 0.3f;

		[SerializeField]
		private float _step;

		void IMouseButtonManipulatable.TryManipulateDown()
		{
			float num = _step * Time.deltaTime;
			_airplaneController.Flap = Mathf.Clamp(_airplaneController.Flap + num, 0f, _maxFlaps);
		}

		void IMouseButtonManipulatable.TryManipulateUp()
		{
			float num = _step * Time.deltaTime;
			_airplaneController.Flap = Mathf.Clamp(_airplaneController.Flap - num, 0f, _maxFlaps);
		}
	}
}
