public class DoorFailEvent : BaseGameEvent
{
	public DoorFailEvent(int seed)
		: base(seed)
	{
	}

	public override void Initalize()
	{
		base.Probability = 0.3f * GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.CalculatedDifficultyValues.EventDoorValue;
		base.CheckFrequency = 225f;
		base.Cooldown = 500f;
		base.Initalize();
	}

	public override void ExecuteEvent()
	{
		DungeonManager instance = DungeonManager.Instance;
		Door door = null;
		int num = 0;
		do
		{
			int num2 = rnd.Next(0, instance.doors.Length);
			Door door2 = instance.doors[num2];
			if (!door2.IsDead && !door2.IsDisconnected && (!door2.corridor.IsAirlock || door2.corridor != BoardingShip.Instance.CurrentAirlock))
			{
				door = door2;
			}
			num++;
		}
		while (door == null && num < 100);
		if (door != null)
		{
			door.DisconnectDoor();
			SystemMessageManager.ShowSystemMessage(string.Format("'{0}' door no longer responding", door.Label), ConsoleMessageType.Warning);
		}
	}
}
