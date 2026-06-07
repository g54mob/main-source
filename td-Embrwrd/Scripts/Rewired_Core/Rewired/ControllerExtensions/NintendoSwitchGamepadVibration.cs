using System;
using Rewired.Utils.Attributes;

namespace Rewired.ControllerExtensions
{
	[Serializable]
	public struct NintendoSwitchGamepadVibration : IEquatable<NintendoSwitchGamepadVibration>
	{
		internal const int frequencyLowDefault = 160;

		internal const int frequencyHighDefault = 320;

		public const float frequencyLowMin = 40.875885f;

		public const float frequencyLowMax = 626.28613f;

		public const float frequencyHighMin = 81.75177f;

		public const float frequencyHighMax = 1252.5723f;

		[FieldRange(0f, 1f)]
		public float amplitudeLow;

		[FieldRange(40.875885f, 626.28613f)]
		public float frequencyLow;

		[FieldRange(0f, 1f)]
		public float amplitudeHigh;

		[FieldRange(81.75177f, 1252.5723f)]
		public float frequencyHigh;

		internal static NintendoSwitchGamepadVibration XTVNlPYHgcNBROagJvabNTwYOXwI => default(NintendoSwitchGamepadVibration);

		internal NintendoSwitchGamepadVibration(float P_0, float P_1, float P_2, float P_3)
		{
			amplitudeLow = 0f;
			frequencyLow = 0f;
			amplitudeHigh = 0f;
			frequencyHigh = 0f;
		}

		public bool Equals(NintendoSwitchGamepadVibration other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(NintendoSwitchGamepadVibration a, NintendoSwitchGamepadVibration b)
		{
			return false;
		}

		public static bool operator !=(NintendoSwitchGamepadVibration a, NintendoSwitchGamepadVibration b)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public static NintendoSwitchGamepadVibration Create()
		{
			return default(NintendoSwitchGamepadVibration);
		}

		public static NintendoSwitchGamepadVibration Create(float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh)
		{
			return default(NintendoSwitchGamepadVibration);
		}

		public static NintendoSwitchGamepadVibration Create(float amplitudeLow, float amplitudeHigh)
		{
			return default(NintendoSwitchGamepadVibration);
		}
	}
}
