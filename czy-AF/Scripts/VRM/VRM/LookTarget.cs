using UniGLTF;
using UnityEngine;

namespace VRM
{
	public class LookTarget : MonoBehaviour
	{
		[SerializeField]
		public Transform Target;

		[SerializeField]
		private Vector3 m_offset = new Vector3(0f, 0.05f, 0f);

		[SerializeField]
		[Range(0f, 3f)]
		private float m_distance = 0.7f;

		public OffsetOnTransform m_offsetTransform;

		private void Update()
		{
			if (Target != m_offsetTransform.Transform)
			{
				m_offsetTransform = OffsetOnTransform.Create(Target);
			}
			Transform transform = m_offsetTransform.Transform;
			if (transform != null)
			{
				Vector3 vector = transform.position + m_offset;
				base.transform.position = vector + m_offsetTransform.WorldMatrix.ExtractRotation() * Vector3.forward * m_distance;
				base.transform.LookAt(vector);
			}
		}
	}
}
