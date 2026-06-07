using UnityEngine;

[CreateAssetMenu(fileName = "CannonSettingData_", menuName = "設定檔/CannonSettingData", order = 1)]
public class CannonSettingData : ATowerComponentSettingData
{
	[SerializeField]
	[Header("砲台的Prefab")]
	private GameObject cannonPrefab;

	[SerializeField]
	[Header("子彈Prefab")]
	private GameObject bulletPrefab;

	public GameObject GetCannonPrefab()
	{
		return null;
	}

	public GameObject GetBulletPrefab()
	{
		return null;
	}

	public float GetAttackRange(float multiplier = 1f)
	{
		return 0f;
	}

	public int GetDamage(float multiplier = 1f)
	{
		return 0;
	}

	public float GetShootInterval(float multiplier = 1f)
	{
		return 0f;
	}
}
