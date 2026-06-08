using System;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRoom : DungeonBoardItem
{
	private float roomScannerBrokenProbability = UnityEngine.Random.Range(0f, 0.3f);

	private float roomMotionBrokenProbability = 0.5f;

	private List<DungeonDoor> doors = new List<DungeonDoor>();

	public List<int> powerGrids = new List<int>();

	public DungeonBoardTerminal terminal;

	public DungeonBoardDefense defense;

	public DungeonBoardVent vent;

	public DungeonBoardPowerInlet powerInlet;

	public DungeonBoardFuelAccess fuelAccess;

	public List<DungeonBoardShipSubSystems> subSystemList = new List<DungeonBoardShipSubSystems>();

	public List<DungeonTile> usedTiles;

	public bool scannerBroken;

	public bool motionBroken;

	public bool safeRoom;

	private static int NextIndex;

	public int index;

	public DungeonDoor airlock { get; private set; }

	public DungeonRoom(Coordinate2D origin, Coordinate2D dimensions, System.Random rnd)
	{
		base.origin = origin;
		base.dimensions = dimensions;
		endpoints = new Coordinate2D(origin.x + dimensions.x - 1, origin.y + dimensions.y - 1);
		if (rnd == null)
		{
			if (UnityEngine.Random.Range(0f, 1f) < roomScannerBrokenProbability)
			{
				scannerBroken = true;
			}
			if (UnityEngine.Random.Range(0f, 1f) < roomMotionBrokenProbability)
			{
				motionBroken = true;
			}
		}
		else
		{
			if (rnd.NextFloat(0f, 1f) < roomScannerBrokenProbability)
			{
				scannerBroken = true;
			}
			if (rnd.NextFloat(0f, 1f) < roomMotionBrokenProbability)
			{
				motionBroken = true;
			}
		}
		index = NextIndex;
		NextIndex++;
	}

	public static void Clear()
	{
		NextIndex = 0;
	}

	public void AddDoor(DungeonDoor door)
	{
		doors.Add(door);
	}

	public void SetAirlock(DungeonDoor door)
	{
		airlock = door;
	}

	public bool HasAirlock()
	{
		return airlock != null;
	}

	public void AddPowerGrid(int gridIndex)
	{
		powerGrids.Add(gridIndex);
	}

	public void AddSubSystem(DungeonBoardShipSubSystems subSystem)
	{
		subSystemList.Add(subSystem);
	}

	public List<DungeonRoom> GetAdjacentRooms()
	{
		List<DungeonRoom> list = new List<DungeonRoom>();
		foreach (DungeonDoor door in doors)
		{
			DungeonRoom otherRoom = door.GetOtherRoom(this);
			if (otherRoom != null)
			{
				list.Add(otherRoom);
			}
		}
		return list;
	}
}
