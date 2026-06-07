using System;
using UnityEngine;

[Serializable]
public class ActivateOverlayObjective : QuestObjectiveBase
{
	[SerializeField]
	private Overlays.Type _overlay;

	public ActivateOverlayObjective()
	{
	}

	private ActivateOverlayObjective(ActivateOverlayObjective other)
		: base(other)
	{
	}

	public override void SetActive(bool active)
	{
		base.SetActive(active);
		if (active)
		{
			GameEventDispatcher.AddListener(GameEventType.OverlayUpdate, OnOverlayUpdate);
		}
		else
		{
			GameEventDispatcher.RemoveListener(GameEventType.OverlayUpdate, OnOverlayUpdate);
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.OverlayUpdate, OnOverlayUpdate);
	}

	private void OnOverlayUpdate(GameEvent gameEvent)
	{
		if (Overlays.OverlayType == _overlay)
		{
			SetCompleted(completed: true);
		}
	}

	public override object Clone()
	{
		return new ActivateOverlayObjective(this);
	}
}
