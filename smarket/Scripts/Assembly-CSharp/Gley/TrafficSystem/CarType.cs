using System;
using UnityEngine;

namespace Gley.TrafficSystem
{
	[Serializable]
	public class CarType
	{
		public GameObject vehiclePrefab;

		[Range(1f, 100f)]
		public int percent;

		public bool dontInstantiate;
	}
}
