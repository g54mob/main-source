using LitJson;
using UnityEngine;

namespace Gh.Tk
{
	public abstract class CameraEvent : IPersistable, ILateRestoreState
	{
		protected EventCameraSettings _eventCameraSettings;

		[PersistenceObjectReference]
		protected GameObjectX _eventCameraGameObjectX;

		private Vector3 _lastKnownLocation;

		public int Id { get; protected set; }

		public float Duration { get; set; }

		public float EndsIn { get; set; }

		public bool UseUnscaledTime { get; set; }

		[JsonIgnore]
		public bool IsDestroyed { get; private set; }

		public EventCameraSettings EventCameraSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[JsonIgnore]
		public GameObjectX EventCameraGameObjectX => null;

		public CameraEvent()
		{
		}

		public CameraEvent(float duration, bool useUnscaledTime)
		{
		}

		protected void OnDestroy()
		{
		}

		public virtual void OnUpdate()
		{
		}

		public void Destroy()
		{
		}

		protected void SetupEventCamera(GameObjectX gox, EventCameraSettings eventCameraSettings)
		{
		}

		public void SetGoxTarget(GameObjectX gox)
		{
		}

		public void EventCameraGoxDestroyed()
		{
		}

		public virtual void EventCameraCallback(EventCamera eventCamera)
		{
		}

		public void ShowEventCameraCountdown(bool show)
		{
		}

		public void SetCustomEventCameraCountdown(float percentage)
		{
		}

		private void UpdateEventCameraCountdown()
		{
		}

		public virtual void LateRestoreState(IDataStore data)
		{
		}
	}
}
