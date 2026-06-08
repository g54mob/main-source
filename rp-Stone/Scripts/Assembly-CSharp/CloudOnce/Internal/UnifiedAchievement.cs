using System;
using CloudOnce.Internal.Utils;

namespace CloudOnce.Internal
{
	public class UnifiedAchievement
	{
		private readonly string internalID;

		private bool isAchievementHidden = true;

		private double achievementProgress;

		public string ID { get; private set; }

		public bool IsUnlocked { get; private set; }

		public double Progress
		{
			get
			{
				return achievementProgress;
			}
			private set
			{
				if (!(value < achievementProgress))
				{
					achievementProgress = ((value > 100.0) ? 100.0 : value);
				}
			}
		}

		public UnifiedAchievement(string internalID, string platformID)
		{
			this.internalID = internalID;
			ID = platformID;
		}

		public void Unlock(Action<CloudRequestResult<bool>> onComplete = null)
		{
			if (!IsUnlocked)
			{
				Action<CloudRequestResult<bool>> onComplete2 = delegate(CloudRequestResult<bool> response)
				{
					OnUnlockCompleted(response, onComplete);
				};
				CloudOnceUtils.AchievementUtils.Unlock(ID, onComplete2, internalID);
			}
			else
			{
				ReportError($"Can't unlock {ID}. Achievement has already been unlocked.", onComplete);
			}
		}

		public void Reveal(Action<CloudRequestResult<bool>> onComplete = null)
		{
			if (isAchievementHidden)
			{
				Action<CloudRequestResult<bool>> onComplete2 = delegate(CloudRequestResult<bool> response)
				{
					OnRevealCompleted(response, onComplete);
				};
				CloudOnceUtils.AchievementUtils.Reveal(ID, onComplete2, internalID);
			}
			else
			{
				ReportError($"Can't reveal {ID}. Achievement has already been revealed.", onComplete);
			}
		}

		public void Increment(double current, double goal, Action<CloudRequestResult<bool>> onComplete = null)
		{
			Increment(current / goal * 100.0, onComplete);
		}

		public void Increment(double progress, Action<CloudRequestResult<bool>> onComplete = null)
		{
			if (IsUnlocked)
			{
				ReportError($"Can't increment {internalID} ({ID}). Achievement is already unlocked.", onComplete);
				return;
			}
			if (progress < 0.0)
			{
				throw new ArgumentException("Value must not be negative!", "progress");
			}
			if (progress.Equals(0.0))
			{
				Reveal(onComplete);
			}
			else if (progress >= 100.0)
			{
				Unlock(onComplete);
			}
			else if (progress <= Progress)
			{
				ReportError($"Can't increment {internalID} ({ID}) to {progress:F2}%. Achievement is already at {Progress:F2}%.", onComplete);
			}
			else
			{
				Action<CloudRequestResult<bool>> onComplete2 = delegate(CloudRequestResult<bool> response)
				{
					OnIncrementCompleted(response, progress, onComplete);
				};
				CloudOnceUtils.AchievementUtils.Increment(ID, progress, onComplete2, internalID);
			}
		}

		public void UpdateData(bool isUnlocked, double progress, bool isHidden)
		{
			if (IsUnlocked && !isUnlocked)
			{
				Action<CloudRequestResult<bool>> onComplete = delegate(CloudRequestResult<bool> response)
				{
					OnUnlockCompleted(response, null);
				};
				CloudOnceUtils.AchievementUtils.Unlock(ID, onComplete, internalID);
				return;
			}
			if (Progress > progress)
			{
				Action<CloudRequestResult<bool>> onComplete2 = delegate(CloudRequestResult<bool> response)
				{
					OnIncrementCompleted(response, progress, null);
				};
				CloudOnceUtils.AchievementUtils.Increment(ID, progress, onComplete2, internalID);
				return;
			}
			IsUnlocked = isUnlocked;
			Progress = progress;
			isAchievementHidden = isHidden;
			if (!IsUnlocked && Progress.Equals(100.0))
			{
				Action<CloudRequestResult<bool>> onComplete3 = delegate(CloudRequestResult<bool> response)
				{
					OnUnlockCompleted(response, null);
				};
				CloudOnceUtils.AchievementUtils.Unlock(ID, onComplete3, internalID);
			}
		}

		public void ResetLocalState()
		{
			IsUnlocked = false;
			isAchievementHidden = true;
			achievementProgress = 0.0;
		}

		private static void ReportError(string errorMessage, Action<CloudRequestResult<bool>> callbackAction)
		{
			CloudOnceUtils.SafeInvoke(callbackAction, new CloudRequestResult<bool>(result: false, errorMessage));
		}

		private void OnUnlockCompleted(CloudRequestResult<bool> response, Action<CloudRequestResult<bool>> callbackAction)
		{
			if (response.Result)
			{
				IsUnlocked = true;
				isAchievementHidden = false;
				Progress = 100.0;
				CloudOnceUtils.SafeInvoke(callbackAction, new CloudRequestResult<bool>(result: true));
			}
			else
			{
				CloudOnceUtils.SafeInvoke(callbackAction, new CloudRequestResult<bool>(result: false, response.Error));
			}
		}

		private void OnRevealCompleted(CloudRequestResult<bool> response, Action<CloudRequestResult<bool>> callbackAction)
		{
			if (response.Result)
			{
				isAchievementHidden = false;
				CloudOnceUtils.SafeInvoke(callbackAction, new CloudRequestResult<bool>(result: true));
			}
			else
			{
				CloudOnceUtils.SafeInvoke(callbackAction, new CloudRequestResult<bool>(result: false, response.Error));
			}
		}

		private void OnIncrementCompleted(CloudRequestResult<bool> response, double progress, Action<CloudRequestResult<bool>> callbackAction)
		{
			if (response.Result)
			{
				Progress = progress;
				CloudOnceUtils.SafeInvoke(callbackAction, new CloudRequestResult<bool>(result: true));
			}
			else
			{
				CloudOnceUtils.SafeInvoke(callbackAction, new CloudRequestResult<bool>(result: false, response.Error));
			}
		}
	}
}
