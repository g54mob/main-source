using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomComponent : MonoBehaviour
{
	public enum RoomType
	{
		CafeArea = 0,
		StaffArea = 1
	}

	[SerializeField]
	private WallComponent[] walls = new WallComponent[4];

	[SerializeField]
	private BoxCollider floorCollider;

	[SerializeField]
	private bool isBorderRoom;

	[SerializeField]
	private bool isStartRoom;

	[SerializeField]
	private bool predefinedStaticRoom;

	[SerializeField]
	private Vector2Int roomDimension = new Vector2Int(2, 2);

	[SerializeField]
	private Vector2Int roomPosition;

	public RoomType roomType;

	[ContextMenu("Refresh Room")]
	private void RefreshRoom()
	{
		for (int i = 0; i < walls.Length; i++)
		{
			walls[i].visualizer.Init();
			walls[i].visualizer.SwitchWallSet();
		}
	}

	public void InitRoom(Vector2Int position, bool outsideWall = false, WallComponent.WallFaceDirection[] outsideWalls = null)
	{
		roomPosition = position;
		floorCollider.size = new Vector3(roomDimension.x, 0.05f, roomDimension.y);
		if (!isStartRoom)
		{
			base.transform.position = ShopBuilder.GetStartOffset() + new Vector3(position.x * roomDimension.x, 0f, position.y * roomDimension.y);
		}
		isBorderRoom = outsideWall;
		if (predefinedStaticRoom)
		{
			WallComponent[] array = walls;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].outsideWall = true;
			}
			walls.ToList().ForEach(delegate(WallComponent wall)
			{
				wall.visualizer.ApplyRoomData(roomPosition, wall.Direction);
			});
			return;
		}
		for (int num = 0; num < walls.Length; num++)
		{
			walls[num].visualizer.ApplyRoomData(roomPosition, walls[num].Direction);
			if (!outsideWall)
			{
				walls[num].visualizer.ApplyWallInt();
				continue;
			}
			for (int num2 = 0; num2 < outsideWalls.Length; num2++)
			{
				if (walls[num].Direction == outsideWalls[num2])
				{
					isBorderRoom = true;
					walls[num].outsideWall = true;
					if (isStartRoom)
					{
						walls[num].visualizer.ApplyDoorArcExt();
					}
					else if (outsideWalls[num2] == ShopBuilder.GetWindowSide())
					{
						walls[num].visualizer.ApplyWindowExt();
					}
					else
					{
						walls[num].visualizer.ApplyWallExt();
					}
					break;
				}
				walls[num].outsideWall = false;
				walls[num].visualizer.ApplyWallInt();
			}
		}
	}

	public void ApplyRoomProperties(Vector2Int position, bool outsideWall = false, WallComponent.WallFaceDirection[] outsideWalls = null)
	{
		roomPosition = position;
		floorCollider.size = new Vector3(roomDimension.x, 0.05f, roomDimension.y);
		if (!isStartRoom)
		{
			base.transform.position = ShopBuilder.GetStartOffset() + new Vector3(position.x * roomDimension.x, 0f, position.y * roomDimension.y);
		}
		isBorderRoom = outsideWall;
		if (predefinedStaticRoom)
		{
			WallComponent[] array = walls;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].outsideWall = true;
			}
		}
		else
		{
			for (int j = 0; j < walls.Length; j++)
			{
				walls[j].visualizer.ApplyRoomData(roomPosition, walls[j].Direction);
			}
		}
	}

	public bool IsStartRoom()
	{
		return isStartRoom;
	}

	public Vector2Int GetPosition()
	{
		return roomPosition;
	}

	public Vector2Int GetDimensions()
	{
		return roomDimension;
	}

	public WallComponent[] GetWalls()
	{
		return walls;
	}

	public void PaintRoom(WallPaintSaveData[] roomPaint)
	{
		if (roomPaint == null || roomPaint.Length == 0)
		{
			return;
		}
		int i;
		for (i = 0; i < walls.Length; i++)
		{
			WallPaintSaveData[] wallPaint = (from x in roomPaint.ToList()
				where x.wall == walls[i].Direction
				select x).ToArray();
			walls[i].visualizer.ApplyPaint(wallPaint);
		}
	}

	private WallComponent GetWallFacingDirection(WallComponent[] walls, WallComponent.WallFaceDirection direction)
	{
		return walls.ToList().Find((WallComponent x) => x.Direction == direction);
	}

	public WallComponent GetWallFacingDirection(WallComponent.WallFaceDirection direction)
	{
		return GetWallFacingDirection(walls, direction);
	}

	public WallComponent.WallFaceDirection[] GetOutsideWalls()
	{
		List<WallComponent.WallFaceDirection> list = new List<WallComponent.WallFaceDirection>();
		List<WallComponent> list2 = walls.ToList().FindAll((WallComponent x) => x.outsideWall);
		for (int num = 0; num < list2.Count; num++)
		{
			list.Add(list2[num].Direction);
		}
		return list.ToArray();
	}

	public void ConnectRoomOnSide(WallComponent[] newRoomWalls, WallComponent.WallFaceDirection direction)
	{
		if (!predefinedStaticRoom)
		{
			GetWallFacingDirection(walls, direction).Hide();
			GetWallFacingDirection(newRoomWalls, WallComponent.GetOppositeDirection(direction)).Hide();
		}
	}
}
