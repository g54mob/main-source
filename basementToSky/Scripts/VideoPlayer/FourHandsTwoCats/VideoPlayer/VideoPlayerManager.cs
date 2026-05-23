using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace FourHandsTwoCats.VideoPlayer
{
	public class VideoPlayerManager : MonoBehaviour
	{
		[SerializeField]
		private UnityEngine.Video.VideoPlayer videoPlayer;

		[Space]
		[SerializeField]
		private Slider videoSlider;

		[SerializeField]
		private TextMeshProUGUI frameCountText;

		[Space]
		[SerializeField]
		private Button speedChangeButton;

		[SerializeField]
		private TextMeshProUGUI speedAmount;

		[SerializeField]
		private List<float> possiblePlaybackSpeed;

		[Space]
		[SerializeField]
		private bool playOnAwake;

		[Space]
		[SerializeField]
		private Image muteImage;

		[SerializeField]
		private Sprite muteSprite;

		[SerializeField]
		private Sprite unmuteSprite;

		private bool _isReady;

		private bool _sliderMode;

		private string _frameCountString = "Frame : {0}/{1}";

		private VideoPlayerInputs _inputs;

		private int _currentPlaybackSpeedIndex;

		private void Awake()
		{
			_inputs = new VideoPlayerInputs();
			_inputs.VideoPlayerControl.NextFrame.performed += delegate
			{
				Nextframe();
			};
			_inputs.VideoPlayerControl.PreviousFrame.performed += delegate
			{
				PreviousFrame();
			};
			_inputs.VideoPlayerControl.PlayPause.performed += delegate
			{
				if (videoPlayer.isPlaying)
				{
					PauseVideo();
				}
				else
				{
					PlayVideo();
				}
			};
			_inputs.Enable();
			_currentPlaybackSpeedIndex = 0;
			speedChangeButton.onClick.AddListener(delegate
			{
				HandleSpeedChange();
			});
			_isReady = playOnAwake;
			videoPlayer.Prepare();
			videoPlayer.frame = 0L;
		}

		private void HandleSpeedChange()
		{
			_currentPlaybackSpeedIndex = (_currentPlaybackSpeedIndex + 1) % possiblePlaybackSpeed.Count;
			speedAmount.text = "x" + possiblePlaybackSpeed[_currentPlaybackSpeedIndex];
			videoPlayer.playbackSpeed = possiblePlaybackSpeed[_currentPlaybackSpeedIndex];
			videoPlayer.Play();
		}

		private void OnDisable()
		{
			_inputs.Disable();
		}

		public void LoadVideo(string pickedFile)
		{
			_isReady = false;
			videoPlayer.Pause();
			videoPlayer.url = pickedFile;
			videoPlayer.prepareCompleted += EnableFonctionnalities;
			videoPlayer.Prepare();
		}

		private void EnableFonctionnalities(UnityEngine.Video.VideoPlayer source)
		{
			_isReady = true;
			videoSlider.value = 0f;
			videoSlider.maxValue = 1f;
			videoPlayer.frame = 0L;
		}

		private void LateUpdate()
		{
			if (_isReady)
			{
				if (!_sliderMode)
				{
					videoSlider.value = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
				}
				frameCountText.text = string.Format(_frameCountString, videoPlayer.frame, videoPlayer.frameCount);
			}
		}

		public void OnUsingSlider()
		{
			videoSlider.onValueChanged.AddListener(delegate(float value)
			{
				if (_isReady)
				{
					long frame = (long)(value * (float)videoPlayer.frameCount);
					videoPlayer.frame = frame;
				}
			});
			PauseVideo();
			_sliderMode = true;
		}

		public void OnStopUsingSlider()
		{
			videoSlider.onValueChanged.RemoveAllListeners();
			_sliderMode = false;
		}

		public void PlayVideo()
		{
			if (_isReady)
			{
				videoPlayer.Play();
			}
		}

		public void PauseVideo()
		{
			if (_isReady)
			{
				videoPlayer.Pause();
			}
		}

		public void Nextframe()
		{
			PauseVideo();
			if (_isReady)
			{
				videoPlayer.StepForward();
			}
		}

		public void PreviousFrame()
		{
			PauseVideo();
			if (_isReady)
			{
				long num = videoPlayer.frame - 1;
				if (num < 0)
				{
					num = 0L;
				}
				videoPlayer.frame = num;
			}
		}

		public void ToggleMute()
		{
			bool flag = !videoPlayer.GetDirectAudioMute(0);
			videoPlayer.SetDirectAudioMute(0, flag);
			muteImage.sprite = (flag ? muteSprite : unmuteSprite);
		}

		public float GetFrameRate()
		{
			return videoPlayer.frameRate;
		}

		public long GetCurrentFrame()
		{
			return videoPlayer.frame;
		}
	}
}
