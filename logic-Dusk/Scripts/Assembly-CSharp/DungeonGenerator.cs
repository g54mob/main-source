using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class DungeonGenerator
{
	public static int SeedDungeonBaseProperties = -1;

	public static int SeedPowerInlet = -1;

	public static int SeedFuelInlet = -1;

	public static int SeedTerminalInlet = -1;

	public static int SeedVent = -1;

	public static int SeedSubSystem = -1;

	public static int SeedDefense = -1;

	public static int SeedAirlocks = -1;

	public static int SeedDoors = -1;

	private static DungeonGenerator instance;

	public DungeonTile[,] tiles;

	private UnityEngine.Random randWidth;

	private UnityEngine.Random randHeight;

	private UnityEngine.Random rand;

	private System.Random sysRand = new System.Random();

	public DungeonBoard dungeonBoard;

	public int minRoomsPerVent = 7;

	private List<DungeonDoor> doorsWithAirlocks = new List<DungeonDoor>();

	private DungeonRoom firstRoom;

	private int roomBorderSize = 2;

	private int doorWidth = 2;

	private bool verbose;

	private GameEditorScript editorScript;

	private bool animate;

	private int[] minSizes = new int[4] { 1, 2, 4, 5 };

	private int minSizeIndex;

	private int minRoomDimension = 2;

	private int minFitSize = 6;

	private int numPowerGrids = 4;

	private int numTerminals;

	private int numVents;

	private int MinSize
	{
		get
		{
			return minSizes[minSizeIndex];
		}
	}

	private bool Animate
	{
		get
		{
			return animate && editorScript != null;
		}
	}

	private int Width { get; set; }

	private int Height { get; set; }

	public static DungeonGenerator GetInstance()
	{
		if (instance == null)
		{
			instance = new DungeonGenerator();
		}
		return instance;
	}

	public void setGameEditor(GameEditorScript editor)
	{
		editorScript = editor;
	}

	private void clearBoard()
	{
		DungeonTile[,] array = tiles;
		int length = array.GetLength(0);
		int length2 = array.GetLength(1);
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				DungeonTile dungeonTile = array[i, j];
				dungeonTile.clear();
			}
		}
		dungeonBoard.Clear();
	}

	private void MinSizeIncrement()
	{
		if (minSizeIndex + 1 < minSizes.Length)
		{
			minSizeIndex++;
		}
	}

	private IEnumerator DoSomethingInAWhile(float seconds)
	{
		yield return new WaitForSeconds(seconds);
	}

	public void InitializeDungeon(int width, int height)
	{
		Width = width;
		Height = height;
		tiles = new DungeonTile[Width, Height];
		for (int i = 0; i < Width; i++)
		{
			for (int j = 0; j < Height; j++)
			{
				tiles[i, j] = new DungeonTile(i, j);
			}
		}
		dungeonBoard = new DungeonBoard();
		clearBoard();
	}

	public void GenerateDungeon(DungeonTypeEnum dungeonType, int width, int height, string dungeonDefName)
	{
		int seed = UnityEngine.Random.seed;
		System.Random random = null;
		if (GlobalSettings.gameMode != GameModeEnum.Normal)
		{
			int seed2 = (int)DateTime.Now.Ticks;
			if (SeedDungeonBaseProperties != -1)
			{
				seed2 = SeedDungeonBaseProperties;
			}
			random = new System.Random(seed2);
		}
		InitializeDungeon(width, height);
		if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.propertyHeader != null)
		{
			GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.propertyHeader.propertyCommon;
			if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.propertyHeader.propertyRare != null && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.propertyHeader.chanceRare > 0f)
			{
				if (GlobalSettings.gameMode == GameModeEnum.Normal)
				{
					if ((float)UnityEngine.Random.Range(0, 100) <= GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.propertyHeader.chanceRare)
					{
						GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.propertyHeader.propertyRare;
					}
				}
				else if ((float)random.Next(0, 100) <= GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.propertyHeader.chanceRare)
				{
					GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.propertyHeader.propertyRare;
				}
			}
		}
		else
		{
			GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty = new DungeonConfigurationManager.DungeonHelper.DungeonProperty();
		}
		int num = 0;
		for (int i = 0; i < Width; i++)
		{
			for (int j = 0; j < Height; j++)
			{
				int num2 = 0;
				int num3 = 0;
				if (Animate)
				{
					BoardTileType type = tiles[i, j].type;
					tiles[i, j].type = BoardTileType.Cursor;
					editorScript.DungeonBoardToEditorBoard();
					Thread.Sleep(100);
					tiles[i, j].type = type;
				}
				if (tiles[i, j].type != BoardTileType.Undefined)
				{
					continue;
				}
				if (verbose)
				{
					Debug.Log("Room start" + i + ":" + j);
				}
				int num4 = 0;
				while (num2 * num3 < 4 || num2 * num3 > 100)
				{
					int num5 = i;
					bool flag = false;
					while (!flag && num5 < Width)
					{
						if (tiles[num5, j].type != BoardTileType.Undefined)
						{
							flag = true;
							if (verbose)
							{
								Debug.Log(num5 + ":" + j + " is taken");
							}
						}
						else
						{
							num5++;
						}
					}
					int num6 = j;
					flag = false;
					while (!flag && num6 < Height)
					{
						if (tiles[i, num6].type != BoardTileType.Undefined)
						{
							flag = true;
							if (verbose)
							{
								Debug.Log(num6 + ":" + j + " is taken");
							}
						}
						else
						{
							num6++;
						}
					}
					int num7 = num5 - i;
					int num8 = num6 - j;
					num2 = ((num7 < minFitSize) ? num7 : ((random != null) ? random.Next(minRoomDimension, num7) : UnityEngine.Random.Range(minRoomDimension, num7)));
					num3 = ((num8 < minFitSize) ? num8 : ((random != null) ? random.Next(minRoomDimension, num8) : UnityEngine.Random.Range(minRoomDimension, num8)));
					if (num7 - num2 < minFitSize)
					{
						num2 = num7;
					}
					if (num8 - num3 < minFitSize)
					{
						num3 = num8;
					}
					if (num4 > 100)
					{
						Debug.Log("Error: area break, couldn't make legal room");
						return;
					}
					num4++;
				}
				if (verbose)
				{
					Debug.Log("Room size" + num2 + ":" + num3);
				}
				DungeonRoom dungeonRoom = new DungeonRoom(new Coordinate2D(i, j), new Coordinate2D(num2, num3), random);
				dungeonBoard.rooms.Add(dungeonRoom);
				for (int k = i - roomBorderSize; k < i + num2 + roomBorderSize; k++)
				{
					for (int l = j - roomBorderSize; l < j + num3 + roomBorderSize; l++)
					{
						if (k < i + num2 && l < j + num3 && k >= i && l >= j)
						{
							tiles[k, l].type = BoardTileType.Room;
							tiles[k, l].boardItem = dungeonRoom;
							if (k == i + num2 - 1 || l == j + num3 - 1 || k == i || l == j)
							{
								tiles[k, l].roomSpaceType = RoomSpaceType.Wall;
								tiles[k, l].empty = true;
								if (k == i + num2 - 1)
								{
									tiles[k, l].wallSpaceType.Add(WallSpaceTileType.Right);
								}
								if (k == i)
								{
									tiles[k, l].wallSpaceType.Add(WallSpaceTileType.Left);
								}
								if (l == j + num3 - 1)
								{
									tiles[k, l].wallSpaceType.Add(WallSpaceTileType.Top);
								}
								if (l == j)
								{
									tiles[k, l].wallSpaceType.Add(WallSpaceTileType.Bottom);
								}
							}
							else
							{
								tiles[k, l].roomSpaceType = RoomSpaceType.Interior;
								tiles[k, l].empty = true;
							}
						}
						else if (k < Width && l < Height && k >= 0 && l >= 0)
						{
							tiles[k, l].type = BoardTileType.DeadSpace;
						}
					}
				}
				num++;
				if (num > 40)
				{
					GenerateDoors(true);
					GenerateDoors(false);
					return;
				}
			}
		}
		int count = dungeonBoard.rooms.Count;
		int num9 = dungeonBoard.rooms.Count / 2;
		int num10 = 0;
		List<int> list = new List<int>();
		for (int m = 0; m < count; m++)
		{
			if (dungeonBoard.rooms[m].motionBroken)
			{
				num10++;
				list.Add(m);
			}
		}
		if (num10 > num9)
		{
			int num11 = num10 - num9;
			if (num11 >= list.Count)
			{
				num11 = list.Count;
			}
			for (int n = 0; n < num11; n++)
			{
				int num12 = -1;
				num12 = ((random != null) ? random.Next(minRoomDimension, list.Count) : UnityEngine.Random.Range(minRoomDimension, list.Count));
				dungeonBoard.rooms[list[num12]].motionBroken = false;
				list.RemoveAt(num12);
			}
		}
		ChooseFirstRoom(random);
		GenerateDoors(true);
		GenerateDoors(false);
		GenerateAirlocks(dungeonType);
		GenerateDoorways();
		int seed3 = (int)DateTime.Now.Ticks;
		if (SeedPowerInlet != -1)
		{
			seed3 = SeedPowerInlet;
		}
		System.Random random2 = new System.Random(seed3);
		if (GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty != null && GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasPowerGrid)
		{
			numPowerGrids = random2.Next(GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.powerGridMin, GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.powerGridMax + 1);
		}
		GeneratePowerInlets(random2);
		GenerateFuelAccesses();
		if (dungeonType == DungeonTypeEnum.Derelict || dungeonType == DungeonTypeEnum.Station)
		{
			GenerateShipSubSystems();
		}
		if (GlobalSettings.gameMode == GameModeEnum.Normal)
		{
			if (GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty != null && GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasTerminal)
			{
				numTerminals = UnityEngine.Random.Range((int)((float)dungeonBoard.rooms.Count() * GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.terminalRatioMin), (int)((float)dungeonBoard.rooms.Count() * GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.terminalRatioMax));
			}
			else
			{
				numTerminals = UnityEngine.Random.Range(0, (int)((float)dungeonBoard.rooms.Count() * 0.33f));
			}
			if (numTerminals == 0 && dungeonDefName.ToLower() == "research")
			{
				numTerminals = 1;
			}
			GenerateTerminals(numTerminals);
		}
		else
		{
			int seed4 = (int)DateTime.Now.Ticks;
			if (SeedTerminalInlet != -1)
			{
				seed4 = SeedTerminalInlet;
			}
			System.Random random3 = new System.Random(seed4);
			if (GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty != null && GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasTerminal)
			{
				numTerminals = random3.Next((int)((float)dungeonBoard.rooms.Count() * GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.terminalRatioMin), (int)((float)dungeonBoard.rooms.Count() * GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.terminalRatioMax));
			}
			else
			{
				numTerminals = random3.Next(0, (int)((float)dungeonBoard.rooms.Count() * 0.33f));
			}
			if (numTerminals == 0 && dungeonDefName.ToLower() == "research")
			{
				numTerminals = 1;
			}
			GenerateTerminals(numTerminals, random3);
		}
		int num13 = Mathf.CeilToInt((float)num / (float)minRoomsPerVent);
		if (GlobalSettings.GameState.ThePlayer != null && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon != null)
		{
			num13 = Mathf.RoundToInt((float)num13 * GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.CalculatedDifficultyValues.VentValue);
		}
		if (GlobalSettings.gameMode == GameModeEnum.Normal)
		{
			GenerateVents(UnityEngine.Random.Range(1, num13 + 1), null);
		}
		else
		{
			int seed5 = (int)DateTime.Now.Ticks;
			if (SeedVent != -1)
			{
				seed5 = SeedVent;
			}
			System.Random random4 = new System.Random(seed5);
			GenerateVents(random4.Next(1, num13 + 1), random4);
		}
		float terminalProbability = 0.5f;
		if (GlobalSettings.gameMode == GameModeEnum.Normal)
		{
			if (GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty != null && GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasDefense)
			{
				terminalProbability = UnityEngine.Random.Range(GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.defenseRatioMin, GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.defenseRatioMax);
			}
			GenerateDefense(terminalProbability, 0.9f);
			return;
		}
		int seed6 = (int)DateTime.Now.Ticks;
		if (SeedDefense != -1)
		{
			seed6 = SeedDefense;
		}
		System.Random random5 = new System.Random(seed6);
		if (GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty != null && GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasDefense)
		{
			terminalProbability = random5.NextFloat(GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.defenseRatioMin, GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.defenseRatioMax);
		}
		GenerateDefense(terminalProbability, 0.9f, random5);
	}

	public void SetRoomTiles(DungeonRoom[] tileArray)
	{
		dungeonBoard.rooms.AddRange(tileArray);
	}

	public void SetDoorTiles(DungeonDoor[] tileArray)
	{
		dungeonBoard.doors.AddRange(tileArray);
	}

	private void ChooseFirstRoom(System.Random rnd)
	{
		firstRoom = null;
		int num = 0;
		int num2 = -1;
		int num3 = -1;
		int num4 = -1;
		int num5 = 2;
		int num6 = 2;
		do
		{
			int num8;
			int num7;
			switch ((rnd != null) ? rnd.Next(0, 4) : UnityEngine.Random.Range(0, 4))
			{
			case 0:
				num8 = 0;
				goto IL_0064;
			case 2:
				num8 = Width - 1;
				goto IL_0064;
			case 1:
				num7 = 0;
				goto IL_0138;
			case 3:
				{
					num7 = Height - 1;
					goto IL_0138;
				}
				IL_0138:
				num4 = num7;
				num3 = ((rnd != null) ? rnd.Next(0, Width) : UnityEngine.Random.Range(0, Width));
				if (tiles[num3, num4].type == BoardTileType.Room && tiles[num3, num4].roomSpaceType == RoomSpaceType.Wall && tiles[num3, num4].boardItem.dimensions.x >= num5 && tiles[num3, num4].boardItem.dimensions.y >= num6)
				{
					firstRoom = (DungeonRoom)tiles[num3, num4].boardItem;
				}
				break;
				IL_0064:
				num3 = num8;
				num4 = ((rnd != null) ? rnd.Next(0, Height) : UnityEngine.Random.Range(0, Height));
				if (tiles[num3, num4].type == BoardTileType.Room && tiles[num3, num4].roomSpaceType == RoomSpaceType.Wall && tiles[num3, num4].boardItem.dimensions.x >= num5 && tiles[num3, num4].boardItem.dimensions.y >= num6)
				{
					firstRoom = (DungeonRoom)tiles[num3, num4].boardItem;
				}
				break;
			}
			num++;
		}
		while (num < 1000 && firstRoom == null);
		if (firstRoom != null)
		{
			firstRoom.safeRoom = true;
		}
	}

	public void GenerateDoors(bool vertical)
	{
		System.Random random = null;
		if (GlobalSettings.gameMode != GameModeEnum.Normal)
		{
			int seed = (int)DateTime.Now.Ticks;
			if (SeedDoors != -1)
			{
				seed = SeedDoors;
			}
			random = new System.Random(seed);
		}
		if (verbose)
		{
			Debug.Log("Data says # of rooms is " + dungeonBoard.rooms.Count);
		}
		List<List<Coordinate2D>> list = new List<List<Coordinate2D>>();
		List<Coordinate2D> list2 = null;
		foreach (DungeonRoom room in dungeonBoard.rooms)
		{
			int num;
			int num2;
			int num3;
			int num4;
			if (vertical)
			{
				num = room.origin.x;
				num2 = room.endpoints.x;
				num3 = room.endpoints.y;
				num4 = Height;
			}
			else
			{
				num = room.origin.y;
				num2 = room.endpoints.y;
				num3 = room.endpoints.x;
				num4 = Width;
			}
			if (list2 != null)
			{
				list2.Clear();
			}
			list.Clear();
			bool flag = true;
			for (int i = num; i <= num2; i++)
			{
				if (num3 + roomBorderSize + 1 >= num4)
				{
					continue;
				}
				Coordinate2D coordinate2D = ((!vertical) ? new Coordinate2D(num3 + roomBorderSize + 1, i) : new Coordinate2D(i, num3 + roomBorderSize + 1));
				DungeonTile dungeonTile = tiles[coordinate2D.x, coordinate2D.y];
				if (dungeonTile.type == BoardTileType.Room)
				{
					if (flag)
					{
						list2 = new List<Coordinate2D>();
						list.Add(list2);
						flag = false;
					}
					list2.Add(coordinate2D);
				}
				else
				{
					flag = true;
				}
			}
			foreach (List<Coordinate2D> item in list)
			{
				if (item.Count < doorWidth)
				{
					continue;
				}
				int num5 = 0;
				num5 = ((random != null) ? random.Next(0, item.Count - (doorWidth - 1)) : UnityEngine.Random.Range(0, item.Count - (doorWidth - 1)));
				int num6;
				int num7;
				if (vertical)
				{
					num6 = item[num5].x;
					num7 = item[num5].y - 1;
				}
				else
				{
					num6 = item[num5].y;
					num7 = item[num5].x - 1;
				}
				Coordinate2D coordinate2D2 = new Coordinate2D();
				for (int j = num6; j < num6 + doorWidth; j++)
				{
					for (int num8 = num7; num8 > num7 - roomBorderSize; num8--)
					{
						Coordinate2D coordinate2D = ((!vertical) ? new Coordinate2D(num8, j) : new Coordinate2D(j, num8));
						tiles[coordinate2D.x, coordinate2D.y].type = BoardTileType.Door;
						if (j == num6 && num8 == num7)
						{
							coordinate2D2 = coordinate2D;
						}
						else if (coordinate2D.x < coordinate2D2.x || coordinate2D.y < coordinate2D2.y)
						{
							coordinate2D2 = coordinate2D;
						}
					}
				}
				DungeonDoor dungeonDoor = new DungeonDoor(coordinate2D2, vertical);
				dungeonDoor.AddRoom(room);
				dungeonDoor.AddRoom((DungeonRoom)tiles[item[0].x, item[0].y].boardItem);
				dungeonBoard.doors.Add(dungeonDoor);
			}
		}
	}

	public void GeneratePowerInlets(System.Random rnd)
	{
		List<int> list = new List<int>();
		List<List<DungeonRoom>> list2 = new List<List<DungeonRoom>>();
		for (int i = 0; i < dungeonBoard.rooms.Count; i++)
		{
			list.Add(i);
		}
		for (int j = 0; j < numPowerGrids; j++)
		{
			int index = rnd.Next(0, list.Count - 1);
			List<DungeonRoom> list3 = new List<DungeonRoom>();
			list3.Add(dungeonBoard.rooms[list[index]]);
			dungeonBoard.rooms[list[index]].AddPowerGrid(j);
			list2.Add(list3);
			list.RemoveAt(index);
		}
		bool flag = false;
		int num = 0;
		while (!flag)
		{
			foreach (List<DungeonRoom> item in list2)
			{
				List<DungeonRoom> list4 = new List<DungeonRoom>();
				foreach (DungeonRoom item2 in item)
				{
					List<DungeonRoom> adjacentRooms = item2.GetAdjacentRooms();
					foreach (DungeonRoom item3 in adjacentRooms)
					{
						if (item3.powerGrids.Count == 0)
						{
							list4.Add(item3);
						}
					}
				}
				if (list4.Count > 0)
				{
					int index2 = rnd.Next(0, list4.Count - 1);
					list4[index2].AddPowerGrid(item[0].powerGrids[0]);
					item.Add(list4[index2]);
				}
			}
			flag = true;
			foreach (DungeonRoom room in dungeonBoard.rooms)
			{
				if (room.powerGrids.Count == 0)
				{
					flag = false;
				}
			}
			if (num > 100)
			{
				flag = true;
				Debug.Log("Saftey Break");
			}
			num++;
		}
		int num2 = 2;
		foreach (List<DungeonRoom> item4 in list2)
		{
			if (item4.Count >= num2 || item4.Count <= 0)
			{
				continue;
			}
			int num3 = item4[0].powerGrids[0];
			for (int num4 = item4.Count - 1; num4 >= 0; num4--)
			{
				List<DungeonRoom> adjacentRooms2 = item4[num4].GetAdjacentRooms();
				List<DungeonRoom> list5 = null;
				list5 = ((GlobalSettings.gameMode != GameModeEnum.Normal) ? adjacentRooms2.OrderBy((DungeonRoom x) => rnd.Next()).ToList() : adjacentRooms2.OrderBy((DungeonRoom x) => sysRand.Next()).ToList());
				bool flag2 = false;
				int num5 = 0;
				while (!flag2 && num5 < list5.Count)
				{
					if (list5[num5].powerGrids[0] != num3)
					{
						int num6 = list5[num5].powerGrids[0];
						item4[num4].powerGrids[0] = num6;
						list2[num6].Add(item4[num4]);
						item4.RemoveAt(num4);
						flag2 = true;
					}
					num5++;
				}
				if (!flag2)
				{
					Debug.Log("something is wrong with the power grids");
				}
			}
		}
		List<int> list6 = new List<int>();
		List<int> list7 = new List<int>();
		List<int> list8 = new List<int>();
		for (int num7 = 0; num7 < list2.Count; num7++)
		{
			if (list2[num7].Count > 0)
			{
				list6.Add(num7);
			}
		}
		bool flag3 = false;
		if ((GlobalSettings.gameMode != GameModeEnum.Normal) ? (PlaceInRoom(firstRoom, BoardTileRoomItemType.PowerInlet, false, rnd) == null) : (PlaceInRoom(firstRoom, BoardTileRoomItemType.PowerInlet, false) == null))
		{
			firstRoom.powerInlet = new DungeonBoardPowerInlet(firstRoom.origin);
		}
		list6.Remove(firstRoom.powerGrids[0]);
		list7.Add(firstRoom.powerGrids[0]);
		bool flag4 = false;
		num = 0;
		while (list6.Count > 0)
		{
			List<int> list9 = null;
			list9 = ((GlobalSettings.gameMode != GameModeEnum.Normal) ? list6.OrderBy((int x) => rnd.Next()).ToList() : list6.OrderBy((int x) => sysRand.Next()).ToList());
			flag4 = false;
			foreach (int item5 in list9)
			{
				foreach (DungeonRoom item6 in list2[item5])
				{
					foreach (DungeonRoom adjacentRoom in item6.GetAdjacentRooms())
					{
						bool flag5 = false;
						foreach (int powerGrid in adjacentRoom.powerGrids)
						{
							if (list7.Contains(powerGrid))
							{
								flag5 = true;
							}
						}
						if (!flag5)
						{
							continue;
						}
						list8.Add(item5);
						list7.Add(item5);
						flag4 = true;
						flag3 = false;
						if ((GlobalSettings.gameMode != GameModeEnum.Normal) ? (PlaceInRoom(item6, BoardTileRoomItemType.PowerInlet, false, rnd) == null) : (PlaceInRoom(item6, BoardTileRoomItemType.PowerInlet, false) == null))
						{
							item6.powerInlet = new DungeonBoardPowerInlet(item6.origin);
							if (item6.dimensions.x >= 2 && item6.dimensions.y >= 2)
							{
								tiles[item6.origin.x, item6.origin.y].empty = false;
								tiles[item6.origin.x + 1, item6.origin.y].empty = false;
								tiles[item6.origin.x, item6.origin.y + 1].empty = false;
								tiles[item6.origin.x + 1, item6.origin.y + 1].empty = false;
							}
						}
						break;
					}
					if (flag4)
					{
						break;
					}
				}
			}
			foreach (int item7 in list8)
			{
				list6.Remove(item7);
			}
			list8.Clear();
			if (num > 100)
			{
				Debug.Log("Saftey break: searching for power inlets");
				break;
			}
			num++;
		}
	}

	private void GenerateFuelAccesses()
	{
		int seed = (int)DateTime.Now.Ticks;
		if (SeedFuelInlet != -1)
		{
			seed = SeedFuelInlet;
		}
		System.Random random = new System.Random(seed);
		int num = 1;
		if (GlobalSettings.gameMode == GameModeEnum.Normal)
		{
			if (GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty != null && GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasFuelAccess)
			{
				num = UnityEngine.Random.Range(GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.fuelAccessMin, GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.fuelAccessMax);
			}
		}
		else if (GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty != null && GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasFuelAccess)
		{
			num = random.Next(GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.fuelAccessMin, GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.fuelAccessMax);
		}
		if (num > dungeonBoard.rooms.Count)
		{
			num = dungeonBoard.rooms.Count;
		}
		for (int i = 0; i < num; i++)
		{
			int num2 = 0;
			int num3 = 0;
			int num4 = dungeonBoard.rooms.Count * 3;
			Coordinate2D coordinate2D = null;
			while (true)
			{
				num2 = ((GlobalSettings.gameMode != GameModeEnum.Normal) ? random.Next(0, dungeonBoard.rooms.Count) : UnityEngine.Random.Range(0, dungeonBoard.rooms.Count));
				if (dungeonBoard.rooms[num2].fuelAccess == null)
				{
					coordinate2D = ((GlobalSettings.gameMode != GameModeEnum.Normal) ? PlaceInRoom(dungeonBoard.rooms[num2], BoardTileRoomItemType.FuelAccess, false, random) : PlaceInRoom(dungeonBoard.rooms[num2], BoardTileRoomItemType.FuelAccess, false));
					num3++;
					if (coordinate2D != null || num3 >= num4)
					{
						break;
					}
				}
			}
			if (coordinate2D == null)
			{
				Debug.LogWarning("Couldn't place Fuel Access");
			}
		}
	}

	private void GenerateDoorways()
	{
		Coordinate2D[] array = new Coordinate2D[6]
		{
			new Coordinate2D(1, 0),
			new Coordinate2D(-1, 0),
			new Coordinate2D(0, 1),
			new Coordinate2D(0, -1),
			new Coordinate2D(0, 0),
			new Coordinate2D(0, 0)
		};
		for (int i = 0; i < Width; i++)
		{
			for (int j = 0; j < Height; j++)
			{
				if (tiles[i, j].type != BoardTileType.Door && tiles[i, j].type != BoardTileType.Airlock)
				{
					continue;
				}
				Coordinate2D coordinate2D = new Coordinate2D(i, j);
				Coordinate2D[] array2 = array;
				foreach (Coordinate2D coordinate2D2 in array2)
				{
					Coordinate2D coordinate2D3 = coordinate2D + coordinate2D2;
					if (coordinate2D3.x >= 0 && coordinate2D3.x < Width && coordinate2D3.y >= 0 && coordinate2D3.y < Height)
					{
						DungeonTile dungeonTile = tiles[coordinate2D3.x, coordinate2D3.y];
						if (dungeonTile.type == BoardTileType.Room)
						{
							dungeonTile.roomItemType = BoardTileRoomItemType.Doorway;
							dungeonTile.empty = false;
						}
					}
				}
			}
		}
	}

	private void GenerateTerminals(int numTerminals)
	{
		GenerateTerminals(numTerminals, sysRand);
	}

	private void GenerateTerminals(int numTerminals, System.Random rnd)
	{
		if (numTerminals <= 0)
		{
			return;
		}
		List<DungeonRoom> list = dungeonBoard.rooms.OrderBy((DungeonRoom x) => rnd.Next()).ToList();
		bool flag = false;
		bool flag2 = false;
		int num = 0;
		foreach (DungeonRoom item in list)
		{
			List<DungeonTile> shuffledRoomTiles = GetShuffledRoomTiles(item, rnd);
			flag = false;
			foreach (DungeonTile item2 in shuffledRoomTiles)
			{
				if (item2.roomSpaceType == RoomSpaceType.Wall && item2.empty)
				{
					foreach (DungeonTile adjacentTile in GetAdjacentTiles(item2))
					{
						flag2 = false;
						foreach (WallSpaceTileType item3 in item2.wallSpaceType)
						{
							if (adjacentTile.wallSpaceType.Contains(item3))
							{
								flag2 = true;
							}
						}
						if (adjacentTile.roomSpaceType == RoomSpaceType.Wall && adjacentTile.empty && flag2)
						{
							item2.roomItemType = BoardTileRoomItemType.Terminal;
							item2.empty = false;
							adjacentTile.roomItemType = BoardTileRoomItemType.Terminal;
							adjacentTile.empty = false;
							flag = true;
							if (item2.position.x < adjacentTile.position.x || item2.position.y < adjacentTile.position.y)
							{
								item.terminal = new DungeonBoardTerminal(item2.position, item2.position.y == adjacentTile.position.y);
							}
							else
							{
								item.terminal = new DungeonBoardTerminal(adjacentTile.position, item2.position.y == adjacentTile.position.y);
							}
							num++;
							if (num >= numTerminals)
							{
								return;
							}
						}
						if (flag)
						{
							break;
						}
					}
				}
				if (flag)
				{
					break;
				}
			}
		}
	}

	private void GenerateDefense(float terminalProbability, float sameGridProbability)
	{
		GenerateDefense(terminalProbability, sameGridProbability, sysRand);
	}

	private void GenerateDefense(float terminalProbability, float sameGridProbability, System.Random rnd)
	{
		foreach (DungeonRoom room in dungeonBoard.rooms)
		{
			if (room.terminal == null || !(terminalProbability > rnd.NextFloat(0f, 1f)))
			{
				continue;
			}
			room.terminal.type = DungeonTerminalType.defense;
			bool flag = sameGridProbability > rnd.NextFloat(0f, 1f);
			List<DungeonRoom> list = dungeonBoard.rooms.OrderBy((DungeonRoom x) => rnd.Next()).ToList();
			foreach (DungeonRoom item in list)
			{
				if ((flag && !item.powerGrids.Contains(room.powerGrids[0])) || item.defense != null || item == room || item.powerInlet != null || item.terminal != null)
				{
					int num = 0;
					num++;
				}
				else if (PlaceInRoom(item, BoardTileRoomItemType.Defense, true, rnd) != null)
				{
					room.terminal.defense = item.defense;
					break;
				}
			}
		}
	}

	public void GenerateAirlocks(DungeonTypeEnum dungeonType)
	{
		System.Random random = null;
		if (GlobalSettings.gameMode != GameModeEnum.Normal)
		{
			int seed = (int)DateTime.Now.Ticks;
			if (SeedAirlocks != -1)
			{
				seed = SeedAirlocks;
			}
			random = new System.Random(seed);
		}
		int num = int.MaxValue;
		int num2 = int.MinValue;
		int num3 = int.MaxValue;
		int num4 = int.MinValue;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		for (int i = 0; i < Width; i++)
		{
			for (int j = 0; j < Height; j++)
			{
				DungeonTile dungeonTile = tiles[i, j];
				if (dungeonTile.type == BoardTileType.Room && dungeonTile.boardItem == firstRoom)
				{
					if (i < num)
					{
						num = i;
					}
					if (i > num2)
					{
						num2 = i;
					}
					if (j < num3)
					{
						num3 = j;
					}
					if (j > num4)
					{
						num4 = j;
					}
				}
			}
		}
		if (num == 0)
		{
			flag = true;
		}
		if (num2 == Width - 1)
		{
			flag3 = true;
		}
		if (num3 == 0)
		{
			flag2 = true;
		}
		if (num4 == Height - 1)
		{
			flag4 = true;
		}
		for (int k = 0; k < 2; k++)
		{
			if (k == 0 && dungeonType == DungeonTypeEnum.Outpost)
			{
				continue;
			}
			int num5 = 0;
			num5 = ((random == null) ? ((GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty == null || !GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasAirlock) ? ((k == 0) ? 1 : UnityEngine.Random.Range(0, 5)) : ((k == 0) ? 1 : UnityEngine.Random.Range(GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.airlockMin, GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.airlockMax + 1))) : ((GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty == null || !GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasAirlock) ? ((k == 0) ? 1 : random.Next(0, 5)) : ((k == 0) ? 1 : random.Next(GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.airlockMin, GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.airlockMax + 1))));
			for (int l = 0; l < num5; l++)
			{
				bool flag5 = false;
				bool flag6 = false;
				int num6 = 0;
				int num7 = 0;
				List<Coordinate2D> list = new List<Coordinate2D>();
				while (!flag5 && num6 < 1000)
				{
					list.Clear();
					flag6 = false;
					num7 = ((random != null) ? random.Next(0, 4) : UnityEngine.Random.Range(0, 4));
					int num8 = 0;
					int num9 = 0;
					int num10 = 0;
					int num11 = 0;
					int num12 = Width;
					int num13 = Height;
					if (k == 0)
					{
						if (num7 == 0 && !flag)
						{
							num7 = ((!flag3) ? (-1) : 2);
						}
						else if (num7 == 2 && !flag3)
						{
							num7 = ((!flag) ? (-1) : 0);
						}
						else if (num7 == 1 && !flag2)
						{
							num7 = ((!flag4) ? (-1) : 3);
						}
						else if (num7 == 3 && !flag4)
						{
							num7 = (flag2 ? 1 : (-1));
						}
						num10 = num;
						num11 = num4;
						num12 = num2 - num;
						num13 = num4 - num3;
					}
					if (num7 != -1)
					{
						if (num7 == 0 || num7 == 2)
						{
							num8 = ((num7 != 0) ? (Width - 1) : 0);
							if (random == null)
							{
								num9 = UnityEngine.Random.Range(num11, num13 - 1 - (doorWidth - 1));
							}
							else
							{
								int num14 = num13 - 1 - (doorWidth - 1);
								num9 = ((num14 < num11) ? random.Next(num14, num11) : random.Next(num11, num14));
							}
							flag6 = false;
						}
						else
						{
							num9 = ((num7 != 1) ? (Height - 1) : 0);
							if (random == null)
							{
								num8 = UnityEngine.Random.Range(num10, num12 - 1 - (doorWidth - 1));
							}
							else
							{
								int num15 = num12 - 1 - (doorWidth - 1);
								num8 = ((num15 < num8) ? random.Next(num15, num10) : random.Next(num10, num15));
							}
							flag6 = true;
						}
						flag5 = false;
						if (tiles[num8, num9].type == BoardTileType.Room && (k == 1 || tiles[num8, num9].boardItem == firstRoom))
						{
							DungeonRoom dungeonRoom = (DungeonRoom)tiles[num8, num9].boardItem;
							if (!dungeonRoom.HasAirlock())
							{
								if (!flag6 && num9 == Height - 1)
								{
									num9--;
									int num16 = 0;
									num16++;
								}
								list.Add(new Coordinate2D(num8, num9));
								int num17 = num8;
								int num18 = num9;
								if (flag6)
								{
									num17++;
									if (num17 == Width)
									{
										num17 -= 2;
									}
								}
								else
								{
									num18++;
									if (num18 == Height - 1)
									{
										num18--;
									}
								}
								DungeonTile dungeonTile2 = tiles[num17, num18];
								if (dungeonTile2.type == BoardTileType.Room)
								{
									flag5 = true;
									list.Add(new Coordinate2D(num17, num18));
									break;
								}
							}
						}
					}
					num6++;
				}
				if (flag5)
				{
					foreach (Coordinate2D item in list)
					{
						tiles[item.x, item.y].type = BoardTileType.Airlock;
						tiles[item.x, item.y].empty = false;
					}
					Coordinate2D coordinate2D = new Coordinate2D(list[0].x, list[0].y);
					if (!flag6)
					{
						if (num7 == 0)
						{
							coordinate2D.x -= 6;
						}
						else
						{
							coordinate2D.x -= 3;
						}
					}
					else if (num7 == 1)
					{
						coordinate2D.y -= 6;
					}
					else
					{
						coordinate2D.y -= 3;
					}
					DungeonDoor dungeonDoor = new DungeonDoor(coordinate2D, flag6);
					dungeonDoor.airlock = true;
					if (k == 0)
					{
						dungeonDoor.initialDockingAirlock = true;
					}
					DungeonRoom dungeonRoom2 = (DungeonRoom)tiles[list[0].x, list[0].y].boardItem;
					dungeonRoom2.SetAirlock(dungeonDoor);
					dungeonDoor.AddRoom(dungeonRoom2);
					dungeonBoard.doors.Add(dungeonDoor);
					doorsWithAirlocks.Add(dungeonDoor);
				}
				else
				{
					Debug.Log("*** Safety Break on pass " + k + " ***");
				}
			}
		}
	}

	private void GenerateVents(int numVents, System.Random rnd)
	{
		int num = numVents;
		List<DungeonRoom> list = new List<DungeonRoom>();
		foreach (DungeonRoom room in dungeonBoard.rooms)
		{
			if (!room.safeRoom)
			{
				list.Add(room);
			}
		}
		while (num > 0 && list.Count() > 0)
		{
			int num2 = 0;
			num2 = ((rnd != null) ? rnd.Next(0, list.Count()) : UnityEngine.Random.Range(0, list.Count()));
			Coordinate2D coordinate2D = null;
			coordinate2D = ((rnd != null) ? PlaceInRoom(list[num2], BoardTileRoomItemType.Vent, true, rnd) : PlaceInRoom(list[num2], BoardTileRoomItemType.Vent));
			list.Remove(list[num2]);
			if (coordinate2D != null)
			{
				num--;
			}
		}
	}

	public void GenerateShipSubSystems()
	{
		int seed = (int)DateTime.Now.Ticks;
		if (SeedSubSystem != -1)
		{
			seed = SeedSubSystem;
		}
		System.Random random = new System.Random(seed);
		int num = 0;
		if (GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty != null && GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasShipUpgrade)
		{
			float num2 = 0f;
			num2 = ((GlobalSettings.gameMode != GameModeEnum.Normal) ? random.NextFloat(GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.shipUpgradeRatioMin, GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.shipUpgradeRatioMax) : UnityEngine.Random.Range(GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.shipUpgradeRatioMin, GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.shipUpgradeRatioMax));
			num = (int)((float)dungeonBoard.rooms.Count * num2);
			if (GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasShipUpgradeQty)
			{
				if (num < GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.shipUpgradeQtyMin)
				{
					num = GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.shipUpgradeQtyMin;
				}
				else if (num > GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.shipUpgradeQtyMax)
				{
					num = GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.shipUpgradeQtyMax;
				}
			}
		}
		else
		{
			int num3 = 0;
			num3 = ((GlobalSettings.gameMode != GameModeEnum.Normal) ? random.Next(4, 11) : UnityEngine.Random.Range(4, 11));
			num = dungeonBoard.rooms.Count / num3 + 1;
		}
		Coordinate2D coordinate2D = new Coordinate2D(int.MaxValue, int.MaxValue);
		Coordinate2D coordinate2D2 = new Coordinate2D(int.MinValue, int.MinValue);
		foreach (DungeonRoom room in dungeonBoard.rooms)
		{
			if (room.dimensions.x <= coordinate2D.x && room.dimensions.y <= coordinate2D.y)
			{
				coordinate2D = room.dimensions;
			}
			if (room.dimensions.x >= coordinate2D2.x && room.dimensions.y >= coordinate2D2.y)
			{
				coordinate2D2 = room.dimensions;
			}
		}
		List<DungeonRoom> list = new List<DungeonRoom>();
		bool flag = false;
		if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType != DungeonTypeEnum.Station && !GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.suppressCommandeer && !GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.suppressPermShipUpgrades)
		{
			if (ConfigFile.GetSetting("AllShipsHavePermUpgrade") != "true")
			{
				if (num > 0)
				{
					flag = ((GlobalSettings.gameMode != GameModeEnum.Normal) ? (random.Next(0, 100) < 40) : (UnityEngine.Random.Range(0, 100) < 40));
				}
			}
			else
			{
				if (num == 0)
				{
					num++;
				}
				flag = true;
			}
		}
		for (int i = 0; i < num; i++)
		{
			Coordinate2D coordinate2D3 = null;
			DungeonRoom dungeonRoom = null;
			int num4 = 0;
			do
			{
				dungeonRoom = null;
				Coordinate2D minRoomSize = null;
				if (GlobalSettings.gameMode == GameModeEnum.Normal)
				{
					minRoomSize = new Coordinate2D(UnityEngine.Random.Range(coordinate2D.x, coordinate2D2.x + 1), UnityEngine.Random.Range(coordinate2D.y, coordinate2D2.y + 1));
				}
				else
				{
					minRoomSize = new Coordinate2D(random.Next(coordinate2D.x, coordinate2D2.x + 1), random.Next(coordinate2D.y, coordinate2D2.y + 1));
				}
				IEnumerable<DungeonRoom> source = dungeonBoard.rooms.Where((DungeonRoom x) => x != null && x.dimensions.x >= minRoomSize.x && x.dimensions.y >= minRoomSize.y);
				if (source.Count() > 0)
				{
					List<DungeonRoom> list2 = source.ToList();
					if (list.Count > 0)
					{
						bool flag2 = false;
						if ((GlobalSettings.gameMode != GameModeEnum.Normal) ? (random.Next(0, 10) == 0) : (UnityEngine.Random.Range(0, 10) == 0))
						{
							IEnumerable<DungeonRoom> source2 = list.Where((DungeonRoom x) => x != null && x.dimensions.x >= minRoomSize.x && x.dimensions.y >= minRoomSize.y);
							if (source2.Count() > 0)
							{
								List<DungeonRoom> list3 = source2.ToList();
								dungeonRoom = ((GlobalSettings.gameMode != GameModeEnum.Normal) ? list3[random.Next(0, list3.Count)] : list3[UnityEngine.Random.Range(0, list3.Count)]);
							}
						}
					}
					if (dungeonRoom == null)
					{
						int num5 = -1;
						int num6 = 0;
						if (list.Count > 0)
						{
							num5 = ((GlobalSettings.gameMode != GameModeEnum.Normal) ? random.Next(0, 3) : UnityEngine.Random.Range(0, 3));
						}
						do
						{
							dungeonRoom = ((GlobalSettings.gameMode != GameModeEnum.Normal) ? list2[random.Next(0, list2.Count)] : list2[UnityEngine.Random.Range(0, list2.Count)]);
							num6++;
						}
						while (num5 == 0 && list.Contains(dungeonRoom) && num6 < 100);
						if (num6 >= 100)
						{
							num4++;
							continue;
						}
					}
					coordinate2D3 = ((GlobalSettings.gameMode == GameModeEnum.Normal) ? ((!flag || i != num - 1) ? PlaceInRoom(dungeonRoom, BoardTileRoomItemType.SubSystem) : PlaceInRoom(dungeonRoom, BoardTileRoomItemType.SubSystemPerm)) : ((!flag || i != num - 1) ? PlaceInRoom(dungeonRoom, BoardTileRoomItemType.SubSystem, true, random) : PlaceInRoom(dungeonRoom, BoardTileRoomItemType.SubSystemPerm, true, random)));
				}
				num4++;
			}
			while (coordinate2D3 == null && num4 < 100);
			if (num4 < 100)
			{
				list.Add(dungeonRoom);
				continue;
			}
			Debug.LogWarning("Broke out of GenerateShipSubSystems() due to 'safety' break.");
			break;
		}
	}

	public List<DungeonTile> GetShuffledRoomTiles(DungeonRoom room)
	{
		return GetShuffledRoomTiles(room, sysRand);
	}

	public List<DungeonTile> GetShuffledRoomTiles(DungeonRoom room, System.Random rnd)
	{
		List<DungeonTile> list = new List<DungeonTile>();
		for (int i = room.origin.x; i < room.origin.x + room.dimensions.x; i++)
		{
			for (int j = room.origin.y; j < room.origin.y + room.dimensions.y; j++)
			{
				list.Add(tiles[i, j]);
			}
		}
		return list.OrderBy((DungeonTile x) => rnd.Next()).ToList();
	}

	private List<DungeonTile> GetAdjacentTiles(DungeonTile tile)
	{
		List<DungeonTile> list = new List<DungeonTile>();
		Coordinate2D[] array = new Coordinate2D[4]
		{
			new Coordinate2D(1, 0),
			new Coordinate2D(-1, 0),
			new Coordinate2D(0, 1),
			new Coordinate2D(0, -1)
		};
		Coordinate2D[] array2 = array;
		foreach (Coordinate2D coordinate2D in array2)
		{
			Coordinate2D coordinate2D2 = tile.position + coordinate2D;
			if (coordinate2D2.x >= 0 && coordinate2D2.x < Width && coordinate2D2.y >= 0 && coordinate2D2.y < Height)
			{
				list.Add(tiles[coordinate2D2.x, coordinate2D2.y]);
			}
		}
		return list;
	}

	public Coordinate2D PlaceInRoom(DungeonRoom room, BoardTileRoomItemType roomItemType)
	{
		return PlaceInRoom(room, roomItemType, true);
	}

	public Coordinate2D PlaceInRoom(DungeonRoom room, BoardTileRoomItemType roomItemType, bool wallSpace)
	{
		return PlaceInRoom(room, roomItemType, wallSpace, sysRand);
	}

	public Coordinate2D PlaceInRoom(DungeonRoom room, BoardTileRoomItemType roomItemType, bool wallSpace, System.Random rnd)
	{
		List<DungeonTile> shuffledRoomTiles = GetShuffledRoomTiles(room, rnd);
		foreach (DungeonTile item in shuffledRoomTiles)
		{
			if (roomItemType == BoardTileRoomItemType.PowerInlet || roomItemType == BoardTileRoomItemType.FuelAccess)
			{
				if (item.position.x + 1 >= Width || item.position.y + 1 >= Height)
				{
					continue;
				}
				List<DungeonTile> list = new List<DungeonTile>();
				list.Add(item);
				list.Add(tiles[item.position.x + 1, item.position.y]);
				list.Add(tiles[item.position.x, item.position.y + 1]);
				list.Add(tiles[item.position.x + 1, item.position.y + 1]);
				bool flag = true;
				if (roomItemType == BoardTileRoomItemType.PowerInlet)
				{
					foreach (DungeonTile item2 in list)
					{
						if (!item2.empty)
						{
							flag = false;
						}
					}
				}
				else
				{
					int num = 0;
					foreach (DungeonTile item3 in list)
					{
						if (!item3.empty)
						{
							num = 0;
							break;
						}
						if (item.roomSpaceType == RoomSpaceType.Wall)
						{
							num++;
						}
					}
					if (num == 0)
					{
						flag = false;
					}
					else
					{
						int num2 = 0;
						num2++;
					}
				}
				if (!flag)
				{
					continue;
				}
				foreach (DungeonTile item4 in list)
				{
					item4.roomItemType = roomItemType;
					item4.empty = false;
				}
				switch (roomItemType)
				{
				case BoardTileRoomItemType.PowerInlet:
				{
					DungeonBoardPowerInlet powerInlet = new DungeonBoardPowerInlet(item.position);
					room.powerInlet = powerInlet;
					break;
				}
				case BoardTileRoomItemType.FuelAccess:
				{
					Coordinate2D position = item.position;
					DungeonBoardFuelAccess fuelAccess = new DungeonBoardFuelAccess(position);
					room.fuelAccess = fuelAccess;
					break;
				}
				}
				if (room.usedTiles == null)
				{
					room.usedTiles = new List<DungeonTile>();
				}
				room.usedTiles.AddRange(list);
				return new Coordinate2D(item.position.x, item.position.y + 1);
			}
			if (!item.empty || ((!wallSpace || item.roomSpaceType != RoomSpaceType.Wall) && (wallSpace || item.roomSpaceType != RoomSpaceType.Interior)))
			{
				continue;
			}
			switch (roomItemType)
			{
			case BoardTileRoomItemType.Vent:
			{
				bool horizontal = false;
				if (item.wallSpaceType.Contains(WallSpaceTileType.Bottom) || item.wallSpaceType.Contains(WallSpaceTileType.Top))
				{
					horizontal = true;
				}
				room.vent = new DungeonBoardVent(item.position, horizontal);
				break;
			}
			case BoardTileRoomItemType.Defense:
			{
				DungeonBoardDefense defense = new DungeonBoardDefense(item.position);
				room.defense = defense;
				break;
			}
			case BoardTileRoomItemType.PowerInlet:
			{
				DungeonBoardPowerInlet powerInlet2 = new DungeonBoardPowerInlet(item.position);
				room.powerInlet = powerInlet2;
				break;
			}
			case BoardTileRoomItemType.SubSystem:
			case BoardTileRoomItemType.SubSystemPerm:
				room.AddSubSystem(new DungeonBoardShipSubSystems(item.position, roomItemType == BoardTileRoomItemType.SubSystemPerm));
				break;
			}
			item.roomItemType = roomItemType;
			item.empty = false;
			if (room.usedTiles == null)
			{
				room.usedTiles = new List<DungeonTile>();
			}
			room.usedTiles.Add(item);
			return item.position;
		}
		return null;
	}
}
