using UnityEngine;

namespace PG
{
	[CreateAssetMenu(fileName = "LayerSettings", menuName = "GameBalance/Settings/LayerSettings")]
	public class LayerSettings : ScriptableObject
	{
		public LayerMask ResetCarTrigger;

		public LayerMask RoadMask;

		public LayerMask VehicleMask;
	}
}
