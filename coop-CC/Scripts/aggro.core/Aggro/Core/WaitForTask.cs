using System.Threading.Tasks;
using UnityEngine;

namespace Aggro.Core
{
	public class WaitForTask : CustomYieldInstruction
	{
		private Task _task;

		public override bool keepWaiting
		{
			get
			{
				if (_task.Exception != null)
				{
					Debug.LogException(_task.Exception);
					throw _task.Exception.GetBaseException();
				}
				return !_task.IsCompleted;
			}
		}

		public WaitForTask(Task task)
		{
			_task = task;
		}

		public void SetTask(Task task)
		{
			_task = task;
		}

		public override void Reset()
		{
			_task = null;
		}
	}
}
