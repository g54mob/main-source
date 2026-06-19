using UnityEngine;

namespace Vehicles.Plane
{
	public class Propeller : MonoBehaviour
	{
		[SerializeField]
		private EngineComponent _engine;

		[SerializeField]
		private bool _rotating;

		[SerializeField]
		private float _speed = 1000f;

		private void Update()
		{
			if (_engine != null && _engine.IsRunning)
			{
				float num = _engine.RPM * 6f;
				base.transform.Rotate(0f, 0f, num * Time.deltaTime);
			}
			if (_rotating)
			{
				base.transform.Rotate(0f, 0f, _speed * Time.deltaTime);
			}
		}
	}
}
