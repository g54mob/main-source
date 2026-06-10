using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[Serializable]
public class TimelineEvent : IComparable<TimelineEvent>
{
	public enum EventType
	{
		sightingStreet = 0,
		sightingWindow = 1,
		sightingHere = 2,
		sightingArrive = 3,
		sightingDepart = 4,
		selfArrive = 5,
		selfDepart = 6,
		wakeUp = 7,
		goToBed = 8,
		heardSound = 9,
		nonPersonSighting = 10,
		smell = 11,
		questioned = 12,
		delayBegin = 13,
		delayEnd = 14,
		timeOfDeath = 15,
		sightingWentToBed = 16,
		sightingWokeUp = 17,
		forcedEntryInvestigate = 18
	}

	public delegate void OnNameChange();

	public delegate void RecallAccuracyChange();

	public delegate void OnCalledUponTimeUpdate();

	public string name;

	public string detail;

	[NonSerialized]
	public bool intialised;

	public EventType eventType;

	public bool isSelfLocational;

	public bool isGlobalEvent;

	public int eventID;

	public static int assignEventID;

	public NewNode location;

	public float happenedAt;

	public float timeAccuracy;

	[NonSerialized]
	public float totalSuspicion;

	public bool calledUpon;

	[NonSerialized]
	public EventTime eventTime;

	[NonSerialized]
	public List<TimelineEvent> childEvents;

	[NonSerialized]
	public TimelineEvent parentEvent;

	public bool discoveredByQuestioned;

	public int debugLocationID;

	public string debugLocationName;

	public event OnNameChange OnNameChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event RecallAccuracyChange OnRecallAccuracyChange
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event OnCalledUponTimeUpdate OnCalledUponTimeUpdated
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public TimelineEvent(EventType newType, NewNode newLocation, TimelineEvent newParentEvent, bool autoCallUpon, bool overrideHappenedAt = false, float happenedOverride = 0f)
	{
	}

	public virtual void UpdateName()
	{
	}

	public void AddChildEventToThis(TimelineEvent newTied)
	{
	}

	public virtual void CallUpon(bool forceAccuracy = false, int forceAccuracyToMinutes = 0)
	{
	}

	public void SetTimeRecallAccuracy(float newVal)
	{
	}

	public void OnTimeUpdated()
	{
	}

	public virtual void OnAppearInTimeline()
	{
	}

	public int CompareTo(TimelineEvent otherObject)
	{
		return 0;
	}
}
