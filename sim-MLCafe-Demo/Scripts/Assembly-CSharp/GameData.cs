using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
	public int id;

	public string version;

	public string cafeName;

	public int budget;

	public int level;

	public int gamemode;

	public GameTime gameTime;

	public GameDate gameDate;

	public int currentLvlXP;

	public ExperienceStat[] currentExperienceStats;

	public CustomerRating rating;

	public List<PlacedOrder> placedOrders = new List<PlacedOrder>();

	public List<int> wallUpgrades = new List<int>();

	public List<ProductListingElement> registeredProducts = new List<ProductListingElement>();

	public List<SaveableObjectData> registeredDynamicObjects = new List<SaveableObjectData>();

	public CafeRoomLayoutData cafeLayoutData;

	public List<WallPaintSaveData> wallPaintSaveData = new List<WallPaintSaveData>();

	public GameData()
	{
		id = Guid.NewGuid().GetHashCode();
	}
}
