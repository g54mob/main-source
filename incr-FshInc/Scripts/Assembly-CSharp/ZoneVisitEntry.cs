using System;
using UnityEngine;

[Serializable]
public class ZoneVisitEntry
{
	[Tooltip("The ZoneData ScriptableObject for the zone this applies to.")]
	public ZoneData zone;

	[Tooltip("Which visit number triggers this cutscene. 1 = first time, 3 = third time, etc. Reads and increments ZoneData.expeditionCount automatically.")]
	public int visitNumber = 1;

	[Tooltip("The sequence of cutscene entries to play on that visit.")]
	public CutsceneEntry[] sequence;
}
