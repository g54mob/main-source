using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/PanelSettingData", order = 1)]
public class PanelSettingData : ATowerComponentSettingData
{
	[SerializeField]
	[Header("底座的Prefab")]
	private GameObject prefab;

	[SerializeField]
	[Header("是否是變異扭曲的方塊 (一般狀況不會出現)")]
	private bool isTwisted;

	[SerializeField]
	[Header("方塊顏色")]
	private Color spriteColor;

	[SerializeField]
	[Header("方塊格子數量")]
	private int blockCount;

	public GameObject Prefab => null;

	public bool IsTwisted => false;

	private bool ValidateBlockCount(int value)
	{
		return false;
	}

	public GameObject GetPrefab()
	{
		return null;
	}

	public Color GetSpriteColor()
	{
		return default(Color);
	}

	public int GetBaseBlockCount()
	{
		return 0;
	}

	public bool IsBlockCount(int count)
	{
		return false;
	}

	public int GetSocketCount()
	{
		return 0;
	}

	public override string GetLocNameString(bool isPrefix = true)
	{
		return null;
	}
}
