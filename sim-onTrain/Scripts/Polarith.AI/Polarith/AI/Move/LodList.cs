using System;
using System.Collections.Generic;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public sealed class LodList
	{
		[SerializeField]
		private List<AIMSensor> sensors = new List<AIMSensor>();

		[SerializeField]
		private List<float> distances = new List<float>();

		public int Count => sensors.Count;

		public LodElement this[int i] => new LodElement(sensors[i], distances[i]);

		public void Add(AIMSensor sensor, float distance)
		{
			sensors.Add(sensor);
			distances.Add(distance);
		}

		public void SetAt(int index, AIMSensor sensor, float distance)
		{
			sensors[index] = sensor;
			distances[index] = distance;
		}

		public void RemoveAt(int index)
		{
			sensors.RemoveAt(index);
			distances.RemoveAt(index);
		}

		public void Clear()
		{
			sensors.Clear();
			distances.Clear();
		}
	}
}
