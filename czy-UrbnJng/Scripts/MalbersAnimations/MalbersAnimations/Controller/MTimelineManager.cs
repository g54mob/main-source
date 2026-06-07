using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

namespace MalbersAnimations.Controller
{
	[AddComponentMenu("Malbers/Timeline/Timeline Manager")]
	public class MTimelineManager : MonoBehaviour
	{
		[RequiredField]
		public PlayableDirector Director;

		public UnityEvent OnTimelinePlay = new UnityEvent();

		public UnityEvent OnTimelineStop = new UnityEvent();

		private void Start()
		{
			if (Director.playOnAwake)
			{
				Director_played(Director);
			}
		}

		private void OnEnable()
		{
			Director.played += Director_played;
			Director.stopped += Director_stopped;
		}

		private void OnDisable()
		{
			Director.played -= Director_played;
			Director.stopped -= Director_stopped;
		}

		private void Director_played(PlayableDirector obj)
		{
			OnTimelinePlay.Invoke();
		}

		private void Director_stopped(PlayableDirector obj)
		{
			OnTimelineStop.Invoke();
		}
	}
}
