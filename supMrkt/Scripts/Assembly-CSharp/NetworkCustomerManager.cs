using UnityEngine;

public class NetworkCustomerManager : NoktaSingletonPunCallbacks<NetworkCustomerManager>
{
	public Customer Spawn(string prefabName, Vector3 position, Quaternion rotation, bool _isShoplifter = false)
	{
		return null;
	}

	public void Despawn(Customer customer)
	{
	}
}
