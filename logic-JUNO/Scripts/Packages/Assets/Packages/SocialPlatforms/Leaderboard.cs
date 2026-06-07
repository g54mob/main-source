using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Assets.Packages.SocialPlatforms
{
	public class Leaderboard : ILeaderboard
	{
		private Action<bool> _scoresLoadedCallback;

		public virtual string id { get; set; }

		public virtual bool loading { get; set; }

		public virtual IScore localUserScore { get; set; }

		public virtual uint maxRange
		{
			get
			{
				if (scores != null)
				{
					return (uint)scores.Length;
				}
				return 0u;
			}
		}

		public virtual UnityEngine.SocialPlatforms.Range range { get; set; }

		public virtual IScore[] scores { get; set; }

		public virtual TimeScope timeScope { get; set; }

		public string title { get; set; }

		public UserScope userScope { get; set; }

		public virtual void LoadScores(Action<bool> callback)
		{
			loading = true;
			_scoresLoadedCallback = callback;
			Social.LoadScores(id, LoadScoresCallback);
		}

		public virtual void SetUserFilter(string[] userIDs)
		{
		}

		protected virtual void LoadScoresCallback(IScore[] scores)
		{
			this.scores = scores;
			if (_scoresLoadedCallback != null)
			{
				_scoresLoadedCallback(scores != null);
			}
			if (scores != null)
			{
				string text = Social.localUser.id;
				for (int i = 0; i < scores.Length; i++)
				{
					if (scores[i].userID == text)
					{
						localUserScore = scores[i];
						break;
					}
				}
			}
			loading = false;
		}
	}
}
