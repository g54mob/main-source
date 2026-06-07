using System;
using PajamaLlama.Flotsam.Narrative;
using UnityEngine;

[Serializable]
public class TriggerableOpenPanel : ScenarioTriggerableBase
{
	[SerializeField]
	private PanelID _panelId;

	protected override bool Trigger(AgentDescriptor actorDescriptor)
	{
		return GameManager.UIManager.DisplayPanel(_panelId);
	}
}
