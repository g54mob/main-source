using System;
using Assets.Scripts.Environment.Water;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Levels;
using Jundroo.Common.Events;
using UnityEngine;

namespace Assets.Scripts
{
	public class GameWorld
	{
		private static GameWorld _instance = new GameWorld();

		private Vector3d _floatingOriginOffset;

		private float? _floatingOriginSeaLevel;

		private float? _seaLevel;

		public static GameWorld Instance => _instance;

		public Vector3 FloatingOriginOffset => _floatingOriginOffset.ToVector3();

		public Vector3d FloatingOriginOffsetD
		{
			get
			{
				return _floatingOriginOffset;
			}
			set
			{
				Vector3d floatingOriginOffset = _floatingOriginOffset;
				_floatingOriginOffset = value;
				if (floatingOriginOffset != value)
				{
					OnFloatingOriginChanged(floatingOriginOffset.ToVector3(), value.ToVector3());
				}
				if (WaterScript.Instance != null)
				{
					WaterScript.Instance.OnFloatingOriginUpdated(floatingOriginOffset.ToVector3(), value.ToVector3());
				}
			}
		}

		public float? FloatingOriginSeaLevel => _floatingOriginSeaLevel;

		public float MassScale => 0.01f;

		public float? SeaLevel
		{
			get
			{
				return _seaLevel;
			}
			set
			{
				float? seaLevel = _seaLevel;
				_seaLevel = value;
				if (seaLevel != value)
				{
					OnSeaLevelChanged(seaLevel, value);
				}
			}
		}

		public event EventHandler<FloatingOriginChangedEventArgs> FloatingOriginChanged
		{
			add
			{
				_floatingOriginChanged += WeakEventHandler.Create(value, delegate(EventHandler<FloatingOriginChangedEventArgs> x)
				{
					_floatingOriginChanged -= x;
				});
			}
			remove
			{
				_floatingOriginChanged -= WeakEventHandler.FindUnregisterHandler(this._floatingOriginChanged, value);
			}
		}

		public event EventHandler<SeaLevelChangedEventArgs> SeaLevelChanged
		{
			add
			{
				_seaLevelChanged += WeakEventHandler.Create(value, delegate(EventHandler<SeaLevelChangedEventArgs> x)
				{
					_seaLevelChanged -= x;
				});
			}
			remove
			{
				_seaLevelChanged -= WeakEventHandler.FindUnregisterHandler(this._seaLevelChanged, value);
			}
		}

		private event EventHandler<FloatingOriginChangedEventArgs> _floatingOriginChanged;

		private event EventHandler<SeaLevelChangedEventArgs> _seaLevelChanged;

		public void RepositionWorld(Vector3d globalPosition, float minimumDistanceThreshold, bool exactPosition = false)
		{
			Vector3d vector3d = globalPosition - _floatingOriginOffset;
			FloatingOriginScript.Instance?.RepositionWorldImmediately(vector3d.ToVector3(), minimumDistanceThreshold, exactPosition);
		}

		public void ShowStatusMessage(string message, float time = 5f)
		{
			FlightSceneScript.Instance.FlightUI.ShowMessage(message, time);
		}

		private void OnFloatingOriginChanged(Vector3 oldValue, Vector3 newValue)
		{
			if (this._floatingOriginChanged == null)
			{
				return;
			}
			_floatingOriginSeaLevel = SeaLevel - FloatingOriginOffset.y;
			Delegate[] invocationList = this._floatingOriginChanged.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				EventHandler<FloatingOriginChangedEventArgs> eventHandler = (EventHandler<FloatingOriginChangedEventArgs>)invocationList[i];
				try
				{
					eventHandler(this, new FloatingOriginChangedEventArgs(oldValue, newValue));
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		private void OnSeaLevelChanged(float? oldValue, float? newValue)
		{
			if (!newValue.HasValue)
			{
				LevelLoaderScript levelLoaderScript = UnityEngine.Object.FindFirstObjectByType<LevelLoaderScript>();
				if (levelLoaderScript != null && levelLoaderScript.Water != null)
				{
					levelLoaderScript.Water.gameObject.SetActive(value: false);
				}
			}
			else if (!oldValue.HasValue)
			{
				LevelLoaderScript levelLoaderScript2 = UnityEngine.Object.FindFirstObjectByType<LevelLoaderScript>();
				if (levelLoaderScript2 != null && levelLoaderScript2.Water != null)
				{
					levelLoaderScript2.Water.gameObject.SetActive(value: true);
				}
			}
			_floatingOriginSeaLevel = ((!newValue.HasValue) ? ((float?)null) : new float?(newValue.Value - FloatingOriginOffset.y));
			if (this._seaLevelChanged == null)
			{
				return;
			}
			Delegate[] invocationList = this._seaLevelChanged.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				EventHandler<SeaLevelChangedEventArgs> eventHandler = (EventHandler<SeaLevelChangedEventArgs>)invocationList[i];
				try
				{
					eventHandler(this, new SeaLevelChangedEventArgs(oldValue, newValue));
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}
	}
}
