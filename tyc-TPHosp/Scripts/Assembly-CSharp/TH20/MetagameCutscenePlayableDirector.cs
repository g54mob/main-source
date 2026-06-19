using UnityEngine;
using UnityEngine.Playables;

namespace TH20
{
	public class MetagameCutscenePlayableDirector : MonoBehaviour
	{
		public string DirectorId;

		[SerializeField]
		private PlayableDirector _director;

		private void Start()
		{
			foreach (PlayableBinding output in _director.playableAsset.outputs)
			{
				_ = output.streamName == "DirectorTrack";
			}
		}

		public void Initialise(MetagameMap metagameMap)
		{
		}

		public void Play()
		{
			_director.Play();
		}

		public void Stop()
		{
			_director.Stop();
		}

		public bool IsFinished()
		{
			return _director.state != PlayState.Playing;
		}
	}
}
