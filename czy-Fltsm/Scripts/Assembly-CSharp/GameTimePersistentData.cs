using System;

[Serializable]
public class GameTimePersistentData
{
	public DayPersistentData[] Days;

	public GameTimePersistentData()
	{
		int count = GameManager.TimeManager.Days.Count;
		Days = new DayPersistentData[count];
		for (int i = 0; i < count; i++)
		{
			Days[i] = new DayPersistentData(GameManager.TimeManager.Days[i]);
		}
	}

	public void Restore()
	{
		GameManager.TimeManager.Restore(Days);
	}
}
