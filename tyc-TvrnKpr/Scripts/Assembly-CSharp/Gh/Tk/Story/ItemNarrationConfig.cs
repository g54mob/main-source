using System;
using Gh.Tk.Story.Narrative;
using Gh.Tk.Story.Requirements;
using UnityEngine;

namespace Gh.Tk.Story
{
	[Serializable]
	public class ItemNarrationConfig
	{
		[Header("Type of Target")]
		public ClickedOnTargetRequirementNode.TargetModeType targetMode;

		[Header("Target Config")]
		[DropDownChoice(typeof(StoryHelper), "GetAllPropOptions")]
		public string targetPropType;

		[DropDownChoice(typeof(StoryHelper), "GetActorTypes")]
		public string targetActorType;

		[DropDownChoice(typeof(StoryHelper), "GetAllZones")]
		public string roomZone;

		[Tooltip("If true, the narration will be picked at random (from unused options), if false they will play in sequence.")]
		public bool pickNarrationAtRandom;

		public NarrationType narrationType;

		public AdvisorState advisorState;

		public string[] narrations;

		public bool DoesObjectMatch(ISelectable selectable)
		{
			return false;
		}
	}
}
