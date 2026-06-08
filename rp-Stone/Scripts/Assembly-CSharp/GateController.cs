using System.Collections.Generic;
using UnityEngine;

public class GateController
{
	public enum State
	{
		EasySection = 0,
		HardSection = 1,
		BossFight = 2,
		AreaComplete = 3,
		FinalBoss = 4,
		Done = 5
	}

	private bool DEBUG_VERBOSE;

	private State currentState = State.Done;

	private Dictionary<string, GateData> gatesLoaded = new Dictionary<string, GateData>();

	private GateData currentGate;

	private GateData.Area currentArea;

	private List<GateData.Area> unplayedAreas = new List<GateData.Area>();

	private Data.Quest currentQuest;

	private int questIndex;

	public State CurrentState => currentState;

	public GateData CurrentGate => currentGate;

	public GateData.Area CurrentArea => currentArea;

	public Data.Quest CurrentQuest => currentQuest;

	public int EnemiesKilled { get; set; }

	private void ClearStateData()
	{
		currentState = State.Done;
		currentGate = null;
		currentArea = null;
		unplayedAreas.Clear();
		currentQuest = null;
		questIndex = 0;
		EnemiesKilled = 0;
		Character.OnCharacterDied -= HandleOnCharacterDied;
	}

	public void PlayGate(string gateId)
	{
		if (DEBUG_VERBOSE)
		{
			Utils.Log("Play Gate " + gateId);
		}
		ClearStateData();
		currentState = State.AreaComplete;
		Character.OnCharacterDied += HandleOnCharacterDied;
		currentGate = GetOrLoadGate(gateId);
		if (currentGate == null)
		{
			return;
		}
		if (currentGate.areas == null || currentGate.areas.Length == 0)
		{
			Utils.LogError("No area data found for Gate " + gateId);
			return;
		}
		for (int i = 0; i < currentGate.areas.Length; i++)
		{
			if (DEBUG_VERBOSE)
			{
				Utils.Log("Adding area " + currentGate.areas[i].id);
			}
			unplayedAreas.Add(currentGate.areas[i]);
		}
		Next();
	}

	private void HandleOnCharacterDied(Character character, Character.DeathReason reason, Damage damage)
	{
		if (currentState != State.Done && character is Enemy)
		{
			EnemiesKilled++;
		}
	}

	public void Next()
	{
		if (currentState == State.FinalBoss || currentState == State.Done)
		{
			currentState = State.Done;
			return;
		}
		questIndex++;
		if (currentState == State.AreaComplete)
		{
			if (unplayedAreas.Count > 0)
			{
				questIndex = -1;
				currentArea = GetRandomUnplayedArea();
				currentState = State.EasySection;
				Next();
			}
			else if (currentGate.finalBoss != null && currentGate.finalBoss != "")
			{
				currentQuest = currentGate.GetQuestById(currentGate.finalBoss);
				if (currentQuest == null)
				{
					Utils.LogError("Problem loading final boss for gate " + currentGate.id);
					currentState = State.Done;
				}
				else
				{
					currentState = State.FinalBoss;
				}
			}
			else
			{
				currentState = State.Done;
			}
		}
		else if (currentState == State.BossFight || (currentArea != null && questIndex >= currentArea.questIds.Length))
		{
			currentState = State.AreaComplete;
		}
		else
		{
			currentQuest = currentGate.GetQuestById(currentArea.questIds[questIndex]);
			switch (questIndex)
			{
			case 0:
				currentState = State.EasySection;
				break;
			case 1:
				currentState = State.HardSection;
				break;
			default:
				currentState = State.BossFight;
				break;
			}
		}
	}

	private GateData.Area GetRandomUnplayedArea(bool removeFromList = true)
	{
		int index = Random.Range(0, unplayedAreas.Count);
		GateData.Area area = unplayedAreas[index];
		if (DEBUG_VERBOSE)
		{
			Utils.Log("Random Area Selected: " + area.id);
		}
		if (removeFromList)
		{
			unplayedAreas.Remove(area);
		}
		return area;
	}

	public void EndGate()
	{
		ClearStateData();
	}

	public GateData GetOrLoadGate(string gateId)
	{
		if (gatesLoaded.ContainsKey(gateId))
		{
			return gatesLoaded[gateId];
		}
		GateData gateData = LoadGate("Quests/Gates/" + gateId);
		if (gateData != null)
		{
			gatesLoaded.Add(gateId, gateData);
		}
		return gateData;
	}

	public GateData LoadGate(string gateFilePath)
	{
		TextAsset textAsset = Resources.Load(gateFilePath) as TextAsset;
		if (textAsset == null)
		{
			Utils.LogError("Failed to load gate at " + gateFilePath);
			return null;
		}
		if (DEBUG_VERBOSE)
		{
			Utils.Log("Gate File: " + textAsset.text);
		}
		return GateData.FromString(textAsset.text);
	}

	public GateData.Result GenerateResult()
	{
		GateData.Result result = new GateData.Result();
		result.enemiesKilled = EnemiesKilled;
		result.moneyLeft = (int)InventoryResources.singleton.GetResourceOfType(Data.Resource.Xi);
		result.consumablePoints = 0;
		result.totalScore = result.enemiesKilled;
		result.totalScore += result.moneyLeft;
		result.totalScore += result.consumablePoints;
		return result;
	}
}
