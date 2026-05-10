using System;
using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	[Serializable]
	public class AxleInfo
	{
		public WheelCollider leftWheel;

		public WheelCollider rightWheel;

		public bool motor;

		public bool steering;
	}
}
