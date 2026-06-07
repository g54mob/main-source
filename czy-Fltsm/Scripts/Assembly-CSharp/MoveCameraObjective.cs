using System;
using UnityEngine;

[Serializable]
public class MoveCameraObjective : QuestObjectiveBase
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Move Camera";

	[SerializeField]
	private float _minimumDistance = 10f;

	[SerializeField]
	private bool _includePreviousMovements;

	private float _totalDistanceMoved;

	public MoveCameraObjective()
	{
	}

	public MoveCameraObjective(MoveCameraObjective other)
		: base(other)
	{
		_minimumDistance = other._minimumDistance;
		_includePreviousMovements = other._includePreviousMovements;
		_totalDistanceMoved = other._totalDistanceMoved;
	}

	public override bool IsCompleted()
	{
		if (base.IsCompleted())
		{
			return true;
		}
		return ((!_includePreviousMovements || _totalDistanceMoved != 0f) ? _totalDistanceMoved : GameManager.GameStatsManager.TotalCameraMovedDistance) >= _minimumDistance;
	}

	public override void Initialize()
	{
		_totalDistanceMoved = (_includePreviousMovements ? GameManager.GameStatsManager.TotalCameraMovedDistance : 0f);
		if (!InitializeIsCompleted())
		{
			GameEventDispatcher.AddListener(GameEventType.ManualCameraMovement, OnCameraMoved);
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ManualCameraMovement, OnCameraMoved);
	}

	private void OnCameraMoved(GameEvent gameEvent)
	{
		if (gameEvent is CameraGameEvent cameraGameEvent)
		{
			_totalDistanceMoved += cameraGameEvent.DistanceMoved;
			if (IsCompleted())
			{
				SetCompleted(completed: true);
			}
		}
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Move Camera";
	}

	public override object Clone()
	{
		return new MoveCameraObjective(this);
	}
}
