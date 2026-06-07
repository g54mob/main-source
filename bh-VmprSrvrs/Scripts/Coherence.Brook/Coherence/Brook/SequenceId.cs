using System;

namespace Coherence.Brook
{
	public struct SequenceId : IEquatable<SequenceId>
	{
		public const byte MaxRange = 128;

		public const byte MaxValue = 127;

		public static SequenceId Max;

		public byte Value { get; }

		public SequenceId(byte id)
		{
			Value = 0;
		}

		public SequenceId Next()
		{
			return default(SequenceId);
		}

		private static bool IsValid(byte id)
		{
			return false;
		}

		public int Distance(SequenceId otherId)
		{
			return 0;
		}

		public bool IsValidSuccessor(SequenceId nextId)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public bool Equals(SequenceId other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}
	}
}
