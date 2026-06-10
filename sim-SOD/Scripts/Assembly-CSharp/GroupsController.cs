using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class GroupsController : MonoBehaviour
{
	[Serializable]
	public class SocialGroup
	{
		public string preset;

		public int id;

		public float decimalStartTime;

		public List<SessionData.WeekDay> weekDays;

		public List<int> members;

		public int meetingPlace;

		[NonSerialized]
		public List<Interactable> reserved;

		public NewAddress GetMeetingPlace()
		{
			return null;
		}

		public float GetNextMeetingTime()
		{
			return 0f;
		}

		public GroupPreset GetPreset()
		{
			return null;
		}
	}

	[Header("Groups")]
	public List<SocialGroup> groups;

	public static int assignID;

	private static GroupsController _instance;

	public static GroupsController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void CreateGroups()
	{
	}

	public bool GetVmailGroupParticiapnts(SocialGroup group, GroupPreset.MeetUpVmailSender setting, out List<Human> particiapnts)
	{
		particiapnts = null;
		return false;
	}

	public void LoadGroups()
	{
	}

	public bool DecimalTimeFinder(GroupPreset g, List<Citizen> people, out float appropriateTime, out List<SessionData.WeekDay> availableDays)
	{
		appropriateTime = default(float);
		availableDays = null;
		return false;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ListCurrentMeetupLocations()
	{
	}
}
