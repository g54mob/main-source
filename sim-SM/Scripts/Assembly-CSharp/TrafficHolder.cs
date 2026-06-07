using System.Collections.Generic;
using Photon.Pun;

public class TrafficHolder : NoktaSingletonPunCallbacks<TrafficHolder>, IPunInstantiateMagicCallback
{
	private List<int> m_vehicles;

	private void Start()
	{
	}

	public override void OnDisable()
	{
	}

	private void SyncVehicles(string invokerUserID)
	{
	}

	[PunRPC]
	public void SyncVehicleState(int[] closedCars)
	{
	}

	public void OnPhotonInstantiate(PhotonMessageInfo info)
	{
	}
}
