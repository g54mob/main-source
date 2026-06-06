using System;
using UnityEngine;

[Serializable]
public class OpenCloseWorldMapObjective : QuestObjectiveBase
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Open/Close world map";

	[SerializeField]
	private bool _needsOpen = true;

	public OpenCloseWorldMapObjective()
	{
	}

	public OpenCloseWorldMapObjective(OpenCloseWorldMapObjective other)
		: base(other)
	{
		_needsOpen = other._needsOpen;
	}

	public override bool IsCompleted()
	{
		if (base.IsCompleted())
		{
			return true;
		}
		return GameManager.UIManager.UIState == UIState.Map == _needsOpen;
	}

	public override void Initialize()
	{
		if (!InitializeIsCompleted())
		{
			if (_needsOpen)
			{
				GameEventDispatcher.AddListener(GameEventType.MapActivated, OnMapOpened);
			}
			else
			{
				GameEventDispatcher.AddListener(GameEventType.MapDeactivated, OnMapClosed);
			}
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.MapActivated, OnMapOpened);
		GameEventDispatcher.RemoveListener(GameEventType.MapDeactivated, OnMapClosed);
	}

	private void OnMapOpened(GameEvent gameEvent)
	{
		SetCompleted(completed: true);
	}

	private void OnMapClosed(GameEvent gameEvent)
	{
		SetCompleted(completed: true);
	}

	protected override string GetNonLocalizedDescription()
	{
		return (_needsOpen ? "Open" : "Close") + " World Map";
	}

	public override object Clone()
	{
		return new OpenCloseWorldMapObjective(this);
	}
}
