using System;

namespace ScheduleOne.Experimental
{
	[Serializable]
	public class VehicleSettings
	{
		public WheelFrictionSettings ForwardFriction;

		public WheelFrictionSettings SidewaysFriction;

		public VehicleSettings Clone()
		{
			return null;
		}

		public VehicleSettings Blend(VehicleSettings other, float t)
		{
			return null;
		}
	}
}
