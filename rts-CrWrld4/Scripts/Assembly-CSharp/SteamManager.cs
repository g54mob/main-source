using System.Text;
using Steamworks;
using UnityEngine;

[DisallowMultipleComponent]
public class SteamManager : MonoBehaviour
{
	private static SteamManager s_instance;

	private static bool s_EverInialized;

	private bool m_bInitialized;

	private SteamAPIWarningMessageHook_t m_SteamAPIWarningMessageHook;

	protected Callback<GameRichPresenceJoinRequested_t> m_GameRichPresenceJoinRequested;

	private static SteamManager Instance => null;

	public static bool Initialized => false;

	private static void SteamAPIDebugTextHook(int nSeverity, StringBuilder pchDebugText)
	{
	}

	private void Awake()
	{
	}

	private void OnGameRichPresenceJoinRequested(GameRichPresenceJoinRequested_t pCallback)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}
}
