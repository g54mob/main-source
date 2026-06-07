using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	[ExecuteInEditMode]
	public class UpdateColliderWidth : MonoBehaviour
	{
		public UIWidget Widget;

		public BoxCollider Collider;

		public void Update()
		{
			Vector3 center = Collider.center;
			center.x = Widget.localCenter.x;
			Collider.center = center;
			Vector3 size = Collider.size;
			size.x = Widget.width;
			Collider.size = size;
		}
	}
}
