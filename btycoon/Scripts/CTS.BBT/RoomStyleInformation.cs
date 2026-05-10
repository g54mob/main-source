using System.Collections.Generic;
using UnityEngine;

public struct RoomStyleInformation
{
	public Dictionary<EBarStyle, int> WallsStyles;

	public Dictionary<EBarStyle, int> FloosStyles;

	public void ToConsoleDebug()
	{
		Debug.Log("Walls");
		foreach (EBarStyle key in WallsStyles.Keys)
		{
			Debug.Log(" - " + key.ToString() + " : " + WallsStyles[key]);
		}
		Debug.Log("Floors");
		foreach (EBarStyle key2 in FloosStyles.Keys)
		{
			Debug.Log(" - " + key2.ToString() + " : " + FloosStyles[key2]);
		}
	}
}
