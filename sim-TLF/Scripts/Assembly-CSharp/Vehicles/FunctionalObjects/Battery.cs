using UnityEngine;

namespace Vehicles.FunctionalObjects
{
	public class Battery : AbstractFunctionalObject
	{
		[SerializeField]
		private int _batteryVoltage = 12;

		[SerializeField]
		private int _batteryCapacity = 100;

		private float _currentCharge;

		public int BatteryVoltage => _batteryVoltage;

		public int BatteryCapacity => _batteryCapacity;

		public float CurrentCharge => _currentCharge;
	}
}
