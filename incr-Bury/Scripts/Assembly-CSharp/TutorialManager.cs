using System;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
	public static TutorialManager Singleton;

	public List<GameObject> tutorialGroups;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	private void Start()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnNightTime_Action = (Action)Delegate.Combine(singleton.OnNightTime_Action, new Action(OnNightTime));
	}

	private void OnDestroy()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnNightTime_Action = (Action)Delegate.Remove(singleton.OnNightTime_Action, new Action(OnNightTime));
	}

	public void OnRoundStart_TutorialCheck()
	{
		switch (PlayerStats.Singleton.totalRounds)
		{
		case 0:
			ShowTutorialGroup(0);
			break;
		case 1:
			ShowTutorialGroup(2);
			break;
		default:
			HideAllTutorialGroups();
			break;
		}
	}

	public void OnNightTime()
	{
		if (PlayerStats.Singleton.totalRounds == 0)
		{
			ShowTutorialGroup(1);
		}
		else
		{
			HideAllTutorialGroups();
		}
	}

	public void HideAllTutorialGroups()
	{
		foreach (GameObject tutorialGroup in tutorialGroups)
		{
			tutorialGroup.SetActive(value: false);
		}
	}

	public void ShowTutorialGroup(int _groupIndex)
	{
		HideAllTutorialGroups();
		if (PlayerStats.Singleton.disableTutorials)
		{
			return;
		}
		try
		{
			tutorialGroups[_groupIndex].SetActive(value: true);
			PickUppable[] componentsInChildren = tutorialGroups[_groupIndex].GetComponentsInChildren<PickUppable>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].gameObject.transform.SetParent(null);
			}
		}
		catch
		{
			Debug.Log("Failed to show Tutorial Group, probably index out of range. Ignoring!");
		}
	}
}
