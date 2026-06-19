using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TH20.Timeline
{
	[Serializable]
	public class EventClip : PlayableAsset, ITimelineClipAsset
	{
		private readonly EventPlayable _template = new EventPlayable();

		public string EventName;

		public string EventTag;

		public ClipCaps clipCaps => ClipCaps.None;

		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
		{
			ScriptPlayable<EventPlayable> scriptPlayable = ScriptPlayable<EventPlayable>.Create(graph, _template);
			EventPlayable behaviour = scriptPlayable.GetBehaviour();
			behaviour.EventName = EventName;
			behaviour.EventTag = EventTag;
			return scriptPlayable;
		}
	}
}
