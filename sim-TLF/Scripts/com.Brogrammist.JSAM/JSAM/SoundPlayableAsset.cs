using UnityEngine;
using UnityEngine.Playables;

namespace JSAM
{
	public class SoundPlayableAsset : PlayableAsset
	{
		public SoundFileObject audio;

		public float volume = 1f;

		public double startTime;

		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
		{
			ScriptPlayable<SoundPlayableBehaviour> scriptPlayable = ScriptPlayable<SoundPlayableBehaviour>.Create(graph);
			SoundPlayableBehaviour behaviour = scriptPlayable.GetBehaviour();
			behaviour.Audio = audio;
			behaviour.Volume = volume;
			return scriptPlayable;
		}
	}
}
