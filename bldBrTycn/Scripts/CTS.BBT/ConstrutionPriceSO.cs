using UnityEngine;

[CreateAssetMenu(fileName = "ConstrutionPriceSO", menuName = "Construction/ConstrutionPriceSO")]
public class ConstrutionPriceSO : ScriptableObject
{
	[field: SerializeField]
	public int BuildFloorPrice { get; private set; }

	[field: SerializeField]
	public int BuildWallPrice { get; private set; }

	[field: SerializeField]
	public int DestroyFloorPrice { get; private set; }

	[field: SerializeField]
	public int DestroyWallPrice { get; private set; }

	[field: SerializeField]
	public int SuperficyPrestige { get; private set; } = 1;

	public BuyingData GetToBuyingData()
	{
		return new BuyingData
		{
			FloorsToBuild = BuildFloorPrice,
			WallsToBuild = BuildWallPrice,
			FloorsToDestroy = DestroyFloorPrice,
			WallsToDestroy = DestroyWallPrice
		};
	}
}
