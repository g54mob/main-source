using UnityEngine;

namespace GRP
{
	public class DraggablePhysicsController : MonoBehaviour
	{
		public WorldPointablePort port;

		public DraggablePhysicsConfig config;

		private float camDistance;

		private Vector3 offset;

		private bool isDragging;

		private DraggablePhysicsLine line;

		private float defLinearDamping;

		private float defAngularDamping;

		private Rigidbody rb;

		private SimShape shape;

		private PhysicsController physicsController;

		private void Start()
		{
		}

		private void OnDisable()
		{
		}

		public void PhysicsUpdate()
		{
		}

		public void LateUpdate()
		{
		}

		public void OnDown(WorldPointerEvent evt)
		{
		}

		public void OnUp(WorldPointerEvent evt)
		{
		}

		private void Clear()
		{
		}
	}
}
