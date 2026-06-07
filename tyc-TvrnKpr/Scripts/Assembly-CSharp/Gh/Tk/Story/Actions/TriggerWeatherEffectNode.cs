using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Actions
{
	public class TriggerWeatherEffectNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection parent;

		[Header("Weather Settings")]
		[DropDownChoice(typeof(StoryHelper), "GetAllWeatherEffects")]
		public string weatherEffectType;

		public bool overrideIntensity;

		[Range(0f, 1f)]
		public float intensity;

		public bool overrideDuration;

		public float durationInHours;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
