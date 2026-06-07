using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class WorkIssueNotification : NotificationWithList<WorkItem>
{
	public enum Issue
	{
		LateProductRelease = 0,
		SupportWorkSlowWarning = 1,
		LeadDesignerOwnerError = 2,
		LeadDesignerAutoError = 3,
		LeadDesignerInspirationWarning = 4,
		MissingBugReporters = 5
	}

	public readonly Issue IssueType;

	public WorkIssueNotification()
	{
	}

	public static string GetIcon(Issue issue)
	{
		switch (issue)
		{
		case Issue.LateProductRelease:
			return "Calendar";
		case Issue.LeadDesignerOwnerError:
		case Issue.LeadDesignerAutoError:
		case Issue.LeadDesignerInspirationWarning:
			return "Paper";
		case Issue.SupportWorkSlowWarning:
		case Issue.MissingBugReporters:
			return "Info";
		default:
			return "Info";
		}
	}

	public WorkIssueNotification(Issue issue, params WorkItem[] items)
		: base(issue.ToString().Loc(), GetIcon(issue), SDateTime.Now(), NotificationManager.NotificationType.Issue, items)
	{
		IssueType = issue;
	}

	public static bool CheckAggregate(WorkItem item, Issue issue)
	{
		return NotificationManager.CheckAggregate<WorkIssueNotification>(item, (uint)issue);
	}

	public override uint AggregateID()
	{
		return (uint)IssueType;
	}

	public override bool HasRefresh()
	{
		return true;
	}

	public static bool CheckIssue(Issue issue, WorkItem target)
	{
		switch (issue)
		{
		case Issue.LateProductRelease:
			if (!target.Done)
			{
				return ((SoftwareWorkItem)target).ReleaseDate.Value > SDateTime.Now();
			}
			return true;
		case Issue.SupportWorkSlowWarning:
			if (!target.Done)
			{
				return SDateTime.GetHours(((SupportWork)target).LastMissed, SDateTime.Now()) >= 2f;
			}
			return true;
		case Issue.MissingBugReporters:
		{
			SupportWork supportWork = (SupportWork)target;
			if (!target.Done && supportWork.TargetProduct.Bugss != 0 && supportWork.DevTeams.Count != 0)
			{
				return supportWork.DevTeams.SelectNotNull(GameSettings.GetTeam).Any((Team z) => z.GetEmployeesDirect().Any((Actor x) => target.HasWork(x, x.SecondaryWork, false) != WorkItem.HasWorkReturn.NotApplicable && x.employee.GetSpecialization(Employee.EmployeeRole.Service, "Support") > 0));
			}
			return true;
		}
		case Issue.LeadDesignerOwnerError:
		case Issue.LeadDesignerAutoError:
		{
			if (target.Done)
			{
				return true;
			}
			AutoDevWorkItem autoDevWorkItem;
			if ((autoDevWorkItem = target as AutoDevWorkItem) != null)
			{
				if (autoDevWorkItem.Items.Count <= ((!autoDevWorkItem.SingleIP && !autoDevWorkItem.IsFunctionallySingleIP()) ? 1 : 0))
				{
					return autoDevWorkItem.Items.Any((AutoDevWorkItem.AutoDevItem x) => !x.Queued && x.Design);
				}
				return true;
			}
			return ((DesignDocument)target).LeadDesigner != null;
		}
		case Issue.LeadDesignerInspirationWarning:
			if (!target.Done && ((DesignDocument)target).Iteration <= 0 && ((DesignDocument)target).LeadDesigner != null)
			{
				return ((DesignDocument)target).LeadDesigner.GetActualInspiration() > 1f;
			}
			return true;
		default:
			return false;
		}
	}

	public override void Goto(int idx = -1)
	{
		GUIWorkItem guiItem = Items.GetAt(idx).guiItem;
		if (guiItem != null)
		{
			guiItem.Highlight();
		}
	}

	public override bool Refresh()
	{
		List<WorkItem> list = Items.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			WorkItem workItem = list[i];
			if (CheckIssue(IssueType, workItem))
			{
				RemoveItem(workItem);
			}
		}
		return Items.Count == 0;
	}

	public override bool IsAggregate()
	{
		return true;
	}
}
