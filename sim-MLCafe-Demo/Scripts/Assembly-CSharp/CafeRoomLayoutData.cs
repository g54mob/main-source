using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CafeRoomLayoutData
{
	public int remainingRoomExtension;

	public SerializedMapCell[] map = new SerializedMapCell[0];

	public CafeRoomLayoutData()
	{
		remainingRoomExtension = 0;
		Vector2Int maxSize = ShopBuilder.GetMaxSize();
		map = new SerializedMapCell[maxSize.x * maxSize.y];
	}

	public static SerializedMapCell[] CreateMapData(List<RoomComponent> roomComponents, Vector2Int size)
	{
		SerializedMapCell[] array = new SerializedMapCell[size.x * size.y];
		int num = 0;
		for (int i = 0; i < size.x; i++)
		{
			for (int j = 0; j < size.y; j++)
			{
				Vector2Int position = new Vector2Int(i, j);
				RoomComponent roomComponent = roomComponents.Find((RoomComponent r) => r.GetPosition() == position);
				int type = -1;
				if (roomComponent != null)
				{
					type = (int)roomComponent.roomType;
				}
				array[num] = new SerializedMapCell(new Vector2Int(i, j), type);
				num++;
			}
		}
		return array;
	}
}
