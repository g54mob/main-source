using Gauges;
using UnityEngine;

namespace Vehicles.Plane
{
	public class PlaneGaugesShower : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody _planeRigidbody;

		[Space(10f)]
		[SerializeField]
		private GyroGauge _gyroGauge;

		[SerializeField]
		private NeedleGauge _speedometerGauge;

		[SerializeField]
		private AltimeterGauge _altimeterGauge;

		[SerializeField]
		private NeedleGauge _fuelGauge;

		[SerializeField]
		private VerticalSpeedGauge _verticalSpeedGauge;

		private void Update()
		{
			_gyroGauge.SetAttitude((base.transform.eulerAngles.x > 180f) ? (base.transform.eulerAngles.x - 360f) : base.transform.eulerAngles.x, (base.transform.eulerAngles.z > 180f) ? (base.transform.eulerAngles.z - 360f) : base.transform.eulerAngles.z);
			_speedometerGauge.SetValue(_planeRigidbody.linearVelocity.magnitude * 3.6f);
			_altimeterGauge.SetAltitude(base.transform.position.y);
			_fuelGauge.SetValue(50f);
			_verticalSpeedGauge.SetVerticalSpeed(_planeRigidbody.linearVelocity.y);
		}
	}
}
