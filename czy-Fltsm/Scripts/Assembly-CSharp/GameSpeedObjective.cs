using System;
using I2.Loc;
using UnityEngine;

[Serializable]
public class GameSpeedObjective : QuestObjectiveBase, ILocalizationParamsManager
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Set Game Speed";

	[SerializeField]
	private GameSpeed _gameSpeed = GameSpeed.One;

	[SerializeField]
	private ComparisonType _comparisonType;

	public GameSpeedObjective()
	{
	}

	public GameSpeedObjective(GameSpeedObjective other)
		: base(other)
	{
		_gameSpeed = other._gameSpeed;
		_comparisonType = other._comparisonType;
	}

	public override bool IsCompleted()
	{
		if (!base.IsCompleted())
		{
			return GameSpeedManager.GameSpeed.Compare(_comparisonType, _gameSpeed);
		}
		return true;
	}

	public override void Initialize()
	{
		GameEventDispatcher.AddListener(GameEventType.GameSpeedChange, OnGameSpeedChanged);
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.GameSpeedChange, OnGameSpeedChanged);
	}

	private void OnGameSpeedChanged(GameEvent gameEvent)
	{
		if (gameEvent is GameSpeedChangedEvent gameSpeedChangedEvent && gameSpeedChangedEvent.GameSpeed.Compare(_comparisonType, _gameSpeed))
		{
			SetCompleted(completed: true);
		}
	}

	protected override string GetNonLocalizedDescription()
	{
		return $"Set Game Speed: {_comparisonType} {_gameSpeed}";
	}

	public override string GetParameterValue(string param)
	{
		if (param == "GAMESPEED")
		{
			return _gameSpeed.ToString();
		}
		return base.GetParameterValue(param);
	}

	public override object Clone()
	{
		return new GameSpeedObjective(this);
	}
}
