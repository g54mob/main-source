using Controllers;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public class OverlayLock : MonoBehaviour
	{
		private InputLock.Lock Lock;

		private void Update()
		{
			if (Platform.Current == null || !Platform.Current.ShouldPauseWhenNotFocused || PlatformSettings.IsEditor)
			{
				return;
			}
			if (Lock != default(InputLock.Lock))
			{
				if (Platform.Current.GameHasFocus)
				{
					InputSourceIdentifier.DefaultInputSource.GlobalLock.ReleaseLock(Lock);
					Lock = default(InputLock.Lock);
				}
			}
			else if (!Platform.Current.GameHasFocus)
			{
				Lock = InputSourceIdentifier.DefaultInputSource.GlobalLock.NewLock(PlayerLockState.PauseAndLockMenu);
			}
		}
	}
}
