using System.Collections;
using Assets.Nimbatus.Scripts.Leaderboards;
using Assets.Nimbatus.Scripts.Workshop;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class ChangeVoteControl : MonoBehaviour
	{
		public VoteButton UpvoteButton;

		public VoteButton DownvoteButton;

		private WorkshopItemResult _item;

		private bool _hasUpvoted;

		private bool _hasDownVoted;

		public IEnumerator Init(WorkshopItemResult item)
		{
			_item = item;
			_hasUpvoted = false;
			_hasDownVoted = false;
			UpvoteButton.Init(this);
			DownvoteButton.Init(this);
			SteamCallbackCoroutine<GetUserItemVoteResult_t> getVotecallback = new SteamCallbackCoroutine<GetUserItemVoteResult_t>();
			SteamAPICall_t userItemVote = SteamUGC.GetUserItemVote(_item.FileId);
			yield return StartCoroutine(getVotecallback.Start(userItemVote, 5f));
			if (getVotecallback.HasResult)
			{
				_hasDownVoted = getVotecallback.Result.m_bVotedDown;
				_hasUpvoted = getVotecallback.Result.m_bVotedUp;
			}
		}

		private IEnumerator DoVote(bool upvote)
		{
			SteamCallbackCoroutine<SetUserItemVoteResult_t> steamCallbackCoroutine = new SteamCallbackCoroutine<SetUserItemVoteResult_t>();
			SteamAPICall_t handle = SteamUGC.SetUserItemVote(_item.FileId, upvote);
			yield return StartCoroutine(steamCallbackCoroutine.Start(handle, 5f));
		}

		public void Vote(bool upvote)
		{
			if (upvote)
			{
				if (!_hasUpvoted)
				{
					_hasUpvoted = true;
					_hasDownVoted = false;
					StartCoroutine(DoVote(true));
				}
			}
			else if (!_hasDownVoted)
			{
				_hasDownVoted = true;
				_hasUpvoted = false;
				StartCoroutine(DoVote(false));
			}
		}

		public bool HasVoted(bool upvote)
		{
			if (upvote && _hasUpvoted)
			{
				return true;
			}
			if (!upvote && _hasDownVoted)
			{
				return true;
			}
			return false;
		}
	}
}
