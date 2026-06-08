using System.Collections.Generic;
using UnityEngine;

public class GameEventManager
{
	private List<BaseGameEvent> gameEventList = new List<BaseGameEvent>();

	private List<BaseGameEvent> gameEventToRemoveList = new List<BaseGameEvent>();

	public static GameEventManager Instance { get; private set; }

	public GameEventManager()
	{
		Instance = this;
	}

	public void AddEvent(BaseGameEvent gameEvent)
	{
		if (!GlobalSettings.IsTutorial || !gameEvent.IgnoreInTutorial)
		{
			if (!gameEventList.Contains(gameEvent))
			{
				gameEvent.Initalize();
				gameEventList.Add(gameEvent);
			}
			else
			{
				Debug.Log("This event already added to GameEventManager " + gameEvent.ToString());
			}
		}
	}

	public void RemoveEvent(BaseGameEvent gameEvent)
	{
		if (gameEventList.Contains(gameEvent))
		{
			gameEventToRemoveList.Add(gameEvent);
		}
	}

	public void Update()
	{
		if (GlobalSettings.IsGamePaused)
		{
			return;
		}
		bool flag = true;
		if (GlobalSettings.GameState.ThePlayer != null && GlobalSettings.GameState.ThePlayer.CurrentStarSystem != null && GlobalSettings.GameState.ThePlayer.CurrentStarSystem.IsNursery)
		{
			flag = false;
		}
		if (!flag)
		{
			return;
		}
		int count = gameEventList.Count;
		for (int i = 0; i < count; i++)
		{
			gameEventList[i].Update();
		}
		if (gameEventToRemoveList.Count > 0)
		{
			count = gameEventToRemoveList.Count;
			for (int j = 0; j < count; j++)
			{
				gameEventToRemoveList.Remove(gameEventToRemoveList[j]);
			}
			gameEventToRemoveList.Clear();
		}
	}
}
