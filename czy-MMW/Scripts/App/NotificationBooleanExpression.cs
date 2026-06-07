using System;
using UnityEngine;

[Serializable]
public class NotificationBooleanExpression
{
	public bool not;

	[SerializeReference]
	public INotificationCondition condition;

	public bool IsTrue(DateTime onDate, INotificationEventSystem notificationEventSystem)
	{
		if (condition == null)
		{
			Diagnostics.FailAssert("condition is null in NotificationBooleanExpression");
			return false;
		}
		bool flag = condition.Evaluate(onDate, notificationEventSystem);
		if (!not)
		{
			return flag;
		}
		return !flag;
	}
}
