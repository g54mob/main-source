using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "roomtypefilter_data", menuName = "Database/Room Type Filter")]
public class RoomTypeFilter : SoCustomComparison
{
	[Header("Room Types")]
	public List<RoomClassPreset> roomClasses;
}
