using System.Collections.Generic;

public class RoomDestroyEvent : BaseGameEvent
{
	private DungeonManager dungeonManager;

	private List<Room> redRooms;

	private List<Room> yellowRooms;

	private int chanceOfPickingYellowRoom;

	public RoomDestroyEvent(int seed)
		: base(seed)
	{
	}

	public override void Initalize()
	{
		dungeonManager = DungeonManager.Instance;
		float num = 0f;
		float num2 = 0f;
		if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.HullIntegrity != HullIntegrity.None)
		{
			switch (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.HullIntegrity)
			{
			case HullIntegrity.Good:
				base.Probability = 0.1f;
				base.CheckFrequency = 4350f;
				base.Cooldown = 500f;
				num = rnd.NextFloat(0f, 0.2f);
				num2 = 0.8f;
				chanceOfPickingYellowRoom = 30;
				break;
			case HullIntegrity.Medium:
				base.Probability = 0.25f;
				base.CheckFrequency = 350f;
				base.Cooldown = 500f;
				num = rnd.NextFloat(0.3f, 0.5f);
				num2 = 0.5f;
				chanceOfPickingYellowRoom = 20;
				break;
			case HullIntegrity.Poor:
				base.Probability = 0.45f;
				base.CheckFrequency = 350f;
				base.Cooldown = 500f;
				num = rnd.NextFloat(0.3f, 0.8f);
				num2 = 0.25f;
				chanceOfPickingYellowRoom = 20;
				break;
			}
		}
		int num3 = GalaxySaveFile.Get(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.GroupKey, "AI", 0);
		if (num3 == 2)
		{
			base.Probability *= 0.5f;
		}
		int num4 = DungeonManager.Instance.rooms.Length - 1;
		num4 = (int)((float)num4 * num);
		if (num4 == 0)
		{
			num4 = 1;
		}
		int num5 = num4;
		List<Room> list = new List<Room>();
		redRooms = new List<Room>();
		int num6 = (int)((float)num4 * num2);
		if (num4 > num6)
		{
			if (num6 > 0)
			{
				yellowRooms = new List<Room>();
			}
			if (num6 > 0)
			{
				for (int i = 0; i < num6; i++)
				{
					do
					{
						int num7 = rnd.Next(0, DungeonManager.Instance.rooms.Length);
						Room room = DungeonManager.Instance.rooms[num7];
						if (!room.boardingVessel && !list.Contains(room))
						{
							yellowRooms.Add(room);
							room.RadiationPossible = true;
							list.Add(room);
						}
					}
					while (list.Count < num6);
				}
				num4 -= num6;
			}
		}
		do
		{
			int num8 = rnd.Next(0, DungeonManager.Instance.rooms.Length);
			Room room2 = DungeonManager.Instance.rooms[num8];
			if (!room2.boardingVessel && !list.Contains(room2))
			{
				redRooms.Add(room2);
				room2.RadiationLikely = true;
				list.Add(room2);
			}
		}
		while (list.Count < num5);
		if (redRooms.Count == 0)
		{
			int num9 = 0;
			num9++;
		}
	}

	public override void ExecuteEvent()
	{
		Room room = null;
		int num = 0;
		while (room == null && num < 100)
		{
			List<Room> list = null;
			list = ((yellowRooms != null && rnd.Next(0, 100) < chanceOfPickingYellowRoom) ? yellowRooms : redRooms);
			int index = rnd.Next(0, list.Count);
			Room room2 = list[index];
			if (room2.onSchematic && !room2.boardingVessel && !room2.IsFillingWithRadiation && !room2.IsRadiated)
			{
				room = room2;
			}
			num++;
		}
		if (room != null)
		{
			room.NaturalRadiateEvent();
		}
	}
}
