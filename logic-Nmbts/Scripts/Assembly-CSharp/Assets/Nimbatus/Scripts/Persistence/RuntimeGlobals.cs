using System;
using System.Linq;
using Assets.Nimbatus.Scripts.Characters.Player;
using Assets.Nimbatus.Scripts.Controls;
using Assets.Nimbatus.Scripts.Persistence.Achievements;
using Assets.Nimbatus.Scripts.Workshop;
using Assets.Nimbatus.Scripts.World;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using Assets.Nimbatus.Scripts.WorldObjects.InteractiveObjects;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Persistence
{
	public static class RuntimeGlobals
	{
		private static bool _isGameLoading;

		private static bool _stopInteraction;

		public static Camera MainCamera { get; set; }

		public static GameSettings Settings { get; set; }

		public static AchievementManager Achievements { get; set; }

		public static EGameMode GameMode { get; set; }

		public static GameModeSettings GameModeSettings { get; set; }

		public static WorldController WorldController { get; set; }

		public static int MaxCreationsPerFrame { get; set; }

		public static NimbatusPlayer NimbatusPlayer { get; set; }

		public static ResourceContainer ResourceContainer { get; set; }

		public static CameraController Camera { get; set; }

		public static bool StopInteraction
		{
			get
			{
				if (!_stopInteraction)
				{
					return UICamera.inputHasFocus;
				}
				return true;
			}
			set
			{
				_stopInteraction = value;
			}
		}

		public static bool IsGameLoading
		{
			get
			{
				return _isGameLoading;
			}
			set
			{
				if (_isGameLoading != value)
				{
					if (!value && RuntimeGlobals.WakeUp != null)
					{
						RuntimeGlobals.WakeUp(null, null);
					}
					_isGameLoading = value;
				}
			}
		}

		public static bool BlockUInteraction { get; set; }

		public static bool IsGamePaused { get; set; }

		public static bool IsGameOver { get; set; }

		public static bool IsMovementBlocked { get; set; }

		public static bool FreezeGame { get; set; }

		public static bool DemoMode { get; set; }

		public static ERunningMode RunningMode { get; set; }

		public static float TimeScale { get; set; }

		public static bool FreezeEnemies { get; set; }

		public static bool CheckOverlap { get; set; }

		public static float DeployCostModifier { get; set; }

		public static bool HasWirelessResourceTransfer { get; set; }

		public static bool HasWeaponWorkshop { get; set; }

		public static event EventHandler WakeUp;

		static RuntimeGlobals()
		{
			CheckOverlap = true;
			Settings = new GameSettings();
			ResetToDefault();
		}

		public static void ResetToDefault()
		{
			Time.timeScale = 1f;
			TimeScale = 1f;
			FreezeGame = false;
			FreezeEnemies = false;
			StopInteraction = false;
			IsMovementBlocked = false;
			IsGamePaused = false;
			IsGameOver = false;
			RunningMode = ERunningMode.Normal;
			MaxCreationsPerFrame = 8;
			MainCamera = UnityEngine.Camera.main;
			InitDronePerkSettings();
		}

		public static void InitDronePerkSettings()
		{
			DeployCostModifier = 1f;
			if (GameModeSettings == null)
			{
				return;
			}
			HasWirelessResourceTransfer = false;
			HasWeaponWorkshop = true;
			if (!(SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance != null) || SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects == null)
			{
				return;
			}
			if (GameModeSettings.DeployCost)
			{
				DeployCostEffect deployCostEffect = SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects.OfType<DeployCostEffect>().FirstOrDefault();
				if (deployCostEffect != null)
				{
					DeployCostModifier = (float)(100 + deployCostEffect.DeployCostIncrease) / 100f;
				}
			}
			HasWirelessResourceTransfer = SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects.OfType<WirelessResourceTransfer>().Any();
			SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.EnableWireless = HasWirelessResourceTransfer;
			HasWeaponWorkshop = SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects.OfType<WeaponWorkshop>().Any() || GameMode == EGameMode.Creative || GameMode == EGameMode.Demo || GameMode == EGameMode.Competitive;
		}
	}
}
