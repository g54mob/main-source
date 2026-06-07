using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Packages.DevConsole;
using Assets.Scripts.Career.Contracts;
using Assets.Scripts.Flight.MapView.Automation;
using Assets.Scripts.Flight.Sim;
using ModApi.Craft;
using ModApi.Flight;
using ModApi.Flight.Sim;
using ModApi.Planet;
using ModApi.Settings;
using ModApi.Settings.Core.Events;
using UnityEngine;

namespace Assets.Scripts.Flight
{
	public class TimeManager : ITimeManager, IDisposable
	{
		public class TimeMultiplierMode : ITimeMultiplierMode
		{
			public string Name { get; set; }

			public double TimeMultiplier { get; set; }

			public bool WarpMode { get; private set; }

			public TimeMultiplierMode(double t, bool warp = true, string name = null)
			{
				TimeMultiplier = t;
				WarpMode = warp;
				if (!string.IsNullOrEmpty(name))
				{
					Name = name;
				}
				else
				{
					Name = t + "x";
				}
			}
		}

		private const int NormalSpeedIndex = 2;

		private const int PauseSpeedIndex = 0;

		private const int SlowMoIndex = 1;

		private double _atmosphereAltitudeAboveCenter;

		private IOrbitPoint _craftPointWarpDisableDuringWarp;

		private bool _disposed;

		private TimeMultiplierMode _fastForward;

		private float _fixedElapsedTime;

		private FlightSceneScript _flightScene;

		private int _modeIndex;

		private List<ITimeMultiplierMode> _modes = new List<ITimeMultiplierMode>();

		private ITimeMultiplierMode _realTime;

		private bool _reverseWarp;

		private TimeMultiplierMode _slowMotion;

		private int _unPauseIndex = 2;

		public bool CanDecreaseTimeMultiplier
		{
			get
			{
				if (_modeIndex > 0)
				{
					return true;
				}
				return false;
			}
		}

		public ITimeMultiplierMode CurrentMode { get; private set; }

		public double DeltaTime { get; private set; }

		public int FirstWarpMode { get; private set; }

		public int ModeIndex => _modeIndex;

		public IReadOnlyCollection<ITimeMultiplierMode> Modes => _modes;

		public bool Paused => _modeIndex == 0;

		public ITimeMultiplierMode RealTime => _realTime;

		public ITimeMultiplierMode SlowMotion => _modes[1];

		public event TimeMultiplierModeChangedDelegate TimeMultiplierModeChanged;

		public event TimeMultiplierModeChangedDelegate TimeMultiplierModeChanging;

		public TimeManager(FlightSceneScript flightScene)
		{
			Game.Instance.Settings.Game.Flight.SlowMotionSpeed.Changed += OnSlowMotionSpeedChanged;
			Game.Instance.Settings.Game.Flight.FastForwardSpeed.Changed += OnFastForwardSpeedChanged;
			_flightScene = flightScene;
			_modes.Add(new TimeMultiplierMode(0.0, warp: false, "Paused"));
			_slowMotion = new TimeMultiplierMode(1f / (float)Game.Instance.Settings.Game.Flight.SlowMotionSpeed, warp: false, "Slow-Mo");
			_modes.Add(_slowMotion);
			_realTime = new TimeMultiplierMode(1.0, warp: false);
			_modes.Add(_realTime);
			_fastForward = new TimeMultiplierMode((float)Game.Instance.Settings.Game.Flight.FastForwardSpeed, warp: false);
			_modes.Add(_fastForward);
			FirstWarpMode = _modes.Count;
			AddWarpModes(_fastForward.TimeMultiplier);
			SetModeImmediate(0);
			DevConsoleApi.RegisterCommand("McFly", delegate
			{
				_reverseWarp = !_reverseWarp;
			});
		}

		public bool CanIncreaseTimeMultiplier(out string failRason)
		{
			if (_modeIndex < _modes.Count - 1)
			{
				return CanSetTimeMultiplierMode(_modeIndex + 1, out failRason);
			}
			failRason = "At max warp";
			return false;
		}

		public bool CanSetTimeMultiplierMode(int modeIndex, out string failReason)
		{
			ITimeMultiplierMode timeMultiplierMode = _modes[modeIndex];
			ICraftNode craftNode = _flightScene.CraftNode;
			if (timeMultiplierMode.WarpMode)
			{
				if (craftNode.CraftScript.FlightData.CurrentEngineThrust > 0f && !craftNode.CraftScript.FlightData.SupportsWarpBurn)
				{
					failReason = "Time Warp cannot be enabled when non-ion engines are active.";
					return false;
				}
				if (!craftNode.CanWarp && !Game.MaxWarpUnlocked)
				{
					double altitude = craftNode.Altitude;
					if (craftNode.Parent.PlanetData.AtmosphereData.HasPhysicsAtmosphere && altitude <= craftNode.Parent.PlanetData.AtmosphereData.Height)
					{
						failReason = "Time Warp can only be enabled when the craft is grounded or outside the atmosphere.";
						return false;
					}
				}
				if (timeMultiplierMode.TimeMultiplier > GetMaxWarp(GetCraftPlanetMinHeightPoint()).TimeMultiplier)
				{
					failReason = "Time Warp limited: craft is on a course to impact the planet.";
					return false;
				}
				if (timeMultiplierMode.TimeMultiplier > GetMaxWarp(GetCraftAtmosphereEntryPoint()).TimeMultiplier)
				{
					failReason = "Time Warp limited: craft is on a course to enter the atmosphere";
					return false;
				}
				ContractContext contractContext = Game.Instance.GameState.Career?.Contracts;
				if (contractContext != null)
				{
					failReason = contractContext.CanWarp();
					if (failReason != null)
					{
						return false;
					}
				}
			}
			failReason = null;
			return true;
		}

		public void CheckCurrentTimeMultiplier(ICraftNode craftNode)
		{
			if (CurrentMode.WarpMode && !OrbitAboveAtmosphere(craftNode) && !craftNode.CanWarp)
			{
				double num = 0.0;
				if (craftNode.Parent.PlanetData.AtmosphereData.HasPhysicsAtmosphere)
				{
					num = craftNode.Parent.PlanetData.AtmosphereData.Height;
				}
				if (Math.Max(craftNode.Altitude, 0.0) < num && !Game.MaxWarpUnlocked)
				{
					SetFastForwardMode();
				}
			}
		}

		public void DecreaseTimeMultiplier()
		{
			if (CanDecreaseTimeMultiplier)
			{
				SetMode(_modeIndex - 1);
			}
		}

		public void Dispose()
		{
			if (!_disposed)
			{
				_disposed = true;
				Game.Instance.Settings.Game.Flight.SlowMotionSpeed.Changed -= OnSlowMotionSpeedChanged;
				Game.Instance.Settings.Game.Flight.FastForwardSpeed.Changed -= OnFastForwardSpeedChanged;
				DevConsoleApi.UnregisterCommand("McFly");
			}
		}

		public void FixedUpdate(float fixedDeltaTime)
		{
			_fixedElapsedTime += fixedDeltaTime;
		}

		public void FlightEnd()
		{
			this.TimeMultiplierModeChanged = null;
			Time.fixedDeltaTime = PhysicsQualitySettings.GetFixedDeltaTime(Game.Instance.QualitySettings.Physics.PhysicsUpdateFrequency.Value);
		}

		public void IncreaseTimeMultiplier()
		{
			if (CanIncreaseTimeMultiplier(out var _))
			{
				SetMode(_modeIndex + 1);
			}
		}

		public void RequestPauseChange(bool paused, bool userInitiated)
		{
			if (paused)
			{
				if (_modeIndex == 2 || _modeIndex == 1)
				{
					_unPauseIndex = _modeIndex;
				}
				else
				{
					_unPauseIndex = 2;
				}
				SetMode(0);
			}
			else
			{
				SetMode(_unPauseIndex);
			}
		}

		public void SetFastForwardMode()
		{
			SetMode(3);
		}

		public void SetMode(int modeIndex, bool forceChange = false)
		{
			if (modeIndex < 0 || modeIndex >= _modes.Count)
			{
				throw new ArgumentOutOfRangeException("Mode index out of range: " + modeIndex);
			}
			_flightScene.StartCoroutine(SetModeEndOfFrame(modeIndex, forceChange));
		}

		public void SetMode(ITimeMultiplierMode mode, bool forceChange = false)
		{
			int num = _modes.IndexOf(mode);
			if (num > 0)
			{
				SetMode(num, forceChange);
				return;
			}
			throw new ArgumentException("Unknown multiplier mode provided");
		}

		public void SetNormalSpeedMode()
		{
			SetMode(2);
		}

		public void SetSlowMotionMode()
		{
			SetMode(1);
		}

		public void Update()
		{
			if (CurrentMode.WarpMode)
			{
				DeltaTime = (double)Time.deltaTime * CurrentMode.TimeMultiplier * (double)((!_reverseWarp) ? 1 : (-1));
			}
			else
			{
				DeltaTime = _fixedElapsedTime;
			}
			if (CurrentMode.WarpMode)
			{
				PreventWarpingThroughPhysics();
			}
			_fixedElapsedTime = 0f;
		}

		private static IOrbitPoint GetCraftAtmosphereEntryPoint()
		{
			IOrbitPoint result = null;
			ICraftNode craftNode = Game.Instance.FlightScene.CraftNode;
			if (!craftNode.InContactWithPlanet)
			{
				IOrbitPoint pointAtmosphereEntry = craftNode.GetPointAtmosphereEntry();
				if (pointAtmosphereEntry != null && pointAtmosphereEntry.Time > craftNode.Orbit.Time)
				{
					result = new OrbitPoint(pointAtmosphereEntry);
				}
			}
			return result;
		}

		private static IOrbitPoint GetCraftPlanetMinHeightPoint()
		{
			IOrbitPoint result = null;
			ICraftNode craftNode = Game.Instance.FlightScene.CraftNode;
			if (!craftNode.InContactWithPlanet && craftNode.Periapsis.Position.magnitude <= craftNode.Parent.PlanetData.Radius)
			{
				IOrbitPoint pointAgl = craftNode.GetPointAgl(craftNode.Parent.PlanetData.Radius * 0.2);
				if (pointAgl != null && pointAgl.Time > craftNode.Orbit.Time)
				{
					result = new OrbitPoint(pointAgl);
				}
			}
			return result;
		}

		private static bool OrbitAboveAtmosphere(ICraftNode craftNode)
		{
			IPlanetData planetData = craftNode.Parent.PlanetData;
			double num = Math.Max(20000.0, 1.1 * planetData.MaxEstimatedTerrainElevation);
			if (planetData.AtmosphereData.HasPhysicsAtmosphere)
			{
				num = Math.Max(num, planetData.AtmosphereData.Height);
			}
			return craftNode.Orbit.PeriapsisDistance > planetData.Radius + num;
		}

		private void AddWarpModes(double minMultiplier)
		{
			List<TimeMultiplierMode> list = new List<TimeMultiplierMode>();
			list.Add(new TimeMultiplierMode(10.0));
			list.Add(new TimeMultiplierMode(25.0));
			list.Add(new TimeMultiplierMode(100.0));
			list.Add(new TimeMultiplierMode(500.0));
			list.Add(new TimeMultiplierMode(2500.0));
			list.Add(new TimeMultiplierMode(10000.0));
			list.Add(new TimeMultiplierMode(50000.0));
			list.Add(new TimeMultiplierMode(250000.0));
			list.Add(new TimeMultiplierMode(1000000.0));
			list.Add(new TimeMultiplierMode(5000000.0));
			list.Add(new TimeMultiplierMode(25000000.0));
			list.Add(new TimeMultiplierMode(100000000.0));
			for (int num = list.Count - 1; num >= 0; num--)
			{
				TimeMultiplierMode timeMultiplierMode = list[num];
				if (timeMultiplierMode.TimeMultiplier <= minMultiplier)
				{
					list.Remove(timeMultiplierMode);
				}
			}
			_modes.AddRange(list);
		}

		private ITimeMultiplierMode GetMaxWarp(IOrbitPoint stopWarpPoint)
		{
			ITimeMultiplierMode timeMultiplierMode = null;
			if (stopWarpPoint != null)
			{
				IOrbit orbit = Game.Instance.FlightScene.CraftNode.Orbit;
				double timeToPoint = stopWarpPoint.Time - orbit.Time;
				timeMultiplierMode = NodeNavigator.GetMaxMultiplierMode(this, timeToPoint, 0.0, 1.0);
			}
			if (timeMultiplierMode == null)
			{
				return _modes[_modes.Count - 1];
			}
			return timeMultiplierMode;
		}

		private void OnFastForwardSpeedChanged(object sender, SettingChangedEventArgs<float> e)
		{
			_fastForward.TimeMultiplier = e.Setting.Value;
			if (CurrentMode == _fastForward)
			{
				SetMode(_fastForward, forceChange: true);
			}
			ReAddWarpModes();
		}

		private void OnSlowMotionSpeedChanged(object sender, SettingChangedEventArgs<float> e)
		{
			_slowMotion.TimeMultiplier = 1f / e.Setting.Value;
			if (CurrentMode == _slowMotion)
			{
				SetMode(_slowMotion, forceChange: true);
			}
		}

		private void OnWarpEntered()
		{
			IOrbitPoint craftAtmosphereEntryPoint = GetCraftAtmosphereEntryPoint();
			IOrbitPoint craftPlanetMinHeightPoint = GetCraftPlanetMinHeightPoint();
			if (craftAtmosphereEntryPoint != null && craftPlanetMinHeightPoint != null)
			{
				_craftPointWarpDisableDuringWarp = ((craftAtmosphereEntryPoint.Time < craftPlanetMinHeightPoint.Time) ? craftAtmosphereEntryPoint : craftPlanetMinHeightPoint);
			}
			else if (craftAtmosphereEntryPoint != null)
			{
				_craftPointWarpDisableDuringWarp = craftAtmosphereEntryPoint;
			}
			else
			{
				_craftPointWarpDisableDuringWarp = craftPlanetMinHeightPoint;
			}
			Game.Instance.FlightScene.ViewManager.GameView.RecenterReferenceFrame();
		}

		private void OnWarpExited()
		{
			_craftPointWarpDisableDuringWarp = null;
		}

		private void PreventWarpingThroughPhysics()
		{
			if (_craftPointWarpDisableDuringWarp != null && GetMaxWarp(_craftPointWarpDisableDuringWarp).TimeMultiplier < CurrentMode.TimeMultiplier)
			{
				ITimeMultiplierMode timeMultiplierMode = _modes[_modeIndex - 1];
				if (timeMultiplierMode == _fastForward)
				{
					SetMode(_realTime);
				}
				else
				{
					SetMode(timeMultiplierMode);
				}
			}
		}

		private void ReAddWarpModes()
		{
			_modes.RemoveRange(FirstWarpMode, _modes.Count - FirstWarpMode);
			AddWarpModes(_fastForward.TimeMultiplier);
		}

		private IEnumerator SetModeEndOfFrame(int modeIndex, bool forceChange = false)
		{
			yield return new WaitForEndOfFrame();
			SetModeImmediate(modeIndex, forceChange);
		}

		private void SetModeImmediate(int modeIndex, bool forceChange = false)
		{
			if (!forceChange && _modeIndex == modeIndex && CurrentMode != null)
			{
				return;
			}
			ITimeMultiplierMode currentMode = CurrentMode;
			_modeIndex = modeIndex;
			CurrentMode = _modes[modeIndex];
			float fixedDeltaTime = PhysicsQualitySettings.GetFixedDeltaTime(Game.Instance.QualitySettings.Physics.PhysicsUpdateFrequency.Value);
			if (CurrentMode.WarpMode)
			{
				Time.timeScale = 1f;
				Time.fixedDeltaTime = fixedDeltaTime;
			}
			else
			{
				Time.timeScale = (float)CurrentMode.TimeMultiplier;
				if (Time.timeScale < 1f && Time.timeScale > 0f)
				{
					Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
				}
				else
				{
					Time.fixedDeltaTime = fixedDeltaTime;
				}
			}
			if (currentMode == null)
			{
				return;
			}
			bool enteredWarp = false;
			bool exitedWarp = false;
			if (currentMode.WarpMode != CurrentMode.WarpMode)
			{
				if (CurrentMode.WarpMode)
				{
					enteredWarp = true;
					OnWarpEntered();
				}
				else
				{
					exitedWarp = true;
					OnWarpExited();
				}
			}
			TimeMultiplierModeChangedEvent e = new TimeMultiplierModeChangedEvent(CurrentMode, currentMode, enteredWarp, exitedWarp);
			this.TimeMultiplierModeChanging?.Invoke(e);
			this.TimeMultiplierModeChanged?.Invoke(e);
		}
	}
}
