using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Flight.MapView;
using Assets.Scripts.Flight.MapView.Automation;
using ModApi.Flight;
using ModApi.Flight.Sim;
using ModApi.Settings;
using ModApi.Settings.Core.Events;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio
{
	public class PlanetStudioTimeManager : ITimeManager, IDisposable
	{
		public class TimeMultiplierMode : ITimeMultiplierMode
		{
			public double MinimumAltitude { get; set; }

			public string Name { get; set; }

			public double TimeMultiplier { get; set; }

			public bool WarpMode { get; private set; }

			public TimeMultiplierMode(double t, double a, bool warp = true, string name = null)
			{
				TimeMultiplier = t;
				MinimumAltitude = a;
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

		private const int NormalSpeedIndex = 1;

		private const int PauseSpeedIndex = 0;

		private bool _disposed;

		private TimeMultiplierMode _fastForward;

		private int _modeIndex;

		private List<ITimeMultiplierMode> _modes = new List<ITimeMultiplierMode>();

		private ITimeMultiplierMode _realTime;

		private int _unPauseIndex = 1;

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

		public IGameTime GameTime
		{
			get
			{
				MapViewManagerScript mapViewManagerScript = PlanetarySystemDesignerScript.Instance?.MapViewManager;
				if (mapViewManagerScript != null)
				{
					return mapViewManagerScript.Ioc.Resolve<IGameTime>();
				}
				return null;
			}
		}

		public int ModeIndex => _modeIndex;

		public IReadOnlyCollection<ITimeMultiplierMode> Modes => _modes;

		public bool Paused => _modeIndex == 0;

		public ITimeMultiplierMode RealTime => _realTime;

		public bool Reversed { get; set; }

		public ITimeMultiplierMode SlowMotion => null;

		public event TimeMultiplierModeChangedDelegate TimeMultiplierModeChanged;

		public event TimeMultiplierModeChangedDelegate TimeMultiplierModeChanging;

		public PlanetStudioTimeManager()
		{
			_modes.Add(new TimeMultiplierMode(0.0, 0.0, warp: false, "Paused"));
			_realTime = new TimeMultiplierMode(1.0, 0.0, warp: false);
			_modes.Add(_realTime);
			_fastForward = new TimeMultiplierMode((float)Game.Instance.Settings.Game.Flight.FastForwardSpeed, 0.0, warp: false);
			_modes.Add(_fastForward);
			FirstWarpMode = _modes.Count;
			AddWarpModes(_fastForward.TimeMultiplier);
			SetModeImmediate(0);
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
			_ = _modes[modeIndex];
			failReason = null;
			return true;
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
				Game.Instance.Settings.Game.Flight.FastForwardSpeed.Changed -= OnFastForwardSpeedChanged;
			}
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
				if (_modeIndex == 1)
				{
					_unPauseIndex = _modeIndex;
				}
				else
				{
					_unPauseIndex = 1;
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
			SetModeImmediate(modeIndex);
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
			SetMode(1);
		}

		public void SetSlowMotionMode()
		{
			SetMode(1);
		}

		public void Update()
		{
			if (GameTime != null)
			{
				DeltaTime = (double)Time.deltaTime * CurrentMode.TimeMultiplier * (double)((!Reversed) ? 1 : (-1));
				GameTime.Time += DeltaTime;
			}
		}

		private void AddWarpModes(double minMultiplier)
		{
			List<TimeMultiplierMode> list = new List<TimeMultiplierMode>();
			list.Add(new TimeMultiplierMode(10.0, 10000.0));
			list.Add(new TimeMultiplierMode(25.0, 10000.0));
			list.Add(new TimeMultiplierMode(100.0, 10000.0));
			list.Add(new TimeMultiplierMode(500.0, 10000.0));
			list.Add(new TimeMultiplierMode(2500.0, 25000.0));
			list.Add(new TimeMultiplierMode(10000.0, 50000.0));
			list.Add(new TimeMultiplierMode(50000.0, 100000.0));
			list.Add(new TimeMultiplierMode(250000.0, 250000.0));
			list.Add(new TimeMultiplierMode(1000000.0, 1000000.0));
			list.Add(new TimeMultiplierMode(5000000.0, 25000000.0));
			list.Add(new TimeMultiplierMode(10000000.0, 25000000.0));
			list.Add(new TimeMultiplierMode(100000000.0, 25000000.0));
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

		private ITimeMultiplierMode GetMaxWarp(IOrbitPoint atmosEntryPoint)
		{
			ITimeMultiplierMode timeMultiplierMode = null;
			if (atmosEntryPoint != null)
			{
				IOrbit orbit = Game.Instance.FlightScene.CraftNode.Orbit;
				double timeToPoint = atmosEntryPoint.Time - orbit.Time;
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

		private void OnWarpEntered()
		{
		}

		private void OnWarpExited()
		{
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
