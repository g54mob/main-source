using System.Collections.Generic;
using UnityEngine;

public static class FurnitureDistances
{
	public class FurnitureDist
	{
		public float Distance;

		public int MaxRooms;

		public string Furniture;

		public FurnitureDist(float distance, int maxRooms, string furniture)
		{
			Distance = distance;
			MaxRooms = maxRooms;
			Furniture = furniture;
		}

		public FurnitureDist(float distance, int maxRooms)
		{
			Distance = distance;
			MaxRooms = maxRooms;
		}

		public FurnitureDist(int maxRooms)
		{
			Distance = 1024f;
			MaxRooms = maxRooms;
		}

		public FurnitureDist(float distance)
		{
			Distance = distance;
			MaxRooms = -1;
		}
	}

	public const float Tray = 75f;

	public const float TraySq = 5625f;

	public const float FastFood = 50f;

	public const float FastFoodSq = 2500f;

	public const float Toilet = 50f;

	public const float ToiletSq = 2500f;

	public const float Coffee = 30f;

	public const float CoffeeSq = 900f;

	public const int CoffeeDist = 3;

	public const float WaterCooler = 30f;

	public const float WaterCoolerSq = 900f;

	public const int WaterCoolerDist = 3;

	public const float Shower = 50f;

	public const float ShowerSq = 2500f;

	public const float Couch = 50f;

	public const float CouchSq = 2500f;

	public const int SinkDist = 1;

	public const int MiniFridge = 3;

	public static Dictionary<string, FurnitureDist> Distances = new Dictionary<string, FurnitureDist>
	{
		{
			"Toilet",
			new FurnitureDist(50f)
		},
		{
			"FastFood",
			new FurnitureDist(50f)
		},
		{
			"Coffee",
			new FurnitureDist(30f, 3)
		},
		{
			"Watercooler",
			new FurnitureDist(30f, 3)
		},
		{
			"Shower",
			new FurnitureDist(50f)
		},
		{
			"Tray",
			new FurnitureDist(75f)
		},
		{
			"Sink",
			new FurnitureDist(1)
		},
		{
			"Minifridge",
			new FurnitureDist(3)
		},
		{
			"Couch",
			new FurnitureDist(50f)
		},
		{
			"Trashcan",
			new FurnitureDist(Mathf.Sqrt(12.25f), 0, "Computer")
		}
	};
}
