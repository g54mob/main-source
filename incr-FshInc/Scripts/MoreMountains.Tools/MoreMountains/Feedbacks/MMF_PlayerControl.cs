using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback allows you to control one or more target MMF Players")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Feedbacks/MMF Player Control")]
	public class MMF_PlayerControl : MMF_Feedback
	{
		public enum Modes
		{
			PlayFeedbacks = 0,
			StopFeedbacks = 1,
			PauseFeedbacks = 2,
			ResumeFeedbacks = 3,
			Initialization = 4,
			PlayFeedbacksInReverse = 5,
			PlayFeedbacksOnlyIfReversed = 6,
			PlayFeedbacksOnlyIfNormalDirection = 7,
			ResetFeedbacks = 8,
			ChangeDirection = 9,
			SetDirectionTopToBottom = 10,
			SetDirectionBottomToTop = 11,
			RestoreInitialValues = 12,
			SkipToTheEnd = 13,
			RefreshCache = 14
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("MMF Player", true, 79, false, false)]
		[Tooltip("a specific MMFeedbacks / MMF_Player to play")]
		public List<MMF_Player> TargetPlayers;

		[Tooltip("if this is true, this feedback will be considered as Playing while any of the target players are still Playing")]
		public bool WaitForTargetPlayersToFinish = true;

		public Modes Mode;

		public override bool HasChannel => false;

		public override float FeedbackDuration
		{
			get
			{
				if (TargetPlayers == null)
				{
					return 0f;
				}
				if (!WaitForTargetPlayersToFinish)
				{
					return 0f;
				}
				if (Mode == Modes.PlayFeedbacks && TargetPlayers.Count > 0)
				{
					float num = 0f;
					{
						foreach (MMF_Player targetPlayer in TargetPlayers)
						{
							if (targetPlayer != null && num < targetPlayer.TotalDuration)
							{
								num = targetPlayer.TotalDuration;
							}
						}
						return num;
					}
				}
				return 0f;
			}
		}

		public override bool IsPlaying
		{
			get
			{
				if (WaitForTargetPlayersToFinish)
				{
					foreach (MMF_Player targetPlayer in TargetPlayers)
					{
						if (targetPlayer.IsPlaying)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (TargetPlayers == null)
			{
				TargetPlayers = new List<MMF_Player>();
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (TargetPlayers.Count == 0 || !Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			switch (Mode)
			{
			case Modes.PlayFeedbacks:
			{
				foreach (MMF_Player targetPlayer in TargetPlayers)
				{
					targetPlayer.PlayFeedbacks(position, feedbacksIntensity);
				}
				break;
			}
			case Modes.StopFeedbacks:
			{
				foreach (MMF_Player targetPlayer2 in TargetPlayers)
				{
					targetPlayer2.StopFeedbacks();
				}
				break;
			}
			case Modes.PauseFeedbacks:
			{
				foreach (MMF_Player targetPlayer3 in TargetPlayers)
				{
					targetPlayer3.PauseFeedbacks();
				}
				break;
			}
			case Modes.ResumeFeedbacks:
			{
				foreach (MMF_Player targetPlayer4 in TargetPlayers)
				{
					targetPlayer4.ResumeFeedbacks();
				}
				break;
			}
			case Modes.Initialization:
			{
				foreach (MMF_Player targetPlayer5 in TargetPlayers)
				{
					targetPlayer5.Initialization();
				}
				break;
			}
			case Modes.PlayFeedbacksInReverse:
			{
				foreach (MMF_Player targetPlayer6 in TargetPlayers)
				{
					targetPlayer6.PlayFeedbacksInReverse(position, feedbacksIntensity, forceChangeDirection: true);
				}
				break;
			}
			case Modes.PlayFeedbacksOnlyIfReversed:
			{
				foreach (MMF_Player targetPlayer7 in TargetPlayers)
				{
					targetPlayer7.PlayFeedbacksOnlyIfReversed(position, feedbacksIntensity);
				}
				break;
			}
			case Modes.PlayFeedbacksOnlyIfNormalDirection:
			{
				foreach (MMF_Player targetPlayer8 in TargetPlayers)
				{
					targetPlayer8.PlayFeedbacksOnlyIfNormalDirection(position, feedbacksIntensity);
				}
				break;
			}
			case Modes.ResetFeedbacks:
			{
				foreach (MMF_Player targetPlayer9 in TargetPlayers)
				{
					targetPlayer9.ResetFeedbacks();
				}
				break;
			}
			case Modes.ChangeDirection:
			{
				foreach (MMF_Player targetPlayer10 in TargetPlayers)
				{
					targetPlayer10.ChangeDirection();
				}
				break;
			}
			case Modes.SetDirectionTopToBottom:
			{
				foreach (MMF_Player targetPlayer11 in TargetPlayers)
				{
					targetPlayer11.SetDirectionTopToBottom();
				}
				break;
			}
			case Modes.SetDirectionBottomToTop:
			{
				foreach (MMF_Player targetPlayer12 in TargetPlayers)
				{
					targetPlayer12.SetDirectionBottomToTop();
				}
				break;
			}
			case Modes.RestoreInitialValues:
			{
				foreach (MMF_Player targetPlayer13 in TargetPlayers)
				{
					targetPlayer13.RestoreInitialValues();
				}
				break;
			}
			case Modes.SkipToTheEnd:
			{
				foreach (MMF_Player targetPlayer14 in TargetPlayers)
				{
					targetPlayer14.SkipToTheEnd();
				}
				break;
			}
			case Modes.RefreshCache:
			{
				foreach (MMF_Player targetPlayer15 in TargetPlayers)
				{
					targetPlayer15.RefreshCache();
				}
				break;
			}
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}
}
