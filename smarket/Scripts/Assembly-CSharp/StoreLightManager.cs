using System.Collections.Generic;
using Photon.Pun;

public class StoreLightManager : NoktaSingletonPunCallbacks<StoreLightManager>
{
	private List<InteriorSpotLight> m_InteriorLights;

	private List<OutdoorSpotLight> m_OutdoorLights;

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
	public void StoreLightSwitchTurnOn_RPC(bool value)
	{
	}

	public void AddOutdoorLight(OutdoorSpotLight light)
	{
	}

	public void RemoveOutdoorLight(OutdoorSpotLight light)
	{
	}

	public void AddLight(InteriorSpotLight light)
	{
	}

	public void RemoveLight(InteriorSpotLight light)
	{
	}
}
