using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class LockButtonWithCurrentDialogue : LockWithCurrentDialogueBase
	{
		[SerializeField]
		[Inject(false)]
		private ISelectable _selectable;

		protected override ILockable GetLockable()
		{
			return _selectable;
		}
	}
}
