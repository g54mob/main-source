using UnityEngine;

namespace UniHumanoid
{
	public class BoneGizmoDrawer : MonoBehaviour
	{
		private const float size = 0.03f;

		private readonly Vector3 SIZE = new Vector3(0.03f, 0.03f, 0.03f);

		[SerializeField]
		public bool Draw = true;

		private void OnDrawGizmos()
		{
		}
	}
}
