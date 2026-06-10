using System;
using UnityEngine;

[Serializable]
public class DayCutsceneEntry
{
	[Tooltip("The global day number (GameManager.CurrentDay) that triggers this cutscene.")]
	public int dayNumber;

	[Tooltip("The sequence of cutscene entries to play on that day.")]
	public CutsceneEntry[] sequence;
}
