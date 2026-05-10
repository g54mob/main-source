using UnityEngine;

[CreateAssetMenu(fileName = "Shoplifter Spawn Setting", menuName = "Customer/Shoplifter/Spawn Setting")]
public class ShoplifterSpawnSettingSO : ScriptableObject
{
	public Vector2Int PlayerLevelRange;

	public Vector2Int MinMaxCustomerSinceLastShoplifterRange;

	public float ShoplifterSpawnRate;
}
