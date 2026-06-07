using System;

[Serializable]
public class HRMissing : NotificationMessage
{
	[NonSerialized]
	private Team _team;

	private readonly string _teamName;

	public Team Team
	{
		get
		{
			if (_team == null)
			{
				_team = GameSettings.Instance.sActorManager.Teams.GetOrDefault(_teamName);
			}
			return _team;
		}
		set
		{
			_team = value;
		}
	}

	public HRMissing()
	{
	}

	public HRMissing(Team team)
		: base("NoHRWarning".LocColor(team.Name), "MoreEmployees", SDateTime.Now(), NotificationManager.NotificationType.Issue)
	{
		_team = team;
		_teamName = team.Name;
	}

	public override void Goto(int idx = -1)
	{
		if (Team != null)
		{
			HUD.Instance.TeamWindow.Init();
			HUD.Instance.TeamWindow.Window.Show();
			HUD.Instance.TeamWindow.TeamList.Select(Team);
		}
	}

	public override int GetCount()
	{
		return 1;
	}

	public override bool HasGoto()
	{
		return true;
	}

	public override bool HasRefresh()
	{
		return true;
	}

	public override bool Refresh()
	{
		if (Team != null && !(Team.Leader != null))
		{
			return !GameSettings.Instance.sActorManager.Teams.ContainsKey(_teamName);
		}
		return true;
	}

	public override bool IsDismissable()
	{
		return true;
	}
}
