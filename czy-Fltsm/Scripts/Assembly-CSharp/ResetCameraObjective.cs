using System;
using UnityEngine;

[Serializable]
public class ResetCameraObjective : QuestObjectiveBase
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Reset Camera";

	[SerializeField]
	private bool _includePreviousReset;

	public ResetCameraObjective()
	{
	}

	public ResetCameraObjective(ResetCameraObjective other)
		: base(other)
	{
		_includePreviousReset = other._includePreviousReset;
	}

	public override bool IsCompleted()
	{
		if (!base.IsCompleted())
		{
			if (_includePreviousReset)
			{
				return GameManager.GameStatsManager.HasEverResetCamera;
			}
			return false;
		}
		return true;
	}

	public override void Initialize()
	{
		if (!InitializeIsCompleted())
		{
			GameEventDispatcher.AddListener(GameEventType.CameraReset, OnCameraReset);
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.CameraReset, OnCameraReset);
	}

	private void OnCameraReset(GameEvent gameEvent)
	{
		SetCompleted(completed: true);
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Reset Camera Position";
	}

	public override object Clone()
	{
		return new ResetCameraObjective(this);
	}
}
