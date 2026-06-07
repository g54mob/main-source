using UnityEngine;

namespace ModApi.Planet
{
	public class StructureLaunchLocationInfoScript : MonoBehaviour
	{
		[SerializeField]
		private double _heading;

		[SerializeField]
		private string _name = "Launch Location";

		public double Heading => _heading;

		public string Name => _name;

		[ContextMenu("Snap to Collider")]
		private void SnapToCollider()
		{
			if (base.gameObject.scene.GetPhysicsScene().Raycast(base.transform.position, -base.transform.up, out var hitInfo, 1000f, 603979776))
			{
				Debug.Log($"Snapped to collider. Moved {hitInfo.point - base.transform.position}");
				base.transform.position = hitInfo.point;
			}
			else
			{
				Debug.Log("No collision");
			}
		}
	}
}
