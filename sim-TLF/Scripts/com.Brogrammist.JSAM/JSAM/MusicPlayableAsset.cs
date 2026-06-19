using UnityEngine;
using UnityEngine.Playables;

namespace JSAM
{
	public class MusicPlayableAsset : PlayableAsset
	{
		public MusicFileObject audio;

		public float volume = 1f;

		public double startTime;

		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
		{
			ScriptPlayable<MusicPlayableBehaviour> scriptPlayable = ScriptPlayable<MusicPlayableBehaviour>.Create(graph);
			MusicPlayableBehaviour behaviour = scriptPlayable.GetBehaviour();
			behaviour.Audio = audio;
			behaviour.Volume = volume;
			behaviour.StartTime = startTime;
			return scriptPlayable;
		}
	}
}
