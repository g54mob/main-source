using System;

[Serializable]
public struct BuyingData
{
	public int FloorsToBuild;

	public int FloorsToDestroy;

	public int WallsToBuild;

	public int WallsToDestroy;

	public static BuyingData operator +(BuyingData a, BuyingData b)
	{
		return new BuyingData
		{
			FloorsToBuild = a.FloorsToBuild + b.FloorsToBuild,
			FloorsToDestroy = a.FloorsToDestroy + b.FloorsToDestroy,
			WallsToBuild = a.WallsToBuild + b.WallsToBuild,
			WallsToDestroy = a.WallsToDestroy + b.WallsToDestroy
		};
	}
}
