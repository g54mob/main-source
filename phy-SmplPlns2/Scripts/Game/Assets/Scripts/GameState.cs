using System;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Levels.Events;
using Jundroo.Common.Events;
using UnityEngine;

namespace Assets.Scripts
{
	public class GameState
	{
		private static GameState _instance = new GameState();

		public static GameState Instance => _instance;

		public string CurrentLevelName { get; set; }

		public string CurrentMapName { get; set; }

		public bool IsInDesigner { get; set; }

		public bool IsInLevel { get; set; }

		public bool IsPaused { get; set; }

		public event EventHandler<AircraftViewChangedEventArgs> AircraftViewChanged
		{
			add
			{
				_aircraftViewChanged += WeakEventHandler.Create(value, delegate(EventHandler<AircraftViewChangedEventArgs> x)
				{
					_aircraftViewChanged -= x;
				});
			}
			remove
			{
				_aircraftViewChanged -= WeakEventHandler.FindUnregisterHandler(this._aircraftViewChanged, value);
			}
		}

		public event EventHandler<EventArgs> DesignerEntered
		{
			add
			{
				_designerEntered += WeakEventHandler.Create(value, delegate(EventHandler<EventArgs> x)
				{
					_designerEntered -= x;
				});
			}
			remove
			{
				_designerEntered -= WeakEventHandler.FindUnregisterHandler(this._designerEntered, value);
			}
		}

		public event EventHandler<EventArgs> DesignerExited
		{
			add
			{
				_designerExited += WeakEventHandler.Create(value, delegate(EventHandler<EventArgs> x)
				{
					_designerExited -= x;
				});
			}
			remove
			{
				_designerExited -= WeakEventHandler.FindUnregisterHandler(this._designerExited, value);
			}
		}

		public event EventHandler<LevelChangedEventArgs> LevelEntered
		{
			add
			{
				_levelEntered += WeakEventHandler.Create(value, delegate(EventHandler<LevelChangedEventArgs> x)
				{
					_levelEntered -= x;
				});
			}
			remove
			{
				_levelEntered -= WeakEventHandler.FindUnregisterHandler(this._levelEntered, value);
			}
		}

		public event EventHandler<LevelChangedEventArgs> LevelExited
		{
			add
			{
				_levelExited += WeakEventHandler.Create(value, delegate(EventHandler<LevelChangedEventArgs> x)
				{
					_levelExited -= x;
				});
			}
			remove
			{
				_levelExited -= WeakEventHandler.FindUnregisterHandler(this._levelExited, value);
			}
		}

		public event EventHandler<EventArgs> LevelRestarted
		{
			add
			{
				_levelRestarted += WeakEventHandler.Create(value, delegate(EventHandler<EventArgs> x)
				{
					_levelRestarted -= x;
				});
			}
			remove
			{
				_levelRestarted -= WeakEventHandler.FindUnregisterHandler(this._levelRestarted, value);
			}
		}

		public event EventHandler<MapChangedEventArgs> MapEntered
		{
			add
			{
				_mapEntered += WeakEventHandler.Create(value, delegate(EventHandler<MapChangedEventArgs> x)
				{
					_mapEntered -= x;
				});
			}
			remove
			{
				_mapEntered -= WeakEventHandler.FindUnregisterHandler(this._mapEntered, value);
			}
		}

		public event EventHandler<MapChangedEventArgs> MapExited
		{
			add
			{
				_mapExited += WeakEventHandler.Create(value, delegate(EventHandler<MapChangedEventArgs> x)
				{
					_mapExited -= x;
				});
			}
			remove
			{
				_mapExited -= WeakEventHandler.FindUnregisterHandler(this._mapExited, value);
			}
		}

		public event EventHandler<MapLocationChangedEventArgs> MapLocationChanged
		{
			add
			{
				_mapLocationChanged += WeakEventHandler.Create(value, delegate(EventHandler<MapLocationChangedEventArgs> x)
				{
					_mapLocationChanged -= x;
				});
			}
			remove
			{
				_mapLocationChanged -= WeakEventHandler.FindUnregisterHandler(this._mapLocationChanged, value);
			}
		}

		public event EventHandler<MapLocationChangedEventArgs> MapLocationChanging
		{
			add
			{
				_mapLocationChanging += WeakEventHandler.Create(value, delegate(EventHandler<MapLocationChangedEventArgs> x)
				{
					_mapLocationChanging -= x;
				});
			}
			remove
			{
				_mapLocationChanging -= WeakEventHandler.FindUnregisterHandler(this._mapLocationChanging, value);
			}
		}

		public event EventHandler<PauseChangedEventArgs> PauseChanged
		{
			add
			{
				_pauseChanged += WeakEventHandler.Create(value, delegate(EventHandler<PauseChangedEventArgs> x)
				{
					_pauseChanged -= x;
				});
			}
			remove
			{
				_pauseChanged -= WeakEventHandler.FindUnregisterHandler(this._pauseChanged, value);
			}
		}

		private event EventHandler<AircraftViewChangedEventArgs> _aircraftViewChanged;

		private event EventHandler<EventArgs> _designerEntered;

		private event EventHandler<EventArgs> _designerExited;

		private event EventHandler<LevelChangedEventArgs> _levelEntered;

		private event EventHandler<LevelChangedEventArgs> _levelExited;

		private event EventHandler<EventArgs> _levelRestarted;

		private event EventHandler<MapChangedEventArgs> _mapEntered;

		private event EventHandler<MapChangedEventArgs> _mapExited;

		private event EventHandler<MapLocationChangedEventArgs> _mapLocationChanged;

		private event EventHandler<MapLocationChangedEventArgs> _mapLocationChanging;

		private event EventHandler<PauseChangedEventArgs> _pauseChanged;

		private GameState()
		{
		}

		public void RaiseAircraftViewChanged(string viewName)
		{
			if (this._aircraftViewChanged == null)
			{
				return;
			}
			Delegate[] invocationList = this._aircraftViewChanged.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				EventHandler<AircraftViewChangedEventArgs> eventHandler = (EventHandler<AircraftViewChangedEventArgs>)invocationList[i];
				try
				{
					eventHandler(this, new AircraftViewChangedEventArgs(viewName));
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		public void RaiseDesignerEntered()
		{
			if (this._designerEntered == null)
			{
				return;
			}
			Delegate[] invocationList = this._designerEntered.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				EventHandler<EventArgs> eventHandler = (EventHandler<EventArgs>)invocationList[i];
				try
				{
					eventHandler(this, new EventArgs());
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		public void RaiseDesignerExited()
		{
			if (this._designerExited == null)
			{
				return;
			}
			Delegate[] invocationList = this._designerExited.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				EventHandler<EventArgs> eventHandler = (EventHandler<EventArgs>)invocationList[i];
				try
				{
					eventHandler(this, new EventArgs());
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		public void RaiseLevelEntered(string levelName, string mapName)
		{
			if (this._levelEntered == null)
			{
				return;
			}
			Delegate[] invocationList = this._levelEntered.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				EventHandler<LevelChangedEventArgs> eventHandler = (EventHandler<LevelChangedEventArgs>)invocationList[i];
				try
				{
					eventHandler(this, new LevelChangedEventArgs(levelName, mapName));
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		public void RaiseLevelExited(string levelName, string mapName)
		{
			if (this._levelExited == null)
			{
				return;
			}
			Delegate[] invocationList = this._levelExited.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				EventHandler<LevelChangedEventArgs> eventHandler = (EventHandler<LevelChangedEventArgs>)invocationList[i];
				try
				{
					eventHandler(this, new LevelChangedEventArgs(levelName, mapName));
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		public void RaiseLevelRestarted()
		{
			if (this._levelRestarted == null)
			{
				return;
			}
			Delegate[] invocationList = this._levelRestarted.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				EventHandler<EventArgs> eventHandler = (EventHandler<EventArgs>)invocationList[i];
				try
				{
					eventHandler(this, new EventArgs());
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		public void RaiseMapEntered(string levelName, string mapName)
		{
			if (this._mapEntered == null)
			{
				return;
			}
			Delegate[] invocationList = this._mapEntered.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				EventHandler<MapChangedEventArgs> eventHandler = (EventHandler<MapChangedEventArgs>)invocationList[i];
				try
				{
					eventHandler(this, new MapChangedEventArgs(levelName, mapName));
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		public void RaiseMapExited(string levelName, string mapName)
		{
			if (this._mapExited == null)
			{
				return;
			}
			Delegate[] invocationList = this._mapExited.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				EventHandler<MapChangedEventArgs> eventHandler = (EventHandler<MapChangedEventArgs>)invocationList[i];
				try
				{
					eventHandler(this, new MapChangedEventArgs(levelName, mapName));
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		public void RaiseMapLocationChanged(string locationId, string locationDisplayName)
		{
			if (this._mapLocationChanged == null)
			{
				return;
			}
			Delegate[] invocationList = this._mapLocationChanged.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				EventHandler<MapLocationChangedEventArgs> eventHandler = (EventHandler<MapLocationChangedEventArgs>)invocationList[i];
				try
				{
					eventHandler(this, new MapLocationChangedEventArgs(locationId, locationDisplayName));
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		public void RaiseMapLocationChanging(string locationId, string locationDisplayName)
		{
			if (this._mapLocationChanging == null)
			{
				return;
			}
			Delegate[] invocationList = this._mapLocationChanging.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				EventHandler<MapLocationChangedEventArgs> eventHandler = (EventHandler<MapLocationChangedEventArgs>)invocationList[i];
				try
				{
					eventHandler(this, new MapLocationChangedEventArgs(locationId, locationDisplayName));
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		public void RaisePauseChanged(bool paused, bool userInitiated)
		{
			if (this._pauseChanged == null)
			{
				return;
			}
			Delegate[] invocationList = this._pauseChanged.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				EventHandler<PauseChangedEventArgs> eventHandler = (EventHandler<PauseChangedEventArgs>)invocationList[i];
				try
				{
					eventHandler(this, new PauseChangedEventArgs(paused, userInitiated));
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		public bool RequestPauseChange(bool paused, bool userInitiated)
		{
			return PauseManager.RequestPauseChange(paused, userInitiated);
		}
	}
}
