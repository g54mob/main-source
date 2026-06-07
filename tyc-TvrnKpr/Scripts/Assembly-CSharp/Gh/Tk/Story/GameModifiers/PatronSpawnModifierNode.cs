using System.Collections.Generic;
using Gh.Tk.Story.Config;
using UnityEngine;
using XNode;

namespace Gh.Tk.Story.GameModifiers
{
	[NodeWidth(300)]
	public class PatronSpawnModifierNode : ConnectedStoryNode
	{
		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection config;

		[StoryNodeTranslateFieldContent("PatronSpawnTitle", "Node")]
		public string title;

		[StoryNodeTranslateFieldContent("PatronSpawnDescription", "Node")]
		public string description;

		[Tooltip("If set to true, this will not be visible on the timeline")]
		public bool hideOnTimeline;

		[DropDownChoice(typeof(StoryHelper), "GetAllTimelineIcons")]
		public string timelineIcon;

		public int offsetInDays;

		[Tooltip("If set to -1, it will use current hour, otherwise wait for start hour")]
		public int startHour;

		public int durationInHours;

		public bool requireTimeClarityOnEvent;

		public bool forceOnNextDay;

		public override void OnTrigger(ActiveStory story)
		{
		}

		internal int GetRandomHourWithinRange()
		{
			return 0;
		}

		public IEnumerable<PatronGroupConfigNode> GetGroupConfigNodes()
		{
			return null;
		}

		public IEnumerable<PatronModifyPawnsConfigNode> GetModifyPawnsConfigNodes()
		{
			return null;
		}
	}
}
