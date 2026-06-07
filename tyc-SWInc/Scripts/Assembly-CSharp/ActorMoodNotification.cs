using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class ActorMoodNotification : EmployeeNotification
{
	public enum Issue
	{
		FreezingWarning = 0,
		BurningWarning = 1,
		NoSeeWarning = 2,
		NoiseWarning = 3,
		UnsatisfiedWarning = 4,
		StressWarning = 5,
		SocialWarning = 6,
		StarvingWarning = 7,
		HasToPeeWarning = 8,
		WornOutWarning = 9,
		OtherTeamWarning = 10,
		NoSittingWarning = 11,
		RoomDirtyWarning = 12,
		RoomDirtyWarning2 = 13,
		BadBenefitWarning = 14,
		NightShiftWarning = 15,
		LeadDesignBreachWarning = 16,
		RoomSmellyWarning = 17,
		LongCommuteWarning = 18,
		ComputerBadWarning = 19,
		AirQualityBadWarning = 20
	}

	public readonly Issue IssueType;

	public ActorMoodNotification()
	{
	}

	public static string GetIcon(Issue issue)
	{
		switch (issue)
		{
		case Issue.FreezingWarning:
			return "Snowflake";
		case Issue.BurningWarning:
			return "Thermometer";
		case Issue.NoSeeWarning:
			return "Eye";
		case Issue.NoiseWarning:
			return "Speaker";
		case Issue.UnsatisfiedWarning:
		case Issue.LeadDesignBreachWarning:
			return "Sad";
		case Issue.StressWarning:
		case Issue.SocialWarning:
		case Issue.WornOutWarning:
		case Issue.BadBenefitWarning:
		case Issue.NightShiftWarning:
		case Issue.RoomSmellyWarning:
			return "Sad";
		case Issue.OtherTeamWarning:
			return "MoreEmployees";
		case Issue.HasToPeeWarning:
		case Issue.NoSittingWarning:
			return "Furniture";
		case Issue.RoomDirtyWarning:
		case Issue.RoomDirtyWarning2:
			return "Trash";
		case Issue.StarvingWarning:
			return "Fork";
		case Issue.LongCommuteWarning:
			return "Clock";
		case Issue.ComputerBadWarning:
			return "Computer";
		case Issue.AirQualityBadWarning:
			return "Air";
		default:
			return "Info";
		}
	}

	public ActorMoodNotification(Issue issue, params Employee[] items)
		: base(issue.ToString().Loc(), GetIcon(issue), SDateTime.Now(), NotificationManager.NotificationType.Issue, items)
	{
		IssueType = issue;
	}

	public override uint AggregateID()
	{
		return (uint)IssueType;
	}

	public override bool HasRefresh()
	{
		return true;
	}

	public static bool CheckIssue(Issue issue, Employee target)
	{
		switch (issue)
		{
		case Issue.FreezingWarning:
		case Issue.BurningWarning:
			return CheckAffector(target, Actor.Affector.Temperature);
		case Issue.NoSeeWarning:
			return CheckAffector(target, Actor.Affector.Lighting);
		case Issue.UnsatisfiedWarning:
			return target.JobSatisfaction < 1.01f;
		case Issue.StressWarning:
			return CheckMood(target, "StressProblem");
		case Issue.NoiseWarning:
			return CheckMood(target, "NoiseComplaint");
		case Issue.SocialWarning:
			return CheckMood(target, "SocialProblem");
		case Issue.StarvingWarning:
			return CheckMood(target, "Starving");
		case Issue.HasToPeeWarning:
			return CheckMood(target, "HasToPee");
		case Issue.WornOutWarning:
			return CheckMood(target, "WornOut");
		case Issue.OtherTeamWarning:
			return CheckMood(target, "OtherTeamComplaint");
		case Issue.NoSittingWarning:
			return CheckMood(target, "NoSitting");
		case Issue.RoomDirtyWarning:
			return CheckMood(target, "RoomLowEnv");
		case Issue.RoomDirtyWarning2:
			return CheckMood(target, "RoomDirty");
		case Issue.BadBenefitWarning:
			return CheckMood(target, "BadBenefits");
		case Issue.NightShiftWarning:
			return CheckMood(target, "NightShiftWork");
		case Issue.LeadDesignBreachWarning:
			if (!CheckMood(target, "LeadDemandBreach"))
			{
				if (target.Founder)
				{
					return CheckAffector(target, Actor.Affector.DemandBreach);
				}
				return false;
			}
			return true;
		case Issue.RoomSmellyWarning:
			return CheckMood(target, "RoomSmells");
		case Issue.LongCommuteWarning:
			return CheckMood(target, "LongCommute");
		case Issue.ComputerBadWarning:
			return CheckMood(target, "ComputerBad");
		case Issue.AirQualityBadWarning:
			return CheckMood(target, "AirQualityBad");
		default:
			return false;
		}
	}

	public override bool IsDismissable()
	{
		return IssueType == Issue.UnsatisfiedWarning;
	}

	private static bool CheckMood(Employee ac, string mood)
	{
		Employee.ThoughtEffect value;
		if (ac.Thoughts.TryGetValue(mood, out value))
		{
			return value.Effect >= value.Mood.WarningThreshold;
		}
		return false;
	}

	private static bool CheckAffector(Employee ac, Actor.Affector af)
	{
		float num = ac.MyActor.Affactors[(int)af];
		if (num < -0.1f)
		{
			return num > -2f;
		}
		return false;
	}

	public override bool Refresh()
	{
		List<Employee> list = Employees.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			Employee employee = list[i];
			if (employee.MyActor == null || employee.MyActor.SpecialState != Actor.HomeState.Default || !CheckIssue(IssueType, employee))
			{
				RemoveItem(employee);
			}
		}
		return Employees.Count == 0;
	}
}
