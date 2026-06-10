using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Lofelt.NiceVibrations
{
	public static class GamepadRumbler
	{
		private class GamepadState
		{
			public GamepadRumble loadedRumble;

			public bool rumbleLoaded;

			public System.Timers.Timer rumbleTimer;

			public int rumbleIndex = -1;

			public long rumblePositionMs;

			public Stopwatch playbackWatch = new Stopwatch();

			public float lowFrequencyMotorSpeedMultiplication = 1f;

			public float highFrequencyMotorSpeedMultiplication = 1f;

			public int gamepadID;

			public GamepadState(int id)
			{
				gamepadID = id;
				rumbleTimer = new System.Timers.Timer();
			}
		}

		private static Dictionary<int, GamepadState> gamepadStates = new Dictionary<int, GamepadState>();

		private static int currentGamepadID = -1;

		public static int GetCurrentGamepadID()
		{
			return currentGamepadID;
		}

		public static void Init()
		{
			_ = SynchronizationContext.Current;
		}

		public static bool CanPlay()
		{
			return CanPlay(currentGamepadID);
		}

		public static bool CanPlay(int gamepadID)
		{
			if (!gamepadStates.ContainsKey(gamepadID))
			{
				return false;
			}
			GamepadState gamepadState = gamepadStates[gamepadID];
			if (IsConnected(gamepadID) && gamepadState.rumbleLoaded)
			{
				return gamepadState.loadedRumble.IsValid();
			}
			return false;
		}

		private static Gamepad GetGamepad(int gamepadID)
		{
			if (gamepadID >= 0)
			{
				if (gamepadID >= Gamepad.all.Count)
				{
					return Gamepad.current;
				}
				return Gamepad.all[gamepadID];
			}
			return Gamepad.current;
		}

		private static GamepadState GetOrCreateState(int gamepadID)
		{
			if (!gamepadStates.ContainsKey(gamepadID))
			{
				GamepadState gamepadState = new GamepadState(gamepadID);
				SynchronizationContext syncContext = SynchronizationContext.Current;
				gamepadState.rumbleTimer.Elapsed += delegate
				{
					syncContext.Post(delegate
					{
						ProcessNextRumble(gamepadID);
					}, null);
				};
				gamepadStates[gamepadID] = gamepadState;
			}
			return gamepadStates[gamepadID];
		}

		public static void SetCurrentGamepad(int gamepadID)
		{
			if (gamepadID < Gamepad.all.Count)
			{
				currentGamepadID = gamepadID;
			}
		}

		public static bool IsConnected()
		{
			return IsConnected(currentGamepadID);
		}

		public static bool IsConnected(int gamepadID)
		{
			return GetGamepad(gamepadID) != null;
		}

		public static void Load(GamepadRumble rumble)
		{
			Load(rumble, currentGamepadID);
		}

		public static void Load(GamepadRumble rumble, int gamepadID)
		{
			GamepadState orCreateState = GetOrCreateState(gamepadID);
			if (rumble.IsValid())
			{
				orCreateState.loadedRumble = rumble;
				orCreateState.rumbleLoaded = true;
				orCreateState.lowFrequencyMotorSpeedMultiplication = 1f;
				orCreateState.highFrequencyMotorSpeedMultiplication = 1f;
			}
			else
			{
				Unload(gamepadID);
			}
		}

		public static void Play()
		{
			Play(currentGamepadID);
		}

		public static void Play(int gamepadID)
		{
			if (CanPlay(gamepadID))
			{
				GamepadState gamepadState = gamepadStates[gamepadID];
				gamepadState.rumbleIndex = 0;
				gamepadState.rumblePositionMs = 0L;
				gamepadState.playbackWatch.Restart();
				ProcessNextRumble(gamepadID);
			}
		}

		public static void Stop()
		{
			Stop(currentGamepadID);
		}

		public static void Stop(int gamepadID)
		{
			if (GetGamepad(gamepadID) != null)
			{
				GetGamepad(gamepadID).ResetHaptics();
			}
			if (gamepadStates.ContainsKey(gamepadID))
			{
				GamepadState gamepadState = gamepadStates[gamepadID];
				gamepadState.rumbleTimer.Enabled = false;
				gamepadState.rumbleIndex = -1;
				gamepadState.rumblePositionMs = 0L;
				gamepadState.playbackWatch.Stop();
			}
		}

		public static void StopAll()
		{
			foreach (KeyValuePair<int, GamepadState> gamepadState in gamepadStates)
			{
				Stop(gamepadState.Key);
			}
		}

		public static void Unload()
		{
			Unload(currentGamepadID);
		}

		public static void Unload(int gamepadID)
		{
			if (gamepadStates.ContainsKey(gamepadID))
			{
				GamepadState gamepadState = gamepadStates[gamepadID];
				gamepadState.loadedRumble.highFrequencyMotorSpeeds = null;
				gamepadState.loadedRumble.lowFrequencyMotorSpeeds = null;
				gamepadState.loadedRumble.durationsMs = null;
				gamepadState.rumbleLoaded = false;
				Stop(gamepadID);
			}
		}

		public static void SetMotorSpeedMultiplication(float lowFreq, float highFreq)
		{
			SetMotorSpeedMultiplication(lowFreq, highFreq, currentGamepadID);
		}

		public static void SetMotorSpeedMultiplication(float lowFreq, float highFreq, int gamepadID)
		{
			if (gamepadStates.ContainsKey(gamepadID))
			{
				GamepadState gamepadState = gamepadStates[gamepadID];
				gamepadState.lowFrequencyMotorSpeedMultiplication = lowFreq;
				gamepadState.highFrequencyMotorSpeedMultiplication = highFreq;
			}
		}

		private static bool IncreaseRumbleIndex(int gamepadID)
		{
			if (!gamepadStates.ContainsKey(gamepadID))
			{
				return false;
			}
			GamepadState gamepadState = gamepadStates[gamepadID];
			gamepadState.rumblePositionMs += gamepadState.loadedRumble.durationsMs[gamepadState.rumbleIndex];
			gamepadState.rumbleIndex++;
			if (gamepadState.rumbleIndex == gamepadState.loadedRumble.durationsMs.Length)
			{
				Stop(gamepadID);
				return false;
			}
			return true;
		}

		private static void ProcessNextRumble(int gamepadID)
		{
			if (!gamepadStates.ContainsKey(gamepadID))
			{
				return;
			}
			GamepadState gamepadState = gamepadStates[gamepadID];
			if (gamepadState.rumbleIndex == -1)
			{
				return;
			}
			if (gamepadState.rumbleIndex == gamepadState.loadedRumble.durationsMs.Length)
			{
				Stop(gamepadID);
				return;
			}
			long elapsedMilliseconds = gamepadState.playbackWatch.ElapsedMilliseconds;
			long num = 0L;
			while (true)
			{
				long num2 = gamepadState.loadedRumble.durationsMs[gamepadState.rumbleIndex];
				long num3 = elapsedMilliseconds - gamepadState.rumblePositionMs;
				num = num2 - num3;
				if (num > 0)
				{
					break;
				}
				if (!IncreaseRumbleIndex(gamepadID))
				{
					return;
				}
			}
			float lowFrequency = gamepadState.loadedRumble.lowFrequencyMotorSpeeds[gamepadState.rumbleIndex] * Mathf.Max(gamepadState.lowFrequencyMotorSpeedMultiplication, 0f);
			float highFrequency = gamepadState.loadedRumble.highFrequencyMotorSpeeds[gamepadState.rumbleIndex] * Mathf.Max(gamepadState.highFrequencyMotorSpeedMultiplication, 0f);
			Gamepad gamepad = GetGamepad(gamepadID);
			if (gamepad != null)
			{
				gamepad.SetMotorSpeeds(lowFrequency, highFrequency);
				gamepadState.rumblePositionMs += gamepadState.loadedRumble.durationsMs[gamepadState.rumbleIndex];
				gamepadState.rumbleIndex++;
				gamepadState.rumbleTimer.Interval = num;
				gamepadState.rumbleTimer.AutoReset = false;
				gamepadState.rumbleTimer.Enabled = true;
			}
		}
	}
}
