using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

namespace RenderHeads.Media.AVProMovieCapture
{
	[AddComponentMenu("AVPro Movie Capture/Utils/Timeline Controller", 300)]
	public class TimelineController : MonoBehaviour
	{
		public enum ScanFrequencyMode
		{
			SceneLoad = 0,
			Frame = 1
		}

		internal class TimelineInstance
		{
			private PlayableDirector _director;

			private DirectorUpdateMode _originalTimeUpdateMode;

			private bool _isControlling;

			private bool _isCapturing;

			internal TimelineInstance(PlayableDirector director)
			{
			}

			internal bool Is(PlayableDirector director)
			{
				return false;
			}

			internal void StartCapture()
			{
			}

			internal void StopCapture()
			{
			}
		}

		[SerializeField]
		private ScanFrequencyMode _scanFrequency;

		private List<TimelineInstance> _timelines;

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

		private void OnValidate()
		{
		}

		internal void UpdateFrame()
		{
		}

		internal void StartCapture()
		{
		}

		internal void StopCapture()
		{
		}

		public void ScanForPlayableDirectors()
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
