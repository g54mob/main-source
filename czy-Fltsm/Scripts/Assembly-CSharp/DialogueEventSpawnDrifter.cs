using System;
using UnityEngine;

[Serializable]
public class DialogueEventSpawnDrifter : IDialogueEvent
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Spawn Drifter";

	[SerializeField]
	private bool _spawnSpeaker = true;

	[SerializeField]
	[ConditionalHide("_spawnSpeaker", true, true)]
	private AgentProfile _drifterProfile;

	[SerializeField]
	private LandmarkPicker.Settings _spawnSettings;

	void IDialogueEvent.TriggerEvent(Dialogue dialogue)
	{
		AgentProfile agentProfile = (_spawnSpeaker ? dialogue.MainSpeaker.AgentProfile : _drifterProfile);
		if (agentProfile == null || !agentProfile.Spawn(_spawnSettings))
		{
			Debug.LogException(new ArgumentException($"Failed to spawn drifter {agentProfile}!"));
		}
	}
}
