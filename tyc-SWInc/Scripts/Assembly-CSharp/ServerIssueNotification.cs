using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class ServerIssueNotification : NotificationWithList<string>
{
	public ServerIssueNotification()
	{
	}

	public ServerIssueNotification(string group)
		: base("ServerLoadWarning".Loc(), "Server", SDateTime.Now(), NotificationManager.NotificationType.Issue, new string[1] { group })
	{
	}

	public override void Goto(int idx = -1)
	{
		ServerGroup serverGroup = GameSettings.Instance.GetServerGroup(Items.GetAt(idx));
		if (serverGroup != null)
		{
			HUD.Instance.serverWindow.Window.Show();
			HUD.Instance.serverWindow.ServerList.Select(serverGroup);
		}
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
		List<string> list = Items.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			ServerGroup serverGroup = GameSettings.Instance.GetServerGroup(list[i]);
			if (serverGroup == null || serverGroup.Available > 0f)
			{
				RemoveItem(list[i]);
			}
		}
		return Items.Count == 0;
	}
}
