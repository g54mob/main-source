using UnityEngine;

namespace DV.TerrainTools
{
	public class RoadMerger : MonoBehaviour
	{
		public RoadCreator[] roadsToMerge;

		[HideInInspector]
		public bool groupOriginalRoads;

		[HideInInspector]
		public bool disableOriginalRoads;
	}
}
