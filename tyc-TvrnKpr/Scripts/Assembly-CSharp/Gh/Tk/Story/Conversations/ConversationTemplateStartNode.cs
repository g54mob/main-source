using System.Collections.Generic;
using Gh.Tk.Story.Requirements;
using Gh.Tk.Story.Structure;
using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Conversations
{
	public class ConversationTemplateStartNode : StartNode, IRequirementProvider
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllConversationThemes")]
		public string theme;

		public bool isRandomConversation;

		public GameLevel level;

		[Header("spawnChance")]
		[DropDownChoice(typeof(StoryHelper), "GetNamedDayCurves")]
		public string dayCurvePreset;

		[Range(0.1f, 2f)]
		[Tooltip("Random selection weighting (default=1). multiplied by dayCurve spawn chance.")]
		public float weighting;

		[Header("tier restriction")]
		public int minTier;

		public int maxTier;

		[Header("group size restriction")]
		public int minGroupSize;

		public int maxGroupSize;

		[Header("other requirements")]
		public bool actorsNeedToBeAtTheSameProp;

		[DropDownChoice(typeof(StoryHelper), "GetAllPropOptions")]
		public List<string> propRestriction;

		public bool InPrivateRoomsOnly;

		public bool SuppressImpatience;

		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection requirements;

		public float GetSpawnChanceForHour(int hour)
		{
			return 0f;
		}

		public bool CanBeUsed(IEnumerable<Actor> actors, bool useRandomStories)
		{
			return false;
		}

		public IEnumerable<RequirementNode> GetRequirements()
		{
			return null;
		}

		protected override bool ShouldCompleteOnTrigger()
		{
			return false;
		}
	}
}
