using UnityEngine;

[CreateAssetMenu(fileName = "Order Spawn Setting", menuName = "Online Order/Spawn Setting")]
public class OrderSpawnSettingsSO : ScriptableObject
{
	public Vector2Int PlayerLevelRange;

	public Vector2Int OrderCountRange;

	public Vector2Int MinMaxProductTypeCount;

	public Vector2Int MinMaxQuantityPerProduct;

	public Vector2Int MinMaxExpireHours;

	public float DeliveryFeeMultiplierPercent;
}
