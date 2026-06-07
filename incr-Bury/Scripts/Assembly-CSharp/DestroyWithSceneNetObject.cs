using Unity.Netcode;

public class DestroyWithSceneNetObject : NetworkBehaviour
{
	public override void OnNetworkSpawn()
	{
		GetComponent<NetworkObject>().DestroyWithScene = true;
	}

	protected override void __initializeVariables()
	{
		base.__initializeVariables();
	}

	protected override void __initializeRpcs()
	{
		base.__initializeRpcs();
	}

	protected internal override string __getTypeName()
	{
		return "DestroyWithSceneNetObject";
	}
}
