using System;
using UnityEngine;

[Serializable]
public class EndlessMapData
{
	[SerializeField]
	private bool isActivated;

	[SerializeField]
	private eEndlessModeType endlessModeType;

	[SerializeField]
	private bool hasWeekIndex;

	[SerializeField]
	private int weekIndex;

	[SerializeField]
	private string levelName;

	[SerializeField]
	private Sprite levelSprite;

	[SerializeField]
	private string locTitleString;

	[SerializeField]
	private string locDescriptionString;

	public bool IsActivated => false;

	public eEndlessModeType EndlessModeType => default(eEndlessModeType);

	public bool HasWeekIndex => false;

	public int WeekIndex => 0;

	public string LevelName => null;

	public Sprite LevelSprite => null;

	public string LocTitleString => null;

	public string LocDescriptionString => null;
}
