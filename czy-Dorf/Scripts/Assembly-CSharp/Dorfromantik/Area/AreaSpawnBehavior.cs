using UnityEngine;

namespace Dorfromantik.Area
{
	public class AreaSpawnBehavior : ScriptableObject
	{
		[SerializeField]
		internal Vector2Int tilesCountMinMax = new Vector2Int(0, 0);

		[SerializeField]
		internal Vector2Int edgeAreaSlotSegmentCountMinMax = new Vector2Int(0, 0);

		[SerializeField]
		internal int totalSpawnIterations;

		[SerializeField]
		internal int completionPercentageNeeded;
	}
}
