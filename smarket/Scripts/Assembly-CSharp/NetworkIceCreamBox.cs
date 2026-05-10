using Photon.Pun;

public class NetworkIceCreamBox : MonoBehaviourPun
{
	private IceCreamBucketBox m_BucketBox;

	public bool IsInteractionRequested { get; set; }

	private void Awake()
	{
	}

	public void SetData_Broadcast(IceCreamFlavourData data)
	{
	}

	[PunRPC]
	private void SetData_RPC(IceCreamFlavourData data)
	{
	}

	public void ToggleBox_Broadcast(bool value)
	{
	}

	public void ToggleBox_Others(bool value)
	{
	}

	[PunRPC]
	private void ToggleBox_RPC(bool value)
	{
	}

	public void SetBucket_Others(int bucketViewId)
	{
	}

	[PunRPC]
	private void SetBucket_RPC(int bucketViewId)
	{
	}

	public void RequestBucketSpawn_Master()
	{
	}

	[PunRPC]
	private void RequestBucketSpawn_RPC(string userId)
	{
	}

	[PunRPC]
	private void BeginInteract_RPC()
	{
	}

	public void RequestInteract_Master(int boxViewId)
	{
	}

	[PunRPC]
	private void RequestInteract_RPC(int boxViewId, string userId)
	{
	}

	[PunRPC]
	private void InteractBoxAccept_RPC(int boxViewId)
	{
	}
}
