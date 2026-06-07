using System;
using System.Runtime.Serialization;
using Gh.Tk.Story.Logic;
using LitJson;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.SpecialUseCase
{
	[InitializeOnGameStarted]
	public abstract class GroupTrackerChallengeBaseNode : ChallengeBaseNode
	{
		[Serializable]
		public class CompetitorInfo
		{
			[DropDownChoice(typeof(StoryHelper), "GetAllStoryFlags")]
			public string storyValueKey;

			public string codexTooltip;

			[IgnoreDataMember]
			[JsonIgnore]
			internal string _labelKey;
		}

		public CompetitorInfo[] competitors;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		protected abstract void OnGroupLeftTavern(ActiveStory story, GroupSatisfactionTrackerGameEvent.GroupLeftEventArgs e);

		protected override void OnInitializingUINotificationData(ActiveStory story, UINotificationData data)
		{
		}

		public override void OnUpdate(ActiveStory story)
		{
		}

		private bool UpdateCompetitorUI(ActiveStory story, CompetitorInfo competitor, UINotificationData data)
		{
			return false;
		}

		public override bool AreAllRequirementsMet(ActiveStory story)
		{
			return false;
		}
	}
}
