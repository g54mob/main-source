using System.Collections.Generic;
using UnityEngine;

public class LevelView : MonoBehaviourBaseView
{
	public const string LevelStartedEvent = "LevelView.LevelStartedEvent";

	public const string GoalCompletedEvent = "LevelView.GoalCompletedEvent";

	public const string AttackerFailedEvent = "LevelView.AttackerFailedEvent";

	public const string DefenderFailedEvent = "LevelView.DefenderFailedEvent";

	public const string AttackerBrainDestroyedEvent = "LevelView.AttackerBrainDestroyedEvent";

	public const string DefenderBrainDestroyedEvent = "LevelView.DefenderBrainDestroyedEvent";

	public const string CollectablesLoadedEvent = "LevelView.CollectablesLoadedEvent";

	public const string CollectablesRestoredEvent = "LevelView.CollectablesRestoredEvent";

	public const string CollectablePickedUpEvent = "LevelView.CollectablePickedUpEvent";

	private GoalTrigger goalTrigger;

	private FailTrigger[] failTriggers;

	private bool isLevelPaused;

	private List<DynamicObjectBase> dynamicObjects;

	private List<LevelCollectable> levelCollectables;

	public bool IsLevelRunning { get; private set; }

	public float LevelTimerCounter { get; private set; }

	public bool IsLevelPaused
	{
		get
		{
			return isLevelPaused;
		}
		set
		{
			isLevelPaused = value;
			if (goalTrigger != null)
			{
				goalTrigger.IsTimerPaused = isLevelPaused;
			}
		}
	}

	public void Initialize()
	{
		if (LevelManager.Instance.goalZone != null)
		{
			goalTrigger = LevelManager.Instance.goalZone.GetComponent<GoalTrigger>();
			goalTrigger.GoalAchivedEvent += GoalCompletedHandler;
		}
		if (LevelManager.Instance.failureZones != null)
		{
			failTriggers = LevelManager.Instance.failureZones.GetComponentsInChildren<FailTrigger>();
			FailTrigger[] array = failTriggers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].FailedEvent += FailedHandler;
			}
		}
		LevelTimerCounter = 0f;
		IsLevelRunning = false;
		IsLevelPaused = false;
		dynamicObjects = new List<DynamicObjectBase>();
		GetDynamicObjects();
		levelCollectables = new List<LevelCollectable>();
		LoadCollectables();
	}

	private void GetDynamicObjects()
	{
		dynamicObjects.AddRange(LevelManager.Instance.dynamicObjectsFolder.transform.GetComponentsInChildren<DynamicObjectBase>(includeInactive: true));
	}

	private void LoadCollectables()
	{
		levelCollectables.AddRange(LevelManager.Instance.collectableFolder.transform.GetComponentsInChildren<LevelCollectable>(includeInactive: true));
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < levelCollectables.Count; i++)
		{
			if (levelCollectables[i].Type == LevelCollectable.CollectableType.Gold)
			{
				num++;
			}
			else if (levelCollectables[i].Type == LevelCollectable.CollectableType.Silver)
			{
				num2++;
			}
			levelCollectables[i].OnCollectedEvent += delegate(LevelCollectable.CollectableType type)
			{
				NotifyChange("LevelView.CollectablePickedUpEvent", type);
			};
		}
		NotifyChange("LevelView.CollectablesLoadedEvent", num, num2);
	}

	private void Update()
	{
		if (IsLevelRunning && !IsLevelPaused)
		{
			LevelTimerCounter += Time.deltaTime;
		}
	}

	private void GoalCompletedHandler()
	{
		StopLevel();
		NotifyChange("LevelView.GoalCompletedEvent", LevelTimerCounter);
	}

	private void FailedHandler(CreationView.CreationRoleState creationRole)
	{
		StopLevel();
		switch (creationRole)
		{
		case CreationView.CreationRoleState.Attacker:
			NotifyChange("LevelView.AttackerFailedEvent");
			break;
		case CreationView.CreationRoleState.Defender:
			NotifyChange("LevelView.DefenderFailedEvent", LevelTimerCounter);
			break;
		}
	}

	public void AttackerBrainDestroyedHandler()
	{
		StopLevel();
		NotifyChange("LevelView.AttackerBrainDestroyedEvent");
	}

	public void DefenderBrainDestroyedHandler()
	{
		StopLevel();
		NotifyChange("LevelView.DefenderBrainDestroyedEvent", LevelTimerCounter);
	}

	private void SetZonesActive(bool isActive)
	{
		if (goalTrigger != null)
		{
			goalTrigger.enabled = isActive;
		}
		if (failTriggers != null && failTriggers.Length != 0)
		{
			FailTrigger[] array = failTriggers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = isActive;
			}
		}
	}

	public void StartLevel()
	{
		ResetLevel();
		SetZonesActive(isActive: true);
		IsLevelRunning = true;
		NotifyChange("LevelView.LevelStartedEvent");
	}

	public void ResetLevel()
	{
		LevelTimerCounter = 0f;
		if (LevelManager.Instance.goalZone != null)
		{
			goalTrigger.ResetTrigger();
		}
		if (LevelManager.Instance.failureZones != null)
		{
			FailTrigger[] array = failTriggers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Reset();
			}
		}
	}

	public void StopLevel()
	{
		SetZonesActive(isActive: false);
		IsLevelRunning = false;
	}

	public void SetCollectablesInteractivity(bool isInteractive)
	{
		for (int i = 0; i < levelCollectables.Count; i++)
		{
			levelCollectables[i].SetInteractive(isInteractive);
		}
		if (isInteractive)
		{
			NotifyChange("LevelView.CollectablesRestoredEvent");
		}
	}

	public ICollection<DynamicObjectBase> GetAllDynamicObjects()
	{
		return dynamicObjects;
	}
}
