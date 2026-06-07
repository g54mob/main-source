using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Coffee.UIEffects.Timeline
{
	public abstract class UIEffectClip : PlayableAsset, ITimelineClipAsset
	{
		public TimelineClip timelineClip { get; set; }

		public ClipCaps clipCaps => default(ClipCaps);

		private void OnValidate()
		{
		}
	}
	public abstract class UIEffectClip<T> : UIEffectClip where T : UIEffectBehaviour, new()
	{
		[NotKeyable]
		[SerializeField]
		public T m_Data;

		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
		{
			return default(Playable);
		}
	}
}
