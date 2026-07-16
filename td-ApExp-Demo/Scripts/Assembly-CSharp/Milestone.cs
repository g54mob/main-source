using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Localization;

public class Milestone : ScriptableObject
{
	[NonSerialized]
	public int ProgressPercent;

	[field: SerializeField]
	public string Name { get; set; }

	[field: SerializeField]
	[field: TextArea(20, 20)]
	public string Description { get; set; }

	[field: SerializeField]
	public int CoresGain { get; set; }

	[field: SerializeField]
	public LocalizedString NameKey { get; private set; }

	[field: SerializeField]
	public LocalizedString DescriptionKey { get; private set; }

	[field: SerializeField]
	public Sprite Icon { get; set; }

	[field: SerializeField]
	public bool SingleRun { get; set; }

	[field: SerializeField]
	public bool Completed { get; set; }

	[field: SerializeField]
	public Enhancement Unlock { get; set; }

	[field: SerializeField]
	protected virtual float Goal { get; set; }

	[field: SerializeField]
	public float Progress { get; set; }

	[field: SerializeField]
	[field: Tooltip("If you leave this field as 0 it will not check for the time")]
	public float TimeInSeconds { get; private set; }

	[field: SerializeField]
	[field: Tooltip("If you leave it as Regular it will not check for a specific train")]
	public TrainType TrainType { get; private set; }

	protected MilestoneTypes Type { get; set; }

	public void Initialize()
	{
		if (GameManager.Instance.isDemo)
		{
			Unlock.Locked = true;
		}
		else if (Unlock != null && !Completed)
		{
			Unlock.Locked = true;
		}
		else if (Unlock != null && Completed)
		{
			Unlock.Locked = false;
		}
		if (SingleRun)
		{
			ResetProgress();
		}
		OnInitialize();
	}

	protected virtual void OnInitialize()
	{
	}

	public virtual void SimulateUpdate()
	{
	}

	public void UpdateProgress()
	{
		if (!MilestoneManager.Instance.canUpdateProgress)
		{
			return;
		}
		if (Progress >= Goal && !Completed)
		{
			if (!MilestoneManager.Instance.loadingFromSave)
			{
				Complete();
			}
			else
			{
				Completed = true;
			}
		}
		if (Unlock != null)
		{
			if (Unlock.LockedOnRuntime && !Completed)
			{
				Unlock.Locked = true;
			}
			else
			{
				Unlock.Locked = false;
			}
		}
		ProgressPercent = Mathf.RoundToInt(Progress / Goal * 100f);
		if (ProgressPercent == 100 && !Completed)
		{
			ProgressPercent = 99;
		}
		if (ProgressPercent == 0 && !Completed && Progress > 0f)
		{
			ProgressPercent = 1;
		}
	}

	public virtual void Complete()
	{
		if (MilestoneManager.Instance.canUpdateProgress && !Completed)
		{
			Completed = true;
			Unlock.Locked = false;
			UIManager.Instance.MilestoneUnlockPopup.ShowPopup(Unlock, "New Unlock");
			MilestoneManager.Instance.AddNewUnlock(this);
			ResourceManager.Instance.LootCores(CoresGain);
			MilestoneManager.Instance.DisplayCoresGainFromMilestone(DisplayCoresGain());
		}
	}

	private IEnumerator DisplayCoresGain()
	{
		HUD.Instance.ShowCoresCounter(show: true);
		yield return new WaitForSecondsRealtime(3f);
		if (LevelManager.Instance.CurrentLevel.LevelType != LevelType.Hub && !LevelManager.Instance.IsAtDestination)
		{
			HUD.Instance.ShowCoresCounter(show: false, isMilestone: true);
		}
	}

	public virtual void AddProgress()
	{
		if (MilestoneManager.Instance.canUpdateProgress && !Completed && (TimeInSeconds == 0f || !(GameManager.Instance.playtimeInRun >= TimeInSeconds)) && (TrainType == TrainType.Regular || TrainType == Train.Instance.currentTrain.trainType))
		{
			Progress += 1f;
			UpdateProgress();
			if (Progress >= Goal)
			{
				Complete();
			}
		}
	}

	public virtual void ResetProgress()
	{
		Progress = 0f;
		ProgressPercent = 0;
	}
}
