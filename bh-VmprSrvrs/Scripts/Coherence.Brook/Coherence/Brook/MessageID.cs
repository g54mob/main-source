using System;

namespace Coherence.Brook
{
	public readonly struct MessageID : IEquatable<MessageID>
	{
		public const ushort MaxRange = 32768;

		public const ushort MaxValue = 32767;

		public ushort Value { get; }

		public MessageID(ushort value)
		{
			Value = 0;
		}

		public MessageID Next()
		{
			return default(MessageID);
		}

		public MessageID Advance(int count)
		{
			return default(MessageID);
		}

		public int Distance(MessageID id)
		{
			return 0;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool Equals(MessageID other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		private static void AssertValid(ushort id)
		{
		}
	}
}
