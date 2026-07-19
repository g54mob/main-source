using System;
using UnityEngine;

namespace VRM
{
	[DefaultExecutionOrder(11001)]
	public class VRMSpringBoneColliderGroup : MonoBehaviour
	{
		[Serializable]
		public class SphereCollider
		{
			public Vector3 Offset;

			[Range(0f, 1f)]
			public float Radius;
		}

		[SerializeField]
		public SphereCollider[] Colliders = new SphereCollider[1]
		{
			new SphereCollider
			{
				Radius = 0.1f
			}
		};

		[SerializeField]
		private Color m_gizmoColor = Color.magenta;

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = m_gizmoColor;
			Gizmos.matrix = base.transform.localToWorldMatrix * Matrix4x4.Scale(new Vector3(1f / base.transform.lossyScale.x, 1f / base.transform.lossyScale.y, 1f / base.transform.lossyScale.z));
			SphereCollider[] colliders = Colliders;
			foreach (SphereCollider sphereCollider in colliders)
			{
				Gizmos.DrawWireSphere(sphereCollider.Offset, sphereCollider.Radius);
			}
		}
	}
}
