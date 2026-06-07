namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class DualSenseTriggerEffect
	{
		public const byte strengthMin = 0;

		public const byte strengthMax = 8;

		public const byte amplitudeMin = 0;

		public const byte amplitudeMax = 8;

		public const byte frequencyMin = 0;

		public const byte frequencyMax = byte.MaxValue;

		public const byte positionCount = 10;

		public const byte positionMin = 0;

		public const byte positionMax = 9;

		internal static bool IsInRange(byte value, byte min, byte max)
		{
			return false;
		}

		internal static byte Clamp(byte value, byte min, byte max)
		{
			return 0;
		}

		internal static float NormalizeStrength(byte value)
		{
			return 0f;
		}

		internal static float NormalizePosition(byte value)
		{
			return 0f;
		}

		internal static float NormalizeAmplitude(byte value)
		{
			return 0f;
		}

		internal static float NormalizeFrequency(byte value)
		{
			return 0f;
		}

		internal static void ThrowArgumentOutOfRange(string name, byte min, byte max)
		{
		}

		internal static void LogValueClamped(byte origValue, byte clampedValue)
		{
		}
	}
}
