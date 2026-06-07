using System;
using PajamaLlama.Utilities;
using UnityEngine;

[Serializable]
public class MoveTownObjective : QuestObjectiveBase
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Move town";

	[Header("Move Town")]
	[SerializeField]
	private bool _checkOnlyOnMoveEnd = true;

	[SerializeField]
	[Tooltip("If true, the objective will always require a movement before being considered completed, even if already completed before")]
	private bool _alwaysStartFalse;

	private bool _isMoving;

	public MoveTownObjective()
	{
	}

	public MoveTownObjective(MoveTownObjective other)
		: base(other)
	{
		_checkOnlyOnMoveEnd = other._checkOnlyOnMoveEnd;
		_alwaysStartFalse = other._alwaysStartFalse;
	}

	public override bool IsCompleted()
	{
		if (!base.IsCompleted())
		{
			if (!_alwaysStartFalse)
			{
				return IsArrived();
			}
			return false;
		}
		return true;
	}

	public override void Initialize()
	{
		if (!InitializeIsCompleted())
		{
			if (_checkOnlyOnMoveEnd)
			{
				GameEventDispatcher.AddListener(GameEventType.WorldMapStoppedMoving, OnTownMove);
				return;
			}
			GameEventDispatcher.AddListener(GameEventType.WorldMapStartedMoving, OnTownStartMoving);
			GameEventDispatcher.AddListener(GameEventType.WorldMapStoppedMoving, OnTownStopMoving);
		}
	}

	public override void Uninitialize()
	{
		FinalUpdate.UnregisterEndOfFrame(OnTownMove);
		GameEventDispatcher.RemoveListener(GameEventType.WorldMapStoppedMoving, OnTownMove);
		GameEventDispatcher.RemoveListener(GameEventType.WorldMapStartedMoving, OnTownStartMoving);
		GameEventDispatcher.RemoveListener(GameEventType.WorldMapStoppedMoving, OnTownStopMoving);
	}

	protected virtual bool IsArrived()
	{
		return GameManager.WorldMapManager.WorldMap.Townheart.DidMove;
	}

	protected virtual void OnArrived()
	{
		SetCompleted(completed: true);
	}

	private void OnTownMove()
	{
		OnTownMove(null);
	}

	private void OnTownMove(GameEvent gameEvent)
	{
		if (IsArrived())
		{
			OnArrived();
		}
	}

	private void OnTownStartMoving(GameEvent gameEvent)
	{
		if (!_isMoving)
		{
			_isMoving = true;
			FinalUpdate.RegisterEndOfFrame(OnTownMove);
		}
	}

	private void OnTownStopMoving(GameEvent gameEvent)
	{
		if (_isMoving)
		{
			_isMoving = false;
			FinalUpdate.UnregisterEndOfFrame(OnTownMove);
			OnTownMove();
		}
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Move Town";
	}

	public override object Clone()
	{
		return new MoveTownObjective(this);
	}
}
