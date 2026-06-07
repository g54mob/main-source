using System;

namespace Gh
{
	public class CoroutineExWaitFor : CoroutineExInstruction
	{
		private float _duration;

		private string _instanceId;

		private Func<bool> _endCondition;

		private Func<bool> _abortCondition;

		private bool _useUnscaledTime;

		private int _startFrame;

		public override bool ContinueOnSameFrame => false;

		public CoroutineExWaitFor(float duration, Func<bool> abortCondition = null, string instanceId = null, bool useUnscaledTime = false)
		{
		}

		public CoroutineExWaitFor(Func<bool> endCondition)
		{
		}

		public override bool Update()
		{
			return false;
		}

		public override void Finish()
		{
		}
	}
}
