using System;
using UnityEngine;

[Serializable]
public class GameEventObjective : QuestObjectiveBase
{
	[SerializeField]
	private GameEventType _gameEventType;

	public GameEventObjective()
	{
	}

	public GameEventObjective(GameEventObjective other)
		: base(other)
	{
		_gameEventType = other._gameEventType;
	}

	public override void Initialize()
	{
		GameEventDispatcher.AddListener(_gameEventType, OnGameEvent);
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(_gameEventType, OnGameEvent);
	}

	public override object Clone()
	{
		return new GameEventObjective(this);
	}

	private void OnGameEvent(GameEvent gameEvent)
	{
		SetCompleted(completed: true);
	}
}
