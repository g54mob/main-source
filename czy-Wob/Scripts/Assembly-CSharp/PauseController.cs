using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
	private static bool isPaused = false;

	private static bool UIEnabled = true;

	private List<LockReason> pauseReasons = new List<LockReason>();

	public void OnSceneChanged()
	{
		pauseReasons.Clear();
		UnpauseGame();
	}

	public static bool IsPaused()
	{
		return isPaused;
	}

	public static bool IsUIEnabled()
	{
		return UIEnabled;
	}

	public bool DogGutScreenOpen()
	{
		if (pauseReasons.Contains(LockReason.GUT_GUI))
		{
			return true;
		}
		return false;
	}

	public void RequestPause(LockReason reason)
	{
		if (pauseReasons.Contains(reason))
		{
			Debug.LogError("Attempting to double-pause the game for reason: " + reason);
			return;
		}
		pauseReasons.Add(reason);
		if (pauseReasons.Count == 1)
		{
			PauseGame();
		}
	}

	public void RequestUnpause(LockReason reason)
	{
		if (pauseReasons.Contains(reason))
		{
			pauseReasons.Remove(reason);
			if (pauseReasons.Count == 0)
			{
				UnpauseGame();
			}
		}
	}

	public void RequestUIEnabled()
	{
		UIEnabled = true;
	}

	public void RequestUIDisabled()
	{
		UIEnabled = false;
	}

	private void PauseGame()
	{
		GUIManagerPens globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI, nullAllowed: true);
		if (globalComponent != null)
		{
			globalComponent.OnGamePaused();
		}
		SFXOverlord.LockInWorldSFX(LockReason.PAUSE_MENU);
		isPaused = true;
		Time.timeScale = 0f;
	}

	private void UnpauseGame()
	{
		SFXOverlord.UnlockInWorldSFX(LockReason.PAUSE_MENU);
		isPaused = false;
		UIEnabled = true;
		Time.timeScale = 1f;
	}
}
