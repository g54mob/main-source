using System;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using XNode;

namespace Gh.Tk.Story
{
	public abstract class BaseInkNode : StoryNode, IStoryGiverHandler
	{
		public enum TimeoutStrategy
		{
			AutoPresentStory = 0,
			TryAgain = 1,
			ContinueWithTimeoutOutput = 2,
			FastAutoPresent = 3
		}

		[Serializable]
		public class VariableSimulationSetting
		{
			public string flagId;

			public int combinationGroup;
		}

		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection input;

		[Header("Ink Settings")]
		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false, dynamicPortList = true)]
		public NodeConnection[] outputs;

		[Tooltip("TryAgain: story giver will retry story, likely next day.\nAutoPresentStory: will play story as if player clicked.\nContinueWithTimeoutOutput: will skip story and continue using timeoutOutput")]
		public TimeoutStrategy timeoutStrategy;

		[Tooltip("If Timeout Strategy is set to ContinueWithTimeoutOutput this story path will be used.")]
		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection timeoutOutput;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection onActorPresent;

		[SerializeField]
		[Tooltip("Parse story to initialize, then customize combinationGroup to tell which variables need to be simulated in each combination.")]
		private List<VariableSimulationSetting> _storyVariableParsingGroups;

		public TextAsset inkFile;

		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection storyGiverPropsOverride;

		public bool showOnSleepingActors;

		private Ink.Runtime.Story _inkStory;

		protected const string EndPointName_Key = "endPointName";

		protected const string EndPointTagPrefix = "end:";

		protected const string TitleTagPrefix = "title:";

		[SerializeField]
		[HideInInspector]
		internal string _storyContentHash;

		protected const string STORY_SEED_KEY = "storySeed";

		protected List<string> _endPoints;

		protected List<VoiceOverPart> _voExportData;

		private const int maxWordsWarning = 90;

		private string _lastChoice;

		private const string LocalizationCommentPrefix = "<lc>";

		private const string LocalizationCommentPostFix = "</lc>";

		private List<string> _cachedStoryGiverPropIds;

		protected Ink.Runtime.Story InkStory => null;

		protected string NodeNotificationId_Key => null;

		public string StoryDecisions_Key => null;

		protected string ActorsWaitingForSpawn_Key => null;

		protected string DelayPatronStoryUntilNextDay_Key => null;

		protected string IsStoryPresented_Key => null;

		protected string IsStoryLockedIn_Key => null;

		protected void TriggerOnActorPresent(ActiveStory story, Actor actor)
		{
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		private void ApplyStoryFlagsToInkStory(ActiveStory story, Ink.Runtime.Story inkStory)
		{
		}

		private void RetrieveStoryFlagsFromInkStory(ActiveStory story, Ink.Runtime.Story inkStory)
		{
		}

		protected string GetEndPoint(Ink.Runtime.Story story)
		{
			return null;
		}

		private void LogStoryChoiceForVOFiles(string choice)
		{
		}

		private void LogStoryTextForVOFiles(string text, Ink.Runtime.Story story, string language, bool logNextChoices = true)
		{
		}

		private void CheckIfIFScenesExist(string content)
		{
		}

		private void CheckInstructionTags(ActiveStory story, Ink.Runtime.Story inkStory)
		{
		}

		private void ValidateInstructions(Ink.Runtime.Story story)
		{
		}

		protected List<UIDialogPageData> GetPages(ActiveStory story, Ink.Runtime.Story inkStory, FateDecision previousFateChoice)
		{
			return null;
		}

		protected List<NotificationDecision> GetDecisions(ActiveStory story, Ink.Runtime.Story inkStory)
		{
			return null;
		}

		protected string GetTitleKey(ActiveStory story, Ink.Runtime.Story inkStory)
		{
			return null;
		}

		public void PresentStory(ActiveStory story)
		{
		}

		private void PresentStoryInternal(ActiveStory story, bool autoOpened = false)
		{
		}

		private void EnsureCorrectSceneTag(ActiveStory story, UIDialogPageData firstPage)
		{
		}

		protected void SkipStory(Ink.Runtime.Story inkStory, List<int> decisionsMade)
		{
		}

		protected void MakeChoice(ActiveStory story, Ink.Runtime.Story inkStory, int decision)
		{
		}

		public override void OnDecision(ActiveStory story, int decision)
		{
		}

		protected bool IsStoryGiverApplied(ActiveStory story, GameObjectX target)
		{
			return false;
		}

		protected void UpdateStoryGiver(ActiveStory story, IEnumerable<GameObjectX> targets)
		{
		}

		private StoryGiverConfig CreateStoryGiverConfig(ActiveStory story, GameObjectX target)
		{
			return null;
		}

		protected void UpdateStoryGiver(ActiveStory story, GameObjectX target)
		{
		}

		private List<string> GetInputStoryGiverPropIds()
		{
			return null;
		}

		public void ResetStoryGiver(ActiveStory story)
		{
		}

		public void OnStoryGiverTimedOut(ActiveStory story)
		{
		}

		private void CompleteInkNode(ActiveStory story, bool didTimeout = false)
		{
		}

		public override void Complete(ActiveStory story)
		{
		}
	}
}
