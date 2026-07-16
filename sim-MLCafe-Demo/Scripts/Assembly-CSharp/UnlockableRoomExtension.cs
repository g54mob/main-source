using System;
using UnityEngine;

[Serializable]
public class UnlockableRoomExtension : Unlockable, IProgression
{
	[SerializeField]
	[Range(1f, 4f)]
	private int unlockExtensionsCount = 1;

	void IProgression.OnUnlock(int level)
	{
		ShopBuilder.UnlockRoomExtensions(unlockExtensionsCount);
		ProgressionManager.Unlock("RoomExtension", level);
	}
}
