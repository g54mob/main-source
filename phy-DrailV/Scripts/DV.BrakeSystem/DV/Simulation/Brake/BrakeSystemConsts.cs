using System.Runtime.InteropServices;

namespace DV.Simulation.Brake
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct BrakeSystemConsts
	{
		public const float ATMOSPHERE_PRESSURE = 1f;

		public const float ATMOSPHERE_VOLUME = 10000f;

		public const float CONTROL_RESERVOIR_VOLUME = 0.1f;

		public const float EQUALIZING_RESERVOIR_VOLUME = 10f;

		public const float PIPE_VOLUME = 10f;

		public const float CYLINDER_VOLUME = 10f;

		public const float AUX_RES_SCALE_FACTOR = 5f;

		public const float AUX_RES_VOLUME = 50f;

		public const float IND_PIPE_VOLUME = 10f;

		public const float MAX_BRAKE_PIPE_PRESSURE = 6f;

		public const float INITIAL_APPLICATION_BRAKE_PIPE_PRESSURE = 5.7f;

		public const float INITIAL_APPLICATION_PRESSURE_DROP = 0.3000002f;

		public const float PRESSURIZED_MIN_BRAKE_PIPE_PRESSURE = 4.5f;

		public const float FULL_APPLICATION_PRESSURE_DROP = 1.5f;

		public const float MAX_MAIN_RES_PRESSURE = 9f;

		public const float MANUAL_LAP_APPLY_TARGET_PRESSURE_SPEED = 0.2f;

		public const float MANUAL_LAP_EMERGENCY_VENT_EQ_SPEED_MULTIPLIER = 150f;

		public const float MANUAL_LAP_RELEASE_TARGET_PRESSURE_SPEED = 6f;

		public const float MANUAL_LAP_EMERGENCY_THRESHOLD = 0.9f;

		public const float MANUAL_LAP_APPLY_THRESHOLD = 0.5f;

		public const float MANUAL_LAP_RELEASE_THRESHOLD = 0.1f;

		public const float CONTROL_VALVE_APPLY_THRESHOLD = 0.01f;

		public const float CONTROL_VALVE_VENT_THRESHOLD = 0.01f;

		public const float MAX_BRAKE_CYLINDER_PRESSURE = 4.5f;

		public const float MIN_APPLICATION_PRESSURE = 1.5f;

		public static float DUMP_EQ_SPEED_MULTIPLIER = 10f;

		public static float IND_DUMP_EQ_SPEED_MULTIPLIER = 20f;

		public static float ANGLE_COCK_EQ_SPEED_MULTIPLIER = 150f;

		public static float MR_TO_BP_EQ_SPEED_MULTIPLIER = 40f;

		public static float MR_TO_IND_BP_EQ_SPEED_MULTIPLIER = 20f;

		public static float BP_TO_MR_EQ_SPEED_MULTIPLIER = 100f;

		public static float BP_TO_AUX_EQ_SPEED_MULTIPLIER = 5f;

		public static float CYLINDER_VENT_EQ_SPEED_MULTIPLIER = 10f;

		public static float CYLINDER_APPLY_EQ_SPEED_MULTIPLIER = 10f;

		public static float AUX_RES_LEAK_EQ_SPEED_MULTIPLIER = 0.0001f;

		public static float CYLINDER_LEAK_EQ_SPEED_MULTIPLIER = 0.01f;

		public static float SLOW_RECHARGE_THRESHOLD = 5.7f;

		public static float SLOW_RECHARGE_MULTIPLIER = 0.1f;

		internal const float TRAPPED_AIR_PRESSURIZED_THRESHOLD = 1.5f;

		internal static float PIPE_AUDIO_SATURATION = 20f;

		internal static float PIPE_AUDIO_EXPONENT = 0.4f;

		internal static float VENT_AUDIO_SATURATION = 5f;
	}
}
