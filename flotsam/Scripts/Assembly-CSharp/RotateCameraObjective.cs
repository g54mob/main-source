using System;
using UnityEngine;

[Serializable]
public class RotateCameraObjective : QuestObjectiveBase
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Rotate Camera";

	[SerializeField]
	private float _minimumRotation = 45f;

	[SerializeField]
	private bool _includePreviousRotations;

	private float _totalRotation;

	public RotateCameraObjective()
	{
	}

	public RotateCameraObjective(RotateCameraObjective other)
		: base(other)
	{
		_minimumRotation = other._minimumRotation;
		_includePreviousRotations = other._includePreviousRotations;
		_totalRotation = other._totalRotation;
	}

	public override bool IsCompleted()
	{
		if (base.IsCompleted())
		{
			return true;
		}
		return ((!_includePreviousRotations || _totalRotation != 0f) ? _totalRotation : GameManager.GameStatsManager.TotalCameraRotationChanges) >= _minimumRotation;
	}

	public override void Initialize()
	{
		_totalRotation = (_includePreviousRotations ? GameManager.GameStatsManager.TotalCameraRotationChanges : 0f);
		if (!InitializeIsCompleted())
		{
			GameEventDispatcher.AddListener(GameEventType.ManualCameraRotation, OnCameraRotated);
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ManualCameraRotation, OnCameraRotated);
	}

	private void OnCameraRotated(GameEvent gameEvent)
	{
		if (gameEvent is CameraGameEvent cameraGameEvent)
		{
			_totalRotation += Mathf.Abs(cameraGameEvent.Rotation);
			if (IsCompleted())
			{
				SetCompleted(completed: true);
			}
		}
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Rotate Camera";
	}

	public override object Clone()
	{
		return new RotateCameraObjective(this);
	}
}
