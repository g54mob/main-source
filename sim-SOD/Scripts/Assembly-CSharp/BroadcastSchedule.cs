using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "broadcastschedule_data", menuName = "Database/Broadcast Schedule")]
public class BroadcastSchedule : SoCustomComparison
{
	[Header("Contents")]
	public List<BroadcastPreset> broadcasts;
}
