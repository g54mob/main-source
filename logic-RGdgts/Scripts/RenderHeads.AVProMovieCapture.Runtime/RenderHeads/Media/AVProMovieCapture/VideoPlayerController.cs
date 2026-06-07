using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace RenderHeads.Media.AVProMovieCapture
{
	public class VideoPlayerController : MonoBehaviour
	{
		public enum ScanFrequencyMode
		{
			SceneLoad = 0,
			Frame = 1
		}

		internal class VideoPlayerInstance
		{
			private VideoPlayer _videoPlayer;

			private bool _isCapturing;

			private bool _isControlling;

			private bool _isSeekPending;

			private double _videoTime;

			private float _postSeekTimer;

			internal VideoPlayerInstance(VideoPlayer videoPlayer)
			{
			}

			internal bool Is(VideoPlayer videoPlayer)
			{
				return false;
			}

			internal void StartCapture()
			{
			}

			internal bool IsSeekPending()
			{
				return false;
			}

			internal void TryTakeControl()
			{
			}

			private void VideoFrameReady(VideoPlayer source, long frameIdx)
			{
			}

			private void VideoSeekCompleted(VideoPlayer source)
			{
			}

			internal void ReleaseControl()
			{
			}

			internal bool Update(float deltaTime)
			{
				return false;
			}

			internal void StopCapture()
			{
			}
		}

		[SerializeField]
		private ScanFrequencyMode _scanFrequency;

		private List<VideoPlayerInstance> _instances;

		public ScanFrequencyMode ScanFrequency
		{
			get
			{
				return default(ScanFrequencyMode);
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnValidate()
		{
		}

		private void Update()
		{
		}

		internal void UpdateFrame()
		{
		}

		public bool CanContinue()
		{
			return false;
		}

		internal IEnumerator WaitforSeekCompletes()
		{
			return null;
		}

		internal void WaitforSeekCompletes2()
		{
		}

		internal void StartCapture()
		{
		}

		internal void StopCapture()
		{
		}

		public void ScanForVideoPlayers()
		{
		}

		private void OnDestroy()
		{
		}

		private void ResetSceneLoading()
		{
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
		}
	}
}
