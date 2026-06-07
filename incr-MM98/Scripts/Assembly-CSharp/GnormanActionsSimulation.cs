using System;
using System.Collections.Generic;
using System.Linq;
using MessagePipe;
using UnityEngine;
using ZLinq;

[CreateAssetMenu(menuName = "Data/Simulation/Gnorman Actions", fileName = "GnormanActionsSimulation")]
public class GnormanActionsSimulation : ScriptableObject, IIntervalIncrementalSimulation, IIncrementalSimulation
{
	[SerializeField]
	private float minimumTimeBetweenFluff = 30f;

	[SerializeField]
	private float maximumTimeBetweenFluff = 120f;

	[SerializeField]
	private float inactivityTimeRequirement = 30f;

	[SerializeField]
	private int recentFluffMemory = 5;

	private float _timeSinceLastAction;

	private float _nextFluffTime;

	private bool _warnedAbandonment;

	private readonly List<GnormanFluffActionData> _fluffActions = new List<GnormanFluffActionData>();

	private readonly List<GnormanFluffActionData> _upgradeActions = new List<GnormanFluffActionData>();

	private readonly List<GnormanFluffActionData> _researchActions = new List<GnormanFluffActionData>();

	private readonly List<GnormanFluffActionData> _operationActions = new List<GnormanFluffActionData>();

	private readonly Dictionary<GnormanAction, float> _cooldownTimers = new Dictionary<GnormanAction, float>();

	private readonly List<GnormanAction> _recentFluff = new List<GnormanAction>();

	private IDisposable _subscriptions;

	[field: SerializeField]
	public float UpdateInterval { get; private set; } = 1f;

	public void Registered(UIRegistry? _)
	{
		EventHub.Scene.For().Subscribe(delegate
		{
			_warnedAbandonment = false;
		}, Array.Empty<MessageHandlerFilter<Prestiged>>()).Subscribe(HandleGnormanDismissed, Array.Empty<MessageHandlerFilter<GnormanActionFinished>>())
			.Subscribe(delegate
			{
				HandleFluffEvent(_upgradeActions);
			}, Array.Empty<MessageHandlerFilter<UpgradeBought>>())
			.Subscribe(delegate
			{
				HandleFluffEvent(_researchActions);
			}, Array.Empty<MessageHandlerFilter<ResearchBought>>())
			.Subscribe(delegate
			{
				HandleFluffEvent(_operationActions);
			}, Array.Empty<MessageHandlerFilter<OperationStarted>>())
			.Build(out _subscriptions);
		CategorizeActions();
		ScheduleNextFluff();
		if (Database.State.Gnorman.Gullibleness == Gullibleness.Pressed)
		{
			if (!Database.State.Gnorman.InProgress || Database.State.Gnorman.Action.Value.IsFluff())
			{
				TriggerFluffAction(GnormanAction.Fluff25);
				Database.Commands.Resource.ReceiveMoney(1.0);
			}
			Database.State.Gnorman.Gullibleness = Gullibleness.None;
		}
	}

	public void Unregistered()
	{
		_subscriptions?.Dispose();
	}

	public void OnUpdateSimulation(float deltaTime)
	{
		_timeSinceLastAction += deltaTime;
		_nextFluffTime -= deltaTime;
		UpdateCooldowns(deltaTime);
		CheckForFluff();
		AttemptWarnAbandonment();
	}

	private void HandleGnormanDismissed(GnormanActionFinished ctx)
	{
		_timeSinceLastAction = 0f;
		if (ctx.Action.FluffData(out var data))
		{
			StartCooldown(ctx.Action, data.cooldown);
		}
	}

	private void HandleFluffEvent(List<GnormanFluffActionData> actions)
	{
		if (!ReactiveSettings.GnormanMuffled.Value && !Database.State.Gnorman.InProgress && !(_timeSinceLastAction < inactivityTimeRequirement))
		{
			List<GnormanFluffActionData> list = actions.Where(CanTriggerAction).ToList();
			if (list.Count != 0)
			{
				TriggerFluffAction(list.AsValueEnumerable().Random());
			}
		}
	}

	private void CheckForFluff()
	{
		if (!ReactiveSettings.GnormanMuffled.Value && !Database.State.Gnorman.InProgress && !(_timeSinceLastAction < inactivityTimeRequirement) && !(_nextFluffTime > 0f))
		{
			List<GnormanFluffActionData> list = _fluffActions.Where(CanTriggerAction).ToList();
			if (list.Count == 0)
			{
				ScheduleNextFluff();
				return;
			}
			TriggerFluffAction(list.AsValueEnumerable().Random());
			ScheduleNextFluff();
		}
	}

	private void AttemptWarnAbandonment()
	{
		if (!_warnedAbandonment)
		{
			if (Database.State.Sequel.Round.CurrentValue >= 1 || Database.State.Sequel.Developing.CurrentValue)
			{
				_warnedAbandonment = true;
			}
			else if (!(Database.State.Game.Time.CurrentValue < 900.0) && Database.State.Resources.MoneySpend.CurrentValue > Database.State.Sequel.Cost.CurrentValue * 10.0)
			{
				_warnedAbandonment = true;
				EventHub.Scene.Publish(new GnormanActionStarted(GnormanAction.Fluff26));
			}
		}
	}

	private void TriggerFluffAction(GnormanFluffActionData action)
	{
		EventHub.Scene.Publish(new GnormanActionStarted(action));
		_recentFluff.Add(action);
		if (_recentFluff.Count > recentFluffMemory)
		{
			_recentFluff.RemoveAt(0);
		}
	}

	private bool CanTriggerAction(GnormanActionData data)
	{
		if (!_recentFluff.Contains(data))
		{
			return !_cooldownTimers.ContainsKey(data);
		}
		return false;
	}

	private void StartCooldown(GnormanAction action, float duration)
	{
		if (duration > 0f)
		{
			_cooldownTimers[action] = duration;
		}
	}

	private void ScheduleNextFluff()
	{
		_nextFluffTime = UnityEngine.Random.Range(minimumTimeBetweenFluff, maximumTimeBetweenFluff);
	}

	private void UpdateCooldowns(float deltaTime)
	{
		List<GnormanAction> list = new List<GnormanAction>();
		foreach (GnormanAction item in _cooldownTimers.Keys.ToList())
		{
			_cooldownTimers[item] -= deltaTime;
			if (_cooldownTimers[item] <= 0f)
			{
				list.Add(item);
			}
		}
		foreach (GnormanAction item2 in list)
		{
			_cooldownTimers.Remove(item2);
		}
	}

	private void CategorizeActions()
	{
		_fluffActions.Clear();
		_upgradeActions.Clear();
		_researchActions.Clear();
		_operationActions.Clear();
		foreach (GnormanAction item in EnumUtility.GetValuesSkipNone<GnormanAction>())
		{
			if (item.FluffData(out var data))
			{
				CategorizeFluffAction(data);
			}
		}
	}

	private void CategorizeFluffAction(GnormanFluffActionData action)
	{
		switch (action.type)
		{
		case GnormanFluffActionData.Type.Fluff:
			_fluffActions.Add(action);
			break;
		case GnormanFluffActionData.Type.Upgrade:
			_upgradeActions.Add(action);
			break;
		case GnormanFluffActionData.Type.Research:
			_researchActions.Add(action);
			break;
		case GnormanFluffActionData.Type.Operation:
			_operationActions.Add(action);
			break;
		}
	}
}
