using System;
using System.Collections;
using DV.Simulation.Brake;
using DV.Simulation.Cars;
using DV.UI;
using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;

namespace DV
{
	public class BedSleepingController : SingletonBehaviour<BedSleepingController>
	{
		private const float MIN_SLEEP_COOLDOWN_FRACTION = 0.5f;

		private const float MAX_SLEEP_COOLDOWN_FRACTION = 1f;

		private const float SLEEP_TO_COOLDOWN_RATIO_FOR_MAX_COOLDOWN = 0.75f;

		private static string N = "[BedSleepingController]";

		public DateTime lastWakeTime = DateTime.MinValue;

		private int lastSleepDurationSeconds;

		public bool IsSleeping { get; private set; }

		public new static string AllowAutoCreate()
		{
			return N;
		}

		public void Sleep(float amountOfSecondsToSleep, float fadeTime, float waitBeforeUnfade, BedSleeping bed)
		{
			float num = ((!VRManager.IsVREnabled()) ? 4 : 0);
			SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(SafetyResetCoro(2f * fadeTime + waitBeforeUnfade + num));
			SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(SleepCoro(amountOfSecondsToSleep, fadeTime, waitBeforeUnfade, bed));
		}

		private IEnumerator SleepCoro(float amountOfSecondsToSleep, float fadeTime, float waitBeforeUnfade, BedSleeping bed)
		{
			if (IsSleeping || FastTravelController.IsFastTravelling)
			{
				Debug.LogError($"{N} Cannot sleep now (IsSleeping={IsSleeping}, IsFastTravelling={FastTravelController.IsFastTravelling})");
				yield break;
			}
			IsSleeping = true;
			yield return null;
			TogglePlayerMovement(allowMovement: false);
			CameraAnchorBedSleepingAnimation anim = null;
			if (PlayerManager.PlayerTransform.TryGetComponent<CameraAnchorBedSleepingAnimation>(out anim))
			{
				anim.pillowTarget = ((bed != null) ? bed.pillowTarget : null);
				anim.enabled = true;
				yield return WaitFor.SecondsRealtime(anim.duration - 0.2f);
			}
			ScreenFade.Fade(Color.black, fadeTime);
			yield return WaitFor.SecondsRealtime(fadeTime);
			TurnOffAndEngageHandbrakeOnAllLocos();
			EngageHandbrakesOnCurrentTrain();
			TimeAdvance.AdvanceTime(amountOfSecondsToSleep);
			lastWakeTime = GetCurrentIngameTime();
			if ((bool)anim)
			{
				anim.enabled = false;
			}
			if (PlayerManager.PlayerTransform.TryGetComponent<CustomFirstPersonController>(out var component))
			{
				Vector3 forward = -PlayerManager.PlayerTransform.forward;
				forward.y = 0f;
				component.ForceLookRotation(Quaternion.LookRotation(forward, Vector3.up));
			}
			yield return WaitFor.SecondsRealtime(waitBeforeUnfade);
			ScreenFade.Fade(Color.clear, fadeTime);
			yield return WaitFor.SecondsRealtime(fadeTime);
		}

		private IEnumerator SafetyResetCoro(float waitTime)
		{
			yield return WaitFor.SecondsRealtime(waitTime);
			IsSleeping = false;
			TogglePlayerMovement(allowMovement: true);
			ScreenFade.Fade(Color.clear, 0f);
		}

		public void TogglePlayerMovement(bool allowMovement)
		{
			PlayerManager.PlayerTransform.GetComponent<LocomotionInputWrapper>().inputEnabled = allowMovement;
			PlayerManager.PlayerTransform.GetComponent<CustomFirstPersonController>().m_MouseLook.ChangeSlowdownState((!allowMovement) ? MouseSensitivityState.Crawl : MouseSensitivityState.Normal);
		}

		public SleepingData GetSleepingData()
		{
			bool flag = (bool)PlayerManager.Car && PlayerManager.Car.GetVelocity().sqrMagnitude > 1f;
			DateTime dateTime = DateTime.Now;
			if ((bool)SingletonBehaviour<WeatherDriver>.Instance)
			{
				dateTime = SingletonBehaviour<WeatherDriver>.Instance.manager.DateTime;
			}
			SleepingData.SleepPermissionState sleepPermissionState = SleepingData.SleepPermissionState.Allowed;
			if (Globals.G.GameParams.SleepCooldownInHours < 0)
			{
				sleepPermissionState = SleepingData.SleepPermissionState.DeniedSleepDisabled;
			}
			else if (flag)
			{
				sleepPermissionState = SleepingData.SleepPermissionState.DeniedTrainIsMoving;
			}
			else if ((dateTime - lastWakeTime).TotalSeconds < (double)GetMinimumTimeSinceLastWakeSeconds())
			{
				sleepPermissionState = SleepingData.SleepPermissionState.DeniedTooSoon;
			}
			return new SleepingData
			{
				currentTime = dateTime,
				nextSleepMinTime = lastWakeTime.AddSeconds(GetMinimumTimeSinceLastWakeSeconds()),
				sleepPermissionState = sleepPermissionState
			};
		}

		private void TurnOffAndEngageHandbrakeOnAllLocos()
		{
			if (!SingletonBehaviour<CarSpawner>.Instance)
			{
				return;
			}
			foreach (TrainCar allLoco in SingletonBehaviour<CarSpawner>.Instance.AllLocos)
			{
				if (allLoco == null)
				{
					Debug.LogError(N + " encountered a null car!");
					continue;
				}
				BaseControlsOverrider baseControlsOverrider = allLoco.SimController?.controlsOverrider;
				if (baseControlsOverrider == null)
				{
					Debug.LogWarning(N + " " + allLoco.name + " " + allLoco.ID + " has no BaseControlsOverrider!");
				}
				else
				{
					baseControlsOverrider.SetNeutralState();
				}
			}
		}

		private void EngageHandbrakesOnCurrentTrain()
		{
			if ((bool)PlayerManager.Car)
			{
				BrakeSystem brakeSystem = PlayerManager.Car.brakeSystem;
				if (!brakeSystem.brakeset.anyHandbrakeApplied)
				{
					brakeSystem.SetHandbrakePosition(1f);
				}
			}
		}

		private DateTime GetCurrentIngameTime()
		{
			if ((bool)SingletonBehaviour<WeatherDriver>.Instance)
			{
				return SingletonBehaviour<WeatherDriver>.Instance.manager.DateTime;
			}
			return DateTime.Now;
		}

		private float GetMinimumTimeSinceLastWakeSeconds()
		{
			float num = (float)Globals.G.GameParams.SleepCooldownInHours * 3600f;
			if (lastSleepDurationSeconds <= 0)
			{
				return num;
			}
			float num2 = num * 0.75f;
			float num3 = Mathf.Clamp((float)lastSleepDurationSeconds / num2, 0.5f, 1f);
			return num * num3 * 3600f;
		}

		public void LoadFrom(SaveGameData saveGameData)
		{
			double? num = saveGameData.GetDouble("Last_wake_time");
			if (num.HasValue)
			{
				lastWakeTime = DateTime.FromOADate(num.Value);
				Debug.Log($"{N} Loaded last bed wakeup time: {lastWakeTime}");
			}
			else
			{
				Debug.LogWarning($"{N} Last bed wakeup time not present in savegame, value will remain {lastWakeTime}");
			}
			int? num2 = saveGameData.GetInt("Last_sleep_duration");
			if (num2.HasValue)
			{
				lastSleepDurationSeconds = num2.Value;
				Debug.Log($"{N} Loaded last sleep duration: {lastSleepDurationSeconds}");
			}
			else
			{
				Debug.LogWarning($"{N} Last sleep duration not present in savegame, value will remain {lastSleepDurationSeconds}");
			}
		}

		public void SaveTo(SaveGameData saveGameData)
		{
			double value = lastWakeTime.ToOADate();
			int value2 = lastSleepDurationSeconds;
			saveGameData.SetDouble("Last_wake_time", value);
			saveGameData.SetInt("Last_sleep_duration", value2);
		}
	}
}
