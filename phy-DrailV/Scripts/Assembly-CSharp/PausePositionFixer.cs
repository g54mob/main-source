using System.Collections;
using DV;
using DV.Utils;
using UnityEngine;

public class PausePositionFixer : MonoBehaviour
{
	private Vector3 playerLocalPosition;

	private bool wasStrafe;

	private bool isVR;

	private bool playerTeleportedWhilePaused;

	private Coroutine ResetNonVRCoro;

	private float PauseTeleportModeOffsetSeated => GamePreferences.Get<float>(Preferences.PlayerSeatedHeight);

	private float PauseTeleportModeOffsetRoomscale => 1.62f + GamePreferences.Get<float>(Preferences.PlayerRoomscaleHeight);

	private bool IsSeated => GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType);

	private void Start()
	{
		isVR = VRManager.IsVREnabled();
		SingletonBehaviour<AppUtil>.Instance.EndOfFrameGamePaused += OnGamePaused;
		SingletonBehaviour<AppUtil>.Instance.GameUnpaused += OnGameResumed;
		PlayerManager.PlayerTeleportStarted += TeleportStarted;
	}

	private void TeleportStarted()
	{
		if (SingletonBehaviour<AppUtil>.Instance.IsTimePaused)
		{
			playerTeleportedWhilePaused = true;
		}
	}

	private void WorldMoved(WorldMover mover, Vector3 vec)
	{
		if (PlayerManager.Car == null)
		{
			playerLocalPosition -= vec;
		}
	}

	private void OnDestroy()
	{
		PlayerManager.PlayerTeleportStarted -= TeleportStarted;
		if (!UnloadWatcher.isUnloading)
		{
			SingletonBehaviour<AppUtil>.Instance.EndOfFrameGamePaused -= OnGamePaused;
			SingletonBehaviour<AppUtil>.Instance.GameUnpaused -= OnGameResumed;
			if ((bool)SingletonBehaviour<WorldMover>.Instance)
			{
				SingletonBehaviour<WorldMover>.Instance.WorldMoved -= WorldMoved;
			}
		}
	}

	private void OnGameResumed()
	{
		if (playerTeleportedWhilePaused)
		{
			playerTeleportedWhilePaused = false;
			return;
		}
		if (isVR)
		{
			bool flag = GamePreferences.Get<bool>(Preferences.SmoothLocomotion);
			if (flag == wasStrafe)
			{
				if (!flag)
				{
					playerLocalPosition.y += (IsSeated ? PauseTeleportModeOffsetSeated : PauseTeleportModeOffsetRoomscale);
				}
				PlayerManager.PlayerTransform.localPosition = playerLocalPosition;
			}
		}
		else
		{
			CustomFirstPersonController component = PlayerManager.PlayerTransform.GetComponent<CustomFirstPersonController>();
			component.isRepositioning = true;
			PlayerManager.PlayerTransform.localPosition = playerLocalPosition;
			if (ResetNonVRCoro != null)
			{
				StopCoroutine(ResetNonVRCoro);
			}
			ResetNonVRCoro = StartCoroutine(ResetNonVrPlayerPos(component));
		}
		if ((bool)SingletonBehaviour<WorldMover>.Instance)
		{
			SingletonBehaviour<WorldMover>.Instance.WorldMoved -= WorldMoved;
		}
	}

	private IEnumerator ResetNonVrPlayerPos(CustomFirstPersonController c)
	{
		yield return WaitFor.EndOfFrame;
		c.isRepositioning = false;
	}

	private void OnGamePaused()
	{
		playerLocalPosition = PlayerManager.PlayerTransform.localPosition;
		wasStrafe = isVR && GamePreferences.Get<bool>(Preferences.SmoothLocomotion);
		if (isVR && !wasStrafe)
		{
			playerLocalPosition.y -= (IsSeated ? PauseTeleportModeOffsetSeated : PauseTeleportModeOffsetRoomscale);
		}
		if ((bool)SingletonBehaviour<WorldMover>.Instance)
		{
			SingletonBehaviour<WorldMover>.Instance.WorldMoved += WorldMoved;
		}
	}
}
