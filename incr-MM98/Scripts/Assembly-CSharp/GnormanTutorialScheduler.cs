using System;
using System.Collections.Generic;
using R3;
using R3.Triggers;
using UnityEngine;

public class GnormanTutorialScheduler : MonoBehaviour
{
	private readonly Dictionary<GnormanAction, IDisposable> _tutorialSubscriptions = new Dictionary<GnormanAction, IDisposable>();

	private void Start()
	{
		if (!Database.State.Studio.Tutorial.Value)
		{
			UnityEngine.Object.Destroy(this);
		}
		else
		{
			RegisterObservableConditions();
		}
	}

	private void OnDestroy()
	{
		foreach (IDisposable value in _tutorialSubscriptions.Values)
		{
			value?.Dispose();
		}
	}

	private void RegisterObservableConditions()
	{
		Database.State.Gnorman.Action.Select((GnormanAction x) => x == GnormanAction.None).IsTrue().Subscribe(delegate
		{
			TryTriggerQueuedTutorial();
		})
			.AddTo(this);
		RegisterTutorial(GnormanAction.ATutorialIntroduction, Database.State.Game.Name.Where((string x) => !string.IsNullOrEmpty(x)));
		RegisterTutorial(GnormanAction.BTutorialServerload, from x in Database.State.Resources.Load.ThrottleLastHalfSecond()
			where x >= 0.4f && Database.State.Upgrades.IsUnlocked(UpgradeNode.Operations)
			select x);
		RegisterTutorial(GnormanAction.CTutorialDebugger, UI.Registry.taskbar.debugger.gameObject.OnEnableAsObservable());
		RegisterTutorial(GnormanAction.DTutorialPing, UI.Registry.taskbar.world.gameObject.OnEnableAsObservable());
		RegisterTutorial(GnormanAction.ETutorialReprovision, from x in Database.State.Datacenters.StateChanged
			select Database.State.Datacenters.GetState(x) into x
			where x == DatacenterState.Degraded || x == DatacenterState.Critical
			select x);
		RegisterTutorial(GnormanAction.FTutorialSequel, UI.Registry.taskbar.sequel.gameObject.OnEnableAsObservable());
		RegisterTutorial(GnormanAction.F2TutorialRelease, Database.State.Sequel.Round.Where((int x) => x >= 1));
		RegisterTutorial(GnormanAction.GTutorialResearch, Database.State.Prestige.Data.Where((double x) => x > 1.0));
		RegisterTutorial(GnormanAction.HTutorialTrueFans, Database.State.Prestige.Fans.CombineLatest(Database.State.Game.Launched, (double f, bool l) => l && f > 1.0).IsTrue());
	}

	private void RegisterTutorial<T>(GnormanAction action, Observable<T> source)
	{
		if (!Database.State.Gnorman.TutorialActionsStarted.Contains(action) && !Database.State.Gnorman.TutorialActionsQueue.Contains(action))
		{
			_tutorialSubscriptions[action] = source.Take(1).Subscribe(action, delegate(T _, GnormanAction x)
			{
				QueueTutorial(x);
				TryTriggerQueuedTutorial();
			});
		}
	}

	private void QueueTutorial(GnormanAction action)
	{
		if (action != GnormanAction.None && !Database.State.Gnorman.TutorialActionsStarted.Contains(action) && !Database.State.Gnorman.TutorialActionsQueue.Contains(action))
		{
			Database.State.Gnorman.TutorialActionsQueue.Enqueue(action);
		}
	}

	private void TryTriggerQueuedTutorial()
	{
		if (Database.State.Gnorman.TutorialActionsQueue.Count != 0 && !Database.State.Gnorman.Action.Value.IsTutorial())
		{
			GnormanAction gnormanAction = Database.State.Gnorman.TutorialActionsQueue.Dequeue();
			if (_tutorialSubscriptions.TryGetValue(gnormanAction, out var value))
			{
				value?.Dispose();
			}
			EventHub.Scene.Publish(new GnormanActionStarted(gnormanAction));
		}
	}
}
