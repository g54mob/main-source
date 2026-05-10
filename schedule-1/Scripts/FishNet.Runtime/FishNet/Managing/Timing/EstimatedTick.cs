using System.Runtime.CompilerServices;

namespace FishNet.Managing.Timing
{
	public struct EstimatedTick
	{
		public enum OldTickOption : byte
		{
			Discard = 0,
			SetLastRemoteTick = 1,
			SetRemoteTick = 2
		}

		public uint LocalTick;

		public uint RemoteTick;

		public uint LastRemoteTick;

		public bool IsUnset => false;

		public bool IsCurrent(TimeManager tm)
		{
			return false;
		}

		public uint LocalTickDifference(TimeManager tm)
		{
			return 0u;
		}

		public bool Update(TimeManager tm, uint remoteTick, OldTickOption oldTickOption = OldTickOption.Discard)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint Value(TimeManager tm)
		{
			return 0u;
		}

		public uint Value(TimeManager tm, out bool isCurrent)
		{
			isCurrent = default(bool);
			return 0u;
		}

		public void Reset()
		{
		}
	}
}
