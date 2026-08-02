using System;
using HQFPSTemplate.Equipment;

namespace HQFPSTemplate
{
	[Serializable]
	public class SimpleCameraMotionState
	{
		[Group]
		public EquipmentMotionState.BobModule Bob;

		[Group]
		public EquipmentMotionState.NoiseModule Noise;
	}
}
