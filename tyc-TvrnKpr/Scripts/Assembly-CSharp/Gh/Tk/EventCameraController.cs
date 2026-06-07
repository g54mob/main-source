using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[PersistenceIgnoreParent]
	[PersistenceOptIn]
	public class EventCameraController : SingletonMonoBehaviour<EventCameraController>, IPersistable
	{
		[SerializeField]
		private GameObject _eventCameraPrefab;

		[SerializeField]
		private GameObject _advisorEventCameraPrefab;

		[SerializeField]
		private GameObject _blockedAdvisorEventCameraPrefab;

		private List<EventCamera> _activeEventCameras;

		private EventCamera3DUIView _eventCamera3DUIView;

		private Transform _displayParent;

		public override void Awake()
		{
		}

		public void ShowEventCameraView()
		{
		}

		public void HideEventCameraView()
		{
		}

		public bool IsEventCameraViewVisible()
		{
			return false;
		}

		public EventCamera CreateEventCamera(GameObjectX gox, EventCameraSettings settings)
		{
			return null;
		}

		private EventCamera CreateEventCameraInternal(Transform camTarget, EventCameraSettings settings)
		{
			return null;
		}

		private EventCamera InstantiateEventCamera(EventCameraSettings settings)
		{
			return null;
		}

		public EventCamera CreateAdvisorCamera(string adviceKey, AdvisorState state = AdvisorState.Neutral, int parentEventId = 0)
		{
			return null;
		}

		public void SetActiveEventCamera(string id)
		{
		}

		public void KillEventCamera(string id)
		{
		}

		public void KillAllEventCameras()
		{
		}

		public void UpdateEventCameraText(string id, string textKey)
		{
		}

		public void EventCameraClicked(string clickedEventCameraId)
		{
		}

		public EventCamera GetEventCamera(string id)
		{
			return null;
		}
	}
}
