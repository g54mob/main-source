using System;
using UnityEngine;

namespace CTS
{
	public class LockSelectionOptionMenu : MonoBehaviour
	{
		public static Action LockSelection;

		public static Action UnlockSelection;

		public void Lock()
		{
			LockSelection?.Invoke();
		}

		public void Unlock()
		{
			UnlockSelection?.Invoke();
		}
	}
}
