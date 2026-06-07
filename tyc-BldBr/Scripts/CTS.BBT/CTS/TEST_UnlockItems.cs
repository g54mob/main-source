using System;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class TEST_UnlockItems : MonoBehaviour
	{
		public EUnlockKey unlockingKey;

		public EUnlockKey currentKey;

		[Button("Unlock", EButtonEnableMode.Playmode)]
		private void Unlock()
		{
			Array values = Enum.GetValues(typeof(EUnlockKey));
			for (int i = 0; i < values.Length; i++)
			{
				EUnlockKey eUnlockKey = (EUnlockKey)values.GetValue(i);
				if (unlockingKey.HasFlag(eUnlockKey) && !currentKey.HasFlag(eUnlockKey))
				{
					currentKey += (int)eUnlockKey;
				}
			}
			UnlockingManager.AddUnlockKey(currentKey);
		}

		[Button("Clear", EButtonEnableMode.Playmode)]
		private void Clear()
		{
			unlockingKey = (EUnlockKey)0;
			currentKey = (EUnlockKey)0;
			UnlockingManager.ClearAll();
			Unlock();
		}

		private void OnDestroy()
		{
			Clear();
		}
	}
}
