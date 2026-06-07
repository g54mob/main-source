using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class DiscoThemeUnlock : CTSBehaviour
	{
		[SerializeField]
		private UIMessageBase _message;

		private void Start()
		{
			if (!UnlockingManager.ContainKey(EUnlockKey.DiscoBarPackage))
			{
				CTSSingleton<UIMessage>.Instance.ShowMessage(_message);
			}
		}
	}
}
