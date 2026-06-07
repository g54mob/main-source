using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Utilities/VRTK_NavMeshData")]
	public class VRTK_NavMeshData : MonoBehaviour
	{
		[Tooltip("The max distance given point can be outside the nav mesh to be considered valid.")]
		public float distanceLimit = 0.1f;

		[Tooltip("The parts of the navmesh that are considered valid")]
		public int validAreas = -1;
	}
}
