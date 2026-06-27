using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

namespace Restory.Utils.VideoPlayers
{
	public class VideoPlayerNotificator : MonoBehaviour
	{
		[SerializeField]
		private VideoPlayer videoPlayer;

		public UnityEvent OnStart = new UnityEvent();

		public UnityEvent OnEnd = new UnityEvent();

		private void Awake()
		{
			videoPlayer.started += OnStarted;
			videoPlayer.loopPointReached += OnEndReached;
		}

		private void OnStarted(VideoPlayer source)
		{
			OnStart.Invoke();
		}

		private void OnEndReached(VideoPlayer source)
		{
			OnEnd.Invoke();
		}
	}
}
