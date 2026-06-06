using System;
using I2.Loc;
using UnityEngine;

[Serializable]
public class OpenClosePanelObjective : QuestObjectiveBase, ILocalizationParamsManager
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Open/Close panel";

	[SerializeField]
	private PanelID _panelID = PanelID.None;

	[SerializeField]
	private bool _needsOpen = true;

	public OpenClosePanelObjective()
	{
	}

	public OpenClosePanelObjective(OpenClosePanelObjective other)
		: base(other)
	{
		_panelID = other._panelID;
		_needsOpen = other._needsOpen;
	}

	public override void Initialize()
	{
		if (_needsOpen)
		{
			GameEventDispatcher.AddListener(GameEventType.PanelOpened, OnPanelOpened);
		}
		else
		{
			GameEventDispatcher.AddListener(GameEventType.PanelClosed, OnPanelClosed);
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.PanelOpened, OnPanelOpened);
		GameEventDispatcher.RemoveListener(GameEventType.PanelClosed, OnPanelClosed);
	}

	private void OnPanelOpened(GameEvent gameEvent)
	{
		if (gameEvent is PanelEvent panelEvent && panelEvent.ID == _panelID)
		{
			SetCompleted(completed: true);
		}
	}

	private void OnPanelClosed(GameEvent gameEvent)
	{
		if (gameEvent is PanelEvent panelEvent && panelEvent.ID == _panelID)
		{
			SetCompleted(completed: true);
		}
	}

	protected override string GetNonLocalizedDescription()
	{
		return string.Format("{0} panel: {1}", _needsOpen ? "Open" : "Close", _panelID);
	}

	public override string GetParameterValue(string param)
	{
		if (param == "PANEL")
		{
			return _panelID.ToString();
		}
		return base.GetParameterValue(param);
	}

	public override object Clone()
	{
		return new OpenClosePanelObjective(this);
	}
}
