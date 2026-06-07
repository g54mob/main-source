using Discord;
using UnityEngine;

public class DiscordManager : MonoBehaviour
{
	public static bool ENABLED;

	private bool isRunning;

	private global::Discord.Discord discord;

	public static DiscordManager Instance;

	private float checkReconnectTimer;

	private long appid;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void UpdateActivity(Activity activity)
	{
	}

	private void Update()
	{
	}

	private void TryReconnect()
	{
	}
}
