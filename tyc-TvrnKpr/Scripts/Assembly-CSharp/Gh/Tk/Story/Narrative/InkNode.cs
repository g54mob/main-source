using System.Collections.Generic;
using Gh.Tk.Story.Requirements;
using UnityEngine;
using UnityEngine.Serialization;
using XNode;

namespace Gh.Tk.Story.Narrative
{
	[NodeTint("#466969")]
	public class InkNode : BaseInkNode, ITargetActorListener, IStoryNodeHasComplexity, IRequirementProvider
	{
		public bool ignoreForI18nAndVo;

		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection requirements;

		[Header("Story Settings")]
		public StoryComplexity complexityValue;

		[Header("Target Settings")]
		[FormerlySerializedAs("actorConfig")]
		public BaseTargetFilterConfig targetFilterConfig;

		[Tooltip("if true then the story will start immediately regardless of it the actor has visited today")]
		public bool spawnStoryImmediately;

		public string devCommentaryId;

		public StoryComplexity StoryComplexity => default(StoryComplexity);

		public void OnTargetActorSpawned(ActiveStory story, Actor actor)
		{
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		private List<ActorData> GetTargetActorDatas(ActiveStory story)
		{
			return null;
		}

		private void UpdateOtherActorsStory(ActiveStory story, IEnumerable<ActorData> otherActorsData)
		{
		}

		private void UpdatePatronStory(ActiveStory story, List<PatronData> patronDatas)
		{
		}

		private void SchedulePatronAtReasonableTime(PatronData patronData)
		{
		}

		private void UpdateStaffStory(ActiveStory story, IEnumerable<StaffData> staffDatas)
		{
		}

		private void UpdatePropStory(ActiveStory story, PropFilterConfig propFilter)
		{
		}

		public override void OnUpdate(ActiveStory story)
		{
		}

		public IEnumerable<RequirementNode> GetRequirements()
		{
			return null;
		}
	}
}
