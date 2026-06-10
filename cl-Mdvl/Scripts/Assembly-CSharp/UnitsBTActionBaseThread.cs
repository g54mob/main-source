using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.CommanderAI.BehaviourTreeTasks;
using NSMedieval.Goap;
using NSMedieval.Tutorial;
using NSMedieval.Utils.TimeHelpers;

public abstract class UnitsBTActionBaseThread : UnitsBTActionBase
{
	private Cooldown tickCooldown;

	protected bool IsThreadJobRunning { get; private set; }

	protected bool ShouldSkipThreadJob { get; set; }

	protected bool IsWaitingForThreadJobDiscard { get; private set; }

	protected virtual int ThreadTickIntervalMinutes => -1;

	protected override void OnStart()
	{
		tickCooldown = Cooldown.FromNowMinutes(-100, TutorialManager.IsTutorialActive);
		if (ThreadTickIntervalMinutes <= 0)
		{
			StartThreadJob();
		}
	}

	protected abstract bool OnThread();

	protected abstract void OnDoneCallback(bool result);

	protected virtual void OnCancelledThreadDone()
	{
	}

	protected override void OnUpdate()
	{
		if (!IsThreadJobRunning && !IsWaitingForThreadJobDiscard && ThreadTickIntervalMinutes > 0 && tickCooldown.HasEnded)
		{
			StartThreadJob();
		}
		base.OnUpdate();
	}

	protected override void OnStop(bool interrupted)
	{
		base.OnStop(interrupted);
		FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(31, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\UnitsBTActionBaseThread.cs");
		if (isEnabled)
		{
			messageBuilder.AppendLiteral("OnStop called with interrupted ");
			messageBuilder.AppendFormatted(interrupted);
		}
		Log.Debug(messageBuilder);
		if (interrupted && !IsWaitingForThreadJobDiscard)
		{
			IsWaitingForThreadJobDiscard = IsThreadJobRunning;
			messageBuilder = new FVLogDebugInterpolationHandler(34, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\UnitsBTActionBaseThread.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Interrupted, isWaitingForDiscard: ");
				messageBuilder.AppendFormatted(IsWaitingForThreadJobDiscard);
			}
			Log.Debug(messageBuilder);
		}
	}

	private void StartThreadJob()
	{
		Log.Debug("StartThreadJob", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\UnitsBTActionBaseThread.cs");
		if (IsWaitingForThreadJobDiscard)
		{
			Log.Debug("Can't start because is waiting for thread discard", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\UnitsBTActionBaseThread.cs");
			EndAction(success: false);
			return;
		}
		if (ShouldSkipThreadJob)
		{
			IsThreadJobRunning = false;
			return;
		}
		Log.Debug("Starting thread job", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\UnitsBTActionBaseThread.cs");
		IsThreadJobRunning = true;
		MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(OnThread, delegate(bool result)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\UnitsBTActionBaseThread.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Thread job ended with result ");
				messageBuilder.AppendFormatted(result);
			}
			Log.Debug(messageBuilder);
			if (IsWaitingForThreadJobDiscard)
			{
				Log.Debug("Discarding callback invoke", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\UnitsBTActionBaseThread.cs");
				IsWaitingForThreadJobDiscard = false;
				IsThreadJobRunning = false;
				OnCancelledThreadDone();
				tickCooldown = Cooldown.FromNowMinutes(ThreadTickIntervalMinutes, TutorialManager.IsTutorialActive);
			}
			else
			{
				OnDoneCallback(result);
				IsThreadJobRunning = false;
				tickCooldown = Cooldown.FromNowMinutes(ThreadTickIntervalMinutes, TutorialManager.IsTutorialActive);
			}
		});
	}
}
