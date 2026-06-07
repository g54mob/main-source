using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class UniqueIDAttribute : PropertyAttribute
{
	public string GroupName { get; private set; }

	public UniqueIDAttribute(string groupName = "")
	{
		GroupName = groupName;
	}
}
