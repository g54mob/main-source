using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltSystem : MonoBehaviour, ISavable
{
	private const float CONVEYOR_BELT_SYSTEM_TICK = 0.02f;

	public static ConveyorBeltSystem instance;

	[Savable("conveyorBeltGroups", false, false)]
	private List<ConveyorBeltGroup> conveyorBeltGroups;

	private Coroutine updateConveyorBeltSystemCoroutine;

	private Dictionary<string, object> loadedData;

	private bool hasEndedLoading;

	private void Awake()
	{
		instance = this;
		conveyorBeltGroups = new List<ConveyorBeltGroup>();
	}

	public ConveyorBeltGroup CreateConveyorBeltGroup(List<ConveyorBelt> belts, List<Resource> resources)
	{
		ConveyorBeltGroup conveyorBeltGroup = new ConveyorBeltGroup(belts, resources);
		conveyorBeltGroups.Add(conveyorBeltGroup);
		return conveyorBeltGroup;
	}

	private void Start()
	{
		this.StartCoroutineCheckingVar(UpdateConveyorBeltSystemCoroutine(), ref updateConveyorBeltSystemCoroutine);
		if ((bool)LTFunctionLibrary.GetLTGameManager())
		{
			LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
			if ((object)lTGameManager != null && lTGameManager.GameState == LTGameManager.EGameState.Playing)
			{
				OnGameStarted();
				return;
			}
			LTGameManager lTGameManager2 = LTFunctionLibrary.GetLTGameManager();
			lTGameManager2.onGameStarted = (Action)Delegate.Combine(lTGameManager2.onGameStarted, new Action(OnGameStarted));
		}
		else
		{
			hasEndedLoading = true;
		}
	}

	private void OnGameStarted()
	{
		if (loadedData != null && loadedData.ContainsKey("conveyorBeltGroups"))
		{
			StartCoroutine(LoadBeltGroupsCoroutine(loadedData["conveyorBeltGroups"] as List<Dictionary<string, object>>));
		}
		else
		{
			hasEndedLoading = true;
		}
	}

	private IEnumerator UpdateConveyorBeltSystemCoroutine()
	{
		float counter = 0f;
		while (!hasEndedLoading)
		{
			yield return null;
		}
		while (true)
		{
			counter += Time.deltaTime;
			if (counter > 0.02f)
			{
				for (int i = 0; i < conveyorBeltGroups.Count; i++)
				{
					conveyorBeltGroups[i].MoveResources(counter);
					conveyorBeltGroups[i].AddResourceFromStorage();
				}
				counter = 0f;
			}
			yield return null;
		}
	}

	public void RemoveConveyorBeltGroup(ConveyorBeltGroup groupToRemove)
	{
		conveyorBeltGroups.Remove(groupToRemove);
	}

	public void MergeConveyorBeltGroups(ConveyorBeltGroup firstGroup, ConveyorBeltGroup secondGroup)
	{
		float groupDistance = firstGroup.GroupDistance;
		int count = firstGroup.Belts.Count;
		firstGroup.AddBelts(secondGroup.Belts, addAtBeginning: false);
		firstGroup.AddResources(secondGroup.Resources, addAtBeginning: false, groupDistance, count);
		firstGroup.OutputStorage = secondGroup.OutputStorage;
		RemoveConveyorBeltGroup(secondGroup);
	}

	public void SplitConveyorBeltGroup(ConveyorBeltGroup group, ConveyorBelt belt)
	{
		int beltIndex = group.GetBeltIndex(belt);
		_ = group.GroupDistance;
		int num = 0;
		List<ConveyorBelt> list = new List<ConveyorBelt>();
		List<Resource> list2 = new List<Resource>();
		list = group.Belts.GetRange(beltIndex + 1, group.Belts.Count - (beltIndex + 1));
		for (int num2 = group.Belts.Count - 1; num2 >= beltIndex; num2--)
		{
			group.RemoveLastBelt(removeResources: false, num2 == beltIndex);
		}
		num = group.Resources.Count;
		for (int i = 0; i < group.Resources.Count; i++)
		{
			if (group.Resources[i].CurrentConveyorBeltIdx <= beltIndex)
			{
				num = i;
				break;
			}
			group.Resources[i].CurrentConveyorBeltIdx -= beltIndex + 1;
			group.Resources[i].TraveledDistance -= group.GroupDistance + belt.GetBeltDistance();
		}
		list2 = group.Resources.GetRange(0, num);
		group.Resources.RemoveRange(0, num);
		ConveyorBeltGroup conveyorBeltGroup = CreateConveyorBeltGroup(list, list2);
		if ((bool)group.OutputStorage)
		{
			conveyorBeltGroup.OutputStorage = group.OutputStorage;
			group.OutputStorage = null;
		}
	}

	private IEnumerator LoadBeltGroupsCoroutine(List<Dictionary<string, object>> groupsDatas)
	{
		yield return null;
		foreach (ConveyorBeltGroup conveyorBeltGroup in conveyorBeltGroups)
		{
			foreach (Dictionary<string, object> groupsData in groupsDatas)
			{
				if (conveyorBeltGroup.Id == groupsData["id"] as string)
				{
					SaveSystem.LoadObjectData(conveyorBeltGroup, groupsData);
				}
			}
		}
		hasEndedLoading = true;
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		loadedData = data;
	}
}
