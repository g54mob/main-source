using System.Collections.Generic;
using Lexone.UnityTwitchChat;
using UnityEngine;
using UnityEngine.Events;

public class TwitchCommandList : MonoBehaviour
{
	[SerializeField]
	private string joinCommand;

	[SerializeField]
	private TwitchCommandLibrary twitchLibrary;

	[SerializeField]
	private List<TwitchCommand> serializedTwitchCommands = new List<TwitchCommand>();

	public static TwitchCommandList instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
	}

	[ContextMenu("RELOAD SERIALIZATION LIST")]
	public void ReloadSerializedList()
	{
		serializedTwitchCommands = twitchLibrary.commandList;
	}

	public static bool IsValidated()
	{
		return instance != null;
	}

	public static List<TwitchCommand> GetCommandList()
	{
		if (IsValidated())
		{
			return instance.twitchLibrary.commandList;
		}
		return instance.serializedTwitchCommands;
	}

	public static string GetJoinCommand()
	{
		return instance.joinCommand;
	}

	public static TwitchCommand GetCommandByIndex(int cmdIndex)
	{
		return GetCommandList()[cmdIndex];
	}

	public static void RegisterToCommand(string commandName, UnityAction<TwitchCommand, Chatter> action)
	{
		instance.twitchLibrary.commandList.Find((TwitchCommand cmd) => cmd.command.ToLower() == commandName.ToLower())?.OnCommandTrigger.AddListener(delegate(TwitchCommand cmd, Chatter chatter)
		{
			action(cmd, chatter);
		});
	}

	public static bool HasCommand(string message)
	{
		return GetCommandList().Find((TwitchCommand cmd) => cmd.command.ToLower() == message.ToLower()) != null;
	}

	public static void InvokeCommand(string message, Chatter chatter)
	{
		TwitchCommand twitchCommand = instance.twitchLibrary.commandList.Find((TwitchCommand cmd) => cmd.command.ToLower() == message.ToLower());
		twitchCommand?.OnCommandTrigger.Invoke(twitchCommand, chatter);
	}
}
