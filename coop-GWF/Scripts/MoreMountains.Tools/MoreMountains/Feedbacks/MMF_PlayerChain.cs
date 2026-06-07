using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback allows you to chain any number of target MMF Players and play them in sequence, with optional delays before and after")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Feedbacks/MMF Player Chain")]
	public class MMF_PlayerChain : MMF_Feedback
	{
		[Serializable]
		public class PlayerChainItem
		{
			[Tooltip("the target MMF Player")]
			public MMF_Player TargetPlayer;

			[Tooltip("a delay in seconds to wait for before playing this MMF Player (x) and after (y)")]
			[MMVector(new string[] { "Before", "After" })]
			public Vector2 Delay;

			[Tooltip("whether this player is active in the list or not. Inactive players will be skipped when playing the chain of players")]
			public bool Inactive;

			[Tooltip("if this is true, the sequence will be blocked until this player has completed playing")]
			public bool WaitUntilComplete = true;
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Feedbacks", true, 79, false, false)]
		[Tooltip("the list of MMF Player that make up the chain. The chain's items will be played from index 0 to the last in the list")]
		public List<PlayerChainItem> Players;

		public override float FeedbackDuration
		{
			get
			{
				if (Players == null || Players.Count == 0)
				{
					return 0f;
				}
				float num = 0f;
				foreach (PlayerChainItem player in Players)
				{
					if (player != null && !(player.TargetPlayer == null) && !player.Inactive)
					{
						num += player.Delay.x;
						num += player.TargetPlayer.TotalDuration;
						num += player.Delay.y;
					}
				}
				return num;
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Players != null && Players.Count != 0 && Active && FeedbackTypeAuthorized)
			{
				Owner.StartCoroutine(PlayChain());
			}
		}

		protected virtual IEnumerator PlayChain()
		{
			IsPlaying = true;
			foreach (PlayerChainItem item in Players)
			{
				if (item != null && !(item.TargetPlayer == null) && !item.Inactive)
				{
					if (item.Delay.x > 0f)
					{
						yield return WaitFor(item.Delay.x);
					}
					if (item.WaitUntilComplete)
					{
						item.TargetPlayer.PlayFeedbacks();
						yield return WaitFor(item.TargetPlayer.TotalDuration);
					}
					else
					{
						item.TargetPlayer.PlayFeedbacks();
					}
					if (item.Delay.y > 0f)
					{
						yield return WaitFor(item.Delay.y);
					}
				}
			}
			while (FeedbacksStillPlaying())
			{
				yield return null;
			}
			IsPlaying = false;
		}

		protected virtual bool FeedbacksStillPlaying()
		{
			bool result = false;
			foreach (PlayerChainItem player in Players)
			{
				if (player.TargetPlayer.IsPlaying)
				{
					result = true;
				}
			}
			return result;
		}

		protected override void CustomSkipToTheEnd(Vector3 position, float feedbacksIntensity = 1f)
		{
			foreach (PlayerChainItem player in Players)
			{
				if (player != null && !(player.TargetPlayer == null) && !player.Inactive)
				{
					player.TargetPlayer.PlayFeedbacks();
					player.TargetPlayer.SkipToTheEnd();
				}
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			foreach (PlayerChainItem player in Players)
			{
				player.TargetPlayer.RestoreInitialValues();
			}
		}
	}
}
