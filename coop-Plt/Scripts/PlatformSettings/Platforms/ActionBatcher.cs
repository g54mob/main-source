using System;
using System.Threading;
using System.Threading.Tasks;
using Kitchen.NetworkSupport;
using UnityEngine;

namespace Platforms
{
	public class ActionBatcher
	{
		public float CommitDelay = 5f;

		public float TaskRepeatTime = 1f;

		public bool AutoRecommit;

		private Action Commit;

		private float LastCommitTime;

		private bool HasQueuedCommit;

		private CancellationTokenSource TokenSource;

		private float CurrentTime => Time.realtimeSinceStartup;

		public ActionBatcher(Action action, float commit_delay = 5f, float task_repeat_time = 1f)
		{
			Commit = action;
			CommitDelay = commit_delay;
			TaskRepeatTime = task_repeat_time;
			TokenSource = new CancellationTokenSource();
			CommitLoop(TokenSource.Token);
		}

		public void Cancel()
		{
			TokenSource.Cancel();
		}

		public void RequestCommit(bool immediate = false)
		{
			if (immediate || LastCommitTime < CurrentTime - CommitDelay)
			{
				PerformCommit();
			}
			else
			{
				HasQueuedCommit = true;
			}
		}

		private async void CommitLoop(CancellationToken token)
		{
			while (!token.IsCancellationRequested)
			{
				await Task.Delay((int)(TaskRepeatTime * 1000f), token);
				if ((AutoRecommit || HasQueuedCommit) && CurrentTime > LastCommitTime + CommitDelay)
				{
					try
					{
						PerformCommit();
					}
					catch (Exception ex)
					{
						EventLog.Files.Report(FileEvent.ErrorDuringCommit, ex);
					}
				}
			}
		}

		private void PerformCommit()
		{
			if (Commit != null)
			{
				Commit();
			}
			HasQueuedCommit = false;
			LastCommitTime = CurrentTime;
		}
	}
}
