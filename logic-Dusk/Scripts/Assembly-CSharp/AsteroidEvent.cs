using System;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEvent : BaseGameEvent
{
	private class SingleAsteroidEvent
	{
		public bool warningFired;

		private System.Random rndParent;

		public float timerIncomming { get; set; }

		public List<Room> potRoomList { get; set; }

		public List<float> potPerList { get; private set; }

		public Corridor dockedCorridor { get; set; }

		private SingleAsteroidEvent()
		{
		}

		public SingleAsteroidEvent(System.Random rndParent)
		{
			this.rndParent = rndParent;
		}

		public void DisplayProbabilities()
		{
			float num = timerIncomming / 60f;
			int num2 = (int)num;
			float num3 = num - (float)num2;
			SystemMessageManager.ShowSystemMessage(string.Format("Potential asteroid collision in: {0}m {1}s", num2, ((int)(60f * num3)).ToString().PadLeft(2, '0')), ConsoleMessageType.Error);
			int count = potRoomList.Count;
			for (int i = 0; i < count; i++)
			{
				if (potRoomList[i] != null)
				{
					if (potRoomList[i].boardingVessel && ((BoardingShip)potRoomList[i]).CurrentAirlock != dockedCorridor)
					{
						DungeonManager.Instance.SendConsoleMessage(string.Format("\tBoarding ship has moved out of range of incomming asteroids"), ConsoleMessageType.Info);
					}
					else
					{
						DungeonManager.Instance.SendConsoleMessage(string.Format("\tRoom {0} has a {1,4:P0} chance of being hit", potRoomList[i].Label, potPerList[i]), ConsoleMessageType.Info);
					}
				}
			}
		}

		public void CalculateProbabilities()
		{
			if (potPerList == null)
			{
				potPerList = new List<float>();
			}
			potPerList.Clear();
			int count = potRoomList.Count;
			for (int i = 0; i < count; i++)
			{
				float item = rndParent.NextFloat(0.1f, 0.8f);
				potPerList.Add(item);
			}
		}

		public void AdjustProbabilities()
		{
			int count = potPerList.Count;
			for (int i = 0; i < count; i++)
			{
				float num = potPerList[i];
				float num2 = num + num * rndParent.NextFloat(-0.25f, 0.25f);
				if (num2 > 0.95f)
				{
					num2 = 0.95f;
				}
				else if (num2 < 0.05f)
				{
					num2 = 0.05f;
				}
				potPerList[i] = num2;
			}
		}
	}

	private List<SingleAsteroidEvent> asteroidGroupList;

	public AsteroidEvent(int seed)
		: base(seed)
	{
	}

	public override void Initalize()
	{
		base.Probability = 0.1f * GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.CalculatedDifficultyValues.AsteroidValue;
		base.CheckFrequency = 120f;
		base.Cooldown = 480f;
		base.Initalize();
	}

	public override void Update()
	{
		if (asteroidGroupList != null && asteroidGroupList.Count > 0)
		{
			int count = asteroidGroupList.Count;
			for (int num = count - 1; num >= 0; num--)
			{
				SingleAsteroidEvent singleAsteroidEvent = asteroidGroupList[num];
				singleAsteroidEvent.timerIncomming -= Time.deltaTime;
				if (singleAsteroidEvent.timerIncomming <= 0f)
				{
					asteroidGroupList.RemoveAt(num);
					bool flag = false;
					int count2 = singleAsteroidEvent.potRoomList.Count;
					List<int> list = new List<int>();
					for (int i = 0; i < count2; i++)
					{
						List<float> potPerList;
						List<float> list2 = (potPerList = singleAsteroidEvent.potPerList);
						int index2;
						int index = (index2 = i);
						float num2 = potPerList[index2];
						list2[index] = num2 + rnd.NextFloat(0f, 0.9f);
						if (singleAsteroidEvent.potPerList[i] >= 1f)
						{
							list.Add(i);
						}
					}
					if (list.Count > 0)
					{
						foreach (int item in list)
						{
							if (rnd.Next(0, 100) > 0 && (!singleAsteroidEvent.potRoomList[item].boardingVessel || !(((BoardingShip)singleAsteroidEvent.potRoomList[item]).CurrentAirlock != singleAsteroidEvent.dockedCorridor)))
							{
								flag = true;
								SystemMessageManager.ShowSystemMessage(string.Format("Room {0} hit by asteroid", singleAsteroidEvent.potRoomList[item].Label), ConsoleMessageType.Warning);
								GameAudio.Play2DSFX(GameAudio.SoundEnum.AsteroidHit);
								if (singleAsteroidEvent.potRoomList.Count > item && singleAsteroidEvent.potRoomList[item] != null)
								{
									singleAsteroidEvent.potRoomList[item].DestroyByImpact("due to asteroid collision", 50, 25, 30);
								}
							}
						}
					}
					if (!flag)
					{
						SystemMessageManager.ShowSystemMessage(string.Format("Asteroids failed to collide with derelict"), ConsoleMessageType.Healthy);
					}
				}
				else if (!singleAsteroidEvent.warningFired && singleAsteroidEvent.timerIncomming <= 60f)
				{
					singleAsteroidEvent.warningFired = true;
					singleAsteroidEvent.AdjustProbabilities();
					singleAsteroidEvent.DisplayProbabilities();
				}
			}
		}
		base.Update();
	}

	public override void ExecuteEvent()
	{
		SingleAsteroidEvent singleAsteroidEvent = new SingleAsteroidEvent(rnd);
		singleAsteroidEvent.timerIncomming = rnd.NextFloat(90f, 480f);
		SingleAsteroidEvent singleAsteroidEvent2 = singleAsteroidEvent;
		DungeonManager instance = DungeonManager.Instance;
		int num = rnd.Next(1, instance.rooms.Length);
		Room room = instance.rooms[num];
		singleAsteroidEvent2.potRoomList = new List<Room>();
		singleAsteroidEvent2.potRoomList.Add(room);
		int num2 = rnd.Next(0, 4);
		if (num2 > 0)
		{
			List<Room> adjacentRooms = room.getAdjacentRooms();
			if (adjacentRooms.Count > 0)
			{
				for (int i = 0; i < num2; i++)
				{
					Room room2 = null;
					int num3 = 0;
					do
					{
						int index = rnd.Next(0, adjacentRooms.Count);
						room2 = adjacentRooms[index];
						num3++;
					}
					while (num3 < 100 && room2 != null && singleAsteroidEvent2.potRoomList.Contains(room2) && !(room2 is BoardingShip));
					if (num3 < 100)
					{
						singleAsteroidEvent2.potRoomList.Add(room2);
						continue;
					}
					break;
				}
			}
		}
		int count = singleAsteroidEvent2.potRoomList.Count;
		for (int j = 0; j < count; j++)
		{
			Room room3 = singleAsteroidEvent2.potRoomList[j];
			if (room3 != null && room3.boardingVessel)
			{
				singleAsteroidEvent2.dockedCorridor = ((BoardingShip)room3).CurrentAirlock;
				break;
			}
		}
		singleAsteroidEvent2.CalculateProbabilities();
		singleAsteroidEvent2.DisplayProbabilities();
		if (asteroidGroupList == null)
		{
			asteroidGroupList = new List<SingleAsteroidEvent>();
		}
		asteroidGroupList.Add(singleAsteroidEvent2);
		base.ExecuteEvent();
	}
}
