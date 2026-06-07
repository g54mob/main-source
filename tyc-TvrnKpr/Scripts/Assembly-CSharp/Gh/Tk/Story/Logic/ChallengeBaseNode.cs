using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Gh.Tk.Story.Requirements;
using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Logic
{
	[NodeTint("#80463c")]
	[NodeWidth(300)]
	public abstract class ChallengeBaseNode : ConnectedStoryNode, IRequirementProvider
	{
		[StoryNodeTranslateFieldContent("Challenge Title", "Node")]
		public string title;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		[Tooltip("the path that the story will continue if this challenge expires when not all requirements are met. This will ONLY trigger if the challenge can expire (ie. expriesInDayF is set).")]
		public NodeConnection challengeFailed;

		[Header("Challenges with Expiry")]
		public float expiresInDaysF;

		[Tooltip("If true and this node defines an expiry time, it will only complete once the time is expired AND all requirements are met")]
		public bool waitForTimeExpiryBeforeCompleting;

		[Tooltip("If true, the challenge will fail as soon as one of the requirements are no longer met")]
		public bool failEarlyIfRequirementsAreNotMet;

		[Header("Misc.")]
		[Tooltip("if true, the game will not show an error if the output of this challenge is not connected")]
		public bool allowUnconnectedOutput;

		[Tooltip("If true, the (optional) task label on optional tasks will not be added.")]
		public bool suppressOptionalTaskLabels;

		private const string ExpiresAt_Key = "challengeExpiresAt";

		public bool showRequirementPipValuesInLabel;

		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection requirements;

		[Tooltip("If specified, the advisor will narrate the progress of this challenge.")]
		public ChallengeAdvisorNarration[] narrations;

		[Tooltip("If set, this challenge/guide will only visually group together with other challenges of the same key")]
		public string groupKeyOverride;

		private static string wasDismissedKey;

		private string NodeNotificationId_Key => null;

		private string RequirementsDone_Key => null;

		private string RequirementsTotal_Key => null;

		public bool CanExpire => false;

		public event EventHandler ProgressChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected bool IsTimeExpired(ActiveStory story)
		{
			return false;
		}

		public override void OnUpdate(ActiveStory story)
		{
		}

		protected bool ShouldComplete(ActiveStory story)
		{
			return false;
		}

		public float GetExpiresWhenTime(ActiveStory story)
		{
			return 0f;
		}

		protected UINotificationData GetNotificationData(ActiveStory story)
		{
			return null;
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		protected string GetNotificationDataId(ActiveStory story)
		{
			return null;
		}

		protected void ClearNotificationDataId(ActiveStory story)
		{
		}

		public virtual bool AreAllRequirementsMet(ActiveStory story)
		{
			return false;
		}

		private bool TryApplyProgressToNotification(ActiveStory story)
		{
			return false;
		}

		public override void Complete(ActiveStory story)
		{
		}

		public void ManuallyComplete(ActiveStory story)
		{
		}

		private void Complete(ActiveStory story, bool failed)
		{
		}

		protected virtual string GetDefaultGroupKey()
		{
			return null;
		}

		protected void ShowNotification(ActiveStory story, bool autoOpen)
		{
		}

		public override void OnDecision(ActiveStory story, int decision)
		{
		}

		protected void OnDismiss(ActiveStory story, UINotificationData data)
		{
		}

		public bool WasDismissedBefore(ActiveStory story)
		{
			return false;
		}

		protected virtual void OnInitializingUINotificationData(ActiveStory story, UINotificationData data)
		{
		}

		protected virtual int GetNotificationGroupPriority()
		{
			return 0;
		}

		protected string GetNotificationImage()
		{
			return null;
		}

		public IEnumerable<RequirementNode> GetRequirements()
		{
			return null;
		}

		private bool TryUpdateProgressData(ActiveStory story, UINotificationData notificationData)
		{
			return false;
		}

		protected void OnNotificationDataUpdated(ActiveStory story, UINotificationData data)
		{
		}

		private void PlayNarrationProgress(ActiveStory story, int percentageProgress)
		{
		}

		private void CheckRequirementNarrations(ActiveStory story)
		{
		}

		private void UpdateUIGuides(ActiveStory story)
		{
		}
	}
}
