using System;
using Unity.Collections;

namespace LitMotion
{
	[Serializable]
	public struct StringOptions : IMotionOptions, IEquatable<StringOptions>
	{
		public ScrambleMode ScrambleMode;

		public bool RichTextEnabled;

		public FixedString64Bytes CustomScrambleChars;

		public uint RandomSeed;

		public readonly bool Equals(StringOptions other)
		{
			if (other.ScrambleMode == ScrambleMode && other.RichTextEnabled == RichTextEnabled && other.CustomScrambleChars == CustomScrambleChars)
			{
				return other.RandomSeed == RandomSeed;
			}
			return false;
		}

		public override readonly bool Equals(object obj)
		{
			if (obj is StringOptions other)
			{
				return Equals(other);
			}
			return false;
		}

		public override readonly int GetHashCode()
		{
			return HashCode.Combine(ScrambleMode, RichTextEnabled, CustomScrambleChars, RandomSeed);
		}
	}
}
