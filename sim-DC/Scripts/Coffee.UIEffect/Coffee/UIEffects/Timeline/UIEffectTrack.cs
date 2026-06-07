using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Coffee.UIEffects.Timeline
{
	[TrackColor(0.92f, 0.54f, 0.17f)]
	[TrackBindingType(typeof(UIEffect), TrackBindingFlags.AllowCreateComponent)]
	public abstract class UIEffectTrack<T> : TrackAsset where T : PlayableBehaviour, new()
	{
		protected abstract string fieldName { get; }

		public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
		{
			return default(Playable);
		}

		public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
		{
		}
	}
}
