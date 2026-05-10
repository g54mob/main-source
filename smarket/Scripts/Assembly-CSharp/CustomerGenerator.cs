using System.Collections.Generic;
using MyBox;
using UnityEngine;
using UnityEngine.Serialization;

public class CustomerGenerator : NoktaSingleton<CustomerGenerator>
{
	[SerializeField]
	private List<Customer> m_CustomerPrefabs;

	[Separator("Test", false)]
	[SerializeField]
	public Transform[] SpawningTransforms;

	[SerializeField]
	public Transform[] ShoplifterDespawnTransforms;

	[FormerlySerializedAs("TutorialShoplifterPrefab")]
	[SerializeField]
	private ShoplifterTutorialCustomer m_ShoplifterTutorialCustomerPrefab;

	[SerializeField]
	private Transform m_TutorialShoplifterSpawnTransform;

	public Customer Spawn(bool _isShoplifter = false)
	{
		return null;
	}

	public Customer Spawn(Vector3 position)
	{
		return null;
	}

	public void DeSpawn(Customer customer)
	{
	}

	public ShoplifterTutorialCustomer SpawnTutorialShoplifter()
	{
		return null;
	}
}
