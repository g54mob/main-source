using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class LowCompatNotification : NotificationWithStringList<Team>
{
	public LowCompatNotification()
	{
	}

	public LowCompatNotification(params Team[] items)
		: base("LowCompatWarning".Loc(), "MoreEmployees", SDateTime.Now(), NotificationManager.NotificationType.Issue, items)
	{
	}

	public override string GetID(Team item)
	{
		return item.Name;
	}

	public override IEnumerable<Team> GetObjects()
	{
		return GameSettings.Instance.sActorManager.Teams.Values;
	}

	public override void Goto(int idx = -1)
	{
		Team at = base.Items.GetAt(idx);
		HUD.Instance.TeamWindow.Init();
		HUD.Instance.TeamWindow.Window.Show();
		HUD.Instance.TeamWindow.TeamList.Select(at);
	}

	public override bool HasGoto()
	{
		return true;
	}

	public override bool HasRefresh()
	{
		return true;
	}

	public override bool IsAggregate()
	{
		return true;
	}

	public override bool Refresh()
	{
		List<Team> list = base.Items.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			Team team = list[i];
			if (team.Count < 2 || team.Compatibility > 0.25f)
			{
				RemoveItem(team);
			}
		}
		return base.Items.Count == 0;
	}
}
