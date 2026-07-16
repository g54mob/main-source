using System.Collections.Generic;
using Lexone.UnityTwitchChat;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TW_GlobalCommands : MonoBehaviour
{
	private char[] commandCharWhiteList = new char[2] { '!', '<' };

	[SerializeField]
	private float commandDelay = 5f;

	public static int commandCount = 5;

	public List<Chatter> joinedChatters = new List<Chatter>();

	public static UnityEvent<TwitchCommand, Chatter> OnCommandTrigger = new UnityEvent<TwitchCommand, Chatter>();

	public static TW_GlobalCommands instance;

	public static bool queuelineRestriction = true;

	private bool loaded;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (!loaded)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Start()
	{
		IRC.Instance.OnChatMessage += CheckMessage;
		SceneManager.activeSceneChanged += ChangedActiveScene;
		loaded = true;
	}

	private void OnEnable()
	{
		if (!(IRC.Instance == null))
		{
			IRC.Instance.OnChatMessage += CheckMessage;
		}
	}

	private void OnDisable()
	{
		if (!(IRC.Instance == null))
		{
			IRC.Instance.OnChatMessage -= CheckMessage;
		}
	}

	private void OnDestroy()
	{
		if (!(IRC.Instance == null))
		{
			IRC.Instance.OnChatMessage -= CheckMessage;
		}
	}

	private void FixedUpdate()
	{
		if (IRC.Instance == null)
		{
			return;
		}
		if (IRC.Instance.stayConnected && !IRC.Instance.isConnected)
		{
			IRC.Instance.Connect();
		}
		foreach (Chatter joinedChatter in joinedChatters)
		{
			if (joinedChatter.cooldownTime > 0f)
			{
				joinedChatter.cooldownTime -= 1f * Time.deltaTime;
			}
			else if (joinedChatter.cooldownTime < 0f)
			{
				joinedChatter.cooldownTime = 0f;
			}
		}
	}

	public static char GetPrimaryCommandLetter()
	{
		return instance.commandCharWhiteList[0];
	}

	public static Chatter GetRandomJoinedChatter()
	{
		if (instance.joinedChatters.Count == 0)
		{
			return null;
		}
		return instance.joinedChatters[Random.Range(0, instance.joinedChatters.Count)];
	}

	private void ChangedActiveScene(Scene current, Scene next)
	{
		if (IRC.Instance.stayConnected && !IRC.Instance.isConnected)
		{
			joinedChatters.Clear();
			IRC.Instance.Connect();
		}
	}

	private bool ValidateIsCommandWritten(char firstChar)
	{
		bool result = false;
		for (int i = 0; i < commandCharWhiteList.Length; i++)
		{
			if (firstChar == commandCharWhiteList[i])
			{
				result = true;
			}
		}
		return result;
	}

	public void JoinGame(Chatter chatter)
	{
		joinedChatters.Add(chatter);
	}

	public bool HasJoined(Chatter chatter)
	{
		return joinedChatters.Find((Chatter x) => x.tags.displayName == chatter.tags.displayName) != null;
	}

	public bool IsCommand(string commandName, Chatter chatter)
	{
		if (chatter.message.ToLower().Contains(commandName.ToLower()))
		{
			return true;
		}
		return false;
	}

	public void CheckMessage(Chatter chatter)
	{
		if (!ValidateIsCommandWritten(chatter.message[0]))
		{
			return;
		}
		if (!HasJoined(chatter))
		{
			if (IsCommand(TwitchCommandList.GetJoinCommand(), chatter))
			{
				JoinGame(chatter);
			}
			return;
		}
		TwitchCommand twitchCommand = TwitchCommandList.GetCommandList().Find((TwitchCommand x) => chatter.message.ToLower().Contains(x.command.ToLower()));
		if (twitchCommand != null && twitchCommand.enabled)
		{
			Chatter chatter2 = joinedChatters.Find((Chatter x) => x.tags.displayName == chatter.tags.displayName);
			if (!(chatter2.cooldownTime > 0f))
			{
				chatter2.SetCooldown(twitchCommand.cooldown);
				chatter2.message = chatter.message;
				OnCommandTrigger.Invoke(twitchCommand, chatter2);
			}
		}
	}
}
