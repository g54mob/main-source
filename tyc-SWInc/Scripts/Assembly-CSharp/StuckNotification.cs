using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class StuckNotification : SelectableNotificationNoDrop<Actor>
{
	public StuckNotification()
	{
	}

	public StuckNotification(params Actor[] items)
		: base("StuckEmployee".Loc(), "Path", SDateTime.Now(), NotificationManager.NotificationType.Issue, items)
	{
	}

	public override IEnumerable<Actor> GetObjects()
	{
		foreach (Actor actor in GameSettings.Instance.sActorManager.Actors)
		{
			yield return actor;
		}
		foreach (Actor item in GameSettings.Instance.sActorManager.Staff)
		{
			yield return item;
		}
		foreach (KeyValuePair<string, HashSet<Actor>> other in GameSettings.Instance.sActorManager.Others)
		{
			foreach (Actor item2 in other.Value)
			{
				yield return item2;
			}
		}
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
		return base.Items.Count((Actor x) => x != null) == 0;
	}
}
