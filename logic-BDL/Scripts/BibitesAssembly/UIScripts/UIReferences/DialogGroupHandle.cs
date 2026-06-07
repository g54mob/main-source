using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UIScripts.UIReferences
{
	public class DialogGroupHandle
	{
		private List<DialogHandle> Dialogs = new List<DialogHandle>();

		private UnityAction OnGood;

		private UnityAction OnDismiss;

		public int Count => Dialogs.Count;

		public DialogGroupHandle(UnityAction onDismiss = null, UnityAction onGood = null)
		{
			OnGood = onGood;
			OnDismiss = onDismiss;
		}

		public void Add(DialogHandle handle)
		{
			Dialogs.Add(handle);
			handle.AfterDismiss(DismissAllDialogs);
			if (handle is ChoicePopupHandle choicePopupHandle)
			{
				choicePopupHandle.AfterAccept(AcceptDialog);
			}
		}

		public void Clear()
		{
			Dialogs.Clear();
		}

		public void AcceptDialog()
		{
			if (Dialogs.Count > 0)
			{
				Dialogs.Remove(Dialogs.FindLast((DialogHandle _p) => true));
				if (Dialogs.Count > 0)
				{
					return;
				}
			}
			OnGood?.Invoke();
		}

		public void DismissAllDialogs()
		{
			if (Dialogs == null || Dialogs.Count == 0)
			{
				return;
			}
			Dialogs.ForEach(delegate(DialogHandle _p)
			{
				if (!_p.dismissed)
				{
					Object.Destroy(_p.gameObject);
				}
			});
			Dialogs.Clear();
			OnDismiss?.Invoke();
		}
	}
}
