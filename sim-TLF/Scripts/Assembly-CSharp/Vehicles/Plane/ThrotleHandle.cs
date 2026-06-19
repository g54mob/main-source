using Items;
using UnityEngine;

namespace Vehicles.Plane
{
	public class ThrotleHandle : MonoBehaviour, IMouseButtonManipulatable
	{
		[SerializeField]
		private AirplaneController _airplaneController;

		[SerializeField]
		private float _step;

		void IMouseButtonManipulatable.TryManipulateDown()
		{
			float value = _step * Time.deltaTime;
			_airplaneController.AddThrust(value);
		}

		void IMouseButtonManipulatable.TryManipulateUp()
		{
			float num = _step * Time.deltaTime;
			_airplaneController.AddThrust(0f - num);
		}
	}
}
