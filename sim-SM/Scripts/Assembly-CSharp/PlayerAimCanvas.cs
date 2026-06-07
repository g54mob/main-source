using UnityEngine;

public class PlayerAimCanvas : NoktaSingleton<PlayerAimCanvas>
{
	[SerializeField]
	private GameObject m_AimIndicator;

	public bool EnableAimIndicator
	{
		set
		{
		}
	}

	private void Start()
	{
	}

	private void OnControllerEnabled(bool value, bool cameraIncluded, bool _)
	{
	}

	public void OnLocalPlayerUpdated(PlayerInstance playerInstance)
	{
	}
}
