public abstract class EventObjectiveBase
{
	public string id;

	public int goal;

	public string description;

	public int maxPlayCount = -1;

	public int rewardPoints = 1;

	public int progress;

	public int timesCompleted;

	private bool isAvailableOnPC = true;

	private bool isAvailableOnMobile = true;

	public bool hasChangedDescription { get; set; }

	public EventObjectiveRow.State state { get; set; }

	public int elapsedTics { get; set; }

	public string titleTid { get; set; }

	public string extraInfo { get; set; }

	public bool isPreventingLocationStatsUpdate { get; set; }

	public EventObjectiveBase(string id, int goal)
	{
		this.id = id;
		this.goal = goal;
	}

	public abstract void Init();

	public abstract void End();

	public virtual bool CheckConditions()
	{
		return isAvailableOnPC;
	}

	public virtual void ResetProgress()
	{
		progress = 0;
	}

	public bool IsComplete()
	{
		return progress >= goal;
	}

	public float GetPercent()
	{
		if (goal <= 0)
		{
			return 0f;
		}
		return (float)progress / (float)goal;
	}

	public void AddProgress(int amount = 1, int showStars = 0)
	{
		int num = progress;
		progress += amount;
		if (progress > goal)
		{
			progress = goal;
		}
		if (progress > num)
		{
			CustomQuestsUi.Singleton.customQuestProgressCard.Setup(null, num, progress, goal, description, showStars);
			GameStates.Singleton.customQuestsScreen.MarkDirty();
			if (progress == goal)
			{
				CustomQuestsUi.Singleton.customQuestProgressCard.LevelUpAnim();
				CustomQuestsController.Singleton.UpdateBadge();
			}
		}
	}

	public EventObjectiveBase SetMaxPlays(int value)
	{
		maxPlayCount = value;
		return this;
	}

	public EventObjectiveBase SetPoints(int value)
	{
		rewardPoints = value;
		return this;
	}

	public EventObjectiveBase SetPC(bool enabled)
	{
		isAvailableOnPC = enabled;
		return this;
	}

	public EventObjectiveBase SetMobile(bool enabled)
	{
		isAvailableOnMobile = enabled;
		return this;
	}

	public EventObjectiveBase SetTitle(string titleTid)
	{
		this.titleTid = titleTid;
		return this;
	}

	public EventObjectiveBase SetInfo(string extraInfoTid)
	{
		extraInfo = extraInfoTid;
		return this;
	}

	public EventObjectiveBase PreventLocationStatsUpdate()
	{
		isPreventingLocationStatsUpdate = true;
		return this;
	}

	public virtual void ClearProgress()
	{
		progress = 0;
		timesCompleted = 0;
	}

	public virtual bool IsDefaultValues()
	{
		if (progress == 0)
		{
			return timesCompleted == 0;
		}
		return false;
	}

	public void Parse(string sjson)
	{
		ClearProgress();
		if (sjson != null)
		{
			progress = SlimJson.ParseInt(sjson, "p");
			timesCompleted = SlimJson.ParseInt(sjson, "tc");
			ParseMore(sjson);
		}
	}

	public string Serialize()
	{
		SlimJson.BeginSerialization();
		if (progress > 0)
		{
			SlimJson.AddProperty("p", progress);
		}
		if (timesCompleted > 0)
		{
			SlimJson.AddProperty("tc", timesCompleted);
		}
		SerializeMore();
		return SlimJson.EndSerialization();
	}

	protected virtual void ParseMore(string sjson)
	{
	}

	protected virtual void SerializeMore()
	{
	}

	public string TranslateIfTID(string text)
	{
		if (text.StartsWith("tid_"))
		{
			return Te.xt(text);
		}
		return text;
	}
}
