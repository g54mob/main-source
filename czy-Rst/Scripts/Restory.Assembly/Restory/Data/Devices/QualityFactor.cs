using System;
using Restory.Data.Devices.Quality;
using UnityEngine;

namespace Restory.Data.Devices
{
	[Serializable]
	public struct QualityFactor
	{
		public DeviceQualityBase Quality;

		[Range(0f, 1f)]
		public float Factor;
	}
}
