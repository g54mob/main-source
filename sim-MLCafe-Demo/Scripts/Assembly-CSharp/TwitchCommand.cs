using System;
using Lexone.UnityTwitchChat;
using UnityEngine.Events;

[Serializable]
public class TwitchCommand
{
	public string command;

	public string description;

	public bool enabled = true;

	public float duration;

	public float cooldown;

	public float additionalOptionValue_1;

	public float additionalOptionValue_2;

	public bool needsToBeJoined;

	public UnityEvent<TwitchCommand, Chatter> OnCommandTrigger;
}
