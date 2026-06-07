using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class HelpBoxAttribute : PropertyAttribute
{
	public enum EType
	{
		NONE = 0,
		INFO = 1,
		WARNING = 2,
		ERROR = 3
	}

	public readonly string content;

	public readonly EType type;

	public HelpBoxAttribute(string content, EType type)
	{
		this.content = content;
		this.type = type;
	}
}
