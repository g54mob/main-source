using Steamworks;
using UnityEngine;

public class SteamCore : MonoBehaviour
{
	public delegate void ScreenShownToggle(bool isOn);

	public static SteamCore Instance;

	public ScreenShownToggle overlayToggled;

	protected Callback<GameOverlayActivated_t> m_GameOverlayActivated;

	private void OnEnable()
	{
		if (SteamManager.Initialized)
		{
			m_GameOverlayActivated = Callback<GameOverlayActivated_t>.Create(OnGameOverActivated);
		}
	}

	private void Awake()
	{
		Instance = this;
	}

	private void OnGameOverActivated(GameOverlayActivated_t pCallback)
	{
		if (overlayToggled != null)
		{
			overlayToggled(pCallback.m_bActive != 0);
		}
	}
}
