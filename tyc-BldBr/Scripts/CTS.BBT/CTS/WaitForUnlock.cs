using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class WaitForUnlock : CustomYieldInstruction
	{
		private readonly ILockable _lockable;

		public override bool keepWaiting => _lockable.IsLocked();

		public WaitForUnlock(ILockable lockable)
		{
			_lockable = lockable;
		}
	}
}
