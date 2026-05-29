using UnityEngine;

namespace Gley.TrafficSystem.Internal
{
	public class TrafficModules : MonoBehaviour
	{
		[SerializeField]
		private bool _pathFinding;

		public bool PathFinding => false;

		public void SetModules(bool enablePathFinding)
		{
		}
	}
}
