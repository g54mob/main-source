using System.Collections.Generic;
using Gh.Tk.UI;
using I18n;
using UnityEngine;

namespace Gh.Tk
{
	public class EventCamera3DUIView : MonoBehaviour
	{
		public Renderer eventCameraOutput;

		[SerializeField]
		private Button3DUIView _dismissCurrentEventCamera;

		[SerializeField]
		private Countdown3DUIView _countdownView;

		public GameObject[] eventCameraDisplayTextFlair;

		public GameObject eventCameraDisplayTextParent;

		public TextMeshProI18n eventCameraDisplayText;

		[SerializeField]
		public List<EventCameraSwitcherButton3DUIView> _switcherButtons;

		private Dictionary<string, EventCameraSwitcherButton3DUIView> _switcherButtonAssignments;

		private string _activeEventCameraId;

		private List<EventCamera> _eventCameras;

		private GameObject _eventCameraContainer;

		private List<Animator> _showHideAnimators;

		[SerializeField]
		private Collider _eventCameraDisplayCollider;

		public const float TARGET_FPS = 30f;

		private bool _isClosing;

		private static readonly int Play;

		private bool _isCameraUpdateEnabled;

		public bool IsOpening { get; private set; }

		public bool IsOpen { get; private set; }

		public void Awake()
		{
		}

		private void Update()
		{
		}

		public void AddEventCamera(EventCamera eventCamera)
		{
		}

		public void SetBestCamera()
		{
		}

		private void UpdateSwitcherButtons()
		{
		}

		public void SetActiveEventCamera(string id)
		{
		}

		public void RefreshEventCameraText(string id)
		{
		}

		public void OnEventCameraClicked()
		{
		}

		public void OnEventCameraDismissClicked()
		{
		}

		public void KillEventCamera(string id)
		{
		}

		public void KillAllEventCameras()
		{
		}

		public void ShowEventCameraView()
		{
		}

		private void HideEventCameraView()
		{
		}

		public void SetCameraUpdate(bool enabled)
		{
		}

		public bool IsCameraUpdateEnabled()
		{
			return false;
		}

		private void OnAnimEvent(object sender, AnimationEventArgs e)
		{
		}
	}
}
