using PajamaLlama.Utilities;
using UnityEngine;

namespace PajamaLlama.YieldInstructions
{
	public class WaitForThreadpoolManagerTask : CustomYieldInstruction
	{
		private ThreadPoolManager.ITask _task;

		public override bool keepWaiting
		{
			get
			{
				if (!_task.Completed)
				{
					if (CoroutineRunner.IsRunning(this))
					{
						_task.ThreadPoolWaitCallback(null);
					}
					return true;
				}
				return false;
			}
		}

		public WaitForThreadpoolManagerTask(ThreadPoolManager.ITask task)
		{
			_task = task;
		}
	}
}
