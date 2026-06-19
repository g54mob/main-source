using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class DebugFlyCameraConfig
	{
		[InspectorTooltip("How much the mouse affects camera rotation")]
		public float MouseSensitivity = 5f;

		[InspectorTooltip("How much the joypad stick affects camera rotation")]
		public float JoypadRotationSensitivity = 100f;

		[InspectorTooltip("Movement speed without modifiers, in m/s")]
		public float Speed = 10f;

		[InspectorTooltip("Speed immediately set to when speeding up, in m/s")]
		public float SpeedUpMinimumSpeed = 10f;

		[InspectorTooltip("Highest speed the camera can move whilst speeding up, in m/s")]
		public float SpeedUpMaximumSpeed = 100f;

		[InspectorTooltip("Time to go between min and max speed whilst speeding up")]
		public float SpeedUpTimeToReachMaximumSpeed = 5f;

		[InspectorTooltip("Speed to go whilst slowing down, in m/s")]
		public float SlowDownSpeed = 2.5f;

		[InspectorDivider]
		[InspectorHeader("Advanced")]
		[InspectorTooltip("Speed multiplier for how long it takes the speed up timer to return to 0 after releasing. 1 means it'll take SpeedUpTimeToReachMaximumSpeed.")]
		public float SpeedUpReturnToZeroSpeed = 2f;
	}
}
