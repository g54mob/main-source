using System;
using FullInspector;
using JetBrains.Annotations;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class GameTime : MustCallDestroy, IGameEventsBase
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			[InspectorTooltip("How much faster 'game' time advances compared to real-world time. e.g. 60 will mean one game minute passes for every real-world second.")]
			public float RealTimeToGameTimeMultiplier = 30f;

			public int DefaultTimeScaleIndex = 1;

			public float[] TimeScales = new float[7] { 0.5f, 1f, 2f, 4f, 8f, 32f, 64f };

			public int ReleaseMaxTimeScaleIndex = 2;
		}

		public static Action<int> OnIncreaseTimeScale;

		public static Action<int> OnDecreaseTimeScale;

		public Action<bool> OnPauseChange;

		public Action<int> OnTimeScaleChange;

		private readonly Config _config;

		[DontSave]
		private Level _level;

		[DontSave]
		private HUD _hud;

		[DontSave]
		private double[] _timeScaleDurations;

		public double CurrentGameTime;

		[DontSave]
		private int _timeScaleIndex;

		private bool _isPausedByUser;

		[DontSave]
		private bool _isSuperPaused;

		[DontSave]
		private bool _isPausedByMenu;

		private float _time;

		private float _unscaledTime;

		private float _deltaTime;

		private float _unscaledDeltaTime;

		public double[] TimeScaleDurations => _timeScaleDurations;

		public int ReleaseMaxTimeScaleIndex => _config.ReleaseMaxTimeScaleIndex;

		private float[] TimeScales => _config.TimeScales;

		public int TimeScaleIndex
		{
			get
			{
				return _timeScaleIndex;
			}
			set
			{
				value = Mathf.Clamp(value, 0, TimeScales.Length - 1);
				if (value != _timeScaleIndex)
				{
					int timeScaleIndex = _timeScaleIndex;
					_timeScaleIndex = value;
					UpdateTimeScale();
					if (timeScaleIndex < _timeScaleIndex)
					{
						OnIncreaseTimeScale.InvokeSafe(_timeScaleIndex);
					}
					if (timeScaleIndex > _timeScaleIndex)
					{
						OnDecreaseTimeScale.InvokeSafe(_timeScaleIndex);
					}
					OnTimeScaleChange.InvokeSafe(_timeScaleIndex);
				}
			}
		}

		public float CurrentTimeScaleIfRunning => TimeScales[_timeScaleIndex];

		public bool IsPausedByUser
		{
			get
			{
				return _isPausedByUser;
			}
			set
			{
				_isPausedByUser = value;
				UpdateTimeScale();
				OnPauseChange.InvokeSafe(_isPausedByUser);
			}
		}

		public bool IsSuperPaused
		{
			get
			{
				return _isSuperPaused;
			}
			set
			{
				_isSuperPaused = value;
				UpdateTimeScale();
			}
		}

		public bool IsPausedByMenu
		{
			get
			{
				return _isPausedByMenu;
			}
			set
			{
				_isPausedByMenu = value;
				UpdateTimeScale();
			}
		}

		public double PausedDuration { get; private set; }

		public double SuperPausedDuration { get; private set; }

		public static float time { get; private set; }

		public static float unscaledTime { get; private set; }

		public static float deltaTime { get; private set; }

		public static float unscaledDeltaTime { get; private set; }

		public GameTime(Config config, Level level)
		{
			_config = config;
			_hud = level.HUD;
			_level = level;
			GameEventsRegistry.RegisterGlobalEvent(this);
			Init();
		}

		private void Init()
		{
			HUDEvents hUDEvents = _hud.HUDEvents;
			hUDEvents.OnMenuOpen = (Action<MenuBase>)Delegate.Combine(hUDEvents.OnMenuOpen, new Action<MenuBase>(OnMenuOpenOrClose));
			HUDEvents hUDEvents2 = _hud.HUDEvents;
			hUDEvents2.OnMenuClose = (Action<MenuBase>)Delegate.Combine(hUDEvents2.OnMenuClose, new Action<MenuBase>(OnMenuOpenOrClose));
			_timeScaleIndex = _config.DefaultTimeScaleIndex;
			_timeScaleDurations = new double[TimeScales.Length];
			UpdateTimeScale();
			UpdateStaticMembers();
			ConsoleCommandsDatabase.RegisterSimpleCommand("SpeedIncrease", "Increases speed", delegate
			{
				IncreaseTimeScale(useDevSpeeds: true);
			});
			ConsoleCommandsDatabase.RegisterSimpleCommand("SpeedDecrease", "Increases speed", delegate
			{
				DecreaseTimeScale(useDevSpeeds: true);
			});
			ConsoleCommandsDatabase.RegisterCommand("SetSpeedMax", "Sets the speed to max", "SetSpeedMax", DebugSetSpeedMax);
			ConsoleCommandsDatabase.RegisterCommand("SetSpeedMin", "Sets the speed to min", "SetSpeedMax", DebugSetSpeedMin);
			ConsoleCommandsDatabase.RegisterCommand("SetSpeedDefault", "Sets the speed to default (1x)", "SetSpeedMax", DebugSetSpeedDefault);
		}

		private void OnMenuOpenOrClose(MenuBase menuBase)
		{
			UpdateTimeScale();
		}

		public void RestoreFromSave(Level level)
		{
			_level = level;
			_hud = _level.HUD;
			Init();
		}

		private ConsoleCommandResult DebugSetSpeedMax(string[] args)
		{
			if (CanIncreaseTimeScale(useDevSpeeds: true))
			{
				_timeScaleIndex = TimeScales.Length - 1;
				UpdateTimeScale();
				OnIncreaseTimeScale.InvokeSafe(_timeScaleIndex);
				OnTimeScaleChange.InvokeSafe(_timeScaleIndex);
			}
			return ConsoleCommandResult.Succeeded("Speed set to " + TimeScales[_timeScaleIndex]);
		}

		private ConsoleCommandResult DebugSetSpeedMin(string[] args)
		{
			if (CanDecreaseTimeScale())
			{
				_timeScaleIndex = 0;
				UpdateTimeScale();
				OnDecreaseTimeScale.InvokeSafe(_timeScaleIndex);
				OnTimeScaleChange.InvokeSafe(_timeScaleIndex);
			}
			return ConsoleCommandResult.Succeeded("Speed set to " + TimeScales[_timeScaleIndex]);
		}

		private ConsoleCommandResult DebugSetSpeedDefault(string[] args)
		{
			_timeScaleIndex = _config.DefaultTimeScaleIndex;
			UpdateTimeScale();
			return ConsoleCommandResult.Succeeded("Speed set to " + TimeScales[_timeScaleIndex]);
		}

		public void Update()
		{
			if (_level.InputManager.GetButtonDown(51))
			{
				IsPausedByUser = !IsPausedByUser;
			}
			bool useDevSpeeds = false;
			if (_level.InputManager.GetButtonDown(54))
			{
				DecreaseTimeScale(useDevSpeeds);
			}
			if (_level.InputManager.GetButtonDown(53))
			{
				IncreaseTimeScale(useDevSpeeds);
			}
			_deltaTime = Time.deltaTime;
			_unscaledDeltaTime = Time.unscaledDeltaTime;
			_time += _deltaTime;
			_unscaledTime += _unscaledDeltaTime;
			UpdateStaticMembers();
			CurrentGameTime += Time.deltaTime * _config.RealTimeToGameTimeMultiplier;
			if (_isSuperPaused)
			{
				SuperPausedDuration += Time.unscaledDeltaTime;
			}
			else if (!_isPausedByUser && !_isPausedByMenu && !_hud.IsPauseTimeMenuOpen)
			{
				_timeScaleDurations[_timeScaleIndex] += Time.unscaledDeltaTime;
			}
			if (_isPausedByUser || _isPausedByMenu)
			{
				PausedDuration += Time.unscaledDeltaTime;
			}
		}

		private void UpdateStaticMembers()
		{
			time = _time;
			unscaledTime = _unscaledTime;
			deltaTime = _deltaTime;
			unscaledDeltaTime = _unscaledDeltaTime;
		}

		public void TogglePause()
		{
			IsPausedByUser = !IsPausedByUser;
		}

		private bool CanIncreaseTimeScale(bool useDevSpeeds)
		{
			return _timeScaleIndex < (useDevSpeeds ? (TimeScales.Length - 1) : _config.ReleaseMaxTimeScaleIndex);
		}

		public bool CanDecreaseTimeScale()
		{
			return _timeScaleIndex > 0;
		}

		public void IncreaseTimeScale(bool useDevSpeeds)
		{
			if (IsPausedByUser)
			{
				IsPausedByUser = false;
			}
			else if (CanIncreaseTimeScale(useDevSpeeds))
			{
				_timeScaleIndex++;
				UpdateTimeScale();
				OnIncreaseTimeScale.InvokeSafe(_timeScaleIndex);
				OnTimeScaleChange.InvokeSafe(_timeScaleIndex);
			}
		}

		public void DecreaseTimeScale(bool useDevSpeeds)
		{
			_isPausedByUser = false;
			if (CanDecreaseTimeScale())
			{
				_timeScaleIndex--;
				UpdateTimeScale();
				OnDecreaseTimeScale.InvokeSafe(_timeScaleIndex);
				OnTimeScaleChange.InvokeSafe(_timeScaleIndex);
			}
			else
			{
				IsPausedByUser = true;
			}
		}

		private void UpdateTimeScale()
		{
			if (_isSuperPaused || _isPausedByMenu || _isPausedByUser || _hud.IsPauseTimeMenuOpen)
			{
				Time.timeScale = 0f;
			}
			else
			{
				Time.timeScale = CurrentTimeScaleIfRunning;
			}
		}

		public override void Destroy()
		{
			HUDEvents hUDEvents = _hud.HUDEvents;
			hUDEvents.OnMenuOpen = (Action<MenuBase>)Delegate.Remove(hUDEvents.OnMenuOpen, new Action<MenuBase>(OnMenuOpenOrClose));
			HUDEvents hUDEvents2 = _hud.HUDEvents;
			hUDEvents2.OnMenuClose = (Action<MenuBase>)Delegate.Remove(hUDEvents2.OnMenuClose, new Action<MenuBase>(OnMenuOpenOrClose));
			ConsoleCommandsDatabase.UnRegisterCommand("UseDevelopmentTimeScales");
			base.Destroy();
		}

		public void VerifyEvents()
		{
			OnIncreaseTimeScale.VerifyIsNull();
			OnDecreaseTimeScale.VerifyIsNull();
			OnPauseChange.VerifyIsNull();
			OnTimeScaleChange.VerifyIsNull();
		}
	}
}
