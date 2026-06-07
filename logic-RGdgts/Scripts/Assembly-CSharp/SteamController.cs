using System;
using System.Collections.Generic;
using Steamworks;

public class SteamController : Controller
{
	private bool _initialized;

	private AppId_t _appId;

	private bool _disableSteam;

	private ulong _playerSteamID;

	public const uint demoAppId = 2160080u;

	public const uint gameAppId = 1730260u;

	private const uint appIdInternal = 1730260u;

	private Callback<PersonaStateChange_t> OnPersonalStateChangeCallResult;

	private Dictionary<ulong, Action<string>> _onNameRequestComplete;

	public AppId_t appId => default(AppId_t);

	public bool IsSteamInitialized => false;

	public override void Init()
	{
	}

	public void InitSteam()
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}

	public bool IsSteamEnabled()
	{
		return false;
	}

	public ulong GetPlayerSteamId()
	{
		return 0uL;
	}

	public void GetUsername(ulong id, Action<string> onComplete)
	{
	}

	public void OpenStorePage()
	{
	}

	public void OpenUserPage(CSteamID steamID)
	{
	}

	private void OnPersonaStateChangeResult(PersonaStateChange_t pCallback)
	{
	}
}
