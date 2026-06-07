using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/WallSettingData", order = 1)]
public class WallSettingData : AItemSettingData
{
	[SerializeField]
	[Header("牆壁的Prefab")]
	private GameObject wallPrefab;

	public GameObject GetPrefab()
	{
		return null;
	}
}
