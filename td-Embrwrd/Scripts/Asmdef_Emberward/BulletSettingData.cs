using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/BulletAssetData", order = 1)]
public class BulletSettingData : ScriptableObject
{
	[SerializeField]
	private int baseDamageMin;

	[SerializeField]
	private int baseDamageMax;

	public int GetDamage(float multiplier = 1f)
	{
		return 0;
	}
}
