using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class LockWithCurrentDialogue : LockWithCurrentDialogueBase
	{
		[SerializeField]
		[Inject(false)]
		private SoftReference<ILockable> _lockable;

		protected override ILockable GetLockable()
		{
			return _lockable.Value;
		}
	}
}
