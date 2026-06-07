using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemSO", menuName = "Scriptable Objects/ShopItemSO")]
public class ShopItemSO : ScriptableObject
{
	public string itemName;

	public Sprite sprite;

	public int xpToUnlock;

	public int price;

	public PlayerManager.ObjectInHand itemType;

	public int itemID;

	public float eol;

	public bool isCustomColor;
}
