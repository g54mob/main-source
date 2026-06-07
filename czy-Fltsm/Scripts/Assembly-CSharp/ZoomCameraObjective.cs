using System;
using UnityEngine;

[Serializable]
public class ZoomCameraObjective : QuestObjectiveBase
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Zoom Camera";

	[SerializeField]
	private float _minimumZoom = 0.5f;

	[SerializeField]
	private bool _includePreviousZooms;

	private float _totalZoom;

	public ZoomCameraObjective()
	{
	}

	public ZoomCameraObjective(ZoomCameraObjective other)
		: base(other)
	{
		_minimumZoom = other._minimumZoom;
		_includePreviousZooms = other._includePreviousZooms;
		_totalZoom = other._totalZoom;
	}

	public override bool IsCompleted()
	{
		if (base.IsCompleted())
		{
			return true;
		}
		return ((!_includePreviousZooms || _totalZoom != 0f) ? _totalZoom : GameManager.GameStatsManager.TotalCameraZoomChanges) >= _minimumZoom;
	}

	public override void Initialize()
	{
		if (!InitializeIsCompleted())
		{
			GameEventDispatcher.AddListener(GameEventType.ManualCameraZoom, OnCameraZoomed);
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ManualCameraZoom, OnCameraZoomed);
	}

	private void OnCameraZoomed(GameEvent gameEvent)
	{
		if (gameEvent is CameraGameEvent cameraGameEvent)
		{
			_totalZoom += Mathf.Abs(cameraGameEvent.Zoom);
			if (IsCompleted())
			{
				SetCompleted(completed: true);
			}
		}
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Zoom Camera";
	}

	public override object Clone()
	{
		return new ZoomCameraObjective(this);
	}
}
