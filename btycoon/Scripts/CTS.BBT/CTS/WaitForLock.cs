using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class WaitForLock : CustomYieldInstruction
	{
		private readonly ILockable _lockable;

		public override bool keepWaiting => !_lockable.IsLocked();

		public WaitForLock(ILockable lockable)
		{
			_lockable = lockable;
		}
	}
}
