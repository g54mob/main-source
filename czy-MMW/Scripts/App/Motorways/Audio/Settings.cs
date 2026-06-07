using UnityEngine;

namespace Motorways.Audio
{
	public static class Settings
	{
		public static class Attenuation
		{
			public static class Zoom
			{
				public static readonly Vector2 DYNAMIC_RANGE = new Vector2(0.33f, 1f);

				public static readonly float MENU = DYNAMIC_RANGE.x + 0.5f * (DYNAMIC_RANGE.y - DYNAMIC_RANGE.x);

				public const bool HOUSE_SPAWNED = false;

				public const bool DESTINATION_ACTIVATED = false;

				public const bool IDLE_LOOPS = false;

				public const bool GROUP_LOOPS_MENU = false;
			}

			public const float FALLOFF = 5f;

			public const float FALLOFF_HOCKETS_MENU = 33f;

			public const float FALLOFF_IDLE_LOOPS_MENU = 500f;

			public const float FALLOFF_SPAWNS = 25f;
		}

		public static class Gain
		{
			public static readonly Vector2 KEYBOARD = new Vector2(1f, 0.3f);

			public const float BASS_STATIC = 0.5f;

			public const float BASS_AMBIENT = 0.4f;

			public const float CLOCK = 0.5f;

			public const float CHORD_STARTUP = 0.55f;

			public const float CHORD_INGAME = 0.275f;

			public static readonly Vector2 CHORD_WEEKOVER = new Vector2(0.25f, 0.55f);

			public const float CHORD_DESTINATION_IN_GROUP_Y = 0.33f;

			public const float CHORD_DESTINATION_IN_GROUP_N = 0.15f;

			public const float GROUP_LOOP_HOME = 0.17f;

			public const float GROUP_LOOP_DEST_MAX = 0.4f;

			public const float IDLE_LOOP = 0.125f;

			public const float IDLE_LOOP_MENU = 3f / 32f;

			public const float VEHICLE_MOTOR = 0.2f;

			public const float VEHICLE_RECEIVES_PIN = 0.18f;

			public const float VEHICLE_RECEIVES_PIN_REVERSE = 0.01f;

			public const float VEHICLE_HORN = 0.11f;

			public const float SFX_WHOOSH = 0.075f;

			public static readonly Vector2 UI_CHECKBOX_HOVER = new Vector2(0.1f, 0.35f);

			public const float HOUSE_SPAWNED = 1f;

			public static readonly float[] HOUSE_SPAWNED_CHORD = new float[2] { 0.05f, 0.1f };

			public const float DESTINATION_ACTIVATED = 1f;

			public static readonly Vector2 DESTINATION_DEMANDED = new Vector2(0.2f, 0.4f);

			public const float MOTORWAY_HANDLE_RELEASED = 1f;

			public const float MOTORWAY_HANDLE_PULLED = 0.75f;
		}

		public const float PAN_WIDTH = 4f;

		public const float PAN_CLOCK = 0.75f;

		public const int CHORD_STACK_CEILING = 0;

		public static float PITCH_PAUSE = 0.9375f;

		public static float PITCH_NIGHT = 1.6875f;

		public static float PITCH_ANCHOR = 1f;

		public static float PITCH_MIXBUS_ATTENUATION = -3f;

		public static readonly Vector2 PITCH_BOING_IN_PLACE = new Vector2(0f, 0.04f);

		public static readonly Vector2 PITCH_TREE_BULLDOZED = new Vector2(0f, 0.1f);

		public static readonly Vector2 ECHO_DECAY_RANGE = new Vector2(0.25f, 0.45f);

		public static readonly Vector2 ECHO_WET_RANGE = new Vector2(0.1f, 0.2f);

		public const float ECHO_OFF_DECAY = 0.75f;

		public const double IDLE_LOOP_FADE_IN = 2.0;

		public const double IDLE_LOOP_FADE_OUT = 3.5;

		public const double BASS_FADE_IN = 0.5;

		public const double BASS_FADE_OUT = 0.5;

		public static readonly Param.Group UPGRADE_GRAB = Param.Gain(1f).Pitch(0.75f);

		public static readonly Param.Group UPGRADE_RELEASE = Param.Gain(0.75f).Pitch(0.33f);

		public static readonly Param.Group BUILD_BRIDGE = Param.Gain(0.33f, 0.6f);

		public static readonly Param.Group BUILD_TUNNEL = Param.Gain(0.3f, 0.55f);

		public static readonly Param.Group BUILD_ROAD = Param.Gain(0.33f, 0.6f).Pitch(0.75f, 1.25f);

		public static readonly Param.Group DELETE_ROAD = Param.Gain(0.25f, 0.375f);

		public static readonly Param.Group MOTHBALL_ROAD = Param.Gain(1f, 0.5f).Pitch(1f, 1.5f);

		public static readonly Param.Group BULLDOZE_TREE = Param.Gain(0.5f, 0.75f).Pitch(0.75f, 1.25f);
	}
}
