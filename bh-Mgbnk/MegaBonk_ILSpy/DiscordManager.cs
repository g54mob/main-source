using System;
using Assets.Scripts.Stats___Achievements.Discord;
using Cpp2ILInjected;
using Discord;
using UnityEngine;

public class DiscordManager : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static ActivityManager.UpdateActivityHandler _003C_003E9__8_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		public _003C_003Ec()
		{
			_003CUpdateActivity_003Eb__8_0(Result.Ok);
		}

		internal void _003CUpdateActivity_003Eb__8_0(Result res)
		{
		}
	}

	public static bool ENABLED = true;

	private bool isRunning;

	private global::Discord.Discord discord;

	public static DiscordManager Instance;

	private float checkReconnectTimer = 5f;

	private long appid = 1336699900590690314L;

	private void Awake()
	{
		if (!(Instance == null))
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		Instance = this;
		bool flag = !ENABLED;
		DiscordManager discordManager = this;
		if (!flag)
		{
			DiscordRichPresence.Init();
			DiscordRichPresence.UpdateMainMenu();
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 132 Invalid \"Jump target not found in method: 0x180355080\"");
			DiscordManager discordManager2 = default(DiscordManager);
			discordManager = discordManager2;
		}
		discordManager.enabled = false;
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			DiscordRichPresence.OnDestroy();
			if (discord != null)
			{
				discord.Dispose();
			}
		}
	}

	public unsafe void UpdateActivity(Activity activity)
	{
		//IL_004e: Expected O, but got Ref
		if (ENABLED && isRunning)
		{
			ActivityManager activityManager = discord.GetActivityManager();
			ActivityManager.UpdateActivityHandler callback = _003C_003Ec._003C_003E9__8_0;
			if (_003C_003Ec._003C_003E9__8_0 == null)
			{
				callback = (_003C_003Ec._003C_003E9__8_0 = delegate
				{
				});
			}
			object obj = default(object);
			activityManager.UpdateActivity((Activity)(&obj), callback);
		}
	}

	private void Update()
	{
		//IL_008a: Invalid comparison between I4 and F4
		if (!ENABLED)
		{
			return;
		}
		if (isRunning)
		{
			DiscordRichPresence.Update();
			if (discord != null)
			{
				discord.RunCallbacks();
			}
			return;
		}
		float deltaTime = Time.deltaTime;
		if (!(0f < (checkReconnectTimer -= deltaTime)))
		{
			checkReconnectTimer = 20f;
			TryReconnect();
		}
	}

	private void TryReconnect()
	{
		//IL_0030: Expected I8, but got I4
		global::Discord.Discord discord = new global::Discord.Discord(appid, 1uL);
		this.discord = discord;
		isRunning = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}
}
