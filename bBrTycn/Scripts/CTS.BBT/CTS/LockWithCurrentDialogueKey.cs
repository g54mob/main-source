using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class LockWithCurrentDialogueKey : LockWithCurrentDialogueBase
	{
		[SerializeField]
		private StringKey _lockKey;

		[SerializeField]
		private SoftReference<StringKey, ILockable> _lockable;

		protected override ILockable GetLockable()
		{
			return _lockable.Get(_lockKey);
		}
	}
}
