using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	[DisallowMultipleComponent]
	[AddComponentMenu("AVPro Movie Capture/Utils/Capture GUI", 300)]
	public class CaptureGUI : MonoBehaviour
	{
		private enum Section
		{
			None = 0,
			VideoCodecs = 1,
			AudioCodecs = 2,
			AudioInputDevices = 3,
			ImageCodecs = 4
		}

		private AudioListener audioListener;

		[SerializeField]
		private CaptureBase _movieCapture;

		[SerializeField]
		private bool _showUI;

		[SerializeField]
		private bool _whenRecordingAutoHideUI;

		[SerializeField]
		private GUISkin _guiSkin;

		private static readonly string[] CommonFrameRateNames;

		private static readonly float[] CommonFrameRateValues;

		private Section _shownSection;

		private string[] _videoCodecNames;

		private string[] _audioCodecNames;

		private bool[] _videoCodecConfigurable;

		private bool[] _audioCodecConfigurable;

		private string[] _audioDeviceNames;

		private string[] _downScales;

		private string[] _outputType;

		private int _downScaleIndex;

		private GUIStyle _tintableBox;

		private int selectedTransparency;

		private Vector2 _videoPos;

		private Vector2 _audioPos;

		private Vector2 _audioCodecPos;

		private Vector2 _imageCodecPos;

		private long _lastFileSize;

		private float _lastEncodedMinutes;

		private float _lastEncodedSeconds;

		private uint _lastEncodedFrame;

		public CaptureBase MovieCapture
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool HideUiWhenRecording
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ShowUI
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void Start()
		{
		}

		private void CreateGUI()
		{
		}

		private void OnGUI()
		{
		}

		private void MyWindow(int id)
		{
		}

		private void GUI_RecordingStatus()
		{
		}

		private void DrawPauseResumeButtons()
		{
		}

		private void DrawGuiField(string a, string b)
		{
		}

		private void StartCapture()
		{
		}

		private void StopCapture()
		{
		}

		private void CancelCapture()
		{
		}

		private void ResumeCapture()
		{
		}

		private void PauseCapture()
		{
		}

		private void Update()
		{
		}
	}
}
