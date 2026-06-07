using Mirror;

public class DisableAfterNetworkRegister : NetworkBehaviour
{
	public override void OnStartServer()
	{
		base.OnStartServer();
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
	}

	public override void OnStartAuthority()
	{
		base.OnStartAuthority();
	}

	public override bool Weaved()
	{
		return true;
	}
}
