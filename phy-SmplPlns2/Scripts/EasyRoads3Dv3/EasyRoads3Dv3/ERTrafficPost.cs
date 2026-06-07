using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERTrafficPost : MonoBehaviour
	{
		[Header("Traffic Post Offsets")]
		public ERRoadSide roadSide;

		public float scale = 1f;

		public float sidewaysOffset = 0f;

		public bool includeSidewalks = true;

		public float forwardOffset = 0f;

		public int relativePosition = 0;

		public ERTrafficPostType postType = ERTrafficPostType.TrafficLight;

		[HideInInspector]
		public bool isset = false;
	}
}
