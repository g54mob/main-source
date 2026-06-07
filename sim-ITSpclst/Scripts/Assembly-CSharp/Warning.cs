using System;
using UnityEngine;

[Serializable]
public class Warning
{
	public int idImageLevel;

	public string level;

	public string keywords;

	public string dateAndTime;

	public string source;

	public int idWarning;

	public string description;

	public string user;

	public string type;

	[NonSerialized]
	public Transform _object;

	public Warning(int idImageLevel, string level, string keywords, string dateAndTime, string source, int idWarning, string description, string user, string type)
	{
	}
}
