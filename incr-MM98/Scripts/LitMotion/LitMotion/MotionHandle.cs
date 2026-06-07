using System;

namespace LitMotion
{
	public struct MotionHandle : IEquatable<MotionHandle>
	{
		public static readonly MotionHandle None;

		public int StorageId;

		public int Index;

		public int Version;

		public readonly double Time
		{
			get
			{
				return MotionManager.GetDataRef(this, checkIsInSequence: false).State.Time;
			}
			set
			{
				MotionManager.SetTime(this, value);
			}
		}

		public readonly float Delay => MotionManager.GetDataRef(this, checkIsInSequence: false).Parameters.Delay;

		public readonly float Duration => MotionManager.GetDataRef(this, checkIsInSequence: false).Parameters.Duration;

		public readonly double TotalDuration => MotionManager.GetDataRef(this, checkIsInSequence: false).Parameters.TotalDuration;

		public readonly int Loops => MotionManager.GetDataRef(this, checkIsInSequence: false).Parameters.Loops;

		public readonly int CompletedLoops => MotionManager.GetDataRef(this).State.CompletedLoops;

		public readonly float PlaybackSpeed
		{
			get
			{
				return MotionManager.GetDataRef(this).State.PlaybackSpeed;
			}
			set
			{
				MotionManager.GetDataRef(this).State.PlaybackSpeed = value;
			}
		}

		public override readonly string ToString()
		{
			return $"MotionHandle`{StorageId} ({Index}:{Version})";
		}

		public readonly bool Equals(MotionHandle other)
		{
			if (Index == other.Index && Version == other.Version)
			{
				return StorageId == other.StorageId;
			}
			return false;
		}

		public override readonly bool Equals(object obj)
		{
			if (obj is MotionHandle other)
			{
				return Equals(other);
			}
			return false;
		}

		public override readonly int GetHashCode()
		{
			return HashCode.Combine(Index, Version, StorageId);
		}

		public static bool operator ==(MotionHandle a, MotionHandle b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(MotionHandle a, MotionHandle b)
		{
			return !(a == b);
		}
	}
}
