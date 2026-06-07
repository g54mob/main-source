using Mirror;

public class GameManager : NetworkBehaviour
{
	public static GameManager Instance;

	private void Awake()
	{
		Instance = this;
	}

	public void CheckAllReady()
	{
		if (!base.isServer)
		{
			return;
		}
		foreach (NetworkConnectionToClient value in NetworkServer.connections.Values)
		{
			if (!value.identity.GetComponent<PlayerReady>().isReady)
			{
				return;
			}
		}
		NetworkManager.singleton.ServerChangeScene("Game");
	}

	public override bool Weaved()
	{
		return true;
	}
}
