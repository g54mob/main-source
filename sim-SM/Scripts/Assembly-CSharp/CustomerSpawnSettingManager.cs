using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawnSettingManager : MonoBehaviour
{
	[SerializeField]
	private List<CustomerSpawnSettingSO> m_SpawnSettings;

	[SerializeField]
	private List<ShoplifterSpawnSettingSO> m_ShoplifterSpawnSettings;

	public List<CustomerSpawnSettingSO> SpawnSettings
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public float GetCustomerSpawningTime()
	{
		return 0f;
	}

	public ShoplifterSpawnSettingSO GetCurrentShoplifterSpawnSettings()
	{
		return null;
	}
}
