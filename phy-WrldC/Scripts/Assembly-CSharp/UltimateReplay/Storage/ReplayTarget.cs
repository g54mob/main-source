using System;

namespace UltimateReplay.Storage
{
	[Serializable]
	[ReplayIgnore]
	public abstract class ReplayTarget : ReplayBehaviour
	{
		protected float duration;

		public abstract float Duration { get; }

		public abstract int MemorySize { get; }

		public abstract ReplayInitialDataBuffer InitialStateBuffer { get; }

		public abstract string TargetSceneName { get; }

		public abstract void RecordSnapshot(ReplaySnapshot state);

		public abstract ReplaySnapshot RestoreSnapshot(float offset);

		public abstract void PrepareTarget(ReplayTargetTask mode);
	}
}
