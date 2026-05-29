using System;
using UnityEngine;

namespace ScheduleOne.Temperature
{
	public class TemperatureEmitter : MonoBehaviour
	{
		public const int DefaultAmbientTemperature = 20;

		public const int MinTemperature = 0;

		public const int MaxTemperature = 40;

		public Action OnEmitterChanged;

		[field: SerializeField]
		public float Temperature { get; private set; }

		[field: SerializeField]
		public float Range { get; private set; }

		public Vector3 EmissionPoint => default(Vector3);

		public void SetPosition(Vector3 position)
		{
		}

		public void SetTemperature(float temperature)
		{
		}

		public void SetRange(float range)
		{
		}

		public void NotifyChanged()
		{
		}
	}
}
