using System.Collections.Generic;
using UnityEngine;

namespace viperOSK
{
	[CreateAssetMenu(fileName = "viperOSK_AccentMap", menuName = "ScriptableObjects/viperOSK_AccentMap", order = 1)]
	public class OSK_AccentAssetObj : ScriptableObject
	{
		public List<AccentEntry> entries;
	}
}
