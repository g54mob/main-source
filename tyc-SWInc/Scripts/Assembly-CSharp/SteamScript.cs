using Steamworks;
using UnityEngine;

public class SteamScript : MonoBehaviour
{
	protected Callback<GameOverlayActivated_t> m_GameOverlayActivated;

	private void Start()
	{
		if (SteamManager.Initialized)
		{
			m_GameOverlayActivated = Callback<GameOverlayActivated_t>.Create(OnGameOverlayActivated);
		}
	}

	private void OnGameOverlayActivated(GameOverlayActivated_t pCallback)
	{
		if (pCallback.m_bActive != 0)
		{
			GameSettings.ForcePause = true;
			GameSettings.FreezeGame = true;
		}
		else
		{
			GameSettings.ForcePause = false;
		}
	}

	private void OnDestroy()
	{
		if (m_GameOverlayActivated != null)
		{
			m_GameOverlayActivated.Unregister();
		}
	}

	private void Update()
	{
	}
}
