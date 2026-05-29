using System.Collections.Generic;
using Photon.Pun;

public class StorageLightManager : NoktaSingletonPunCallbacks<StorageLightManager>
{
	private List<InteriorSpotLight> m_InteriorLights;

	private bool m_IsOn;

	public bool TurnOn
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	[PunRPC]
	public void StorageLightSwitchTurnOn_RPC(bool value)
	{
	}

	public void AddLight(InteriorSpotLight light)
	{
	}

	public void RemoveLight(InteriorSpotLight light)
	{
	}
}
