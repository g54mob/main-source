using NSMedieval;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.Village;

public static class PrisonerUtil
{
	public static bool FindJailCellPositionForEscort(CreatureBase jailerEscort, out Vec3Int position)
	{
		position = Vec3Int.zero;
		foreach (Room item in VillageManager.ActiveVillage.Map.RoomDetection.IterateRoomsSafe())
		{
			if (item.RoomType.Prison && item.TryGetRandomReachablePositionInRoom(jailerEscort, out var position2))
			{
				position = position2;
				break;
			}
		}
		return position != Vec3Int.zero;
	}
}
