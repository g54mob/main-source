using System;
using System.Collections.Generic;
using Gh.Tk.Story.Logic;
using Gh.Tk.Story.Narrative;
using UnityEngine;
using UnityEngine.Serialization;
using XNode;

namespace Gh.Tk.Story.Requirements
{
	[NodeTint("#7f2d1e")]
	public abstract class RequirementNode : NodeBase
	{
		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection output;

		[Tooltip("Optional requirements are used to give visual checklist where some items do not hinder progression")]
		public bool isOptional;

		public string codexTooltip;

		[FormerlySerializedAs("textOverride")]
		[StoryNodeTranslateFieldContent("requirement label", "RequirementLabel")]
		public string labelOverride;

		[StoryNodeTranslateFieldContent("tooltip text", "Tooltip")]
		public string tooltipText;

		[Tooltip("if connected to challenge node, the requirement will trigger narrations after a certain delay (while the requirement is the first unmet requirement). Narrations are NOT guaranteed to trigger, they only trigger if the player doesn't complete the requirement in the given time.")]
		public NarratorItemConfig[] challengeNarrationConfig;

		public string uiGuideId;

		[Tooltip("If true, the requirement only has to be met once and will not be unchecked when the requirement is no longer met")]
		public bool onlyRequireOnce;

		[Tooltip("if true then this and requirements after this one will not show until the previous requirements are met")]
		public bool requirePreviousItemsCompleted;

		public string devCommentaryId;

		protected bool? _previousIsMetValue;

		private static readonly List<(RequirementNode requirement, ActiveStory story)> _activeRequirements;

		private static bool _activeRequirementsDirty;

		private ChallengeBaseNode _challengeNode;

		private string _wasMetStoryDataKey => null;

		protected bool IsDirty { get; set; }

		~RequirementNode()
		{
		}

		private void OnLevelReady(object sender, EventArgs eventArgs)
		{
		}

		public virtual string GetLabelKey(ActiveStory story)
		{
			return null;
		}

		public virtual string GetLabelPostfixKey(ActiveStory story)
		{
			return null;
		}

		public bool IsMet(ActiveStory story)
		{
			return false;
		}

		protected abstract bool IsMetInternal(ActiveStory story);

		public virtual int GetMaxPips(ActiveStory story)
		{
			return 0;
		}

		public virtual float GetFilledPips(ActiveStory story)
		{
			return 0f;
		}

		public virtual float GetSinglePipValue(ActiveStory story)
		{
			return 0f;
		}

		public virtual void Invalidate()
		{
		}

		public void OnParentNodeTriggered()
		{
		}

		public static void InvalidateActiveRequirementNodes()
		{
		}

		protected static void ExecuteOnActiveRequirements<T>(Action<T, ActiveStory> action) where T : RequirementNode
		{
		}

		protected ChallengeBaseNode GetTargetChallengeNode()
		{
			return null;
		}
	}
}
