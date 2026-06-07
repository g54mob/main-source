using System;
using PajamaLlama.Utilities;
using UnityEngine;

[Serializable]
public class MoveTownBackwardsObjective : QuestObjectiveBase
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Move town backwards";

	[SerializeField]
	[Tooltip("Bumping against a wall at full speed seems to bounce back by a little more than 10")]
	private float _minimumDistance = 11f;

	private Vector3 _previousFramePosition = Vector3.zero;

	private float _distanceTraveledBackwards;

	private bool _isMoving;

	public MoveTownBackwardsObjective()
	{
	}

	public MoveTownBackwardsObjective(MoveTownBackwardsObjective other)
		: base(other)
	{
		_minimumDistance = other._minimumDistance;
		_previousFramePosition = other._previousFramePosition;
		_distanceTraveledBackwards = other._distanceTraveledBackwards;
	}

	public override void Initialize()
	{
		GameEventDispatcher.AddListener(GameEventType.WorldMapStartedMoving, OnTownStartMoving);
		GameEventDispatcher.AddListener(GameEventType.WorldMapStoppedMoving, OnTownStopMoving);
	}

	public override void Uninitialize()
	{
		FinalUpdate.UnregisterEndOfFrame(OnTownMove);
		GameEventDispatcher.RemoveListener(GameEventType.WorldMapStartedMoving, OnTownStartMoving);
		GameEventDispatcher.RemoveListener(GameEventType.WorldMapStoppedMoving, OnTownStopMoving);
	}

	private void OnTownStartMoving(GameEvent gameEvent)
	{
		if (!_isMoving)
		{
			_isMoving = true;
			_previousFramePosition = GameManager.WorldMapManager.WorldMap.Townheart.Position;
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

	private void OnTownMove()
	{
		Transform transform = GameManager.WorldMapManager.WorldMap.Townheart.transform;
		Vector3 position = transform.position;
		Vector3 forward = transform.forward;
		Vector3 lhs = position - _previousFramePosition;
		_previousFramePosition = position;
		if (Vector3.Dot(lhs, forward) >= 0f)
		{
			_distanceTraveledBackwards = 0f;
			return;
		}
		_distanceTraveledBackwards += lhs.magnitude;
		if (_distanceTraveledBackwards >= _minimumDistance)
		{
			SetCompleted(completed: true);
		}
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Move Town Backwards";
	}

	public override object Clone()
	{
		return new MoveTownBackwardsObjective(this);
	}
}
