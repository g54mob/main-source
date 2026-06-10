using System;

namespace NSMedieval.Goap
{
	public readonly struct ThreadSequenceStep
	{
		private readonly Func<bool> onStart;

		private readonly Func<bool> onThread;

		private readonly Func<bool> onFinish;

		public Func<bool> OnStart => onStart;

		public Func<bool> OnThread => onThread;

		public Func<bool> OnFinish => onFinish;

		public ThreadSequenceStep(Func<bool> onStart = null, Func<bool> onThread = null, Func<bool> onFinish = null)
		{
			this.onStart = onStart;
			this.onThread = onThread;
			this.onFinish = onFinish;
		}
	}
}
